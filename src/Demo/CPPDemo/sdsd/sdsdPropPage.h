#pragma once

// sdsdPropPage.h : CsdsdPropPage ����ҳ���������


// CsdsdPropPage : �й�ʵ�ֵ���Ϣ������� sdsdPropPage.cpp��

class CsdsdPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CsdsdPropPage)
	DECLARE_OLECREATE_EX(CsdsdPropPage)

// ���캯��
public:
	CsdsdPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_SDSD };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

