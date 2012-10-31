#pragma once
#include "IceBase.h"

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
	void UpdateData(const string&, const string&);
	void SetDrive(CAMHSDrive* pDrive);
private:
	GuiDataHubI* m_pGuiHub;
};

