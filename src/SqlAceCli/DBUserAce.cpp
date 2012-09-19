#include "StdAfx.h"
#include "SqlAceCli.h"
#include "TMcsUser.h"
#include "../CypAce/CypAce.h"
#include "DBConst.h"

DBUserAce::DBUserAce(void)
{
	
}


DBUserAce::~DBUserAce(void)
{
	
}

int DBUserAce::Login(const ::std::string& sName, const ::std::string& sHash)
{
	int nLoginStatus = DBO_LOGIN_FAILED;
	CString strName;
	CString strHash;
	strName = sName.c_str();
	strHash = sHash.c_str();

	CoInitialize(NULL);
	HRESULT hr;
	CMcsUserTable dbUser;

	hr = dbUser.OpenDataSource();
	if (FAILED(hr))
	{
		CoUninitialize();
		return nLoginStatus;
	}

	CString strSQL;
	strSQL.Format(L"Select * from mcsuser where (Name = '%s') AND (Password = '%s')", 
		strName, strHash);
	hr = dbUser.Open(dbUser.m_session, strSQL);
	if (FAILED(hr))
	{
		CoUninitialize();
		return nLoginStatus;
	}
	if (dbUser.MoveFirst() != DB_S_ENDOFROWSET)
	{
		nLoginStatus = DBO_SUCCESS;
	}
	else
	{
		nLoginStatus = DBO_LOGIN_FAILED;
	}

	dbUser.CloseAll();
	CoUninitialize();
	return nLoginStatus;
}
int DBUserAce::Logout(int)
{
	return 0;
}
int DBUserAce::CreateUser(const ::std::string& sName, 
	const ::std::string& sPassWord, int nRight)
{
	int nRet = 0;
	CString strUserHash;
	CString strName;
	strName = sName.c_str();
	CString strPassWord;
	strPassWord = sPassWord.c_str();
	strUserHash = CypHashUserInfo(strName, strPassWord);

	CoInitialize(NULL);
	HRESULT hr;
	CMcsUserTable dbUser;

	hr = dbUser.OpenDataSource();
	if (FAILED(hr))
	{
		CoUninitialize();
		return 2;
	}
	CString strFind = L"Select Name from mcsuser where Name = '#@#'";
	strFind.Replace(L"#@#", strName);
	hr = dbUser.Open(dbUser.m_session, strFind);
	if (FAILED(hr))
	{
		CoUninitialize();
		return 2;
	}
	if (dbUser.MoveNext() != DB_S_ENDOFROWSET )
	{
		dbUser.CloseAll();
		CoUninitialize();
		return 3;
	}
	dbUser.CloseAll();


	hr = dbUser.OpenAll();
	if (FAILED(hr))
	{
		CoUninitialize();
		return 2;
	}

	wcscpy_s(dbUser.m_Name, strName);
	dbUser.m_dwNameLength = strName.GetLength()*2;
	wcscpy_s(dbUser.m_Password, strUserHash);
	dbUser.m_dwPasswordLength = strUserHash.GetLength()*2;
	dbUser.m_UserRight = nRight;
	dbUser.m_dwidStatus = DBSTATUS_S_IGNORE;
	dbUser.m_dwNameStatus = DBSTATUS_S_OK;
	dbUser.m_dwPasswordStatus = DBSTATUS_S_OK;
	dbUser.m_dwUserRightStatus = DBSTATUS_S_OK;
	hr = dbUser.Insert();
	if (FAILED(hr))
	{
		nRet = 1;
	}
	
	dbUser.CloseAll();
	CoUninitialize();

	return nRet;
}
int DBUserAce::DeleteUser(int nID)
{
	CoInitialize(NULL);
	HRESULT hr;
	CMcsUserTable dbUser;

	hr = dbUser.OpenDataSource();
	if (FAILED(hr))
	{
		CoUninitialize();
		return -1;
	}
	CDBPropSet propset(DBPROPSET_ROWSET);
	dbUser.GetRowsetProperties(&propset);

	CString strSQL;
	strSQL.Format(L"Select * from mcsuser where (id = %d)", nID);
	hr = dbUser.Open(dbUser.m_session, strSQL, &propset);
	if (FAILED(hr))
	{
		CoUninitialize();
		return -1;
	}

	while (dbUser.MoveNext() != DB_S_ENDOFROWSET)
	{
		if (nID == dbUser.m_id)
		{
			hr = dbUser.Delete();
		}		
	}

	dbUser.UpdateAll();
	dbUser.CloseAll();
	CoUninitialize();
	return 0;
}
int DBUserAce::SetUserPW(int nID, const ::std::string& sPassWord)
{
	CoInitialize(NULL);
	HRESULT hr;
	CMcsUserTable dbUser;

	hr = dbUser.OpenDataSource();
	if (FAILED(hr))
	{
		CoUninitialize();
		return -1;
	}
	CDBPropSet propset(DBPROPSET_ROWSET);
	dbUser.GetRowsetProperties(&propset);

	CString strSQL;
	strSQL.Format(L"Select * from mcsuser where (id = %d)", nID);
	hr = dbUser.Open(dbUser.m_session, strSQL, &propset);
	if (FAILED(hr))
	{
		CoUninitialize();
		return -1;
	}
	if (dbUser.MoveFirst() != DB_S_ENDOFROWSET)
	{
		dbUser.m_dwidStatus = DBSTATUS_S_IGNORE;
		CString strPassWord;
		CString strName = dbUser.m_Name;
		strPassWord = sPassWord.c_str();
		CString strUserHash = CypHashUserInfo(strName, strPassWord);
		wcscpy_s(dbUser.m_Password, strUserHash);
		hr = dbUser.SetData();
	}

	dbUser.CloseAll();
	CoUninitialize();
	return 0;
}

