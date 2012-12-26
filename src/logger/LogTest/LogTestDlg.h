// LogTestDlg.h : 头文件
//

#pragma once

// CLogTestDlg 对话框
class CLogTestDlg : public CDialog
{
// 构造
public:
	CLogTestDlg(CWnd* pParent = NULL);	// 标准构造函数

// 对话框数据
	enum { IDD = IDD_LOGTEST_DIALOG };


	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 支持

// 实现
protected:
	HICON m_hIcon;

	// 生成的消息映射函数
	virtual BOOL OnInitDialog();
#if defined(_DEVICE_RESOLUTION_AWARE) && !defined(WIN32_PLATFORM_WFSP)
	afx_msg void OnSize(UINT /*nType*/, int /*cx*/, int /*cy*/);
#endif
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedBnHello();
	afx_msg void OnBnClickedBnSend();
	afx_msg void OnDestroy();
	afx_msg void OnBnClickedBnSendm();
	afx_msg void OnBnClickedBnBeginauto();
	afx_msg void OnBnClickedBnEndauto();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	void LogRandMsg(void);
	int GetRandNum(int nMax, int nMin);
};
