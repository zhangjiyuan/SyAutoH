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
#include "iconstDef.ice"


module MCS
{

struct GuiDataItem
{
	GuiHub::PushData enumTag;
	string sVal;
};

interface GuiDataUpdater
{
		["ami", "amd"] idempotent void UpdateData(GuiDataItem data);
};

interface GuiDataHub
{
    idempotent string ReadData(GuiHub::GuiCommand Tag, int session);
    idempotent int WriteData(GuiHub::GuiCommand Tag, string Val, int session);
    idempotent void SetDataUpdater(GuiDataUpdater* updater);
    idempotent void EraseDataUpdater(GuiDataUpdater* updater);
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
