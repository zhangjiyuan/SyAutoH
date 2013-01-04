#include "StdAfx.h"
#include "GuiDataHubI.h"
#include "../AMHSDrive/AMHSDrive.h"
#include "../shared/Util.h"
#include "../shared/Log.h"
#include "../SqlAceCli/SqlAceCli.h"
#include "IceUtil/Unicode.h"
#include "iConstDef.h"

void GuiDataHubI::MES_GetPositionTable(const std::string&, const ::Ice::Current& current)
{
	vector<int> nTypes;
	nTypes.push_back(0x40);
	nTypes.push_back(0x20);
	nTypes.push_back(0x80);

	string strVal = _GetKeyPointsTable(nTypes);
	UpdateDataOne(current.con, GuiHub::upMesPosTable, strVal);
}