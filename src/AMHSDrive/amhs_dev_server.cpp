#include "StdAfx.h"
#include "amhs_dev_server.h"

amhs_room::amhs_room()
{
	m_optHanders.insert(std::make_pair(OHT_ACK_STATUS_BACK_TIME, 
		&amhs_room::Handle_OHT_AckStatusBackTime));
	m_optHanders.insert(std::make_pair(OHT_ACK_POSITION_BACK_TIME, 
		&amhs_room::Handle_OHT_AckPosBackTime));
	m_optHanders.insert(std::make_pair(OHT_ACK_PATH, 
		&amhs_room::Handle_OHT_AckPath));
	m_optHanders.insert(std::make_pair(OHT_ACK_MOVE, 
		&amhs_room::Handle_OHT_AckMove));
	m_optHanders.insert(std::make_pair(OHT_ACK_FOUP, 
		&amhs_room::Handle_OHT_AckFoup));
	m_optHanders.insert(std::make_pair(OHT_AUTH, 
		&amhs_room::Handle_OHT_Auth));
	m_optHanders.insert(std::make_pair(OHT_POSITION, 
		&amhs_room::Handle_OHT_Pos));
	m_optHanders.insert(std::make_pair(OHT_STATUS, 
		&amhs_room::Handle_OHT_Status));

	//////////////////////////////////////////////////////////////////////////
	m_optHanders.insert(std::make_pair(STK_ACK_FOUP, 
		&amhs_room::Handle_STK_AckFoup));
	m_optHanders.insert(std::make_pair(STK_ACK_STATUS, 
		&amhs_room::Handle_STK_AckStatus));
	m_optHanders.insert(std::make_pair(STK_ACK_ROOM, 
		&amhs_room::Handle_STK_AckRoom));
	m_optHanders.insert(std::make_pair(STK_ACK_STORAGE, 
		&amhs_room::Handle_STK_AckStorage));
	m_optHanders.insert(std::make_pair(STK_ACK_INPUT_STATUS, 
		&amhs_room::Handle_STK_AckInputStatus));
	m_optHanders.insert(std::make_pair(STK_ACK_HISTORY, 
		&amhs_room::Handle_STK_AckHistory));
	m_optHanders.insert(std::make_pair(STK_ACK_ALARMS, 
		&amhs_room::Handle_STK_AckAlarms));
	m_optHanders.insert(std::make_pair(STK_AUTH, 
		&amhs_room::Handle_STK_Auth));
	m_optHanders.insert(std::make_pair(STK_FOUP_EVENT, 
		&amhs_room::Handle_STK_FoupEvent));
}

void amhs_room::join(amhs_participant_ptr participant)
{
	participants_.insert(participant);
}

void amhs_room::leave(amhs_participant_ptr participant)
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

amhs_oht_set amhs_room::GetOhtDataSet()
{
	amhs_oht_set oht_set;
	for (amhs_oht_map::iterator it = oht_map_.begin();
		it != oht_map_.end(); ++it)
	{
		oht_set.insert(it->second);
	}
	return oht_set;
}

void amhs_room::SendPacket(amhs_participant_ptr participants, AMHSPacket &packet)
{
	size_t szLen = packet.size();
	size_t szLimit = amhs_message::max_body_length;
	int nLoop = szLen / szLimit + 1;

	size_t szPacketLen = 0;
	for (int i=0; i<nLoop; i++)
	{
		amhs_message msg;
		msg.Index(i+1);
		if ((i+1) < nLoop)
		{
			msg.IsLast(0);
		}
		else
		{
			msg.IsLast(1);
		}
		if (szLen > szLimit)
		{
			szPacketLen = szLimit;
			szLen -= szLimit;
		}
		else
		{
			szPacketLen = szLen;
		}
		msg.command(packet.GetOpcode());
		msg.body_length(szPacketLen);
		msg.IsNeedRespond(true);
		memcpy(msg.body(), packet.contents() + (i*szLimit), msg.body_length());
		msg.encode_header();
		
		if (254 == participants->nID_)
		{
			deliver_all(msg);
		}
		else
		{
			participants->deliver(msg);
		}
	}
}

