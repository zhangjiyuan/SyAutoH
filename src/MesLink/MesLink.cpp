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

int CMesLink::Init()
{
	if (NULL == m_pMesServer)
	{
		m_pMesServer = new MesLinkServer();
		m_pMesServer->InitIce();
	}
	return 0;
}