#include "StdAfx.h"
#include "GuiDataHubServer.h"
#include "GuiDataHubI.h"

GuiDataHubServer::GuiDataHubServer(void)
{
	Proxy("DataHub");
}


GuiDataHubServer::~GuiDataHubServer(void)
{
	EndIce();
}

void GuiDataHubServer::GetProxy()
{
	GuiDataHubI* pManager = new GuiDataHubI();
	//pManager->Init();
	m_objPtr = pManager;
}