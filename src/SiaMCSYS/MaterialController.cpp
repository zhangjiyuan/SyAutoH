#include "StdAfx.h"
#include "MaterialController.h"
#include "../shared/AMHSPacket.h"
#include "OptCodes.h"

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



	m_GuiHub.StartServer();
	m_amhsDrive.Init();
	
	return 0;
}


void MaterialController::Check(void)
{
	//m_amhsDrive.Run();
	//m_amhsDrive.SetOHTBackMessage(24, 200);
	//m_amhsDrive.Check();

	AMHSPacket* Packet = m_amhsDrive.GetMsgPacket();
	if (NULL != Packet)
	{
		int mOpcode = Packet->GetOpcode();
		switch(mOpcode)
		{
		case OHT_POSITION:
			{
				uint8		ohtID = 0;
				uint16		ohtPosition = 0;
				*Packet >> ohtID;
				*Packet >> ohtPosition;
				//printf("OHT POS  ---> id: %d, pos: %d\n", ohtID, ohtPosition);
				char buf[256] = "";
				sprintf_s(buf, 256, "%d,%d", ohtID, ohtPosition);
				m_GuiHub.SetData("OHT.POS", buf);
			}
			break;
		}
		delete Packet;
	}

	
	
}


void MaterialController::PrintfInfo(void)
{
	cout<< "Material Control System V1.0.0.1 \n\n\n" << endl;
}
