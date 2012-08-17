#include "StdAfx.h"
#include "MaterialController.h"
#include "../MesLink/MesLink.h"

MaterialController::MaterialController(void)
{
	m_pMesLink = NULL;
}


MaterialController::~MaterialController(void)
{
	if (NULL != m_pMesLink)
	{
		delete m_pMesLink;
		m_pMesLink = NULL;
	}
}


int MaterialController::Init(void)
{
	if (NULL == m_pMesLink)
	{
		m_pMesLink = new CMesLink();
		m_pMesLink->Init();
	}
	return 0;
}


void MaterialController::Run(void)
{
}
