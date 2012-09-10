#include "StdAfx.h"
#include "IceMesLinkI.h"
#include <iostream>
using namespace std;
#include "MesLink.h"
IceMesLinkI::IceMesLinkI(void)
{
}


IceMesLinkI::~IceMesLinkI(void)
{
}

int IceMesLinkI::PickFoup(::Ice::Int nFoup, ::Ice::Int nDev, const ::Ice::Current& )
{
	cout<<"MesLink get command: <PickFoup> Param: " << nFoup << " " << nDev << endl; 
	__raise m_pSource->MyEvent(nFoup);
	return 0;
}

int IceMesLinkI::PlaceFoup(::Ice::Int nFoup, ::Ice::Int nDev, const ::Ice::Current& )
{
	cout<<"MesLink get command: <PlaceFoup> Param: " << nFoup << " " << nDev << endl; 
	wstring ws;
	WCHAR wBuf[50] = {0};
	wsprintf(wBuf, L"%d", nFoup);
	__raise m_pSource->MyEventS(wBuf, nDev);
	return 0;
}