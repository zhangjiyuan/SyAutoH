#include "StdAfx.h"
#include "MetaMoveCtrlServer.h"
#include <signal.h>
#include "MaterialController.h"
#include "AtomicBoolean.h"
#include <iostream>

using namespace std;

AtomicBoolean mrunning(true);

/*** Signal Handler ***/
void _OnSignal(int s)
{
	switch(s)
	{
	case SIGINT:
	case SIGTERM:
	case SIGABRT:
#ifdef _WIN32
	case SIGBREAK:
#endif
		mrunning.SetVal(false);
		break;
	}

	signal(s, _OnSignal);
}

void MetaMoveCtrlServer::Stop()
{
}

void MetaMoveCtrlServer::Run(int argc, _TCHAR** argv)
{
	//if(authsockcreated && intersockcreated)
	{
		// hook signals
		signal(SIGINT, _OnSignal);
		signal(SIGTERM, _OnSignal);
		signal(SIGABRT, _OnSignal);
#ifdef _WIN32
		signal(SIGBREAK, _OnSignal);
#else
		signal(SIGHUP, _OnSignal);
#endif

		//		/* write pid file */
		//		FILE* fPid = fopen("logonserver.pid", "w");
		//		if(fPid)
		//		{
		//			uint32 pid;
		//#ifdef WIN32
		//			pid = GetCurrentProcessId();
		//#else
		//			pid = getpid();
		//#endif
		//			fprintf(fPid, "%u", (unsigned int)pid);
		//			fclose(fPid);
		//		}
		//		uint32 loop_counter = 0;
		//ThreadPool.Gobble();
		//sLog.outString("Success! Ready for connections");

		cout<< "Material Control System V1.0.0.1 \n\n\n" << endl;
		MaterialController MC;
		if (0 != MC.Init())
		{
			cout<< "MCS Init failed." << endl;
			return;
		}

		MC.Run();

		while(mrunning.GetVal())
		{
			//if(!(++loop_counter % 20))	 // 20 seconds
			//	CheckForDeadSockets();

			//if(!(loop_counter % 300))	// 5mins
			//	ThreadPool.IntegrityCheck();

			//if(!(loop_counter % 5))
			//{
			//	sInfoCore.TimeoutSockets();
			//	sSocketGarbageCollector.Update();
			//	CheckForDeadSockets();			  // Flood Protection
			//	UNIXTIME = time(NULL);
			//	g_localTime = *localtime(&UNIXTIME);
			//}

			//PatchMgr::getSingleton().UpdateJobs();

			//wprintf_s(L"MCS Running.\n");

			Sleep(1000);
		}

		//sLog.outString("Shutting down...");
		wprintf_s(L"Shutting down....\n");
		signal(SIGINT, 0);
		signal(SIGTERM, 0);
		signal(SIGABRT, 0);
#ifdef _WIN32
		signal(SIGBREAK, 0);
#else
		signal(SIGHUP, 0);
#endif
	}

}
