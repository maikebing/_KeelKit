// sdsdPropPage.cpp : CsdsdPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "sdsd.h"
#include "sdsdPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CsdsdPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CsdsdPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CsdsdPropPage, "SDSD.sdsdPropPage.1",
	0x2a1458ca, 0x8610, 0x4404, 0x99, 0xba, 0xab, 0x25, 0x6d, 0x58, 0x92, 0xe3)



// CsdsdPropPage::CsdsdPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CsdsdPropPage ��ϵͳע�����

BOOL CsdsdPropPage::CsdsdPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_SDSD_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CsdsdPropPage::CsdsdPropPage - ���캯��

CsdsdPropPage::CsdsdPropPage() :
	COlePropertyPage(IDD, IDS_SDSD_PPG_CAPTION)
{
}



// CsdsdPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CsdsdPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CsdsdPropPage ��Ϣ�������
