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
	static void PassCommand(void* pDevice, AMHSPacket& packet);
	virtual void HandleCommand(AMHSPacket& packet) = 0;
private:
	amhs_client* pclient;
	boost::asio::io_service io_service;
	boost::thread t;

	int m_nID;

protected:
	
};

