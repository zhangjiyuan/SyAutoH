#pragma once

class CMesLink;
class MaterialController
{
public:
	MaterialController(void);
	~MaterialController(void);
	int Init(void);
	void Run(void);
private:
	CMesLink* m_pMesLink;
};

