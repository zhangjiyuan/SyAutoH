#include "StdAfx.h"
#include "VirtualOHT.h"


VirtualOHT::VirtualOHT(void)
{
}


VirtualOHT::~VirtualOHT(void)
{
	Clean();
}


int VirtualOHT::Init(string strIP, int nPort)
{
	char buf[10] = "";
	 _itoa_s(nPort, buf, 10);
	tcp::resolver resolver(io_service);
	tcp::resolver::query query(strIP, buf);
	tcp::resolver::iterator iterator = resolver.resolve(query);

	pclient = new amhs_client(io_service, iterator);

	t = boost::thread(boost::bind(&boost::asio::io_service::run, &io_service));

	return 0;
}


int VirtualOHT::Clean(void)
{
	pclient->close();
	t.join();
	delete pclient;

	return 0;
}


int VirtualOHT::Auth(int nID, int nPos, int nHand)
{
	amhs_message msg;
	AMHSPacket authPacket(0x0816, 4);
	authPacket<< uint8(nID);		// oht id
	authPacket<< uint16(nPos);		// oht location
	authPacket<< uint8(nHand);				// oht hand status;

	msg.body_length(authPacket.size());
	msg.command(authPacket.GetOpcode());
	memcpy(msg.body(), authPacket.contents(), msg.body_length());
	msg.encode_header();
	pclient->write(msg);

	return 0;
}
