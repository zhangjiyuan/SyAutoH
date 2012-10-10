// AMHSDrive.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "Common.h"
#include "../shared/Network.h"
#include "AMHSDrive.h"

#include "AMHSPacket.h"



// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 AMHSDrive.h
CAMHSDrive::CAMHSDrive()
{

	return;
}

int CAMHSDrive::Init()
{
	new SocketMgr;
	return 0;
}

int CAMHSDrive::SetOHTLocation(int nPoint)
{
	AMHSPacket oht(0x0817, 512);

	oht << (uint8)253;
	oht << (uint16)65535;

	oht.hexlike();

	

	uint32 dwCode;
	uint8 nOht;
	uint16 nPt;
	oht >> dwCode;
	oht >> nOht;
	oht >> nPt;

	oht.Initialize(45);
	oht.hexlike();

	return 0;
}