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
