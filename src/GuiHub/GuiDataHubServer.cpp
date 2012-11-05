#include "StdAfx.h"
#include "GuiDataHubServer.h"
#include "GuiDataHubI.h"

GuiDataHubServer::GuiDataHubServer(void)
	:
m_pGuiHub(NULL)
{
	Proxy("DataHub");
}


GuiDataHubServer::~GuiDataHubServer(void)
{
	EndIce();
}

void GuiDataHubServer::GetProxy()
{
	m_pGuiHub = new GuiDataHubI();
	//pManager->Init();
	m_objPtr = m_pGuiHub;
}

void GuiDataHubServer::UpdateData(const string& sTag, const string& sVal)
{
	if (NULL != m_pGuiHub)
	{
		m_pGuiHub->UpdateData(sTag, sVal);
	}
}

void GuiDataHubServer::SetDrive(CAMHSDrive* pDrive)
{
	if (NULL != m_pGuiHub)
	{
		m_pGuiHub->AMHSDrive(pDrive);
	}
}