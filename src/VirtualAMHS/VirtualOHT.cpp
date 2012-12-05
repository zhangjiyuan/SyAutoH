#include "StdAfx.h"
#include "VirtualOHT.h"
#include <MMSystem.h>

#pragma comment(lib, "winmm.lib")

VirtualOHT::VirtualOHT(void)
	: m_nPos(0),
	m_nHand(0),
	m_nPosUpdateTimeSet(0),
	m_nStatusUpdateTimeSet(0),
	m_nTimerID(0),
	m_nTimeCounter(0)
{
	m_optHanders.insert(std::make_pair(OHT_MCS_ACK_AUTH, 
		&VirtualOHT::Handle_Auth));
	m_optHanders.insert(std::make_pair(OHT_MCS_POSITION_BACK_TIME, 
		&VirtualOHT::Handle_SetPosTime));
	m_optHanders.insert(std::make_pair(OHT_MCS_STATUS_BACK_TIME, 
		&VirtualOHT::Handle_SetStatusTime));
	m_optHanders.insert(std::make_pair(OHT_MCS_FOUPHANDING, 
		&VirtualOHT::Handle_FoupHanding));
	CreateTimer();
}

VirtualOHT::~VirtualOHT(void)
{
	DestoryTimer();
}

int VirtualOHT::SetTeachPosition(uint32 nPos, uint8 nType, uint8 nSpeedRate)
{
	AMHSPacket teachPos(OHT_TEACH_PATH, 7);
	teachPos << uint8(DeviceID());
	teachPos << uint32(nPos);
	teachPos << uint8(nType);
	teachPos << uint8(nSpeedRate);

	SendPacket(teachPos);

	return 0;
}

int VirtualOHT::Auth( uint32 nPos, int nHand)
{
	AMHSPacket authPacket(OHT_AUTH, 4);
	authPacket<< uint8(DeviceID());		// device id
	authPacket<< uint32(nPos);		// oht location
	authPacket<< uint8(nHand);				// oht hand status;

	SendPacket(authPacket);

	return 0;
}

int VirtualOHT::UpdateStatus()
{
	AMHSPacket authPacket(OHT_STATUS, 4);
	authPacket<< uint8(DeviceID());		// device id
	authPacket<< uint8(1);
	authPacket<< uint8(1);		
	authPacket<< uint8(0);		
	SendPacket(authPacket);
	return 0;
}

int VirtualOHT::UpdatePos()
{
	AMHSPacket authPacket(OHT_POSITION, 3);
	authPacket<< uint8(DeviceID());		// device id
	authPacket<< uint32(m_nPos);		// oht location
	SendPacket(authPacket);

	return 0;
}

void VirtualOHT::HandleCommand(AMHSPacket& packet)
{
	OPT_MAP::iterator it = m_optHanders.find(packet.GetOpcode());
	if (it != m_optHanders.end())
	{
		(this->*it->second)(packet);
	}
}

void VirtualOHT::Handle_SetStatusTime(AMHSPacket& packet)
{
	uint8 nID = 0;
	uint8 nTime = 0;
	packet >> nID;
	packet >> nTime;
	m_nStatusUpdateTimeSet = nTime * 16;

	AMHSPacket authPacket(OHT_ACK_STATUS_BACK_TIME, 2);
	authPacket<< uint8(DeviceID());		// device id
	authPacket<< uint8(nTime);	
	SendPacket(authPacket);
}

void VirtualOHT::Handle_FoupHanding(AMHSPacket& packet)
{
	uint8 nID = 0;
	uint8 nBuff = 0;
	uint8 nOpt = 0;
	packet >> nID;
	packet >> nBuff;
	packet >> nOpt;
	if (1 == nOpt)
	{
		m_nHand = 0;
	}
	else
	{
		m_nHand = 1;
	}

	AMHSPacket authPacket(OHT_ACK_FOUP, 2);
	authPacket<< uint8(DeviceID());		// device id
	authPacket<< uint8(0);
	SendPacket(authPacket);
}

void VirtualOHT::Handle_SetPosTime(AMHSPacket&  packet)
{
	uint8 nID = 0;
	uint8 nPosTime = 0;
	packet >> nID;
	packet >> nPosTime;
	m_nPosUpdateTimeSet = nPosTime * 16;

	AMHSPacket authPacket(OHT_ACK_POSITION_BACK_TIME, 2);
	authPacket<< uint8(DeviceID());		// device id
	authPacket<< uint8(nPosTime);	
	SendPacket(authPacket);
}

void VirtualOHT::Handle_Auth(AMHSPacket& packet)
{
	uint8 nID = 0;
	uint8 nAuthRes = 0;
	packet >> nID;
	packet >> nAuthRes;
	m_isOnline = nAuthRes > 0 ? true : false;
	
	printf("OHT %d Auth %d\n", nID, nAuthRes);
}

void VirtualOHT::CreateTimer(void)
{
	// Create a periodic timer
	timeBeginPeriod(1);
	m_nTimerID = timeSetEvent(
		1,
		1,
		&VirtualOHT::TimerHandler,
		(DWORD)this,
		TIME_PERIODIC);
	printf("ID: %u TimerID: %d\n", DeviceID(), m_nTimerID);
}


void VirtualOHT::DestoryTimer(void)
{
	if (m_nTimerID > 0)
	{
		timeKillEvent(m_nTimerID);
		timeEndPeriod(1);
		m_nTimerID = 0;
	}
}

void CALLBACK VirtualOHT::TimerHandler(UINT id, UINT msg, DWORD dwUser, DWORD dw1, DWORD dw2)
{
	VirtualOHT *pOht = (VirtualOHT*)dwUser;
	
	pOht->OnTimer();
}

void VirtualOHT::OnTimer(void)
{
	// 
	m_nPos += 1;
	if (m_nPos > 12400)
	{
		m_nPos = 0;
	}
	
	// 
	m_nTimeCounter++;
	if ((m_nPosUpdateTimeSet > 0) 
		&& (m_nTimeCounter % m_nPosUpdateTimeSet == 0))
	{
		UpdatePos();
	}
	if ((m_nStatusUpdateTimeSet > 0 )
		&& (m_nTimeCounter % m_nStatusUpdateTimeSet == 0))
	{
		UpdateStatus();
	}
}
