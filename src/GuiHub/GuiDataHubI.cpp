#include "StdAfx.h"
#include "GuiDataHubI.h"
#include "../AMHSDrive/AMHSDrive.h"
#include "../shared/Util.h"
#include "../shared/Log.h"
#include "../SqlAceCli/SqlAceCli.h"
#include "IceUtil/Unicode.h"

GuiDataHubI::GuiDataHubI(void)
{
	m_optHanders.insert(std::make_pair("OHT.POSTIME", 
		&GuiDataHubI::OHT_SetPositionBackTime));
	m_optHanders.insert(std::make_pair("OHT.GetPosTable", 
		&GuiDataHubI::OHT_GetPositionTable));
	m_optHanders.insert(std::make_pair("OHT.PATHTEST", 
		&GuiDataHubI::OHT_PathTest));
}


GuiDataHubI::~GuiDataHubI(void)
{
}

std::string GuiDataHubI::ReadData(const std::string &,Ice::Int,const Ice::Current &)
{
	return "Read";
}

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

	UpdateData("OHT.PosTable", strVal);
}

void GuiDataHubI::OHT_PathTest(const std::string&)
{
	PATH_POINT_LIST list;
	keyPoint pt;

	pt.nPos = 1;
	pt.nType = 1;
	pt.nSpeedRate = 100;
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
	

	m_pAMHSDrive->OHTSetPath(1, 1, 1, 100, list);
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

Ice::Int GuiDataHubI::WriteData(const std::string &strTag,const std::string &strVal,Ice::Int,const Ice::Current &)
{
	OPT_MAP::iterator it = m_optHanders.find(strTag);
	if (it != m_optHanders.end())
	{
		(this->*it->second)(strVal);
		return 0;
	}
	else
	{
		return -1;
	}
}

void GuiDataHubI::SetDataUpdater(const ::MCS::GuiDataUpdaterPrx& updater, const ::Ice::Current& /* = ::Ice::Current */)
{
	WLock(m_rwUpdaterSet)
	{
		SET_UPDATER::iterator it = m_setUpdater.find(updater);
		if (it != m_setUpdater.end())
		{
			return;
		}

		m_setUpdater.insert(updater);
	}
}

void GuiDataHubI::removeUpdater(const ::MCS::GuiDataUpdaterPrx& updater)
{
	WLock(m_rwUpdaterSet)
	{
		if (m_setUpdater.size() <= 0)
		{
			return;
		}

		SET_UPDATER::iterator it = m_setUpdater.find(updater);
		if (it != m_setUpdater.end())
		{
			m_setUpdater.erase(updater);
		}
	}
}

void GuiDataHubI::UpdateData(const std::string &sTag, const std::string &sVal)
{
	RLock(m_rwUpdaterSet)
	{
		for(SET_UPDATER::iterator p = m_setUpdater.begin(); p != m_setUpdater.end(); ++p)
		{
			try
			{
				UpdateCallbackPtr cb = new UpdateCallback();
				cb->client = *p;
				cb->m_view = this;
				GuiDataItem item;
				item.sTag = sTag;
				item.sVal = sVal;

				::Ice::AsyncResultPtr pAsyncCall = (*p)->begin_UpdateData(item,
					newCallback_GuiDataUpdater_UpdateData(cb, &UpdateCallback::response, 
					&UpdateCallback::exception));
			}
			catch(const Ice::Exception& ex)
			{
				cout << "Update data ex: " << ex.ice_name() << endl;
			}
		}
	}
}
