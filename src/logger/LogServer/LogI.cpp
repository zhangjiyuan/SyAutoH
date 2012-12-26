#include "StdAfx.h"
#include <strstream>
#include "LogI.h"
#include "LogDef.h"
#include <IceUtil/Unicode.h>

//////////////////////////////////////////////////////////////////////////
//
void CLogI::getOldFiles( string path, vector<string>& files, time_t today, int nDayOld )
{
    //文件句柄 
    intptr_t   hFile   =   0; 
    //文件信息 
    struct _finddata_t fileinfo; 
	time_t tcomp;
	tcomp = nDayOld * 24 * 60 * 60;

	WLock(m_muMap)
	{
		queryMap.clear();

		string p;

		if   ((hFile   =   _findfirst(p.assign(path).append("/*").c_str(),&fileinfo))   !=   -1)  
		{ 
			do  
			{ 
				//如果是目录,迭代之
				//如果不是,加入列表
				if   ((fileinfo.attrib   &   _A_SUBDIR)) 
				{ 
				   // if   (strcmp(fileinfo.name,".")   !=   0   &&   strcmp(fileinfo.name,"..")   !=   0) 
				   //     getFiles(   p.assign(path).append("/").append(fileinfo.name), files   ); 
				}  
				else  
				{ 
					time_t tDiff =  today - fileinfo.time_write;
					//struct tm Diff;
					//_localtime64_s(&Diff, &tDiff);
					string strfileName = "";
					strfileName = p.assign(path).append("/").append(fileinfo.name);
					if (tDiff > tcomp)
					{
						files.push_back(   strfileName  );
					}
					else
					{
						long long dateKey = 0;
						string strDate;
						strDate = fileinfo.name;
						strDate.replace(0, sizeof(LOG_DB_FILE)-1, "" );
						sscanf_s(strDate.c_str(), "%lld", &dateKey);
						if (dateKey > 0)
						{
							//map <int, string>::iterator qu_Iter = queryMap.find(dateKey);
							//if (qu_Iter)
							{
								queryMap.insert(IntStr_Pair(dateKey, strfileName));
							}
						}
						
					}
				} 
			}   while   (_findnext(   hFile,   &fileinfo   )   ==   0); 

			_findclose(hFile); 
		}
	}
} 


CLogI::CLogI(HWND wnd)
: _wnd(wnd)
{
	m_strLogFileName = "";
	m_strAlarmFileName = "";

	m_hThreadDbStore = NULL;
	m_eventStore = NULL;
	m_nBoundID = 0;
	
	//////////////////////////////////////////////////////////////////////////
	InitDbStore();
}

CLogI::~CLogI(void)
{
	if (m_hThreadDbStore)
	{
		SetEvent(m_eventStore);
		WaitForSingleObject(m_hThreadDbStore, 2000);  
		CloseHandle(m_hThreadDbStore);
		m_hThreadDbStore = NULL;
	}
	CloseHandle(m_eventStore);
	
	WLock(m_muLogDB)
	{
		m_logTable.Close();
		m_logDB.Close();
	}

	WLock(m_muAlarmDB)
	{
		m_alarmTable.Close();
		m_alarmDB.Close();
	}
}

std::string GetProcessPath()
{
	TCHAR buf[256] = {0};
	GetModuleFileName(NULL, buf, 256);
	std::wstring wstr;
	wstr = buf;
	std::string str = "";
	str =  IceUtil::wstringToString(wstr);

	int nBar = (int)str.find_last_of('\\') + 1;
	str = str.substr(0, nBar);

	//int nCm = str.find_last_of('.');
	//str = str.substr(0, nCm);

	return str;
}

