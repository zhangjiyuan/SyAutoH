#include "StdAfx.h"
#include "VirtualStocker.h"


VirtualStocker::VirtualStocker(void)
{
}


VirtualStocker::~VirtualStocker(void)
{
}

int VirtualStocker::Auth( const char* sIP)
{
	AMHSPacket authPacket(STK_AUTH, 4);
	authPacket<< uint8(getID());		// stokcer id
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
	Packet << uint8(getID());
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
	Packet << uint8(getID());
	Packet << uint8(1); // output
	Packet << uint8(0);
	Packet << uint16(23); // lot
	Packet << uint16(nFoupID); // foup
	Packet << uint8(5); // manual input 1

	SendPacket(Packet);

	return 0;
}