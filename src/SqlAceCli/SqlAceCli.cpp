// SqlAceCli.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "SqlAceCli.h"
#include "SqlServerNCLI.h"

// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 SqlAceCli.h
CSqlAceCli::CSqlAceCli()
{
	m_pSqlClient = NULL;
}

CSqlAceCli::~CSqlAceCli()
{
	if (NULL != m_pSqlClient)
	{
		delete m_pSqlClient;
		m_pSqlClient = NULL;
	}
}

int CSqlAceCli::Connect(WCHAR* wServer, WCHAR* wDBName)
{
	if (NULL == m_pSqlClient)
	{
		m_pSqlClient = new SqlServerNCLI();
	}

	int nHR = m_pSqlClient->InitializeAndEstablishConnection(wServer, wDBName);
	if (0 == nHR)
	{
		nHR = m_pSqlClient->CreationSession();
	}
	return nHR;
}


int CSqlAceCli::ExecuteSQL(WCHAR* wSqlCmd)
{
	if (NULL != m_pSqlClient)
	{
		return m_pSqlClient->ExecuteSQL(wSqlCmd);
	}
	
	return -1;
}


int CSqlAceCli::PutOutRecordSet(void)
{
	if (NULL != m_pSqlClient)
	{
		return m_pSqlClient->TProcessRecordSet();
	}

	return -1;
}
