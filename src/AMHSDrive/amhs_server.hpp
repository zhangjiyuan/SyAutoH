#pragma once
#include <algorithm>
#include <cstdlib>
#include <deque>
#include <iostream>
#include <list>
#include <set>
#include <map>
#include <boost/bind.hpp>
#include <boost/shared_ptr.hpp>
#include <boost/enable_shared_from_this.hpp>
#include <boost/asio.hpp>
#include "amhs_message.hpp"

using boost::asio::ip::tcp;

//----------------------------------------------------------------------

typedef std::deque<amhs_message> amhs_message_queue;
enum AMHS_DEV_TYPE
{
	DEV_TYPE_UNKNOW = 0,
	DEV_TYPE_OHT = 1,
	DEV_TYPE_STOCKER = 2
};



//----------------------------------------------------------------------

class amhs_participant
{
public:
	virtual ~amhs_participant() {}
	virtual void deliver(const amhs_message& msg) = 0;
public:
	int nID_;
	int nDevType_;
};

typedef boost::shared_ptr<amhs_participant> amhs_participant_ptr;

typedef struct
{
	int nID;
	int nPOS;
	int nHand;
	amhs_participant_ptr p_participant;
} amhs_OHT;
typedef boost::shared_ptr<amhs_OHT> amhs_oht_ptr;
typedef std::map<int, amhs_oht_ptr> amhs_oht_map;
typedef std::set<amhs_oht_ptr> amhs_oht_set;
//----------------------------------------------------------------------

class amhs_room
{
public:
	void join(amhs_participant_ptr participant)
	{
		participants_.insert(participant);
	}

	void leave(amhs_participant_ptr participant)
	{
		if (DEV_TYPE_OHT == participant->nDevType_)
		{
			amhs_oht_map::iterator it = oht_map_.find(participant->nID_);
			if (it != oht_map_.end())
			{
				oht_map_.erase(it);
			}
		}
		participants_.erase(participant);
	}

	amhs_oht_set GetOhtDataSet()
	{
		amhs_oht_set oht_set;
		for (amhs_oht_map::iterator it = oht_map_.begin();
			it != oht_map_.end(); ++it)
		{
			oht_set.insert(it->second);
		}
		return oht_set;
	}

	void SendPacket(amhs_participant_ptr participants, AMHSPacket &ack)
	{
		amhs_message msg;

		msg.body_length(ack.size());
		msg.command(ack.GetOpcode());
		msg.IsNeedRespond(true);
		memcpy(msg.body(), ack.contents(), msg.body_length());
		msg.encode_header();

		participants->deliver(msg);
	}

	int DecodePacket(amhs_participant_ptr participants, AMHSPacket* Packet)
	{
		int mOpcode = Packet->GetOpcode();
		switch(mOpcode)
		{
		case OHT_POSITION:
			{
				uint8		ohtID = 0;
				uint16		ohtPosition = 0;
				*Packet >> ohtID;
				*Packet >> ohtPosition;
				//printf("OHT POS  ---> id: %d, pos: %d\n", ohtID, ohtPosition);
				amhs_oht_map::iterator it = oht_map_.find(ohtID);
				if (it != oht_map_.end())
				{
					it->second->nPOS = ohtPosition;
				}
			}
			break;
		case OHT_AUTH:
			{
				uint8		ohtID = 0;
				uint16		ohtPosition = 0;
				uint8		ohtHand = 0;
				*Packet >> ohtID;
				*Packet >> ohtPosition;
				*Packet >> ohtHand;
				printf("OHT Auth  ---> id: %d, pos: %d, hand: %d\n", ohtID, ohtPosition, ohtHand);
				participants->nID_ = ohtID;
				participants->nDevType_ = DEV_TYPE_OHT;
				delete Packet;
				
				amhs_oht_map::iterator it = oht_map_.find(ohtID);
				uint8 nAuthAck = 0;
				if (it != oht_map_.end())
				{
					nAuthAck = 0;
				}
				else
				{
					amhs_oht_ptr pOht = amhs_oht_ptr(new amhs_OHT());
					pOht->nID = ohtID;
					pOht->nPOS = ohtPosition;
					pOht->nHand = ohtHand;
					pOht->p_participant = participants;
					oht_map_.insert(std::make_pair(ohtID, pOht));
					nAuthAck = 1;
				}

				AMHSPacket ack(OHT_MCS_ACK_AUTH, 2);
				ack << uint8(ohtID);
				ack << nAuthAck;
				SendPacket(participants, ack);

				//__time64_t ltime;
				//_time64( &ltime );
				//char bufTime[256] = "";
				//_ctime64_s(bufTime, &ltime);
				//printf( "The time is %s\n", bufTime ); // C4996
			}
			break;
		case STK_AUTH:
			{
				uint8 stockerID = 0;
				uint32 uIP = 0;
				*Packet >> stockerID;
				*Packet >> uIP;
				struct in_addr addr1;

				memcpy(&addr1, &uIP, 4);
				char* sIP = inet_ntoa(addr1);
				printf("STOCKER Auth ---> id: %d, ip: %s\n", stockerID, sIP);
				participants->nDevType_ = DEV_TYPE_STOCKER;
				participants->nID_ = stockerID;
				delete Packet;

				AMHSPacket ack(STK_MCS_ACK_AUTH, 10);
				ack << uint8(stockerID);
				ack << uint8(1);
				__time64_t ltime;
				_time64( &ltime );
				ack << uint64(ltime);

				SendPacket(participants, ack);
			}
			break;
		default:
			{
				return -1;
			}
			break;
		}

		return 0;
	}

