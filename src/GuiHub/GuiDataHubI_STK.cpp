#include "StdAfx.h"
#include "GuiDataHubI.h"
#include "../AMHSDrive/AMHSDrive.h"
#include "../shared/Util.h"
#include "../shared/Log.h"
#include "../SqlAceCli/SqlAceCli.h"
#include "IceUtil/Unicode.h"
#include "iConstDef.h"

GuiDataItem GuiDataHubI::Push_STK_DevInfo()
{
	GuiDataItem item;
	item.enumTag = GuiHub::upStkInfo;

	DR_STK_LIST stk_list = m_pAMHSDrive->GetStkList();
	string strGuiData = "";
	char buf[256] ="";
	for (DR_STK_LIST::iterator it = stk_list.begin(); 
		it != stk_list.end(); ++it)
	{
		sprintf_s(buf, 256, "<%d,%d,%d>", it->nID, 0, 0);
		strGuiData += buf;
	}

	item.sVal = strGuiData;

	return item;
}

void GuiDataHubI::STK_SetStatusBackTime(const std::string& strVal, const ::Ice::Current&)
{
	STR_VEC vecStr = GetVecStrings(strVal);
	for(STR_VEC::iterator it = vecStr.begin();
		it != vecStr.end(); ++it)
	{
		string strE = *it;
		STR_VEC Params = SplitString(*it, ",");
		if (Params.size() == 2)
		{
			int nID = atoi(Params[0].c_str());
			int nTime = atoi(Params[1].c_str());
			m_pAMHSDrive->STKStatusBackTime(nID, nTime);
		}
	}
}

void GuiDataHubI::STK_SetFoupInfoBackTime(const std::string& strVal, const ::Ice::Current&)
{
	STR_VEC vecStr = GetVecStrings(strVal);
	for(STR_VEC::iterator it=vecStr.begin();
		it!=vecStr.end();++it)
	{
		string strE=*it;
		STR_VEC Params=SplitString(*it,",");
		if(Params.size()==2)
		{
			int nID=atoi(Params[0].c_str());
			int nTime=atoi(Params[1].c_str());
			m_pAMHSDrive->STKFoupInfoBackTime(nID,nTime);
		}
	}
}

void GuiDataHubI::STK_FoupHanding(const std::string& strVal, const ::Ice::Current&)
{
	STR_VEC vecStr=GetVecStrings(strVal);
	for(STR_VEC::iterator it=vecStr.begin();
		it!=vecStr.end();++it)
	{
		string strE = *it;
		STR_VEC Params=SplitString(*it,",");
		if(Params.size()==4)
		{
			int nID=atoi(Params[0].c_str());
			int nOpt=atoi(Params[1].c_str());
			int nMode=atoi(Params[2].c_str());
			int nData=atoi(Params[3].c_str());
			m_pAMHSDrive->STKFoup(nID, nOpt, nMode, nData);
		}
	}
}