#include "stdafx.h"
#include "commandFun.h"
#include "dataFun.h"
#include "windows.h"
using namespace std;

void CommandFuns::Command8001( char *message,unsigned short len)
{
	DataContext dataMes(message,len);
	BYTE OHTID = dataMes.data_Context->IdNum;
	BYTE stateTime = dataMes.data_Context->share[0];
	cout<<"小车ID："<<(int)OHTID<<endl;
	cout<<"状态反馈周期是"<<(int)stateTime<<"ms"<<endl;
}

void CommandFuns::Command8002( char *message,unsigned short len)
{
	DataContext dataMes(message,len);
	BYTE OHTID = dataMes.data_Context->IdNum;
	BYTE positionTime = dataMes.data_Context->share[0];
	cout<<"天车ID:"<<(int)OHTID<<endl;
	cout<<"位置反馈周期是"<<(int)positionTime<<"ms"<<endl;

}

void CommandFuns::Command8003( char *message, unsigned short len)
{
	//std::cout<<"传递的是"<<(int)*message<<std::endl;
	DataContext dataMes(message,len);
	unsigned char OHTID = dataMes.data_Context->IdNum;
	unsigned char moveType = dataMes.data_Context->share[0];
	dataMes.unite(dataMes.data_Context->share[1],dataMes.data_Context->share[2]);
	unsigned short currentP = dataMes.position;
	unsigned short finalP = dataMes.data_Context->fPosition;
	unsigned char pCount = dataMes.data_Context->pCount;
	unsigned short positionID = dataMes.data_Context->pNumber;
	unsigned char Pmessage = dataMes.data_Context->pMessage;

	std::cout<<"天车ID是："<<(int)OHTID<<std::endl;
	std::cout<<"运动模式代码是："<<(int)moveType<<std::endl;
	std::cout<<"起始点位置："<<currentP<<std::endl;
	std::cout<<"目的点位置："<<finalP<<std::endl;
	std::cout<<"路径关键位置个数："<<(int)pCount<<std::endl;
	std::cout<<"关键位置编号："<<positionID<<std::endl;
	std::cout<<"关键位置信息："<<(int)Pmessage<<std::endl;
}
void CommandFuns::Command8004( char *message,unsigned short len)
{
	DataContext dataMes(message,len);
	BYTE OHTID = dataMes.data_Context->IdNum;
	BYTE MCID = dataMes.data_Context->share[0];
	cout<<"天车ID:"<<(int)OHTID<<endl;
	cout<<"运动控制ID:"<<(int)MCID<<endl;
}
void CommandFuns::Command8005( char *message,unsigned short len)
{
	DataContext dataMes(message,len);
	BYTE OHTID = dataMes.data_Context->IdNum;
	BYTE boardID = dataMes.data_Context->share[0];
	BYTE controlC = dataMes.data_Context->share[2];
	cout<<"天车ID:"<<(int)OHTID<<endl;
	cout<<"储存柜编号:"<<(int)boardID<<endl;
	cout<<"控制指令："<<(int)controlC<<endl;
}

