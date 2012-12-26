// LogServer.cpp : 定义 DLL 应用程序的入口点。
//

#include "stdafx.h"
#include "LogServer.h"
#include "ice/Ice.h"
#include "LogI.h"

CLogServer::CLogServer()
{ 
	m_hWnd = NULL;
}


Ice::CommunicatorPtr communicator;
Ice::ObjectPtr servant ;
Ice::ObjectAdapterPtr adapter;

int CLogServer::InitICE(void)
{
	try
	{
		int argc = 0;
			
		Ice::InitializationData initData;
		initData.properties = Ice::createProperties();
		std::string strConfigFile = GetProcessPath() + "../config/IceServerConfig.txt";
		//
		// Set a default value for Hello.Endpoints so that the demo
		// will run without a configuration file.
		//
		initData.properties->setProperty("ICLog.Endpoints","tcp -p 17777");

		//
		// Now, load the configuration file if present. Under WinCE we
		// use "config.txt" since it can be edited with pocket word.
		//
		try
		{
			initData.properties->load(strConfigFile);
		}
		catch(const Ice::FileException&)
		{
		}
	
		communicator = Ice::initialize(argc, 0, initData);

		adapter = communicator->createObjectAdapter("ICLog");
		//LogPtr logger = new LogPtr(this);
		servant = new CLogI(m_hWnd);
		adapter->add(servant, communicator->stringToIdentity("ICLog"));
		adapter->activate();

		//communicator = Ice::initialize(argc, NULL);
		//adapter = communicator->createObjectAdapterWithEndpoints("ICLog.Endpoints","tcp -p 15356");
		//servant = new CLogI(m_hWnd);
		//adapter->add(servant, communicator->stringToIdentity("ICLog"));
		//adapter->activate();
	}
	catch(const Ice::Exception& ex)
	{
		TCHAR wtext[1024];
		string err = ex.what();
		mbstowcs(wtext, err.c_str(), err.size());
		MessageBox(NULL, wtext, L"Error", MB_ICONEXCLAMATION | MB_OK);
		return -1;
	}

	return 0;
}

int CLogServer::InitDataStore(void)
{


	return 0;
}

int CLogServer::Init(void)
{
	InitDataStore();
	InitICE();

	return 0;
}

int CLogServer::End(void)
{
	if(communicator)
	{
		try
		{
			adapter->destroy();
			communicator->destroy();
			////delete communicator;
			//if (NULL != servant)
			//{
			//	//delete servant;
			//	servant->__decRef();
			//}
			
		}
		catch(const Ice::Exception& ex)
		{
			TCHAR wtext[1024];
			string err = ex.what();
			mbstowcs(wtext, err.c_str(), err.size());
			//MessageBox(mainWnd, wtext, L"Error", MB_ICONEXCLAMATION | MB_OK);

			//status = EXIT_FAILURE;
		}
	}

	return 0;
}

void CLogServer::BindMsgHandle(HWND hwnd)
{
	m_hWnd = hwnd;
}
