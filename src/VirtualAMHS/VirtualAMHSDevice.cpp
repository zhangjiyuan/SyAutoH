#include "StdAfx.h"
#include "VirtualAMHSDevice.h"


VirtualAMHSDevice::VirtualAMHSDevice(void)
	: pclient(NULL),
	m_nID(0)
{
	
}


VirtualAMHSDevice::~VirtualAMHSDevice(void)
{
	Close();
}

void VirtualAMHSDevice::PassCommand(void* pDevice, AMHSPacket& packet)
{
	VirtualAMHSDevice* pVirtualDev = static_cast<VirtualAMHSDevice*>(pDevice);
	pVirtualDev->HandleCommand(packet);
}

//void VirtualAMHSDevice::HandleCommand(AMHSPacket& packet)
//{
//	printf("VirtualAMHSDevice::HandleCommand: %d \n", packet.GetOpcode());
//	OPT_MAP::iterator it = m_optHanders.find(packet.GetOpcode());
//	if (it != m_optHanders.end())
//	{
//		it->second(packet);
//	}
//}

int VirtualAMHSDevice::Connect(string strIP, int nPort)
{
	if (NULL != pclient)
	{
		return -1;
	}
	char buf[10] = "";
	_itoa_s(nPort, buf, 10);
	tcp::resolver resolver(io_service);
	tcp::resolver::query query(strIP, buf);
	tcp::resolver::iterator iterator = resolver.resolve(query);

	pclient = new amhs_client(io_service, iterator);
	pclient->m_pHandleCommand = (ProcessCommand)&VirtualAMHSDevice::PassCommand;
	pclient->m_pVirtualDevice = this;

	t = boost::thread(boost::bind(&boost::asio::io_service::run, &io_service));

	return 0;
}


int VirtualAMHSDevice::Close(void)
{
	pclient->close();
	t.join();
	delete pclient;
	pclient = NULL;

	return 0;
}

int VirtualAMHSDevice::SendPacket(AMHSPacket& packet)
{
	amhs_message msg;
	
	msg.body_length(packet.size());
	msg.command(packet.GetOpcode());
	msg.IsNeedRespond(true);
	memcpy(msg.body(), packet.contents(), msg.body_length());
	msg.encode_header();
	pclient->write(msg);

	return 0;
}