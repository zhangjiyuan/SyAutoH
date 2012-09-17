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

struct LocFoup
{
	int nDevID;
	int nLocType;
	string sStatus;
};

interface MESLink
{
    idempotent int PlaceFoup(string FoupID, int DevID, int nLocType);
    idempotent int PickFoup(string FoupId, int DevID, int nLocType);
    idempotent LocFoup GetFoup(string FoupId);
};

};

#endif
