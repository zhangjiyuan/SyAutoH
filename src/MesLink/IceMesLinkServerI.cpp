#include "StdAfx.h"
#include "IceMesLinkServerI.h"
#include "IceMesLinkI.h"

MesLinkServer::MesLinkServer(void)
{
	Proxy("MESLink");
}


MesLinkServer::~MesLinkServer(void)
{
}

void MesLinkServer::GetProxy()
{
	IceMesLinkI* pManager = new IceMesLinkI();
	m_objPtr = pManager;
}