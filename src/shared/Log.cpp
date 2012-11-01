#include "stdafx.h"
#include "Config.h"
#include "LOG.h"
//#include <cstdarg>
using namespace std;
string FormatOutputString(const char* Prefix, const char* Description, bool useTimeStamp)
{
	char p[MAX_PATH];
	p[0] = 0;
	time_t t = time(NULL);
	tm* a = gmtime(&t);
	strcat(p, Prefix);
	strcat(p, "/");
	strcat(p, Description);
	if(useTimeStamp)
	{
		char ftime[100];
		snprintf(ftime, 100, "-%-4d-%02d-%02d %02d-%02d-%02d", a->tm_year + 1900, a->tm_mon + 1, a->tm_mday, a->tm_hour, a->tm_min, a->tm_sec);
		strcat(p, ftime);
	}
	strcat(p, ".log");
	return string(p);
}

string SetNewName(const char* Description, bool useTimeStamp)
{
	char p[MAX_PATH];
	p[0] = 0;
	time_t t = time(NULL);
	tm* a = gmtime(&t);
	strcat(p, Description);
	if(useTimeStamp)
	{
		char ftime[100];
		snprintf(ftime, 100, "-%-4d-%02d-%02d-%02d%02d%02d", a->tm_year + 1900, a->tm_mon + 1, a->tm_mday, a->tm_hour+8, a->tm_min, a->tm_sec);
		strcat(p, ftime);
	}
	strcat(p, ".log");
	return string(p);
}
createFileSingleton(oLog);
//initialiseSingleton(WorldLog);

 time_t UNIXTIME;
 tm g_localTime;

oLog::oLog()
 {
	 hMutex_level = CreateMutex(NULL,FALSE,NULL);
	 hMutex_queue = CreateMutex(NULL,FALSE,NULL);
	 hMutex_file = CreateMutex(NULL,FALSE,NULL);
	 hMutex_write = CreateMutex(NULL,FALSE,NULL);
	 m_normalFile = fopen("normal.log","a");
	 m_errorFile = fopen("error.log","a");
	 _beginthreadex(NULL,0,WriteFile,this,0,0);
	 m_fileLogLevel = NOT_GET_LEVEL;
 }
void oLog::Append(PElement m_mes)
 {
	 WaitForSingleObject(hMutex_queue,INFINITE);
	 Mes.push(m_mes);
	 ReleaseMutex(hMutex_queue);
 }
