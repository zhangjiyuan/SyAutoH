#include "stdafx.h"
#include "Config.h"
#include "LOG.h"
//#include <cstdarg>
using namespace std;
/*
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
*/
string WstringToString(wstring &ws)
{
    string curLocale = setlocale(LC_ALL, NULL); // curLocale = "C";
    setlocale(LC_ALL, "chs");
    const wchar_t* _Source = ws.c_str();
    size_t _Dsize = 2 * ws.size() + 1;
    char *_Dest = new char[_Dsize];
    memset(_Dest,0,_Dsize);
    wcstombs(_Dest,_Source,_Dsize);
    string result = _Dest;
    delete []_Dest;
    setlocale(LC_ALL, curLocale.c_str());
    return result;
}
LPCWSTR stringToLPCWSTR(std::string orig)
{
	size_t origsize = orig.length() + 1;
    const size_t newsize = 100;
    size_t convertedChars = 0;
    wchar_t *wcstring = (wchar_t *)malloc(sizeof(wchar_t)*(orig.length()-1));
    mbstowcs_s(&convertedChars, wcstring, origsize, orig.c_str(), _TRUNCATE);
    return wcstring;
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
		snprintf(ftime, 100, "-%-4d-%02d-%02d-%02d%02d%02d", a->tm_year + 1900, 
			            a->tm_mon + 1, a->tm_mday, a->tm_hour + 8, a->tm_min, a->tm_sec);
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
	 hMutex_queue = CreateMutex(NULL,TRUE,NULL);
	 hMutex_file = CreateMutex(NULL,TRUE,NULL);
	 hMutex_logfile = CreateMutex(NULL,FALSE,NULL);

	 string procName = GetProcessName();
	 string procPath = GetProcessPath();
	 strPath = procPath + "../Log/" + procName;
	 LPCWSTR file_create = stringToLPCWSTR(strPath);
	 CreateDirectory(file_create,NULL);
	 normal_file_name = strPath + "/normal.log";
	 error_file_name = strPath + "/error.log";
	 /*
	 m_normalFile = fopen(normal_file_name.c_str(),"a");
	 if(m_normalFile == NULL)
	 {
		 printf("error opening %s",normal_file_name.c_str());
	 }
	 m_errorFile = fopen(error_file_name.c_str(),"a");
	 if(m_errorFile == NULL)
	 {
		 printf("error opening %s",error_file_name.c_str());
	 }
	 */
	 hthread = (HANDLE)_beginthreadex(NULL,0,WriteFile,this,0,0);
	 m_fileLogLevel = NOT_GET_LEVEL;
 }
oLog::~oLog()
{
	Close();
}
void oLog::GetElement(int out_colour,char* Mes,int MesLength,
	                    int file,const char* Source,char* Timebuffer,int timeLength)
{
	element m_Mes;
	m_Mes.file = file;
	memset(m_Mes.mes,0,sizeof(m_Mes.mes));
	memcpy(m_Mes.mes,Mes,MesLength);
	m_Mes.out_colour = out_colour;
	memset(m_Mes.source,0,1024);
	if(Source != NULL)
	{
	    const char* p = Source;
	    for(int i = 0;*p != '\0';i++,p++)
	    {
		    m_Mes.source[i] = *p;
	    }
	}
	memset(m_Mes.timebuffer,0,100);
	memcpy(m_Mes.timebuffer,Timebuffer,timeLength);//size problem
	Append(m_Mes);
}
void oLog::Append(element m_mes)
 {
	 WaitForSingleObject(hMutex_queue,INFINITE);
	 Mes.push(m_mes);
	 if(ReleaseMutex(hMutex_queue) != 0)
		 ReleaseMutex(hMutex_queue);
 }
