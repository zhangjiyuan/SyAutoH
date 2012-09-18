#include "StdAfx.h"
#include "SqlAceCli.h"
#include "TLinkSession.h"

DBSession::DBSession(void)
{
}


DBSession::~DBSession(void)
{
}


int DBSession::GetLoginSession(int nUserID, int nRight, 
	const string& strConnection, bool bLastLimit)
{
	int nSession = 0;
	CoInitialize(NULL);
	HRESULT hr;
	CLinkSessionTable linkSession;
	hr = linkSession.OpenAll();
	if (FAILED(hr))
	{
		CoUninitialize();
		return -1;
	}

	linkSession.m_UserID = nUserID;
	linkSession.m_OrginRight = nRight;
	linkSession.m_RealRight = nRight;
	CString strCon;
	strCon = strConnection.c_str();
	wcscpy_s(linkSession.m_ConnectInfo, strCon);
	linkSession.m_dwConnectInfoLength = strCon.GetLength()*2;
	
	COleDateTime t = COleDateTime::GetCurrentTime();
	DBTIMESTAMP ts;
	t.GetAsDBTIMESTAMP( ts ); // retrieves the time in t into the ts structure

	linkSession.m_AccessTime = ts;

	linkSession.m_dwSessionIDStatus = DBSTATUS_S_IGNORE;
	linkSession.m_dwUserIDStatus = DBSTATUS_S_OK;
	linkSession.m_dwOrginRightStatus = DBSTATUS_S_OK;
	linkSession.m_dwRealRightStatus = DBSTATUS_S_OK;
	linkSession.m_dwConnectInfoStatus = DBSTATUS_S_OK;
	linkSession.m_dwAccessTimeStatus = DBSTATUS_S_OK;
	hr = linkSession.Insert();
	if (FAILED(hr))
	{
		linkSession.CloseAll();
		CoUninitialize();
		return -1;
	}
	linkSession.UpdateAll();
	if (linkSession.MoveLast() != DB_S_ENDOFROWSET)
	{
		nSession = linkSession.m_SessionID;
	}
	linkSession.CloseAll();
	CoUninitialize();

	return nSession;
}
