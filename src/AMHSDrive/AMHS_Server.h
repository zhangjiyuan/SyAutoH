#pragma once

#include "../shared/Singleton.h"
#include "amhs_server.hpp"
class AMHS_Server;
class AMHS_Server : public Singleton<AMHS_Server>
{
public:
	int Start(int nPort);
	int Close();

public:
	void SetOHTBaceMesageTime(int nID, int ms)
	{
		m_pServer->setOhtMessageBackTime(nID, ms);
	}

	int GetConnectedCount()
	{
		return m_pServer->GetConnectCount();
	}

private:
	boost::asio::io_service m_io_service;
	boost::thread m_thread;
	amhs_server_ptr m_pServer;
};

#define sAmhsServer AMHS_Server::getSingleton()