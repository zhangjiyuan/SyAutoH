// LogClientWinTestDlg.cpp : 实现文件
//

#include "stdafx.h"
#include "LogClientWinTest.h"
#include "LogClientWinTestDlg.h"
#include "../../include/LogClient.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define   _CRT_RAND_S   
#include   <stdlib.h>   

#if   defined(_CRT_RAND_S)   
extern"C"   
{   
	_CRTIMP   errno_t   __cdecl   rand_s   (   __out   unsigned   int   *_RandomValue);   
}   
#endif  

int GetRandNum(int nMax, int nMin)
{
	UINT nRand = 0;
	rand_s(&nRand);

	int rand100 = (int)(((double) nRand/ (double) UINT_MAX  ) 
		* (double)(nMax-nMin) + (double)nMin);

	return rand100;
}

CString  LogRandMsg(CString strHead = _T(""))
{
	CString strRand = _T("AutoSend Test: ");
	strRand = strHead + strRand;

	int nLen = 0;
	nLen = GetRandNum(3, 72);
	char ch = 0;
	for (int i=0; i<nLen; i++)
	{
		ch = GetRandNum(33, 126);
		strRand += ch;
	}

	int nType = GetRandNum(1, 4);
	int nID = 0;
	
	if (LogType::Error == nType)
	{
		nID = GetRandNum(300, 350);
	}
	else
	{
		nID = GetRandNum(1, 300);
	}
	USES_CONVERSION;
	LogS(nID, nType, "Unit", T2A(strRand));

	return strRand;
}
// 用于应用程序“关于”菜单项的 CAboutDlg 对话框

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// 对话框数据
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 实现
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


// CLogClientWinTestDlg 对话框




CLogClientWinTestDlg::CLogClientWinTestDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CLogClientWinTestDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	m_pThread = NULL;
	m_nThreadID = 0;
}

void CLogClientWinTestDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CLogClientWinTestDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_BN_DEFMSG, &CLogClientWinTestDlg::OnBnClickedBnDefmsg)
	ON_BN_CLICKED(IDC_BN_SEND, &CLogClientWinTestDlg::OnBnClickedBnSend)
	ON_BN_CLICKED(IDC_BN_SEND1K, &CLogClientWinTestDlg::OnBnClickedBnSend1k)
	ON_BN_CLICKED(IDC_BN_AUTOBEGIN, &CLogClientWinTestDlg::OnBnClickedBnAutobegin)
	ON_BN_CLICKED(IDC_BN_End_Auto, &CLogClientWinTestDlg::OnBnClickedBnEndAuto)
	ON_WM_TIMER()
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BN_ALMCOUNT, &CLogClientWinTestDlg::OnBnClickedBnAlmcount)
END_MESSAGE_MAP()


// CLogClientWinTestDlg 消息处理程序

BOOL CLogClientWinTestDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// 将“关于...”菜单项添加到系统菜单中。

	// IDM_ABOUTBOX 必须在系统命令范围内。
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// 设置此对话框的图标。当应用程序主窗口不是对话框时，框架将自动
	//  执行此操作
	SetIcon(m_hIcon, TRUE);			// 设置大图标
	SetIcon(m_hIcon, FALSE);		// 设置小图标

	// TODO: 在此添加额外的初始化代码
	//InitLogger();
	DrawThreadCount();

	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE
}

void CLogClientWinTestDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// 如果向对话框添加最小化按钮，则需要下面的代码
//  来绘制该图标。对于使用文档/视图模型的 MFC 应用程序，
//  这将由框架自动完成。

void CLogClientWinTestDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 用于绘制的设备上下文

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 使图标在工作矩形中居中
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 绘制图标
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

//当用户拖动最小化窗口时系统调用此函数取得光标显示。
//
HCURSOR CLogClientWinTestDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CLogClientWinTestDlg::OnBnClickedBnDefmsg()
{
	LogS(102, LogType::Warrning, "Unit", "Hello Message");
}

void CLogClientWinTestDlg::OnBnClickedBnSend()
{
	CString str;
	CString strMsg;
	GetDlgItemText(IDC_EDIT_MSG, strMsg);
	//LogS(200, 150, 234, (TCHAR*)(LPCTSTR)strMsg);
	USES_CONVERSION;
	GetDlgItemText(IDC_EDIT_EID, str);
	int nEID = _wtoi(str);
	GetDlgItemText(IDC_EDIT_TYPE, str);
	int nType = _wtoi(str);
	
	LogS(nEID, nType, "Unit", T2A(strMsg));
	LogS(LID_SYS_DEBUG_INFO, LogType::Warrning, SYS_MODULE, "stand message");
}

void CLogClientWinTestDlg::OnBnClickedBnSend1k()
{
	for (int i=0; i<1000; i++)
	{
		OnBnClickedBnSend();
	}
}

void CLogClientWinTestDlg::OnBnClickedBnAutobegin()
{
	SetTimer(100, 50, NULL);
	AddThread();
	DrawThreadCount();
}

void CLogClientWinTestDlg::OnBnClickedBnEndAuto()
{
	KillTimer(100);
	CleanThreadAll();
	m_nThreadID = 0;
	DrawThreadCount();
}

void CLogClientWinTestDlg::OnTimer(UINT_PTR nIDEvent)
{
	for (int i=0; i<1; i++)
	{
		CString str = LogRandMsg(_T("Timer "));
		SetDlgItemText(IDC_EDIT_MSG, str);
	}
	

	CDialog::OnTimer(nIDEvent);
}



void CLogClientWinTestDlg::OnDestroy()
{
	CDialog::OnDestroy();

	// TODO: 在此处添加消息处理程序代码
	//EndLogger();
}

UINT CLogClientWinTestDlg::__SendLog(LPVOID lp)
{
	int *nID = (int*)lp;
	CString strNum = _T("");
	strNum.Format(_T("Thread: %d "), *nID);
	while(1)
	{
		LogRandMsg(strNum);
		int nSleep = GetRandNum(10, 100);
		Sleep(nSleep);
	}
	return 0;
}

void CLogClientWinTestDlg::AddThread(void)
{
	m_nThreadID++;
	CWinThread* pThread = AfxBeginThread(__SendLog, (LPVOID)&m_nThreadID);
	m_listThread.AddTail(pThread);
}

void CLogClientWinTestDlg::CleanThreadAll(void)
{
	while(!m_listThread.IsEmpty())
	{
		CWinThread* pThread = m_listThread.RemoveHead();
		pThread->SuspendThread();
		delete pThread;
	}
}

void CLogClientWinTestDlg::DrawThreadCount(void)
{
	INT_PTR nCount = m_listThread.GetCount();
	CString str = _T("");
	str.Format(_T("Thread Count: %d"), nCount);
	SetDlgItemText(IDC_TX_COUNT, str);
}

void CLogClientWinTestDlg::OnBnClickedBnAlmcount()
{
	int nAlmCount = 0;
	nAlmCount = GetAlarmCount();
	int nLastType = GetLastType();
	CString str = _T("");
	if (nAlmCount < 0)
	{
		str = "未连接到服务器";
	}
	else
	{
		str.Format(_T("Alarm: %d LastType: %d"), nAlmCount, nLastType);
	}

	SetDlgItemText(IDC_ALMSTU, str);
}
