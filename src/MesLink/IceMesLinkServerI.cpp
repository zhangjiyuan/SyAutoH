#include "StdAfx.h"
#include "IceMesLinkServerI.h"
#include "IceMesLinkI.h"

MesLinkServer::MesLinkServer(void)
{
	Proxy("MESLink");
}


MesLinkServer::~MesLinkServer(void)
{
	EndIce();
}

void MesLinkServer::GetProxy()
{
	IceMesLinkI* pManager = new IceMesLinkI();
	pManager->SetSource(m_pSource);
	m_objPtr = pManager;
}