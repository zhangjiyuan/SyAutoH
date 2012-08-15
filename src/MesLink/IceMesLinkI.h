#pragma once
#include "iMesLink.h"
using namespace MCS;
class IceMesLinkI : public MESLink
{
public:
	IceMesLinkI(void);
	~IceMesLinkI(void);

public:
	virtual int PlaceFoup(::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int PickFoup(::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
};