void CLogI::InitDbStore()
{
	//g_logDB.ConnectDb("./Application Data/GemmaLog.db");
	//g_logTable.Open(g_logDB.GetDBPtr());
	DelOldFiles();

	std::string strPath = GetProcessPath();

	TCHAR wstrPath[1024] = {0};
	std::string strDataPath;
	strDataPath = strPath + "..\\data\\";
	mbstowcs(wstrPath,strDataPath.c_str(), strDataPath.size());
	CreateDirectory(wstrPath,NULL);

	strDataPath = strPath + "..\\data\\log\\";
	mbstowcs(wstrPath,strDataPath.c_str(), strDataPath.size());
	CreateDirectory(wstrPath,NULL);

	m_strLogFileName = GetProcessPath() + "../data/log/";
	m_strLogFileName += LOG_DB_FILE ;
	m_strLogFileName += ".logdb";

	m_strAlarmFileName = GetProcessPath() + "../data/log/";
	m_strAlarmFileName += ALARM_DB_FILE;
	m_strAlarmFileName += ".logdb";

	BOOL bConnect = FALSE;
	BOOL bOpen = FALSE;
	WLock(m_muLogDB)
	{
		bConnect = m_logDB.ConnectDb(m_strLogFileName.c_str());
		if (FALSE == bConnect)
		{
			return ;
		}

		bOpen = m_logTable.Open(m_logDB.GetDBPtr());
		if (FALSE == bOpen)
		{
			MakeNewDB();
			//return ;
		}
	}
	

	WLock(m_muAlarmDB)
	{
		bConnect = m_alarmDB.ConnectDb(m_strAlarmFileName.c_str());
		if (FALSE == bConnect)
		{
			return ;
		}

		bOpen = m_alarmTable.Open(m_alarmDB.GetDBPtr());
		if (FALSE == bOpen)
		{
			return ;
		}
	}
	

	InitBoundID();

	//m_hThreadDbStore = _beginthread();
	unsigned	dwThreadId = 0;
	bool ret = false;
	m_eventStore = CreateEvent(NULL, true, false, NULL);
	m_hThreadDbStore = (HANDLE)_beginthreadex(NULL, 0, __DataDaseStore, (LPVOID)this, 0, &dwThreadId);

	if (m_hThreadDbStore)
	{
		SetThreadPriority(m_hThreadDbStore, THREAD_PRIORITY_BELOW_NORMAL);
		ret = true;
	}
	else
	{
		ret = false;
	}
}

unsigned CLogI::__DataDaseStore(LPVOID lp)
{
	CLogI* pLog = static_cast<CLogI*>(lp);

	while(1)
	{
		pLog->CheckDiskSpace();
		pLog->WritetoDb();
		//Sleep(50);
		DWORD dwRet = WaitForSingleObject(pLog->m_eventStore, 50);
		if (WAIT_OBJECT_0 == dwRet)
		{
			break;
		}
	}

	return 0;
}

int CLogI::GetLastID(const ::Ice::Current& /* = ::Ice::Current */)
{
	int nLastID = -1;
	nLastID = GetLastIDinCurrent();
	if (nLastID <= 0)
	{
		nLastID = GetLastIDinHistory();
	}

	return nLastID;
}

int CLogI::GetLogFromCurrent(::Ice::Int nStart, ::Ice::Int nCount, const IDList& types, 
							 const IDList& ids, LogList & list, const ::std::string& sKey)
{
	RLock(m_muLogDB)
	{
		GetOnlineLog(m_logTable, nStart, nCount, types, ids, list, sKey);
	}

	return ((int)list.size());
}

int CLogI::GetLogFromTimeHistory(::Ice::Int nStart, ::Ice::Int nCount, const IDList& types, 
								 const IDList& ids, LogList & list, const ::std::string& sKey)
{
	RLock(m_muMap)
	{
		if (queryMap.size() <= 0)
		{
			return 0;
		}

		string strDbFileName = "";
		int nResCount = 0;
		int nRes = 0;

		map <__int64, string>::iterator  iter;
		iter = queryMap.find(m_DateKey);

		if (iter != queryMap.end())
		{
			++iter;
		}

		if (iter == queryMap.end())
		{
			--iter;
		}

		while((nResCount < nCount) && (iter != queryMap.end()))
		{
			strDbFileName = iter->second;
			nRes = GetLogFromSingleDB(strDbFileName, nStart, nCount-nResCount, types, ids, list, sKey);
			if (nRes > 0)
			{
				nResCount += nRes;
			}

			--iter;
		}
	}

	return ((int)list.size());
}

int CLogI::GetLogFromAllHistory(::Ice::Int nStart, ::Ice::Int nCount, const IDList& types, 
								const IDList& ids, LogList & list, const ::std::string& sKey)
{
	RLock(m_muMap)
	{
		if (queryMap.size() <= 0)
		{
			return 0;
		}

		string strDbFileName = "";
		int nResCount = 0;
		int nRes = 0;

		map <__int64, string>::reverse_iterator   iter;
		iter = queryMap.rbegin();
		while((nResCount < nCount) && (iter != queryMap.rend()))
		{
			strDbFileName = iter->second;
			nRes = GetLogFromSingleDB(strDbFileName, nStart, nCount-nResCount, types, ids, list, sKey);
			if (nRes > 0)
			{
				nResCount += nRes;
			}

			++iter;
		}
	}

	return ((int)list.size());
}

