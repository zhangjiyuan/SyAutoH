#include<iostream>
#include "string.h"
using namespace std;
#ifdef MYLIBAPI

#else
#define MYLIBAPI extern "C" _declspec(dllimport)
#endif

MYLIBAPI string SHA1Transform(string instr);
MYLIBAPI string HashLoginInfo(string& sName, string& sHighMark, string& sLowMark, string& sPassword);