void amhs_room::Handle_STK_AckFoup(amhs_participant_ptr, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}
void amhs_room::Handle_STK_AckStatus(amhs_participant_ptr, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}
void amhs_room::Handle_STK_AckRoom(amhs_participant_ptr, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}
void amhs_room::Handle_STK_AckStorage(amhs_participant_ptr, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}
void amhs_room::Handle_STK_AckInputStatus(amhs_participant_ptr, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}
void amhs_room::Handle_STK_AckHistory(amhs_participant_ptr, AMHSPacket& Packet)
{
	size_t szLen = Packet.size();
	Log.Warning("amhs_room", "Packet handle not implemented\n");
	Log.Debug("amhs_romm", "Stocker history packet len %d\n", szLen);
}
void amhs_room::Handle_STK_AckAlarms(amhs_participant_ptr, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}

void amhs_room::Handle_STK_FoupEvent(amhs_participant_ptr, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}


void amhs_room::Handle_OHT_AckStatusBackTime(amhs_participant_ptr participants, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}
void amhs_room::Handle_OHT_AckPosBackTime(amhs_participant_ptr participants, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}
void amhs_room::Handle_OHT_AckPath(amhs_participant_ptr participants, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}
void amhs_room::Handle_OHT_AckMove(amhs_participant_ptr participants, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}
void amhs_room::Handle_OHT_AckFoup(amhs_participant_ptr participants, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}
void amhs_room::Handle_OHT_Status(amhs_participant_ptr participants, AMHSPacket& Packet)
{
	Log.Warning("amhs_room", "Packet handle not implemented\n");
}

void amhs_room::Handle_OHT_Auth(amhs_participant_ptr participants, AMHSPacket& Packet)
{
	uint8		ohtID = 0;
	uint16		ohtPosition = 0;
	uint8		ohtHand = 0;
	Packet >> ohtID;
	Packet >> ohtPosition;
	Packet >> ohtHand;
	printf("OHT Auth  ---> id: %d, pos: %d, hand: %d\n", ohtID, ohtPosition, ohtHand);
	participants->nID_ = ohtID;
	participants->nDevType_ = DEV_TYPE_OHT;

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
}
void amhs_room::Handle_STK_Auth(amhs_participant_ptr participants, AMHSPacket& Packet)
{
	uint8 stockerID = 0;
	uint32 uIP = 0;
	Packet >> stockerID;
	Packet >> uIP;
	struct in_addr addr1;

	memcpy(&addr1, &uIP, 4);
	char* sIP = inet_ntoa(addr1);
	printf("STOCKER Auth ---> id: %d, ip: %s\n", stockerID, sIP);
	participants->nDevType_ = DEV_TYPE_STOCKER;
	participants->nID_ = stockerID;

	AMHSPacket ack(STK_MCS_ACK_AUTH, 10);
	ack << uint8(stockerID);
	ack << uint8(1);
	__time64_t ltime;
	_time64( &ltime );
	ack << uint64(ltime);

	SendPacket(participants, ack);
}

void amhs_room::Handle_OHT_Pos(amhs_participant_ptr participants, AMHSPacket& Packet)
{
	uint8		ohtID = 0;
	uint16		ohtPosition = 0;
	Packet >> ohtID;
	Packet >> ohtPosition;
	//printf("OHT POS  ---> id: %d, pos: %d\n", ohtID, ohtPosition);
	amhs_oht_map::iterator it = oht_map_.find(ohtID);
	if (it != oht_map_.end())
	{
		it->second->nPOS = ohtPosition;
	}
}

int amhs_room::DecodePacket(amhs_participant_ptr participants, AMHSPacket& Packet)
{
	int mOpcode = Packet.GetOpcode();
	OPT_MAP::iterator it = m_optHanders.find(mOpcode);
	if (it != m_optHanders.end())
	{
		(this->*it->second)(participants, Packet);
		return 0;
	}
	else
	{
		return -1;
	}
}

