#pragma once

#include "../shared/Singleton.h"
#include "amhs_dev_server.h"
class AMHS_Server;
class AMHS_Server : public Singleton<AMHS_Server>
{
public:
	int Start(int nPort);
	int Close();

public:
	
	amhs_server_ptr GetServer() const { return m_pServer; }

private:
	boost::asio::io_service m_io_service;
	boost::thread m_thread;
	amhs_server_ptr m_pServer;
};

#define sAmhsServer AMHS_Server::getSingleton()