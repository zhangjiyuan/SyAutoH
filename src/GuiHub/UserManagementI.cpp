#include "StdAfx.h"
#include "UserManagementI.h"
#include "../SqlAceCli/SqlAceCli.h"


UserManagementI::UserManagementI(void)
{
	cout<<"User Management Server is Ready." << endl;
	m_pUserDB = NULL;
}


UserManagementI::~UserManagementI(void)
{
}

int UserManagementI::Init()
{
	if (NULL == m_pUserDB)
	{
		m_pUserDB = new DBUserAce();
	}
	return 0;
}

int UserManagementI::Login(const ::std::string& sUser, const ::std::string& sHash, const ::Ice::Current& /* = ::Ice::Current */)
{
	cout<< "Login Info:  -> User: " << sUser << " Hash: " << sHash << endl;
	return 1;
}
int UserManagementI::Logout(::Ice::Int nSession, const ::Ice::Current& /* = ::Ice::Current */)
{
	return 0;
}

int UserManagementI::CreateUser(const ::std::string& sName, 
	const ::std::string& sPassWord, ::Ice::Int nRight, const ::Ice::Current& /* = ::Ice::Current */)
{
	int nRet = 0;
	nRet = m_pUserDB->CreateUser(sName, sPassWord, nRight);
	return nRet;
}
int UserManagementI::DeleteUser(::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */)
{
	return 0;
}
int UserManagementI::SetUserPW(::Ice::Int, const ::std::string&, ::Ice::Int, const ::Ice::Current&)
{
	return 0;
}
int UserManagementI::SetUserRight(::Ice::Int, ::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */)
{
	return 0;
}
int UserManagementI::GetUserCount(const ::Ice::Current&)
{
	return 0;
}
UserList UserManagementI::GetUserList(::Ice::Int, ::Ice::Int, const ::Ice::Current&)
{
	return UserList();
}