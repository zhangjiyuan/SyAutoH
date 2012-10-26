#include "StdAfx.h"
#include "VirtualOHT.h"
#include <MMSystem.h>

#pragma comment(lib, "winmm.lib")

VirtualOHT::VirtualOHT(void)
	: m_nPos(0),
	m_nHand(0),
	m_nPosUpdateTime(0),
	m_nStatusUpdateTime(0),
	m_nPosTimerID(0)
{
	m_optHanders[OHT_MCS_ACK_AUTH] = (CommandHander)&VirtualOHT::Handle_Auth;
}


VirtualOHT::~VirtualOHT(void)
{
	DestoryPosTimer();
}

int VirtualOHT::Auth( int nPos, int nHand)
{
	AMHSPacket authPacket(OHT_AUTH, 4);
	authPacket<< uint8(DeviceID());		// device id
	authPacket<< uint16(nPos);		// oht location
	authPacket<< uint8(nHand);				// oht hand status;

	SendPacket(authPacket);

	return 0;
}

int VirtualOHT::UpdatePos(uint16 nPos)
{
	AMHSPacket authPacket(OHT_POSITION, 3);
	authPacket<< uint8(DeviceID());		// device id
	authPacket<< uint16(nPos);		// oht location
	SendPacket(authPacket);

	return 0;
}

void VirtualOHT::HandleCommand(AMHSPacket& packet)
{
	printf("VirtualOHT::HandleCommand: %d \n", packet.GetOpcode());
	
	OPT_MAP::iterator it = m_optHanders.find(packet.GetOpcode());
	if (it != m_optHanders.end())
	{
		(this->*it->second)(packet);
	}
}

void VirtualOHT::Handle_SetPosTime(AMHSPacket&  packet)
{
	uint8 nID = 0;
	uint8 nPosTime = 0;
	packet >> nID;
	packet >> nPosTime;
	m_nPosUpdateTime = nPosTime;
	if(m_nPosTimerID > 0)
	{
		if (m_nPosUpdateTime > 0)
		{
			CreatePosTimer();
		}
		else
		{
			DestoryPosTimer();
		}	
	}

	AMHSPacket authPacket(OHT_MCS_POSITION_BACK_TIME, 2);
	authPacket<< uint8(DeviceID());		// device id
	authPacket<< uint8(m_nPosUpdateTime);		// oht location
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

	m_nPosUpdateTime = 200;
	if (m_nPosTimerID == 0)
	{
		CreatePosTimer();
	}
}

void VirtualOHT::CreatePosTimer(void)
{
	// Create a periodic timer
	timeBeginPeriod(1);
	m_nPosTimerID = timeSetEvent(
		m_nPosUpdateTime,
		1,
		&VirtualOHT::PosTimerHandler,
		(DWORD)this,
		TIME_PERIODIC);
}


void VirtualOHT::DestoryPosTimer(void)
{
	timeKillEvent(m_nPosTimerID);
	timeEndPeriod(1);
	m_nPosTimerID = 0;
}

void CALLBACK VirtualOHT::PosTimerHandler(UINT id, UINT msg, DWORD dwUser, DWORD dw1, DWORD dw2)
{
	VirtualOHT *pOht = (VirtualOHT*)dwUser;
	pOht->OnPosTimer();
}

void VirtualOHT::OnPosTimer(void)
{
	m_nPos += 10;
	if (m_nPos > 2100)
	{
		m_nPos = 0;
	}
	UpdatePos(m_nPos);
}
