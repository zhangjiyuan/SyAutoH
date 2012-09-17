#pragma once
#include "IceBase.h"

class UserManagementServer: public CIceServerBase
{
public:
	UserManagementServer(void);
	virtual ~UserManagementServer(void);

public:
	virtual void GetProxy();
};

