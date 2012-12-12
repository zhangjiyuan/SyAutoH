#include "StdAfx.h"
#include "GuiDataHubI.h"
#include "../AMHSDrive/AMHSDrive.h"
#include "../shared/Util.h"
#include "../shared/Log.h"
#include "../SqlAceCli/SqlAceCli.h"
#include "IceUtil/Unicode.h"
#include "iConstDef.h"

GuiDataHubI::GuiDataHubI(void)
{
	// for oht
	m_mapHandles.insert(std::make_pair(GuiHub::OhtPosTime, 
		&GuiDataHubI::OHT_SetPositionBackTime));
	m_mapHandles.insert(std::make_pair(GuiHub::OhtStatusTime, 
		&GuiDataHubI::OHT_SetStatusBackTime));
	m_mapHandles.insert(std::make_pair(GuiHub::OhtGetPosTable, 
		&GuiDataHubI::OHT_GetPositionTable));
	m_mapHandles.insert(std::make_pair(GuiHub::OhtFoupHanding, 
		&GuiDataHubI::OHT_FoupHanding));
	m_mapHandles.insert(std::make_pair(GuiHub::OhtSetPath, 
		&GuiDataHubI::OHT_SetPath));
	m_mapHandles.insert(std::make_pair(GuiHub::OhtMove, 
		&GuiDataHubI::OHT_Move));


	m_mapHandles.insert(std::make_pair(GuiHub::OhtPathTest, 
		&GuiDataHubI::OHT_PathTest));
	m_mapHandles.insert(std::make_pair(GuiHub::OhtMoveTest, 
		&GuiDataHubI::OHT_MoveTest));
	m_mapHandles.insert(std::make_pair(GuiHub::OhtFoupTest, 
		&GuiDataHubI::OHT_FoupTest));

	// for stocker
	m_mapHandles.insert(std::make_pair(GuiHub::StkStatusTime,
		&GuiDataHubI::STK_SetStatusBackTime));
}


GuiDataHubI::~GuiDataHubI(void)
{
}

std::string GuiDataHubI::ReadData(MCS::GuiHub::GuiCommand enumCmd, Ice::Int nSession, const Ice::Current &)
{
	return "readData";
}

Ice::Int GuiDataHubI::WriteData(MCS::GuiHub::GuiCommand enumCmd, 
	const std::string &strVal, Ice::Int nSession, const Ice::Current &)
{
	HANDLE_MAP::iterator it = m_mapHandles.find(enumCmd);
	if (it != m_mapHandles.end())
	{
		(this->*it->second)(strVal);
		return 0;
	}
	else
	{
		return -1;
	}
}

int GuiDataHubI::SetPushCmd(const ::MCS::GuiDataUpdaterPrx& guicli, 
	const ::MCS::GuiHub::GuiCmdList& cmdlist, ::Ice::Int, const ::Ice::Current& )
{
	WLock(m_rwUpdaterSet)
	{

	}
	return 0;
}

int GuiDataHubI::SetPushTimer(::Ice::Int nPeriord, ::Ice::Int, const ::Ice::Current& )
{
	WLock(m_rwTimerSet)
	{
		m_nTimerPeriord = nPeriord;
	}

	return 0;
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

void GuiDataHubI::EraseDataUpdater(const ::MCS::GuiDataUpdaterPrx& updater, const ::Ice::Current& )
{
	removeUpdater(updater);
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

void GuiDataHubI::UpdateData(MCS::GuiHub::PushData nTag, const std::string &sVal)
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
				item.enumTag =nTag;
				item.sVal = sVal;
				__time64_t time;
				_time64(&time);
				

				(*p)->begin_UpdateData(time, item,
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
