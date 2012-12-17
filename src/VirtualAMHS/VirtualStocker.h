#pragma once
#include "VirtualAMHSDevice.h"

class VirtualFoup
{
public:
	int nID;
	int nStatus;
	int nBatchID;
	int nRoomID;

	VirtualFoup()
		: nStatus(0),
		nID(0),
		nBatchID(0),
		nRoomID(0)
	{

	}
};
typedef struct
{
	int nStatus;
	int nFoupID;
};
typedef std::map<int, VirtualFoup> MAP_VFOUP;
typedef std::map<int,uint8> MAP_VROOM;

class VirtualStocker : public VirtualAMHSDevice
{
public:
	VirtualStocker(void);
	virtual ~VirtualStocker(void);

public:
	virtual void HandleCommand(AMHSPacket& packet);

public:
	int Auth( const char* sIP);
	int ManualInputFoup( const TCHAR* sFoupID);
	int ManualOutputFoup( const TCHAR* sFoupID);
	int UpdateStatus();
	int UpdateFoupInfo();
	void CreateTimer(void);
	void DestoryTimer(void);
	static void CALLBACK TimerHandler(UINT id, UINT msg, DWORD dwUser, DWORD dw1, DWORD dw2);
	void OnTimer(void);
	int History();
	int m_nContain;
	int m_nWholeRoomStatus;
	int m_nTimerID;
	int m_nTimeCounter;
	int m_nMoveStatus;
	uint64 m_nMoveStatusTimeSet;
	uint64 m_nFoupInfoTimeSet;
private:
	void Handle_Auth(AMHSPacket& packet);
	void Handle_FoupOperate(AMHSPacket& packet);
	void Handle_StatusQuery(AMHSPacket& packet);
	void Handle_RoomQuery(AMHSPacket& packet);
	void Handle_StorageQuery(AMHSPacket& packet);
	void Handle_InputStatus(AMHSPacket& packet);
	void Handle_History(AMHSPacket& packet);
	void Handle_Alarms(AMHSPacket& packet);
	void Handle_StatusBackTime(AMHSPacket& packet);
	void Handle_FoupBackTime(AMHSPacket& packet);
	void Handle_AuthBack(AMHSPacket& packet);

private:
	typedef void (VirtualStocker::*CommandHander)(AMHSPacket& packet);
	typedef std::map<int, CommandHander> OPT_MAP;
	int GetRoomStatus();
	int FoupIntoRoom(int nID,int nBatchID);
	OPT_MAP m_optHanders;
	MAP_VFOUP m_mapFoups;
	MAP_VROOM m_mapRooms;
};

