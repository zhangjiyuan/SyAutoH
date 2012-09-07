// SqlDBTest.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "../SqlAceCli/SqlAceCli.h"
#include <string>
#include <iostream>
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	CSqlAceCli sqlAce;
	int nHR = sqlAce.Connect(L"SDNY-PC\\AMHS", L"MCS");
	if (nHR != 0)
	{
		cout<<"Cannot open the database." << endl;
	}
	else
	{
		cout<<"Success to open the database." << endl;
	}

	WCHAR* wSql = L"Select * from [User]";

	int nExeSql = sqlAce.ExecuteSQL(wSql);
	if (nExeSql != 0)
	{
		cout<<"Failed to Execute Sql" << endl;
	}
	else
	{
		cout<<"Success to Execute Sql" << endl;
	}

	//sqlAce.PutOutRecordSet();

	int nOHT  = 0;
	int nStocker = 0;
	int nFoupFind = 0;
	//int nFoupFind = sqlAce.FindFoupLocation(L"Foup-S1", nOHT, nStocker);
	//if (0 == nFoupFind)
	//{
	//	cout<< "Find Foup-S1 OHT:" << nOHT << " Stocker:" << nStocker << endl;
	//}

	//nFoupFind = sqlAce.FindFoupLocation(L"Foup-S6", nOHT, nStocker);
	//if (0 == nFoupFind)
	//{
	//	cout<< "Find Foup-S6 OHT:" << nOHT << " Stocker:" << nStocker << endl;
	//}

	nFoupFind = sqlAce.FindFoupLocation(L"34", nOHT, nStocker);
	if (0 == nFoupFind)
	{
		cout<< "Find Foup-S2 OHT:" << nOHT << " Stocker:" << nStocker << endl;
	}

	
	sqlAce.Clean();
	getchar();

	return 0;
}

