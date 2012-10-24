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
void GuiDataHubI::SetDataUpdater(const ::MCS::GuiDataUpdaterPrx& updater, const ::Ice::Current& /* = ::Ice::Current */)
{
	//dataUpdater->UpdateData("TEST", "CallBack OK 1000");
	vector<ClientInfo>::iterator p;
	for(p = m_listUpdater.begin(); p != m_listUpdater.end(); ++p)
	{
		if(updater ==  p->client )
		{
			return;
		}
	}

	ClientInfo info;
	info.client = updater;
	m_listUpdater.push_back(info);
}

void GuiDataHubI::removeUpdater(const ::MCS::GuiDataUpdaterPrx& updater)
{
	vector<ClientInfo>::iterator p;
	for(p = m_listUpdater.begin(); p != m_listUpdater.end(); ++p)
	{
		if(updater ==  p->client )
		{
			break;
		}
	}

	//assert(p != m_listUpdater.end());
	if (p != m_listUpdater.end())
	{
		m_listUpdater.erase(p);
	}
}

void GuiDataHubI::UpdateData(const std::string &sTag, const std::string &sVal)
{
	int n = 0;
	vector<ClientInfo>::iterator p;
	for(p = m_listUpdater.begin(); p != m_listUpdater.end(); ++p)
	{
		try
		{
			UpdateCallbackPtr cb = new UpdateCallback();
			cb->client = p->client;
			cb->m_view = this;

			p->client->begin_UpdateData(sTag, sVal,
				newCallback_GuiDataUpdater_UpdateData(cb, &UpdateCallback::response, 
				&UpdateCallback::exception));

			++n;
		}
		catch(const Ice::Exception& /*ex*/)
		{

		}
	}
}
