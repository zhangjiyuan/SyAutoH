#include "StdAfx.h"
#include "MaterialController.h"
#include "../MesLink/MesLink.h"
#include "../SqlAceCli/SqlAceCli.h"
#include "../GuiHub/GuiHub.h"
#include <iostream>
#include <string>

using namespace std;

[event_receiver(native)]
class CReceiver 
{
public:
	DBFoup* m_pFoupDB;

	void MyHandler1(int nValue) 
	{
		printf("MyHandler1 was called with value %d.\n", nValue);
	}

	void MyHandler2(int nValue)
	{
		printf("MyHandler2 was called with value %d.\n", nValue);
	}

	void MyHanderS(WCHAR* strMsg, int nV)
	{
		wprintf_s(L"MyHandlerS was called with value %s %d.\n", strMsg, nV);
		int nOHT = 0;
		int nStocker = 0;
		int nFoup = m_pFoupDB->FindFoup(strMsg);
		wstring wstrMsg;
		wstrMsg = strMsg;
		if (nFoup > 0)
		{
			int nLocal = 0;
			int nType = 0;
			m_pFoupDB->GetFoupLocation(nFoup, nLocal, nType);
			wprintf_s(L"Find Foup: %s at Location: %d Type: %d.\n", 
				strMsg, nLocal, nType);
		}
		else
		{
			wprintf_s(L"Can not Fine Foup %s.\n", strMsg);
		}

	}

	void hookEvent(CSource* pSource) 
	{
		__hook(&CSource::MyEvent, pSource, &CReceiver::MyHandler1);
		__hook(&CSource::MyEvent, pSource, &CReceiver::MyHandler2);
		__hook(&CSource::MyEventS, pSource, &CReceiver::MyHanderS);
	}

	void unhookEvent(CSource* pSource) 
	{
		__unhook(&CSource::MyEvent, pSource, &CReceiver::MyHandler1);
		__unhook(&CSource::MyEvent, pSource, &CReceiver::MyHandler2);
		__unhook(&CSource::MyEventS, pSource, &CReceiver::MyHanderS);
	}
};

MaterialController::MaterialController(void)
{
	m_pMesLink = NULL;
	m_pFoupDB = NULL;
	m_pGuiHub =NULL;
}


MaterialController::~MaterialController(void)
{
	if (NULL != m_pMesLink)
	{
		delete m_pMesLink;
		m_pMesLink = NULL;

		receiver->unhookEvent(source);
	}

	if (NULL != m_pFoupDB)
	{
		delete m_pFoupDB;
		m_pFoupDB = NULL;
	}

	if (NULL != m_pGuiHub)
	{
		delete m_pGuiHub;
		m_pGuiHub = NULL;
	}

	delete receiver;
	delete source;
}


int MaterialController::Init(void)
{
	if (NULL == m_pFoupDB)
	{
		m_pFoupDB = new DBFoup();
		//m_pSqlAce->Connect(L"SDNY-PC\\AMHS", L"MCS");
	}

	if (NULL == m_pMesLink)
	{
		m_pMesLink = new CMesLink();
		source = new CSource();
		receiver = new CReceiver();
		receiver->m_pFoupDB = m_pFoupDB;
		//receiver->MyHanderS(L"45", 0);

		m_pMesLink->Init(source);
		receiver->hookEvent(source);
	}

	if (NULL == m_pGuiHub)
	{
		m_pGuiHub = new CGuiHub();
		m_pGuiHub->StartUserManagement();
	}
	return 0;
}


void MaterialController::Run(void)
{
	//while(1)
	//{
	//	CMesData data;
	//	m_pMesLink->GetMesData(data);
	//}
	//CReceiver receiver;
	//CSource source;

	//receiver.hookEvent(&source);
}