void amhs_room::deliver_all(const amhs_message& msg)
{
	//recent_msgs_.push_back(msg);
	//while (recent_msgs_.size() > max_recent_msgs)
	//recent_msgs_.pop_front();

	std::for_each(participants_.begin(), participants_.end(),
		boost::bind(&amhs_participant::deliver, _1, boost::ref(msg)));
}

int amhs_room::GetCount()
{
	return participants_.size();
}

//////////////////////////////////////////////////////////////////////////

amhs_session::amhs_session(boost::asio::io_service& io_service, amhs_room& room)
	: socket_(io_service),
	room_(room)
{
	nDevType_ = DEV_TYPE_UNKNOW;
	nID_ = -1;
}

tcp::socket& amhs_session::socket()
{
	return socket_;
}

void amhs_session::PutSocketInfo(tcp::socket& socket_)
{
	tcp::socket::endpoint_type ep = socket_.remote_endpoint();
	std::string sIP = ep.address().to_string();
	unsigned int uPort = ep.port();
	std::cout<< "socket IP: " << sIP << " Port: " << uPort << std::endl;
}

void amhs_session::start()
{
	room_.join(shared_from_this());
	boost::asio::async_read(socket_,
		boost::asio::buffer(read_msg_.data(), amhs_message::header_length),
		boost::bind(
		&amhs_session::handle_read_header, shared_from_this(),
		boost::asio::placeholders::error));

	PutSocketInfo(socket_);
}

void amhs_session::deliver(const amhs_message& msg)
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

void amhs_session::handle_read_header(const boost::system::error_code& error)
{
	if (!error && read_msg_.decode_header())
	{
		boost::asio::async_read(socket_,
			boost::asio::buffer(read_msg_.body(), read_msg_.body_length()),
			boost::bind(&amhs_session::handle_read_body, shared_from_this(),
			boost::asio::placeholders::error));
	}
	else
	{
		room_.leave(shared_from_this());
	}
}

void amhs_session::handle_read_body(const boost::system::error_code& error)
{
	// TODO: need message index check for packet sequence
	if (!error)
	{
		int mOpcode = read_msg_.command();
		int mSize = read_msg_.body_length();
		
		if (mSize > 0)
		{
			AMHSPacket* Packet;
			Packet_Map::iterator it = read_packets_.find(mOpcode);
			if (it != read_packets_.end())
			{
				Packet = it->second;
			}
			else
			{
				Packet = new AMHSPacket(static_cast<uint16>(mOpcode), mSize);
				Packet->resize(0);
				read_packets_.insert(std::make_pair(mOpcode, Packet));
			}
			
			if (read_msg_.IsLast() == 1)
			{
				Packet_Map::iterator it = read_packets_.find(mOpcode);
				if (it != read_packets_.end())
				{
					read_packets_.erase(it);
				}
				
				Packet->append(read_msg_.body(), mSize);

				int nDecode = room_.DecodePacket(shared_from_this(), *Packet);	
				if (nDecode < 0)
				{
					printf("Wrong packet. \n");
				}
				
				delete Packet;
			}
			else
			{
				Packet->append(read_msg_.body(), mSize);
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

void amhs_session::handle_write(const boost::system::error_code& error)
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

//////////////////////////////////////////////////////////////////////////

amhs_dev_server::amhs_dev_server(boost::asio::io_service& io_service,
	const tcp::endpoint& endpoint)
	: io_service_(io_service),
	acceptor_(io_service, endpoint)
{
	start_accept();
}

void amhs_dev_server::start_accept()
{
	amhs_session_ptr new_session(new amhs_session(io_service_, room_));
	acceptor_.async_accept(new_session->socket(),
		boost::bind(&amhs_dev_server::handle_accept, this, new_session,
		boost::asio::placeholders::error));
}

void amhs_dev_server::handle_accept(amhs_session_ptr session,
	const boost::system::error_code& error)
{
	if (!error)
	{
		session->start();
	}

	start_accept();
}

int amhs_dev_server::GetConnectCount()
{
	return room_.GetCount();
}

amhs_oht_set amhs_dev_server::GetOhtDataSet()
{
	return room_.GetOhtDataSet();
}

void amhs_dev_server::setOhtMessageBackTime(int nID, int ms)
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

