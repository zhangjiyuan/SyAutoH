// VirualAMHS.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "VirualAMHS.h"
#include "amhs_client.h"

// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 VirualAMHS.h
boost::asio::io_service io_service;
boost::thread t;
CVirualAMHS::CVirualAMHS()
{
	tcp::resolver resolver(io_service);
	tcp::resolver::query query("127.0.0.1", "9999");
	tcp::resolver::iterator iterator = resolver.resolve(query);

	pclient = new amhs_client(io_service, iterator);
	
	t = boost::thread(boost::bind(&boost::asio::io_service::run, &io_service));
	return;
}

CVirualAMHS::~CVirualAMHS()
{
	pclient->close();
	t.join();
}

int CVirualAMHS::AddOHT(int nIndex)
{
	amhs_message msg;
	AMHSPacket authPacket(0x0816, 4);
	authPacket<< uint8(nIndex);		// oht id
	authPacket<< uint16(1001);		// oht location
	authPacket<< uint8(1);				// oht hand status;

	msg.body_length(authPacket.size());
	msg.command(authPacket.GetOpcode());
	memcpy(msg.body(), authPacket.contents(), msg.body_length());
	msg.encode_header();
	pclient->write(msg);

	return 0;
}
