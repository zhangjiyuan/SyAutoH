#include "StdAfx.h"
#include "VirtualOHT.h"


VirtualOHT::VirtualOHT(void)
{
}


VirtualOHT::~VirtualOHT(void)
{
	
}

int VirtualOHT::Auth( int nPos, int nHand)
{
	AMHSPacket authPacket(OHT_AUTH, 4);
	authPacket<< uint8(ID());		// device id
	authPacket<< uint16(nPos);		// oht location
	authPacket<< uint8(nHand);				// oht hand status;

	SendPacket(authPacket);

	return 0;
}
