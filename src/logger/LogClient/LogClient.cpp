// LogClient.cpp : 定义 DLL 应用程序的入口点。
//

#include "stdafx.h"
#include <LogClient.h>
#include <windows.h>
#include <commctrl.h>
#include "Logger.h"

//BOOL APIENTRY DllMain( HANDLE hModule, 
//                       DWORD  ul_reason_for_call, 
//                       LPVOID lpReserved
//					 )
//{
//	switch (ul_reason_for_call)
//	{
//	case DLL_PROCESS_ATTACH:
//	case DLL_THREAD_ATTACH:
//	case DLL_THREAD_DETACH:
//	case DLL_PROCESS_DETACH:
//		break;
//	}
//    return TRUE;
//}

CLogger g_logger;

LOGCLIENT_API int InitLogger(void)
{
	return g_logger.Init();
}

LOGCLIENT_API int EndLogger(void)
{
	return g_logger.End();
}

//LOGCLIENT_API int Log(int nID, int nStation, TCHAR* strMsg)
//{
//	return g_logger.Log(nID, nStation, strMsg);
//}

//
//LOGCLIENT_API void Log(unsigned long EventID, unsigned short wUnitID, unsigned short wStationID, unsigned short wParam1 , unsigned short wParam2 , unsigned long lParam1 , unsigned long lParam2 , unsigned long lParam3 )
//{
//
//}
//LOGCLIENT_API void LogF(unsigned long EventID, unsigned short wUnitID, unsigned short wStationID, unsigned short wParam1 , unsigned short wParam2 , float lParam1 , float lParam2 )
//{
//
//}
//LOGCLIENT_API void LogS(unsigned long EventID, unsigned short wUnitID, unsigned short wStationID, const TCHAR * pStr)
//{
//
//}
//LOGCLIENT_API void LogS(unsigned long EventID, unsigned short wUnitID, unsigned short wStationID, unsigned short wParam1, unsigned short wParam2, const TCHAR * pStr)
//{
//
//}

LOGCLIENT_API void LogS(unsigned long ID,  UCHAR type, const CHAR * pUnit, const CHAR * pStr)
{
	g_logger.Init();
	g_logger.Log(ID, type, pUnit, pStr);
}

LOGCLIENT_API int GetAlarmCount()
{
	g_logger.Init();
	return g_logger.GetAlarmCount();
}

LOGCLIENT_API int GetLastType()
{
	g_logger.Init();
	return g_logger.GetLastType();
}



// by zjh 2010.6.4
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

FILE* g_log_file = 0;

TCHAR g_log_name[256] = {0};

TCHAR* GetLogPath(TCHAR* spath)
{
	TCHAR tpath[MAX_PATH];
	if(!::GetModuleFileName(NULL, tpath, MAX_PATH))
		return 0;

	LPTSTR pszToken = wcsrchr(tpath, '\\'); pszToken[0] = '\0';
	pszToken = wcsrchr(tpath, '\\'); pszToken[1] = '\0';
	wcscat(tpath, L"data\\log");

	if(lstrlen(tpath) == 0)
		return 0;

	lstrcpy(spath, tpath);
	return spath;
}

TCHAR* GetOldlogName(TCHAR* name)
{
	SYSTEMTIME systime={0};
	GetSystemTime(&systime);
	systime.wMonth--;
	if(systime.wMonth == 0)
	{
		systime.wYear--;
		systime.wMonth = 12;
	}
	wsprintf(name, L"%4d%02d%02d", systime.wYear, systime.wMonth, systime.wDay);
	return name;
}

TCHAR* GetCurlogName(TCHAR* name)
{
	SYSTEMTIME systime={0};
	GetSystemTime(&systime);
	wsprintf(name, L"%4d%02d%02d", systime.wYear, systime.wMonth, systime.wDay);
	return name;
}

FILE* GetLogFile()
{
	TCHAR name[256] = {0}; GetCurlogName(name);
	if(g_log_file != 0)
	{
		if(lstrcmp(name, g_log_name) != 0)
		{
			fclose(g_log_file);
			g_log_file = 0;

			TCHAR path[256] = {0}; TCHAR file[256] = {0};
			TCHAR sold[256] = {0}; GetOldlogName(sold);
			if(GetLogPath(path))
			{
				wsprintf(file, L"%s\\%s.log", path, sold); 
				DeleteFile(file);
			}
		}
	}
	if(g_log_file == 0)
	{
		TCHAR path[256] = {0}; TCHAR file[256] = {0};
		if(!GetLogPath(path))
			return 0;
		wsprintf(file, L"%s\\%s.log", path, name); 
		g_log_file = _wfopen(file, L"at+");
		if(!g_log_file)
			g_log_file = _wfopen(file, L"wt+");
		lstrcpy(g_log_name, name);
	}
	return g_log_file;
}

int fouttime(FILE* fout)
{
	SYSTEMTIME systime={0};
	GetSystemTime(&systime);
	fprintf(fout, "[%02d:%02d:%02d] ", systime.wHour, systime.wMinute, systime.wSecond);
	return 0;
}

int __cdecl LogF(const char *format, ...)
{
	try{
	FILE* fout = GetLogFile();
	if(fout != 0)
	{
		fouttime(fout);
		va_list args;   
		va_start(args, format);   
		vfprintf(fout, format, args);  
		fflush(fout);
	}
	}
	catch(...)
	{
	}
	return 0;
}
