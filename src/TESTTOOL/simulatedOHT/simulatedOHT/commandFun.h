#pragma once
#include "stdio.h"
#include "iostream"

//定义命令码函数类
class CommandFuns
{
public:
	void Command8001( char *message,unsigned short len);
	void Command8002( char *message,unsigned short len);
	void Command8003( char *message,unsigned short len);
	void Command8004( char *message,unsigned short len);
	void Command8005( char *message,unsigned short len);
	unsigned char* Command8011( );
	unsigned char* Command8012( );
	unsigned char* Command8013( );
    unsigned char* Command8014( );
	unsigned char* Command8015( );
	unsigned char* Command0816( );
	unsigned char* Command8017( );
	unsigned char* Command8018( );
    unsigned char* Command8019( );
public:
	void unite(unsigned char first,unsigned char second);
public:
	unsigned char* message_send;
	unsigned char* buffer_send;
	unsigned char isReply_send;
	unsigned char needReply_send;
	//unsigned short mesBuf_length;
	unsigned short message_length;
	unsigned char toChar;
	unsigned long commandNum;
	unsigned char m_mesBuf[1024];
};