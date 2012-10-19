#include "StdAfx.h"
#include "VirtualOHT.h"


VirtualOHT::VirtualOHT(void)
	: nPos(0),
	nHand(0)
{
	//m_optHanders.insert(make_pair(OHT_MCS_ACK_AUTH, &VirtualOHT::Handle_Auth));
	m_optHanders[OHT_MCS_ACK_AUTH] = (CommandHander)&VirtualOHT::Handle_Auth;
}


VirtualOHT::~VirtualOHT(void)
{
	
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

void VirtualOHT::HandleCommand(AMHSPacket& packet)
{
	printf("VirtualOHT::HandleCommand: %d \n", packet.GetOpcode());
	
	OPT_MAP::iterator it = m_optHanders.find(packet.GetOpcode());
	if (it != m_optHanders.end())
	{
		(this->*it->second)(packet);
	}
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