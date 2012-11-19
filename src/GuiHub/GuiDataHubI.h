#pragma once
#include "iGuiHub.h"
#include "../shared/ThreadLock.h"
using namespace MCS;

class ClientInfo
{
private:
	
	
public: 
	MCS::GuiDataUpdaterPrx client;
	int nTryCount;
	
	ClientInfo()
	{
		nTryCount = 0;
	}
	~ClientInfo()
	{

	}

	
};

typedef set<MCS::GuiDataUpdaterPrx> SET_UPDATER;

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
	SET_UPDATER m_setUpdater;
	rwmutex m_rwUpdaterSet;
	CAMHSDrive* m_pAMHSDrive;

	typedef void (GuiDataHubI::*WriteHander)(const std::string&);
	typedef std::map<std::string, WriteHander> OPT_MAP;
	OPT_MAP m_optHanders;

private:
	void OHT_SetPositionBackTime(const std::string&);
	void OHT_GetPositionTable(const std::string&);
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
		//m_view->PopCallPtr();
	}

	void exception(const Ice::Exception& ex)
	{
		//cerr << "call failed:\n" << ex << endl;
		//int i=0;
		//i = client->ice_getHash();
		//cout << "call failed:\n" << ex.ice_name().c_str() << endl;

		if (NULL != m_view)
		{
			m_view->removeUpdater(client);
		}
	}
};
typedef IceUtil::Handle<UpdateCallback> UpdateCallbackPtr;