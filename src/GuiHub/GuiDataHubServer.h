#pragma once
#include "IceBase.h"
#include "../common/iConstDef.h"

class GuiDataHubI;
class CAMHSDrive;
class GuiDataHubServer: public CIceServerBase
{
public:
	GuiDataHubServer(void);
	virtual ~GuiDataHubServer(void);
public:
	virtual void GetProxy();

public:
	void UpdateData(MCS::GuiHub::PushData, const string&);
	void SetDrive(CAMHSDrive* pDrive);
private:
	GuiDataHubI* m_pGuiHub;
};

