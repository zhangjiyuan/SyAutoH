#pragma once

#include "IceBase.h"


class MesLinkServer : public CIceServerBase
{
public:
	MesLinkServer(void);
	virtual ~MesLinkServer(void);

public:
	virtual void GetProxy();
};

