#pragma once
#include "../common/LogDataDb.h"
#include "../shared/ThreadLock.h"


#include <Ice/ice.h>
#include <IceUtil/IceUtil.h>
#include "../../common/iLog.h"



using namespace std;
using namespace Gemma;

const int LogListCount = 4096;
const int UpLoadListCount = 2000;
//const int ReserveRecordCount = 10000;
//const int DelListCount = 700;
const DWORD VacuumTime =  2 * 60 * 60 * 1000;

class CLogger
{
public:
	CLogger(void);
	~CLogger(void);
	int Init(void);
	int End(void);
	//void Log(int nID, int nStation, const TCHAR* strMsg);
	void Log(int nID, UCHAR type, const CHAR* strUnit, const CHAR* strMsg);
	int InitICE(void);
	int EndICE(void);

protected:

	CLogDataTbl m_logTable;
	CGemmaDB m_logDB;
	//HANDLE hMsgQ;
	Ice::CommunicatorPtr communicator;
	LogPrx logger;
	//bool m_bStore;
	//bool m_bUpLoad;
	HANDLE m_eventStore;
	HANDLE m_eventUpLoad;
	bool m_bConnected;

private:
	rwmutex		m_MutexBuf;
	rwmutex		m_MutexDB;

	DWORD m_dwTick;
	std::string m_strFileName;
	std::string m_strModule;

	int m_nDupMark;
	int m_nOverBuf;
	Gemma::LogMsg logLast;
	HANDLE m_hThreadDbStore;
	HANDLE m_hThreadUpLoad;

	__int64 GetTime();

#ifdef WINCE
	static DWORD __stdcall  __DataDaseStore(LPVOID lp);
	static DWORD __stdcall  __DataUpLoad(LPVOID lp);
#else
	static unsigned __stdcall __DataDaseStore(LPVOID lp);
	static unsigned __stdcall __DataUpLoad(LPVOID lp);
#endif
	

	Gemma::LogMsg* m_logBuf[LogListCount];
	int m_nListBegin;
	int m_nListEnd;

	Gemma::LogMsg* Pop();
	void Push(const ::Gemma::LogMsg& data);

	bool        IsLogBufferFull()
	{
		bool bRet = false;
		RLock(m_MutexBuf)
		{
			if(m_nListEnd + 1 < LogListCount)
			{
				bRet =  ((m_nListEnd + 1) == m_nListBegin);
			}
			else if(m_nListEnd + 1 >= LogListCount)
			{
				bRet = ( ((m_nListEnd + 1) % LogListCount) == m_nListBegin);
			}
			else 
			{
				bRet =  false;
			}
		}
		return bRet;
	}

	bool       IsEventBufferEmpty() 
	{
		bool bRet = false;
		RLock(m_MutexBuf)
		{
			bRet =  (m_nListBegin == m_nListEnd);
		}
		return bRet;
	}

	int WritetoDb(void);
	int UpLoadtoServer(void);

	std::string GetProcessName();
	std::string GetProcessPath();
	
private:
	bool OpenDB(void);
	void CloseDB(bool bVacuum = false);
	int DeleteMsg(Gemma::LogList& msgList);
	int GetMsg(Gemma::LogList& msgList);
public:
	int GetAlarmCount(void);
	int GetLastType(void);
};
