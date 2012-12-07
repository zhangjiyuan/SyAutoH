#include "StdAfx.h"
#include "GuiDataHubI.h"
#include "../AMHSDrive/AMHSDrive.h"
#include "../shared/Util.h"
#include "../shared/Log.h"
#include "../SqlAceCli/SqlAceCli.h"
#include "IceUtil/Unicode.h"
#include "iConstDef.h"

void GuiDataHubI::OHT_GetPositionTable(const std::string&)
{
	LOG_DEBUG("");
	//boost::thread();
	DBKeyPoints db;
	VEC_KEYPOINT ptKeys = db.GetKeyPointsTable();
	string strVal = "";
	char buf[100] = "";
	for (VEC_KEYPOINT::iterator it = ptKeys.begin();
		it != ptKeys.end(); ++it)
	{
		strVal += "<";
		strVal += IceUtil::wstringToString(it->strName);
		strVal += ",";
		strVal += itoa(it->uPosition, buf, 10);
		strVal += ",";
		strVal += itoa(it->uType, buf, 10);
		strVal += ",";
		strVal += itoa(it->uSpeedRate, buf, 10);
		strVal += ">";
	}

	UpdateData(GuiHub::upOhtPosTable, strVal);
}
void GuiDataHubI::OHT_FoupTest(const std::string&)
{
	m_pAMHSDrive->OHTFoup(1, 100, 0);
	Sleep(100);
	m_pAMHSDrive->OHTFoup(1, 100, 1);
}
void GuiDataHubI::OHT_MoveTest(const std::string&)
{
	m_pAMHSDrive->OHTMove(1, 1);
}

void GuiDataHubI::OHT_PathTest(const std::string&)
{
	PATH_POINT_LIST list;
	keyPoint pt;

	pt.nPos = 1;
	pt.nType = 1;
	pt.nSpeedRate = 10;
	list.push_back(pt);

	pt.nPos = 30;
	pt.nType = 2;
	pt.nSpeedRate = 30;
	list.push_back(pt);

	pt.nPos = 50;
	pt.nType = 4;
	pt.nSpeedRate = 50;
	list.push_back(pt);

	pt.nPos = 70;
	pt.nType = 8;
	pt.nSpeedRate = 70;
	list.push_back(pt);

	pt.nPos = 100;
	pt.nType = 16;
	pt.nSpeedRate = 100;
	list.push_back(pt);

	int nSleep = 50;
	m_pAMHSDrive->OHTFoup(1, 100, 0);
	Sleep(nSleep);
	m_pAMHSDrive->OHTSetPath(1, 1, 1, 100, list);
	Sleep(nSleep);
	m_pAMHSDrive->OHTFoup(1, 100, 0);
	Sleep(nSleep);
	m_pAMHSDrive->OHTSetPath(1, 1, 1, 100, list);
	Sleep(nSleep);
	m_pAMHSDrive->OHTFoup(1, 100, 0);
	Sleep(nSleep);
	m_pAMHSDrive->OHTSetPath(1, 1, 1, 100, list);
	Sleep(nSleep);
	m_pAMHSDrive->OHTFoup(1, 100, 0);
	Sleep(nSleep);
	m_pAMHSDrive->OHTSetPath(1, 1, 1, 100, list);
	Sleep(nSleep);
	m_pAMHSDrive->OHTFoup(1, 100, 0);
	Sleep(nSleep);
	m_pAMHSDrive->OHTSetPath(1, 1, 1, 100, list);
	Sleep(nSleep);
	m_pAMHSDrive->OHTFoup(1, 100, 0);
	Sleep(nSleep);
	m_pAMHSDrive->OHTSetPath(1, 1, 1, 100, list);
	Sleep(nSleep);
	m_pAMHSDrive->OHTMove(1, 1);
}
void GuiDataHubI::OHT_SetStatusBackTime(const std::string& strVal)
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
			m_pAMHSDrive->OHTStatusBackTime(nID, nTime);
		}
	}
}

void GuiDataHubI::OHT_SetPath(const std::string& strVal)
{
	PATH_POINT_LIST list;
	keyPoint pt;
	uint8 uID = 0;
	uint8 uType = 0;
	
	STR_VEC vecStr = GetVecStrings(strVal);
	for(STR_VEC::iterator it = vecStr.begin();
		it != vecStr.end(); ++it)
	{
		string strE = *it;
		STR_VEC Params = SplitString(*it, ",");
		size_t szParams = Params.size();
		if (3 == szParams)
		{
			pt.nPos = atoi(Params[0].c_str());
			pt.nType = atoi(Params[1].c_str());
			pt.nSpeedRate = atoi(Params[2].c_str());
			list.push_back(pt);
		}
		else if (2 == szParams)
		{
			uID = atoi(Params[0].c_str());
			uType = atoi(Params[1].c_str());
		}
	}

	int nStart = 0;
	int nEnd = 0;
	nStart = list.begin()->nPos;
	nEnd = list.rbegin()->nPos;

	m_pAMHSDrive->OHTSetPath(uID, uType, nStart, nEnd, list);
}

void GuiDataHubI::OHT_Move(const std::string& strVal)
{
	uint8 uID = 0;
	uint8 uType = 0;
	STR_VEC vecStr = GetVecStrings(strVal);
	for(STR_VEC::iterator it = vecStr.begin();
		it != vecStr.end(); ++it)
	{
		string strE = *it;
		STR_VEC Params = SplitString(*it, ",");
		size_t szParams = Params.size();
		 if (2 == szParams)
		{
			uID = atoi(Params[0].c_str());
			uType = atoi(Params[1].c_str());
		}
	}

	m_pAMHSDrive->OHTMove(uID, uType);
}

void GuiDataHubI::OHT_FoupHanding(const std::string& strVal)
{
	STR_VEC vecStr = GetVecStrings(strVal);
	for(STR_VEC::iterator it = vecStr.begin();
		it != vecStr.end(); ++it)
	{
		string strE = *it;
		STR_VEC Params = SplitString(*it, ",");
		if (Params.size() == 3)
		{
			int nID = atoi(Params[0].c_str());
			int nBuffID = atoi(Params[1].c_str());
			int nHanding = atoi(Params[2].c_str());
			m_pAMHSDrive->OHTFoup(nID, nBuffID, nHanding);
		}
	}
}
void GuiDataHubI::OHT_SetPositionBackTime(const std::string& strVal)
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
			m_pAMHSDrive->OHTPosBackTime(nID, nTime);
		}
	}
}