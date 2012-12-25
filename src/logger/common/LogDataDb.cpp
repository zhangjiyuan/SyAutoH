#include "StdAfx.h"
#include "LogDataDb.h"

CLogDataTbl::CLogDataTbl(void)
{
	m_id = 0;
	m_llTime = 0;
	m_nType = 0;
	m_strUnit = "";
	m_strMsg = "";
	m_strUser = "";
	m_nParam1 = 0;
	m_nParam2 = 0;
	m_dParam1 = 0;
	m_dparam2 = 0;
	m_nEventID = 0;

	//these must match table above
	SetItem(0, "id",             MYDB_TYPE_ID, &m_id);
	SetItem(1, "Time",			MYDB_TYPE_LONG, &m_llTime, true);
	SetItem(2, "Type",          MYDB_TYPE_INT,  &m_nType, true);	
	SetItem(3, "EventID",          MYDB_TYPE_INT,  &m_nEventID, true);
	SetItem(4, "Unit",          MYDB_TYPE_TEXT, &m_strUnit);
	SetItem(5, "Message",   MYDB_TYPE_TEXT, &m_strMsg);	
	SetItem(6, "User",   MYDB_TYPE_TEXT, &m_strUser);
	SetItem(7, "intParam1",			MYDB_TYPE_INT, &m_nParam1);
	SetItem(8, "intParam2",          MYDB_TYPE_INT,  &m_nParam2);
	SetItem(9, "doubleParam1",          MYDB_TYPE_DOUBLE, &m_dParam1);
	SetItem(10, "doubleParam2",   MYDB_TYPE_DOUBLE, &m_dparam2);
}

CLogDataTbl::~CLogDataTbl(void)
{
	
}

const char* CLogDataTbl::TableName() 
{ 
	return "LogTable"; 
}

int CLogDataTbl::ItemCount() 
{ 
	return 11; 
}