int CLogI::GetLogFromSingleDB(string strDBFile,::Ice::Int nStart,
							  ::Ice::Int nCount, const IDList& types, const IDList& ids, LogList & list, const ::std::string& sKey)
{
	if (ids.size() <= 0)
	{
		return 0;
	}

	CGemmaDB logDB;
	CLogDataTbl logTable;

	if (strDBFile.length() <= 0)
	{
		return 0;
	}

	BOOL bConnect = logDB.ConnectDb(strDBFile.c_str());
	if (FALSE == bConnect)
	{
		return 0;
	}

	BOOL bOpen = logTable.Open(logDB.GetDBPtr());
	if (FALSE == bOpen)
	{
		return 0;
	}

	GetOnlineLog(logTable, nStart, nCount, types, ids, list, sKey);

	logTable.Close();
	logDB.Close();

	return ((int)list.size());
}

LogList CLogI::GetLog(::Ice::Int nStart, ::Ice::Int nCount, const IDList& types, const IDList& ids, 
					  const ::std::string& sKey, const ::Ice::Current& )
{
	LogList list;
	int nResCount = 0;
	int nReCount = 0;

	if ((nStart >= m_nBoundID) && (m_nBoundID > 0))
	{
		nResCount = GetLogFromCurrent(nStart, nCount, types, ids, list, sKey);
		if (nResCount < nCount)
		{
			//// find in near files
			nReCount = nCount - nResCount;
			nReCount = GetLogFromAllHistory(nStart, nReCount, types, ids, list, sKey);
		}
	}
	else if(nStart > 0)
	{
		nReCount = GetLogFromTimeHistory(nStart, nCount, types, ids, list, sKey);
	}
	
	return list;
}

void CLogI::sendLog(const ::Gemma::LogList& listdata, const ::Ice::Current& /* = ::Ice::Current */)
{
	LogList::const_iterator it;
	LogList::const_iterator itEnd = listdata.end();

	WLock(m_muLogBuf)
	{
		for (it = listdata.begin(); it != itEnd; ++it)
		{
			m_qLogBuf.push(*it);
		}
	}
}

int CLogI::WritetoDb(void)
{
	LogMsg msg;

	RLock(m_muLogBuf)
	{
		if (m_qLogBuf.empty())
		{
			return -1;
		}
	}

	LogList almMsgList;
	WLock(m_muLogDB)
	{
		m_logTable.BeginTrans();
		WLock(m_muLogBuf)
		{
			int nCount = 0;
			while(!m_qLogBuf.empty())
			{
				msg = m_qLogBuf.front();

				//__int64 lTime = msg.lTime;
				//msg.strUser = GetOperatorName(lTime);
				m_logTable.AddNew();
				CopyLogTable(m_logTable, msg);
				m_logTable.Update();

				if (LogType::Error == msg.nType)
				{
					almMsgList.push_back(msg);
				}

				m_qLogBuf.pop();

				++nCount;
				if (nCount > 3000)
				{
					break;
				}
			}
		}
		bool bRet = m_logTable.EndTrans();
		if (false == bRet)
		{
			MakeNewDB();
		}
	}

	if (m_nBoundID <= 0)
	{
		InitBoundID();
	}
	BackUpDB();

	AddAlarmList(almMsgList);


	return 0;
}

void CLogI::DelOldFiles(void)
{
	time_t ltime;
	time(&ltime);
	//struct tm today;
	//_localtime64_s( &today, &ltime );

	vector<string>   files; 
	std::string strPath = 
		GetProcessPath() + "../data/log/";
	getOldFiles( strPath, files, ltime, 90 ); //day

	size_t nCount = 0;
	nCount = files.size();
	for (size_t i=0; i<nCount; i++)
	{
		string strfile = files[i];
		//remove(strfile.c_str());
	}

}

void CLogI::BackUpDB(void)
{
	WLock(m_muLogDB)
	{
		m_logTable.SetFilter("");
		int nCount = m_logTable.ReadCount();

		if (nCount > DBMAXCOUNT)
		{
			
			MakeNewDB();
			// delete old files
			DelOldFiles();
			return;
		}
		
		//DelOldFiles();
	}
}

int CLogI::GetOfflineCountInCurrent(::Ice::Long llTimeEnd, ::Ice::Long llTimeBegin, const IDList& types, 
									const IDList& ids, const ::std::string& sKey)
{
	int nCount = 0;

	RLock(m_muLogDB)
	{
		nCount = _GetLogCount(m_logTable, llTimeEnd, llTimeBegin, types, ids, sKey);
	}

	return nCount;
}

