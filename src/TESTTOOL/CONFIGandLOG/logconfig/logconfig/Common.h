#pragma once
/* Define these if you are creating a repack */

#ifdef WIN32
#pragma warning(disable:4996)
#pragma warning(disable:4251)		// dll-interface bullshit
#endif
#define snprintf _snprintf

#include <cstdlib>
#include <cstdio>
#include <ctime>
#include <cerrno>
#include <map>
#include <queue>
#include <sstream>
#include <cstring>

#if defined( __WIN32__ ) || defined( WIN32 ) || defined( _WIN32 )
//#include <winsock2.h>
#include <ws2tcpip.h>
#endif


typedef signed __int64 int64;
typedef signed __int32 int32;
typedef signed __int16 int16;
typedef signed __int8 int8;

typedef unsigned __int64 uint64;
typedef unsigned __int32 uint32;
typedef unsigned __int16 uint16;
typedef unsigned __int8 uint8;



