#include "StdAfx.h"
#include "GuiDataHubI.h"


GuiDataHubI::GuiDataHubI(void)
{
}


GuiDataHubI::~GuiDataHubI(void)
{
}

std::string GuiDataHubI::ReadData(const std::string &,Ice::Int,const Ice::Current &)
{
	return "Read";
}
Ice::Int GuiDataHubI::WriteData(const std::string &,const std::string &,Ice::Int,const Ice::Current &)
{
	return 0;
}
void GuiDataHubI::SetDataUpdater(const ::MCS::GuiDataUpdaterPrx& dataUpdater, const ::Ice::Current& /* = ::Ice::Current */)
{
	dataUpdater->UpdateData("OHT.POS", "1000");
}
