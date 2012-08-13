// SiaMCSYS.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <string>
#include <iostream>
using namespace std;

#include "MaterialController.h"

int _tmain(int argc, _TCHAR* argv[])
{
	cout<< "Material Control System" << endl;
	MaterialController MC;
	if (0 != MC.Init())
	{
		cout<< "MCS Init failed." << endl;
		return 0;
	}

	MC.Run();

	string str;
	while(cin>>str)
	{
		cout<< str<<endl;
	}
	return 0;
}

