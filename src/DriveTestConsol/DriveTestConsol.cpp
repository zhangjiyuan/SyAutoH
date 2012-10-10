// DriveTestConsol.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "../AMHSDrive/AMHSDrive.h"

int _tmain(int argc, _TCHAR* argv[])
{
	CAMHSDrive amhsDev;
	amhsDev.Init();
	//amhsDev.SetOHTLocation( 200);
	amhsDev.SetOHTBackMessage(12, 150);


	getchar();
	amhsDev.Clean();

	return 0;
}

