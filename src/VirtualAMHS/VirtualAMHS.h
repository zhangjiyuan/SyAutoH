// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 VIRUALAMHS_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何其他项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// VIRUALAMHS_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
#ifdef VIRUALAMHS_EXPORTS
#define VIRUALAMHS_API __declspec(dllexport)
#else
#define VIRUALAMHS_API __declspec(dllimport)
#endif

#pragma once

class VirtualOHT;
class VirtualStocker;
#include <map>
#include <list>
typedef std::map<int, VirtualOHT*> MAP_VOHT;
typedef std::map<int, VirtualStocker*> MAP_VSTK;

typedef struct
{
	int nID;
	int nPosition;
	int nHandStatus;
	int nOnline;
} ItemOHT;
typedef std::list<ItemOHT> LIST_OHT;
typedef std::map<int, ItemOHT*> MAP_ItemOHT;

typedef struct
{
	TCHAR FoupID[256];
	int nProcessStatus;
} ItemFoup;
typedef std::list<ItemFoup> LIST_FOUP;
//zhang add the code in 2012.10.24
typedef std::map<int,ItemFoup*> MAP_ItemFoup;

class VIRUALAMHS_API CVirtualAMHS {
public:
	CVirtualAMHS(void);
	~CVirtualAMHS();

	// device auth
	int OHT_Auth(int nIndex, DWORD nPos = 0, int nHand = 0);
	int Stocker_Auth(int nIndex, const char* sIP);

	int OHT_Offline(int nIndex);
	int Stocker_Offline(int nIndex);

	// for Stocker
	LIST_FOUP Stocker_GetFoupsStatus(int nStocker);
	int Stocker_ManualInputFoup(int nStocker, const TCHAR* sFoupID);
	int Stocker_ManualOutputFoup(int nStocker, const TCHAR* sFoupID);
	int STK_History(int nStocker);

	// for OHT
	LIST_OHT OHT_GetStatus();
	int SetTeachPosition(int nID, int nPos, int nType, int nSpeedRate);

private:
	MAP_VOHT* m_mapOHT;
	MAP_VSTK*	 m_mapSTK;
};
