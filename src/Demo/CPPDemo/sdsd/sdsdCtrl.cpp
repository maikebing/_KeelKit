// sdsdCtrl.cpp : CsdsdCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "sdsd.h"
#include "sdsdCtrl.h"
#include "sdsdPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CsdsdCtrl, COleControl)



// 消息映射

BEGIN_MESSAGE_MAP(CsdsdCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CsdsdCtrl, COleControl)
	DISP_FUNCTION_ID(CsdsdCtrl, "AboutBox", DISPID_ABOUTBOX, AboutBox, VT_EMPTY, VTS_NONE)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CsdsdCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CsdsdCtrl, 1)
	PROPPAGEID(CsdsdPropPage::guid)
END_PROPPAGEIDS(CsdsdCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CsdsdCtrl, "SDSD.sdsdCtrl.1",
	0x438dfc09, 0x4dc1, 0x4161, 0x8b, 0xbc, 0x9a, 0x80, 0x6a, 0x53, 0xfd, 0x45)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CsdsdCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_Dsdsd =
		{ 0x60B9A45C, 0x6DF5, 0x43BD, { 0xA4, 0x63, 0x28, 0x67, 0x3B, 0xC9, 0x1C, 0xC1 } };
const IID BASED_CODE IID_DsdsdEvents =
		{ 0x91638E1F, 0x8CCA, 0x4701, { 0xAA, 0x4A, 0xF3, 0xF3, 0x54, 0x5B, 0x41, 0x7F } };



// 控件类型信息

static const DWORD BASED_CODE _dwsdsdOleMisc =
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CsdsdCtrl, IDS_SDSD, _dwsdsdOleMisc)



// CsdsdCtrl::CsdsdCtrlFactory::UpdateRegistry -
// 添加或移除 CsdsdCtrl 的系统注册表项

BOOL CsdsdCtrl::CsdsdCtrlFactory::UpdateRegistry(BOOL bRegister)
{
	// TODO: 验证您的控件是否符合单元模型线程处理规则。
	// 有关更多信息，请参考 MFC 技术说明 64。
	// 如果您的控件不符合单元模型规则，则
	// 必须修改如下代码，将第六个参数从
	// afxRegApartmentThreading 改为 0。

	if (bRegister)
		return AfxOleRegisterControlClass(
			AfxGetInstanceHandle(),
			m_clsid,
			m_lpszProgID,
			IDS_SDSD,
			IDB_SDSD,
			afxRegApartmentThreading,
			_dwsdsdOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CsdsdCtrl::CsdsdCtrl - 构造函数

CsdsdCtrl::CsdsdCtrl()
{
	InitializeIIDs(&IID_Dsdsd, &IID_DsdsdEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CsdsdCtrl::~CsdsdCtrl - 析构函数

CsdsdCtrl::~CsdsdCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CsdsdCtrl::OnDraw - 绘图函数

void CsdsdCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: 用您自己的绘图代码替换下面的代码。
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CsdsdCtrl::DoPropExchange - 持久性支持

void CsdsdCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CsdsdCtrl::OnResetState - 将控件重置为默认状态

void CsdsdCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CsdsdCtrl::AboutBox - 向用户显示“关于”框

void CsdsdCtrl::AboutBox()
{
	CDialog dlgAbout(IDD_ABOUTBOX_SDSD);
	dlgAbout.DoModal();
}



// CsdsdCtrl 消息处理程序
