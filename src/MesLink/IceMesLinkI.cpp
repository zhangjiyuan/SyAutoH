#include "StdAfx.h"
#include "IceMesLinkI.h"
#include "MesLink.h"
#include "IceUtil/Unicode.h"
#include "../shared/Log.h"

using namespace std;

IceMesLinkI::IceMesLinkI(void)
{
	Log.outBasic("MesLink Server is Ready.");
}


IceMesLinkI::~IceMesLinkI(void)
{
}

LocFoup IceMesLinkI::GetFoup(const ::std::string& sFoupName, const ::Ice::Current& )
{
	LocFoup locationFoup;
	wstring wsName;
	wsName = IceUtil::stringToWstring(sFoupName);
	wprintf_s(L"GetFoup %s \n", wsName.c_str());
	return locationFoup;
}
int IceMesLinkI::PlaceFoup(const ::std::string& sFoupName, 
	int nDevID, int nType, const ::Ice::Current&)
{
	wstring wsName;
	wsName = IceUtil::stringToWstring(sFoupName);
	__raise m_pSource->MESPlaceFoup(wsName.c_str(), nDevID, nType);
	return 0;
}
int IceMesLinkI::PickFoup(const ::std::string& sFoupName, 
	int nDevID, int nType, const ::Ice::Current&)
{
	wstring wsName;
	wsName = IceUtil::stringToWstring(sFoupName);
	__raise m_pSource->MESPickFoup(wsName.c_str(), nDevID, nType);
	return 0;
}