#pragma once

enum Optcodes
{
	OPTION_NULL_ACTION										= 0x0000,
	// defines for OHT
	OHT_MCS_STATUS_BACK_TIME				= 0x0801,	// MCS设置 OHT 状态反馈周期
	OHT_MCS_POSITION_BACK_TIME			= 0x0802,	// MCS设置 OHT 位置反馈周期
	OHT_MCS_PATH											= 0x0803,	// MCS设置 OHT 的路径指令
	OHT_MCS_MOVE											= 0x0804,
	OHT_MCS_FOUP											= 0x0805,
	OHT_MCS_ACK_AUTH								= 0x0806,
	OHT_ACK_STATUS_BACK_TIME				= 0x0811,
	OHT_ACK_POSITION_BACK_TIME				= 0x0812,	
	OHT_ACK_PATH											= 0x0813,	
	OHT_ACK_MOVE											= 0x0814,
	OHT_ACK_FOUP											= 0x0815,
	OHT_AUTH													= 0x0816,
	OHT_POSITION												= 0x0817,
	OHT_STATUS												= 0x0818,

	// defines for Stocker
	STK_MCS_FOUP											= 0x0807,
	STK_MCS_STATUS										= 0x0808,
	STK_MCS_ROOM											= 0x0809,
	STK_MCS_STORAGE									= 0x080A,
	STK_MCS_INPUT_STATUS							= 0x080B,
	STK_MCS_HISTORY										= 0x080C,
	STK_MCS_ALARMS										= 0x080D,
	STK_MCS_STATUS_BACK_TIME				= 0x080E,
	STK_MCS_FOUP_BACK_TIME						= 0x080F,
	STK_ACK_FOUP											= 0x0820,
	STK_ACK_STATUS										= 0x0821,
	STK_ACK_ROOM											= 0x0822,
	STK_ACK_STORAGE										= 0x0823,
	STK_ACK_INPUT_STATUS							= 0x0824,
	STK_ACK_HISTORY										= 0x0825,
	STK_ACK_ALARMS										= 0x0826,
	STK_AUTH														= 0x0827,
	STK_MCS_ACK_AUTH									= 0x0828
};