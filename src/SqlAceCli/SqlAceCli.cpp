// SqlAceCli.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "SqlAceCli.h"
#include "SqlServerNCLI.h"
#include "DBFoup.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// 唯一的应用程序对象

CWinApp theApp;

using namespace std;

int _tmain(int argc, TCHAR* argv[], TCHAR* envp[])
{
	int nRetCode = 0;

	HMODULE hModule = ::GetModuleHandle(NULL);

	if (hModule != NULL)
	{
		// 初始化 MFC 并在失败时显示错误
		if (!AfxWinInit(hModule, NULL, ::GetCommandLine(), 0))
		{
			// TODO: 更改错误代码以符合您的需要
			_tprintf(_T("错误: MFC 初始化失败\n"));
			nRetCode = 1;
		}
		else
		{
			// TODO: 在此处为应用程序的行为编写代码。
		}
	}
	else
	{
		// TODO: 更改错误代码以符合您的需要
		_tprintf(_T("错误: GetModuleHandle 失败\n"));
		nRetCode = 1;
	}

	return nRetCode;
}

CSqlAceCli::CSqlAceCli()
{
	m_pSqlClient = NULL;
}

CSqlAceCli::~CSqlAceCli()
{
	Clean();
}

int CSqlAceCli::Connect(WCHAR* wServer, WCHAR* wDBName)
{
	if (NULL == m_pSqlClient)
	{
		m_pSqlClient = new SqlServerNCLI();
	}

	int nHR = m_pSqlClient->InitializeAndEstablishConnection(wServer, wDBName);

	//m_pSqlClient->TestMfcOleDB();

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
		//return m_pSqlClient->TProcessRecordSet();
	}

	return -1;
}


int CSqlAceCli::Clean(void)
{
	if (NULL != m_pSqlClient)
	{
		delete m_pSqlClient;
		m_pSqlClient = NULL;
	}

	return 0;
}


int CSqlAceCli::FindFoupLocation(WCHAR* sFoupID, int& nOHV, int& nStocker)
{
	nOHV = 0;
	nStocker = 0;

	CFoupCommander foupCmd;
	foupCmd.OpenDataSource();
	CString strFind = L"SELECT * From Foup where FoupID = '#@#'";
	strFind.Replace(L"#@#", sFoupID);
	HRESULT hr = foupCmd.Open(foupCmd.m_session, strFind);
	if (FAILED(hr))
	{
		cout << "Open Foup Failed." << endl;
		return -1;
	}

	if(foupCmd.MoveFirst() != DB_S_ENDOFROWSET)
	{
		//CString line;
		//line.Format(L"ID: %d | Lot: %s | OHV: %d | STOCKER: %d | Status: %s\r\n", 
		//	foupCmd.m_ID, foupCmd.m_Lot, foupCmd.m_OHV, 
		//	foupCmd.m_STOCKER, foupCmd.m_Status);
		//_tprintf(line);
		nOHV = foupCmd.m_OHV;
		nStocker = foupCmd.m_STOCKER;
	}

	foupCmd.CloseAll();

	return 0;
}
