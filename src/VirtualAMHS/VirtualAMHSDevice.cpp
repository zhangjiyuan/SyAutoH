#include "StdAfx.h"
#include "VirtualAMHSDevice.h"


VirtualAMHSDevice::VirtualAMHSDevice(void)
{
}


VirtualAMHSDevice::~VirtualAMHSDevice(void)
{
}

int VirtualAMHSDevice::Init(string strIP, int nPort)
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


int VirtualAMHSDevice::Clean(void)
{
	pclient->close();
	t.join();
	delete pclient;

	return 0;
}

int VirtualAMHSDevice::SendPacket(AMHSPacket& packet)
{
	amhs_message msg;
	
	msg.body_length(packet.size());
	msg.command(packet.GetOpcode());
	memcpy(msg.body(), packet.contents(), msg.body_length());
	msg.encode_header();
	pclient->write(msg);
	pclient->write(msg);

	return 0;
}