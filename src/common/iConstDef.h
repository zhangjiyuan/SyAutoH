// **********************************************************************
//
// Copyright (c) 2003-2011 ZeroC, Inc. All rights reserved.
//
// This copy of Ice is licensed to you under the terms described in the
// ICE_LICENSE file included in this distribution.
//
// **********************************************************************
//
// Ice version 3.4.2
//
// <auto-generated>
//
// Generated from file `iConstDef.ice'
//
// Warning: do not edit this file.
//
// </auto-generated>
//

#ifndef _____common_iConstDef_h__
#define _____common_iConstDef_h__

#include <Ice/LocalObjectF.h>
#include <Ice/ProxyF.h>
#include <Ice/ObjectF.h>
#include <Ice/Exception.h>
#include <Ice/LocalObject.h>
#include <IceUtil/ScopedArray.h>
#include <Ice/UndefSysMacros.h>

#ifndef ICE_IGNORE_VERSION
#   if ICE_INT_VERSION / 100 != 304
#       error Ice version mismatch!
#   endif
#   if ICE_INT_VERSION % 100 > 50
#       error Beta header file detected
#   endif
#   if ICE_INT_VERSION % 100 < 2
#       error Ice patch level mismatch!
#   endif
#endif

namespace MCS
{

namespace GuiHub
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
    StkInquiryRoom,
    StkInquiryStorage,
    StkInquiryInputStatus,
    StkFoupHistory,
    StkAlarmHistory,
    StkStatusTime,
    StkSetFoupInfoBackTime,
    StkGetFoupInSys
};

void __write(::IceInternal::BasicStream*, GuiCommand);
void __read(::IceInternal::BasicStream*, GuiCommand&);

enum PushData
{
    upOhtInfo,
    upOhtPos,
    upOhtPosTable,
    upOhtStatus,
    upStkInfo,
    upStkFoupsInfo,
    upStkLastOptFoup,
    upStkStatus,
    upStkInputStatus,
    upStkFoupInSys,
    upStkRoomStatus
};

void __write(::IceInternal::BasicStream*, PushData);
void __read(::IceInternal::BasicStream*, PushData&);

typedef ::std::vector< ::MCS::GuiHub::PushData> GuiPushDataList;
void __writeGuiPushDataList(::IceInternal::BasicStream*, const ::MCS::GuiHub::PushData*, const ::MCS::GuiHub::PushData*);
void __readGuiPushDataList(::IceInternal::BasicStream*, GuiPushDataList&);

}

}

#endif
