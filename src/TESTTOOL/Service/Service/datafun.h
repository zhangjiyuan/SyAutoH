#ifdef _DATA_FUN
#else 
#define _DATA_FUN
#include "stdio.h"
#include <iostream>
 
#pragma pack(1)
typedef struct _Data_Message
{
	unsigned char  signBit;
	unsigned long  commandNum;
	unsigned short dataLen;
	unsigned short bagNum;
	unsigned char lastBag;
    unsigned long  unkown;
	char data[512];
}Message,*LPMessage;
//消息体共用结构体尝试
#pragma pack(1)
typedef struct _Data_Context
{
	unsigned char IdNum;
	unsigned char share[3];
	unsigned short fPosition;
	unsigned char pCount;
	unsigned short pNumber;
	unsigned char pMessage;
}*LPContext;
#pragma pack()
class DataFun 
{
public:
	DataFun(unsigned char *buf,unsigned long len);
	DataFun(unsigned char sign,unsigned long order,unsigned short bag,unsigned char last,unsigned char *data,unsigned short size = 0);
	virtual ~DataFun(void);

public:
	//unsigned char* buffer;
	void Sign(unsigned char signByte);
	char *toBite;
	LPMessage m_pMesBuf;  //消息实例
	unsigned int m_bufLen;//记录数据空间长度
};
class DataContext
{
public:
	DataContext(unsigned char Num);
	DataContext(char*buf,unsigned short length);
	DataContext(unsigned char Num,unsigned char mes);
	DataContext(unsigned char Num,unsigned short positionNum);
	DataContext(unsigned char Num,unsigned char mes1,unsigned char mes2);
	DataContext(unsigned char Num,unsigned short positionNum,unsigned char state);
	DataContext(unsigned char Num,unsigned char modeID,unsigned char stateSign,unsigned char alarmID);
	DataContext(unsigned char Num,unsigned char moveType,unsigned short currentPos,unsigned short finalPos,unsigned char Count,unsigned short number,unsigned char message);
	virtual ~DataContext(void);
public:
	void unite(unsigned char former,unsigned char latter);
	LPContext data_Context;
	unsigned char *m_dataBuf;
	unsigned short position;
};
#endif