int CLogI::GetOfflineCountInDateStore(::Ice::Long llTimeEnd, ::Ice::Long llTimeBegin, const IDList& types, 
									  const IDList& ids, const ::std::string& sKey)
{
	size_t nCount = 0;
	int nRetCount = 0;
	RLock(m_muMap)
	{
		nCount = queryMap.size();
		__int64 DateKey = 0;
		if (nCount <= 0)
		{
			return 0;
		}

		//int nIndex = 0;
		string strDBFile;
		map <__int64, string>::iterator  iter;

		__int64 timeStart = llTimeEnd - Time_Diff;
		int nFindCount = 0;

		for(iter = queryMap.begin(); iter != queryMap.end(); iter++)
		{
			__int64 lTime = iter->first;
		  
			if(lTime >= timeStart)
			{
			   strDBFile = iter->second;
			   DateKey = iter->first;
			   if (strDBFile.length() > 1)
			   {
				   nFindCount = GetOfflineCountInFile(strDBFile, llTimeEnd, llTimeBegin, types, ids, sKey);
				   nRetCount += nFindCount;
			   }
			}
			
			if(lTime > llTimeEnd)
			{
				break;
			}
		}
	}

	return nRetCount;
}


int CLogI::GetOfflineCountInFile(const string& strDB, ::Ice::Long llTimeEnd, ::Ice::Long llTimeBegin, const IDList& types, 
								 const IDList& ids, const ::std::string& sKey)
{
	CGemmaDB logDB;
	CLogDataTbl logTable;
	BOOL bConnect = logDB.ConnectDb(strDB.c_str());
	if (FALSE == bConnect)
	{
		return 0;
	}

	BOOL bOpen = logTable.Open(logDB.GetDBPtr());
	if (FALSE == bOpen)
	{
		return 0;
	}

	int nCount = 0;

	nCount = _GetLogCount(logTable, llTimeEnd, llTimeBegin, types, ids, sKey);

	logTable.Close();
	logDB.Close();

	return nCount;
}

void CLogI::InitBoundID(void)
{
	int nLastID = -1;
	RLock(m_muLogDB)
	{
		m_logTable.SetLimit(1);
		m_logTable.SetSort("[id] ");
		m_logTable.SetFilter("");
		m_logTable.Query();
		int nCount = m_logTable.GetCount();
		if (nCount > 0)
		{
			nLastID = m_logTable.m_id;
		}

		if (nLastID > 0)
		{
			m_nBoundID = nLastID;
		}
	}
}

int CLogI::GetLastIDinCurrent(void)
{
	int nLastID = -1;

	RLock(m_muLogDB)
	{
		nLastID = GetMaxID(m_logTable);
	}
	
	return nLastID;
}

