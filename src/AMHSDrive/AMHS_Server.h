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
		pServer->setOhtMessageBackTime(nID, ms);
	}

private:
	boost::asio::io_service io_service;
	boost::thread t;
	amhs_server_ptr pServer;
};

#define sAmhsServer AMHS_Server::getSingleton()