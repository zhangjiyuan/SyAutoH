// **********************************************************************
//
// Copyright (c) 2003-2009 ZeroC, Inc. All rights reserved.
//
// This copy of Ice is licensed to you under the terms described in the
// ICE_LICENSE file included in this distribution.
//
// **********************************************************************

#ifndef CONSTDEF_ICE
#define CONSTDEF_ICE


module MCS
{
	module GuiHub
	{
			enum GuiCommand
			{ 
				OhtPosTime, 
				OhtStatusTime, 
				OhtGetPosTable,
				OhtFoupHanding,
				OhtSetPath,
				OhtMove,
				
				OhtPathTest,
				OhtMoveTest,
				OhtFoupTest,
				
				StkHandFoup,
				StkInquiryStatus,
				StkInquiryPlace,
				StkInquiryFoup,
				StkInquiryEntryStatus,
				StkFoupHistory,
				StkAlarmHistory,
				StkSetStatusBackTime, 
				StkSetFoupInfoBackTime,
				
			};
			
			
			enum PushData
			{
				upOhtInfo,
				upOhtPos,
				upOhtPosTable,
				upOhtStatus,
				
				upStkInfo,
				upFoupsTable
			};
			sequence<PushData> GuiPushDataList;
		
	};

};

#endif
