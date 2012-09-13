#pragma once

class CMesLink;
class CSource;
class CReceiver;
class CSqlAceCli;
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
	CSqlAceCli* m_pSqlAce;
	CReceiver *receiver;
	CGuiHub* m_pGuiHub;
	CSource *source;
};

