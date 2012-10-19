#pragma once
#include "VirtualAMHSDevice.h"

class VirtualFoup
{
public:
	int nID;
	int nStatus;

	VirtualFoup()
		: nStatus(0),
		nID(0)
	{

	}
};
typedef std::map<int, VirtualFoup> MAP_VFOUP;

class VirtualStocker : public VirtualAMHSDevice
{
public:
	VirtualStocker(void);
	virtual ~VirtualStocker(void);

public:
	virtual void HandleCommand(AMHSPacket& packet);

public:
	int Auth( const char* sIP);
	int ManualInputFoup( const TCHAR* sFoupID);
	int ManualOutputFoup( const TCHAR* sFoupID);

private:
	void Handle_Auth(AMHSPacket& packet);

private:
	typedef void (VirtualStocker::*CommandHander)(AMHSPacket& packet);
	typedef std::map<int, CommandHander> OPT_MAP;
	OPT_MAP m_optHanders;
	MAP_VFOUP m_mapFoups;
};

