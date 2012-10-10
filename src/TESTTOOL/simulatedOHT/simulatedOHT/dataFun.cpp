#include "stdafx.h"
#include "dataFun.h"

DataFun::DataFun(unsigned char *buf,unsigned long len)
{
	int nLen = sizeof(Message);
	m_bufLen = len;
	m_pMesBuf = (LPMessage) new char[m_bufLen];
	if (buf && len > 0)
		memcpy(m_pMesBuf,buf,len);
}

DataFun::DataFun(unsigned char sign,unsigned long order,unsigned short bag,unsigned char last,unsigned char *data,unsigned short size )
{
	m_bufLen = sizeof(Message);
	m_pMesBuf = (LPMessage) new char[m_bufLen];
	memset(m_pMesBuf,0,m_bufLen);

	m_pMesBuf->signBit = sign;
	m_pMesBuf->commandNum = order;
	m_pMesBuf->dataLen = size;
	m_pMesBuf->bagNum = bag;
	m_pMesBuf->lastBag = last;

	if(data && size > 0)
		memcpy(m_pMesBuf->data, data,size);
	//buffer = (unsigned char*)m_pMesBuf;
}

DataFun::~DataFun(void)
{
	if(m_pMesBuf)
	{
		delete[] m_pMesBuf;
		m_pMesBuf = 0;
	}    
}

void DataFun::Sign(unsigned char signByte)
{
	toBite = new char[8];
	for(int i=0;i<8;i++)
	{
		toBite[7-i] = ((signByte>>i)&0x00000001)+'0';
	}
}

DataContext::DataContext(unsigned char Num)
{
	int Len = sizeof(_Data_Context);
	data_Context = (LPContext)new char[Len];
	memset(data_Context,0,Len);
	data_Context->IdNum = Num;
	m_dataBuf = (unsigned char*)data_Context;
}
DataContext::DataContext(char *buf,unsigned short length)
{
	data_Context = (LPContext)new char[length];
	memset(data_Context,0,length);
	if(buf&&length)
		memcpy(data_Context,buf,length);
}
DataContext::DataContext(unsigned char Num,unsigned char mes)
{
	int Len = sizeof(_Data_Context);
	data_Context = (LPContext)new char[Len];
	memset(data_Context,0,Len);
	data_Context->IdNum = Num;
	data_Context->share[0] = mes;
	m_dataBuf = (unsigned char*)data_Context;
}
DataContext::DataContext(unsigned char Num,unsigned short positionNum)
{
	int Len = sizeof(_Data_Context);
	data_Context = (LPContext)new char[Len];
	memset(data_Context,0,Len);
	data_Context->IdNum = Num;
	data_Context->share[1] = (unsigned char)positionNum;
	data_Context->share[0] = (unsigned char)(positionNum>>8);
	m_dataBuf = (unsigned char*)data_Context;
}
DataContext::DataContext(unsigned char Num,unsigned char mes1,unsigned char mes2)
{
	int Len = sizeof(_Data_Context);
	data_Context = (LPContext)new char[Len];
	memset(data_Context,0,Len);
	data_Context->IdNum = Num;
	data_Context->share[0] = mes1;
	data_Context->share[1] = mes2;
	m_dataBuf = (unsigned char*)data_Context;
}
DataContext::DataContext(unsigned char Num,unsigned short positionNum,unsigned char state)
{
	int Len = sizeof(_Data_Context);
	data_Context = (LPContext)new char[Len];
	memset(data_Context,0,Len);
	data_Context->IdNum = Num;
	data_Context->share[0] = (unsigned char)positionNum;
	data_Context->share[1] = (unsigned char)(positionNum>>8);
	data_Context->share[2] = state;
	m_dataBuf = (unsigned char*)data_Context;
}
DataContext::DataContext(unsigned char Num,unsigned char modeID,unsigned char stateSign,unsigned char alarmID)
{
	int Len = sizeof(_Data_Context);
	data_Context = (LPContext)new char[Len];
	memset(data_Context,0,Len);
	data_Context->IdNum = Num;
	data_Context->share[0] = modeID;
	data_Context->share[1] = stateSign;
	data_Context->share[2] = alarmID;
	m_dataBuf = (unsigned char*)data_Context;
}
DataContext::DataContext(unsigned char Num,unsigned char moveType,unsigned short currentPos,unsigned short finalPos,unsigned char Count,unsigned short number,unsigned char message)
{
	int Len = sizeof(_Data_Context);
	data_Context = (LPContext)new char[Len];
	memset(data_Context,0,Len);
	data_Context->IdNum = Num;
	data_Context->share[0] = moveType;
	data_Context->share[1] = (unsigned char)(currentPos>>8);
	data_Context->share[2] = (unsigned char)currentPos;
	data_Context->fPosition = finalPos;
	data_Context->pCount = Count;
	data_Context->pNumber = number;
	data_Context->pMessage = message;
	m_dataBuf = (unsigned char*)data_Context;
}
DataContext::~DataContext(void)
{
	if(data_Context)
	{
		delete[] data_Context;
	    data_Context = 0;
	}
}
void DataContext::unite(unsigned char former,unsigned char latter)
{
	position = (unsigned short)former;
	position = position<<7;
	position = position|(unsigned short)latter;
}