unsigned char* CommandFuns::Command8011()
{
	unsigned char OHTID = 1;
	unsigned char commandReply = 25;
	DataContext dataMes(OHTID,commandReply);
	message_length = sizeof(_Data_Context);
	message_send = dataMes.m_dataBuf;
	//mesBuf_length = sizeof(dataMes.d8iata_Context);
	isReply_send = 1;
	needReply_send = 0;
	unite(isReply_send,needReply_send);
	commandNum = 0x8011;
	unsigned short bagNum = 1;
	unsigned char lastBag = 1;
	DataFun data_send(toChar,commandNum,bagNum,lastBag,message_send,message_length);
	buffer_send = (unsigned char*) data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;
}
unsigned char* CommandFuns::Command8012()
{
	unsigned char OHTID = 1;
	unsigned char commandReply = 25;
	DataContext dataMes(OHTID,commandReply);
	message_length = sizeof(_Data_Context);
	message_send = dataMes.m_dataBuf;
	//mesBuf_length = sizeof(dataMes.data_Context);

	isReply_send = 1;
	needReply_send = 0;
	unite(isReply_send,needReply_send);
	commandNum = 0x8012;
	unsigned short bagNum = 1;
	unsigned char lastBag = 1;
	DataFun data_send(toChar,commandNum,bagNum,lastBag,message_send,message_length);
	buffer_send = (unsigned char*) data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;
}
unsigned char* CommandFuns::Command8013()
{
	unsigned char OHTID = 1;
	unsigned char commandReply = 0;
	DataContext dataMes(OHTID,commandReply);
	message_length = sizeof(_Data_Context);
	message_send = dataMes.m_dataBuf;
	//mesBuf_length = sizeof(dataMes.data_Context);
	isReply_send = 1;
	needReply_send = 0;
	unite(isReply_send,needReply_send);
	commandNum = 0x8013;
	unsigned short bagNum = 1;
	unsigned char lastBag = 1;
	DataFun data_send(toChar,commandNum,bagNum,lastBag,message_send,message_length);
	//std::cout<<data_send.m_pMesBuf->commandNum<<std::endl;
	buffer_send = (unsigned char*) data_send.m_pMesBuf;
	//std::cout<<*buffer_send<<std::endl;
	int buf_length = sizeof(Message);
	//std::cout<<buf_length<<std::endl;
	memcpy(m_mesBuf,buffer_send,buf_length);
	//std::cout<<m_mesBuf<<std::endl;
    DataFun datadata(m_mesBuf,1024);
	//std::cout<<datadata.m_pMesBuf->commandNum<<std::endl;
	return m_mesBuf;
}
unsigned char* CommandFuns::Command8014()
{
	unsigned char OHTID = 1;
	unsigned char operateSituation = 1;
	unsigned char alarmID = 0;
	DataContext dataMes(OHTID,operateSituation,alarmID);
	message_length = sizeof(_Data_Context);
	message_send = dataMes.m_dataBuf;
	//mesBuf_length = sizeof(dataMes.data_Context);

	isReply_send = 1;
	needReply_send = 0;
	unite(isReply_send,needReply_send);
	commandNum = 0x8014;
	unsigned short bagNum = 1;
	unsigned char lastBag = 1;
	DataFun data_send(toChar,commandNum,bagNum,lastBag,message_send,message_length);
	buffer_send = (unsigned char*) data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;
}
unsigned char* CommandFuns::Command8015()
{
	unsigned char OHTID = 1;
	unsigned char operateSituation = 0;
	DataContext dataMes(OHTID,operateSituation);
	message_length = sizeof(_Data_Context);
	message_send = dataMes.m_dataBuf;
	//mesBuf_length = sizeof(dataMes.data_Context);

	isReply_send = 1;
	needReply_send = 0;
	unite(isReply_send,needReply_send);
	commandNum = 0x8015;
	unsigned short bagNum = 1;
	unsigned char lastBag = 1;
	DataFun data_send(toChar,commandNum,bagNum,lastBag,message_send,message_length);
	buffer_send = (unsigned char*) data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memset(m_mesBuf,0,1024);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;
}
unsigned char* CommandFuns::Command8016()
{
	unsigned char OHTID = 1;
	unsigned short positionNum = 25;
	unsigned char holdState = 0;
	DataContext dataMes(OHTID,positionNum,holdState);
	message_length = sizeof(_Data_Context);
	message_send = dataMes.m_dataBuf;
	//mesBuf_length = sizeof(dataMes.data_Context);

	isReply_send = 1;
	needReply_send = 0;
	unite(isReply_send,needReply_send);
	commandNum = 0x8016;
	unsigned short bagNum = 1;
	unsigned char lastBag = 1;
	DataFun data_send(toChar,commandNum,bagNum,lastBag,message_send,message_length);
	buffer_send = (unsigned char*) data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;
}
unsigned char* CommandFuns::Command8017()
{
	unsigned char OHTID = 1;
	unsigned short positionNum = 25;
	DataContext dataMes(OHTID,positionNum);
	message_length = sizeof(_Data_Context);
	message_send = dataMes.m_dataBuf;
	//mesBuf_length = sizeof(dataMes.data_Context);

	isReply_send = 1;
	needReply_send = 0;
	unite(isReply_send,needReply_send);
	commandNum = 0x8017;
	unsigned short bagNum = 1;
	unsigned char lastBag = 1;
	DataFun data_send(toChar,commandNum,bagNum,lastBag,message_send,message_length);
	buffer_send = (unsigned char*) data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;
}
unsigned char* CommandFuns::Command8018()
{
	unsigned char OHTID = 1;
	unsigned char modeID = 1;
	unsigned char stateSign = 2;
	unsigned char alarmID = 0;
	DataContext dataMes(OHTID,modeID,stateSign,alarmID);
	message_length = sizeof(_Data_Context);
	message_send = dataMes.m_dataBuf;
	//mesBuf_length = sizeof(dataMes.data_Context);

	isReply_send = 1;
	needReply_send = 0;
	unite(isReply_send,needReply_send);
	commandNum = 0x8018;
	unsigned short bagNum = 1;
	unsigned char lastBag = 1;
	DataFun data_send(toChar,commandNum,bagNum,lastBag,message_send,message_length);
	buffer_send = (unsigned char*) data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;
}
unsigned char* CommandFuns::Command8019()
{
	unsigned char OHTID = 1;
	DataContext dataMes(OHTID);
	message_length = sizeof(_Data_Context);
	message_send = dataMes.m_dataBuf;
	//mesBuf_length = sizeof(dataMes.data_Context);

	isReply_send = 1;
	needReply_send = 1;
	unite(isReply_send,needReply_send);
	commandNum = 0x8019;
	unsigned short bagNum = 1;
	unsigned char lastBag = 1;
	DataFun data_send(toChar,commandNum,bagNum,lastBag,message_send,message_length);
	buffer_send = (unsigned char*) data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;
}
void CommandFuns::unite(unsigned char first,unsigned char second)
{
	toChar = (first&0xFF)<<7;
	toChar = toChar|(second<<6);
}