int DBUserAce::SetUserRight(int nID, int nRight)
{
	CoInitialize(NULL);
	HRESULT hr;
	CMcsUserTable dbUser;

	hr = dbUser.OpenDataSource();
	if (FAILED(hr))
	{
		CoUninitialize();
		return -1;
	}
	CDBPropSet propset(DBPROPSET_ROWSET);
	dbUser.GetRowsetProperties(&propset);

	CString strSQL;
	strSQL.Format(L"Select * from mcsuser where (id = %d)", nID);
	hr = dbUser.Open(dbUser.m_session, strSQL, &propset);
	if (FAILED(hr))
	{
		CoUninitialize();
		return -1;
	}
	if (dbUser.MoveFirst() != DB_S_ENDOFROWSET)
	{
		dbUser.m_UserRight = nRight;
		dbUser.m_dwidStatus = DBSTATUS_S_IGNORE;
		hr = dbUser.SetData();
	}

	dbUser.CloseAll();
	CoUninitialize();

	return 0;
}

int DBUserAce::GetUserCount()
{
	CoInitialize(NULL);
	HRESULT hr;
	CMcsUserTable dbUser;

	hr = dbUser.OpenAll();
	if (FAILED(hr))
	{
		CoUninitialize();
		return 2;
	}
	int nCount = 0;
	while (dbUser.MoveNext() != DB_S_ENDOFROWSET )
	{
		nCount++;
	}

	dbUser.CloseAll();
	CoUninitialize();

	return nCount;
}

UserData DBUserAce::GetUserDatabyName(const ::std::string& sName)
{
	UserData user;
	user.nID = 0;

	CoInitialize(NULL);
	HRESULT hr;
	CMcsUserTable dbUser;

	hr = dbUser.OpenDataSource();
	if (FAILED(hr))
	{
		CoUninitialize();
		return user;
	}

	CString strName;
	strName = sName.c_str();
	CString strSQL;
	strSQL.Format(L"Select * from mcsuser where (Name = '%s')", 
		strName);
	hr = dbUser.Open(dbUser.m_session, strSQL);
	if (FAILED(hr))
	{
		CoUninitialize();
		return user;
	}
	if (dbUser.MoveFirst() != DB_S_ENDOFROWSET)
	{
		user.nID = dbUser.m_id;
		user.strName = dbUser.m_Name;
		user.nRight = dbUser.m_UserRight;
	}

	dbUser.CloseAll();
	CoUninitialize();

	return user;
}
UserData DBUserAce::GetUserDatabyID(int nUserID)
{
	UserData user;
	user.nID = 0;

	CoInitialize(NULL);
	HRESULT hr;
	CMcsUserTable dbUser;

	hr = dbUser.OpenDataSource();
	if (FAILED(hr))
	{
		CoUninitialize();
		return user;
	}

	CString strSQL;
	strSQL.Format(L"Select * from mcsuser where (ID = %d)", 
		nUserID);
	hr = dbUser.Open(dbUser.m_session, strSQL);
	if (FAILED(hr))
	{
		CoUninitialize();
		return user;
	}
	if (dbUser.MoveFirst() != DB_S_ENDOFROWSET)
	{
		user.nID = dbUser.m_id;
		user.strName = dbUser.m_Name;
		user.nRight = dbUser.m_UserRight;
	}

	dbUser.CloseAll();
	CoUninitialize();

	return user;
}

UserDataList DBUserAce::GetUserList(int nStartID, int nCount)
{
	UserDataList list;
	CoInitialize(NULL);
	HRESULT hr;
	CMcsUserTable dbUser;

	hr = dbUser.OpenDataSource();
	if (FAILED(hr))
	{
		CoUninitialize();
		return list;
	}
	
	CString strSQL;
	strSQL.Format(L"Select TOP(%d) * from mcsuser where (id > %d)", nCount, nStartID );
	hr = dbUser.Open(dbUser.m_session, strSQL);
	if (FAILED(hr))
	{
		CoUninitialize();
		return list;
	}

	while (dbUser.MoveNext() != DB_S_ENDOFROWSET )
	{
		UserData anUser;
		anUser.nID = dbUser.m_id;
		anUser.strName = dbUser.m_Name;
		anUser.nRight = dbUser.m_UserRight;
		list.push_back(anUser);
	}
	dbUser.CloseAll();
	CoUninitialize();

	return list;
}