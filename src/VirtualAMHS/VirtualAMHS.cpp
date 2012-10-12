// VirualAMHS.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "VirtualAMHS.h"
#include "VirtualOHT.h"
#include "VirtualStocker.h"

// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 VirualAMHS.h


CVirtualAMHS::CVirtualAMHS()
{
	m_mapOHT = new MAP_OHT();
	m_mapSTK = new MAP_STK();
	return;
}

CVirtualAMHS::~CVirtualAMHS()
{
	MAP_OHT::iterator it;
	it = m_mapOHT->begin();
	while(it != m_mapOHT->end())
	{
		delete it->second;
		++it;
	}
	delete m_mapOHT;

	MAP_STK::iterator it_stk;
	it_stk = m_mapSTK->begin();
	while(it_stk != m_mapSTK->end())
	{
		delete it_stk->second;
		++it_stk;
	}
	delete m_mapSTK;
}

int CVirtualAMHS::AddStocker(int nIndex, const char* sIP)
{
	MAP_STK::iterator it;
	it = m_mapSTK->find(nIndex);
	if (it != m_mapSTK->end())
	{
		VirtualStocker* stocker = it->second;
		stocker->Auth( sIP);
	}
	else
	{
		VirtualStocker* stocker = new VirtualStocker();
		stocker->ID(nIndex);
		stocker->Connect("127.0.0.1", 9999);
		stocker->Auth( sIP);
		(*m_mapSTK)[nIndex] = stocker;
	}
	return 0;
}

int CVirtualAMHS::AddOHT(int nIndex)
{
	MAP_OHT::iterator it;
	it = m_mapOHT->find(nIndex);
	if (it != m_mapOHT->end())
	{
		VirtualOHT* oht = it->second;
		oht->Auth(2001, 0);
	}
	else
	{
		VirtualOHT* oht = new VirtualOHT();
		oht->ID(nIndex);

		oht->Connect("127.0.0.1", 9999);
		oht->Auth(1001, 1);
		(*m_mapOHT)[nIndex] = oht;
	}
	

	return 0;
}
