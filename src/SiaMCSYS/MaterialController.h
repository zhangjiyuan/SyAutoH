#pragma once

class CMesLink;
class CSource;
class CReceiver;
class CSqlAceCli;
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
	CSource *source;
};

