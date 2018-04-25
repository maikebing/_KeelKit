

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Mon Jun 29 11:46:13 2009
 */
/* Compiler settings for .\sdsd.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__


#ifndef __sdsdidl_h__
#define __sdsdidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___Dsdsd_FWD_DEFINED__
#define ___Dsdsd_FWD_DEFINED__
typedef interface _Dsdsd _Dsdsd;
#endif 	/* ___Dsdsd_FWD_DEFINED__ */


#ifndef ___DsdsdEvents_FWD_DEFINED__
#define ___DsdsdEvents_FWD_DEFINED__
typedef interface _DsdsdEvents _DsdsdEvents;
#endif 	/* ___DsdsdEvents_FWD_DEFINED__ */


#ifndef __sdsd_FWD_DEFINED__
#define __sdsd_FWD_DEFINED__

#ifdef __cplusplus
typedef class sdsd sdsd;
#else
typedef struct sdsd sdsd;
#endif /* __cplusplus */

#endif 	/* __sdsd_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __sdsdLib_LIBRARY_DEFINED__
#define __sdsdLib_LIBRARY_DEFINED__

/* library sdsdLib */
/* [control][helpstring][helpfile][version][uuid] */ 


EXTERN_C const IID LIBID_sdsdLib;

#ifndef ___Dsdsd_DISPINTERFACE_DEFINED__
#define ___Dsdsd_DISPINTERFACE_DEFINED__

/* dispinterface _Dsdsd */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__Dsdsd;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("60B9A45C-6DF5-43BD-A463-28673BC91CC1")
    _Dsdsd : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DsdsdVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _Dsdsd * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _Dsdsd * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _Dsdsd * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _Dsdsd * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _Dsdsd * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _Dsdsd * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _Dsdsd * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DsdsdVtbl;

    interface _Dsdsd
    {
        CONST_VTBL struct _DsdsdVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _Dsdsd_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _Dsdsd_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _Dsdsd_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _Dsdsd_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _Dsdsd_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _Dsdsd_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _Dsdsd_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___Dsdsd_DISPINTERFACE_DEFINED__ */


#ifndef ___DsdsdEvents_DISPINTERFACE_DEFINED__
#define ___DsdsdEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DsdsdEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__DsdsdEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("91638E1F-8CCA-4701-AA4A-F3F3545B417F")
    _DsdsdEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DsdsdEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DsdsdEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DsdsdEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DsdsdEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DsdsdEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DsdsdEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DsdsdEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DsdsdEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DsdsdEventsVtbl;

    interface _DsdsdEvents
    {
        CONST_VTBL struct _DsdsdEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DsdsdEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DsdsdEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DsdsdEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DsdsdEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DsdsdEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DsdsdEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DsdsdEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DsdsdEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_sdsd;

#ifdef __cplusplus

class DECLSPEC_UUID("438DFC09-4DC1-4161-8BBC-9A806A53FD45")
sdsd;
#endif
#endif /* __sdsdLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


