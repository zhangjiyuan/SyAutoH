// simulatedOHT.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "dataFun.h"
#include "commandFun.h"
#include <boost\asio.hpp>
using namespace std;

unsigned char buf_accept[1024];
unsigned char buf_send[1024];
unsigned char replyMes = 1;
unsigned char isNeedReply = 1;
int commandNum;                               //获得的命令码
char *message_accept;                         //获得的消息体
unsigned short mesLength;                     //消息体长度
unsigned char *message_send;
size_t len;

string host = "127.0.0.1";
int wsport = 9999;

int accept()
{
	boost::asio::io_service iosev; 
    boost::asio::ip::tcp::socket socket(iosev); 
    boost::asio::ip::tcp::endpoint ep(boost::asio::ip::address_v4::from_string(host), wsport); 
    boost::system::error_code ec; 
    socket.connect(ep,ec); 
    if(ec) 
    { 
        std::cout << boost::system::system_error(ec).what() << std::endl; 
        return -1; 
    } 
	//memset(buf_send,1,1024);
	//socket.write_some(boost::asio::buffer(buf_accept));
	memset(buf_send,0,1024);
	len = socket.read_some(boost::asio::buffer(buf_accept), ec); 
	return 0;
}
int send_Message(unsigned char *buf)
{
	memcpy(buf_send,buf,1024);
	boost::asio::io_service iosev; 
    boost::asio::ip::tcp::socket socket(iosev); 
    boost::asio::ip::tcp::endpoint ep(boost::asio::ip::address_v4::from_string(host), wsport); 
    boost::system::error_code ec; 
    socket.connect(ep,ec); 
    if(ec) 
    { 
        std::cout << boost::system::system_error(ec).what() << std::endl; 
        return -1; 
    } 
	socket.write_some(boost::asio::buffer(buf_send),ec);
	return 0;
}
//void read_Message(DataFun data,unsigned short bufLen)
//{
	//DataFun data(buf_accept,bufLen);
	//data.Sign(data.m_pMesBuf->signBit);
	//replyMes = (char)data.toBite[0];
	//isNeedReply = (char)data.toBite[1];
	//commandNum = data.m_pMesBuf->commandNum;
	//message_accept = new char[data.m_pMesBuf->dataLen];
	//message_accept = data.m_pMesBuf->data;
	//DataContext data1(data.m_pMesBuf->data,data.m_pMesBuf->dataLen);

	//cout<<data1.data_Context->IdNum<<endl;
	//cout<<data1.data_Context->fPosition<<endl;
	//cout<<data1.data_Context->pMessage<<endl;

	//mesLength = data.m_pMesBuf->dataLen;
	//cout<<data.m_pMesBuf->data<<endl;
	//cout<<(int)mesLength<<endl;
	//cout<<*message_accept<<endl;
//}


void analytic_Command(int command)
{
	CommandFuns anCommand;
	switch(command)
	{
		case(0x8001):
			anCommand.Command8001(message_accept,mesLength);
			if(isNeedReply)
			{
				message_send = anCommand.Command8011();
				send_Message(message_send);
			}

			break;
		case(0x8002):
			anCommand.Command8002(message_accept,mesLength);
			if(isNeedReply)
			{
				message_send = anCommand.Command8012();
				send_Message(message_send);
			}
			break;
		case(0x8003):
			anCommand.Command8003(message_accept,mesLength);
			if(isNeedReply)
			{
				message_send = anCommand.Command8013();
				send_Message(message_send);
			}
			break;
		case(0x8004):
			anCommand.Command8004(message_accept,mesLength);
			if(isNeedReply)
			{
				message_send = anCommand.Command8014();
				send_Message(message_send);
			}
			break;
		case(0x8005):
			anCommand.Command8005(message_accept,mesLength);
			if(isNeedReply)
			{
				message_send = anCommand.Command8015();
				send_Message(message_send);
			}
			break;
		default:
			break; 
	}
}

int _tmain(int argc, _TCHAR* argv[])
{
    memset(buf_accept,0,1024);
	accept();
	//while(1)
	{
		if (len)
		{
			unsigned short bufLen = sizeof(buf_accept);
			DataFun data(buf_accept,bufLen);
			data.Sign(data.m_pMesBuf->signBit);
			replyMes = (char)data.toBite[0];
			isNeedReply = (char)data.toBite[1];
			//commandNum = data.m_pMesBuf->commandNum;
			commandNum = data.m_pMesBuf->commandNum;
			message_accept = new char[data.m_pMesBuf->dataLen];
			message_accept = data.m_pMesBuf->data;
			mesLength = data.m_pMesBuf->dataLen;
			analytic_Command(commandNum);

			analytic_Command(0x8001);
		}
	   
	}
	return 0;
}




