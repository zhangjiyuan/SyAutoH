// LogExpDlg.h : 头文件
//

#pragma once

#include "../LogServer/LogServer.h"
#include "afxwin.h"
// CLogExpDlg 对话框
class CLogExpDlg : public CDialog
{
// 构造
public:
	CLogExpDlg(CWnd* pParent = NULL);	// 标准构造函数

// 对话框数据
	enum { IDD = IDD_LOGEXP_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 支持


// 实现
protected:
	HICON m_hIcon;

	// 生成的消息映射函数
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg LRESULT OnLog(WPARAM, LPARAM);
	DECLARE_MESSAGE_MAP()

protected:
	CLogServer m_server;
public:
	afx_msg void OnDestroy();
	CEdit _edit;
};
