#include "StdAfx.h"
#include "AlarmDataTbl.h"

CAlarmDataTbl::CAlarmDataTbl(void)
{
	//
	m_nID = 0;
	m_nEventID = 0;
	m_firstTime = 0;
	m_lastTime = 0;
	m_strMsg = "";
	m_nCount = 0;

	//these must match table above
	SetItem(0, "id",             MYDB_TYPE_ID, &m_nID);
	SetItem(1, "EventID",          MYDB_TYPE_INT,  &m_nEventID, true);
	SetItem(2, "FirstTime",			MYDB_TYPE_LONG, &m_firstTime);
	SetItem(3, "LastTime",			MYDB_TYPE_LONG, &m_lastTime);
	SetItem(4, "Message",   MYDB_TYPE_TEXT, &m_strMsg);
	SetItem(5, "Count",			MYDB_TYPE_INT, &m_nCount);
}

CAlarmDataTbl::~CAlarmDataTbl(void)
{
}

const char* CAlarmDataTbl::TableName() 
{ 
	return "AlarmData"; 
}

int CAlarmDataTbl::ItemCount() 
{ 
	return 6; 
}

