#pragma once
#include "iGuiHub.h"
using namespace MCS;

class GuiDataHubI : public GuiDataHub
{
public:
	GuiDataHubI(void);
	virtual ~GuiDataHubI(void);

public:
	virtual std::string ReadData(const std::string &,Ice::Int,const Ice::Current &);
	virtual Ice::Int WriteData(const std::string &,const std::string &,Ice::Int,const Ice::Current &);
	virtual void SetDataUpdater(const ::MCS::GuiDataUpdaterPrx&, const ::Ice::Current& /* = ::Ice::Current */);
};

