#pragma once
#include "iGuiHub.h"
#include "../shared/ThreadLock.h"
using namespace MCS;

class ClientInfo
{
public: 
	MCS::GuiDataUpdaterPrx client;
	int nTryCount;
	ClientInfo()
	{
		nTryCount = 0;
	}
};

typedef vector<ClientInfo> LIST_UPDATER;

class CAMHSDrive;
class GuiDataHubI : public GuiDataHub
{
public:
	GuiDataHubI(void);
	virtual ~GuiDataHubI(void);

public:
	virtual std::string ReadData(const std::string &,Ice::Int,const Ice::Current &);
	virtual Ice::Int WriteData(const std::string &,const std::string &,Ice::Int,const Ice::Current &);
	virtual void SetDataUpdater(const ::MCS::GuiDataUpdaterPrx&, const ::Ice::Current& /* = ::Ice::Current */);

public:
	void UpdateData(const std::string &, const std::string &);
	void removeUpdater(const ::MCS::GuiDataUpdaterPrx& updater);

	CAMHSDrive* AMHSDrive() const { return m_pAMHSDrive; }
	void AMHSDrive(CAMHSDrive* val) { m_pAMHSDrive = val; }

private:
	LIST_UPDATER m_listUpdater;
	rwmutex m_rwmListUpdater;
	CAMHSDrive* m_pAMHSDrive;
};

class UpdateCallback : public IceUtil::Shared
{
public:
	GuiDataUpdaterPrx client;
	GuiDataHubI*   m_view;

	UpdateCallback()
	{
		client = NULL;
		m_view = NULL;
	}

	void response()
	{
		//int i=0;

		//i = client->ice_getHash();

	}

	void exception(const Ice::Exception& ex)
	{
		//cerr << "call failed:\n" << ex << endl;
		//int i=0;
		//i = client->ice_getHash();

		if (NULL != m_view)
		{
			m_view->removeUpdater(client);
		}
	}
};
typedef IceUtil::Handle<UpdateCallback> UpdateCallbackPtr;