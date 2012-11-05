#include "StdAfx.h"
#include "AMHS_Server.h"
#include "amhs_dev_server.h"


initialiseSingleton(AMHS_Server);
int AMHS_Server::Start(int nPort)
{
	tcp::endpoint endpoint(tcp::v4(), nPort);
	amhs_dev_server* DevServer = new amhs_dev_server(m_io_service, endpoint);
	m_pServer = amhs_server_ptr(DevServer);
	m_thread = boost::thread(boost::bind(&boost::asio::io_service::run, &m_io_service));

	return 0;
}

int AMHS_Server::Close()
{
	m_thread.join();
	return 0;
}