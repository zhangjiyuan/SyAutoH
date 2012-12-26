// 下列 ifdef 块是创建使从 DLL 导出更简单的
// 宏的标准方法。此 DLL 中的所有文件都是用命令行上定义的 SQLITETABLE_EXPORTS
// 符号编译的。在使用此 DLL 的
// 任何其他项目上不应定义此符号。这样，源文件中包含此文件的任何其他项目都会将
// SQLITETABLE_API 函数视为是从 DLL 导入的，而此 DLL 则将用此宏定义的
// 符号视为是被导出的。
#ifdef SQLITETABLE_EXPORTS
#define SQLITETABLE_API __declspec(dllexport)
#else
#define SQLITETABLE_API __declspec(dllimport)

 #pragma comment(lib, "sqlitetable.lib") 

#endif


#pragma once

#include <string>
#include <sqlite3.h>

class SQLITETABLE_API CGemmaDB
{
public:
	CGemmaDB(void);
	~CGemmaDB(void);
private:
	sqlite3 *	m_pDataBase;
	bool		m_isOpen;
	//MyCString		m_strDbFile;

protected:
	bool OpenDb(const char* strDbFile);
	bool CreateDB(const char* strFileName);
	//int GetKey(char* pKey);

public:

	bool ConnectDb(const char* strDbFile);
	bool Close(void);
	//bool ExeSQL(CString strSQL);
	bool ExeSQL(const char* pSQL);

public:
	sqlite3 * GetDBPtr(void);
};

//this #define enables the auto-vacuum mode, which will keep the file sizes small
//#define MYSQLITE_AUTOVAC_ON

enum SQLITETABLE_API MYDB_TYPE {
	MYDB_TYPE_NONE,
	MYDB_TYPE_TEXT,
	MYDB_TYPE_INT,
	MYDB_TYPE_DOUBLE,
	MYDB_TYPE_BLOB,
	MYDB_TYPE_ID,
	MYDB_TYPE_LONG,
};

struct  SQLITETABLE_API  MYDB_ITEM {
	MYDB_TYPE type;
	void* pData;  
	int item_col; //which column is the item
	char name[100];
	bool bIndex;
};

//basic blob class
class   SQLITETABLE_API  SQLiteBlob 
{
public:
	SQLiteBlob();
	virtual ~SQLiteBlob() { Clean(); }

	void Clean();
	void Set(const char* pData, int size);
	const char* GetData() { return (m_size>0) ? m_pData : NULL; }
	int GetSize() { return m_size; }

private:
	char* m_pData;
	int m_size;
};

//I didn't want to be dependant on MFC or STL, so I made my own string obj
//feel free to expand it if needed
class  SQLITETABLE_API  SQLiteString : public SQLiteBlob 
{
public:
	SQLiteString() { SQLiteBlob::SQLiteBlob();  Set("", 1); }
	SQLiteString(const char* pData) 
	{ 
		SetString(pData);
	}
	SQLiteString(SQLiteString& data)
	{
		Set(data.GetData(), data.GetSize());
	}

	void SetString(const char* pData);
	void Format(const char* fmt, ...);
	int GetLength() { int l = GetSize(); return (l>1) ? l-1 : 0; } //string length, not buffer
	bool IsEmpty() { return GetLength() < 1; }
	void SetAt(int i, char c); //only use if necessary

	const char* operator =(const char* pData) 
	{ 
		SetString(pData); 
		return GetData();
	}
	SQLiteString& operator =(SQLiteString& data) 
	{ 
		Set(data.GetData(), data.GetSize());
		return *this; 
	}
	operator const char*() 
	{ 
		return GetData(); 
	}
	char operator [](int i); 
	void operator +=(const char* pData);
	void operator +=(char c) { char t[2]; t[0]=c; t[1]='\0'; *this+=t; }
	bool operator ==(const char* pS);
	bool operator !=(const char* pS) { return !(*this==pS); }
	bool operator <(const char* pS);
	bool operator >(const char* pS);
};


