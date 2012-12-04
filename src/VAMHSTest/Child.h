#pragma once
#include "afxcmn.h"
#include "afxwin.h"
#include "CMarkup.h"
// Child 对话框

class Child : public CDialogEx
{
	DECLARE_DYNAMIC(Child)

public:
	Child(CWnd* pParent = NULL);   // 标准构造函数
	virtual ~Child();

// 对话框数据
	enum { IDD = IDD_DIALOG1 };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL OnInitDialog();
	void InitList();
	void ReadXML();
	void SaveXML(CString nID,CString nPos,CString nType,CString nSpeed);
	void InitComBox();
	void DeleteXMLElem(CString ID,CString pos);
	CStringW GetXMLPath();
	CListCtrl m_TeachPos_List;
	CComboBox m_TeachPosType;

	CEdit m_ID;
	CEdit m_POS;
	CEdit m_Speed;
	afx_msg void OnBnClickedCreateButton();
	afx_msg void OnBnClickedDeleteButton();
	afx_msg void OnBnClickedButton1();
};
