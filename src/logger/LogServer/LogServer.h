// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 LOGSERVER_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何其他项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// LOGSERVER_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
#ifdef LOGSERVER_EXPORTS
#define LOGSERVER_API __declspec(dllexport)
#else
#define LOGSERVER_API __declspec(dllimport)
#endif

// 此类是从 LogServer.dll 导出的
class LOGSERVER_API CLogServer {
public:
	CLogServer(void);
	// TODO: 在此添加您的方法。
	int Init(void);
	int End(void);
	void BindMsgHandle(HWND hwnd);

private:
	HWND m_hWnd;
	int InitICE(void);
	int InitDataStore(void);
};

extern LOGSERVER_API int nLogServer;

LOGSERVER_API int fnLogServer(void);
