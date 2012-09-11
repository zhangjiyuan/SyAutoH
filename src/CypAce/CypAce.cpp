// CypAce.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "CypAce.h"
#include <Wincrypt.h>
#include <stdio.h>
#include <tchar.h>

// 这是已导出类的构造函数。
// 有关类定义的信息，请参阅 CypAce.h
CCypAce::CCypAce()
{
	return;
}

LPTSTR CCypAce::HashUserInfo(LPCTSTR strUserName, LPCTSTR strPassword, LPCTSTR strHighMark, LPCTSTR strLowMark)
{
	return LPTSTR();
}


bool CCypAce::HashString(LPCTSTR plainText, LPTSTR hashCode)
{
	bool		rc			= true;		// default is success
	TCHAR		rstData[256]= {0};		// buffer to receive hashed result
	ALG_ID		algorithmID	= CALG_SHA1; // use SHA1 algorithm
	HCRYPTPROV  hProv       = NULL;
	HCRYPTHASH  hHash       = NULL;
	BYTE		pbHash[50]  = {0};
	DWORD       dwDataLen   = 0;

	//--------------------------------------------------------------------
	// Acquire a handle to the default RSA cryptographic service provider.
	if (!CryptAcquireContext(
		&hProv,                   // handle of the CSP
		NULL,                     // key container name
		NULL,                     // CSP name
		PROV_RSA_FULL,            // provider type
		CRYPT_VERIFYCONTEXT))     // no key access is requested
	{
		rc = false;
		goto ErrorExit;
	}

	if (!CryptCreateHash(
		hProv,                    // handle of the CSP
		algorithmID,              // hash algorithm to use
		0,                        // hash key
		0,                        // reserved
		&hHash))                  // address of hash object handle
	{
		rc = false;
		goto ErrorExit;
	}

	if (!CryptHashData(
		hHash,                    // handle of the hash object
		(const BYTE *) plainText, // text to be hash
		_tcslen(plainText)*sizeof(TCHAR), // number of bytes of data
		0))                       // flags
	{
		rc = false;
		goto ErrorExit;
	}

	if (!CryptGetHashParam(
		hHash,                 // handle of the HMAC hash object
		HP_HASHVAL,                // query on the hash value
		NULL,                    // pointer to the HMAC hash value
		&dwDataLen,                // length,in bytes, of the hash
		0))
	{
		rc = false;
		goto ErrorExit;
	}

	if (!CryptGetHashParam(
		hHash,                 // handle of the HMAC hash object
		HP_HASHVAL,                // query on the hash value
		pbHash,                    // pointer to the HMAC hash value
		&dwDataLen,                // length,in bytes, of the hash
		0))
	{
		rc = false;
		goto ErrorExit;
	}

	TCHAR tmpBuffer[3] = {0};
	for (DWORD i = 0 ; i < dwDataLen ; i++) 
	{
		tmpBuffer[0] = 0; tmpBuffer[1] = 0; tmpBuffer[2] = 0;		// clear
		 swprintf_s(tmpBuffer, _T("%2.2x"),pbHash[i]);
		wcscat_s(rstData, tmpBuffer);
	}
	wcscpy_s(hashCode, 256, rstData);

	// Free resources.
ErrorExit:
	if(hHash)
		CryptDestroyHash(hHash);    
	if(hProv)
		CryptReleaseContext(hProv, 0);

	return rc;
}
