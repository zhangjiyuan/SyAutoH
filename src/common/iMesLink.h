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
// Generated from file `iMesLink.ice'
//
// Warning: do not edit this file.
//
// </auto-generated>
//

#ifndef _____common_iMesLink_h__
#define _____common_iMesLink_h__

#include <Ice/LocalObjectF.h>
#include <Ice/ProxyF.h>
#include <Ice/ObjectF.h>
#include <Ice/Exception.h>
#include <Ice/LocalObject.h>
#include <Ice/Proxy.h>
#include <Ice/Object.h>
#include <Ice/Outgoing.h>
#include <Ice/OutgoingAsync.h>
#include <Ice/Incoming.h>
#include <Ice/Direct.h>
#include <IceUtil/ScopedArray.h>
#include <Ice/StreamF.h>
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

namespace IceProxy
{

namespace MCS
{

class MESLink;

}

}

namespace MCS
{

class MESLink;
bool operator==(const MESLink&, const MESLink&);
bool operator<(const MESLink&, const MESLink&);

}

namespace IceInternal
{

::Ice::Object* upCast(::MCS::MESLink*);
::IceProxy::Ice::Object* upCast(::IceProxy::MCS::MESLink*);

}

namespace MCS
{

typedef ::IceInternal::Handle< ::MCS::MESLink> MESLinkPtr;
typedef ::IceInternal::ProxyHandle< ::IceProxy::MCS::MESLink> MESLinkPrx;

void __read(::IceInternal::BasicStream*, MESLinkPrx&);
void __patch__MESLinkPtr(void*, ::Ice::ObjectPtr&);

}

namespace MCS
{

struct LocFoup
{
    ::Ice::Int nDevID;
    ::Ice::Int nLocType;
    ::std::string sStatus;

    bool operator==(const LocFoup& __rhs) const
    {
        if(this == &__rhs)
        {
            return true;
        }
        if(nDevID != __rhs.nDevID)
        {
            return false;
        }
        if(nLocType != __rhs.nLocType)
        {
            return false;
        }
        if(sStatus != __rhs.sStatus)
        {
            return false;
        }
        return true;
    }

    bool operator<(const LocFoup& __rhs) const
    {
        if(this == &__rhs)
        {
            return false;
        }
        if(nDevID < __rhs.nDevID)
        {
            return true;
        }
        else if(__rhs.nDevID < nDevID)
        {
            return false;
        }
        if(nLocType < __rhs.nLocType)
        {
            return true;
        }
        else if(__rhs.nLocType < nLocType)
        {
            return false;
        }
        if(sStatus < __rhs.sStatus)
        {
            return true;
        }
        else if(__rhs.sStatus < sStatus)
        {
            return false;
        }
        return false;
    }

    bool operator!=(const LocFoup& __rhs) const
    {
        return !operator==(__rhs);
    }
    bool operator<=(const LocFoup& __rhs) const
    {
        return operator<(__rhs) || operator==(__rhs);
    }
    bool operator>(const LocFoup& __rhs) const
    {
        return !operator<(__rhs) && !operator==(__rhs);
    }
    bool operator>=(const LocFoup& __rhs) const
    {
        return !operator<(__rhs);
    }

    void __write(::IceInternal::BasicStream*) const;
    void __read(::IceInternal::BasicStream*);
};

}

namespace MCS
{

class Callback_MESLink_PlaceFoup_Base : virtual public ::IceInternal::CallbackBase { };
typedef ::IceUtil::Handle< Callback_MESLink_PlaceFoup_Base> Callback_MESLink_PlaceFoupPtr;

class Callback_MESLink_PickFoup_Base : virtual public ::IceInternal::CallbackBase { };
typedef ::IceUtil::Handle< Callback_MESLink_PickFoup_Base> Callback_MESLink_PickFoupPtr;

class Callback_MESLink_GetFoup_Base : virtual public ::IceInternal::CallbackBase { };
typedef ::IceUtil::Handle< Callback_MESLink_GetFoup_Base> Callback_MESLink_GetFoupPtr;

}

namespace IceProxy
{

namespace MCS
{

class MESLink : virtual public ::IceProxy::Ice::Object
{
public:

