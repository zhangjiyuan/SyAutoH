#include "StdAfx.h"
#include "IceBase.h"

CIceServerBase::CIceServerBase()
{
	m_communicator = NULL;
	m_objPtr = NULL;
	m_strProxy = "";
	m_strConfigFileName = "IceServerConfig.txt";
}

CIceServerBase::~CIceServerBase()
{
	EndIce();
}

void CIceServerBase::InitIce(void)
{
	string strBasePath = "";
	strBasePath = GetProcessPath();
	try
	{
		Ice::InitializationData initData;
		initData.properties = Ice::createProperties();

		try
		{
			std::string strConfigfile =strBasePath + "../conf/";
			strConfigfile += m_strConfigFileName;
			initData.properties->load(strConfigfile);
		}
		catch(const Ice::FileException&)
		{
			return;
		}

		int argc = 0;
		m_communicator = Ice::initialize(argc, 0, initData);
		m_adapter = m_communicator->createObjectAdapter(m_strProxy);

		GetProxy();

		m_adapter->add(m_objPtr, m_communicator->stringToIdentity(m_strProxy));
		m_adapter->activate();
	}
	catch(const Ice::Exception& ex)
	{
		//MessageBox(NULL, CString(ex.ice_name().c_str()), L"Exception", MB_ICONEXCLAMATION | MB_OK);
		string strMsg;
		strMsg = ex.ice_name();
		return;
	}
}

void CIceServerBase::EndIce(void)
{
	try
	{
		if(NULL != m_communicator )
		{
			m_adapter->destroy();
			m_communicator->destroy();
		}
	}
	catch (const Ice::Exception& /*ex*/)
	{

	}
}
