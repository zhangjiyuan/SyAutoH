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

interface GuiDataHub
{
    idempotent int Login(string user, string pass);
    idempotent int Logout(int session);
    idempotent string ReadData(string Tag, int session);
    idempotent int WriteData(string Tag, string Val, int session);
};

};

#endif