	void deliver_all(const amhs_message& msg)
	{
		//recent_msgs_.push_back(msg);
		//while (recent_msgs_.size() > max_recent_msgs)
			//recent_msgs_.pop_front();

		std::for_each(participants_.begin(), participants_.end(),
			boost::bind(&amhs_participant::deliver, _1, boost::ref(msg)));
	}

	int GetCount()
	{
		return participants_.size();
	}

private:
	std::set<amhs_participant_ptr> participants_;
	enum { max_recent_msgs = 100 };
	amhs_message_queue recent_msgs_;
	amhs_oht_map oht_map_;
};

//----------------------------------------------------------------------

class amhs_session
	: public amhs_participant,
	public boost::enable_shared_from_this<amhs_session>
{
public:
	amhs_session(boost::asio::io_service& io_service, amhs_room& room)
		: socket_(io_service),
		room_(room)
	{
		nDevType_ = DEV_TYPE_UNKNOW;
		nID_ = -1;
	}

	tcp::socket& socket()
	{
		return socket_;
	}

	void PutSocketInfo(tcp::socket& socket_)
	{
		tcp::socket::endpoint_type ep = socket_.remote_endpoint();
		std::string sIP = ep.address().to_string();
		unsigned int uPort = ep.port();
		std::cout<< "socket IP: " << sIP << " Port: " << uPort << std::endl;
	}

	void start()
	{
		room_.join(shared_from_this());
		boost::asio::async_read(socket_,
			boost::asio::buffer(read_msg_.data(), amhs_message::header_length),
			boost::bind(
			&amhs_session::handle_read_header, shared_from_this(),
			boost::asio::placeholders::error));
		
		PutSocketInfo(socket_);
	}

	void deliver(const amhs_message& msg)
	{
		bool write_in_progress = !write_msgs_.empty();
		write_msgs_.push_back(msg);
		if (!write_in_progress)
		{
			boost::asio::async_write(socket_,
				boost::asio::buffer(write_msgs_.front().data(),
				write_msgs_.front().length()),
				boost::bind(&amhs_session::handle_write, shared_from_this(),
				boost::asio::placeholders::error));
		}
	}

	void handle_read_header(const boost::system::error_code& error)
	{
		if (!error && read_msg_.decode_header())
		{
			boost::asio::async_read(socket_,
				boost::asio::buffer(read_msg_.body(), read_msg_.body_length()),
				boost::bind(&amhs_session::handle_read_body, shared_from_this(),
				boost::asio::placeholders::error));
			//PutSocketInfo(socket_);
		}
		else
		{
			room_.leave(shared_from_this());
		}
	}

	void handle_read_body(const boost::system::error_code& error)
	{
		if (!error)
		{
			int mOpcode = read_msg_.command();
			int mSize = read_msg_.body_length();
			if (mSize > 0)
			{
				AMHSPacket* Packet;
				Packet = new AMHSPacket(static_cast<uint16>(mOpcode), mSize);
				Packet->resize(mSize);

				memcpy((void*)Packet->contents(), read_msg_.body(), mSize);
				int nDecode = room_.DecodePacket(shared_from_this(), Packet);
				if (nDecode < 0)
				{
					room_.deliver_all(read_msg_);
				}
			}

			boost::asio::async_read(socket_,
				boost::asio::buffer(read_msg_.data(), amhs_message::header_length),
				boost::bind(&amhs_session::handle_read_header, shared_from_this(),
				boost::asio::placeholders::error));
		}
		else
		{
			room_.leave(shared_from_this());
		}
	}

	void handle_write(const boost::system::error_code& error)
	{
		if (!error)
		{
			write_msgs_.pop_front();
			if (!write_msgs_.empty())
			{
				boost::asio::async_write(socket_,
					boost::asio::buffer(write_msgs_.front().data(),
					write_msgs_.front().length()),
					boost::bind(&amhs_session::handle_write, shared_from_this(),
					boost::asio::placeholders::error));
			}
		}
		else
		{
			room_.leave(shared_from_this());
		}
	}

private:
	tcp::socket socket_;
	amhs_room& room_;
	amhs_message read_msg_;
	amhs_message_queue write_msgs_;
};

typedef boost::shared_ptr<amhs_session> amhs_session_ptr;

//----------------------------------------------------------------------

class amhs_dev_server
{
public:
	amhs_dev_server(boost::asio::io_service& io_service,
		const tcp::endpoint& endpoint)
		: io_service_(io_service),
		acceptor_(io_service, endpoint)
	{
		start_accept();
	}

	void start_accept()
	{
		amhs_session_ptr new_session(new amhs_session(io_service_, room_));
		acceptor_.async_accept(new_session->socket(),
			boost::bind(&amhs_dev_server::handle_accept, this, new_session,
			boost::asio::placeholders::error));
	}

	void handle_accept(amhs_session_ptr session,
		const boost::system::error_code& error)
	{
		if (!error)
		{
			session->start();
		}

		start_accept();
	}

	int GetConnectCount()
	{
		return room_.GetCount();
	}

	amhs_oht_set GetOhtDataSet()
	{
		return room_.GetOhtDataSet();
	}

	void setOhtMessageBackTime(int nID, int ms)
	{
		AMHSPacket packet(OHT_MCS_STATUS_BACK_TIME, 2);
		packet<< uint8(nID);
		packet<< uint8(ms);

		amhs_message msg;

		msg.body_length(packet.size());
		msg.command(packet.GetOpcode());
		msg.IsNeedRespond(true);
		memcpy(msg.body(), packet.contents(), msg.body_length());
		msg.encode_header();
		room_.deliver_all(msg);
	}

private:
	boost::asio::io_service& io_service_;
	tcp::acceptor acceptor_;
	amhs_room room_;
};

typedef boost::shared_ptr<amhs_dev_server> amhs_server_ptr;
typedef std::list<amhs_server_ptr> amhs_server_list;