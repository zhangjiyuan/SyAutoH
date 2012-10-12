#include "StdAfx.h"
#include "VirtualOHT.h"


VirtualOHT::VirtualOHT(void)
{
}


VirtualOHT::~VirtualOHT(void)
{
	Clean();
}

int VirtualOHT::Auth(int nID, int nPos, int nHand)
{
	AMHSPacket authPacket(OHT_AUTH, 4);
	authPacket<< uint8(nID);		// oht id
	authPacket<< uint16(nPos);		// oht location
	authPacket<< uint8(nHand);				// oht hand status;

	SendPacket(authPacket);

	return 0;
}
