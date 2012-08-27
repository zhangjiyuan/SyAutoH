// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 SQLACECLI_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何其他项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// SQLACECLI_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
#ifdef SQLACECLI_EXPORTS
#define SQLACECLI_API __declspec(dllexport)
#else
#define SQLACECLI_API __declspec(dllimport)
#endif

#pragma once
#include <windows.h>

class SqlServerNCLI;
// 此类是从 SqlAceCli.dll 导出的
class SQLACECLI_API CSqlAceCli {
public:
	CSqlAceCli(void);
	~CSqlAceCli();

private:
	SqlServerNCLI* m_pSqlClient;

public:
	int Connect(WCHAR* wServer, WCHAR* wDBName);
	int ExecuteSQL(WCHAR* wSqlCmd);
	int PutOutRecordSet(void);
};