    ::Ice::Int PlaceFoup(const ::std::string& FoupID, ::Ice::Int DevID, ::Ice::Int nLocType)
    {
        return PlaceFoup(FoupID, DevID, nLocType, 0);
    }
    ::Ice::Int PlaceFoup(const ::std::string& FoupID, ::Ice::Int DevID, ::Ice::Int nLocType, const ::Ice::Context& __ctx)
    {
        return PlaceFoup(FoupID, DevID, nLocType, &__ctx);
    }

    ::Ice::AsyncResultPtr begin_PlaceFoup(const ::std::string& FoupID, ::Ice::Int DevID, ::Ice::Int nLocType)
    {
        return begin_PlaceFoup(FoupID, DevID, nLocType, 0, ::IceInternal::__dummyCallback, 0);
    }

    ::Ice::AsyncResultPtr begin_PlaceFoup(const ::std::string& FoupID, ::Ice::Int DevID, ::Ice::Int nLocType, const ::Ice::Context& __ctx)
    {
        return begin_PlaceFoup(FoupID, DevID, nLocType, &__ctx, ::IceInternal::__dummyCallback, 0);
    }

    ::Ice::AsyncResultPtr begin_PlaceFoup(const ::std::string& FoupID, ::Ice::Int DevID, ::Ice::Int nLocType, const ::Ice::CallbackPtr& __del, const ::Ice::LocalObjectPtr& __cookie = 0)
    {
        return begin_PlaceFoup(FoupID, DevID, nLocType, 0, __del, __cookie);
    }

    ::Ice::AsyncResultPtr begin_PlaceFoup(const ::std::string& FoupID, ::Ice::Int DevID, ::Ice::Int nLocType, const ::Ice::Context& __ctx, const ::Ice::CallbackPtr& __del, const ::Ice::LocalObjectPtr& __cookie = 0)
    {
        return begin_PlaceFoup(FoupID, DevID, nLocType, &__ctx, __del, __cookie);
    }

    ::Ice::AsyncResultPtr begin_PlaceFoup(const ::std::string& FoupID, ::Ice::Int DevID, ::Ice::Int nLocType, const ::MCS::Callback_MESLink_PlaceFoupPtr& __del, const ::Ice::LocalObjectPtr& __cookie = 0)
    {
        return begin_PlaceFoup(FoupID, DevID, nLocType, 0, __del, __cookie);
    }

    ::Ice::AsyncResultPtr begin_PlaceFoup(const ::std::string& FoupID, ::Ice::Int DevID, ::Ice::Int nLocType, const ::Ice::Context& __ctx, const ::MCS::Callback_MESLink_PlaceFoupPtr& __del, const ::Ice::LocalObjectPtr& __cookie = 0)
    {
        return begin_PlaceFoup(FoupID, DevID, nLocType, &__ctx, __del, __cookie);
    }

    ::Ice::Int end_PlaceFoup(const ::Ice::AsyncResultPtr&);
    
private:

    ::Ice::Int PlaceFoup(const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Context*);
    ::Ice::AsyncResultPtr begin_PlaceFoup(const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Context*, const ::IceInternal::CallbackBasePtr&, const ::Ice::LocalObjectPtr& __cookie = 0);
    
public:

    ::Ice::Int PickFoup(const ::std::string& FoupId, ::Ice::Int DevID, ::Ice::Int nLocType)
    {
        return PickFoup(FoupId, DevID, nLocType, 0);
    }
    ::Ice::Int PickFoup(const ::std::string& FoupId, ::Ice::Int DevID, ::Ice::Int nLocType, const ::Ice::Context& __ctx)
    {
        return PickFoup(FoupId, DevID, nLocType, &__ctx);
    }

    ::Ice::AsyncResultPtr begin_PickFoup(const ::std::string& FoupId, ::Ice::Int DevID, ::Ice::Int nLocType)
    {
        return begin_PickFoup(FoupId, DevID, nLocType, 0, ::IceInternal::__dummyCallback, 0);
    }

