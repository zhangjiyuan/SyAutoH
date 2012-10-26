#include "ConfigEnv.h"
#include "LOG.h"
#include <cstdarg>

using namespace std;
string FormatOutputString(const char* Prefix, const char* Description, bool useTimeStamp)
{

	char p[MAX_PATH];
	p[0] = 0;
	time_t t = time(NULL);
	tm* a = gmtime(&t);
	strcat(p, Prefix);
	strcat(p, "-");
	strcat(p, Description);
	if(useTimeStamp)
	{
		char ftime[100];
		snprintf(ftime, 100, "-%-4d-%02d-%02d-%02d-%02d-%02d", a->tm_year + 1900, a->tm_mon + 1, a->tm_mday, a->tm_hour, a->tm_min, a->tm_sec);
		strcat(p, ftime);
	}

	strcat(p, ".log");
	return string(p);
}
void CopyLogFile(const char *srcfile,string newfile)       //将达到一定大小的LOG文件内容转移到新的LOG文件保存，以便清楚原来的LOG文件的内容
{
	
	char ch;
	const char *name;
	name = new char[100];
	name = newfile.c_str();
	/*
	FILE *newname;
	newname = fopen(name,"a");
	while((ch=fgetc(srcfile))!=EOF)
    {
     fputc(ch,newname);
	}
	fclose(newname);
	*/
	ifstream file(srcfile);
	ofstream file1(name);
	while(file.get(ch))
	{
		file1<<ch;
	}
	file1.close();
	file.close();
}

createFileSingleton(oLog);
initialiseSingleton(WorldLog);

time_t UNIXTIME;
tm g_localTime;

void oLog::outFile(FILE* file, char* msg, const char* source)
{
	char time_buffer[TIME_FORMAT_LENGTH];
	//char szltr_buffer[SZLTR_LENGTH];
	Time(time_buffer);
	//pdcds(SZLTR, szltr_buffer);
	switch(out_colour)           //由信息类型选择命令行输出字体的颜色，暂定三种：红、黄、绿
	{
	case(1):
		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),FOREGROUND_INTENSITY |FOREGROUND_RED | FOREGROUND_GREEN); //yellow
		break;
	case(2):
		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),FOREGROUND_INTENSITY |FOREGROUND_RED); //red 
		break;
	case(3):
		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),FOREGROUND_INTENSITY |FOREGROUND_GREEN);//green
		break;
	default:
		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),FOREGROUND_INTENSITY |FOREGROUND_RED |
			    FOREGROUND_GREEN | FOREGROUND_BLUE);//white
		break;
	}
	if(file == m_normalFile)
	{
		int32 file_length = filelength(fileno(file));
	    if(file_length >= 5*1024)
	    {
			string filename = FormatOutputString("Longon","normal",true); // 获得新的LOG文件的名字，以类型及时间命名
			CopyLogFile("logon-normal.log",filename);
			file = fopen("logon-normal.log","w");                         //清除LOG文件内容
			fclose(file);
			file = fopen("logon-normal.log","a");
			m_normalFile = file;
	    }
	}
	else if(file == m_errorFile)
	{
		int32 file_length = filelength(fileno(file));
	    if(file_length >= 5*1024)
	    {
			string filename = FormatOutputString("Longon","error",true);
		    CopyLogFile("logon-error.log",filename);
			file = fopen("logon-error.log","w");
			fclose(file);
			file = fopen("logon-error.log","a");
			m_errorFile = file;
	    }
	}
	if(source != NULL)
	{
		fprintf(file, "%s%s: %s\n", time_buffer,source, msg);
		printf("%s%s: %s\n", time_buffer, source, msg);
	}
	else
	{
		fprintf(file, "%s%s\n", time_buffer, msg);
		printf("%s%s\n", time_buffer, msg);
	}
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),FOREGROUND_INTENSITY |FOREGROUND_RED |
			    FOREGROUND_GREEN | FOREGROUND_BLUE);//white
	out_colour = 0;
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
		fprintf(file, "%s%s: %s\n", time_buffer, source, msg);
		// Don't use printf to prevent text from being shown in the console output.
	}
	else
	{
		fprintf(file, "%s%s\n", time_buffer, msg);
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
	if(m_normalFile == NULL)
		return;

	char buf[32768];
	va_list ap;

	va_start(ap, str);
	vsnprintf(buf, 32768, str, ap);
	va_end(ap);

	outFile(m_normalFile, buf);
}

void oLog::outError(const char* err, ...)
{
	if(m_errorFile == NULL)
		return;

	char buf[32768];
	va_list ap;

	va_start(ap, err);
	vsnprintf(buf, 32768, err, ap);
	va_end(ap);
	out_colour = 2;
	outFile(m_errorFile, buf);
}

/// Writes into the error log without giving console output. Used for the startup banner.
void oLog::outErrorSilent(const char* err, ...)
{
	if(m_errorFile == NULL)
		return;

	char buf[32768];
	va_list ap;

	va_start(ap, err);
	vsnprintf(buf, 32768, err, ap);
	va_end(ap);

	outFileSilent(m_errorFile, buf); // This uses a function that won't give console output.
}

void oLog::outBasic(const char* str, ...)
{
	if(m_normalFile == NULL)
		return;

	char buf[32768];
	va_list ap;

	va_start(ap, str);
	vsnprintf(buf, 32768, str, ap);
	va_end(ap);

	outFile(m_normalFile, buf);
}