bool oLog::Remove()
{
	WaitForSingleObject(hMutex_queue,INFINITE);
	if(Mes.size() != 0)
	{
		m_Mes_Write = Mes.front();
	    Mes.pop();
		if(ReleaseMutex(hMutex_queue) != 0)
			ReleaseMutex(hMutex_queue);
		return true;
	}
	else
	{
		if(ReleaseMutex(hMutex_queue) != 0)
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
		    WaitForSingleObject(This->hMutex_logfile,INFINITE);
			//printf("%s","reached here too");
			if(This->m_normalFile == NULL)
		    {
			    This->m_normalFile = fopen(This->normal_file_name.c_str(),"a");
			    if(This->m_normalFile == NULL)
			    {
				    printf("ERROR OPENING %s",This->normal_file_name.c_str());
			    }
		    }
		    if(This->m_errorFile == NULL)
		    {
			    This->m_errorFile = fopen(This->error_file_name.c_str(),"a");
			    if(This->m_errorFile == NULL)
			    {
				    printf("ERROR OPENING %s",This->error_file_name.c_str());
			    }
		    }
			if(This->m_Mes_Write.file == NORMAL_FILE)
				file = This->m_normalFile;
			else if(This->m_Mes_Write.file == ERROR_FILE)
				file = This->m_errorFile;
			char *source = This->m_Mes_Write.source;
			if(source != NULL)
			{
				This->outFile(file,This->m_Mes_Write.mes,This->m_Mes_Write.out_colour,
					                    This->m_Mes_Write.timebuffer,This->m_Mes_Write.source);
			}
			else
			{
				This->outFile(file,This->m_Mes_Write.mes,This->m_Mes_Write.out_colour,This->m_Mes_Write.timebuffer);
			}
			DWORD num = ReleaseMutex(This->hMutex_logfile);
		    if(num != 0)
			    ReleaseMutex(This->hMutex_logfile);
		}
		else
			Sleep(1);
	}
}
void oLog::outFile(FILE* file, char* msg,int colour,char* time_buffer,const char* source)
{
	switch(colour)           //由信息类型选择命令行输出字体的颜色，暂定三种：红、黄、白
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
			string filename = SetNewName("normal",true);// 获得新的LOG文件的名字，以类型及时间命名
			filename = strPath + "/" + filename;
			fflush(m_normalFile);
			fclose(file);
			rename(normal_file_name.c_str(),filename.c_str());
			if(rename != 0)
			{
				perror("Save the Log file");
			}
			file = fopen(normal_file_name.c_str(),"a");
			m_normalFile = file;
	    }
	}
	else if(file == m_errorFile)
	{
		int32 file_length = filelength(fileno(file));
	    if(file_length >= 1*1000)
	    {
			string filename = SetNewName("error",true); // 获得新的LOG文件的名字，以类型及时间命名
			filename = strPath + "/" + filename;
			fflush(m_errorFile);
			fclose(file);
			rename(error_file_name.c_str(),filename.c_str());
			if(rename != 0)
			{
				perror("Save the Log file");
			}
			file = fopen(error_file_name.c_str(),"a");
			m_errorFile = file;
	    }
	}
	if(source != NULL)
	{
		printf("%s : %s: %s\n", time_buffer, source, msg);
		if (file != NULL)
		{
			fprintf(file, "%s : %s: %s\n", time_buffer, source, msg);	
		}
	}
	else
	{
		printf("%s :%s\n", time_buffer, msg);
		if (file != NULL)
		{
			fprintf(file, "%s :%s\n", time_buffer, msg);
		}
	}
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),FOREGROUND_INTENSITY |FOREGROUND_RED |
			    FOREGROUND_GREEN | FOREGROUND_BLUE);//white
}

