#pragma once
#include "Common.h"
#include "Singleton.h"
//#include "Mutex.h"

class Session;

#define TIME_FORMAT "[%m-%d-%Y %H:%M:%S]"
#define TIME_FORMAT_LENGTH 100
#define LINE_COLOUR_RED 2;
#define LINE_COLOUR_YELLOW 1;
#define LINE_COLOUR_WHITE 0;
#define NORMAL_FILE 4
#define ERROR_FILE 5
#define NOT_GET_LEVEL 3
//#define FROM_INIT false;
//#define FROM_CONFIG true;

extern  time_t UNIXTIME;		/* update this every loop to avoid the time() syscall! */
extern  tm g_localTime;
//bool fileLevel = FROM_CONFIG;
std::string FormatOutputString(const char* Prefix, const char* Description, bool useTimeStamp);
string SetNewName(const char* Description, bool useTimeStamp);
class oLog : public Singleton< oLog >
{
	struct element
    {
	    int out_colour;
	    char mes[32768];
	    int file;
		char source[1024];
    };
    typedef element* PElement;
	public:
		oLog();
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
		void SetFileLoggingLevel( );
		void SetFileLoggingLevel(const char* levelname);
		void Close();
		void Append(PElement m_mes);
		bool Remove();
		static unsigned __stdcall WriteFile(PVOID pParam);

		int32 out_colour;
		int32 m_fileLogLevel;
		bool funcInCon;
		std::queue <PElement> Mes;
        HANDLE hMutex_level,hMutex_queue,hMutex_file,hMutex_write;
		PElement m_Mes_Write;

	private:
		FILE* m_normalFile, *m_errorFile;
		void outFile(FILE* file, char* msg, int colour,const char* source = NULL);
		void outFileSilent(FILE* file, char* msg, const char* source = NULL); // Prints text to file without showing it to the user. Used for the startup banner.
		void Time(char* buffer);
		/*
		inline char dcd(char in)
		{
			char out = in;
			out -= 13;
			out ^= 131;
			return out;
		}

		void dcds(char* str)
		{
			unsigned long i = 0;
			size_t len = strlen(str);

			for(i = 0; i < len; ++i)
				str[i] = dcd(str[i]);
		}

		void pdcds(const char* str, char* buf)
		{
			strcpy(buf, str);
			dcds(buf);
		}
		*/
};

class SessionLogWriter
{
		FILE* m_file;
		char* m_filename;
	public:
		SessionLogWriter(const char* filename, bool open);
		~SessionLogWriter();

		void write(const char* format, ...);
		void writefromsession(Session* session, const char* format, ...);
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

/*
class WorldLog : public Singleton<WorldLog>
{
	public:
		WorldLog();
		~WorldLog();

		void LogPacket(uint32 len, uint16 opcode, const uint8* data, uint8 direction, uint32 accountid = 0);
		void Enable();
		void Disable();
	private:
		FILE* m_file;
		//Mutex mutex;
		bool bEnabled;
};

#define sWorldLog WorldLog::getSingleton()
*/