    ::Ice::AsyncResultPtr begin_PickFoup(const ::std::string& FoupId, ::Ice::Int DevID, ::Ice::Int nLocType, const ::Ice::Context& __ctx)
    {
        return begin_PickFoup(FoupId, DevID, nLocType, &__ctx, ::IceInternal::__dummyCallback, 0);
    }

    ::Ice::AsyncResultPtr begin_PickFoup(const ::std::string& FoupId, ::Ice::Int DevID, ::Ice::Int nLocType, const ::Ice::CallbackPtr& __del, const ::Ice::LocalObjectPtr& __cookie = 0)
    {
        return begin_PickFoup(FoupId, DevID, nLocType, 0, __del, __cookie);
    }

    ::Ice::AsyncResultPtr begin_PickFoup(const ::std::string& FoupId, ::Ice::Int DevID, ::Ice::Int nLocType, const ::Ice::Context& __ctx, const ::Ice::CallbackPtr& __del, const ::Ice::LocalObjectPtr& __cookie = 0)
    {
        return begin_PickFoup(FoupId, DevID, nLocType, &__ctx, __del, __cookie);
    }

    ::Ice::AsyncResultPtr begin_PickFoup(const ::std::string& FoupId, ::Ice::Int DevID, ::Ice::Int nLocType, const ::MCS::Callback_MESLink_PickFoupPtr& __del, const ::Ice::LocalObjectPtr& __cookie = 0)
    {
        return begin_PickFoup(FoupId, DevID, nLocType, 0, __del, __cookie);
    }

    ::Ice::AsyncResultPtr begin_PickFoup(const ::std::string& FoupId, ::Ice::Int DevID, ::Ice::Int nLocType, const ::Ice::Context& __ctx, const ::MCS::Callback_MESLink_PickFoupPtr& __del, const ::Ice::LocalObjectPtr& __cookie = 0)
    {
        return begin_PickFoup(FoupId, DevID, nLocType, &__ctx, __del, __cookie);
    }

    ::Ice::Int end_PickFoup(const ::Ice::AsyncResultPtr&);
    
private:

    ::Ice::Int PickFoup(const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Context*);
    ::Ice::AsyncResultPtr begin_PickFoup(const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Context*, const ::IceInternal::CallbackBasePtr&, const ::Ice::LocalObjectPtr& __cookie = 0);
    
public:

    ::MCS::LocFoup GetFoup(const ::std::string& FoupId)
    {
        return GetFoup(FoupId, 0);
    }
    ::MCS::LocFoup GetFoup(const ::std::string& FoupId, const ::Ice::Context& __ctx)
    {
        return GetFoup(FoupId, &__ctx);
    }

    ::Ice::AsyncResultPtr begin_GetFoup(const ::std::string& FoupId)
    {
        return begin_GetFoup(FoupId, 0, ::IceInternal::__dummyCallback, 0);
    }

    ::Ice::AsyncResultPtr begin_GetFoup(const ::std::string& FoupId, const ::Ice::Context& __ctx)
    {
        return begin_GetFoup(FoupId, &__ctx, ::IceInternal::__dummyCallback, 0);
    }

    ::Ice::AsyncResultPtr begin_GetFoup(const ::std::string& FoupId, const ::Ice::CallbackPtr& __del, const ::Ice::LocalObjectPtr& __cookie = 0)
    {
        return begin_GetFoup(FoupId, 0, __del, __cookie);
    }

    ::Ice::AsyncResultPtr begin_GetFoup(const ::std::string& FoupId, const ::Ice::Context& __ctx, const ::Ice::CallbackPtr& __del, const ::Ice::LocalObjectPtr& __cookie = 0)
    {
        return begin_GetFoup(FoupId, &__ctx, __del, __cookie);
    }

    ::Ice::AsyncResultPtr begin_GetFoup(const ::std::string& FoupId, const ::MCS::Callback_MESLink_GetFoupPtr& __del, const ::Ice::LocalObjectPtr& __cookie = 0)
    {
        return begin_GetFoup(FoupId, 0, __del, __cookie);
    }

    ::Ice::AsyncResultPtr begin_GetFoup(const ::std::string& FoupId, const ::Ice::Context& __ctx, const ::MCS::Callback_MESLink_GetFoupPtr& __del, const ::Ice::LocalObjectPtr& __cookie = 0)
    {
        return begin_GetFoup(FoupId, &__ctx, __del, __cookie);
    }

