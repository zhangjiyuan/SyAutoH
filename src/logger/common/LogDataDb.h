#pragma once
#include "SqliteTable.h"

class CLogDataTbl : public SQLiteTbl
{
public:
	CLogDataTbl(void);
	virtual ~CLogDataTbl(void);

	virtual const char* TableName();
	virtual int ItemCount();
	
	int m_id;
	//SQLiteString m_strTime;
	long long m_llTime;
	int m_nType;
	int m_nEventID;
	SQLiteString m_strUnit;
	SQLiteString m_strMsg;
	SQLiteString m_strUser;

	int m_nParam1;
	int m_nParam2;
	double m_dParam1;
	double m_dparam2;
};
