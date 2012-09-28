// **********************************************************************
//
// Copyright (c) 2003-2009 ZeroC, Inc. All rights reserved.
//
// This copy of Ice is licensed to you under the terms described in the
// ICE_LICENSE file included in this distribution.
//
// **********************************************************************

#ifndef MESLink_ICE
#define MESLink_ICE


module MCS
{

interface GuiDataHub
{
    idempotent string ReadData(string Tag, int session);
    idempotent int WriteData(string Tag, string Val, int session);
};

struct User
{
	int nID;
	string sName;
	int nRight;
};

sequence<User> UserList;
interface UserManagement
{
  idempotent int Login(string user, string pass);
  idempotent int Logout(int session);
	idempotent int CreateUser(string user, string pass, int nRight, int session);
	idempotent int SetUserPW(int nUID, string pass, int session);
	idempotent int SetUserRight(int nUID, int nRight, int session);
	idempotent int DeleteUser(int nUID, int session);
	idempotent int GetUserCount(int session);
	idempotent UserList GetUserList(int nBegin, int nCount, int session);
};

};

#endif
