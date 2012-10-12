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
	
	int getID() const { return m_nID; }
	void getID(int val) { m_nID = val; }

private:
	amhs_client* pclient;
	boost::asio::io_service io_service;
	boost::thread t;

	int m_nID;
	
};

