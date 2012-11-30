#pragma once
                                                              
const wchar_t DbConnectString[] = L"Provider=SQLNCLI11.1;Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=MCS;Data Source=.\\AMHS;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=(local);Initial File Name=\"\";Use Encryption for Data=False;Tag with column collation when possible=False;MARS Connection=False;DataTypeCompatibility=0;Trust Server Certificate=False;Application Intent=READWRITE";
// define const value for db operation
const int DBO_SUCCESS = 0;
const int DBO_LOGIN_FAILED = -1;
const int DBO_FAILED = -1;
const int DBO_NORIGHT = -5;