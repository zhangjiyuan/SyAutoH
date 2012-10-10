#include "StdAfx.h"
#include "AMHSPacket.h"
#include "AMHSSocket.h"

#pragma pack(push, 1)
struct ClientPktHeader
{
	uint16 size;
	uint32 cmd;
};

struct ServerPktHeader
{
	uint16 size;
	uint16 cmd;
};
#pragma pack(pop)

AMHSSocket::AMHSSocket(SOCKET fd)
	:
Socket(fd, AMHSSOCKET_SENDBUF_SIZE, AMHSSOCKET_RECVBUF_SIZE),
	//Authed(false),
	mOpcode(0),
	mRemaining(0),
	mSize(0),
	//mSeed(RandomUInt()),
	mRequestID(0)
	//mSession(NULL),
	//pAuthenticationPacket(NULL),
	//_latency(0),
	//mQueued(false),
	//m_nagleEanbled(false),
	//m_fullAccountName(NULL)
{
}


AMHSSocket::~AMHSSocket(void)
{
}

void AMHSSocket::OnConnect()
{
	//sWorld.mAcceptedConnections++;
	//_latency = getMSTime();

	AMHSPacket wp(12, 24);

	wp << uint32(1);
	wp << uint32(235);
	wp << uint32(0xC0FFEEEE);
	wp << uint32(0x00BABE00);
	wp << uint32(0xDF1697E5);
	wp << uint32(0x1234ABCD);
	wp.hexlike();
	SendPacket(&wp);

}

void AMHSSocket::OnDisconnect()
{
	//if(mSession)
	//{
	//	mSession->SetSocket(0);
	//	mSession = NULL;
	//}

	//if(mRequestID != 0)
	//{
	//	sLogonCommHandler.UnauthedSocketClose(mRequestID);
	//	mRequestID = 0;
	//}

	//if(mQueued)
	//{
	//	sWorld.RemoveQueuedSocket(this);	// Remove from queued sockets.
	//	mQueued = false;
	//}
}

void AMHSSocket::OnRead()
{
	for(;;)
	{
		// Check for the header if we don't have any bytes to wait for.
		if(mRemaining == 0)
		{
			if(readBuffer.GetSize() < 6)
			{
				// No header in the packet, let's wait.
				return;
			}

			// Copy from packet buffer into header local var
			ClientPktHeader Header;
			readBuffer.Read((uint8*)&Header, 6);

			// Decrypt the header
			//_crypt.DecryptRecv((uint8*)&Header, sizeof(ClientPktHeader));

			mRemaining = mSize = ntohs(Header.size) - 4;
			mOpcode = Header.cmd;
		}

		AMHSPacket* Packet;

		if(mRemaining > 0)
		{
			if(readBuffer.GetSize() < mRemaining)
			{
				// We have a fragmented packet. Wait for the complete one before proceeding.
				return;
			}
		}

		Packet = new AMHSPacket(static_cast<uint16>(mOpcode), mSize);
		Packet->resize(mSize);

		if(mRemaining > 0)
		{
			// Copy from packet buffer into our actual buffer.
			///Read(mRemaining, (uint8*)Packet->contents());
			readBuffer.Read((uint8*)Packet->contents(), mRemaining);
		}

		//sWorldLog.LogPacket(mSize, static_cast<uint16>(mOpcode), mSize ? Packet->contents() : NULL, 0, (mSession ? mSession->GetAccountId() : 0));
		mRemaining = mSize = mOpcode = 0;

		//// Check for packets that we handle
		//switch(Packet->GetOpcode())
		//{
		//case CMSG_PING:
		//	{
		//		_HandlePing(Packet);
		//		delete Packet;
		//	}
		//	break;
		//case CMSG_AUTH_SESSION:
		//	{
		//		_HandleAuthSession(Packet);
		//	}
		//	break;
		//default:
		//	{
		//		if(mSession) mSession->QueuePacket(Packet);
		//		else delete Packet;
		//	}
		//	break;
		//}
	}
}


void AMHSSocket::OutPacket(uint16 opcode, size_t len, const void* data)
{
	OUTPACKET_RESULT res;
	/*if((len + 10) > WORLDSOCKET_SENDBUF_SIZE)
	{
	LOG_ERROR("WARNING: Tried to send a packet of %u bytes (which is too large) to a socket. Opcode was: %u (0x%03X)", (unsigned int)len, (unsigned int)opcode, (unsigned int)opcode);
	return;
	}*/

	res = _OutPacket(opcode, len, data);
	if(res == OUTPACKET_RESULT_SUCCESS)
		return;

	if(res == OUTPACKET_RESULT_NO_ROOM_IN_BUFFER)
	{
		/* queue the packet */
		queueLock.Acquire();
		AMHSPacket* pck = new AMHSPacket(opcode, len);
		if(len) pck->append((const uint8*)data, len);
		_queue.Push(pck);
		queueLock.Release();
	}
}

OUTPACKET_RESULT AMHSSocket::_OutPacket(uint16 opcode, size_t len, const void* data)
{
	bool rv;
	if(!IsConnected())
		return OUTPACKET_RESULT_NOT_CONNECTED;

	BurstBegin();
	//if((m_writeByteCount + len + 4) >= m_writeBufferSize)
	if(writeBuffer.GetSpace() < (len + 4))
	{
		BurstEnd();
		return OUTPACKET_RESULT_NO_ROOM_IN_BUFFER;
	}

	// Packet logger :)
	//sWorldLog.LogPacket((uint32)len, opcode, (const uint8*)data, 1, (mSession ? mSession->GetAccountId() : 0));

	// Encrypt the packet
	// First, create the header.
	ServerPktHeader Header;

	Header.cmd = opcode;
	Header.size = ntohs((uint16)len + 2);

	//_crypt.EncryptSend((uint8*)&Header, sizeof(ServerPktHeader));

	// Pass the header to our send buffer
	rv = BurstSend((const uint8*)&Header, 4);

	// Pass the rest of the packet to our send buffer (if there is any)
	if(len > 0 && rv)
	{
		rv = BurstSend((const uint8*)data, (uint32)len);
	}

	if(rv) BurstPush();
	BurstEnd();
	return rv ? OUTPACKET_RESULT_SUCCESS : OUTPACKET_RESULT_SOCKET_ERROR;
}