    ::MCS::LocFoup end_GetFoup(const ::Ice::AsyncResultPtr&);
    
private:

    ::MCS::LocFoup GetFoup(const ::std::string&, const ::Ice::Context*);
    ::Ice::AsyncResultPtr begin_GetFoup(const ::std::string&, const ::Ice::Context*, const ::IceInternal::CallbackBasePtr&, const ::Ice::LocalObjectPtr& __cookie = 0);
    
public:
    
    ::IceInternal::ProxyHandle<MESLink> ice_context(const ::Ice::Context& __context) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_context(__context).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_context(__context).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_adapterId(const std::string& __id) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_adapterId(__id).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_adapterId(__id).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_endpoints(const ::Ice::EndpointSeq& __endpoints) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_endpoints(__endpoints).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_endpoints(__endpoints).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_locatorCacheTimeout(int __timeout) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_locatorCacheTimeout(__timeout).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_locatorCacheTimeout(__timeout).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_connectionCached(bool __cached) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_connectionCached(__cached).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_connectionCached(__cached).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_endpointSelection(::Ice::EndpointSelectionType __est) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_endpointSelection(__est).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_endpointSelection(__est).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_secure(bool __secure) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_secure(__secure).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_secure(__secure).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_preferSecure(bool __preferSecure) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_preferSecure(__preferSecure).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_preferSecure(__preferSecure).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_router(const ::Ice::RouterPrx& __router) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_router(__router).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_router(__router).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_locator(const ::Ice::LocatorPrx& __locator) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_locator(__locator).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_locator(__locator).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_collocationOptimized(bool __co) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_collocationOptimized(__co).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_collocationOptimized(__co).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_twoway() const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_twoway().get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_twoway().get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_oneway() const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_oneway().get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_oneway().get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_batchOneway() const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_batchOneway().get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_batchOneway().get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_datagram() const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_datagram().get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_datagram().get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_batchDatagram() const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_batchDatagram().get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_batchDatagram().get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_compress(bool __compress) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_compress(__compress).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_compress(__compress).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_timeout(int __timeout) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_timeout(__timeout).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_timeout(__timeout).get());
    #endif
    }
    
    ::IceInternal::ProxyHandle<MESLink> ice_connectionId(const std::string& __id) const
    {
    #if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
        typedef ::IceProxy::Ice::Object _Base;
        return dynamic_cast<MESLink*>(_Base::ice_connectionId(__id).get());
    #else
        return dynamic_cast<MESLink*>(::IceProxy::Ice::Object::ice_connectionId(__id).get());
    #endif
    }
    
    static const ::std::string& ice_staticId();

private: 

    virtual ::IceInternal::Handle< ::IceDelegateM::Ice::Object> __createDelegateM();
    virtual ::IceInternal::Handle< ::IceDelegateD::Ice::Object> __createDelegateD();
    virtual ::IceProxy::Ice::Object* __newInstance() const;
};

}

}

namespace IceDelegate
{

namespace MCS
{

class MESLink : virtual public ::IceDelegate::Ice::Object
{
public:

    virtual ::Ice::Int PlaceFoup(const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Context*) = 0;

    virtual ::Ice::Int PickFoup(const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Context*) = 0;

    virtual ::MCS::LocFoup GetFoup(const ::std::string&, const ::Ice::Context*) = 0;
};

}

}

namespace IceDelegateM
{

namespace MCS
{

class MESLink : virtual public ::IceDelegate::MCS::MESLink,
                virtual public ::IceDelegateM::Ice::Object
{
public:

    virtual ::Ice::Int PlaceFoup(const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Context*);

    virtual ::Ice::Int PickFoup(const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Context*);

    virtual ::MCS::LocFoup GetFoup(const ::std::string&, const ::Ice::Context*);
};

}

}

