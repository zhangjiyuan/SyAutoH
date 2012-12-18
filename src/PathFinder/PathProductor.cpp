#include "StdAfx.h"
#include "PathProductor.h"

initialiseSingleton(CPathProductor);
CPathProductor::CPathProductor(void)
{
	sLog.outBasic("Path Productor is Started.");
}


CPathProductor::~CPathProductor(void)
{
}


void CPathProductor::GetLaneData(void)
{
	DBLane dbLane;
	m_vecLane = dbLane.GetLaneTable(1);

	for (auto it = m_vecLane.cbegin();
		it != m_vecLane.cend(); ++it)
	{
		printf("Lane: %d, s: %d e: %d, p: %d n: %d, f: %d, t: %d, l: %d\r\n",
			it->nID, it->nStart, it->nEnd, it->nPrevLane, it->nNextLane, it->nNextFork, it->nType, 
			it->nLength);
	}
}
