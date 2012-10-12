#pragma once
#include "VirtualAMHSDevice.h"

class VirtualFoup
{
public:
	TCHAR FoupID[256];
	int nStatus;

	VirtualFoup()
		: nStatus(0)
	{
		memset(FoupID, 0, 256);
	}
};

class VirtualStocker : public VirtualAMHSDevice
{
public:
	VirtualStocker(void);
	virtual ~VirtualStocker(void);

public:
	int Auth( const char* sIP);
	int ManualInputFoup( const TCHAR* sFoupID);
	int ManualOutputFoup( const TCHAR* sFoupID);
};

