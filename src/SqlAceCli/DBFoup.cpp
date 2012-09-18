#include "StdAfx.h"
#include "SqlAceCli.h"
#include "TFoup.h"

DBFoup::DBFoup(void)
{
}


DBFoup::~DBFoup(void)
{
}

int DBFoup::AddFoup(const WCHAR* sFoupID, const WCHAR* sLot, int nLocal, int nType)
{
	CoInitialize(NULL);
	HRESULT hr;
	int nFoup = 0;

	CFoupTable tableFoup;
	hr = tableFoup.OpenDataSource();
	if (FAILED(hr))
	{
		cout << "Open Foup Failed." << endl;
		CoUninitialize();
		return -1;
	}

	CString strFind = L"SELECT * From Foup where FoupID = '#@#'";
	strFind.Replace(L"#@#", sFoupID);
	hr = tableFoup.Open(tableFoup.m_session, strFind);
	if (FAILED(hr))
	{
		cout << "Open Foup Failed." << endl;
		CoUninitialize();
		return -1;
	}

	if(tableFoup.MoveFirst() != DB_S_ENDOFROWSET)
	{
		tableFoup.CloseAll();
		CoUninitialize();
		return -1;
	}
	tableFoup.CloseAll();

	hr = tableFoup.OpenAll();
	if (FAILED(hr))
	{
		CoUninitialize();
		return -1;
	}

	// insert record
	CString strFoupID;
	strFoupID = sFoupID;
	CString strLot;
	strLot = sLot;
	wcscpy_s(tableFoup.m_FoupID, strFoupID);
	tableFoup.m_dwFoupIDLength = strFoupID.GetLength() * 2;
	wcscpy_s(tableFoup.m_Lot, strLot);
	tableFoup.m_dwLotLength = strLot.GetLength() * 2;
	tableFoup.m_Local = nLocal;
	tableFoup.m_Type = nType;
	tableFoup.m_dwIDStatus = DBSTATUS_S_IGNORE;
	tableFoup.m_dwLocalStatus = DBSTATUS_S_OK;
	tableFoup.m_dwTypeStatus = DBSTATUS_S_OK;
	tableFoup.m_dwLotStatus = DBSTATUS_S_OK;
	tableFoup.m_dwFoupIDStatus = DBSTATUS_S_OK;
	tableFoup.Insert();

	int nRet = 0;
	if (FAILED(hr))
	{
		nRet = -1;
	}
	else
	{
		tableFoup.UpdateAll();
	}
	
	CoUninitialize();

	return nRet;
}
int DBFoup::FindFoup(const WCHAR* sFoupID)
{
	CoInitialize(NULL);
	HRESULT hr;
	int nFoup = 0;

	CFoupTable tableFoup;
	hr = tableFoup.OpenDataSource();
	if (FAILED(hr))
	{
		cout << "Open Foup Failed." << endl;
		CoUninitialize();
		return -1;
	}

	CString strFind = L"SELECT * From Foup where FoupID = '#@#'";
	strFind.Replace(L"#@#", sFoupID);
	hr = tableFoup.Open(tableFoup.m_session, strFind);
	if (FAILED(hr))
	{
		cout << "Open Foup Failed." << endl;
		CoUninitialize();
		return -1;
	}

	if(tableFoup.MoveFirst() != DB_S_ENDOFROWSET)
	{
		nFoup = tableFoup.m_ID;
	}
	tableFoup.CloseAll();
	CoUninitialize();

	return nFoup;
}
int DBFoup::SetFoupLocation(int nFoup, int nLocal, int nType)
{
	CoInitialize(NULL);
	HRESULT hr;

	CFoupTable tableFoup;
	hr = tableFoup.OpenDataSource();
	if (FAILED(hr))
	{
		cout << "Open Foup Failed." << endl;
		return -1;
	}

	CString strFind = L"";
	strFind.Format(L"SELECT * From Foup where ID = %d", nFoup);
	hr = tableFoup.Open(tableFoup.m_session, strFind);
	if (FAILED(hr))
	{
		cout << "Open Foup Failed." << endl;
		return -1;
	}

	if(tableFoup.MoveFirst() != DB_S_ENDOFROWSET)
	{
		tableFoup.m_Local = nLocal;
		tableFoup.m_Type = nType;
		hr = tableFoup.SetData();
		tableFoup.UpdateAll();
	}
	tableFoup.CloseAll();
	CoUninitialize();
	return 0;
}
int DBFoup::GetFoupLocation(int nFoup, int &nLocal, int &nType)
{
	CoInitialize(NULL);
	HRESULT hr;

	CFoupTable tableFoup;
	hr = tableFoup.OpenDataSource();
	if (FAILED(hr))
	{
		cout << "Open Foup Failed." << endl;
		return -1;
	}

	CString strFind = L"";
	strFind.Format(L"SELECT * From Foup where ID = %d", nFoup);
	hr = tableFoup.Open(tableFoup.m_session, strFind);
	if (FAILED(hr))
	{
		cout << "Open Foup Failed." << endl;
		return -1;
	}

	if(tableFoup.MoveFirst() != DB_S_ENDOFROWSET)
	{
		nLocal = tableFoup.m_Local;
		nType = tableFoup.m_Type;
	}
	tableFoup.CloseAll();
	CoUninitialize();

	return 0;
}