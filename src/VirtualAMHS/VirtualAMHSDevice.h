#pragma once



class VirtualAMHSDevice
{
public:
	VirtualAMHSDevice(void);
	virtual ~VirtualAMHSDevice(void);

public:
	int Connect(string strIP, int nPort);
	int Close(void);
	int SendPacket(AMHSPacket& packet);
	
	int DeviceID() const { return m_nID; }
	void DeviceID(int val) { m_nID = val; }
	static void PassCommand(void* pDevice, AMHSPacket& packet);
	virtual void HandleCommand(AMHSPacket& packet) = 0;

	bool Online() const 
	{ 
		if (NULL != m_pClient)
		{
			return !m_pClient->isClosed();
		}
		else
		{
			return m_isOnline; 
		}
	}

private:
	amhs_client* m_pClient;
	boost::asio::io_service m_io_service;
	boost::thread m_thread;
	string m_sIP;
	int m_nPort;
	int m_nID;

protected:
	bool m_isOnline;
};

