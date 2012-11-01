// DriveTestConsol.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <string>
#include <iostream>
#include "../shared/Util.h"
#include "Common.h"

using namespace std;


uint8 XORRotateLeft(const uint8* data, uint32 length)
{
	// a big thank you to Strilanc for figuring this out
	if (data == NULL) return 0;

	uint8 hash = 0;

	for(int i=0;i<length;i++) hash ^=data[i];

	return hash;
}

int _tmain(int argc, _TCHAR* argv[])
{
	string strVal = "<12,34><34,45><23,77><34,56,78,90,98><33,44,55,66>";

	STR_VEC list = GetVecStrings(strVal);
	for (STR_VEC::iterator it = list.begin();
		it != list.end(); ++it)
	{
		cout << it->c_str() << endl;
		STR_VEC ln = SplitString(*it, ",");
		for (STR_VEC::iterator nit = ln.begin();
			nit != ln.end(); ++ nit)
		{
			cout << nit->c_str() << endl;
		}
	}

	uint8 buf[] = "1234567";
	uint8 xor = XORRotateLeft(buf, 7);
	
	getchar();

	return 0;
}
