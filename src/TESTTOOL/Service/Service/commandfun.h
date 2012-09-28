#pragma once
#include "stdio.h"
#include "iostream"

//定义命令码函数类
class CommandFuns
{
public:
	unsigned char* Command8001( );
	unsigned char* Command8002( );
	unsigned char* Command8003( );
	unsigned char* Command8004( );
	unsigned char* Command8005( );
	void Command8011(char *message,unsigned short len );
	void Command8012(char *message,unsigned short len );
	void Command8013(char *message,unsigned short len );
    void Command8014(char *message,unsigned short len );
	void Command8015(char *message,unsigned short len );
	void Command8016(char *message,unsigned short len );
	void Command8017(char *message,unsigned short len );
	void Command8018(char *message,unsigned short len );
    void Command8019(char *message,unsigned short len );
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