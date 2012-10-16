#pragma once
#include "VirtualAMHSDevice.h"
class VirtualOHT : public VirtualAMHSDevice
{
public:
	VirtualOHT(void);
	virtual ~VirtualOHT(void);
	
public:
	int Auth( int nPos, int nHand);
	virtual void HandleCommand(AMHSPacket& packet);
public:
	bool isOnline;

private:
	void Handle_Auth(AMHSPacket& packet);
	
private:
	typedef void (VirtualOHT::*CommandHander)(AMHSPacket& packet);
	typedef std::map<int, CommandHander> OPT_MAP;
	CommandHander pCmd;
	OPT_MAP m_optHanders;
};

