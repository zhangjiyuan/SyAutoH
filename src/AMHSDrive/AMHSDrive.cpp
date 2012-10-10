// AMHSDrive.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "Common.h"
#include "../shared/Network.h"
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

}

int CAMHSDrive::Init()
{
	new SocketMgr;
	new SocketGarbageCollector;
	sSocketMgr.SpawnWorkerThreads();
	string host = "127.0.0.1";
	int wsport = 9999;
	// Create listener
	ListenSocket<AMHSSocket> * ls = new ListenSocket<AMHSSocket>(host.c_str(), wsport);
	bool listnersockcreate = ls->IsOpen();
	if(listnersockcreate)
		ThreadPool.ExecuteTask(ls);

	ThreadPool.ShowStats();

	return 0;
}

int CAMHSDrive::Run()
{
	return 0;
}

int CAMHSDrive::Clean()
{
	sSocketMgr.ShutdownThreads();
	delete SocketMgr::getSingletonPtr();
	delete SocketGarbageCollector::getSingletonPtr();

	//ThreadPool.Shutdown();
	return 0;
}

int CAMHSDrive::SetOHTLocation(int nPoint)
{
	AMHSPacket oht(0x0817, 512);

	oht << (uint8)253;
	oht << (uint16)65535;

	oht.hexlike();

	

	uint32 dwCode;
	uint8 nOht;
	uint16 nPt;
	oht >> dwCode;
	oht >> nOht;
	oht >> nPt;

	oht.Initialize(45);
	oht.hexlike();

	return 0;
}