// AMHSDrive.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"

#include "Common.h"
#include "../shared/Network.h"
#include "AMHS_Server.h"
#include "AMHSDrive.h"

#include "AMHSPacket.h"
#include "AMHSSocket.h"


// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 AMHSDrive.h
CAMHSDrive::CAMHSDrive()
{
	
}

CAMHSDrive::~CAMHSDrive()
{
	Clean();
}

int CAMHSDrive::Init()
{
	//// using socket
	//new SocketMgr;
	//new SocketGarbageCollector;
	//sSocketMgr.SpawnWorkerThreads();
	//string host = "127.0.0.1";
	//int wsport = 9999;
	//// Create listener
	//ListenSocket<AMHSSocket> * ls = new ListenSocket<AMHSSocket>(host.c_str(), wsport);
	//bool listnersockcreate = ls->IsOpen();
	//if(listnersockcreate)
	//	ThreadPool.ExecuteTask(ls);

	//ThreadPool.ShowStats();

	// using asio
	new AMHS_Server;
	sAmhsServer.Start(9999);

	return 0;
}

DR_OHT_LIST CAMHSDrive::GetOhtList()
{
	DR_OHT_LIST list;
	amhs_oht_set oht_set = sAmhsServer.GetOhtSet();
	for (amhs_oht_set::iterator it = oht_set.begin(); 
		it != oht_set.end(); ++it)
	{
		amhs_oht_ptr sp_oht = *it;
		driveOHT dOht;
		dOht.nID = sp_oht->nID;
		dOht.nPos =  sp_oht->nPOS;
		dOht.nHand = sp_oht->nHand;
		list.push_back(dOht);
	}
	return list;
}

int CAMHSDrive::Check()
{
	/*while(1)
	{
	ThreadPool.ShowStats();
	Sleep(5000);
	}*/
	/*while(1)
	{
	sSocketMgr.ShowStatus();
	Sleep(1000);
	}*/

	//int nCount = sAmhsServer.GetConnectedCount();
	//printf("amhs dev connected: %d\n", nCount);

	return 0;
}

int CAMHSDrive::Clean()
{
	//sSocketMgr.ShutdownThreads();
	//sSocketMgr.CloseAll();
	//delete SocketMgr::getSingletonPtr();
	//delete SocketGarbageCollector::getSingletonPtr();

	//ThreadPool.Shutdown();
	delete AMHS_Server::getSingletonPtr();
	return 0;
}

int CAMHSDrive::SetOHTBackMessage(int nOHT, int ms)
{
	sAmhsServer.SetOHTBaceMesageTime(nOHT, ms);
	return 0;
}

int CAMHSDrive::SetOHTLocation(int nPoint)
{

	return 0;
}