// AMHSDrive.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"

#include "Common.h"

#include "AMHS_Server.h"
#include "AMHSDrive.h"

#include "AMHSPacket.h"


// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 AMHSDrive.h
CAMHSDrive::CAMHSDrive()
{
	
}

CAMHSDrive::~CAMHSDrive()
{
	Clean();
}

int CAMHSDrive::Init()
{
	// using asio
	new AMHS_Server;
	sAmhsServer.Start(9999);

	return 0;
}

void CopyOHTStruct(driveOHT& target, amhs_oht_ptr& src)
{
	target.nID = src->nID;
	target.nPOS = src->nPOS;
	target.nHand  = src->nHand;
	target.nStatusTime = src->nStatusTime;
	target.nPosTime = src->nPosTime;
	target.nPathResult = src->nPathResult;
	target.nMoveStatus = src->nMoveStatus;
	target.nMoveAlarm = src->nMoveAlarm;
	target.nFoupOpt = src->nFoupOpt;
	target.nBackStatusMode = src->nBackStatusMode;
	target.nBackStatusMark = src->nBackStatusMark;
	target.nBackStausAlarm = src->nBackStausAlarm;
	target.bNeedPath = src->bNeedPath;
	target.strIp = src->p_participant->sIP_;
	target.uPort = src->p_participant->uPort_;
}

DR_OHT_LIST CAMHSDrive::GetOhtList()
{
	DR_OHT_LIST list;
	amhs_oht_set oht_set = sAmhsServer.GetServer()->OHT_GetDataSet();
	for (amhs_oht_set::iterator it = oht_set.begin(); 
		it != oht_set.end(); ++it)
	{
		amhs_oht_ptr sp_oht = *it;
		driveOHT dOht;
		CopyOHTStruct(dOht, sp_oht);
		list.push_back(dOht);
	}
	return list;
}

int CAMHSDrive::Check()
{
	/*while(1)
	{
	ThreadPool.ShowStats();
	Sleep(5000);
	}*/
	/*while(1)
	{
	sSocketMgr.ShowStatus();
	Sleep(1000);
	}*/

	//int nCount = sAmhsServer.GetConnectedCount();
	//printf("amhs dev connected: %d\n", nCount);

	return 0;
}

int CAMHSDrive::Clean()
{
	//sSocketMgr.ShutdownThreads();
	//sSocketMgr.CloseAll();
	//delete SocketMgr::getSingletonPtr();
	//delete SocketGarbageCollector::getSingletonPtr();

	//ThreadPool.Shutdown();
	delete AMHS_Server::getSingletonPtr();
	return 0;
}

void CAMHSDrive::OHTStatusBackTime(int nID, int ms)
{
	sAmhsServer.GetServer()->OHT_Set_StatusBackTime(nID, ms);
}
void CAMHSDrive::OHTPosBackTime(int nID, int ms)
{
	sAmhsServer.GetServer()->OHT_Set_PosBackTime(nID, ms);
}
void CAMHSDrive::OHTMove(int nID, int nControl)
{
	sAmhsServer.GetServer()->OHT_Move(nID, nControl);
}
void CAMHSDrive::OHTFoup(int nID, int nDevBuf, int nOperation)
{
	sAmhsServer.GetServer()->OHT_Foup(nID, nDevBuf, nOperation);
}
void CAMHSDrive::OHTSetPath(int nID, int nType, int nStart, int nTarget, PATH_POINT_LIST& KeyPoints)
{
	//sAmhsServer.GetServer()->OHT_SetPath();
	amhs_keypoint_vec keyPts;
	for(PATH_POINT_LIST::iterator it = KeyPoints.begin();
		it != KeyPoints.end(); ++it)
	{
		amhs_keyPoint kPt;
		kPt.nPos = it->nPos;
		kPt.nType = it->nType;
		kPt.nSpeedRate = it->nSpeedRate;

		keyPts.push_back(kPt);
	}
	sAmhsServer.GetServer()->OHT_SetPath(nID, nType, nStart, nTarget, keyPts);
}

void CAMHSDrive::STKFoup(int nID, int nOpt, int nMode, int nData)
{
	sAmhsServer.GetServer()->STK_FOUP(nID, nOpt, nMode, nData);
}

void CAMHSDrive::STKStatusBackTime(int nID, int ms)
{
	sAmhsServer.GetServer()->STK_Set_StatusBackTime(nID, ms);
}

int CAMHSDrive::SetOHTLocation(int nPoint)
{

	return 0;
}