namespace IceDelegateD
{

namespace MCS
{

class MESLink : virtual public ::IceDelegate::MCS::MESLink,
                virtual public ::IceDelegateD::Ice::Object
{
public:

    virtual ::Ice::Int PlaceFoup(const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Context*);

    virtual ::Ice::Int PickFoup(const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Context*);

    virtual ::MCS::LocFoup GetFoup(const ::std::string&, const ::Ice::Context*);
};

}

}

namespace MCS
{

class MESLink : virtual public ::Ice::Object
{
public:

    typedef MESLinkPrx ProxyType;
    typedef MESLinkPtr PointerType;
    
    virtual ::Ice::ObjectPtr ice_clone() const;

    virtual bool ice_isA(const ::std::string&, const ::Ice::Current& = ::Ice::Current()) const;
    virtual ::std::vector< ::std::string> ice_ids(const ::Ice::Current& = ::Ice::Current()) const;
    virtual const ::std::string& ice_id(const ::Ice::Current& = ::Ice::Current()) const;
    static const ::std::string& ice_staticId();

    virtual ::Ice::Int PlaceFoup(const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Current& = ::Ice::Current()) = 0;
    ::Ice::DispatchStatus ___PlaceFoup(::IceInternal::Incoming&, const ::Ice::Current&);

    virtual ::Ice::Int PickFoup(const ::std::string&, ::Ice::Int, ::Ice::Int, const ::Ice::Current& = ::Ice::Current()) = 0;
    ::Ice::DispatchStatus ___PickFoup(::IceInternal::Incoming&, const ::Ice::Current&);

    virtual ::MCS::LocFoup GetFoup(const ::std::string&, const ::Ice::Current& = ::Ice::Current()) = 0;
    ::Ice::DispatchStatus ___GetFoup(::IceInternal::Incoming&, const ::Ice::Current&);

    virtual ::Ice::DispatchStatus __dispatch(::IceInternal::Incoming&, const ::Ice::Current&);

    virtual void __write(::IceInternal::BasicStream*) const;
    virtual void __read(::IceInternal::BasicStream*, bool);
// COMPILERFIX: Stream API is not supported with VC++ 6
#if !defined(_MSC_VER) || (_MSC_VER >= 1300)
    virtual void __write(const ::Ice::OutputStreamPtr&) const;
    virtual void __read(const ::Ice::InputStreamPtr&, bool);
#endif
};

inline bool operator==(const MESLink& l, const MESLink& r)
{
    return static_cast<const ::Ice::Object&>(l) == static_cast<const ::Ice::Object&>(r);
}

inline bool operator<(const MESLink& l, const MESLink& r)
{
    return static_cast<const ::Ice::Object&>(l) < static_cast<const ::Ice::Object&>(r);
}

}

namespace MCS
{

template<class T>
class CallbackNC_MESLink_PlaceFoup : public Callback_MESLink_PlaceFoup_Base, public ::IceInternal::TwowayCallbackNC<T>
{
public:

    typedef IceUtil::Handle<T> TPtr;

    typedef void (T::*Exception)(const ::Ice::Exception&);
    typedef void (T::*Sent)(bool);
    typedef void (T::*Response)(::Ice::Int);

    CallbackNC_MESLink_PlaceFoup(const TPtr& obj, Response cb, Exception excb, Sent sentcb)
        : ::IceInternal::TwowayCallbackNC<T>(obj, cb != 0, excb, sentcb), response(cb)
    {
    }

    virtual void __completed(const ::Ice::AsyncResultPtr& __result) const
    {
        ::MCS::MESLinkPrx __proxy = ::MCS::MESLinkPrx::uncheckedCast(__result->getProxy());
        ::Ice::Int __ret;
        try
        {
            __ret = __proxy->end_PlaceFoup(__result);
        }
        catch(::Ice::Exception& ex)
        {
#if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
            __exception(__result, ex);
#else
            ::IceInternal::CallbackNC<T>::__exception(__result, ex);
#endif
            return;
        }
        if(response)
        {
#if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
            (callback.get()->*response)(__ret);
#else
            (::IceInternal::CallbackNC<T>::callback.get()->*response)(__ret);
#endif
        }
    }

