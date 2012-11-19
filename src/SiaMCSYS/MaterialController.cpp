#include "StdAfx.h"
#include "MaterialController.h"
#include "../shared/AMHSPacket.h"
#include "OptCodes.h"
#include "../shared/Log.h"

#include <iostream>
#include <string>

using namespace std;



MaterialController::MaterialController(void)
{
	sLog.Init(3);
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
	
	m_GuiHub.StartServer(&m_amhsDrive);
	m_amhsDrive.Init();
	


	return 0;
}


void MaterialController::Check(void)
{
	//m_amhsDrive.Run();
	//m_amhsDrive.SetOHTBackMessage(24, 200);
	//m_amhsDrive.Check();

	DR_OHT_LIST oht_list = m_amhsDrive.GetOhtList();
	string strOhtList = "";
	char buf[256] ="";
	for (DR_OHT_LIST::iterator it = oht_list.begin(); 
		it != oht_list.end(); ++it)
	{
		sprintf_s(buf, 256, "<%d, %d, %d>", it->nID, it->nPOS, it->nHand);
		strOhtList += buf;
	}
	m_GuiHub.SetData("OHT.Pos", strOhtList.c_str());
	
	
}


void MaterialController::PrintfInfo(void)
{
	Log.outBasic("Material Control System V1.0.0.1 \n\n\n");
	//LOG_BASIC("Material Control System V1.0.0.1 \n\n\n");
}
