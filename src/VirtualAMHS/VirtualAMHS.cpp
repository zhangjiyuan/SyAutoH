// VirualAMHS.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "VirtualAMHS.h"
#include "VirtualOHT.h"
#include "VirtualStocker.h"
#include "../shared/Threading/Mutex.h"

// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 VirualAMHS.h
const int OHT_START_POS = 1000;


CVirtualAMHS::CVirtualAMHS()
{
	m_mapOHT = new MAP_VOHT();
	m_mapSTK = new MAP_VSTK();
	m_pOhtLock = new Mutex();
	return;
}

CVirtualAMHS::~CVirtualAMHS()
{
	MAP_VOHT::iterator it;
	m_pOhtLock->Acquire();
	it = m_mapOHT->begin();
	while(it != m_mapOHT->end())
	{
		delete it->second;
		++it;
	}
	delete m_mapOHT;
	m_mapOHT = NULL;
	m_pOhtLock->Release();

	MAP_VSTK::iterator it_stk;
	it_stk = m_mapSTK->begin();
	while(it_stk != m_mapSTK->end())
	{
		delete it_stk->second;
		++it_stk;
	}
	delete m_mapSTK;

	delete m_pOhtLock;
}

int CVirtualAMHS::Stocker_Auth(int nIndex, const char* sIP)
{
	MAP_VSTK::iterator it;
	it = m_mapSTK->find(nIndex);
	if (it != m_mapSTK->end())
	{
		VirtualStocker* stocker = it->second;
		if (stocker->Online() == false)
		{
			delete stocker;
			m_mapSTK->erase(it);
		}
		else
		{
			printf("Stocker %d already online. \n", stocker->DeviceID());
			return 0;
		}
	}

	VirtualStocker* stocker = new VirtualStocker();
	stocker->DeviceID(nIndex);
	stocker->Connect("127.0.0.1", 9999);
	stocker->Auth( sIP);
	(*m_mapSTK)[nIndex] = stocker;

	return 0;
}

int CVirtualAMHS::OHT_Auth(int nIndex, int nPos, int nHand)
{
	MAP_VOHT::iterator it;
	it = m_mapOHT->find(nIndex);
	if (it != m_mapOHT->end())
	{
		VirtualOHT* oht = it->second;
		if (oht->Online() == false)
		{
			delete oht;
			m_mapOHT->erase(it);
		}
		else
		{
			printf("OHT %d already online. \n", oht->DeviceID());
			return 0;
		}
	}

	m_pOhtLock->Acquire();
	VirtualOHT* oht = new VirtualOHT();
	oht->DeviceID(nIndex);
	oht->Connect("127.0.0.1", 9999);
	oht->Auth(nPos, nHand);
	(*m_mapOHT)[nIndex] = oht;
	m_pOhtLock->Release();

	return 0;
}

LIST_FOUP CVirtualAMHS::Stocker_GetFoupsStatus(int nStocker)
{
	LIST_FOUP list;
	return list;
}

LIST_OHT CVirtualAMHS::OHT_GetStatus()
{
	LIST_OHT list;
	m_pOhtLock->Acquire();
	for (MAP_VOHT::iterator it = m_mapOHT->begin(); 
		it != m_mapOHT->end(); ++it)
	{
		VirtualOHT *vOht = it->second;
		ItemOHT item;
		item.nID = vOht->DeviceID();
		if (vOht->Online() == true)
		{
			item.nOnline = 1;
		}
		item.nHandStatus = vOht->m_nHand;
		item.nPosition = vOht->m_nPos;
		list.push_back(item);
	}
	
	m_pOhtLock->Release();
	return list;
}

int CVirtualAMHS::STK_History(int nStocker)
{
	MAP_VSTK::iterator it;
	it = m_mapSTK->find(nStocker);
	if (it != m_mapSTK->end())
	{
		VirtualStocker* stocker = it->second;
		stocker->History();
	}
	return 0;
}

int CVirtualAMHS::Stocker_ManualInputFoup(int nStocker, const TCHAR* sFoupID)
{
	MAP_VSTK::iterator it;
	it = m_mapSTK->find(nStocker);
	if (it != m_mapSTK->end())
	{
		VirtualStocker* stocker = it->second;
		stocker->ManualInputFoup(sFoupID);
	}
	else
	{
		printf("Stocker %d is offline \n", nStocker);
		return -1;
	}

	return 0;
}

int CVirtualAMHS::Stocker_ManualOutputFoup(int nStocker, const TCHAR* sFoupID)
{
	MAP_VSTK::iterator it;
	it = m_mapSTK->find(nStocker);
	if (it != m_mapSTK->end())
	{
		VirtualStocker* stocker = it->second;
		stocker->ManualOutputFoup(sFoupID);
	}
	else
	{
		printf("Stocker %d is offline \n", nStocker);
		return -1;
	}
	return 0;
}