int CLogI::GetLastIDinHistory(void)
{
	int nLastID = -1;

	CGemmaDB logDB;
	CLogDataTbl logTable;

	string strCurHistoryDBFile;
	map <__int64, string>::reverse_iterator  iter;
	__int64 findKey = 0;
	RLock(m_muMap)
	{
		iter = queryMap.rbegin();
		if (iter == queryMap.rend())
		{
			return -1;
		}
		strCurHistoryDBFile = iter->second;
		findKey = iter->first;
	}


	if (strCurHistoryDBFile.length() <= 0)
	{
		return -1;
	}

	BOOL bConnect = logDB.ConnectDb(strCurHistoryDBFile.c_str());
	if (FALSE == bConnect)
	{
		return -1;
	}

	BOOL bOpen = logTable.Open(logDB.GetDBPtr());
	if (FALSE == bOpen)
	{
		return -1;
	}
	
	nLastID = GetMaxID(logTable);
	if (nLastID > 0)
	{
		m_strCurHistoryDBFile = strCurHistoryDBFile;
		m_DateKey = findKey;
		
	}

	logTable.Close();
	logDB.Close();

	return nLastID;
}

 int CLogI::GetCountOffline(::Ice::Long lTimeEnd, ::Ice::Long lTimeBegin, const ::Gemma::IDList& nTypes, 
	const ::Gemma::IDList& ids, const ::std::string& strKey, const ::Ice::Current& /* = ::Ice::Current */)
 {
	int nCountStote = 0;
	nCountStote = GetOfflineCountInDateStore(lTimeEnd, lTimeBegin, nTypes, ids, strKey);

	int nCountCurren = 0;
	nCountCurren = GetOfflineCountInCurrent(lTimeEnd, lTimeBegin, nTypes, ids, strKey);

	int nTotal = 0;
	nTotal = nCountCurren + nCountStote;
	
	return nTotal;
 }

 LogList CLogI::GetLogOffline(::Ice::Int nSkip, ::Ice::Int nCount, ::Ice::Long lTimeEnd, ::Ice::Long lTimeBegin, 
	 const ::Gemma::IDList& nTypes, const ::Gemma::IDList& ids, const ::std::string& strKey, const ::Ice::Current& /* = ::Ice::Current */)
 {
	LogList list;

	int nStoreCount = 0;
	nStoreCount = GetOfflineLogInDataStore(nSkip, nCount, lTimeEnd, lTimeBegin, nTypes, ids, list, strKey);
	
	int nCurCount = 0;
	if (nCount > 0)
	{
		nCurCount = GetOfflineLogInCurrent(nSkip, nCount, lTimeEnd, lTimeBegin, nTypes, ids, list, strKey);
	}


	/*LogList retList;
	size_t szList = list.size();
	int nEnd = nSkip + nCount;
	for (int i=nSkip; i<nEnd; i++)
	{
		if (i>= szList)
		{
			break;
		}
		LogMsg msg = list[i];
		retList.push_back(msg);
	}*/

	return list;
 }

 int CLogI::GetOfflineLogInCurrent(int nSkip, int nCount, ::Ice::Long llTimeEnd, ::Ice::Long llTimeBegin, const IDList& types, 
	 const ::Gemma::IDList& ids, LogList & list, const ::std::string& strKey)
 {
	 int nRetCount = 0;

	 RLock(m_muLogDB)
	 {
		nRetCount = _GetOfflineLog(m_logTable, nSkip, nCount, llTimeEnd, llTimeBegin, types, ids, list, strKey);
	 }

	 return nRetCount;
 }

 int CLogI::GetOfflineLogInDataStore(int & nSkip, int & nGetCount, ::Ice::Long llTimeEnd, ::Ice::Long llTimeBegin, 
	 const IDList& types, const ::Gemma::IDList& ids, LogList & list, const ::std::string& strKey)
 {
	size_t nCount = 0;
	int nRetCount = 0;
	RLock(m_muMap)
	{
		nCount = queryMap.size();
		__int64 DateKey = 0;
		if (nCount <= 0)
		{
			return 0;
		}

		string strDBFile;
		map <__int64, string>::iterator  iter;

		__int64 timeStart = llTimeEnd - Time_Diff;
		int nFindCount = 0;

		int nOrgGetCount = nGetCount;

		for(iter = queryMap.begin(); iter != queryMap.end(); iter++)
		{
			__int64 lTime = iter->first;

			if (lTime >= timeStart) 
			{
				strDBFile = iter->second;
				DateKey = iter->first;
				if (strDBFile.length() > 1)
				{
					int nDbCount = GetOfflineCountInFile(strDBFile, llTimeEnd, llTimeBegin, types, ids, strKey);
					if (nSkip >= nDbCount)
					{
						nSkip -= nDbCount;
						nFindCount = 0;
					}
					else
					{
						nFindCount = GetOfflineLogInFile(strDBFile, nSkip, nGetCount, llTimeEnd, llTimeBegin, types, ids, list, strKey);
						nSkip = 0;
						nGetCount -= nFindCount;
					}

					nRetCount += nFindCount;

					if (nRetCount >= nOrgGetCount)
					{
						break;
					}

					if (nGetCount <= 0 )
					{
						break;
					}
				}
			}

			if (lTime > llTimeEnd)
			{
				break;
			}
		}
	}

	return nRetCount;
 }

 int CLogI::GetOfflineLogInFile(const string& strDB, int nSkip, int nGetCount, ::Ice::Long llTimeEnd, 
	 ::Ice::Long llTimeBegin, const IDList& types, const ::Gemma::IDList& ids, LogList & list, const ::std::string& strKey)
 {
	 CGemmaDB logDB;
	 CLogDataTbl logTable;
	 BOOL bConnect = logDB.ConnectDb(strDB.c_str());
	 if (FALSE == bConnect)
	 {
		 return 0;
	 }

	 BOOL bOpen = logTable.Open(logDB.GetDBPtr());
	 if (FALSE == bOpen)
	 {
		 return 0;
	 }

	 int nCount = 0;

	 nCount = _GetOfflineLog(logTable, nSkip, nGetCount, llTimeEnd, llTimeBegin, types, ids, list, strKey);

	 logTable.Close();
	 logDB.Close();

	 return nCount;
 }

 int CLogI::GetAlarmCount(const ::Ice::Current& /* = ::Ice::Current */)
 {
	 int nCount = 0;
	 RLock(m_muAlarmDB)
	 {
		 m_alarmTable.SetFilter("");
		 nCount = m_alarmTable.ReadCount();
	 }

	 return nCount;
 }

 AlarmList CLogI::GetAlarms(::Ice::Int nSkip, ::Ice::Int nCount, const ::Ice::Current& /* = ::Ice::Current */)
 {
	AlarmList list;

	RLock(m_muAlarmDB)
	{
		m_alarmTable.SetFilter("");
		m_alarmTable.SetSkip(nSkip);
		m_alarmTable.SetLimit(nCount);
		m_alarmTable.SetSort("[LastTime] ASC");
		m_alarmTable.Query();
		int ntabCount = m_alarmTable.GetCount();
		if (ntabCount > 0)
		{
			m_alarmTable.MoveFirst();
			while( !m_alarmTable.IsEOF() )
			{
				AlarmMsg msg;
				msg.nID = m_alarmTable.m_nID;
				msg.nEventID = m_alarmTable.m_nEventID;
				msg.firstTime = m_alarmTable.m_firstTime;
				msg.lastTime = m_alarmTable.m_lastTime;
				msg.strMsg = m_alarmTable.m_strMsg;
				msg.nCount = m_alarmTable.m_nCount;
				list.push_back(msg);
				m_alarmTable.MoveNext();
			}

		}
	}

	return list;
 }