/// Prints text to file without showing it to the user. Used for the startup banner.
void oLog::outFileSilent(FILE* file, char* msg, const char* source)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	int32 file_length = filelength(fileno(file));
	if(file_length >= 900*1000)
	{
		string filename = SetNewName("error",true); // 获得新的LOG文件的名字，以类型及时间命名
		filename = strPath + "/" + filename;
		fflush(m_errorFile);
		fclose(m_errorFile);
		rename(error_file_name.c_str(),filename.c_str());
		if(rename != 0)
		{
			perror("Save the Log file");
		}
		m_errorFile = fopen(error_file_name.c_str(),"a");
	}
	if(source != NULL)
	{
		fprintf(file, "%s %s : %s\n", time_buffer, source, msg);
		// Don't use printf to prevent text from being shown in the console output.
	}
	else
	{
		fprintf(file, "%s : %s\n", time_buffer, msg);
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
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
		SetFileLoggingLevel();
	}
	if(m_fileLogLevel == -1)
		return;
	
	char buf[32768];
	va_list ap;

	va_start(ap, str);
	vsnprintf(buf, 32768, str, ap);
	va_end(ap);
	GetElement(LINE_COLOUR_WHITE,buf,sizeof(buf),
		          NORMAL_FILE,NULL,time_buffer,sizeof(time_buffer));
	//outFile(m_normalFile, buf);
}

void oLog::outError(const char* err, ...)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
    if(funcInCon == false)
	{
		if(m_fileLogLevel == NOT_GET_LEVEL)
		{
		    SetFileLoggingLevel();
		}
	    if(m_fileLogLevel == -1)
			return;
	}
	char buf[32768];
	va_list ap;
	va_start(ap, err);
	vsnprintf(buf, 32768, err, ap);
	va_end(ap);
	GetElement(LINE_COLOUR_RED,buf,sizeof(buf),
		           ERROR_FILE,NULL,time_buffer,sizeof(time_buffer));
}

/// Writes into the error log without giving console output. Used for the startup banner.
void oLog::outErrorSilent(const char* err, ...)
{
	SetFileLoggingLevel();
	if(m_fileLogLevel == -1)
		return;
	if(m_errorFile == NULL)
		m_errorFile = fopen(error_file_name.c_str(),"a");
	char buf[32768];
	va_list ap;

	va_start(ap, err);
	vsnprintf(buf, 32768, err, ap);
	va_end(ap);
	outFileSilent(m_errorFile, buf); // This uses a function that won't give console output.
}

void oLog::outBasic(const char* str, ...)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
		SetFileLoggingLevel( );
	}
	if(m_fileLogLevel == -1)
		return;
	char buf[32768];
	va_list ap;

	va_start(ap, str);
	vsnprintf(buf, 32768, str, ap);
	va_end(ap);
	GetElement(LINE_COLOUR_WHITE,buf,sizeof(buf),
		           NORMAL_FILE,NULL,time_buffer,sizeof(time_buffer));
		
	//outFile(m_normalFile, buf);
}

void oLog::outDetail(const char* str, ...)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 1)
		return;
	char buf[32768];
	va_list ap;

	va_start(ap, str);
	vsnprintf(buf, 32768, str, ap);
	va_end(ap);
	GetElement(LINE_COLOUR_WHITE,buf,sizeof(buf),
		           NORMAL_FILE,NULL,time_buffer,sizeof(time_buffer));
	//outFile(m_normalFile, buf);
}

void oLog::outDebug(const char* str, ...)///
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 2)
		return;
	
	char buf[32768];
	va_list ap;
	va_start(ap, str);
	vsnprintf(buf, 32768, str, ap);
	va_end(ap);
	GetElement(LINE_COLOUR_WHITE,buf,sizeof(buf),
		           NORMAL_FILE,NULL,time_buffer,sizeof(time_buffer));
	//outFile(m_normalFile, buf);
}

void oLog::logBasic(const char* file, int line, const char* fncname, const char* msg, ...)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel == -1)
		return;

	char buf[ 32768 ];
	char message[ 32768 ];
	snprintf(message, 32768, " [BSC] %s:%d %s %s", file, line, fncname, msg);
	va_list ap;
	va_start(ap, msg);
	vsnprintf(buf, 32768, message, ap);
	va_end(ap);
	GetElement(LINE_COLOUR_WHITE,buf,sizeof(buf),
		           NORMAL_FILE,NULL,time_buffer,sizeof(time_buffer));
	//outFile(m_normalFile, buf);
}

