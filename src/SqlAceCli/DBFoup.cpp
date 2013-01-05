#include "StdAfx.h"
#include "SqlAceCli.h"
#include "TFoup.h"

DBFoup::DBFoup(void)
{
}


DBFoup::~DBFoup(void)
{
}

int DBFoup::AddFoup(int nBarCode, int nLot, const FoupLocation& location)
{
	CoInitialize(NULL);
	HRESULT hr;
	int nFoup = 0;

	CTableFoup tableFoup;
	hr = tableFoup.OpenDataSource();
	if (FAILED(hr))
	{
		cout << "Open Foup Failed." << endl;
		CoUninitialize();
		return -1;
	}
	CString strFind = L"";
	strFind.Format(L"SELECT * From Foup where BarCode = '%d'", nBarCode);
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
	tableFoup.m_BarCode = nBarCode;
	tableFoup.m_Lot = nLot;
	tableFoup.m_Status = 0;
	tableFoup.m_Location = location.nLocation;
	tableFoup.m_LocationType = location.nLocType;
	tableFoup.m_Carrier = location.nCarrier;
	tableFoup.m_Port = location.nPort;


	tableFoup.m_dwIDStatus = DBSTATUS_S_IGNORE;
	tableFoup.m_dwBarCodeStatus = DBSTATUS_S_OK;
	tableFoup.m_dwLotStatus = DBSTATUS_S_OK;
	tableFoup.m_dwLocationStatus = DBSTATUS_S_OK;
	tableFoup.m_dwLocationTypeStatus = DBSTATUS_S_OK;
	tableFoup.m_dwStatusStatus = DBSTATUS_S_OK;
	tableFoup.m_dwCarrierStatus = DBSTATUS_S_OK;
	tableFoup.m_dwPortStatus = DBSTATUS_S_OK;

	hr = tableFoup.Insert();

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
int DBFoup::FindFoup(int nBarCode)
{
	CoInitialize(NULL);
	HRESULT hr;
	int nFoup = 0;

	CTableFoup tableFoup;
	hr = tableFoup.OpenDataSource();
	if (FAILED(hr))
	{
		cout << "Open Foup Failed." << endl;
		CoUninitialize();
		return -1;
	}

	CString strFind = L"";
	strFind.Format(L"SELECT * From Foup where BarCode = '%d'", nBarCode);
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
int DBFoup::SetFoupLocation(int nFoup, const FoupLocation& location)
{
	CoInitialize(NULL);
	HRESULT hr;

	CTableFoup tableFoup;
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
		tableFoup.m_Location = location.nLocation;
		tableFoup.m_LocationType = location.nLocType;
		tableFoup.m_Carrier = location.nCarrier;
		tableFoup.m_Port = location.nPort;
		hr = tableFoup.SetData();
		tableFoup.UpdateAll();
	}
	tableFoup.CloseAll();
	CoUninitialize();
	return 0;
}
int DBFoup::GetFoupLocation(int nFoup, FoupLocation& location)
{
	CoInitialize(NULL);
	HRESULT hr;

	CTableFoup tableFoup;
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
		location.nLocation = tableFoup.m_Location;
		location.nLocType = tableFoup.m_LocationType;
		location.nCarrier = tableFoup.m_Carrier;
		location.nPort = tableFoup.m_Port;
	}
	tableFoup.CloseAll();
	CoUninitialize();

	return 0;
}

VEC_FOUP DBFoup::GetFoupTable()
{
	VEC_FOUP foupList;
	CoInitialize(NULL);
	HRESULT hr;

	CTableFoup tableFoup;
	hr = tableFoup.OpenAll();
	if (FAILED(hr))
	{
		cout << "Open Foup Failed." << endl;
		return foupList;
	}

	while(tableFoup.MoveNext() != DB_S_ENDOFROWSET)
	{
		FoupItem foupItem;
		foupItem.nBarCode = tableFoup.m_BarCode;
		foupItem.nLot = tableFoup.m_Lot;
		foupItem.locFoup.nLocation = tableFoup.m_Location;
		foupItem.locFoup.nLocType = tableFoup.m_LocationType;
		foupItem.locFoup.nCarrier = tableFoup.m_Carrier;
		foupItem.locFoup.nPort = tableFoup.m_Port;
		foupItem.nStatus = tableFoup.m_Status;
		foupList.push_back(foupItem);
	}
	tableFoup.CloseAll();
	CoUninitialize();

	return foupList;
}