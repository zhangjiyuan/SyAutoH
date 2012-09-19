#include "StdAfx.h"
#include "UserManagementI.h"
#include "../SqlAceCli/SqlAceCli.h"
#include "IceUtil/Unicode.h"
#include "Ice/Connection.h"
#include "iGuiHub.h"

UserManagementI::UserManagementI(void)
{
	cout<<"User Management Server is Ready." << endl;
	m_pUserDB = NULL;
	m_pSession = NULL;
}


UserManagementI::~UserManagementI(void)
{
	if (NULL != m_pUserDB)
	{
		delete m_pUserDB;
		m_pUserDB = NULL;
	}
	if (NULL != m_pSession)
	{
		delete m_pSession;
		m_pSession = NULL;
	}
}

int UserManagementI::Init()
{
	if (NULL == m_pUserDB)
	{
		m_pUserDB = new DBUserAce();
	}
	if (NULL == m_pSession)
	{
		m_pSession = new DBSession();
	}

	return 0;
}

int UserManagementI::Login(const ::std::string& sUser, const ::std::string& sHash, const ::Ice::Current& c/* = ::Ice::Current */)
{
	int nLinkSession = 0;
	string strCon = "";
	if(c.con)
	{
		strCon =  c.con->toString();
	}

	//cout<< strCon <<endl;

	int nRet = m_pUserDB->Login(sUser, sHash);
	if (0 == nRet)
	{
		UserData user;
		user = m_pUserDB->GetUserDatabyName(sUser);
		nLinkSession = m_pSession->GetLoginSession(user.nID, user.nRight, strCon, false);
		cout<< "Login Sucess:  -> User: " << sUser << " session: " << nLinkSession << endl;
	}
	else
	{
		cout<< "Login Failed:  -> User: " << sUser << endl;
		nLinkSession = 0;
	}

	return nLinkSession;
}
int UserManagementI::Logout(::Ice::Int nSession, const ::Ice::Current& /* = ::Ice::Current */)
{
	m_pSession->LoginOut(nSession);

	return 0;
}

int UserManagementI::CreateUser(const ::std::string& sName, 
	const ::std::string& sPassWord, ::Ice::Int nRight, ::Ice::Int nSession, const ::Ice::Current& /* = ::Ice::Current */)
{
	int nRet = 0;
	nRet = m_pUserDB->CreateUser(sName, sPassWord, nRight);
	return nRet;
}
int UserManagementI::DeleteUser(::Ice::Int nUID, ::Ice::Int nSession, const ::Ice::Current& /* = ::Ice::Current */)
{
	int nRole = 0;
	nRole = m_pSession->GetRealRight(nSession);
	if (nRole < 4)
	{
		return -5;
	}
	int nRet = 0;
	nRet = m_pUserDB->DeleteUser(nUID);
	return nRet;
}
int UserManagementI::SetUserPW(::Ice::Int nUID, 
	const ::std::string& strPW, ::Ice::Int nSession, const ::Ice::Current&)
{
	int nRet = 0;
	nRet = m_pUserDB->SetUserPW(nUID, strPW);
	return nRet;
}
int UserManagementI::SetUserRight(::Ice::Int nUID, 
	::Ice::Int nRight, ::Ice::Int nSession, const ::Ice::Current& /* = ::Ice::Current */)
{
	int nRole = 0;
	nRole = m_pSession->GetRealRight(nSession);
	if (nRole < 4)
	{
		return -5;
	}
	int nRet = 0;
	nRet = m_pUserDB->SetUserRight(nUID, nRight);
	return nRet;
}
int UserManagementI::GetUserCount(::Ice::Int nSession, const ::Ice::Current&)
{
	int nCount = 0;
	nCount = m_pUserDB->GetUserCount();
	return nCount;
}
UserList UserManagementI::GetUserList(::Ice::Int nStart, ::Ice::Int nCount, 
	::Ice::Int nSession, const ::Ice::Current&)
{
	UserList list;
	UserDataList uList;
	uList = m_pUserDB->GetUserList(nStart, nCount);
	size_t szCount = uList.size();
	UserDataList::iterator itUserList = uList.begin();
	while(itUserList != uList.end())
	{
		MCS::User mcsUser;
		mcsUser.nID = itUserList->nID;
		mcsUser.nRight = itUserList->nRight;
		string sName = IceUtil::wstringToString(itUserList->strName);
		mcsUser.sName = sName;
		list.push_back(mcsUser);
		++itUserList;
	}

	return list;
}