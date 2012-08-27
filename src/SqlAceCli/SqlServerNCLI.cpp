#include "StdAfx.h"
#include "SqlServerNCLI.h"


SqlServerNCLI::SqlServerNCLI(void)
{
	pIDBInitialize = NULL;
	pIDBProperties = NULL;
	pIDBCreateSession = NULL;
	pIDBCreateCommand = NULL;
	pICommandText = NULL;
	pIRowset = NULL;
	pIColumnsInfo = NULL;

	pDBColumnInfo = NULL;
	pIAccessor =  NULL;

	cNumRows = 0;
	ConsumerBufColOffset = 0;
	pRows = &hRows[0];
}


SqlServerNCLI::~SqlServerNCLI(void)
{
}


int SqlServerNCLI::InitializeAndEstablishConnection(WCHAR* wsServer, WCHAR* wsDataBase)
{
	CoInitialize(NULL);
	HRESULT hr;

	// Obtain access to the SQLNCLI provider.
	hr = CoCreateInstance( CLSID_SQLNCLI10,
		NULL,
		CLSCTX_INPROC_SERVER,
		IID_IDBInitialize,
		(void **) &pIDBInitialize);

	if (FAILED(hr)) 
	{
		printf("Failed to get IDBInitialize interface.\n");
		// Handle errors here.
		return -1;
	}

	// Initialize the property values needed to establish the connection.
	for ( int i = 0 ; i < 4 ; i++ )
	{
		VariantInit(&InitProperties[i].vValue);
	}

	// Server name.
	InitProperties[0].dwPropertyID = DBPROP_INIT_DATASOURCE;
	InitProperties[0].vValue.vt = VT_BSTR;

	InitProperties[0].vValue.bstrVal= SysAllocString(wsServer);
	InitProperties[0].dwOptions = DBPROPOPTIONS_REQUIRED;
	InitProperties[0].colid = DB_NULLID;

	// Database.
	InitProperties[1].dwPropertyID = DBPROP_INIT_CATALOG;
	InitProperties[1].vValue.vt = VT_BSTR;
	InitProperties[1].vValue.bstrVal = SysAllocString(wsDataBase);
	InitProperties[1].dwOptions = DBPROPOPTIONS_REQUIRED;
	InitProperties[1].colid = DB_NULLID;

	InitProperties[2].dwPropertyID = DBPROP_AUTH_INTEGRATED;
	InitProperties[2].vValue.vt = VT_BSTR;
	InitProperties[2].vValue.bstrVal = SysAllocString(L"SSPI");
	InitProperties[2].dwOptions = DBPROPOPTIONS_REQUIRED;
	InitProperties[2].colid = DB_NULLID;

	// Properties are set, now construct the DBPROPSET structure (rgInitPropSet) used to pass 
	// an array of DBPROP structures (InitProperties) to the SetProperties method.
	rgInitPropSet[0].guidPropertySet = DBPROPSET_DBINIT;
	rgInitPropSet[0].cProperties = 4;
	rgInitPropSet[0].rgProperties = InitProperties;

	// Set initialization properties.
	hr = pIDBInitialize->QueryInterface(IID_IDBProperties, (void **)&pIDBProperties);
	if (FAILED(hr)) 
	{
		cout << "Failed to get IDBProperties interface.\n";
		// Handle errors here.
		return -1;
	}

	hr = pIDBProperties->SetProperties(1, rgInitPropSet); 
	if (FAILED(hr)) 
	{
		cout << "Failed to set initialization properties.\n";
		// Handle errors here.
		return -1;
	}

	pIDBProperties->Release();

	// Now establish the connection to the data source.
	if (FAILED(pIDBInitialize->Initialize())) 
	{
		cout << "Problem in establishing connection to the data"
			"source.\n";
		// Handle errors here.
		return -1;
	}
	return 0;
}


int SqlServerNCLI::ReleaseResource(void)
{
	return 0;
}