    Response response;
};

template<class T> Callback_MESLink_PlaceFoupPtr
newCallback_MESLink_PlaceFoup(const IceUtil::Handle<T>& instance, void (T::*cb)(::Ice::Int), void (T::*excb)(const ::Ice::Exception&), void (T::*sentcb)(bool) = 0)
{
    return new CallbackNC_MESLink_PlaceFoup<T>(instance, cb, excb, sentcb);
}

template<class T> Callback_MESLink_PlaceFoupPtr
newCallback_MESLink_PlaceFoup(T* instance, void (T::*cb)(::Ice::Int), void (T::*excb)(const ::Ice::Exception&), void (T::*sentcb)(bool) = 0)
{
    return new CallbackNC_MESLink_PlaceFoup<T>(instance, cb, excb, sentcb);
}

template<class T, typename CT>
class Callback_MESLink_PlaceFoup : public Callback_MESLink_PlaceFoup_Base, public ::IceInternal::TwowayCallback<T, CT>
{
public:

    typedef IceUtil::Handle<T> TPtr;

    typedef void (T::*Exception)(const ::Ice::Exception& , const CT&);
    typedef void (T::*Sent)(bool , const CT&);
    typedef void (T::*Response)(::Ice::Int, const CT&);

    Callback_MESLink_PlaceFoup(const TPtr& obj, Response cb, Exception excb, Sent sentcb)
        : ::IceInternal::TwowayCallback<T, CT>(obj, cb != 0, excb, sentcb), response(cb)
    {
    }

    virtual void __completed(const ::Ice::AsyncResultPtr& __result) const
    {
        ::MCS::MESLinkPrx __proxy = ::MCS::MESLinkPrx::uncheckedCast(__result->getProxy());
        ::Ice::Int __ret;
        try
        {
            __ret = __proxy->end_PlaceFoup(__result);
        }
        catch(::Ice::Exception& ex)
        {
#if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
            __exception(__result, ex);
#else
            ::IceInternal::Callback<T, CT>::__exception(__result, ex);
#endif
            return;
        }
        if(response)
        {
#if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
            (callback.get()->*response)(__ret, CT::dynamicCast(__result->getCookie()));
#else
            (::IceInternal::Callback<T, CT>::callback.get()->*response)(__ret, CT::dynamicCast(__result->getCookie()));
#endif
        }
    }

    Response response;
};

template<class T, typename CT> Callback_MESLink_PlaceFoupPtr
newCallback_MESLink_PlaceFoup(const IceUtil::Handle<T>& instance, void (T::*cb)(::Ice::Int, const CT&), void (T::*excb)(const ::Ice::Exception&, const CT&), void (T::*sentcb)(bool, const CT&) = 0)
{
    return new Callback_MESLink_PlaceFoup<T, CT>(instance, cb, excb, sentcb);
}

template<class T, typename CT> Callback_MESLink_PlaceFoupPtr
newCallback_MESLink_PlaceFoup(T* instance, void (T::*cb)(::Ice::Int, const CT&), void (T::*excb)(const ::Ice::Exception&, const CT&), void (T::*sentcb)(bool, const CT&) = 0)
{
    return new Callback_MESLink_PlaceFoup<T, CT>(instance, cb, excb, sentcb);
}

template<class T>
class CallbackNC_MESLink_PickFoup : public Callback_MESLink_PickFoup_Base, public ::IceInternal::TwowayCallbackNC<T>
{
public:

    typedef IceUtil::Handle<T> TPtr;

    typedef void (T::*Exception)(const ::Ice::Exception&);
    typedef void (T::*Sent)(bool);
    typedef void (T::*Response)(::Ice::Int);

    CallbackNC_MESLink_PickFoup(const TPtr& obj, Response cb, Exception excb, Sent sentcb)
        : ::IceInternal::TwowayCallbackNC<T>(obj, cb != 0, excb, sentcb), response(cb)
    {
    }

    virtual void __completed(const ::Ice::AsyncResultPtr& __result) const
    {
        ::MCS::MESLinkPrx __proxy = ::MCS::MESLinkPrx::uncheckedCast(__result->getProxy());
        ::Ice::Int __ret;
        try
        {
            __ret = __proxy->end_PickFoup(__result);
        }
        catch(::Ice::Exception& ex)
        {
#if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
            __exception(__result, ex);
#else
            ::IceInternal::CallbackNC<T>::__exception(__result, ex);
#endif
            return;
        }
        if(response)
        {
#if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
            (callback.get()->*response)(__ret);
#else
            (::IceInternal::CallbackNC<T>::callback.get()->*response)(__ret);
#endif
        }
    }

