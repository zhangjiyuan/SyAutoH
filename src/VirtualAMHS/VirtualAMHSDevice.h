#pragma once
class VirtualAMHSDevice
{
public:
	VirtualAMHSDevice(void);
	virtual ~VirtualAMHSDevice(void);

public:
	int Init(string strIP, int nPort);
	int Clean(void);
	int SendPacket(AMHSPacket& packet);

private:
	amhs_client* pclient;
	boost::asio::io_service io_service;
	boost::thread t;
};

