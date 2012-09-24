#include "stdafx.h"
#include "commandFun.h"
#include "dataFun.h"
#include "windows.h"
using namespace std;

unsigned char* CommandFuns::Command8001( )
{
	unsigned char OHTID = 1;
	unsigned char stateTime = 25;
	DataContext command_send(OHTID,stateTime);
	unsigned short size = sizeof(_Data_Context);

	isReply_send = 0;
	needReply_send = 1;
	unite(isReply_send,needReply_send);
	unsigned long commandNumber = 0x8001;
	unsigned short bagNumber = 1;
	unsigned char isLastBag = 1;
	DataFun data_send(toChar,commandNumber,bagNumber,isLastBag,command_send.m_dataBuf,size);

	buffer_send = (unsigned char*)data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;

}

unsigned char* CommandFuns::Command8002( )
{
	unsigned char OHTID = 1;
	unsigned char positionTime = 25;
	DataContext command_send(OHTID,positionTime);
	unsigned short size = sizeof(_Data_Context);

	isReply_send = 0;
	needReply_send = 1;
	unite(isReply_send,needReply_send);
	unsigned long commandNumber = 0x8002;
	unsigned short bagNumber = 1;
	unsigned char isLastBag = 1;
	DataFun data_send(toChar,commandNumber,bagNumber,isLastBag,command_send.m_dataBuf,size);

	buffer_send = (unsigned char*)data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;
	
}

unsigned char* CommandFuns::Command8003( )
{
	unsigned char OHTID = 1;
	unsigned char moveType = 0;
	unsigned short startPosition = 0;
	unsigned short stopPosition = 245;
	unsigned char positionCount = 1;
	unsigned short positionNum = 56;
	unsigned char positionMessage = 0;
	DataContext command_send(OHTID,moveType,startPosition,stopPosition,positionCount,positionNum,positionMessage);

	unsigned short size = sizeof(_Data_Context);

	isReply_send = 0;
	needReply_send = 1;
	unite(isReply_send,needReply_send);
	unsigned long commandNumber = 0x8003;
	unsigned short bagNumber = 1;
	unsigned char isLastBag = 1;
	DataFun data_send(toChar,commandNumber,bagNumber,isLastBag,command_send.m_dataBuf,size);

	buffer_send = (unsigned char*)data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;
}
unsigned char* CommandFuns::Command8004( )
{
	unsigned char OHTID = 1;
	unsigned char MCID = 0;
	DataContext command_send(OHTID,MCID);
	unsigned short size = sizeof(_Data_Context);

	isReply_send = 0;
	needReply_send = 1;
	unite(isReply_send,needReply_send);
	unsigned long commandNumber = 0x8003;
	unsigned short bagNumber = 1;
	unsigned char isLastBag = 1;
	DataFun data_send(toChar,commandNumber,bagNumber,isLastBag,command_send.m_dataBuf,size);

	buffer_send = (unsigned char*)data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;
}
unsigned char* CommandFuns::Command8005( )
{
	unsigned char OHTID = 1;
	unsigned char boardNum = 25;
	unsigned char mcCommand = 0;
	DataContext command_send(OHTID,boardNum,mcCommand);
	unsigned short size = sizeof(_Data_Context);

	isReply_send = 0;
	needReply_send = 1;
	unite(isReply_send,needReply_send);
	unsigned long commandNumber = 0x8005;
	unsigned short bagNumber = 1;
	unsigned char isLastBag = 1;
	DataFun data_send(toChar,commandNumber,bagNumber,isLastBag,command_send.m_dataBuf,size);

	buffer_send = (unsigned char*)data_send.m_pMesBuf;
	int buf_length = sizeof(Message);
	memcpy(m_mesBuf,buffer_send,buf_length);
	return m_mesBuf;
}

void CommandFuns::Command8011(char *message,unsigned short len)
{
	DataContext message_accept(message,len);
	cout<<"天车ID："<<"OHTID is:"<<(int)message_accept.data_Context->IdNum<<endl;
	cout<<"状态反馈周期："<<(int)message_accept.data_Context->share[0]<<endl;
}
void CommandFuns::Command8012(char *message,unsigned short len)
{
	DataContext message_accept(message,len);
	cout<<"天车ID："<<(int)message_accept.data_Context->IdNum<<endl;
	cout<<"位置反馈周期"<<(int)message_accept.data_Context->share[0]<<endl;
}
void CommandFuns::Command8013(char *message,unsigned short len)
{
	DataContext message_accept(message,len);
	cout<<"天车ID："<<(int)message_accept.data_Context->IdNum<<endl;
	cout<<"路径设置响应"<<(int)message_accept.data_Context->share[0]<<endl;
}
void CommandFuns::Command8014(char *message,unsigned short len)
{
	DataContext message_accept(message,len);
	cout<<"天车ID："<<(int)message_accept.data_Context->IdNum<<endl;
	cout<<"指令执行状态："<<(int)message_accept.data_Context->share[0]<<endl;
	cout<<"故障报警ID："<<(int)message_accept.data_Context->share[1]<<endl;
}
void CommandFuns::Command8015(char *message,unsigned short len)
{
	DataContext message_accept(message,len);
	cout<<"天车ID："<<(int)message_accept.data_Context->IdNum<<endl;
	cout<<"执行状态："<<(int)message_accept.data_Context->share[0]<<endl;
}
void CommandFuns::Command8016(char *message,unsigned short len)
{
	DataContext message_accept(message,len);
	cout<<"天车ID："<<(int)message_accept.data_Context->IdNum<<endl;
	message_accept.unite(message_accept.data_Context->share[0],message_accept.data_Context->share[1]);
	cout<<"所处位置点编号："<<message_accept.position<<endl;
	cout<<"抓取状态"<<(int)message_accept.data_Context->share[2]<<endl;
}
void CommandFuns::Command8017(char *message,unsigned short len)
{
	DataContext message_accept(message,len);
	cout<<"天车ID："<<(int)message_accept.data_Context->IdNum<<endl;
	message_accept.unite(message_accept.data_Context->share[0],message_accept.data_Context->share[1]);
	cout<<"所处位置点编号："<<message_accept.position<<endl;
}
void CommandFuns::Command8018(char *message,unsigned short len)
{
	DataContext message_accept(message,len);
	cout<<"天车ID："<<(int)message_accept.data_Context->IdNum<<endl;
	cout<<"模式ID："<<(int)message_accept.data_Context->share[0]<<endl;
	cout<<"状态标志"<<(int)message_accept.data_Context->share[1]<<endl;
	cout<<"故障报警ID："<<(int)message_accept.data_Context->share[2]<<endl;
}
void CommandFuns::Command8019(char *message,unsigned short len)
{
	DataContext message_accept(message,len);
	cout<<"天车ID："<<message_accept.data_Context->IdNum<<endl;
}
void CommandFuns::unite(unsigned char first,unsigned char second)
{
	toChar = (first&0xFF)<<7;
	toChar = toChar|(second<<6);
}