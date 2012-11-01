#include "StdAfx.h"
#include "GuiDataHubI.h"
#include "../AMHSDrive/AMHSDrive.h"
#include "../shared/Util.h"

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

Ice::Int GuiDataHubI::WriteData(const std::string &strTag,const std::string &strVal,Ice::Int,const Ice::Current &)
{
	if (strTag.find("OHT.POSTIME") >= 0)
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

	
	
	return 0;
}

void GuiDataHubI::SetDataUpdater(const ::MCS::GuiDataUpdaterPrx& updater, const ::Ice::Current& /* = ::Ice::Current */)
{
	WLock(m_rwmListUpdater)
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
	WLock(m_rwmListUpdater)
	{
		if (m_setUpdater.size() <= 0)
		{
			return;
		}

		m_setUpdater.erase(updater);
	}
}

void GuiDataHubI::UpdateData(const std::string &sTag, const std::string &sVal)
{
	RLock(m_rwmListUpdater)
	{
		for(SET_UPDATER::iterator p = m_setUpdater.begin(); p != m_setUpdater.end(); ++p)
		{
			try
			{
				UpdateCallbackPtr cb = new UpdateCallback();
				cb->client = *p;
				cb->m_view = this;

				::Ice::AsyncResultPtr pAsyncCall = (*p)->begin_UpdateData(sTag, sVal,
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