bool oLog::Remove()
{
	WaitForSingleObject(hMutex_queue,INFINITE);
	if(Mes.size() != 0)
	{
		m_Mes_Write = Mes.front();
	    Mes.pop();
	    ReleaseMutex(hMutex_queue);
		return true;
	}
	else
	{
		ReleaseMutex(hMutex_queue);
		return false;
	}
}
unsigned __stdcall oLog::WriteFile(PVOID pParam)
{
	oLog* This = (oLog *)pParam;
	while(1)
	{
		FILE* file = NULL;
		if(This->Remove())
		{
			if(This->m_Mes_Write->file == NORMAL_FILE)
				file = This->m_normalFile;
			else if(This->m_Mes_Write->file == ERROR_FILE)
				file = This->m_errorFile;
			else
				GetLastError();
			char *source = This->m_Mes_Write->source;
			if(source != NULL)
			{
				This->outFile(file,This->m_Mes_Write->mes,This->m_Mes_Write->out_colour,This->m_Mes_Write->source);
			}
			else
			{
				This->outFile(file,This->m_Mes_Write->mes,This->m_Mes_Write->out_colour);
			}
		}
	}
}
void oLog::outFile(FILE* file, char* msg,int colour,const char* source)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	switch(colour)           //由信息类型选择命令行输出字体的颜色，暂定三种：红、黄、绿
	{
	case(1):
		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),FOREGROUND_INTENSITY |FOREGROUND_RED | FOREGROUND_GREEN); //yellow
		break;
	case(2):
		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),FOREGROUND_INTENSITY |FOREGROUND_RED); //red 
		break;
	default:
		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),FOREGROUND_INTENSITY |FOREGROUND_RED |
			    FOREGROUND_GREEN | FOREGROUND_BLUE);//white
		break;
	}
	if(file == m_normalFile)
	{
		int32 file_length = filelength(fileno(file));
	    if(file_length >= 900*1000)
	    {
			fclose(file);
			string filename = SetNewName("normal",true); // 获得新的LOG文件的名字，以类型及时间命名
			rename("normal.log",filename.c_str());
			if(rename != 0)
				perror("rename");
			file = fopen("normal.log","a");
			//m_normalFile = file;
	    }
	}
	
	else if(file == m_errorFile)
	{
		int32 file_length = filelength(fileno(file));
	    if(file_length >= 900*1000)
	    {
			fclose(file);
			string filename = SetNewName("error",true); // 获得新的LOG文件的名字，以类型及时间命名
			rename("error.log",filename.c_str());
			if(rename != 0)
				perror("rename");
			file = fopen("error.log","a");
			//m_errorFile = file;
	    }
	}
	if(source != NULL)
	{
		printf("%s %s: %s\n", time_buffer, source, msg);
		if (file != NULL)
		{
			WaitForSingleObject(hMutex_write,INFINITE);
			fprintf(file, "%s %s: %s\n", time_buffer, source, msg);
			ReleaseMutex(hMutex_write);
		}
	}
	else
	{
		printf("%s %s\n", time_buffer, msg);
		if (file != NULL)
		{
			WaitForSingleObject(hMutex_write,INFINITE);
			fprintf(file, "%s %s\n", time_buffer, msg);
			ReleaseMutex(hMutex_write);
		}
	}
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),FOREGROUND_INTENSITY |FOREGROUND_RED |
			    FOREGROUND_GREEN | FOREGROUND_BLUE);//white
	//out_colour = LINE_COLOUR_WHITE;
}

/// Prints text to file without showing it to the user. Used for the startup banner.
void oLog::outFileSilent(FILE* file, char* msg, const char* source)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	//char szltr_buffer[SZLTR_LENGTH];
	Time(time_buffer);
	//pdcds(SZLTR, szltr_buffer);

	if(source != NULL)
	{
		WaitForSingleObject(hMutex_write,INFINITE);
		fprintf(file, "%s %s: %s\n", time_buffer, source, msg);
		ReleaseMutex(hMutex_write);
		// Don't use printf to prevent text from being shown in the console output.
	}
	else
	{
		WaitForSingleObject(hMutex_write,INFINITE);
		fprintf(file, "%s %s\n", time_buffer, msg);
		ReleaseMutex(hMutex_write);
		// Don't use printf to prevent text from being shown in the console output.
	}
}

void oLog::Time(char* buffer)
{
	time_t now;
	struct tm* timeinfo = NULL;

	time(&now);
	timeinfo = localtime(&now);

	if(timeinfo != NULL)
	{
		strftime(buffer, TIME_FORMAT_LENGTH, TIME_FORMAT, timeinfo);
	}
	else
	{
		buffer[0] = '\0';
	}
}

void oLog::outString(const char* str, ...)
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
		SetFileLoggingLevel();
	}
	if(m_fileLogLevel == -1)
		return;
	//if(m_normalFile == NULL)
		//m_normalFile = fopen("normal.log","a");

	char buf[32768];
	va_list ap;

	va_start(ap, str);
	vsnprintf(buf, 32768, str, ap);
	va_end(ap);
	PElement m_Mes_String;
	m_Mes_String = (PElement) new char[sizeof(element)];
	m_Mes_String->file =NORMAL_FILE;
	memcpy(m_Mes_String->mes,buf,sizeof(buf));
	m_Mes_String->out_colour = LINE_COLOUR_WHITE;
	memset(m_Mes_String->source,0,1024);
	Append(m_Mes_String);
	//outFile(m_normalFile, buf);
}

