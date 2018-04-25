#pragma once

// sdsdCtrl.h : CsdsdCtrl ActiveX 控件类的声明。


// CsdsdCtrl : 有关实现的信息，请参阅 sdsdCtrl.cpp。

class CsdsdCtrl : public COleControl
{
	DECLARE_DYNCREATE(CsdsdCtrl)

// 构造函数
public:
	CsdsdCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();

// 实现
protected:
	~CsdsdCtrl();

	DECLARE_OLECREATE_EX(CsdsdCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CsdsdCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CsdsdCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CsdsdCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

	afx_msg void AboutBox();

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
	};
};

