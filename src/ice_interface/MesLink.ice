// **********************************************************************
//
// Copyright (c) 2003-2009 ZeroC, Inc. All rights reserved.
//
// This copy of Ice is licensed to you under the terms described in the
// ICE_LICENSE file included in this distribution.
//
// **********************************************************************

#ifndef MESLink_ICE
#define MESLink_ICE


module MCS
{

interface MESLink
{
    idempotent int PlaceFoup(int FoupID, int DevID);
    idempotent int PickFoup(int FoupId, int DevID);
};

};

#endif
