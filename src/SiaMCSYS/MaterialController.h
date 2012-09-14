#pragma once

class CMesLink;
class CSource;
class CReceiver;
class DBFoup;
class CGuiHub;
class MaterialController
{
public:
	MaterialController(void);
	~MaterialController(void);
	int Init(void);
	void Run(void);
private:
	CMesLink* m_pMesLink;
	DBFoup* m_pFoupDB;
	CReceiver *receiver;
	CGuiHub* m_pGuiHub;
	CSource *source;
};

