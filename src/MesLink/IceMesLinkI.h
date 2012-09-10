#pragma once
#include "iMesLink.h"
using namespace MCS;
class CSource;
class IceMesLinkI : public MESLink
{
public:
	IceMesLinkI(void);
	~IceMesLinkI(void);

public:
	virtual int PlaceFoup(::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int PickFoup(::Ice::Int, ::Ice::Int, const ::Ice::Current& /* = ::Ice::Current */);

private:
	CSource* m_pSource;

public:
	void SetSource(CSource* source){ m_pSource = source; };
};

