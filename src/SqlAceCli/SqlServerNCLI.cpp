#include "StdAfx.h"
#include "SqlServerNCLI.h"
#include "DBUser.h"
#include "UserCommand.h"
#include "UserA.h"

SqlServerNCLI::SqlServerNCLI(void)
{

}


SqlServerNCLI::~SqlServerNCLI(void)
{
	CoUninitialize();
}


int SqlServerNCLI::InitializeAndEstablishConnection(WCHAR* wsServer, WCHAR* wsDataBase)
{
	CoInitialize(NULL);

	/*HRESULT hr;
	CString strConnection = L"Provider=SQLNCLI10;"
		L"Server=#S#;Database=#DB#;Trusted_Connection=yes";
	strConnection.Replace(L"#S#", wsServer);
	strConnection.Replace(L"#DB#", wsDataBase);

	hr = ds.OpenFromInitializationString(strConnection);

	if (FAILED(hr))
	{
		cout<< "CDataSource open failed." << endl;
		return -1;
	}
	sn.Open(ds);*/

	return 0;
}


int SqlServerNCLI::ReleaseResource(void)
{
	return 0;
}


int SqlServerNCLI::ExecuteSQL(WCHAR* sSQLCMD)
{
	return 0;
}

int SqlServerNCLI::TestMfcOleDB(void)
{
	//CTables tbs;
	//tbs.Open(sn);

	//while(tbs.MoveNext() == S_OK)
	//{
	//	printf("%ls: %ls \r\n", tbs.m_szType, tbs.m_szName);
	////}
	HRESULT hr;
	CUserA dbUser;
	hr = dbUser.OpenAll();
	while(dbUser.MoveNext() != DB_S_ENDOFROWSET)
	{
		CString line;
		line.Format(L"ID: %d | Name: %s | PW: %s | Right: %d \r\n", dbUser.m_id,
			dbUser.m_Name, dbUser.m_Password, dbUser.m_UserRight);
		_tprintf(line);
		//dbUser.m_UserRight++;
		//dbUser.SetData();
	}
	

	dbUser.MoveLast();
	//++dbUser.m_id;
	//memset(dbUser.m_Name, 0, dbUser.m_dwNameLength);
	//_tcscpy_s(dbUser.m_Name, dbUser.m_dwNameLength, _T("Insert"));
	wcscpy_s(dbUser.m_Name, L"HLOOInsert");
	//dbUser.m_dwidLength = 7;
	wcscpy_s(dbUser.m_Password, L"InsertP");
	//dbUser.m_dwPasswordLength = 8;
	dbUser.m_UserRight = 3;
	dbUser.m_dwidStatus = DBSTATUS_S_IGNORE;
	dbUser.m_dwNameStatus = DBSTATUS_S_OK;
	dbUser.m_dwPasswordStatus = DBSTATUS_S_OK;
	dbUser.m_dwUserRightStatus = DBSTATUS_S_OK;
	hr = dbUser.Insert();
	DWORD dwError = GetLastError();
	
	//dbUser.SetData();
	dbUser.UpdateAll();
	//dbUser.CloseAll();

	/*CUserCommand uc;
	hr = uc.OpenAll();
	while(uc.MoveNext() != DB_S_ENDOFROWSET)
	{
	CString line;
	line.Format(L"ID: %d Name: %s PW: %s Right: %d \r\n", uc.m_id,
	uc.m_Name, uc.m_Password, uc.m_UserRight);
	_tprintf(line);	
	}

	wcscpy_s(uc.m_Name, L"Hello");
	wcscpy_s(uc.m_Password, L"dde");
	uc.m_UserRight = 4;
	uc.m_dwidStatus = DBSTATUS_S_OK;
	uc.m_dwNameStatus = DBSTATUS_S_OK;
	uc.m_dwPasswordStatus =DBSTATUS_S_OK;
	uc.m_dwUserRightStatus = DBSTATUS_S_OK;
	hr = uc.Insert();

	uc.SetData();
	uc.Update();

	uc.CloseAll();*/
	//uc.SetData();
	//uc.UpdateAll();
	
	return 0;
}
