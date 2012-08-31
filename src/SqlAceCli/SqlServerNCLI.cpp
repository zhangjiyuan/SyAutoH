#include "StdAfx.h"
#include "SqlServerNCLI.h"

#include "FoupCommander.h"
#include "McsUserCommander.h"

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
	CString strConnection = L"Provider=SQLNCLI10.1;"
		L"Server=#S#;Database=#DB#;Integrated Security=SSPI";
	strConnection.Replace(L"#S#", wsServer);
	strConnection.Replace(L"#DB#", wsDataBase);

	CDataSource _db;
	hr = _db.OpenFromInitializationString(strConnection);

	if (FAILED(hr))
	{
		cout<< "CDataSource open failed." << endl;
		return -1;
	}
	sn.Open(_db);*/

	/*CDataSource _db;
	HRESULT hr;
	hr = _db.OpenFromInitializationString(L"Provider=SQLNCLI10.1;Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=MCS;Data Source=SDNY-PC\\AMHS;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=SDNY-PC;Initial File Name=\"\";Use Encryption for Data=False;Tag with column collation when possible=False;MARS Connection=False;DataTypeCompatibility=0;Trust Server Certificate=False");
	if (FAILED(hr))
	{
#ifdef _DEBUG
		AtlTraceErrorRecords(hr);
#endif
		return hr;
	}
	return m_session.Open(_db);*/

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
	HRESULT hr;
	CMcsUserCommander dbUser;
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
	
	/*CString strName = L"HLOOInsertaaaaaa";
	dbUser.MoveLast();
	wcscpy_s(dbUser.m_Name, strName);
	dbUser.m_dwNameLength = strName.GetLength()*2;
	wcscpy_s(dbUser.m_Password, L"InsertP");
	dbUser.m_UserRight = 3;
	dbUser.m_dwidStatus = DBSTATUS_S_IGNORE;
	dbUser.m_dwNameStatus = DBSTATUS_S_OK;
	dbUser.m_dwPasswordStatus = DBSTATUS_S_OK;
	dbUser.m_dwUserRightStatus = DBSTATUS_S_OK;
	hr = dbUser.Insert();
	dbUser.UpdateAll();*/
	dbUser.CloseAll();

	// query by select
	dbUser.OpenDataSource();
	hr = dbUser.Open(dbUser.m_session, "Select * from mcsuser where id = 12");
	while(dbUser.MoveNext() != DB_S_ENDOFROWSET)
	{
		CString line;
		line.Format(L"ID: %d | Name: %s | PW: %s | Right: %d \r\n", dbUser.m_id,
			dbUser.m_Name, dbUser.m_Password, dbUser.m_UserRight);
		_tprintf(line);
	}
	dbUser.CloseAll();

	CFoupCommander foupCmd;
	foupCmd.OpenAll();
	CString strLot = L"Intel core i5 2400k";
	CString strStatus = L"Process";
	wcscpy_s(foupCmd.m_Lot, strLot);
	foupCmd.m_dwLotLength = strLot.GetLength()*2;
	wcscpy_s(foupCmd.m_Status, strStatus);
	foupCmd.m_dwStatusLength = strStatus.GetLength()*2;
	foupCmd.m_OHV = 23;
	foupCmd.m_STOCKER = 0;
	foupCmd.m_dwIDStatus = DBSTATUS_S_IGNORE;
	foupCmd.m_dwLotStatus = DBSTATUS_S_OK;
	foupCmd.m_dwOHVStatus = DBSTATUS_S_OK;
	foupCmd.m_dwSTOCKERStatus = DBSTATUS_S_OK;
	foupCmd.m_dwStatusStatus = DBSTATUS_S_OK;
	//hr = foupCmd.Insert();
	foupCmd.Update();

	while(foupCmd.MoveNext() != DB_S_ENDOFROWSET)
	{
		CString line;
		line.Format(L"ID: %d | Lot: %s | OHV: %d | STOCKER: %d | Status: %s\r\n", 
			foupCmd.m_ID, foupCmd.m_Lot, foupCmd.m_OHV, 
			foupCmd.m_STOCKER, foupCmd.m_Status);
		_tprintf(line);
	}

	foupCmd.CloseAll();
	
	
	return 0;
}
