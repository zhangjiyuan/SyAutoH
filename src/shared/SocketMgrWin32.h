/*
 * Multiplatform Async Network Library
 * Copyright (c) 2007 Burlex
 *
 * SocketMgr - iocp-based SocketMgr for windows.
 *
 */


#ifndef SOCKETMGR_H_WIN32
#define SOCKETMGR_H_WIN32

#ifdef CONFIG_USE_IOCP

class Socket;
class  SocketMgr : public Singleton<SocketMgr>
{
	public:
		SocketMgr();
		~SocketMgr();

		inline HANDLE GetCompletionPort() { return m_completionPort; }
		void SpawnWorkerThreads();
		void CloseAll();
		void ShowStatus();
		void AddSocket(Socket* s)
		{
			socketLock.Acquire();
			_sockets.insert(s);
			++socket_count;
			socketLock.Release();
		}

		void RemoveSocket(Socket* s)
		{
			socketLock.Acquire();
			_sockets.erase(s);
			--socket_count;
			socketLock.Release();
		}

		void ShutdownThreads();
		long threadcount;

	private:
		HANDLE m_completionPort;
		set<Socket*> _sockets;
		Mutex socketLock;
		syamhs::Threading::AtomicCounter socket_count;
};

#define sSocketMgr SocketMgr::getSingleton()

typedef void(*OperationHandler)(Socket* s, uint32 len);

class SocketWorkerThread : public ThreadBase
{
	public:
		bool run();
};

void  HandleReadComplete(Socket* s, uint32 len);
void  HandleWriteComplete(Socket* s, uint32 len);
void  HandleShutdown(Socket* s, uint32 len);

static OperationHandler ophandlers[NUM_SOCKET_IO_EVENTS] =
{
	&HandleReadComplete,
	&HandleWriteComplete,
	&HandleShutdown
};

#endif
#endif