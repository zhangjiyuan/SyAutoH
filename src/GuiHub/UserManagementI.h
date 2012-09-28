#pragma once
#include "iGuiHub.h"
using namespace MCS;

class DBUserAce;
class DBSession;
class UserManagementI : public UserManagement
{
public:
	UserManagementI(void);
	virtual ~UserManagementI(void);
private:
	DBUserAce*	m_pUserDB;
	DBSession*	m_pSession;
public:
	int Init();
	virtual int Login(const ::std::string&, const ::std::string&, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int Logout(::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int CreateUser(const ::std::string&, const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int DeleteUser(::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int SetUserPW(::Ice::Int, const ::std::string&, ::Ice::Int, const ::Ice::Current&);
	virtual int SetUserRight(::Ice::Int, ::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int GetUserCount(::Ice::Int, const ::Ice::Current&);
	virtual ::MCS::UserList GetUserList(::Ice::Int, ::Ice::Int, ::Ice::Int, const ::Ice::Current&);
};

