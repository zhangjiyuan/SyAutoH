// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 LOGCLIENT_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何其他项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// LOGCLIENT_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
#ifdef LOGCLIENT_EXPORTS
#define LOGCLIENT_API __declspec(dllexport)
#else
#define LOGCLIENT_API __declspec(dllimport)

#pragma comment(lib, "logclientwin.lib")

#endif

#include "LogDef.h"

//LOGCLIENT_API void Log(unsigned long EventID, unsigned short wUnitID, unsigned short wStationID, unsigned short wParam1 = 0, unsigned short wParam2 = 0, unsigned long lParam1 = 0, unsigned long lParam2 = 0, unsigned long lParam3 = 0);
//LOGCLIENT_API void LogF(unsigned long EventID, unsigned short wUnitID, unsigned short wStationID, unsigned short wParam1 = 0, unsigned short wParam2 = 0, float lParam1 = 0.0, float lParam2 = 0.0);
//LOGCLIENT_API void LogS(unsigned long EventID, unsigned short wUnitID, unsigned short wStationID, const TCHAR * pStr);
//LOGCLIENT_API void LogS(unsigned long EventID, unsigned short wUnitID, unsigned short wStationID, unsigned short wParam1, unsigned short wParam2, const TCHAR * pStr);

// 
// Log sample : LogS(LID_SYS_ERR, LogType::Error, SYS_MODULE, "your message");
//

extern "C"
{
// log
LOGCLIENT_API void LogS(unsigned long EventID,  UCHAR type, const CHAR * pUnit, const CHAR * pStr);

// 取得报警数目. 
// 如果返回值小于0,说明没有连接到日志服务器. 
// 返回值大于等0时,即是服务器上真实的报警信息数目. 0说明没有报警信息.
LOGCLIENT_API int GetAlarmCount();

// 取得最后一条日志信息的类别. 
// 如果返回值小于0,说明没有连接到日志服务器. 
// 返回值大于0时取得最后一条日志的类别信息, 类别定义在LogDef.h.
LOGCLIENT_API int GetLastType();

// by zjh 2010.6.4
LOGCLIENT_API int __cdecl LogF(const char *format, ...);


};

