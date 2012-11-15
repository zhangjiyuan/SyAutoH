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
	m_optHanders.insert(std::make_pair(OHT_MCS_ACK_AUTH, 
		&VirtualOHT::Handle_Auth));
	m_optHanders.insert(std::make_pair(OHT_MCS_POSITION_BACK_TIME, 
		&VirtualOHT::Handle_SetPosTime));
}


VirtualOHT::~VirtualOHT(void)
{
	DestoryPosTimer();
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

int VirtualOHT::UpdatePos(uint32 nPos)
{
	AMHSPacket authPacket(OHT_POSITION, 3);
	authPacket<< uint8(DeviceID());		// device id
	authPacket<< uint32(nPos);		// oht location
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

void VirtualOHT::Handle_SetPosTime(AMHSPacket&  packet)
{
	uint8 nID = 0;
	uint8 nPosTime = 0;
	packet >> nID;
	packet >> nPosTime;
	m_nPosUpdateTime = nPosTime;

	if ((nPosTime >= 30) 
		&& (nPosTime <= 253))
	{

		if (m_nPosTimerID > 0)
		{
			DestoryPosTimer();
		}
		CreatePosTimer();
	}
	else
	{
		DestoryPosTimer();
		m_nPosUpdateTime = 0;
	}	

	AMHSPacket authPacket(OHT_ACK_POSITION_BACK_TIME, 2);
	authPacket<< uint8(DeviceID());		// device id
	authPacket<< uint8(m_nPosUpdateTime);		// oht location
	SendPacket(authPacket);

	cout<< "OHT POS TIME -> ID: " << nID << " Time: " << nPosTime << " True Time: " << m_nPosUpdateTime << endl;
}

void VirtualOHT::Handle_Auth(AMHSPacket& packet)
{
	uint8 nID = 0;
	uint8 nAuthRes = 0;
	packet >> nID;
	packet >> nAuthRes;
	m_isOnline = nAuthRes > 0 ? true : false;
	
	printf("OHT %d Auth %d\n", nID, nAuthRes);

	m_nPosUpdateTime = 100;
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
		m_nPosUpdateTime *16,
		1,
		&VirtualOHT::PosTimerHandler,
		(DWORD)this,
		TIME_PERIODIC);
}


void VirtualOHT::DestoryPosTimer(void)
{
	if (m_nPosTimerID > 0)
	{
		timeKillEvent(m_nPosTimerID);
		timeEndPeriod(1);
		m_nPosTimerID = 0;
	}
}

void CALLBACK VirtualOHT::PosTimerHandler(UINT id, UINT msg, DWORD dwUser, DWORD dw1, DWORD dw2)
{
	VirtualOHT *pOht = (VirtualOHT*)dwUser;
	pOht->OnPosTimer();
}

void VirtualOHT::OnPosTimer(void)
{
	m_nPos += 50;
	if (m_nPos > 12400)
	{
		m_nPos = 0;
	}
	UpdatePos(m_nPos);
}