int SqlServerNCLI::CreationSession(void)
{
	// Create a session object.
	if (FAILED(pIDBInitialize->QueryInterface( IID_IDBCreateSession,
		(void**) &pIDBCreateSession))) 
	{
			cout << "Failed to obtain IDBCreateSession interface.\n";
			// Handle error.
			return -1;
	}
	return 0;
}


int SqlServerNCLI::ExecuteSQL(WCHAR* sSQLCMD)
{
	HRESULT hr;

	if (FAILED(pIDBCreateSession->CreateSession( NULL, 
		IID_IDBCreateCommand, 
		(IUnknown**) &pIDBCreateCommand))) {
			cout << "pIDBCreateSession->CreateSession failed.\n";
			// Handle error.
			return -1;
	}

	// Access the ICommandText interface.
	if (FAILED(pIDBCreateCommand->CreateCommand( NULL, 
		IID_ICommandText, 
		(IUnknown**) &pICommandText))) {
			cout << "Failed to access ICommand interface.\n";
			// Handle error.
			return -1;
	}

	// Use SetCommandText() to specify the command text.
	if (FAILED(pICommandText->SetCommandText(DBGUID_DBSQL, sSQLCMD))) {
		cout << "Failed to set command text.\n";
		// Handle error.
		return -1;
	}

	// Execute the command.
	if (FAILED(hr = pICommandText->Execute( NULL, 
		IID_IRowset, 
		NULL, 
		&cNumRows, 
		(IUnknown **) &pIRowset))) {
			cout << "Failed to execute command.\n";
			// Handle error.
			return -1;
	}

	return 0;
}


