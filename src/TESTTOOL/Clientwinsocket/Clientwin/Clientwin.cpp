// Clientwin.cpp : 定义控制台应用程序的入口点。
//


#include "stdafx.h"
#include <iostream>
#include <winsock.h>
#include <windows.h>
#pragma comment(lib,"wsock32")

using namespace std;

WSADATA wsaData;
WORD version = MAKEWORD(1,1);
typedef unsigned __int8 uint8;
typedef unsigned __int16 uint16;
typedef unsigned __int32 uint32;
#define max_body_length = 512;
uint8 body[4];
#pragma pack(1)
struct AMHSPktHeader
{
	uint8 comm;
	uint32 cmd;
	uint16 size;
	uint16 index;
	uint8  bLast;
	uint8 reversed[4];
};
AMHSPktHeader PktHeader;
#pragma pack()
uint16 header_length = sizeof(AMHSPktHeader);
uint8 data_[526];

void Send_Message(const char* buf,uint16 length)
{
	cout<<buf<<endl;
	int ret = WSAStartup(version,&wsaData);
    if(ret)
        cout<<"initial failure"<<endl;
    else
        cout<<"initial successfully"<<endl;
    SOCKET m_hSocket = socket(AF_INET,SOCK_STREAM,0);

    if(m_hSocket!=NULL)
        cout<<"create socket successfully"<<endl;
    else
        cout<<"socket create error"<<endl;

    sockaddr_in m_addr;
    m_addr.sin_family = AF_INET;
    m_addr.sin_addr.s_addr=inet_addr("127.0.0.1");
    m_addr.sin_port = htons(9999);
    ret = 0;
    ret = connect(m_hSocket,(LPSOCKADDR)&m_addr,sizeof(m_addr));
    if(ret==SOCKET_ERROR)
        cout<<"connect error = "<<WSAGetLastError()<<endl;
    else
        cout<<"connect successfully"<<endl;
    ret = 0;
    ret = send(m_hSocket,buf,length,0);
    closesocket(m_hSocket);
    WSACleanup(); 
}

void EncodeHeader(uint16 body_length_)
{
    memset(&PktHeader, 0, header_length);
    PktHeader.cmd = 0x0816;
	PktHeader.size = body_length_;
	uint8 comm = 0;
	PktHeader.comm = comm;
	if (body_length_ < 512)
	{
		PktHeader.bLast = 1;
		PktHeader.index = 1;
	}
	memcpy(data_,&PktHeader, header_length);
	
}

void  EncodeBody(uint8 nOHTID,uint16 nposition,uint8 handstatus)
{
	memset(body,0,4);
	memcpy(body,&nOHTID,1);
	memcpy(body + 1,&nposition,2);
	memcpy(body + 3,&handstatus,1);
}
int _tmain(int argc, _TCHAR* argv[])
{   
	memset(data_,0,526);
    int OHTID = 0;
	uint16 nposition = 0;
	uint8  handstatus = 0;
	cout<<"Please input the ID of the OHT online: "<<endl;
	cin>>OHTID;
	cout<<"Please intput the OHT's position: "<<endl;
	cin>>nposition;
	cout<<"Please input the OHT's handstatus: "<<endl;
	cin>>handstatus;
	uint8 nOHTID = (uint8)OHTID;
	EncodeBody(nOHTID,nposition,handstatus);
	uint16 body_length = 4;
	EncodeHeader(body_length);
	memcpy(data_ + header_length,body,body_length);
	uint16 data_length_ = header_length + body_length;
	Send_Message((const char *)data_,data_length_);
	return 0;
}
