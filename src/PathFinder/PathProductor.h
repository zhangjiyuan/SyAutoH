#pragma once
#include "../shared/Singleton.h"
#pragma comment(lib, "shared.lib")

#include "../SqlAceCli/SqlAceCli.h"


class CPathProductor;
class CPathProductor  : public Singleton<CPathProductor>
{
public:
	CPathProductor(void);
	~CPathProductor(void);
private:
	VEC_LANE m_vecLane;
public:
	void GetLaneData(void);
};

#define sPathProductor CPathProductor::getSingleton()