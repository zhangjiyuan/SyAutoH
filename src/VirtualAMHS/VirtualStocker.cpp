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
	authPacket<< uint8(ID());		// stokcer id
	uint32 uIP = 0;
	uIP = inet_addr(sIP);
	authPacket << uIP;

	SendPacket(authPacket);

	return 0;
}