void oLog::logDetail(const char* file, int line, const char* fncname, const char* msg, ...)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 1)
		return;
	char buf[ 32768 ];
	char message[ 32768 ];

	snprintf(message, 32768, " [DTL] %s:%d %s %s", file, line, fncname, msg);
	va_list ap;
	va_start(ap, msg);
	vsnprintf(buf, 32768, message, ap);
	va_end(ap);

	GetElement(LINE_COLOUR_WHITE,buf,sizeof(buf),
		           NORMAL_FILE,NULL,time_buffer,sizeof(time_buffer));
	//outFile(m_normalFile, buf);
}

void oLog::logError(const char* file, int line, const char* fncname, const char* msg, ...)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel == -1)
		return;
	char buf[ 32768 ];
	char message[ 32768 ];

	snprintf(message, 32768, " [ERR] %s:%d %s %s", file, line, fncname, msg);
	va_list ap;
	va_start(ap, msg);
	vsnprintf(buf, 32768, message, ap);
	va_end(ap);
	GetElement(LINE_COLOUR_RED,buf,sizeof(buf),
		           ERROR_FILE,NULL,time_buffer,sizeof(time_buffer));
	//outFile(m_errorFile, buf);
}

void oLog::logDebug(const char* file, int line, const char* fncname, const char* msg, ...)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 2)
		return;
	char buf[ 32768 ];
	char message[ 32768 ];
	snprintf(message, 32768, " [DBG] %s:%d %s %s", file, line, fncname, msg);
	va_list ap;
	va_start(ap, msg);
	vsnprintf(buf, 32768, message, ap);
	va_end(ap);
	GetElement(LINE_COLOUR_WHITE,buf,sizeof(buf),
		           NORMAL_FILE,NULL,time_buffer,sizeof(time_buffer));
	//outFile(m_normalFile, buf);
}

//old NGLog.h methods
void oLog::Notice(const char* source, const char* format, ...)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 1)
		return;
	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);
	GetElement(LINE_COLOUR_YELLOW,buf,sizeof(buf),
		           NORMAL_FILE,source,time_buffer,sizeof(time_buffer));
	//outFile(m_normalFile, buf, source);
}

void oLog::Warning(const char* source, const char* format, ...)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel < 1)
		return;
	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);
	GetElement(LINE_COLOUR_YELLOW,buf,sizeof(buf),
		           NORMAL_FILE,source,time_buffer,sizeof(time_buffer));
}

void oLog::Success(const char* source, const char* format, ...)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
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
	GetElement(LINE_COLOUR_WHITE,buf,sizeof(buf),
		           NORMAL_FILE,source,time_buffer,sizeof(time_buffer));
}

void oLog::Error(const char* source, const char* format, ...)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
	if(m_fileLogLevel == NOT_GET_LEVEL)
	{
	    SetFileLoggingLevel( );
	}
	if(m_fileLogLevel == -1)
		return;
	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);
	GetElement(LINE_COLOUR_RED,buf,sizeof(buf),
		           ERROR_FILE,source,time_buffer,sizeof(time_buffer));
}