void CLogI::ClearAlarms(const ::Gemma::IDList& list, const ::Ice::Current& /* = ::Ice::Current */)
{
	WLock(m_muAlarmDB)
	{
		IDList::const_iterator it;
		it = list.begin();
		while(it != list.end())
		{
			int nID = *it;
			SQLiteString strFind;
			strFind.Format("[EventID] == %d", nID);
			m_alarmTable.SetFilter(strFind);

			m_alarmTable.Query();
			int ntabCount = m_alarmTable.GetCount();
			if (ntabCount > 0)
			{
				m_alarmTable.Delete();
				m_alarmTable.Update();
			}

			++it;
		}
	}
}

void CLogI::AddAlarmList(LogList& list)
{
	size_t szCount = 0;
	szCount = list.size();
	if (szCount <= 0)
	{
		return;
	}

	LogList::iterator it;
	it = list.begin();
	WLock(m_muAlarmDB)
	{
		m_alarmTable.BeginTrans();
		while(it != list.end())
		{
			AddAlarm(*it);
			++it;
		}
		m_alarmTable.EndTrans();
	}
}

void CLogI::AddAlarm(LogMsg& msg)
{
	int nEventID = msg.nEventID;
	SQLiteString strFind;	
	strFind.Format("[EventID] == %d", nEventID);
	m_alarmTable.SetFilter(strFind);
	m_alarmTable.Query();
	int nCount = m_alarmTable.GetCount();
	if (nCount > 0)
	{
		m_alarmTable.Edit();
		if (msg.lTime < m_alarmTable.m_firstTime)
		{
			m_alarmTable.m_firstTime = msg.lTime;
		}
		else if (msg.lTime > m_alarmTable.m_lastTime)
		{
			m_alarmTable.m_lastTime = msg.lTime;
		}
		++m_alarmTable.m_nCount;
		m_alarmTable.Update();
	}
	else
	{
		m_alarmTable.AddNew();
		m_alarmTable.m_nEventID = nEventID;
		m_alarmTable.m_firstTime = msg.lTime;
		m_alarmTable.m_lastTime = msg.lTime;
		m_alarmTable.m_strMsg = msg.strMsg.c_str();
		m_alarmTable.m_nCount = 1;
		m_alarmTable.Update();
	}
}

void CLogI::CopyLogMsg(LogMsg& msg, CLogDataTbl& tbl)
{
	msg.nUnit = 0;
	msg.nID = tbl.m_id;
	msg.nEventID = tbl.m_nEventID;
	msg.nType = (short)tbl.m_nType;
	msg.lTime = tbl.m_llTime;	
	msg.strUnit = tbl.m_strUnit;
	msg.strMsg = tbl.m_strMsg;
	msg.strUser = tbl.m_strUser;
	msg.dParam1 = tbl.m_dParam1;
	msg.dParam2 =tbl.m_dparam2;
	msg.nParam1 = tbl.m_nParam1;
	msg.nParam2 = tbl.m_nParam2;
}

void CLogI::CopyLogTable(CLogDataTbl& tbl, LogMsg& msg)
{
	tbl.m_nEventID = msg.nEventID;
	tbl.m_llTime = msg.lTime;
	tbl.m_nType = msg.nType;
	tbl.m_strUnit = msg.strUnit.c_str();
	tbl.m_strMsg = msg.strMsg.c_str();
	tbl.m_strUser = msg.strUser.c_str();
	tbl.m_nParam1 = msg.nParam1;
	tbl.m_nParam2 = msg.nParam2;
	tbl.m_dParam1 = msg.dParam1;
	tbl.m_dparam2 = msg.dParam2;
}

