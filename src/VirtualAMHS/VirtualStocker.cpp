#include "StdAfx.h"
#include "VirtualStocker.h"


VirtualStocker::VirtualStocker(void)
{
	m_optHanders[STK_MCS_ACK_AUTH] = &VirtualStocker::Handle_Auth;
}


VirtualStocker::~VirtualStocker(void)
{
}

void VirtualStocker::HandleCommand(AMHSPacket& packet)
{
	OPT_MAP::iterator it = m_optHanders.find(packet.GetOpcode());
	if (it != m_optHanders.end())
	{
		(this->*it->second)(packet);
	}
}

int VirtualStocker::Auth( const char* sIP)
{
	AMHSPacket authPacket(STK_AUTH, 4);
	authPacket<< uint8(DeviceID());		// stokcer id
	uint32 uIP = 0;
	uIP = inet_addr(sIP);
	authPacket << uIP;

	SendPacket(authPacket);

	return 0;
}

int VirtualStocker::ManualInputFoup(const TCHAR* sFoupID)
{
	int nFoupID = _wtoi(sFoupID);
	MAP_VFOUP::iterator it;
	it = m_mapFoups.find(nFoupID);
	if (it == m_mapFoups.end())
	{
		VirtualFoup foup;
		foup.nID = nFoupID;
		foup.nStatus = 0;
		m_mapFoups.insert(std::make_pair(nFoupID, foup));

		AMHSPacket Packet(STK_FOUP_EVENT, 8);
		Packet << uint8(DeviceID());
		Packet << uint8(0); // input
		Packet << uint8(0); // slot ID
		Packet << uint16(0); // lot ID
		Packet << uint16(nFoupID); // foup ID
		Packet << uint8(5); // manual input 1

		SendPacket(Packet);
	}

	

	return 0;
}

int VirtualStocker::History()
{
	printf("Test big Packet \n");
	AMHSPacket Packet(STK_ACK_HISTORY, 2500);

	for (int i=0; i<2500; i++)
	{
		Packet << uint8(i);
	}

	SendPacket(Packet);
	return 0;
}

int VirtualStocker::ManualOutputFoup(const TCHAR* sFoupID)
{
	int nFoupID = _wtoi(sFoupID);
	AMHSPacket Packet(STK_FOUP_EVENT, 8);
	Packet << uint8(DeviceID());
	Packet << uint8(1); // output
	Packet << uint8(0);
	Packet << uint16(23); // lot
	Packet << uint16(nFoupID); // foup
	Packet << uint8(5); // manual input 1

	SendPacket(Packet);

	return 0;
}

void VirtualStocker::Handle_Auth(AMHSPacket& packet)
{
	uint8 nID = 0;
	uint8 nAuthRes = 0;
	uint64 uTime = 0;
	packet >> nID;
	packet >> nAuthRes;
	packet >> uTime;

	m_isOnline = nAuthRes > 0 ? true : false;
	__time64_t tTime;
	memcpy(&tTime, &uTime, 8);
	char timebuf[256] = "";
	_ctime64_s(timebuf, 256, &tTime);
	printf("Stocker %d Auth %d SysTime: %s\n", nID, nAuthRes, timebuf);
}