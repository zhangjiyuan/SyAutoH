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
	CSqlAceCli* m_pSqlcli;

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
		m_pSqlcli->FindFoupLocation(strMsg, nOHT, nStocker);
		cout<< "Find Foup:" << nOHT << " Stocker:" << nStocker << endl;

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
	m_pSqlAce = NULL;
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

	if (NULL != m_pSqlAce)
	{
		delete m_pSqlAce;
		m_pSqlAce = NULL;
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
	if (NULL == m_pSqlAce)
	{
		m_pSqlAce = new CSqlAceCli();
		//m_pSqlAce->Connect(L"SDNY-PC\\AMHS", L"MCS");
	}

	if (NULL == m_pMesLink)
	{
		m_pMesLink = new CMesLink();
		source = new CSource();
		receiver = new CReceiver();
		receiver->m_pSqlcli = m_pSqlAce;
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