void oLog::outDetail(const char* str, ...)
{
	if(m_fileLogLevel < 1 || m_normalFile == NULL)
		return;

	char buf[32768];
	va_list ap;

	va_start(ap, str);
	vsnprintf(buf, 32768, str, ap);
	va_end(ap);

	outFile(m_normalFile, buf);
}

void oLog::outDebug(const char* str, ...)///
{
	if(m_fileLogLevel < 2 || m_errorFile == NULL)
		return;
	char buf[32768];
	va_list ap;

	va_start(ap, str);
	vsnprintf(buf, 32768, str, ap);
	va_end(ap);
	out_colour = 2;
	outFile(m_errorFile, buf);
}

void oLog::logBasic(const char* file, int line, const char* fncname, const char* msg, ...)
{
	if(m_normalFile == NULL)
		return;

	char buf[ 32768 ];
	char message[ 32768 ];

	snprintf(message, 32768, " [BSC] %s:%d %s %s", file, line, fncname, msg);
	va_list ap;

	va_start(ap, msg);
	vsnprintf(buf, 32768, message, ap);
	va_end(ap);

	outFile(m_normalFile, buf);
}

void oLog::logDetail(const char* file, int line, const char* fncname, const char* msg, ...)
{
	if((m_fileLogLevel < 1) || (m_normalFile == NULL))
		return;

	char buf[ 32768 ];
	char message[ 32768 ];

	snprintf(message, 32768, " [DTL] %s:%d %s %s", file, line, fncname, msg);
	va_list ap;

	va_start(ap, msg);
	vsnprintf(buf, 32768, message, ap);
	va_end(ap);

	outFile(m_normalFile, buf);
}

void oLog::logError(const char* file, int line, const char* fncname, const char* msg, ...)
{
	if(m_errorFile == NULL)
		return;

	char buf[ 32768 ];
	char message[ 32768 ];

	snprintf(message, 32768, " [ERR] %s:%d %s %s", file, line, fncname, msg);
	va_list ap;

	va_start(ap, msg);
	vsnprintf(buf, 32768, message, ap);
	va_end(ap);
	out_colour = 2;
	outFile(m_errorFile, buf);
}

void oLog::logDebug(const char* file, int line, const char* fncname, const char* msg, ...)
{
	if((m_fileLogLevel < 2) || (m_errorFile == NULL))
		return;

	char buf[ 32768 ];
	char message[ 32768 ];

	snprintf(message, 32768, " [DBG] %s:%d %s %s", file, line, fncname, msg);
	va_list ap;

	va_start(ap, msg);
	vsnprintf(buf, 32768, message, ap);
	va_end(ap);
	out_colour = 2;
	outFile(m_errorFile, buf);
}

//old NGLog.h methods
void oLog::Notice(const char* source, const char* format, ...)
{
	if(m_fileLogLevel < 1 || m_normalFile == NULL)
		return;

	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);
	out_colour = 1;
	outFile(m_normalFile, buf, source);
}

void oLog::Warning(const char* source, const char* format, ...)
{
	if(m_fileLogLevel < 1 || m_normalFile == NULL)
		return;

	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);
	out_colour = 1;
	outFile(m_normalFile, buf, source);
}

void oLog::Success(const char* source, const char* format, ...)
{
	if(m_normalFile == NULL)
		return;

	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);

	outFile(m_normalFile, buf, source);
}

void oLog::Error(const char* source, const char* format, ...)
{
	if(m_errorFile == NULL)
		return;

	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);
	out_colour = 2;
	outFile(m_errorFile, buf, source);
}

void oLog::Debug(const char* source, const char* format, ...)
{
	if(m_fileLogLevel < 2 || m_errorFile == NULL)
		return;

	char buf[32768];
	va_list ap;

	va_start(ap, format);
	vsnprintf(buf, 32768, format, ap);
	va_end(ap);
	out_colour = 2;
	outFile(m_errorFile, buf, source);
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
	out_colour = 2;
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

void oLog::Init(int32 fileLogLevel, LogType logType)                    
{
	SetFileLoggingLevel(fileLogLevel);

	const char* logNormalFilename = NULL, *logErrorFilename = NULL;
	switch(logType)
	{
		case LOGON_LOG:
			{
				logNormalFilename = "logon-normal.log";
				logErrorFilename = "logon-error.log";
				break;
			}
		case WORLD_LOG:
			{
				logNormalFilename = "world-normal.log";
				logErrorFilename = "world-error.log";
				break;
			}
	}

	m_normalFile = fopen(logNormalFilename, "a");
	if(m_normalFile == NULL)
		fprintf(stderr, "%s: Error opening '%s': %s\n", __FUNCTION__, logNormalFilename, strerror(errno));
	else
	{
		tm* aTm = localtime(&UNIXTIME);
		outBasic("[%-4d-%02d-%02d %02d:%02d:%02d] ", aTm->tm_year + 1900, aTm->tm_mon + 1, aTm->tm_mday, aTm->tm_hour, aTm->tm_min, aTm->tm_sec);
	}

	m_errorFile = fopen(logErrorFilename, "a");
	if(m_errorFile == NULL)
		fprintf(stderr, "%s: Error opening '%s': %s\n", __FUNCTION__, logErrorFilename, strerror(errno));
	else
	{
		tm* aTm = localtime(&UNIXTIME);
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
}

void oLog::SetFileLoggingLevel(int32 level)
{
	//log level -1 is no more allowed
	if(level >= 0)
		m_fileLogLevel = level;
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