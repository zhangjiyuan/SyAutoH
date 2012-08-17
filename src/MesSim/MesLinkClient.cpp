#include "StdAfx.h"
#include "MesLinkClient.h"


MesLinkClient::MesLinkClient(void)
{
	Proxy("MESLink");
}


MesLinkClient::~MesLinkClient(void)
{
}

void MesLinkClient::GetProxy()
{
	m_Proxy =MESLinkPrx::uncheckedCast(m_objPrx);
}

int MesLinkClient::PlaceFoup(int FoupID, int DevID)
{
	int nRet = 0;
	try
	{
		return m_Proxy->PlaceFoup(FoupID, DevID);
	}
	catch (Ice::Exception & ex)
	{
		cout<< ex.what();
	}
	return nRet;
}
int MesLinkClient::PickFoup(int FoupId, int DevID)
{
	int nRet = 0;
	try
	{
		return m_Proxy->PickFoup(FoupId, DevID);
	}
	catch (Ice::Exception & ex)
	{
		cout<< ex.what();
	}
	return nRet;
}