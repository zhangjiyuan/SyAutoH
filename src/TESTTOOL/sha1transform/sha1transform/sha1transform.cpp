// sha1transform.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include <Windows.h>
#include "stdio.h"
#include "string.h"
#include <iostream>
#include <algorithm>
#define MYLIBAPI extern "C" _declspec(dllexport)
#include "SHA1.h"

#define SHA1HashSize 20
#define SHA1CircularShift(bits,word)  (((word) << (bits)) | ((word) >> (32-(bits))))

typedef struct 
{
	unsigned int H[5];
	unsigned int Length_Low;
	unsigned int Length_High;
	unsigned char Message_Block[64];
	int Message_Block_Index;
	int corrupted;
	int Computed;
} SHA_CONTEXT;

char Message[20];

void SHAInit(SHA_CONTEXT *hd);
void SHAInput(SHA_CONTEXT *hd,const unsigned char *message_array,unsigned length);
void SHAResult( SHA_CONTEXT *hd);
void SHA1PadMessage(SHA_CONTEXT *hd);   
void SHA1ProcessMessageBlock(SHA_CONTEXT *hd);
string WordsChange(string name,string low,string high,string passWord);

string SHA1Transform(string instr)
{   
	const char *buffer;
	buffer = instr.c_str();
	int n;
	n = strlen(buffer);
	SHA_CONTEXT tx;
	SHAInit(&tx);
	SHAInput(&tx,(const unsigned char*)buffer,n);
	SHAResult(&tx);
	char middle[20];
	string str1;
	for(int i=0;i<5;i++)
	{
		sprintf(middle,"%08x",tx.H[i]);
		strcat(Message,middle);
	}
	string str;
	str=Message;
	return str;
}
 
void SHAInit(SHA_CONTEXT *hd)
{
    memset(Message,'\0',sizeof(Message));

    hd->Length_Low             = 0;
    hd->Length_High            = 0;
    hd->Message_Block_Index    = 0;
	hd->corrupted              = 0;

    hd->H[0]   = 0x67452301;
    hd->H[1]   = 0xEFCDAB89;
    hd->H[2]   = 0x98BADCFE;
    hd->H[3]   = 0x10325476;
    hd->H[4]   = 0xC3D2E1F0;

    hd->Computed   = 0;
}

void SHAInput(SHA_CONTEXT *hd, const unsigned char *message_array, unsigned length)
{

    if (!hd || !message_array)	
    {
        return ;
    }

    if (hd->Computed)
    {
     
        return ;
    }

    if (hd->corrupted)
    {
         return ;
    }

	while(length--)	
    {
		hd->Message_Block[hd->Message_Block_Index++] = (*message_array & 0xFF);

		hd->Length_Low += 8;

		if (hd->Length_Low == 0)
		{
			hd->Length_High++;

			if (hd->Length_High == 0)
			{	
				hd->corrupted = 1;
			}
		}

		if (hd->Message_Block_Index == 64)
		{
			SHA1ProcessMessageBlock(hd);	
		}

		message_array++;	
	}
}

void SHAResult( SHA_CONTEXT *hd)
{
    int i;
	
    if (!hd )	
    {
        return ;
    }
	
    if (hd->corrupted)
    {
        return ;
    }
	
    if (!hd->Computed)	
    {
        SHA1PadMessage(hd);	

        for(i = 0; i < 64; ++i)
        {
            hd->Message_Block[i] = 0;	 
        }

        hd->Length_Low = 0;	
        hd->Length_High = 0;
        hd->Computed = 1;
    }	
}

