// **********************************************************************
//
// Copyright (c) 2003-2009 ZeroC, Inc. All rights reserved.
//
// This copy of Ice is licensed to you under the terms described in the
// ICE_LICENSE file included in this distribution.
//
// **********************************************************************

#ifndef LogInterface_ICE
#define LogInterface_ICE


module Gemma
{

struct LogMsg
{
	int nID;
	int nEventID;
	long lTime;
	int nParam1;
	int nParam2;
	double dParam1;
	double dParam2;
	string strUnit;
	string strMsg;
	string strUser;
	short nUnit;
	short nType;
	bool bCleared;
};

struct AlarmMsg
{
	int nID;
	int nEventID;
	long firstTime;
	long lastTime;
	string strMsg;
	int nCount;
};

sequence<LogMsg> LogList;
sequence<AlarmMsg> AlarmList;
sequence<int>  IDList;

interface Log
{
    idempotent void sendLog(LogList data);
    idempotent LogList GetLog(int nID, int nCount, IDList Types, IDList IDS, string skey);
    idempotent int GetLastID();
    
    idempotent int GetCountOffline(long llDateTimeEnd, long llDateTimeBegin, IDList Types, IDList IDS, string skey);
    idempotent LogList GetLogOffline(int nIndex, int nCount, long llDateTimeEnd, long llDateTimeBegin, IDList Types, IDList IDS, string skey);
    
    idempotent int GetAlarmCount();
    idempotent AlarmList GetAlarms(int nIndex, int nCount);
    idempotent void ClearAlarms(IDList IDS);
};

};

#endif