void oLog::outError(const char* err, ...)
{
    if(funcInCon == false)
	{
		if(m_fileLogLevel == NOT_GET_LEVEL)
		{
		    SetFileLoggingLevel();
		}
	    if(m_fileLogLevel == -1)
			return;
	}
	//if(m_errorFile == NULL)
		//m_errorFile = fopen("error.log","a");

	char buf[32768];
	va_list ap;

	va_start(ap, err);
	vsnprintf(buf, 32768, err, ap);
	va_end(ap);
	PElement m_Mes_Error;//新建一个局部变量，避免成员变量冲突
	m_Mes_Error = (PElement) new char[sizeof(element)];
	m_Mes_Error->file = ERROR_FILE;
	memcpy(m_Mes_Error->mes,buf,sizeof(buf));
	m_Mes_Error->out_colour = LINE_COLOUR_RED;
	memset(m_Mes_Error->source,0,1024);
	Append(m_Mes_Error);	
	//outFile(m_errorFile, buf);
}

/// Writes into the error log without giving console output. Used for the startup banner.
void oLog::outErrorSilent(const char* err, ...)
{
	SetFileLoggingLevel();
	if(m_fileLogLevel == -1)
		return;
	if(m_errorFile == NULL)
		m_errorFile = fopen("error.log","a");
	char buf[32768];
	va_list ap;

	va_start(ap, err);
	vsnprintf(buf, 32768, err, ap);
	va_end(ap);
	outFileSilent(m_errorFile, buf); // This uses a function that won't give console output.
}

void oLog::outBasic(const char* str, ...)
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
		SetFileLoggingLevel( );
	}
	if(m_fileLogLevel == -1)
		return;
	//if(m_normalFile == NULL)
		//m_normalFile = fopen("normal.log","a");

	char buf[32768];
	va_list ap;

	va_start(ap, str);
	vsnprintf(buf, 32768, str, ap);
	va_end(ap);
	PElement m_Mes_Basic;
	m_Mes_Basic = (PElement) new char[sizeof(element)];
	m_Mes_Basic->file = NORMAL_FILE;
	memcpy(m_Mes_Basic->mes,buf,sizeof(buf));
	m_Mes_Basic->out_colour = LINE_COLOUR_WHITE;
	memset(m_Mes_Basic->source,0,1024);
	Append(m_Mes_Basic);
		
	//outFile(m_normalFile, buf);
}

void oLog::outDetail(const char* str, ...)
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 1)
		return;
	//if(m_normalFile == NULL)
		//m_normalFile = fopen("normal.log","a");
	char buf[32768];
	va_list ap;

	va_start(ap, str);
	vsnprintf(buf, 32768, str, ap);
	va_end(ap);
	PElement m_Mes_Detail;
	m_Mes_Detail = (PElement) new char[sizeof(element)];
	m_Mes_Detail->file =NORMAL_FILE;
	memcpy(m_Mes_Detail->mes,buf,sizeof(buf));
	m_Mes_Detail->out_colour = LINE_COLOUR_WHITE;
	memset(m_Mes_Detail->source,0,1024);
	Append(m_Mes_Detail);
	
	//outFile(m_normalFile, buf);
}

void oLog::outDebug(const char* str, ...)///
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 2)
		return;
	//if(m_normalFile == NULL)
		//m_normalFile = fopen("normal.log","a");
	char buf[32768];
	va_list ap;

	va_start(ap, str);
	vsnprintf(buf, 32768, str, ap);
	va_end(ap);
	PElement m_Mes_Debug;
	m_Mes_Debug = (PElement) new char[sizeof(element)];
	m_Mes_Debug->file = NORMAL_FILE;
	memcpy(m_Mes_Debug->mes,buf,sizeof(buf));
	m_Mes_Debug->out_colour = LINE_COLOUR_WHITE;
	memset(m_Mes_Debug->source,0,1024);
	Append(m_Mes_Debug);
	//m_errorFile = fopen("normal.log","a");
	//outFile(m_normalFile, buf);
}

