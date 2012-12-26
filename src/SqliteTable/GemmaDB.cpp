#include "stdafx.h"
#include "SqliteTable.h"

std::wstring GetProcessPathWS()
{
	TCHAR buf[256] = {0};
	GetModuleFileName(NULL, buf, 256);
	std::wstring wstr;
	wstr = buf;
	
	size_t nBar = wstr.find_last_of('\\') + 1;
	wstr = wstr.substr(0, nBar);

	return wstr;
}

//void SQLITETABLE_API Time64ToSysTime( __int64 in, SYSTEMTIME* out)
//{
//	__int64 nTemp = 0;
//
//	//20121129084756111
//	nTemp = in %	1000000000;
//	out->wHour = (WORD)(nTemp /			10000000);
//	nTemp =  (WORD)(nTemp %		10000000);
//	out->wMinute =  (WORD)(nTemp /			100000);
//	nTemp =  (WORD)(nTemp %		100000);
//	out->wSecond = (WORD)(nTemp /			1000);
//	out->wMilliseconds =  (WORD)(nTemp %			1000);
//}

__int64 SQLITETABLE_API SysTimeto64Time(const SYSTEMTIME& time)
{
	__int64 _64Time = 0;

	_64Time = time.wMilliseconds;
	_64Time += time.wSecond *		1000;
	_64Time += time.wMinute *		100000;
	_64Time += time.wHour *			10000000;
	_64Time += (__int64)time.wDay *			1000000000;
	_64Time += (__int64)time.wMonth *		100000000000;
	_64Time += (__int64)time.wYear *			10000000000000;

	return _64Time;
}

__int64 GetTime4DB()
{
	__int64 _64Time = 0;

	SYSTEMTIME time;
	GetLocalTime(&time);

	_64Time = time.wMilliseconds;
	_64Time += time.wSecond *		1000;
	_64Time += time.wMinute *		100000;
	_64Time += time.wHour *			10000000;
	_64Time += (__int64)time.wDay *			1000000000;
	_64Time += (__int64)time.wMonth *		100000000000;
	_64Time += (__int64)time.wYear *			10000000000000;

	return _64Time;
}

CGemmaDB::CGemmaDB(void)
{
	m_pDataBase = NULL;
	m_isOpen	= false;
}

CGemmaDB::~CGemmaDB(void)
{
	Close();
}

bool CGemmaDB::OpenDb(const char* strDbFile)
{
	if (!m_isOpen && !m_pDataBase) 
	{
		int i = sqlite3_open_v2(strDbFile, &m_pDataBase, SQLITE_OPEN_READWRITE, NULL);
		if (i == SQLITE_OK && m_pDataBase) 
		{
			m_isOpen = true;
			//m_strDbFile = strDbFile;

			return true;
		}
	}

	m_isOpen = false;
	 sqlite3_close(m_pDataBase);
	m_pDataBase = NULL;

	return false;
}

bool CGemmaDB::ConnectDb(const char* strDbFile)
{
	//char chKey[128] = {0};
	//int nKey = 0;
	//nKey = GetKey(chKey);

	if(!OpenDb(strDbFile))
	{
		if(CreateDB(strDbFile))
		{
			/*if(nKey > 0 )
			{
				sqlite3_key(m_pDataBase, chKey, nKey);
			}*/
			//CreateTables();
			return true;
		}

		return false;
	}

	/*if(nKey > 0 )
	{
		sqlite3_key(m_pDataBase, chKey, nKey);
	}*/

	ExeSQL("PRAGMA cache_size =8000;"
		"PRAGMA temp_store = MEMORY");


	return true;
}

bool CGemmaDB::ExeSQL(const char* pSQL)
{
	if (m_isOpen && m_pDataBase )
	{
		const char* pTail;
		sqlite3_stmt* pStmt;
		int i = sqlite3_prepare_v2(m_pDataBase, pSQL, -1, &pStmt, &pTail);
		if (i == SQLITE_OK) 
		{
			i = sqlite3_step(pStmt);            
		}
		sqlite3_finalize(pStmt);

		return i == SQLITE_ROW || i == SQLITE_DONE;
	}
	return false;
}

bool CGemmaDB::CreateDB(const char* strFileName)
{
	//char cstr[128] = {0}; 
	//WideCharToMultiByte(CP_OEMCP, 0, strFileName, -1, 
	//cstr, strFileName.GetLength(), NULL, NULL); 

	if (!m_isOpen && !m_pDataBase) 
	{
		int i = sqlite3_open_v2(strFileName, &m_pDataBase, 
			SQLITE_OPEN_READWRITE | SQLITE_OPEN_CREATE, NULL);
		if (i == SQLITE_OK && m_pDataBase) 
		{
			m_isOpen = true;
			//m_strDbFile = strFileName;

			//first set the pragma to auto_vacuum when create new db
			ExeSQL("PRAGMA auto_vacuum=1;");

			return true;
		}
	}

	sqlite3_close(m_pDataBase);
	m_pDataBase = NULL;

	return false;
}

bool CGemmaDB::Close(void)
{
	if (m_isOpen || m_pDataBase) 
	{
		sqlite3_close(m_pDataBase);
		m_pDataBase = NULL;
		m_isOpen = false;
		//m_col_loaded = false;
		//m_strDbFile = _T("");
	}

	return true;
}

//int CGemmaDB::GetKey(char* pKey)
//{
//	char* p = pKey;
//	char tc[128] = {0};
//	char* p2 = tc;
//
//	*p++ = '1';
//	*p2++ = '2';
//
//	*p++ = 'q';
//	*p2++ = 'a';
//
//	*p++ = '2';
//	*p2++ = '7';
//
//	*p++ = 'w';
//	*p2++ = 's';
//
//	*p++ = '3';
//	*p2++ = '1';
//
//	*p++ = 'e';
//	*p2++ = 'j';
//
//	*p++ = '4';
//	*p2++ = 'k';
//
//	*p++ = 'r';
//	*p2++ = '7';
//
//	return 8;
//	//return 0;
//}

sqlite3 * CGemmaDB::GetDBPtr(void)
{
	return m_pDataBase;
}
