#pragma once
#include "Common.h"
#include "Singleton.h"
//#include "Mutex.h"

class WorldPacket;
class WorldSession;

#define TIME_FORMAT "[%m-%d-%Y][%H:%M]"
#define TIME_FORMAT_LENGTH 100
/*
enum LogType
{
    WORLD_LOG,
    LOGON_LOG
};
*/
extern  time_t UNIXTIME;		/* update this every loop to avoid the time() syscall! */
extern  tm g_localTime;
#define LINE_COLOUR_RED 2
#define LINE_COLOUR_YELLOW 1
#define LINE_COLOUR_WHITE 0
#define NORMAL_FILE 5
#define ERROR_FILE 4
#define NOT_GET_LEVEL 3

//std::string FormatOutputString(const char* Prefix, const char* Description, bool useTimeStamp);
std::string SetNewName(const char* Description, bool useTimeStamp);
std::string WstringToString(std::wstring &ws);
LPCWSTR stringToLPCWSTR(std::string orig);
void SetAttribute(std::string filePath);
class oLog : public Singleton< oLog >
{
	struct element
    {
	    int out_colour;
	    char mes[32768];
	    int file;
		char source[1024];
		char timebuffer[100];
    };
   
	public:
		oLog();
		~oLog();
		//log level 0
		void outString(const char* str, ...);
		void outError(const char* err, ...);
		void outErrorSilent(const char* err, ...); // Writes into the error log without giving console output. Used for the startup banner.
		void outBasic(const char* str, ...);
		//log level 1
		void outDetail(const char* str, ...);
		//log level 2
		void outDebug(const char* str, ...);

		void logError(const char* file, int line, const char* fncname, const char* msg, ...);
		void logDebug(const char* file, int line, const char* fncname, const char* msg, ...);
		void logBasic(const char* file, int line, const char* fncname,  const char* msg, ...);
		void logDetail(const char* file, int line, const char* fncname, const char* msg, ...);

		//old NGLog.h methods
		//log level 0
		void Success(const char* source, const char* format, ...);
		void Error(const char* source, const char* format, ...);
		void LargeErrorMessage(const char* str, ...);
		//log level 1
		void Notice(const char* source, const char* format, ...);
		void Warning(const char* source, const char* format, ...);
		//log level 2
		void Debug(const char* source, const char* format, ...);

		void SetLogging(bool enabled);

		void Init(int32 fileLogLevel);
		void SetFileLoggingLevel(int32 level);
		void SetFileLoggingLevel();
		void SetFileLoggingLevel(const char* levelname);
		void Close();
		
		
		int32 out_colour;
		int32 m_fileLogLevel;
		bool funcInCon;
		std::queue <element> Mes;
        HANDLE hMutex_level,hMutex_queue,hMutex_file,hMutex_write,hthread;
		element m_Mes_Write;
		std::string strPath,normal_file_name,error_file_name;


	private:
		FILE* m_normalFile, *m_errorFile;
		void outFile(FILE* file, char* msg,int colour,char* time_buffer,const char* source = NULL);
		void outFileSilent(FILE* file, char* msg, const char* source = NULL); // Prints text to file without showing it to the user. Used for the startup banner.
		void Time(char* buffer);
		void Append(element m_mes);
		bool Remove();
		
		static unsigned __stdcall WriteFile(PVOID pParam);
		std::string GetProcessPath(); 
		std::string GetProcessName();
		void GetElement(int out_colour,char* Mes,int MesLength,int file,const char* Source,char* Timebuffer,int timeLength);
};

class SessionLogWriter
{
		FILE* m_file;
		char* m_filename;
	public:
		SessionLogWriter(const char* filename, bool open);
		~SessionLogWriter();

		void write(const char* format, ...);
		void writefromsession(WorldSession* session, const char* format, ...);
		inline bool IsOpen() { return (m_file != NULL); }
		void Open();
		void Close();
};

#define sLog oLog::getSingleton()

#define LOG_BASIC( msg, ... ) sLog.logBasic( __FILE__, __LINE__, __FUNCTION__, msg, ##__VA_ARGS__ )
#define LOG_DETAIL( msg, ... ) sLog.logDetail( __FILE__, __LINE__, __FUNCTION__, msg, ##__VA_ARGS__ )
#define LOG_ERROR( msg, ... ) sLog.logError( __FILE__, __LINE__, __FUNCTION__, msg, ##__VA_ARGS__ )
#define LOG_DEBUG( msg, ... ) sLog.logDebug( __FILE__, __LINE__, __FUNCTION__, msg, ##__VA_ARGS__ )
 
#define Log sLog
