#pragma once
#include "VirtualAMHSDevice.h"
typedef struct 
{
	int nposition;
	int nType;
	int nSpeed;
} PathInfo;
typedef std::map<int,PathInfo*> PATH_SET_MAP;
class VirtualOHT : public VirtualAMHSDevice
{
public:
	VirtualOHT(void);
	virtual ~VirtualOHT(void);
	
public:
	int Auth( uint32 nPos, int nHand);
	int UpdatePos();
	int UpdateStatus();
	int SetTeachPosition(uint32 nPos, uint8 nType, uint8 nSpeedRate);

	virtual void HandleCommand(AMHSPacket& packet);

private:
	void Handle_Auth(AMHSPacket& );
	void Handle_SetPosTime(AMHSPacket& );
	void Handle_SetStatusTime(AMHSPacket& );
	void Handle_FoupHanding(AMHSPacket& );
	void Handle_SetPath(AMHSPacket& );
	
private:
	typedef void (VirtualOHT::*CommandHander)(AMHSPacket& packet);
	typedef std::map<int, CommandHander> OPT_MAP;
	OPT_MAP m_optHanders;
	PATH_SET_MAP m_mapPath;

public:
	bool isSetPath;
	int m_nHand;
	DWORD m_nPos;
	int m_nPosUpdateTimeSet;
	int m_nStatusUpdateTimeSet;
	int m_nTimerID;
	int m_nTimeCounter;
	void CreateTimer(void);
	void DestoryTimer(void);
	static void CALLBACK TimerHandler(UINT id, UINT msg, DWORD dwUser, DWORD dw1, DWORD dw2);
	void OnTimer(void);
};

