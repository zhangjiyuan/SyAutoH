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
	virtual LocFoup GetFoup(const ::std::string&, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int PlaceFoup(const ::std::string&, int, int, const ::Ice::Current&);
	virtual int PickFoup(const ::std::string&, int, int, const ::Ice::Current&);

private:
	CSource* m_pSource;

public:
	void SetSource(CSource* source){ m_pSource = source; };
};

