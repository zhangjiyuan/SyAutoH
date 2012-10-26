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
	amhs_room();
	void join(amhs_participant_ptr participant);
	void leave(amhs_participant_ptr participant);
	amhs_oht_set GetOhtDataSet();
	void SendPacket(amhs_participant_ptr participants, AMHSPacket &ack);
	int DecodePacket(amhs_participant_ptr participants, AMHSPacket& Packet);
	void deliver_all(const amhs_message& msg);
	int GetCount();

private:
	////
	//OHT_ACK_STATUS_BACK_TIME				= 0x0811,
	//	OHT_ACK_POSITION_BACK_TIME				= 0x0812,	
	//	OHT_ACK_PATH											= 0x0813,	
	//	OHT_ACK_MOVE											= 0x0814,
	//	OHT_ACK_FOUP											= 0x0815,
	//	OHT_AUTH													= 0x0816,
	//	OHT_POSITION												= 0x0817,
	//	OHT_STATUS												= 0x0818,
	void Handle_OHT_AckStatusBackTime(amhs_participant_ptr, AMHSPacket&);
	void Handle_OHT_AckPosBackTime(amhs_participant_ptr, AMHSPacket&);
	void Handle_OHT_AckPath(amhs_participant_ptr, AMHSPacket&);
	void Handle_OHT_AckMove(amhs_participant_ptr, AMHSPacket&);
	void Handle_OHT_AckFoup(amhs_participant_ptr, AMHSPacket&);
	void Handle_OHT_Auth(amhs_participant_ptr, AMHSPacket&);
	void Handle_OHT_Pos(amhs_participant_ptr, AMHSPacket&);
	void Handle_OHT_Status(amhs_participant_ptr, AMHSPacket&);

	////
	//STK_ACK_FOUP											= 0x0820,
	//	STK_ACK_STATUS										= 0x0821,
	//	STK_ACK_ROOM											= 0x0822,
	//	STK_ACK_STORAGE										= 0x0823,
	//	STK_ACK_INPUT_STATUS							= 0x0824,
	//	STK_ACK_HISTORY										= 0x0825,
	//	STK_ACK_ALARMS										= 0x0826,
	//	STK_AUTH														= 0x0827,
	//	STK_FOUP_EVENT										= 0x0829,
	void Handle_STK_AckFoup(amhs_participant_ptr, AMHSPacket&);
	void Handle_STK_AckStatus(amhs_participant_ptr, AMHSPacket&);
	void Handle_STK_AckRoom(amhs_participant_ptr, AMHSPacket&);
	void Handle_STK_AckStorage(amhs_participant_ptr, AMHSPacket&);
	void Handle_STK_AckInputStatus(amhs_participant_ptr, AMHSPacket&);
	void Handle_STK_AckHistory(amhs_participant_ptr, AMHSPacket&);
	void Handle_STK_AckAlarms(amhs_participant_ptr, AMHSPacket&);
	void Handle_STK_Auth(amhs_participant_ptr, AMHSPacket&);
	void Handle_STK_FoupEvent(amhs_participant_ptr, AMHSPacket&);

private:
	std::set<amhs_participant_ptr> participants_;
	enum { max_recent_msgs = 100 };
	amhs_message_queue recent_msgs_;
	amhs_oht_map oht_map_;

	typedef void (amhs_room::*HANDLE_OPT)(amhs_participant_ptr, AMHSPacket& packet);
	typedef std::map<int, HANDLE_OPT> OPT_MAP;
	OPT_MAP m_optHanders;
};

//----------------------------------------------------------------------
typedef std::map<int, AMHSPacket*> Packet_Map;
class amhs_session
	: public amhs_participant,
	public boost::enable_shared_from_this<amhs_session>
{
public:
	amhs_session(boost::asio::io_service& io_service, amhs_room& room);

	tcp::socket& socket();
	void PutSocketInfo(tcp::socket& socket_);
	void start();
	void deliver(const amhs_message& msg);
	void handle_read_header(const boost::system::error_code& error);
	void handle_read_body(const boost::system::error_code& error);
	void handle_write(const boost::system::error_code& error);

private:
	tcp::socket socket_;
	amhs_room& room_;
	amhs_message read_msg_;
	amhs_message_queue write_msgs_;
	Packet_Map read_packets_;
};

typedef boost::shared_ptr<amhs_session> amhs_session_ptr;

//----------------------------------------------------------------------

class amhs_dev_server
{
public:
	amhs_dev_server(boost::asio::io_service& io_service,
		const tcp::endpoint& endpoint);

	void start_accept();
	void handle_accept(amhs_session_ptr session,
		const boost::system::error_code& error);
	int GetConnectCount();
	amhs_oht_set GetOhtDataSet();
	void setOhtMessageBackTime(int nID, int ms);

private:
	boost::asio::io_service& io_service_;
	tcp::acceptor acceptor_;
	amhs_room room_;
};

typedef boost::shared_ptr<amhs_dev_server> amhs_server_ptr;
typedef std::list<amhs_server_ptr> amhs_server_list;