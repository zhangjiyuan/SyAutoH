#pragma once
#include "IceBase.h"
#include "iMesLink.h"

using namespace MCS;

class MesLinkClient : public CIceClientBase
{
public:
	MesLinkClient(void);
	virtual ~MesLinkClient(void);

private:
	MESLinkPrx m_Proxy;

protected:
	virtual void GetProxy();

public:
	int PlaceFoup(int FoupID, int DevID);
	int PickFoup(int FoupId, int DevID);
};

