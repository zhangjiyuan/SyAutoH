// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 MESSIM_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何其他项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// MESSIM_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
#ifdef MESSIM_EXPORTS
#define MESSIM_API __declspec(dllexport)
#else
#define MESSIM_API __declspec(dllimport)
#endif

class MesLinkClient;
// 此类是从 MesSim.dll 导出的
class MESSIM_API CMesSim {
public:
	CMesSim(void);
	~CMesSim();

private:
	MesLinkClient* m_pMesClient;

public:
	int Init();
	int PlaceFoup(int nFoupID, int nDevID);
	int PickFoup(int nFoupID, int nDevID);
};
