#include "StdAfx.h"
#include "VirtualAMHSDevice.h"


VirtualAMHSDevice::VirtualAMHSDevice(void)
	: m_pClient(NULL),
	m_nID(0),
	m_isOnline(false)
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
	if (NULL != m_pClient)
	{
		return -1;
	}
	m_sIP = strIP;
	m_nPort = nPort;

	char buf[10] = "";
	_itoa_s(nPort, buf, 10);
	tcp::resolver resolver(m_io_service);
	tcp::resolver::query query(strIP, buf);
	tcp::resolver::iterator iterator = resolver.resolve(query);

	m_pClient = new amhs_client(m_io_service, iterator);
	m_pClient->m_pHandleCommand = (ProcessCommand)&VirtualAMHSDevice::PassCommand;
	m_pClient->m_pVirtualDevice = this;

	m_thread = boost::thread(boost::bind(&boost::asio::io_service::run, &m_io_service));

	return 0;
}


int VirtualAMHSDevice::Close(void)
{
	m_pClient->close();
	m_thread.join();
	delete m_pClient;
	m_pClient = NULL;

	return 0;
}

int VirtualAMHSDevice::SendPacket(AMHSPacket& packet)
{
	/*bool bConnect = false;
	if (false == bConnect)
	{
	Close();
	Connect(m_sIP, m_nPort);
	}*/
	amhs_message msg;
	
	msg.body_length(packet.size());
	msg.command(packet.GetOpcode());
	msg.IsNeedRespond(true);
	memcpy(msg.body(), packet.contents(), msg.body_length());
	msg.encode_header();
	m_pClient->write(msg);

	return 0;
}