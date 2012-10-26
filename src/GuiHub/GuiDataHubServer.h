#pragma once
#include "IceBase.h"

class GuiDataHubI;
class GuiDataHubServer: public CIceServerBase
{
public:
	GuiDataHubServer(void);
	virtual ~GuiDataHubServer(void);
public:
	virtual void GetProxy();

public:
	void UpdateData(const string&, const string&);

private:
	GuiDataHubI* m_pGuiHub;
};

