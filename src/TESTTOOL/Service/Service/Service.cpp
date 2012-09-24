// Service.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "datafun.h"
#include "commandfun.h"
#include <iostream>
#include <boost/asio.hpp>
using namespace std;

unsigned long number = 0;
unsigned char buf_accept[1024];
unsigned char buf_send[1024];
char *message;
unsigned char *message_send;
unsigned short message_length;

int send_Message(unsigned char *buf)
{
	
	return 0;
}

void command_send(unsigned long cnumber)
{
	CommandFuns anCommand;
	switch(cnumber)
	{
	case(0x8001):
		message_send = anCommand.Command8001();
		memcpy(buf_send,message_send,1024);
		break;
	case(0x8002):
		message_send = anCommand.Command8002();
		memcpy(buf_send,message_send,1024);
		break;
	case(0x8003):
		message_send =anCommand.Command8003();
		memcpy(buf_send,message_send,1024);
		break;
	case(0x8004):
		message_send = anCommand.Command8004();
		
		memcpy(buf_send,message_send,1024);
		break;
	case(0x8005):
		message_send = anCommand.Command8005();
		memcpy(buf_send,message_send,1024);
		break;
	default:
		cout<<"No command is matched!!"<<endl;
		break;
	}
}

void command_accept(unsigned long commandNumber)
{
	CommandFuns anCommand;
	switch(commandNumber)
	{
	case(0x8011):
		anCommand.Command8011(message,message_length);
		break;
	case(0x8012):
		anCommand.Command8012(message,message_length);
		break;
	case(0x8013):
		anCommand.Command8013(message,message_length);
		break;
	case(0x8014):
		anCommand.Command8014(message,message_length);
		break;
	case(0x8015):
		anCommand.Command8015(message,message_length);
		break;
	case(0x8016):
		anCommand.Command8016(message,message_length);
		break;
	case(0x8017):
		anCommand.Command8017(message,message_length);
		break;
	case(0x8018):
		anCommand.Command8018(message,message_length);
		break;
	case(0x8019):
		anCommand.Command8019(message,message_length);
		number = 0x8003;
		break;
	default:
		cout<<"No command is matched!!"<<endl;
		break;

	}
     
}
int _tmain(int argc, _TCHAR* argv[])
{
	number = 0x8005;
	memset(buf_accept,0,1024);
	memset(buf_send,0,1024);
	boost::asio::io_service iosev;
	boost::asio::ip::tcp::acceptor acceptor(iosev, boost::asio::ip::tcp::endpoint(boost::asio::ip::tcp::v4(), 1000)); 
	for(;;)
	{
        boost::asio::ip::tcp::socket socket(iosev);  
        acceptor.accept(socket);  
        //std::cout << socket.remote_endpoint().address() << std::endl; 
    boost::system::error_code ec; 
	if(number == 0x8003)
	{
		command_send(number);
	    socket.write_some(boost::asio::buffer(buf_send),ec);
		number = 0;
	}
	else if(number !=0)
	{
		command_send(number);
	    socket.write_some(boost::asio::buffer(buf_send),ec);
		number = 0;
	}
	else
	{
		socket.read_some(boost::asio::buffer(buf_accept),ec);
		unsigned long length = sizeof(buf_accept);
	    DataFun message_accept(buf_accept,length);
		message = message_accept.m_pMesBuf->data;
		message_length = message_accept.m_pMesBuf->dataLen;
		number = message_accept.m_pMesBuf->commandNum;
		command_accept(number);
	}
	if(ec) 
    { 
        std::cout << boost::system::system_error(ec).what() << std::endl; 
        return -1; 
    } 
	}
	return 0;
}