void SHA1PadMessage(SHA_CONTEXT *hd)
{

    if (hd->Message_Block_Index > 55)
    {
        hd->Message_Block[hd->Message_Block_Index++] = 0x80;
        while(hd->Message_Block_Index < 64)
        {
            hd->Message_Block[hd->Message_Block_Index++] = 0;
        }

        SHA1ProcessMessageBlock(hd);	

        while(hd->Message_Block_Index < 56)
        {
            hd->Message_Block[hd->Message_Block_Index++] = 0;
        }
    }
    else
    {
        hd->Message_Block[hd->Message_Block_Index++] = 0x80;
        while(hd->Message_Block_Index < 56)
        {
            hd->Message_Block[hd->Message_Block_Index++] = 0;
        }
    }

    hd->Message_Block[56] = hd->Length_High >> 24;
    hd->Message_Block[57] = hd->Length_High >> 16;
    hd->Message_Block[58] = hd->Length_High >> 8;
    hd->Message_Block[59] = hd->Length_High;
    hd->Message_Block[60] = hd->Length_Low >> 24;
    hd->Message_Block[61] = hd->Length_Low >> 16;
    hd->Message_Block[62] = hd->Length_Low >> 8;
    hd->Message_Block[63] = hd->Length_Low;

    SHA1ProcessMessageBlock(hd);	
}

void SHA1ProcessMessageBlock(SHA_CONTEXT *hd)
{
    const unsigned int K[4] = {0x5A827999,0x6ED9EBA1,0x8F1BBCDC,0xCA62C1D6};
	
    int              t;                   
    unsigned  int    temp;             
    unsigned  int    W[80];                
    unsigned  int    A, B, C, D, E;      
	
    for(t = 0; t < 16; t++)
    {
        W[t] = hd->Message_Block[t * 4] << 24;
        W[t] |= hd->Message_Block[t * 4 + 1] << 16;
        W[t] |= hd->Message_Block[t * 4 + 2] << 8;
        W[t] |= hd->Message_Block[t * 4 + 3];
    }
	
    for(t = 16; t < 80; t++)
    {
		W[t] = SHA1CircularShift(1,W[t-3] ^ W[t-8] ^ W[t-14] ^ W[t-16]);
    }
	
    A = hd->H[0];
    B = hd->H[1];
    C = hd->H[2];
    D = hd->H[3];
    E = hd->H[4];
	
    for(t = 0; t < 20; t++)
    {
        temp = SHA1CircularShift(5,A) + ((B & C) | ((~B) & D)) + E + W[t] + K[0];
        E = D;
        D = C;
        C = SHA1CircularShift(30,B);
		B = A;
        A = temp;
    }
	
    for(t = 20; t < 40; t++)
    {
        temp = SHA1CircularShift(5,A) + (B ^ C ^ D) + E + W[t] + K[1];
        E = D;
        D = C;
        C = SHA1CircularShift(30,B);
        B = A;
        A = temp;
    }
	
    for(t = 40; t < 60; t++)
    {
        temp = SHA1CircularShift(5,A) + ((B & C) | (B & D) | (C & D)) + E + W[t] + K[2];
        E = D;
        D = C;
        C = SHA1CircularShift(30,B);
        B = A;
        A = temp;
    }
	
    for(t = 60; t < 80; t++)
    {
        temp = SHA1CircularShift(5,A) + (B ^ C ^ D) + E + W[t] + K[3];
        E = D;
        D = C;
        C = SHA1CircularShift(30,B);
        B = A;
        A = temp;
    }

    hd->H[0] += A;
    hd->H[1] += B;
    hd->H[2] += C;
    hd->H[3] += D;
    hd->H[4] += E;
	
    hd->Message_Block_Index = 0;
}

string HashLoginInfo(string& sName, string& sHighMark, string& sLowMark, string& sPassword)
{
	transform(sName.begin(),sName.end(),sName.begin(),tolower);
	string message;
	message=WordsChange(sName,sLowMark,sHighMark,sPassword);
	string sha1message;
	sha1message = SHA1Transform(message); 
	return sha1message;
}

string WordsChange(string name,string low,string high,string passWord)
{
	char firstWord;
	char last[4];
	string middle;
	string wholeMessage;
	firstWord = name[0];
	firstWord = firstWord&0x0F;
	for(int i = 0;i<4;i++)
	{
		last[3-i] = ((firstWord>>i)&0x00000001)+'0';
	}
	for(int i=0;i<4;i++)
	{
		if(last[i]!='0')
			middle += high;
		else
			middle += low;
	}
	wholeMessage += name ;
	wholeMessage +=middle;
	wholeMessage +=passWord;
	return wholeMessage;
}




