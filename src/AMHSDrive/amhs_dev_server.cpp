#include "StdAfx.h"
#include "amhs_dev_server.h"

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

amhs_oht_set amhs_dev_server::OHT_GetDataSet()
{
	return room_.GetOhtDataSet();
}

void amhs_dev_server::OHT_Set_StatusBackTime(int nID, int ms)
{
	AMHSPacket packet(OHT_MCS_STATUS_BACK_TIME, 2);
	packet<< uint8(nID);
	packet<< uint8(ms);

	SendPacket_OHT(nID, packet);
}

void amhs_dev_server::OHT_Set_PosBackTime(int nID, int ms)
{
	AMHSPacket packet(OHT_MCS_POSITION_BACK_TIME, 2);
	packet << uint8(nID);
	packet << uint8(ms);

	SendPacket_OHT(nID, packet);
}

void amhs_dev_server::OHT_Move(int nID, int nControl)
{
	AMHSPacket packet(OHT_MCS_MOVE, 2);
	packet << uint8(nID);
	packet << uint8(nControl);

	SendPacket_OHT(nID, packet);
}

void amhs_dev_server::OHT_SetPath(int nID, int nType, int nStart, int nTarget, amhs_keypoint_vec& KeyPoints)
{
	Log.outBasic("OHT Setpath is not implenement.");
	size_t szKeyCount = KeyPoints.size();
	size_t szPacketLen = 0;
	szPacketLen = 7 + szKeyCount * 4;

	AMHSPacket packet(OHT_MCS_PATH, szPacketLen);
	packet << uint8(nID);
	packet << uint8(nType);
	packet << uint16(nStart);
	packet << uint16(nTarget);
	packet << uint8(szKeyCount);
	for (amhs_keypoint_vec::iterator it = KeyPoints.begin(); 
		it != KeyPoints.end(); ++it)
	{
		packet << uint16(it->nPos);
		packet << uint8(it->nType);
		packet << uint8(it->nSpeedRate);
	}

	SendPacket_OHT(nID, packet);
}

void amhs_dev_server::OHT_Foup(int nID, int nDevBuf, int nOperation)
{
	AMHSPacket packet(OHT_MCS_FOUP, 3);
	packet << uint8(nID);
	packet << uint8(nDevBuf);
	packet << uint8(nOperation);

	SendPacket_OHT(nID, packet);
}