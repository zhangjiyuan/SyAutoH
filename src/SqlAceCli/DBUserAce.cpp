#include "StdAfx.h"
#include "SqlAceCli.h"
#include "McsUserCommander.h"
#include "../CypAce/CypAce.h"

DBUserAce::DBUserAce(void)
{
	
}


DBUserAce::~DBUserAce(void)
{
	
}

int DBUserAce::Login(const ::std::string& sName, const ::std::string& sHash)
{
	return 0;
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
	CMcsUserCommander dbUser;

	hr = dbUser.OpenDataSource();
	if (FAILED(hr))
	{
		return 2;
	}
	CString strFind = L"Select Name from mcsuser where Name = '#@#'";
	strFind.Replace(L"#@#", strName);
	hr = dbUser.Open(dbUser.m_session, strFind);
	if (FAILED(hr))
	{
		return 2;
	}
	if (dbUser.MoveNext() != DB_S_ENDOFROWSET )
	{
		dbUser.CloseAll();
		return 3;
	}
	dbUser.CloseAll();


	hr = dbUser.OpenAll();
	if (FAILED(hr))
	{
		return 2;
	}

	wcscpy_s(dbUser.m_Name, strName);
	dbUser.m_dwNameLength = strName.GetLength()*2;
	wcscpy_s(dbUser.m_Password, strUserHash);
	dbUser.m_dwPasswordLength = strUserHash.GetLength()*2;
	dbUser.m_UserRight = 3;
	dbUser.m_dwidStatus = DBSTATUS_S_IGNORE;
	dbUser.m_dwNameStatus = DBSTATUS_S_OK;
	dbUser.m_dwPasswordStatus = DBSTATUS_S_OK;
	dbUser.m_dwUserRightStatus = DBSTATUS_S_OK;
	hr = dbUser.Insert();
	if (FAILED(hr))
	{
		nRet = 1;
	}
	else
	{
		dbUser.UpdateAll();
	}
	
	dbUser.CloseAll();
	CoUninitialize();

	return nRet;
}
int DBUserAce::DeleteUser(int, int)
{
	return 0;
}
int DBUserAce::SetUserPW(int, const ::std::string&, int)
{
	return 0;
}
int DBUserAce::SetUserRight(int, int, int)
{
	return 0;
}
int DBUserAce::GetUserCount()
{
	return 0;
}
strList DBUserAce::GetUserList(int, int)
{
	strList list;
	return list;
}