// GuiHub.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "GuiHub.h"
#include "UserManagementServer.h"

// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 GuiHub.h
CGuiHub::CGuiHub()
{
	m_pUserMgt = NULL;
	return;
}
CGuiHub::~CGuiHub()
{
	if (NULL != m_pUserMgt)
	{
		delete m_pUserMgt;
		m_pUserMgt = NULL;
	}
}

int CGuiHub::StartUserManagement()
{
	if (NULL == m_pUserMgt)
	{
		m_pUserMgt = new UserManagementServer();
		m_pUserMgt->InitIce();
	}

	return 0;
}