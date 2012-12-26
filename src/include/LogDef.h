#pragma once

//////////////////////////////////////////////////////////////////////////
// LogType Define
namespace LogType
{
	enum enumType
	{
		Info = 1,
		Warrning,
		Error,
		Debug
	};
}

//////////////////////////////////////////////////////////////////////////
// LogID Define

//////////////////////////////////////////////////////////////////////////
// System Log ID
const char SYS_MODULE[] = "SYS";
const int LID_SYS_BASE = 10;
const int LID_SYS_DEBUG_INFO = LID_SYS_BASE + 1;
const int LID_SYS_ERR = LID_SYS_BASE + 2;
const int LID_SYS_DiskLow = LID_SYS_BASE + 3;
//////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////
// CTC Log ID
const char CTC_MODULE[] = "CTC";
const int LID_CTC_BASE = 1000;
const int LID_CTC_1001 = LID_CTC_BASE + 1;
const int LID_CTC_1002 = LID_CTC_BASE + 2;
const int LID_CTC_1003 = LID_CTC_BASE + 3;
const int LID_CTC_1004 = LID_CTC_BASE + 4;
const int LID_CTC_1005 = LID_CTC_BASE + 5;
const int LID_CTC_1006 = LID_CTC_BASE + 6;
const int LID_CTC_1007 = LID_CTC_BASE + 7;
const int LID_CTC_1008 = LID_CTC_BASE + 8;
const int LID_CTC_1009 = LID_CTC_BASE + 9;
const int LID_CTC_1010 = LID_CTC_BASE + 10;
const int LID_CTC_1011 = LID_CTC_BASE + 11;
const int LID_CTC_1012 = LID_CTC_BASE + 12;
const int LID_CTC_1013 = LID_CTC_BASE + 13;
const int LID_CTC_1014 = LID_CTC_BASE + 14;
const int LID_CTC_1015 = LID_CTC_BASE + 15;
const int LID_CTC_1016 = LID_CTC_BASE + 16;
const int LID_CTC_1017 = LID_CTC_BASE + 17;
const int LID_CTC_1018 = LID_CTC_BASE + 18;
const int LID_CTC_1019 = LID_CTC_BASE + 19;
const int LID_CTC_1020 = LID_CTC_BASE + 20;
const int LID_CTC_1021 = LID_CTC_BASE + 21;
const int LID_CTC_1022 = LID_CTC_BASE + 22;
const int LID_CTC_1023 = LID_CTC_BASE + 23;
const int LID_CTC_1024 = LID_CTC_BASE + 24;
const int LID_CTC_1025 = LID_CTC_BASE + 25;
const int LID_CTC_1026 = LID_CTC_BASE + 26;
const int LID_CTC_1027 = LID_CTC_BASE + 27;
const int LID_CTC_1028 = LID_CTC_BASE + 28;
const int LID_CTC_1029 = LID_CTC_BASE + 29;
//////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////
// PMC Log ID
const char PMC_MODULE[] = "PMC";
const int LID_PMC_BASE = 2000;
//////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////
// EFEM Log ID
const char EFEM_MODULE[] = "EFEM";
const int LID_EFEM_BASE						= 3000;
const int LID_EFEM_INFORMATION				= LID_EFEM_BASE + 1;
const int LID_EFEM_STARTUP_SERVICE_FAIL		= LID_EFEM_BASE + 2;
const int LID_EFEM_EFEM_MANAGER_INIT_FAIL	= LID_EFEM_BASE + 3;
const int LID_EFEM_EFEM_TASK_INIT_FAIL		= LID_EFEM_BASE + 4;
const int LID_EFEM_IO_TASK_INIT_FAIL		= LID_EFEM_BASE + 5;
const int LID_EFEM_CONVERT_NAME				= LID_EFEM_BASE + 6;
const int LID_EFEM_REVERSE_NAME				= LID_EFEM_BASE + 7;
const int LID_EFEM_CONNECT_FAIL				= LID_EFEM_BASE + 8;
const int LID_EFEM_SEND_DATA_FAIL			= LID_EFEM_BASE + 9;
const int LID_EFEM_RECV_DATA_FAIL			= LID_EFEM_BASE + 10;
const int LID_EFEM_INVALID_MSG				= LID_EFEM_BASE + 11;
const int LID_EFEM_CMD_EXCUTE_FAIL			= LID_EFEM_BASE + 12;
const int LID_EFEM_FFU_ALARM				= LID_EFEM_BASE + 13;
const int LID_EFEM_SUB_STRING_FAIL			= LID_EFEM_BASE + 14;
const int LID_EFEM_READ_CONFIG_FAIL			= LID_EFEM_BASE + 15;
const int LID_EFEM_WRITE_DATA_FAIL			= LID_EFEM_BASE + 16;
const int LID_EFEM_GET_WAFER_INFO_FAIL		= LID_EFEM_BASE + 17;
const int LID_EFEM_CLEAR_WAFER_INFO_FAIL	= LID_EFEM_BASE + 18;
const int LID_EFEM_OPEN_RECIPE_FAIL			= LID_EFEM_BASE + 19;
const int LID_EFEM_LOAD_RECIPE_FAIL			= LID_EFEM_BASE + 20;
const int LID_EFEM_TARGET_HAS_WAFER			= LID_EFEM_BASE + 21;
const int LID_EFEM_SEND_EVENT_FAIL          = LID_EFEM_BASE + 22;
const int LID_EFEM_VAC_ABNORMAL             = LID_EFEM_BASE + 23;
const int LID_EFEM_AIR_ABNORMAL             = LID_EFEM_BASE + 24;
const int LID_EFEM_DOOR_SWITCH_OPEN         = LID_EFEM_BASE + 25;
const int LID_EFEM_ROBOT_POWER_ABNORMAL     = LID_EFEM_BASE + 26;

//////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////
// TM Log ID
const char TM_MODULE[] = "TM";
const int LID_TM_BASE = 4000;
//////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////
// Statistic Log ID
const char ST_MODULE[] = "Statistic";
const int LID_ST_BASE = 5000;
//////////////////////////////////////////////////////////////////////////