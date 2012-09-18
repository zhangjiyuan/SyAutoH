// TLinkSession.h : CLinkSessionTable 的声明

#pragma once

// 代码生成在 2012年9月18日, 16:25

class CLinkSessionTableAccessor
{
public:
	LONG m_SessionID;
	LONG m_UserID;
	LONG m_RealRight;
	LONG m_OrginRight;
	DBTIMESTAMP m_AccessTime;
	TCHAR m_ConnectInfo[201];

	// 以下向导生成的数据成员包含
	//列映射中相应字段的状态值。
	// 可以使用这些值保存数据库返回的 NULL 值或在编译器返回
	// 错误时保存错误信息。有关如何使用
	//这些字段的详细信息，
	// 请参见 Visual C++ 文档中的
	//“向导生成的访问器中的字段状态数据成员”。
	// 注意: 在设置/插入数据前必须初始化这些字段!

	DBSTATUS m_dwSessionIDStatus;
	DBSTATUS m_dwUserIDStatus;
	DBSTATUS m_dwRealRightStatus;
	DBSTATUS m_dwOrginRightStatus;
	DBSTATUS m_dwAccessTimeStatus;
	DBSTATUS m_dwConnectInfoStatus;

	// 以下向导生成的数据成员包含
	//列映射中相应字段的长度值。
	// 注意: 对变长列，在设置/插入
	//       数据前必须初始化这些字段!

	DBLENGTH m_dwSessionIDLength;
	DBLENGTH m_dwUserIDLength;
	DBLENGTH m_dwRealRightLength;
	DBLENGTH m_dwOrginRightLength;
	DBLENGTH m_dwAccessTimeLength;
	DBLENGTH m_dwConnectInfoLength;


	void GetRowsetProperties(CDBPropSet* pPropSet)
	{
		pPropSet->AddProperty(DBPROP_CANFETCHBACKWARDS, true, DBPROPOPTIONS_OPTIONAL);
		pPropSet->AddProperty(DBPROP_CANSCROLLBACKWARDS, true, DBPROPOPTIONS_OPTIONAL);
		pPropSet->AddProperty(DBPROP_IRowsetChange, true, DBPROPOPTIONS_OPTIONAL);
		pPropSet->AddProperty(DBPROP_UPDATABILITY, DBPROPVAL_UP_CHANGE | DBPROPVAL_UP_INSERT | DBPROPVAL_UP_DELETE);
	}

	HRESULT OpenDataSource()
	{
		CDataSource _db;
		HRESULT hr;
//#error 安全问题：连接字符串可能包含密码。
// 此连接字符串中可能包含明文密码和/或其他重要
// 信息。请在查看完此连接字符串并找到所有与安全
// 有关的问题后移除 #error。可能需要将此密码存
// 储为其他格式或使用其他的用户身份验证。
		hr = _db.OpenFromInitializationString(L"Provider=SQLNCLI10.1;Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=MCS;Data Source=SDNY-PC\\AMHS;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=SDNY-PC;Initial File Name=\"\";Use Encryption for Data=False;Tag with column collation when possible=False;MARS Connection=False;DataTypeCompatibility=0;Trust Server Certificate=False");
		if (FAILED(hr))
		{
#ifdef _DEBUG
			AtlTraceErrorRecords(hr);
#endif
			return hr;
		}
		return m_session.Open(_db);
	}

	void CloseDataSource()
	{
		m_session.Close();
	}

	operator const CSession&()
	{
		return m_session;
	}

	CSession m_session;

	DEFINE_COMMAND_EX(CLinkSessionTableAccessor, L" \
	SELECT \
		SessionID, \
		UserID, \
		RealRight, \
		OrginRight, \
		AccessTime, \
		ConnectInfo \
		FROM dbo.LinkSession")


	// 为解决某些提供程序的若干问题，以下代码可能以
	// 不同于提供程序所报告的顺序来绑定列

	BEGIN_COLUMN_MAP(CLinkSessionTableAccessor)
		COLUMN_ENTRY_LENGTH_STATUS(1, m_SessionID, m_dwSessionIDLength, m_dwSessionIDStatus)
		COLUMN_ENTRY_LENGTH_STATUS(2, m_UserID, m_dwUserIDLength, m_dwUserIDStatus)
		COLUMN_ENTRY_LENGTH_STATUS(3, m_RealRight, m_dwRealRightLength, m_dwRealRightStatus)
		COLUMN_ENTRY_LENGTH_STATUS(4, m_OrginRight, m_dwOrginRightLength, m_dwOrginRightStatus)
		COLUMN_ENTRY_LENGTH_STATUS(5, m_AccessTime, m_dwAccessTimeLength, m_dwAccessTimeStatus)
		COLUMN_ENTRY_LENGTH_STATUS(6, m_ConnectInfo, m_dwConnectInfoLength, m_dwConnectInfoStatus)
	END_COLUMN_MAP()
};

class CLinkSessionTable : public CCommand<CAccessor<CLinkSessionTableAccessor> >
{
public:
	HRESULT OpenAll()
	{
		HRESULT hr;
		hr = OpenDataSource();
		if (FAILED(hr))
			return hr;
		__if_exists(GetRowsetProperties)
		{
			CDBPropSet propset(DBPROPSET_ROWSET);
			__if_exists(HasBookmark)
			{
				if( HasBookmark() )
					propset.AddProperty(DBPROP_IRowsetLocate, true);
			}
			GetRowsetProperties(&propset);
			return OpenRowset(&propset);
		}
		__if_not_exists(GetRowsetProperties)
		{
			__if_exists(HasBookmark)
			{
				if( HasBookmark() )
				{
					CDBPropSet propset(DBPROPSET_ROWSET);
					propset.AddProperty(DBPROP_IRowsetLocate, true);
					return OpenRowset(&propset);
				}
			}
		}
		return OpenRowset();
	}

	HRESULT OpenRowset(DBPROPSET *pPropSet = NULL)
	{
		HRESULT hr = Open(m_session, NULL, pPropSet);
#ifdef _DEBUG
		if(FAILED(hr))
			AtlTraceErrorRecords(hr);
#endif
		return hr;
	}

	void CloseAll()
	{
		Close();
		ReleaseCommand();
		CloseDataSource();
	}
};


