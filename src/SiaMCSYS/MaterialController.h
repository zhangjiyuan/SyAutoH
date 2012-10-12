#pragma once

#include "../MesLink/MesLink.h"
#include "../SqlAceCli/SqlAceCli.h"
#include "../GuiHub/GuiHub.h"
#include "../AMHSDrive/AMHSDrive.h"

[event_receiver(native)]
class CReceiver 
{
public:
	DBFoup* m_pFoupDB;

	void MESHanderPick(const WCHAR* sName, int nLoc, int nLocType)
	{
		wprintf_s(L"FoupPick was called with value %s %d %d.\n", sName, nLoc, nLocType);
		int nOHT = 0;
		int nStocker = 0;
		int nFoup = m_pFoupDB->FindFoup(sName);

		if (nFoup > 0)
		{
			int nLocal = 0;
			int nType = 0;
			m_pFoupDB->GetFoupLocation(nFoup, nLocal, nType);
			wprintf_s(L"Find Foup: %s at Location: %d Type: %d.\n", 
				sName, nLocal, nType);

			m_pFoupDB->SetFoupLocation(nFoup, nLocal, nType);
			wprintf_s(L"Find Foup: %s at Location: %d Type: %d.\n", 
				sName, nLocal, nType);
		}
		else
		{
			wprintf_s(L"Can not Fine Foup %s.\n", sName);
		}
	}

	void MESHanderPlace(const WCHAR* sName, int nLoc, int nLocType)
	{
		wprintf_s(L"FoupPlace was called with value %s %d %d.\n", sName, nLoc, nLocType);
		int nOHT = 0;
		int nStocker = 0;
		int nFoup = m_pFoupDB->FindFoup(sName);

		if (nFoup > 0)
		{
			int nLocal = 0;
			int nType = 0;
			m_pFoupDB->GetFoupLocation(nFoup, nLocal, nType);
			wprintf_s(L"Find Foup: %s at Location: %d Type: %d.\n", 
				sName, nLocal, nType);
		}
		else
		{
			wprintf_s(L"Can not Fine Foup %s.\n", sName);
		}
	}

	void hookEvent(CSource* pSource) 
	{
		__hook(&CSource::MESPickFoup, pSource, &CReceiver::MESHanderPick);
		__hook(&CSource::MESPlaceFoup, pSource, &CReceiver::MESHanderPlace);
	}

	void unhookEvent(CSource* pSource) 
	{
		__unhook(&CSource::MESPickFoup, pSource, &CReceiver::MESHanderPick);
		__unhook(&CSource::MESPlaceFoup, pSource, &CReceiver::MESHanderPlace);
	}
};

class MaterialController 
{
public:
	MaterialController(void);
	~MaterialController(void);

public:
	int Init(void);
	void Run(void);

private:
	CMesLink m_MesLink;
	DBFoup m_FoupDB;
	CReceiver m_MesReciver;
	CGuiHub m_GuiHub;
	CSource m_MesSource;
	CAMHSDrive m_amhsDrive;
public:
	void PrintfInfo(void);
};

