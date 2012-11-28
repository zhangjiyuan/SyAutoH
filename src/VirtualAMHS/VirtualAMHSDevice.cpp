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
	if (NULL != m_pClient)
	{
		m_pClient->close();
		m_thread.join();
		delete m_pClient;
		m_pClient = NULL;
	}
	m_isOnline = false;

	return 0;
}

int VirtualAMHSDevice::SendPacket(AMHSPacket& packet)
{
	if (NULL == m_pClient)
	{
		return -1;
	}

	try
	{
		if (m_pClient->isClosed())
		{
			return -1;
		}

		m_pClient->write_packet(packet);
	}
	catch(...)
	{

	}

	return 0;
}