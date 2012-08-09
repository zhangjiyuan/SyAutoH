// **********************************************************************
//
// Copyright (c) 2003-2009 ZeroC, Inc. All rights reserved.
//
// This copy of Ice is licensed to you under the terms described in the
// ICE_LICENSE file included in this distribution.
//
// **********************************************************************

#ifndef LogInterface_ICE
#define LogInterface_ICE


module MCS
{


interface FoupMove
{
    idempotent int Move(int FoupID, int From, int To);
};

};

#endif