void oLog::logBasic(const char* file, int line, const char* fncname, const char* msg, ...)
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel == -1)
		return;
	//if(m_normalFile == NULL)
		//m_normalFile = fopen("normal.log","a");

	char buf[ 32768 ];
	char message[ 32768 ];

	snprintf(message, 32768, " [BSC] %s:%d %s %s", file, line, fncname, msg);
	va_list ap;

	va_start(ap, msg);
	vsnprintf(buf, 32768, message, ap);
	va_end(ap);
	PElement m_Mes_LogBasic;
	m_Mes_LogBasic = (PElement) new char[sizeof(element)];
	m_Mes_LogBasic->file = NORMAL_FILE;
	memcpy(m_Mes_LogBasic->mes,buf,sizeof(buf));
	m_Mes_LogBasic->out_colour = LINE_COLOUR_WHITE;
	memset(m_Mes_LogBasic->source,0,1024);
	Append(m_Mes_LogBasic);
		
	//outFile(m_normalFile, buf);
}

void oLog::logDetail(const char* file, int line, const char* fncname, const char* msg, ...)
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 1)
		return;
	//if(m_normalFile == NULL)
		//m_normalFile = fopen("normal.log","a");
	char buf[ 32768 ];
	char message[ 32768 ];

	snprintf(message, 32768, " [DTL] %s:%d %s %s", file, line, fncname, msg);
	va_list ap;

	va_start(ap, msg);
	vsnprintf(buf, 32768, message, ap);
	va_end(ap);
	PElement m_Mes_LogDetail;
	m_Mes_LogDetail = (PElement) new char[sizeof(element)];
	m_Mes_LogDetail->file = NORMAL_FILE;
	memcpy(m_Mes_LogDetail->mes,buf,sizeof(buf));
	m_Mes_LogDetail->out_colour = LINE_COLOUR_WHITE;
	memset(m_Mes_LogDetail->source,0,1024);
	Append(m_Mes_LogDetail);
	//outFile(m_normalFile, buf);
}

void oLog::logError(const char* file, int line, const char* fncname, const char* msg, ...)
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel == -1)
		return;
	//if(m_errorFile == NULL)
		//m_errorFile = fopen("error.log","a");
	char buf[ 32768 ];
	char message[ 32768 ];

	snprintf(message, 32768, " [ERR] %s:%d %s %s", file, line, fncname, msg);
	va_list ap;

	va_start(ap, msg);
	vsnprintf(buf, 32768, message, ap);
	va_end(ap);
	PElement m_Mes_logError;
	m_Mes_logError = (PElement) new char[sizeof(element)];
	m_Mes_logError->file = ERROR_FILE;
	memcpy(m_Mes_logError->mes,buf,sizeof(buf));
	m_Mes_logError->out_colour = LINE_COLOUR_RED;
	memset(m_Mes_logError->source,0,1024);
	Append(m_Mes_logError);
	//out_colour = LINE_COLOUR_RED;
	//outFile(m_errorFile, buf);
}

void oLog::logDebug(const char* file, int line, const char* fncname, const char* msg, ...)
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 2)
		return;
	//if(m_normalFile == NULL)
		//m_normalFile = fopen("normal.log","a");
	char buf[ 32768 ];
	char message[ 32768 ];

	snprintf(message, 32768, " [DBG] %s:%d %s %s", file, line, fncname, msg);
	va_list ap;

	va_start(ap, msg);
	vsnprintf(buf, 32768, message, ap);
	va_end(ap);
	PElement m_Mes_logDebug;
	m_Mes_logDebug = (PElement) new char[sizeof(element)];
	m_Mes_logDebug->file = NORMAL_FILE;
	memcpy(m_Mes_logDebug->mes,buf,sizeof(buf));
	m_Mes_logDebug->out_colour = LINE_COLOUR_WHITE;
	memset(m_Mes_logDebug->source,0,1024);
	Append(m_Mes_logDebug);
	//outFile(m_normalFile, buf);
}

