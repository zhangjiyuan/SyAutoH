#include "StdAfx.h"
#include "MaterialController.h"

#include <iostream>
#include <string>

using namespace std;



MaterialController::MaterialController(void)
{

}

MaterialController::~MaterialController(void)
{
	m_MesReciver.unhookEvent(&m_MesSource);
}


int MaterialController::Init(void)
{

	m_MesReciver.m_pFoupDB = &m_FoupDB;
		

	m_MesLink.Init(&m_MesSource);
	m_MesReciver.hookEvent(&m_MesSource);



	m_GuiHub.StartUserManagement();
	m_amhsDrive.Init();
	
	return 0;
}


void MaterialController::Check(void)
{
	//m_amhsDrive.Run();
	m_amhsDrive.SetOHTBackMessage(24, 200);
	m_amhsDrive.Check();
}


void MaterialController::PrintfInfo(void)
{
	cout<< "Material Control System V1.0.0.1 \n\n\n" << endl;
}
