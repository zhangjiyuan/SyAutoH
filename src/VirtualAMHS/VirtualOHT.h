#pragma once
#include "VirtualAMHSDevice.h"
class VirtualOHT : public VirtualAMHSDevice
{
public:
	VirtualOHT(void);
	virtual ~VirtualOHT(void);
	
public:
	int Auth( int nPos, int nHand);
};