//old NGLog.h methods
void oLog::Notice(const char* source, const char* format, ...)
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 1)
		return;
	//if(m_normalFile == NULL)
		//m_normalFile = fopen("normal.log","a");
	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);
	PElement m_Mes_Notice;
	m_Mes_Notice = (PElement) new char[sizeof(element)];
	m_Mes_Notice->file = NORMAL_FILE;
	memcpy(m_Mes_Notice->mes,buf,sizeof(buf));
	m_Mes_Notice->out_colour = LINE_COLOUR_YELLOW;
	memset(m_Mes_Notice->source,0,1024);
	Append(m_Mes_Notice);
	//out_colour = LINE_COLOUR_YELLOW;
	//outFile(m_normalFile, buf, source);
}

void oLog::Warning(const char* source, const char* format, ...)
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 1)
		return;
	//if(m_normalFile == NULL)
		//m_normalFile = fopen("normal.log","a");
	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);
	PElement m_Mes_Warning;
	m_Mes_Warning = (PElement) new char[sizeof(element)];
	m_Mes_Warning->file = NORMAL_FILE;
	memcpy(m_Mes_Warning->mes,buf,sizeof(buf));
	m_Mes_Warning->out_colour = LINE_COLOUR_YELLOW;
	memset(m_Mes_Warning->source,0,1024);
	const char* p = source;
	for(int i = 0;*p != '\0';i++,p++)
	{
		m_Mes_Warning->source[i] = *p;
	}
	Append(m_Mes_Warning);
	//out_colour = LINE_COLOUR_YELLOW;
	//outFile(m_normalFile, buf, source);
}

void oLog::Success(const char* source, const char* format, ...)
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel == -1)
		return;
	//if(m_normalFile == NULL)
		//m_normalFile = fopen("normal.log","a");
	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);
	PElement m_Mes_Success;
	m_Mes_Success = (PElement) new char[sizeof(element)];
	m_Mes_Success->file = NORMAL_FILE;
	memcpy(m_Mes_Success->mes,buf,sizeof(buf));
	m_Mes_Success->out_colour = LINE_COLOUR_WHITE;
	memset(m_Mes_Success->source,0,1024);
	const char* p = source;
	for(int i = 0;*p != '\0';i++,p++)
	{
		m_Mes_Success->source[i] = *p;
	}
	Append(m_Mes_Success);
	//outFile(m_normalFile, buf, source);
}

void oLog::Error(const char* source, const char* format, ...)
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel == -1)
		return;
	//if(m_errorFile == NULL)
		//m_errorFile = fopen("error.log","a");
	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);
	PElement m_Mes_Error;
	m_Mes_Error = (PElement) new char[sizeof(element)];
	m_Mes_Error->file = ERROR_FILE;
	memcpy(m_Mes_Error->mes,buf,sizeof(buf));
	m_Mes_Error->out_colour = LINE_COLOUR_RED;
	memset(m_Mes_Error->source,0,1024);
	const char* p = source;
	for(int i = 0;*p != '\0';i++,p++)
	{
		m_Mes_Error->source[i] = *p;
	}
	Append(m_Mes_Error);
	//out_colour = LINE_COLOUR_RED;
	//outFile(m_errorFile, buf, source);
}

void oLog::Debug(const char* source, const char* format, ...)
{
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 2)
		return;
	//if(m_normalFile == NULL)
		//m_normalFile = fopen("normal.log","a");
	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);
	PElement m_Mes_Debug1;
	m_Mes_Debug1 = (PElement) new char[sizeof(element)];
	m_Mes_Debug1->file = NORMAL_FILE;
	memcpy(m_Mes_Debug1->mes,buf,sizeof(buf));
	m_Mes_Debug1->out_colour = LINE_COLOUR_WHITE;
	memset(m_Mes_Debug1->source,0,1024);
	const char* p = source;
	for(int i = 0;*p != '\0';i++,p++)
	{
		m_Mes_Debug1->source[i] = *p;
	}
	Append(m_Mes_Debug1);
	//outFile(m_normalFile, buf, source);
}

