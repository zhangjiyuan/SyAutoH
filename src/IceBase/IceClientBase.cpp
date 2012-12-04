// IceClientBase.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "IceBase.h"
#include <iostream>
#include "../shared/Log.h"

string GetProcessPath()
{
	TCHAR buf[256] = {0};
	GetModuleFileName(NULL, buf, 256);
	std::wstring wstr;
	wstr = buf;
	std::string str = "";
	str =  IceUtil::wstringToString(wstr);

	size_t nBar = str.find_last_of('\\') + 1;
	str = str.substr(0, nBar);

	return str;
}

// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 IceClientBase.h
CIceClientBase::CIceClientBase()
{
	m_communicator = NULL;
	m_objPrx = NULL;
	m_strProxy = "";
	m_strConfigFileName = "IceClientConfig.txt";
}

CIceClientBase::~CIceClientBase()
{
	EndIce();
}

void CIceClientBase::InitIce(void)
{
	string strBasePath = "";
	strBasePath = GetProcessPath();
	try
	{
		Ice::InitializationData initData;
		initData.properties = Ice::createProperties();

		//
		// Set a default value for "Hello.Proxy" so that the demo will
		// run without a configuration file.
		//
		//initData.properties->setProperty("SHMIAlarm.Proxy", "SHMIAlarm:tcp -p 11888");

		//
		// Now, load the configuration file if present. Under WinCE we
		// use "config.txt" since it can be edited with pocket word.
		//
		std::string strConfigfile = "";
		try
		{
			strConfigfile =strBasePath + "../config/";
			strConfigfile += m_strConfigFileName;
			initData.properties->load(strConfigfile);
		}
		catch(const Ice::FileException& ex)
		{
			std::cout<< ex.what() << endl;
			std::cout<< "Maybe cannot find the config file: " << strConfigfile << endl;
			Sleep(1000);
			return;
		}

		int argc = 0;
		m_communicator = Ice::initialize(argc, 0, initData);

		string strProxy = m_strProxy;
		strProxy += ".Proxy";
		m_objPrx = m_communicator->stringToProxy(initData.properties->getProperty(strProxy));

		//IceInternal::ProxyHandle<T> 
		//AlarmViewer =
		//IceInternal::ProxyHandle::checkedCast(m_objPrx);

		GetProxy();
	}
	catch(const Ice::Exception& ex)
	{
		//MessageBox(NULL, CString(ex.ice_name().c_str()), L"Exception", MB_ICONEXCLAMATION | MB_OK);
		string strMsg;
		strMsg = ex.ice_name();
		//printf("%s \n", strMsg.c_str());
		LOG_ERROR("%s", strMsg.c_str());
		return;
	}
}

void CIceClientBase::EndIce(void)
{
	try
	{
		if(NULL != m_communicator )
		{
			m_communicator->destroy();
		}
	}
	catch (const Ice::Exception& /*ex*/)
	{

	}
}
