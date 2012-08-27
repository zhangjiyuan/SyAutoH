#pragma once

class SqlServerNCLI
{
public:
	SqlServerNCLI(void);
	virtual ~SqlServerNCLI(void);

private:
	IDBInitialize* pIDBInitialize;
	IDBProperties* pIDBProperties;
	IDBCreateSession* pIDBCreateSession;
	IDBCreateCommand* pIDBCreateCommand;
	ICommandText* pICommandText;
	IRowset* pIRowset;
	IColumnsInfo* pIColumnsInfo;

	DBCOLUMNINFO* pDBColumnInfo;
	IAccessor* pIAccessor ;
	DBPROP InitProperties[4];
	DBPROPSET rgInitPropSet[1];

	//ULONG i, j;
	//HRESULT hr;
	DBROWCOUNT cNumRows;
	DBORDINAL lNumCols;
	WCHAR* pStringsBuffer;
	DBBINDING* pBindings;
	DBLENGTH ConsumerBufColOffset;
	HACCESSOR hAccessor;
	DBCOUNTITEM lNumRowsRetrieved;
	HROW hRows[10];
	HROW* pRows;

public:
	int InitializeAndEstablishConnection(WCHAR* wsServer, WCHAR* wsDataBase);
	int ReleaseResource(void);
	int CreationSession(void);
	int ExecuteSQL(WCHAR* sSQLCMD);
	int TProcessRecordSet(void);
	int TestMfcOleDB(void);
};

