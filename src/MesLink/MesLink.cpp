// MesLink.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "MesLink.h"
#include "IceMesLinkServerI.h"
// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 MesLink.h
CMesLink::CMesLink()
{
	m_pMesServer = NULL;
	return;
}

CMesLink::~CMesLink()
{
	if (NULL != m_pMesServer)
	{
		delete m_pMesServer;
		m_pMesServer = NULL;
	}
}

int CMesLink::Init(MesMsgSource* pSrc)
{
	if (NULL == m_pMesServer)
	{
		m_pMesServer = new MesLinkServer();
		m_pMesServer->Source(pSrc);
		m_pMesServer->InitIce();
	}
	return 0;
}

int CMesLink::GetMesData(CMesData& data)
{

	return 0;
}