//SQLiteTbl is the base class for each of your SQLite tables in your project.  You
//would instantiate a new class for each table with this as your base class.
class SQLITETABLE_API  SQLiteTbl
{
public:
	SQLiteTbl();
	virtual ~SQLiteTbl();

public:
	//virtual functions that need to be defined in the derived class
	virtual const char* TableName() = 0;     
	virtual int ItemCount() = 0; //number of items we are using.  can be less than the actual columns
	virtual bool Open(sqlite3* pDB);

public:
	bool OpenDB(sqlite3* pDB);
	bool Create(void);    
	bool IsOpen() { return m_is_open; }
	bool Compact(); //be careful using this, as it will take time, plus if you use the auto-vacuum, you don't need it
	const char* Path() { return m_path; }

	void SetSort(const char* pSort) { m_sort = pSort; }
	const char* GetSort() { return m_sort; }
	void SetFilter(const char* pFilter) { m_filter = pFilter; }
	void SetLimit(int nLimit) {m_row_limit = nLimit; }
	void SetSkip(int nVal) {m_row_skip = nVal; }
	const char* GetFilter() { return m_filter; }
	bool Query(); //run the select string
	bool Close();
	bool IsBOF(); //beginning of file
	bool IsEOF(); //end of file
	int CurrentPos() { return m_row_pos; } //current position
	int GetCount() { return m_row_count; }//get the current count of items
	int ReadCount();  //executes the sql to ge the count
	SQLiteString GetSQL(bool rowid_only=false, bool use_filter=true, bool use_sort=true);

	bool ExeSQL(const char* pSQL); //provides mechanism to run SQL command directly
	bool SetOneItem(const char* pItem, const char* pValue, int rowid=-1); //sets one item in the table quickly.  doesn't use edit/update

	bool MoveFirst();
	bool MoveNext();
	bool MovePrev();
	bool MoveLast();
	bool Move(int idx); //move to a specific index.  One-based, because of I was making it like CRecordSet

	bool Edit();    //call edit first, then change values, must call Update when finished
	bool InEdit() { return m_rowid_edit > 0; }
	void EditCancel() { m_rowid_edit = 0; } //cancel the edit
	bool AddNew(); //must call Update when finished
	bool Update();  //call Update after you have changed the values

	bool Delete();

	//caution - be careful how you use the sqlite direct access
	sqlite3* GetDB() { return m_pDb; }
	MYDB_ITEM* Items() { return m_pItems; }
	int* GetRowids() { return m_pRowids; } //again, be careful using this
	int GetQueryCount() { return m_query_count; }

protected:
	void InitItems();
	void SetItem(int item, const char* pName, MYDB_TYPE type, void* pData, 
		bool bIndex = false);
	void LoadItems(sqlite3_stmt* pStmt);
	bool LoadColumnNumbers();      
	bool InsertTable();
	bool InsertIndex();
	bool SlowAdd();
	void AddRowid(int id);

	sqlite3* m_pDb;
	MYDB_ITEM* m_pItems; //this must be set by the derived class
	bool m_is_open;
	SQLiteString m_path;
	SQLiteString m_filter;
	SQLiteString m_sort;
	int m_row_count;
	int m_row_limit;
	int m_row_skip;
	int m_row_pos; //current position
	int m_col_count; //number of actual columns in table
	bool m_col_loaded; //set true after we have loaded the column indexes

	int* m_pRowids;
	int m_rowid_size; //bigger to allow us to add new records
	int m_query_count; //used so we know how far we are into the query

	int m_rowid_edit; //used for edit/update
	bool m_add; //used to show we are adding

public:
	void SetDBPtr(sqlite3* pDB);
	bool LoadTable(void);
	void BeginTrans(void);
	bool EndTrans(void);
};

std::wstring SQLITETABLE_API GetProcessPathWS();
__int64 SQLITETABLE_API GetTime4DB();
__int64 SQLITETABLE_API SysTimeto64Time(const SYSTEMTIME& );
//void SQLITETABLE_API Time64ToSysTime( __int64, SYSTEMTIME* );