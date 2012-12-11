#pragma once

typedef signed __int64 int64;
typedef signed __int32 int32;
typedef signed __int16 int16;
typedef signed __int8 int8;

typedef unsigned __int64 uint64;
typedef unsigned __int32 uint32;
typedef unsigned __int16 uint16;
typedef unsigned __int8 uint8;

#include <string>
#include <vector>
#include <assert.h>
#include <list>
#include <map>
#include <set>

using namespace std;

#	define LIKELY( _x ) \
	_x
#	define UNLIKELY( _x ) \
	_x

#ifdef WIN32
#pragma warning(disable:4996)
#pragma warning(disable:4251)		// dll-interface bullshit
#endif
#define snprintf _snprintf

#include <cstdlib>
#include <cstdio>
#include <ctime>
#include <cerrno>
#include <queue>
#include <sstream>
#include <cstring>
#include <io.h>
#include <process.h>
