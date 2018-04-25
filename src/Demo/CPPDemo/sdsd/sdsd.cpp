// sdsd.cpp : CsdsdApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "sdsd.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CsdsdApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0xA04F3CFF, 0xA7A9, 0x4945, { 0x82, 0xFA, 0x5C, 0xCE, 0x4B, 0x19, 0x29, 0x1F } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CsdsdApp::InitInstance - DLL 初始化

BOOL CsdsdApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CsdsdApp::ExitInstance - DLL 终止

int CsdsdApp::ExitInstance()
{
	// TODO: 在此添加您自己的模块终止代码。

	return COleControlModule::ExitInstance();
}



// DllRegisterServer - 将项添加到系统注册表

STDAPI DllRegisterServer(void)
{
	AFX_MANAGE_STATE(_afxModuleAddrThis);

	if (!AfxOleRegisterTypeLib(AfxGetInstanceHandle(), _tlid))
		return ResultFromScode(SELFREG_E_TYPELIB);

	if (!COleObjectFactoryEx::UpdateRegistryAll(TRUE))
		return ResultFromScode(SELFREG_E_CLASS);

	return NOERROR;
}



// DllUnregisterServer - 将项从系统注册表中移除

STDAPI DllUnregisterServer(void)
{
	AFX_MANAGE_STATE(_afxModuleAddrThis);

	if (!AfxOleUnregisterTypeLib(_tlid, _wVerMajor, _wVerMinor))
		return ResultFromScode(SELFREG_E_TYPELIB);

	if (!COleObjectFactoryEx::UpdateRegistryAll(FALSE))
		return ResultFromScode(SELFREG_E_CLASS);

	return NOERROR;
}
