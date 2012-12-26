// LogClientWinTestDlg.h : 头文件
//

#pragma once
#include <afxtempl.h>

// CLogClientWinTestDlg 对话框
class CLogClientWinTestDlg : public CDialog
{
// 构造
public:
	CLogClientWinTestDlg(CWnd* pParent = NULL);	// 标准构造函数

// 对话框数据
	enum { IDD = IDD_LOGCLIENTWINTEST_DIALOG };

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
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedBnDefmsg();
	afx_msg void OnBnClickedBnSend();
	afx_msg void OnBnClickedBnSend1k();
	afx_msg void OnBnClickedBnAutobegin();
	afx_msg void OnBnClickedBnEndAuto();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnDestroy();

protected:
	CWinThread* m_pThread;
	static UINT __SendLog(LPVOID lp);
	CList<CWinThread*, CWinThread*> m_listThread;
	int m_nThreadID;
	
public:
	void AddThread(void);
	void CleanThreadAll(void);

	void DrawThreadCount(void);
	afx_msg void OnBnClickedBnAlmcount();
};
