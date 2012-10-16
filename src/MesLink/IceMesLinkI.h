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
	virtual LocFoup GetFoup(const ::std::string&, const ::Ice::Current& /* = ::Ice::Current */);
	virtual int PlaceFoup(const ::std::string&, int, int, const ::Ice::Current&);
	virtual int PickFoup(const ::std::string&, int, int, const ::Ice::Current&);

private:
	MesMsgSource* m_pSource;

public:
	void SetSource(MesMsgSource* source){ m_pSource = source; };
};