    Response response;
};

template<class T> Callback_MESLink_PickFoupPtr
newCallback_MESLink_PickFoup(const IceUtil::Handle<T>& instance, void (T::*cb)(::Ice::Int), void (T::*excb)(const ::Ice::Exception&), void (T::*sentcb)(bool) = 0)
{
    return new CallbackNC_MESLink_PickFoup<T>(instance, cb, excb, sentcb);
}

template<class T> Callback_MESLink_PickFoupPtr
newCallback_MESLink_PickFoup(T* instance, void (T::*cb)(::Ice::Int), void (T::*excb)(const ::Ice::Exception&), void (T::*sentcb)(bool) = 0)
{
    return new CallbackNC_MESLink_PickFoup<T>(instance, cb, excb, sentcb);
}

template<class T, typename CT>
class Callback_MESLink_PickFoup : public Callback_MESLink_PickFoup_Base, public ::IceInternal::TwowayCallback<T, CT>
{
public:

    typedef IceUtil::Handle<T> TPtr;

    typedef void (T::*Exception)(const ::Ice::Exception& , const CT&);
    typedef void (T::*Sent)(bool , const CT&);
    typedef void (T::*Response)(::Ice::Int, const CT&);

    Callback_MESLink_PickFoup(const TPtr& obj, Response cb, Exception excb, Sent sentcb)
        : ::IceInternal::TwowayCallback<T, CT>(obj, cb != 0, excb, sentcb), response(cb)
    {
    }

    virtual void __completed(const ::Ice::AsyncResultPtr& __result) const
    {
        ::MCS::MESLinkPrx __proxy = ::MCS::MESLinkPrx::uncheckedCast(__result->getProxy());
        ::Ice::Int __ret;
        try
        {
            __ret = __proxy->end_PickFoup(__result);
        }
        catch(::Ice::Exception& ex)
        {
#if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
            __exception(__result, ex);
#else
            ::IceInternal::Callback<T, CT>::__exception(__result, ex);
#endif
            return;
        }
        if(response)
        {
#if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
            (callback.get()->*response)(__ret, CT::dynamicCast(__result->getCookie()));
#else
            (::IceInternal::Callback<T, CT>::callback.get()->*response)(__ret, CT::dynamicCast(__result->getCookie()));
#endif
        }
    }

    Response response;
};

template<class T, typename CT> Callback_MESLink_PickFoupPtr
newCallback_MESLink_PickFoup(const IceUtil::Handle<T>& instance, void (T::*cb)(::Ice::Int, const CT&), void (T::*excb)(const ::Ice::Exception&, const CT&), void (T::*sentcb)(bool, const CT&) = 0)
{
    return new Callback_MESLink_PickFoup<T, CT>(instance, cb, excb, sentcb);
}

template<class T, typename CT> Callback_MESLink_PickFoupPtr
newCallback_MESLink_PickFoup(T* instance, void (T::*cb)(::Ice::Int, const CT&), void (T::*excb)(const ::Ice::Exception&, const CT&), void (T::*sentcb)(bool, const CT&) = 0)
{
    return new Callback_MESLink_PickFoup<T, CT>(instance, cb, excb, sentcb);
}

template<class T>
class CallbackNC_MESLink_GetFoup : public Callback_MESLink_GetFoup_Base, public ::IceInternal::TwowayCallbackNC<T>
{
public:

    typedef IceUtil::Handle<T> TPtr;

    typedef void (T::*Exception)(const ::Ice::Exception&);
    typedef void (T::*Sent)(bool);
    typedef void (T::*Response)(const ::MCS::LocFoup&);

    CallbackNC_MESLink_GetFoup(const TPtr& obj, Response cb, Exception excb, Sent sentcb)
        : ::IceInternal::TwowayCallbackNC<T>(obj, cb != 0, excb, sentcb), response(cb)
    {
    }

