#pragma once
class VirtualOHT
{
public:
	VirtualOHT(void);
	~VirtualOHT(void);
	int Init(string strIP, int nPort);
	int Clean(void);
	int Auth(int nID, int nPos, int nHand);

private:
		amhs_client* pclient;
		boost::asio::io_service io_service;
		boost::thread t;
};

