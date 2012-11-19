#include "StdAfx.h"
#include "SqlAceCli.h"
#include "TKeyPoints.h"


DBKeyPoints::DBKeyPoints(void)
{
}


DBKeyPoints::~DBKeyPoints(void)
{
}

VEC_KEYPOINT DBKeyPoints::GetKeyPointsTable()
{
	VEC_KEYPOINT keyPTList;

	CoInitialize(NULL);
	HRESULT hr;
	CKeyPoints table;
	hr = table.OpenAll();
	if (FAILED(hr))
	{
		CoUninitialize();
		return keyPTList;
	}

	while(table.MoveNext() != DB_S_ENDOFROWSET)
	{
		KeyPointItem item;
		item.uPosition = table.m_Position;
		item.uType = table.m_Type;
		item.uSpeedRate = table.m_SpeedRate;
		item.uTeachMode = table.m_TeachMode;
		item.uOHT_ID = table.m_OHT_ID;
		item.uRail_ID = table.m_Rail_ID;
		item.uPrev = table.m_Prev;
		item.uNext = table.m_Next;
		item.strName = table.m_Name;
		keyPTList.push_back(item);
	}
	table.CloseAll();
	CoUninitialize();

	return keyPTList;
}

int DBKeyPoints::SetKeyPointbyOHTTeach(int nOHT_ID, int nPOS, int nType, int nSpeedRate)
{
	CoInitialize(NULL);
	HRESULT hr;
	int nFoup = 0;

	CKeyPoints table;
	hr = table.OpenDataSource();
	if (FAILED(hr))
	{
		cout << "Open KeyPoints Failed." << endl;
		CoUninitialize();
		return -1;
	}
	CDBPropSet propset(DBPROPSET_ROWSET);
	table.GetRowsetProperties(&propset);

	CString strSQL = L"";
	strSQL.Format(L"Select * from dbo.KeyPoints where (Position = %d)", nPOS);
	hr = table.Open(table.m_session, strSQL, &propset);
	if (FAILED(hr))
	{
		cout << "Open KeyPoints Failed." << endl;
		CoUninitialize();
		return -1;
	}

	if(table.MoveFirst() != DB_S_ENDOFROWSET)
	{
		// update recoard
		table.m_Type = nType;
		table.m_SpeedRate = nSpeedRate;
		table.m_TeachMode = 1;
		table.m_OHT_ID = nOHT_ID;

		//table.m_dwPositionStatus = DBSTATUS_S_IGNORE;
		hr = table.SetData();
		if (FAILED(hr))
		{
			cout<< "update keypoints table failed." << endl;
		}
		table.CloseAll();
		CoUninitialize();
		return -1;
	}
	table.CloseAll();

	hr = table.OpenAll();
	if (FAILED(hr))
	{
		CoUninitialize();
		return -1;
	}

	//Position, \
	//	Type, \
	//	SpeedRate, \
	//	TeachMode, \
	//	OHT_ID, \
	//	Rail_ID, \
	//	Prev, \
	//	Next \
	////// insert record
	table.m_Position = nPOS;
	table.m_Type = nType;
	table.m_SpeedRate = nSpeedRate;
	table.m_TeachMode = 1;
	table.m_OHT_ID = nOHT_ID;
	table.m_Rail_ID = 0;
	table.m_Prev = 0;
	table.m_Next = 0;

	table.m_dwPositionStatus = DBSTATUS_S_OK;
	table.m_dwTypeStatus = DBSTATUS_S_OK;
	table.m_dwSpeedRateStatus = DBSTATUS_S_OK;
	table.m_dwTeachModeStatus = DBSTATUS_S_OK;
	table.m_dwOHT_IDStatus = DBSTATUS_S_OK;
	table.m_dwRail_IDStatus = DBSTATUS_S_OK;
	table.m_dwPrevStatus = DBSTATUS_S_OK;
	table.m_dwNextStatus = DBSTATUS_S_OK;
	table.m_dwNameStatus = DBSTATUS_S_IGNORE;

	table.Insert();

	int nRet = 0;
	if (FAILED(hr))
	{
		nRet = -1;
	}
	else
	{
		table.UpdateAll();
	}
	table.CloseAll();
	CoUninitialize();

	return nRet;
}
