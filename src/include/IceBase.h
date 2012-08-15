// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 ICECLIENTBASE_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何其他项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// ICECLIENTBASE_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
#ifdef ICECLIENTBASE_EXPORTS
#define ICECLIENTBASE_API __declspec(dllexport)
#else
#define ICECLIENTBASE_API __declspec(dllimport)

#ifdef  WINCE
	#ifdef _DEBUG
		#pragma comment(lib,"IceBaseCEd.lib")
		#pragma comment(lib,"Iceed.lib")
	#else
		#pragma comment(lib,"IceBaseCE.lib")
		#pragma comment(lib,"Icee.lib")
	#endif
#else
	#ifdef _DEBUG
		#pragma comment(lib,"IceBased.lib")
		#pragma comment(lib,"Iced.lib")
		#pragma comment(lib,"Iceutild.lib")
	#else
		#pragma comment(lib,"IceBase.lib")
		#pragma comment(lib,"Ice.lib")
		#pragma comment(lib,"Iceutil.lib")
	#endif
#endif

#endif


#pragma once

#include <string>
#ifdef WINCE
	#include "IceE/IceE.h"
    #include "IceE/Unicode.h"
#else
	#include "ice/Ice.h"
#endif


using namespace std;

// 此类是从 IceClientBase.dll 导出的
string ICECLIENTBASE_API GetProcessPath();

class ICECLIENTBASE_API CIceClientBase 
{
public:
	CIceClientBase();
	virtual ~CIceClientBase(void);

	void InitIce(void);
	void EndIce(void);

public:
	Ice::CommunicatorPtr m_communicator;
	Ice::ObjectAdapterPtr m_adapter;

	string m_strConfigFileName;
	string m_strProxy;

protected:
	Ice::ObjectPrx m_objPrx;	
	
	virtual void GetProxy(void) = 0;
	
public:
	std::string ConfigFileName() const { return m_strConfigFileName; }
	void ConfigFileName(std::string val) { m_strConfigFileName = val; }
	
	std::string Proxy() const { return m_strProxy; }
	void Proxy(std::string val) { m_strProxy = val; }

};

class  ICECLIENTBASE_API CIceServerBase
{
public:
	CIceServerBase(void);
	virtual ~CIceServerBase(void);

	void InitIce(void);
	void EndIce(void);

public:
	Ice::CommunicatorPtr m_communicator;
	Ice::ObjectAdapterPtr m_adapter;

	string m_strConfigFileName;
	string m_strProxy;

protected:
	Ice::ObjectPtr m_objPtr;	

	virtual void GetProxy(void) = 0;

public:
	std::string ConfigFileName() const { return m_strConfigFileName; }
	void ConfigFileName(std::string val) { m_strConfigFileName = val; }

	std::string Proxy() const { return m_strProxy; }
	void Proxy(std::string val) { m_strProxy = val; }
};


