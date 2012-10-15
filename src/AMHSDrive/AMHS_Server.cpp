#include "StdAfx.h"
#include "AMHS_Server.h"
#include "amhs_server.hpp"


initialiseSingleton(AMHS_Server);
int AMHS_Server::Start(int nPort)
{
	//boost::asio::io_service io_service;

	//chat_server_list servers;
	//for (int i = 1; i < argc; ++i)
	//{
	//	using namespace std; // For atoi.
	//	tcp::endpoint endpoint(tcp::v4(), atoi(argv[i]));
	//	chat_server_ptr server(new chat_server(io_service, endpoint));
	//	servers.push_back(server);
	//}
	//
	
	//chat_server_ptr server(new chat_server(io_service, endpoint));
	//io_service.run();
	//pclient = new amhs_client(io_service, iterator);
	
	tcp::endpoint endpoint(tcp::v4(), nPort);
	amhs_dev_server* DevServer = new amhs_dev_server(io_service, endpoint);
	pServer = amhs_server_ptr(DevServer);
	t = boost::thread(boost::bind(&boost::asio::io_service::run, &io_service));

	return 0;
}

int AMHS_Server::Close()
{
	t.join();
	return 0;
}