#pragma once

class SqlServerNCLI
{
public:
	SqlServerNCLI(void);
	virtual ~SqlServerNCLI(void);

private:
	CDataSource ds;
	CSession sn;

public:
	int InitializeAndEstablishConnection(WCHAR* wsServer, WCHAR* wsDataBase);
	int ReleaseResource(void);
	int ExecuteSQL(WCHAR* sSQLCMD);
	int TestMfcOleDB(void);
};