void oLog::Debug(const char* source, const char* format, ...)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	Time(time_buffer);
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
	GetElement(LINE_COLOUR_WHITE,buf,sizeof(buf),
		           NORMAL_FILE,source,time_buffer,sizeof(time_buffer));
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
	if(ReleaseMutex(hMutex_level) != 0)
		ReleaseMutex(hMutex_level);
	const char* logNormalFilename = NULL, *logErrorFilename = NULL;
	logNormalFilename = normal_file_name.c_str();
	logErrorFilename = error_file_name.c_str();

	WaitForSingleObject(hMutex_logfile,INFINITE);
	if(m_normalFile == NULL)
	{
	    m_normalFile = fopen(logNormalFilename,"a");
	}
	if(m_errorFile == NULL)
	{
	    m_errorFile = fopen(logErrorFilename,"a");
	}
	if(m_normalFile == NULL)
		fprintf(stderr, "%s: Error opening '%s': %s\n", __FUNCTION__, logNormalFilename, strerror(errno));
	else
	{
		time_t t = time(NULL);
		tm* aTm = localtime(&t);
		outBasic("[%-4d-%02d-%02d %02d:%02d:%02d]", aTm->tm_year + 1900, aTm->tm_mon + 1, aTm->tm_mday, aTm->tm_hour, aTm->tm_min, aTm->tm_sec);
	}
	if(m_errorFile == NULL)
		fprintf(stderr, "%s: Error opening '%s': %s\n", __FUNCTION__, logErrorFilename, strerror(errno));
	else
	{
		time_t t = time(NULL);
		tm* aTm = localtime(&t);
		// We don't echo time and date again because outBasic above just echoed them.
		outErrorSilent("[%-4d-%02d-%02d %02d:%02d:%02d]", aTm->tm_year + 1900, aTm->tm_mon + 1, aTm->tm_mday, aTm->tm_hour, aTm->tm_min, aTm->tm_sec);
	}
	
	//fflush(m_normalFile);
	fclose(m_normalFile);
	m_normalFile = NULL;
	//fflush(m_errorFile);
	fclose(m_errorFile);
	m_errorFile = NULL;
	if(ReleaseMutex(hMutex_logfile) != 0)
		ReleaseMutex(hMutex_logfile);
}

void oLog::Close()
{
	if(hMutex_queue != NULL)
	    CloseHandle(hMutex_queue);
	if(hthread != NULL)
		CloseHandle(hthread);
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
		CloseHandle(hMutex_file);
}
string oLog::GetProcessPath()
{
	TCHAR path[200];
	GetModuleFileName(NULL,path,200);
	std::wstring wstr = path;
	string strpath = WstringToString(wstr);
	size_t nBar = strpath.find_last_of('\\') + 1;
	strpath = strpath.substr(0, nBar);
	return strpath;
}
string oLog::GetProcessName()
{
	TCHAR buf[256] = {0};
	GetModuleFileName(NULL, buf, 256);
	std::wstring wstr;
	wstr = buf;
	std::string str = "";
	str = WstringToString(wstr);
	size_t nBar = str.find_last_of('\\') + 1;
	str = str.substr(nBar, str.length() - nBar);
	size_t nCm = str.find_last_of('.');
	str = str.substr(0, nCm);
	return str;
}

void oLog::SetFileLoggingLevel(int32 level)
{
	WaitForSingleObject(hMutex_level,INFINITE);
	if(level >= -1)
		m_fileLogLevel = level;
	if(ReleaseMutex(hMutex_level) != 0)
		ReleaseMutex(hMutex_level);
}

void oLog::SetFileLoggingLevel()
{
	WaitForSingleObject(hMutex_file,INFINITE);
	funcInCon = false;
	string strpath = GetProcessPath();
	strpath = strpath + "../config/log_level.conf";
	WaitForSingleObject(hMutex_level,INFINITE);
	if(Config.MainConfig.SetSource(strpath.c_str(),false))
	{
		int32 level;
		if(Config.MainConfig.GetInt("LogLevel","Debug",&level))            //获得配置文件中的filelevel，文件中设置四种级别，NormalAndError = 0,Detail = 1,Debug = 2,Nothing = -1;
		{
			WaitForSingleObject(hMutex_level,INFINITE);
			m_fileLogLevel = level;
		}
		else 
		{
			printf("%s","Get fileLevel failed!");
			m_fileLogLevel = -1;
		}
	}
	else
	{
		m_fileLogLevel = -1;
	}
	if(ReleaseMutex(hMutex_level) != 0)
		ReleaseMutex(hMutex_level);
    if(ReleaseMutex(hMutex_file) != 0)
		ReleaseMutex(hMutex_file);
}
/*
void oLog::SetFileLoggingLevel(const char* levelname)
{
	WaitForSingleObject(hMutex_file,INFINITE);
	funcInCon = false;
	if(Config.MainConfig.SetSource("log_level.conf",false))
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
*/
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
