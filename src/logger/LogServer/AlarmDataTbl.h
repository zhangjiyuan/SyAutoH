#pragma once
#include "SqliteTable.h"

class CAlarmDataTbl : public SQLiteTbl
{
public:
	CAlarmDataTbl(void);
	virtual ~CAlarmDataTbl(void);

public:
	virtual const char* TableName();
	virtual int ItemCount();

public:
	int m_nID;
	int m_nEventID;
	long long m_firstTime;
	long long m_lastTime;
	SQLiteString m_strMsg;
	int m_nCount;
};
