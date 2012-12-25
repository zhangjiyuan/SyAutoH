#pragma once
#include   <iostream> 
#include   <io.h> 
#include   <direct.h> 
#include   <string> 
#include   <vector> 
#include   <iomanip> 
#include   <ctime>  
#include <map>
#include <queue>

#include "iLog.h"
#include "../../shared/ThreadLock.h"
#include "LogDataDb.h"
#include "AlarmDataTbl.h"

using namespace std;
using namespace Gemma;

const int MaxLogBufCount = 16384;
const __int64 Time_Diff = 235959999;

const int DBMAXCOUNT = 20000; //100000

const char LOG_DB_FILE[] = "GemmaLog";
const char ALARM_DB_FILE[] = "GemmaAlarm";

typedef std::queue<LogMsg> QUEUE_LOG;

class CLogI : public Gemma::Log
{
public:
	CLogI(HWND wnd);
	virtual ~CLogI(void);

public:
	// ice interface functions
	virtual void sendLog(const ::Gemma::LogList&, const ::Ice::Current& );
	virtual int GetLastID(const ::Ice::Current& /* = ::Ice::Current */);
	virtual LogList GetLog(::Ice::Int, ::Ice::Int, const ::Gemma::IDList&, const ::Gemma::IDList&, 
		const ::std::string&, const ::Ice::Current& /* = ::Ice::Current */);
	
	virtual int GetCountOffline(::Ice::Long, ::Ice::Long, const ::Gemma::IDList&, 
		const ::Gemma::IDList&, const ::std::string&, const ::Ice::Current& /* = ::Ice::Current */);
	virtual LogList GetLogOffline(::Ice::Int, ::Ice::Int, ::Ice::Long, ::Ice::Long, const ::Gemma::IDList&, 
		const ::Gemma::IDList&, const ::std::string&, const ::Ice::Current& /* = ::Ice::Current */);

	virtual int GetAlarmCount(const ::Ice::Current& /* = ::Ice::Current */);
	virtual AlarmList GetAlarms(::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual void ClearAlarms(const ::Gemma::IDList&, const ::Ice::Current& /* = ::Ice::Current */);

private:
	void InitDbStore(void);

protected:
	HANDLE m_eventStore;

private:
	CGemmaDB m_logDB;
	CLogDataTbl m_logTable;

	CGemmaDB m_alarmDB;
	CAlarmDataTbl m_alarmTable;

	std::string m_strLogFileName;
	std::string m_strAlarmFileName;

	rwmutex				m_muLogBuf;
	rwmutex				m_muLogDB;
	rwmutex				m_muAlarmDB;
	rwmutex				m_muMap;

	QUEUE_LOG		m_qLogBuf;

	const HWND _wnd;
	HANDLE m_hThreadDbStore;
	static unsigned __stdcall  __DataDaseStore(LPVOID lp);

	int m_nBoundID;

	int	WritetoDb(void);
	void	BackUpDB(void);
	void	DelOldFiles(void);
	void	getOldFiles( string path, vector<string>& files, time_t today, int nDayOld );

	//vector<string>& files
	map<long long, string> queryMap;
	typedef pair <long long, string> IntStr_Pair;
	string m_strCurHistoryDBFile;
	__int64 m_DateKey;

	void InitBoundID(void);
	int GetLastIDinCurrent(void);
	int GetLastIDinHistory(void);
	int GetLogFromCurrent(::Ice::Int nStart, ::Ice::Int nCount, const IDList& types, 
		const IDList& ids, LogList & list, const ::std::string& sKey);
	int GetLogFromAllHistory(::Ice::Int nStart, ::Ice::Int nCount, const IDList& types, 
		const IDList& ids, LogList & list, const ::std::string& sKey);
	int GetLogFromTimeHistory(::Ice::Int nStart, ::Ice::Int nCount, const IDList& types, 
		const IDList& ids, LogList & list, const ::std::string& sKey);
	int GetLogFromSingleDB(string strDBFile,::Ice::Int nStart, ::Ice::Int nCount, const IDList& types, 
		const IDList& ids, LogList & list, const ::std::string& sKey);

	int GetOfflineCountInCurrent(::Ice::Long llTimeEnd, ::Ice::Long llTimeBegin, const IDList& types, 
		const IDList& ids, const ::std::string& sKey);
	int GetOfflineCountInDateStore(::Ice::Long llTimeEnd, ::Ice::Long llTimeBegin, const IDList& types, 
		const IDList& ids, const ::std::string& sKey);
	int GetOfflineCountInFile(const string& strDB, ::Ice::Long llTimeEnd, ::Ice::Long llTimeBegin, const IDList& types, 
		const IDList& ids, const ::std::string& sKey);
	
	int GetOfflineLogInCurrent(int nSkip, int nCount, ::Ice::Long llTimeEnd, ::Ice::Long llTimeBegin, const IDList& types, 
		const ::Gemma::IDList&, LogList & list, const ::std::string& sKey);
	int GetOfflineLogInDataStore(int & nSkip, int & nCount, ::Ice::Long llTimeEnd, ::Ice::Long llTimeBegin, const IDList& types, 
		const ::Gemma::IDList&, LogList & list, const ::std::string& sKey);
	int GetOfflineLogInFile(const string& strDB, int nSkip, int nCount, ::Ice::Long llTimeEnd, ::Ice::Long llTimeBegin, 
		const IDList& types, const ::Gemma::IDList&, LogList & list, const ::std::string& sKey);

	void AddAlarmList(LogList& list);
	void AddAlarm(LogMsg& msg);
	void CopyLogMsg(LogMsg& msg, CLogDataTbl& tbl);
	void CopyLogTable(CLogDataTbl& tbl, LogMsg& msg);
	int _GetLogCount(CLogDataTbl& tbl, __int64 lTimeEnd, __int64 lTimeBegin, 
		const IDList& types, const IDList& ids, const ::std::string& sKey);
	int _GetOfflineLog(CLogDataTbl& table, int nSkip, int nCount, __int64 lTimeEnd, __int64 lTimeBegin, 
		const IDList& types, const ::Gemma::IDList& ids, LogList& list, const ::std::string& sKey);

	int GetOnlineLog(CLogDataTbl& table, int nStart, int nCount, 
		const IDList& types, const IDList& ids, LogList& list, const ::std::string& sKey);

	SQLiteString GetListIDFilter(const IDList& listIDs, const char* strName);
	SQLiteString GetIDFilter(const IDList& ids);
	SQLiteString GetTypeFilter(const IDList& types);
	SQLiteString GetFindSQL( __int64 lTimeEnd, __int64 lTimeBegin, 
		const IDList& types, const IDList& ids, const ::std::string& sKey);
public:
	int GetMaxID(CLogDataTbl& table);
	void CheckDiskSpace(void);
	int MakeNewDB(void);
};

std::string GetProcessPath();