#pragma once
#include "iGuiHub.h"
using namespace MCS;
class UserManagementI : public UserManagement
{
public:
	UserManagementI(void);
	virtual ~UserManagementI(void);
public:
	virtual int Login(const ::std::string&, const ::std::string&, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int Logout(::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int CreateUser(const ::std::string&, const ::std::string&, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int DeleteUser(::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int SetUserPW(::Ice::Int, const ::std::string&, ::Ice::Int, const ::Ice::Current&);
	virtual int SetUserRight(::Ice::Int, ::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int GetUserCount(const ::Ice::Current&);
	virtual ::MCS::UserList GetUserList(::Ice::Int, ::Ice::Int, const ::Ice::Current&);
};

//idempotent int CreateUser(string user, string pass, int session);
//idempotent int SetUserPW(int nUID, string pass, int session);
//idempotent int SetUserRight(int nUID, int nRight, int session);
//idempotent int DeleteUser(int nUID, int session);
//idempotent int GetUserCount();
//idempotent UserList GetUserList(int nBegin, int nCount);

