#pragma once
#include "iMesLink.h"
using namespace MCS;
class MesMsgSource;
class IceMesLinkI : public MESLink
{
public:
	IceMesLinkI(void);
	~IceMesLinkI(void);

public:
	virtual LocFoup GetFoup(::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int PlaceFoup(::Ice::Int, ::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int PickFoup(::Ice::Int, ::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);

private:
	MesMsgSource* m_pSource;

public:
	void SetSource(MesMsgSource* source){ m_pSource = source; };
};

