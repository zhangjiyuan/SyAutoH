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
#include <string>
#include <list>

using namespace std;

typedef list<string> strList;
class SQLACECLI_API DBUserAce
{
public:
	DBUserAce(void);
	~DBUserAce(void);

public:
	int Login(const ::std::string& sName, const ::std::string& sHash);
	int Logout(int);
	int CreateUser(const ::std::string& sName, const ::std::string& sPassWord, int nRight);
	int DeleteUser(int, int);
	int SetUserPW(int, const ::std::string&, int);
	int SetUserRight(int, int, int);
	int GetUserCount();
	strList GetUserList(int, int);
};

class SQLACECLI_API DBFoup
{
public:
	DBFoup(void);
	~DBFoup(void);
public:
	int AddFoup(WCHAR* sFoupID, WCHAR* sLot, int nLocal, int nType);
	int FindFoup(WCHAR* sFoupID);
	int SetFoupLocation(int nFoup, int nLocal, int nType);
	int GetFoupLocation(int nFoup, int &nLocal, int &nType);
};
