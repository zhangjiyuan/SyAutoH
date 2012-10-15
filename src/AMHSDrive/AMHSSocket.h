#pragma once

#define AMHSSOCKET_SENDBUF_SIZE 131078
#define AMHSSOCKET_RECVBUF_SIZE 16384

class AMHSPacket;
//class SocketHandler;

enum OUTPACKET_RESULT
{
	OUTPACKET_RESULT_SUCCESS = 1,
	OUTPACKET_RESULT_NO_ROOM_IN_BUFFER = 2,
	OUTPACKET_RESULT_NOT_CONNECTED = 3,
	OUTPACKET_RESULT_SOCKET_ERROR = 4,
};

class AMHSSocket : public Socket
{
public:
	AMHSSocket(SOCKET fd);
	~AMHSSocket(void);

	//  - send null on empty buffer
	inline void SendPacket(AMHSPacket* packet) 
	{ 
		if(!packet) return; 
		OutPacket(packet->GetOpcode(), packet->size(), (packet->size() ? (const void*)packet->contents() : NULL)); 
	}

	void  OutPacket(uint16 opcode, size_t len, const void* data);
	OUTPACKET_RESULT  _OutPacket(uint16 opcode, size_t len, const void* data);
	
	void OnConnect();
	void OnDisconnect();
	void OnRead();

private:
	uint32 mOpcode;
	uint32 mRemaining;
	uint32 mSize;
	uint32 mSeed;
	uint32 mClientSeed;
	uint32 mClientBuild;
	uint32 mRequestID;

	Mutex queueLock;
	FastQueue<AMHSPacket*, DummyLock> _queue;
};

