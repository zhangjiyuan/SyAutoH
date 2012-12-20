// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 PATHFINDER_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何其他项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// PATHFINDER_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
#ifdef PATHFINDER_EXPORTS
#define PATHFINDER_API __declspec(dllexport)
#else
#define PATHFINDER_API __declspec(dllimport)
#pragma comment(lib, "pathfinder.lib")
#endif

#pragma once
#include <vector>
typedef std::vector<int> INT_LIST;

class CPathProductor;
// 此类是从 PathFinder.dll 导出的
class PATHFINDER_API CPathFinder 
{
public:
	CPathFinder(void);
	~CPathFinder();

	INT_LIST GetPath(int nFrom, int nTo);
	void Init();

private: 
	CPathProductor* m_pProductor;
public:
	void Test(void);
};