void oLog::LargeErrorMessage(const char* source, ...)                //调用时，最后一个参数应设为NULL
{
	std::vector<char*> lines;
	char* pointer;
	va_list ap;
	va_start(ap, source);

	pointer = const_cast<char*>(source);
	lines.push_back(pointer);

	size_t i, j, k;
	pointer = va_arg(ap, char*);
	while(pointer != NULL)
	{
		lines.push_back(pointer);
		pointer = va_arg(ap, char*);
	}
	outError("*********************************************************************");
	outError("*                        MAJOR ERROR/WARNING                        *");
	outError("*                        ===================                        *");

	for(std::vector<char*>::iterator itr = lines.begin(); itr != lines.end(); ++itr)
	{
		stringstream sstext;
		i = strlen(*itr);
		j = (i <= 65) ? 65 - i : 0;
		sstext << "* " << *itr;
		for(k = 0; k < j; ++k)
		{
			sstext << " ";
		}

		sstext << " *";
		outError(sstext.str().c_str());
	}

	outError("*********************************************************************");
}

void oLog::Init(int32 fileLogLevel)                    
{
	WaitForSingleObject(hMutex_level,INFINITE);
	SetFileLoggingLevel(fileLogLevel);
	ReleaseMutex(hMutex_level);
	const char* logNormalFilename = NULL, *logErrorFilename = NULL;
	//logNormalFilename = "normal.log";
	//logErrorFilename = "error.log";

	//m_normalFile = fopen(logNormalFilename, "a");
	if(m_normalFile == NULL)
		fprintf(stderr, "%s: Error opening '%s': %s\n", __FUNCTION__, logNormalFilename, strerror(errno));
	else
	{
		time_t t = time(NULL);
		tm* aTm = localtime(&t);
		outBasic("[%-4d-%02d-%02d %02d:%02d:%02d] ", aTm->tm_year + 1900, aTm->tm_mon + 1, aTm->tm_mday, aTm->tm_hour, aTm->tm_min, aTm->tm_sec);
	}

	//m_errorFile = fopen(logErrorFilename, "a");
	if(m_errorFile == NULL)
		fprintf(stderr, "%s: Error opening '%s': %s\n", __FUNCTION__, logErrorFilename, strerror(errno));
	else
	{
		time_t t = time(NULL);
		tm* aTm = localtime(&t);
		// We don't echo time and date again because outBasic above just echoed them.
		outErrorSilent("[%-4d-%02d-%02d %02d:%02d:%02d] ", aTm->tm_year + 1900, aTm->tm_mon + 1, aTm->tm_mday, aTm->tm_hour, aTm->tm_min, aTm->tm_sec);
	}
}

void oLog::Close()
{
	if(m_normalFile != NULL)
	{
		fflush(m_normalFile);
		fclose(m_normalFile);
		m_normalFile = NULL;
	}

	if(m_errorFile != NULL)
	{
		fflush(m_errorFile);
		fclose(m_errorFile);
		m_errorFile = NULL;
	}
	if(hMutex_level != NULL)
		CloseHandle(hMutex_level);
	if(hMutex_file != NULL)
		CloseHandle(hMutex_level);
	if(hMutex_queue != NULL)
		CloseHandle(hMutex_queue);
	if(hMutex_write != NULL)
		CloseHandle(hMutex_write);
}

