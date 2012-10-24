#pragma once
#include "IceBase.h"

class GuiDataHubServer: public CIceServerBase
{
public:
	GuiDataHubServer(void);
	virtual ~GuiDataHubServer(void);
public:
	virtual void GetProxy();
};

