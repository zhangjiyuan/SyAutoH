#pragma once
#include "VirtualAMHSDevice.h"
class VirtualOHT : public VirtualAMHSDevice
{
public:
	VirtualOHT(void);
	virtual ~VirtualOHT(void);
	
	int Auth(int nID, int nPos, int nHand);
};

