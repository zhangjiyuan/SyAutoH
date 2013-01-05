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

LocFoup IceMesLinkI::GetFoup(int nFoupBarCode, const ::Ice::Current& )
{
	LocFoup locationFoup;
	
	return locationFoup;
}
int IceMesLinkI::PlaceFoup(int nFoupBarCode, 
	int nDevID, int nType, const ::Ice::Current&)
{
	__raise m_pSource->MESPlaceFoup(nFoupBarCode, nDevID, nType);
	return 0;
}
int IceMesLinkI::PickFoup(int nFoupBarCode, 
	int nDevID, int nType, const ::Ice::Current&)
{
	__raise m_pSource->MESPickFoup(nFoupBarCode, nDevID, nType);
	return 0;
}