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
	printf("VirtualStocker::HandleCommand: %d \n", packet.GetOpcode());

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
	AMHSPacket Packet(STK_FOUP_EVENT, 8);
	Packet << uint8(DeviceID());
	Packet << uint8(0); // input
	Packet << uint8(0);
	Packet << uint16(23); // lot
	Packet << uint16(nFoupID); // foup
	Packet << uint8(5); // manual input 1

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
	__time64_t tTime;
	memcpy(&tTime, &uTime, 8);
	char timebuf[256] = "";
	_ctime64_s(timebuf, 256, &tTime);
	printf("Stocker %d Auth %d SysTime: %s\n", nID, nAuthRes, timebuf);
}