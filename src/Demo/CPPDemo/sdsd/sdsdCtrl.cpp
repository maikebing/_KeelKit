// sdsdCtrl.cpp : CsdsdCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "sdsd.h"
#include "sdsdCtrl.h"
#include "sdsdPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CsdsdCtrl, COleControl)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CsdsdCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CsdsdCtrl, COleControl)
	DISP_FUNCTION_ID(CsdsdCtrl, "AboutBox", DISPID_ABOUTBOX, AboutBox, VT_EMPTY, VTS_NONE)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CsdsdCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CsdsdCtrl, 1)
	PROPPAGEID(CsdsdPropPage::guid)
END_PROPPAGEIDS(CsdsdCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CsdsdCtrl, "SDSD.sdsdCtrl.1",
	0x438dfc09, 0x4dc1, 0x4161, 0x8b, 0xbc, 0x9a, 0x80, 0x6a, 0x53, 0xfd, 0x45)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CsdsdCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_Dsdsd =
		{ 0x60B9A45C, 0x6DF5, 0x43BD, { 0xA4, 0x63, 0x28, 0x67, 0x3B, 0xC9, 0x1C, 0xC1 } };
const IID BASED_CODE IID_DsdsdEvents =
		{ 0x91638E1F, 0x8CCA, 0x4701, { 0xAA, 0x4A, 0xF3, 0xF3, 0x54, 0x5B, 0x41, 0x7F } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwsdsdOleMisc =
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CsdsdCtrl, IDS_SDSD, _dwsdsdOleMisc)



// CsdsdCtrl::CsdsdCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CsdsdCtrl ��ϵͳע�����

BOOL CsdsdCtrl::CsdsdCtrlFactory::UpdateRegistry(BOOL bRegister)
{
	// TODO: ��֤���Ŀؼ��Ƿ���ϵ�Ԫģ���̴߳������
	// �йظ�����Ϣ����ο� MFC ����˵�� 64��
	// ������Ŀؼ������ϵ�Ԫģ�͹�����
	// �����޸����´��룬��������������
	// afxRegApartmentThreading ��Ϊ 0��

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



// CsdsdCtrl::CsdsdCtrl - ���캯��

CsdsdCtrl::CsdsdCtrl()
{
	InitializeIIDs(&IID_Dsdsd, &IID_DsdsdEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CsdsdCtrl::~CsdsdCtrl - ��������

CsdsdCtrl::~CsdsdCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CsdsdCtrl::OnDraw - ��ͼ����

void CsdsdCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: �����Լ��Ļ�ͼ�����滻����Ĵ��롣
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CsdsdCtrl::DoPropExchange - �־���֧��

void CsdsdCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CsdsdCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CsdsdCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CsdsdCtrl::AboutBox - ���û���ʾ�����ڡ���

void CsdsdCtrl::AboutBox()
{
	CDialog dlgAbout(IDD_ABOUTBOX_SDSD);
	dlgAbout.DoModal();
}



// CsdsdCtrl ��Ϣ�������
