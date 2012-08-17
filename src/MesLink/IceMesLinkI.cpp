#include "StdAfx.h"
#include "IceMesLinkI.h"
#include <iostream>
using namespace std;

IceMesLinkI::IceMesLinkI(void)
{
}


IceMesLinkI::~IceMesLinkI(void)
{
}

int IceMesLinkI::PickFoup(::Ice::Int nFoup, ::Ice::Int nDev, const ::Ice::Current& )
{
	cout<<"MesLink get command: <PickFoup> Param: " << nFoup << " " << nDev << endl; 
	return 0;
}

int IceMesLinkI::PlaceFoup(::Ice::Int nFoup, ::Ice::Int nDev, const ::Ice::Current& )
{
	cout<<"MesLink get command: <PlaceFoup> Param: " << nFoup << " " << nDev << endl; 
	return 0;
}