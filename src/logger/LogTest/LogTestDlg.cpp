// LogTestDlg.cpp : 实现文件
//

#include "stdafx.h"
#include "LogTest.h"
#include "LogTestDlg.h"
#include "../../include/LogClient.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CLogTestDlg 对话框

CLogTestDlg::CLogTestDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CLogTestDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CLogTestDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CLogTestDlg, CDialog)
#if defined(_DEVICE_RESOLUTION_AWARE) && !defined(WIN32_PLATFORM_WFSP)
	ON_WM_SIZE()
#endif
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_BN_Hello, &CLogTestDlg::OnBnClickedBnHello)
	ON_BN_CLICKED(IDC_BN_Send, &CLogTestDlg::OnBnClickedBnSend)
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BN_SENDM, &CLogTestDlg::OnBnClickedBnSendm)
	ON_BN_CLICKED(IDC_BN_BeginAuto, &CLogTestDlg::OnBnClickedBnBeginauto)
	ON_BN_CLICKED(IDC_BN_EndAuto, &CLogTestDlg::OnBnClickedBnEndauto)
	ON_WM_TIMER()
END_MESSAGE_MAP()


// CLogTestDlg 消息处理程序

BOOL CLogTestDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// 设置此对话框的图标。当应用程序主窗口不是对话框时，框架将自动
	//  执行此操作
	SetIcon(m_hIcon, TRUE);			// 设置大图标
	SetIcon(m_hIcon, FALSE);		// 设置小图标

	// TODO: 在此添加额外的初始化代码
	//InitLogger();
	
	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE
}

#if defined(_DEVICE_RESOLUTION_AWARE) && !defined(WIN32_PLATFORM_WFSP)
void CLogTestDlg::OnSize(UINT /*nType*/, int /*cx*/, int /*cy*/)
{
	if (AfxIsDRAEnabled())
	{
		DRA::RelayoutDialog(
			AfxGetResourceHandle(), 
			this->m_hWnd, 
			DRA::GetDisplayMode() != DRA::Portrait ? 
			MAKEINTRESOURCE(IDD_LOGTEST_DIALOG_WIDE) : 
			MAKEINTRESOURCE(IDD_LOGTEST_DIALOG));
	}
}
#endif


void CLogTestDlg::OnBnClickedBnHello()
{
	// TODO: 在此添加控件通知处理程序代码
	//Log(100, 100, L"Hello Msg for Log");
	//LogS( 100, 100, 100, L"Hello Msg for Log");
	LogS(LID_SYS_DEBUG_INFO, LogType::Info, "Unit", "Message");
}

void CLogTestDlg::OnBnClickedBnSend()
{
	// TODO: 在此添加控件通知处理程序代码
	CString strMsg;
	GetDlgItemText(IDC_EDIT_LOG, strMsg);
	//LogS(200, 150, 234, (TCHAR*)(LPCTSTR)strMsg);
	USES_CONVERSION;
	char* msg = T2A(strMsg);
	LogS(LID_SYS_DEBUG_INFO, LogType::Info, "Unit", msg);
}

void CLogTestDlg::OnDestroy()
{
	CDialog::OnDestroy();

	// TODO: 在此处添加消息处理程序代码
	//EndLogger();
}

void CLogTestDlg::OnBnClickedBnSendm()
{
	// TODO: 在此添加控件通知处理程序代码
	for (int i=0; i<5000; i++)
	{
		OnBnClickedBnSend();
	}
}

void CLogTestDlg::OnBnClickedBnBeginauto()
{
	// TODO: 在此添加控件通知处理程序代码
	SetTimer(100, 200, NULL);
}

void CLogTestDlg::OnBnClickedBnEndauto()
{
	// TODO: 在此添加控件通知处理程序代码
	KillTimer(100);
}

void CLogTestDlg::OnTimer(UINT_PTR nIDEvent)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
	//OnBnClickedBnSend();
	LogRandMsg();

	CDialog::OnTimer(nIDEvent);
}

void CLogTestDlg::LogRandMsg(void)
{
	CString strRand = _T("");
	
	int nLen = 0;
	nLen = GetRandNum(36, 1024);
	char ch = 0;
	for (int i=0; i<nLen; i++)
	{
		ch = GetRandNum(33, 126);
		strRand += ch;
	}
	int nID = GetRandNum(1, 400);
	int nType = GetRandNum(1, 4);
	if(nID > 300)
	{
		nType = LogType::Error;
	}
	USES_CONVERSION;
	LogS(nID, nType, "Unit", T2A(strRand));
}

int CLogTestDlg::GetRandNum(int nMax, int nMin)
{
	/*SYSTEMTIME time;
	GetLocalTime(&time);
	srand(
		GetTickCount() 
		);

	int nRand = 0;
	nRand = rand();

	int nAscii = 0;
	return 0;*/

	UINT nRand = 0;
	rand_s(&nRand);

	int rand100 = (int)(((double) nRand/ (double) UINT_MAX  ) 
		* (double)(nMax-nMin) + (double)nMin);

	return rand100;
}
