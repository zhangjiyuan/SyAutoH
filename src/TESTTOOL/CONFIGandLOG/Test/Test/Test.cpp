// Test.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "Config.h"
#include "Log.h"
#include "stdio.h"
#include "iostream"
#pragma comment(lib,"logconfig.lib")
using namespace std;

void ConfigTest();
void LogTest();
void SLWTest();
int _tmain(int argc, _TCHAR* argv[])
{
	ConfigTest();
	LogTest();
	SLWTest();
	return 0;
}
void ConfigTest()
{
	string lhostname, lusername;
	bool ldatabase;
	int lpassword;
	float lport = 0;
	bool open = Config.MainConfig.SetSource("logon.conf",true);
	if(open == true)
		cout<<"read the file successful"<<endl;
	else 
		cout<<"read the file failed"<<endl;
	bool existsUsername = Config.MainConfig.GetString("LogonDatabase", "Username", &lusername);
	bool existsPassword = Config.MainConfig.GetInt("LogonDatabase", "Password", &lpassword);
	bool existsHostname = Config.MainConfig.GetString("LogonDatabase", "Hostname", &lhostname);
	bool existsName     = Config.MainConfig.GetBool("LogonDatabase", "Name",     &ldatabase);
	bool existsPort     = Config.MainConfig.GetFloat("LogonDatabase", "Port",     &lport);
	cout<<endl<<"Username:"<<lusername.c_str()<<endl;
	cout<<endl<<"PassWord:"<<lpassword<<endl;
	cout<<endl<<"Hostname:"<<lhostname.c_str()<<endl;
	cout<<endl<<"Name:"<<ldatabase<<endl;
	cout<<endl<<"Port:"<<lport<<endl;

	string username;
	string hostname;
	bool Name;
	int word;
	float port;
	username = Config.MainConfig.GetStringDefault("LogonDatabase", "Username","WRONG");
	hostname = Config.MainConfig.GetStringDefault("LogonDatabase", "Hostname", "WRONG");
	Name = Config.MainConfig.GetBoolDefault("LogonDatabase", "Name", false);
	word = Config.MainConfig.GetIntDefault("LogonDatabase", "Password", 0);
	port = Config.MainConfig.GetFloatDefault("LogonDatabase", "Port",0.0001f);
	if(username == "WRONG")
		cout<<endl<<"initialise the Username failed "<<endl;
	else 
	{
		cout<<endl<<"(GetStringVA)"<<Config.MainConfig.GetStringVA("LogonDatabase","failed","Username",1)<<endl;
		char *buffer;
		buffer = (char *)new char[7];
		Config.MainConfig.GetString("LogonDatabase",buffer,"Username","failed",7);
		cout<<endl<<"(GetString(2))limit the username to : "<<buffer<<endl;
	}
	if(hostname == "WRONG")
		cout<<endl<<"initialise the Hostname failed"<<endl;
	if(Name == false)
		cout<<"initialise the Name failed"<<endl;
	if(word == 0)
		cout<<endl<<"initialise the Password failed"<<endl;
	else
	{
		int a;
		a = Config.MainConfig.GetIntVA("LogonDatabase",0,"Password",0);
		cout<<endl<<"GetIntVA  "<<a<<endl;
		if(a == 0)
		{
			cout<<"GetIntVA 获取失败"<<endl;
		}
		    
	}
	if(port == 0.0001)
		cout<<endl<<"initialise the Port failed" <<endl;
	else
	{
		float b;
		b = Config.MainConfig.GetFloatVA("LogonDatabase",0.01f,"Port",0);
		cout<<endl<<"GetFloatVA  "<<b<<endl;
		if(b == 0.01f)
			cout<<"GetFloatVA获取失败"<<endl;
	}
}
void LogTest()
{
	cout<<endl<<"the message under this line is the result of LogTest"<<endl;
	string filename ;
	filename = "testlog";
	cout<<endl;
	Log.Init(0,LOGON_LOG);
	cout<<endl;
	//log level 0
	Log.outString("(test logString)Start the debug:");
	cout<<endl;
	Log.outBasic("(test outBasic）the name is '%s'" ,filename.c_str());
	cout<<endl;
	//log level 1
	Log.SetFileLoggingLevel(1);
	Log.outDetail("（test outDetail)the debug is used for test the function of log ,the name is '%s'",filename.c_str());
	cout<<endl;
	//log level 0
	Log.SetFileLoggingLevel(0);
	Log.Success("(test Success)get the message successfully","make the next step ……");
	string name;
	name = "outDebug";
	//log level 2
	Log.SetFileLoggingLevel(2);
	cout<<endl;
	Log.logBasic(__FILE__,__LINE__,__FUNCTION__,"test logBaic");
	
	cout<<endl;
	Log.logDetail(__FILE__,__LINE__,__FUNCTION__,"test logDetail");
	cout<<endl;
	//log level 0
	Log.SetFileLoggingLevel(1);
	Log.Notice("test Notice","%s","test successful");
	cout<<endl;
	Log.Warning("test Warning","%s","testing");
	cout<<endl;

	cout<<"the message under this line are displayed in the error file"<<endl; 
	Log.LargeErrorMessage("test LargeErrorMessage","success",NULL);
	cout<<endl;
	Log.Error("test Error","%s","no error");
	Log.SetFileLoggingLevel(2);
	cout<<endl;
	Log.logDebug(__FILE__,__LINE__,__FUNCTION__,"test logDebug");
	cout<<endl;
	Log.outDebug("(test outDebug)the function's name: '%s',",name.c_str());
	cout<<endl;
	LOG_ERROR("(test logError) output the error message .");
	cout<<endl;
	//log level 0
	Log.SetFileLoggingLevel(0);
	Log.outError("(test outError),output the error message two,the difference with LogError is the filelevel ");
	cout<<endl;
	//log level 2
	Log.SetFileLoggingLevel(2);
	Log.outErrorSilent("test the outErrorSilent,do not display on the screen");
	cout<<endl;
	Log.logError(__FILE__,__LINE__,__FUNCTION__,"test logError");
	cout<<endl;
	Log.Debug("test Debug","%s","going");
	cout<<endl;

	Log.Close();

	string str;
	str = FormatOutputString("Test","FormatOutputString testing ","true");
	cout<<str<<endl;
	cout<<endl;
}

void SLWTest()
{
	SessionLogWriter SLW("SLWtest.log",true);
	SLW.Open();
	char mes[120] = {"test the SessionLogWriter function , test is successful!"};
	SLW.write("the message is :'%s'",mes);
	SLW.Close();
}