SQLiteString CLogI::GetFindSQL( __int64 lTimeEnd, __int64 lTimeBegin, 
						const IDList& types, const IDList& ids, const ::std::string& sKey)
{
	SQLiteString strFind;
	strFind.Format("[Time] <= %lld and [Time] >= %lld", lTimeEnd, lTimeBegin);
	SQLiteString strType = GetTypeFilter(types);
	strFind += strType;

	//wstring wstr = IceUtil::stringToWstring(sKey);
	//wstr.size();
	// march skey
	if (sKey.size() > 0)
	{
		strFind += " and [Message] like '%";
		strFind += sKey.c_str();
		strFind += "%'";
	}

	SQLiteString strIDFilter = GetIDFilter(ids);
	strFind += strIDFilter;
	return strFind;
}

int CLogI::_GetLogCount(CLogDataTbl& tbl, __int64 lTimeEnd, __int64 lTimeBegin, 
						const IDList& types, const IDList& ids, const ::std::string& sKey)
{
	if (ids.size() <= 0)
	{
		return 0;
	}

	int nCount = 0;
	SQLiteString strFind;
	strFind = GetFindSQL(lTimeEnd, lTimeBegin, types, ids, sKey);
	tbl.SetFilter(strFind);
	//tbl.Query();
	//nCount = tbl.GetCount();
	nCount = tbl.ReadCount();

	return nCount;
}

int CLogI::_GetOfflineLog(CLogDataTbl& table, int nSkip, int nGetCount,  __int64 lTimeEnd,  
						  __int64 lTimeBegin, const IDList& types, const ::Gemma::IDList& ids, LogList& list, const ::std::string& sKey)
{
	int nCount = 0;

	if (ids.size() <= 0)
	{
		return 0;
	}

	SQLiteString strFind;
	strFind = GetFindSQL(lTimeEnd, lTimeBegin, types, ids, sKey);

	table.SetSort("[Time] ASC");
	table.SetSkip(nSkip);
	table.SetLimit(nGetCount);
	table.SetFilter(strFind);
	table.Query();
	nCount = table.GetCount();
	if (nCount > 0)
	{
		table.MoveFirst();
		while(!table.IsEOF())
		{
			LogMsg msg;
			CopyLogMsg(msg, table);
			list.push_back(msg);
			table.MoveNext();
		}
	}

	table.SetSkip(-1);
	table.SetLimit(-1);

	return nCount;
}

int CLogI::GetOnlineLog(CLogDataTbl& table, int nStart, int nCount, 
						const IDList& types, const IDList& ids, LogList& list, const ::std::string& sKey)
{
	if (ids.size() <= 0)
	{
		return 0;
	}

	// march skey
	if (sKey.size() <= 0)
	{
	}

	table.SetLimit(nCount);
	table.SetSort("[id] DESC");
	SQLiteString strId;
	
	strId.Format("[id] <= %d", nStart);
	SQLiteString strType = GetTypeFilter(types);
	strId += strType;
	
	SQLiteString strIDFilter = GetIDFilter(ids);
	strId += strIDFilter;
	table.SetFilter(strId);
	table.Query();

	int nC = table.GetCount();
	if(nC <= 0)
	{
		return 0;
	}

	int nMaxID = table.m_id;
	if (nStart > nMaxID)
	{
		nStart = nMaxID;
	}

	table.MoveFirst();
	while(!table.IsEOF())
	{
		LogMsg msg;
		CopyLogMsg(msg, table);
		list.push_back(msg);
		table.MoveNext();
	}

	return nC;
}

SQLiteString CLogI::GetListIDFilter(const IDList& listIDs, const char* strName)
{
	SQLiteString strFind = "";

	IDList::const_iterator it;
	SQLiteString strIDS;
	for(it = listIDs.begin(); it != listIDs.end(); ++it)
	{
		int nID  = *it;
		if (nID < 0)
		{
			break;
		}
		SQLiteString strAndID;

		if (strIDS.GetLength() > 0)
		{
			strAndID.Format(" or [%s] == %d ", strName, nID);
		}
		else
		{
			strAndID.Format(" [%s] == %d ", strName, nID);
		}
		strIDS += strAndID;
	}
	if (strIDS.GetLength() > 0)
	{
		strFind += " and ( ";
		strFind += strIDS;
		strFind += " )";
	}

	return strFind;
}

SQLiteString CLogI::GetIDFilter(const IDList& ids)
{
	return GetListIDFilter(ids, "EventID");
}
SQLiteString CLogI::GetTypeFilter(const IDList& types)
{
	return GetListIDFilter(types, "Type");
}

int CLogI::GetMaxID(CLogDataTbl& table)
{
	int nLastID = -1;
	table.SetLimit(1);
	table.SetSkip(-1);
	table.SetSort("[id] DESC");
	table.SetFilter("");
	table.Query();
	int nCount = table.GetCount();
	if (nCount > 0)
	{
		nLastID = table.m_id;
	}
	return nLastID;
}

