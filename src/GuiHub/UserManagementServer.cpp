#include "StdAfx.h"
#include "UserManagementServer.h"
#include "UserManagementI.h"

UserManagementServer::UserManagementServer(void)
{
	Proxy("UserAce");
}


UserManagementServer::~UserManagementServer(void)
{
	EndIce();
}

void UserManagementServer::GetProxy()
{
	UserManagementI* pManager = new UserManagementI();
	m_objPtr = pManager;
}