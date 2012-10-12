#pragma once
#include "VirtualAMHSDevice.h"
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

