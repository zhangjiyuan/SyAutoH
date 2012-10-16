#pragma once

#include "IceBase.h"

class MesMsgSource;
class MesLinkServer : public CIceServerBase
{
public:
	MesLinkServer(void);
	virtual ~MesLinkServer(void);

public:
	virtual void GetProxy();

private:
	MesMsgSource* m_pSource;
	
public:
	void Source(MesMsgSource* val) { m_pSource = val; }

};

