#pragma once

// sdsdCtrl.h : CsdsdCtrl ActiveX �ؼ����������


// CsdsdCtrl : �й�ʵ�ֵ���Ϣ������� sdsdCtrl.cpp��

class CsdsdCtrl : public COleControl
{
	DECLARE_DYNCREATE(CsdsdCtrl)

// ���캯��
public:
	CsdsdCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();

// ʵ��
protected:
	~CsdsdCtrl();

	DECLARE_OLECREATE_EX(CsdsdCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CsdsdCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CsdsdCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CsdsdCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

	afx_msg void AboutBox();

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
	};
};

