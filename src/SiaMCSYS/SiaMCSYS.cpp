// SiaMCSYS.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <string>
#include <iostream>
using namespace std;

#include "MaterialController.h"
#include "MetaMoveCtrlServer.h"
#include "AtomicBoolean.h"
#include <signal.h>

initialiseSingleton(MetaMoveCtrlServer);

int _tmain(int argc, _TCHAR* argv[])
{
	
	new MetaMoveCtrlServer;
	MetaMoveCtrlServer::getSingleton().Run(argc, argv);
	delete MetaMoveCtrlServer::getSingletonPtr();

	return 0;
}