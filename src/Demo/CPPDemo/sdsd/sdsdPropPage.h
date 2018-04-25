#pragma once

// sdsdPropPage.h : CsdsdPropPage 属性页类的声明。


// CsdsdPropPage : 有关实现的信息，请参阅 sdsdPropPage.cpp。

class CsdsdPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CsdsdPropPage)
	DECLARE_OLECREATE_EX(CsdsdPropPage)

// 构造函数
public:
	CsdsdPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_SDSD };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