    virtual void __completed(const ::Ice::AsyncResultPtr& __result) const
    {
        ::MCS::MESLinkPrx __proxy = ::MCS::MESLinkPrx::uncheckedCast(__result->getProxy());
        ::MCS::LocFoup __ret;
        try
        {
            __ret = __proxy->end_GetFoup(__result);
        }
        catch(::Ice::Exception& ex)
        {
#if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
            __exception(__result, ex);
#else
            ::IceInternal::CallbackNC<T>::__exception(__result, ex);
#endif
            return;
        }
        if(response)
        {
#if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
            (callback.get()->*response)(__ret);
#else
            (::IceInternal::CallbackNC<T>::callback.get()->*response)(__ret);
#endif
        }
    }

    Response response;
};

template<class T> Callback_MESLink_GetFoupPtr
newCallback_MESLink_GetFoup(const IceUtil::Handle<T>& instance, void (T::*cb)(const ::MCS::LocFoup&), void (T::*excb)(const ::Ice::Exception&), void (T::*sentcb)(bool) = 0)
{
    return new CallbackNC_MESLink_GetFoup<T>(instance, cb, excb, sentcb);
}

template<class T> Callback_MESLink_GetFoupPtr
newCallback_MESLink_GetFoup(T* instance, void (T::*cb)(const ::MCS::LocFoup&), void (T::*excb)(const ::Ice::Exception&), void (T::*sentcb)(bool) = 0)
{
    return new CallbackNC_MESLink_GetFoup<T>(instance, cb, excb, sentcb);
}

template<class T, typename CT>
class Callback_MESLink_GetFoup : public Callback_MESLink_GetFoup_Base, public ::IceInternal::TwowayCallback<T, CT>
{
public:

    typedef IceUtil::Handle<T> TPtr;

    typedef void (T::*Exception)(const ::Ice::Exception& , const CT&);
    typedef void (T::*Sent)(bool , const CT&);
    typedef void (T::*Response)(const ::MCS::LocFoup&, const CT&);

    Callback_MESLink_GetFoup(const TPtr& obj, Response cb, Exception excb, Sent sentcb)
        : ::IceInternal::TwowayCallback<T, CT>(obj, cb != 0, excb, sentcb), response(cb)
    {
    }

    virtual void __completed(const ::Ice::AsyncResultPtr& __result) const
    {
        ::MCS::MESLinkPrx __proxy = ::MCS::MESLinkPrx::uncheckedCast(__result->getProxy());
        ::MCS::LocFoup __ret;
        try
        {
            __ret = __proxy->end_GetFoup(__result);
        }
        catch(::Ice::Exception& ex)
        {
#if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
            __exception(__result, ex);
#else
            ::IceInternal::Callback<T, CT>::__exception(__result, ex);
#endif
            return;
        }
        if(response)
        {
#if defined(_MSC_VER) && (_MSC_VER < 1300) // VC++ 6 compiler bug
            (callback.get()->*response)(__ret, CT::dynamicCast(__result->getCookie()));
#else
            (::IceInternal::Callback<T, CT>::callback.get()->*response)(__ret, CT::dynamicCast(__result->getCookie()));
#endif
        }
    }

    Response response;
};

template<class T, typename CT> Callback_MESLink_GetFoupPtr
newCallback_MESLink_GetFoup(const IceUtil::Handle<T>& instance, void (T::*cb)(const ::MCS::LocFoup&, const CT&), void (T::*excb)(const ::Ice::Exception&, const CT&), void (T::*sentcb)(bool, const CT&) = 0)
{
    return new Callback_MESLink_GetFoup<T, CT>(instance, cb, excb, sentcb);
}

template<class T, typename CT> Callback_MESLink_GetFoupPtr
newCallback_MESLink_GetFoup(T* instance, void (T::*cb)(const ::MCS::LocFoup&, const CT&), void (T::*excb)(const ::Ice::Exception&, const CT&), void (T::*sentcb)(bool, const CT&) = 0)
{
    return new Callback_MESLink_GetFoup<T, CT>(instance, cb, excb, sentcb);
}

}

#endif