int SqlServerNCLI::TProcessRecordSet(void)
{
	HRESULT hr;
	int i=0;
	int j=0;
	hr = pIRowset->QueryInterface(IID_IColumnsInfo, (void **)&pIColumnsInfo);
	if (FAILED(hr)) 
	{
		cout << "Failed to get IColumnsInfo interface.\n";
		// Handle errors here.
		return -1;
	} 

	// Retrieve the column information.
	pIColumnsInfo->GetColumnInfo(&lNumCols, &pDBColumnInfo, &pStringsBuffer);

	// Free the column information interface.
	pIColumnsInfo->Release();

	// Create a DBBINDING array.
	DBBINDING * p = (pBindings = new DBBINDING[lNumCols]);
	if (!(p /* pBindings = new DBBINDING[lNumCols] */ ))
		return -1;

	// Using the ColumnInfo structure, fill out the pBindings array.
	for ( j = 0 ; j < lNumCols ; j++ ) 
	{
		pBindings[j].iOrdinal = j+1;
		pBindings[j].obValue = ConsumerBufColOffset;
		pBindings[j].pTypeInfo = NULL;
		pBindings[j].pObject = NULL;
		pBindings[j].pBindExt = NULL;
		pBindings[j].dwPart = DBPART_VALUE;
		pBindings[j].dwMemOwner = DBMEMOWNER_CLIENTOWNED;
		pBindings[j].eParamIO = DBPARAMIO_NOTPARAM;
		pBindings[j].cbMaxLen = (pDBColumnInfo[j].wType == DBTYPE_WSTR) ? pDBColumnInfo[j].ulColumnSize * 2 : pDBColumnInfo[j].ulColumnSize;
		pBindings[j].dwFlags = 0;
		pBindings[j].wType = pDBColumnInfo[j].wType;
		pBindings[j].bPrecision = pDBColumnInfo[j].bPrecision;
		pBindings[j].bScale = pDBColumnInfo[j].bScale;

		// Compute the next buffer offset.
		ConsumerBufColOffset = 
			ConsumerBufColOffset + pBindings[j].cbMaxLen;
	};

	// Get the IAccessor interface.
	hr = pIRowset->QueryInterface(IID_IAccessor, (void **) &pIAccessor);
	if (FAILED(hr)) 
	{
		cout << "Failed to obtain IAccessor interface.\n";
		// Handle errors here.
		return -1;
	}

	// Create an accessor from the set of bindings (pBindings).
	pIAccessor->CreateAccessor(DBACCESSOR_ROWDATA, lNumCols, pBindings, 0, &hAccessor, NULL);

	// Print column names.
	for ( j = 0 ; j < lNumCols ; j++ )
		printf("%-40S", pDBColumnInfo[j].pwszName);

	printf("\n");   // new line after the column names

	// Get a set of 10 rows.
	pIRowset->GetNextRows( NULL, 0, 10, &lNumRowsRetrieved, &pRows);

	// Allocate space for the row buffer.
	BYTE * pBuffer = new BYTE[ConsumerBufColOffset];
	if (!(pBuffer /* = new BYTE[ConsumerBufColOffset] */ )) 
	{
		// Free up all allocated memory.
		pIAccessor->ReleaseAccessor(hAccessor, NULL);
		pIAccessor->Release();
		delete [] pBindings;

		return 0;
	}

	// Create an instance of the data conversion library to convert DBTYPE_CY to string for display
	IDataConvert* pIDataConvert;
	CoCreateInstance(CLSID_OLEDB_CONVERSIONLIBRARY,
		NULL,
		CLSCTX_INPROC_SERVER,
		IID_IDataConvert,
		(void**)&pIDataConvert);

	// variables used in DataConvert
	DBLENGTH cbDstLength;
	DBSTATUS dbsStatus;
	char strCurrency0[25];
	char strCurrency1[25];

	// Display the rows.
	while ( lNumRowsRetrieved > 0 ) 
	{
		// For each row, print the column data.
		for ( j = 0 ; j < lNumRowsRetrieved ; j++ ) 
		{
			// Clear the buffer.
			memset(pBuffer, 0, ConsumerBufColOffset);

			// Get the row data values.
			pIRowset->GetData(hRows[j], hAccessor, pBuffer);

			// Convert DBTYPE_CY values to string		 
			pIDataConvert->DataConvert(DBTYPE_I4,   // wSrcType
				DBTYPE_STR,   // wDstType
				sizeof(LARGE_INTEGER),   // cbSrcLength 
				&cbDstLength,   // pcbDstLength
				&pBuffer[pBindings[0].obValue],   // pSrc
				strCurrency0,   // pDst
				sizeof(strCurrency0),   //cbDstMaxLength
				DBSTATUS_S_OK,   // dbsSrcStatus
				&dbsStatus,   // pdbsStatus
				0,   // bPrecision (used for DBTYPE_NUMERIC only)
				0,   // bScale (used for DBTYPE_NUMERIC only)
				DBDATACONVERT_DEFAULT);   // dwFlags	

			pIDataConvert->DataConvert(DBTYPE_WSTR,   // wSrcType
				DBTYPE_STR,   // wDstType
				20,   // cbSrcLength 
				&cbDstLength,   // pcbDstLength
				&pBuffer[pBindings[1].obValue],   // pSrc
				strCurrency1,   // pDst
				sizeof(strCurrency1),   // cbDstMaxLength
				DBSTATUS_S_OK,   // dbsSrcStatus
				&dbsStatus,   // pdbsStatus
				0,   // bPrecision (used for DBTYPE_NUMERIC only)
				0,   // bScale (used for DBTYPE_NUMERIC only)
				DBDATACONVERT_DEFAULT); // dwFlags

			// Print cost and price values.
			printf("%-40s%s\n", strCurrency0, strCurrency1); //sparra
		};

		// Release the rows retrieved.
		pIRowset->ReleaseRows(lNumRowsRetrieved, hRows, NULL, NULL, NULL);

		// Get the next set of 10 rows.
		pIRowset->GetNextRows(NULL, 0, 10, &lNumRowsRetrieved, &pRows);
	}

	// Free up all allocated memory.
	delete [] pBuffer;
	pIAccessor->ReleaseAccessor(hAccessor, NULL);
	pIAccessor->Release();
	delete [] pBindings;

	return 0;
}