void oLog::SetFileLoggingLevel(int32 level)
{
	//log level -1 is no more allowed
	WaitForSingleObject(hMutex_level,INFINITE);
	if(level >= 0)
		m_fileLogLevel = level;
	ReleaseMutex(hMutex_level);
}
void oLog::SetFileLoggingLevel()
{
	WaitForSingleObject(hMutex_file,INFINITE);
	funcInCon = false;
	if(Config.MainConfig.SetSource("/SyAutoH/bin/Config/log_level.conf",false))
	{
		int32 level;
		if(Config.MainConfig.GetInt("LogLevel","Debug",&level))            //获得配置文件中的filelevel，文件中设置四种级别，NormalAndError = 0,Detail = 1,Debug = 2,Nothing = -1;
		{
			WaitForSingleObject(hMutex_level,INFINITE);
			m_fileLogLevel = level;
			ReleaseMutex(hMutex_level);
		}
		else 
		{
			printf("%s","Get fileLevel failed!");
			WaitForSingleObject(hMutex_level,INFINITE);
			m_fileLogLevel = -1;
			ReleaseMutex(hMutex_level);
		}
	}
	else
	{
		WaitForSingleObject(hMutex_level,INFINITE);
		m_fileLogLevel = -1;
		ReleaseMutex(hMutex_level);
	}
	ReleaseMutex(hMutex_file);
}

void oLog::SetFileLoggingLevel(const char* levelname)
{
	WaitForSingleObject(hMutex_file,INFINITE);
	funcInCon = false;
	if(Config.MainConfig.SetSource("/SyAutoH/bin/Config/log_level.conf",false))
	{
		int32 level;
		if(Config.MainConfig.GetInt("LogLevel",levelname,&level))            //获得配置文件中的filelevel，文件中设置四种级别，NormalAndError = 0,Detail = 1,Debug = 2,Nothing = -1;
		{
			WaitForSingleObject(hMutex_level,INFINITE);
			m_fileLogLevel = level;
			ReleaseMutex(hMutex_level);
		}
		else 
		{
			printf("%s","Get fileLevel failed!");
			WaitForSingleObject(hMutex_level,INFINITE);
			m_fileLogLevel = -1;
			ReleaseMutex(hMutex_level);
		}
	}
	else
	{
		WaitForSingleObject(hMutex_level,INFINITE);
		m_fileLogLevel = -1;
		ReleaseMutex(hMutex_level);
	}
	ReleaseMutex(hMutex_file);
}
void SessionLogWriter::write(const char* format, ...)
{
	if(!m_file)
		return;

	char out[32768];
	va_list ap;

	va_start(ap, format);
	time_t t = time(NULL);
	tm* aTm = localtime(&t);
	sprintf(out, "[%-4d-%02d-%02d %02d:%02d:%02d] ", aTm->tm_year + 1900, aTm->tm_mon + 1, aTm->tm_mday, aTm->tm_hour, aTm->tm_min, aTm->tm_sec);
	size_t l = strlen(out);
	vsnprintf(&out[l], 32768 - l, format, ap);
	fprintf(m_file, "%s\n", out);
	va_end(ap);
}

/*
WorldLog::WorldLog()
{
	bEnabled = false;
	m_file = NULL;

	if(Config.MainConfig.GetBoolDefault("LogLevel", "World", false))
	{
		Log.Notice("WorldLog", "Enabling packetlog output to \"world.log\"");
		Enable();
	}
	else
	{
		Disable();
	}
}

void WorldLog::Enable()
{
	if(bEnabled)
		return;

	bEnabled = true;
	if(m_file != NULL)
	{
		Disable();
		bEnabled = true;
	}
	m_file = fopen("world.log", "a");
}

void WorldLog::Disable()
{
	if(!bEnabled)
		return;

	bEnabled = false;
	if(!m_file)
		return;

	fflush(m_file);
	fclose(m_file);
	m_file = NULL;
}

WorldLog::~WorldLog()
{
	if(m_file)
	{
		fclose(m_file);
		m_file = NULL;
	}
}
*/

void SessionLogWriter::Open()
{
	m_file = fopen(m_filename, "a");            //打开文件
}

void SessionLogWriter::Close()
{
	if(!m_file) return;
	fflush(m_file);
	fclose(m_file);
	m_file = NULL;
}

SessionLogWriter::SessionLogWriter(const char* filename, bool open)
{
	m_filename = strdup(filename);             //复制文件名到m_filename
	m_file = NULL;
	if(open)
		Open();
}

SessionLogWriter::~SessionLogWriter()
{
	if(m_file)
		Close();

	free(m_filename);
}