//string CLogI::GetOperatorName(__int64 lTime)
//{
//	//lTime++;
//	//return "Test";
//
//	return GetOperatorNameByTime(lTime);
//}

__int64 GetDiskSpace(const wstring &wszPath)
{
	__int64 i64FreeBytesToCaller, i64TotalBytes, i64FreeBytes;

	BOOL bRet =  GetDiskFreeSpaceEx (wszPath.c_str(),  
		(PULARGE_INTEGER)&i64FreeBytesToCaller,
		(PULARGE_INTEGER)&i64TotalBytes,
		(PULARGE_INTEGER)&i64FreeBytes);

	if(!bRet)
	{
		//		Aloha::log(INFO, _T(" Get Disk space error.") );
		return 0;      
	}
	return i64FreeBytes;
}

void CLogI::CheckDiskSpace(void)
{
	static DWORD LastCheck = 0;
	DWORD TimeDiskCheck = GetTickCount();

	// TimeDiskCheck must bigger than LastCheck,
	if (TimeDiskCheck < LastCheck)
	{
		LastCheck = TimeDiskCheck;
	}

	if ( (TimeDiskCheck - LastCheck) < 5000 )
	{
		return;
	}

	LastCheck = TimeDiskCheck;

	wstring wstrPath = GetProcessPathWS();

	__int64 lSpace = GetDiskSpace(wstrPath);
	__int64 lSDisp = 0;
	lSDisp = lSpace / 1024 / 1024; // MB
	//float fSpace = lSDisp / 1024.0f; // GB

	int nDiskLimit = 200; // MB

	if (lSDisp < nDiskLimit) // disk space is lower than 200MB
	{
		// alarm
		SYSTEMTIME time;
		GetLocalTime(&time);

		__int64 _64Time = 0;

		char buf[24] = {0};
		sprintf(buf, "%04d%02d%02d%02d%02d%02d%03d", time.wYear, 
			time.wMonth, time.wDay, time.wHour, time.wMinute,
			time.wSecond, time.wMilliseconds);

		_64Time = _atoi64(buf);

		LogMsg logData;
		logData.nEventID = LID_SYS_DiskLow;
		logData.dParam1 = 0;
		logData.dParam2 = 0;
		logData.nParam1 = 0;
		logData.nParam2 = 0;
		logData.lTime = _64Time;
		logData.nType = LogType::Error;


		logData.strUnit = SYS_MODULE;

		stringstream os;
		os << "The free space of the server disk is low. The free space remained is " << lSDisp;
		logData.strMsg = os.str();

		WLock(m_muLogBuf)
		{
			{
				m_qLogBuf.push(logData);
			}
		}
	}
}

int CLogI::MakeNewDB(void)
{
	int nLaseID = GetMaxID(m_logTable);

	m_logTable.Close();
	m_logDB.Close();

	SYSTEMTIME time;
	GetLocalTime(&time);

	//__int64 _64Time = 0;
	char buf[24] = {0};
	sprintf(buf, "%04d%02d%02d%02d%02d%02d%03d", time.wYear, 
		time.wMonth, time.wDay, time.wHour, time.wMinute,
		time.wSecond, time.wMilliseconds);
	//sscanf(buf, "%lld", &_64Time);
	std::string strNewFileName = 
		GetProcessPath() + "../data/log/GemmaLog";
	strNewFileName += buf;
	strNewFileName += ".logdb";

	m_strLogFileName = GetProcessPath() + "../data/log/GemmaLog.logdb";
	MoveFileA(m_strLogFileName.c_str(), strNewFileName.c_str());
	//DWORD dwErr = GetLastError();

	BOOL bConnect = m_logDB.ConnectDb(m_strLogFileName.c_str());
	if (FALSE == bConnect)
	{
		return -1;
	}

	BOOL bOpen = m_logTable.Open(m_logDB.GetDBPtr());
	if (FALSE == bOpen)
	{
		return -1;
	}

	std::string str;
	_itoa_s(nLaseID, buf, 10);
	str = buf;
	//str.Format("%d", nLaseID);
	std::string strTableName = m_logTable.TableName();
	std::string strSQL = "update sqlite_sequence set seq = ";
	strSQL += str;
	strSQL += " where name = '";
	strSQL += strTableName;
	strSQL += "';";

	m_logTable.AddNew();
	m_logTable.Update();
	m_logTable.Delete();
	m_logTable.ExeSQL(strSQL.c_str());
	m_nBoundID = nLaseID;

	//TRACE(_T("-------------last id %d ----------\n"), nLaseID);
	return nLaseID;
}
