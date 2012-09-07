#pragma once

#include "IceBase.h"

class CSource;
class MesLinkServer : public CIceServerBase
{
public:
	MesLinkServer(void);
	virtual ~MesLinkServer(void);

public:
	virtual void GetProxy();

private:
	CSource* m_pSource;
	
public:
	void Source(CSource* val) { m_pSource = val; }

};

