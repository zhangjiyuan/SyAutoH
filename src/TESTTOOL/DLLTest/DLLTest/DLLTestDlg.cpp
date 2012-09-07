
// DLLTestDlg.cpp : 实现文件
//

#include "stdafx.h"
#include "DLLTest.h"
#include "DLLTestDlg.h"
#include "afxdialogex.h"
#include <iostream>
#include "string.h"
using namespace std;

#ifdef _DEBUG
#define new DEBUG_NEW
#endif



// 用于应用程序“关于”菜单项的 CAboutDlg 对话框

class CAboutDlg : public CDialogEx
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

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CDLLTestDlg 对话框




CDLLTestDlg::CDLLTestDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CDLLTestDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CDLLTestDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_EDIT1, m_input);
	DDX_Control(pDX, IDC_EDIT2, m_output);
	DDX_Control(pDX, IDC_EDIT3, m_name);
	DDX_Control(pDX, IDC_EDIT5, m_passWord);
	DDX_Control(pDX, IDC_EDIT4, m_high);
	DDX_Control(pDX, IDC_EDIT6, m_low);
	DDX_Control(pDX, IDC_EDIT7, m_outInfo);
}

BEGIN_MESSAGE_MAP(CDLLTestDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON1, &CDLLTestDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CDLLTestDlg::OnBnClickedButton2)
END_MESSAGE_MAP()


// CDLLTestDlg 消息处理程序

BOOL CDLLTestDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// 将“关于...”菜单项添加到系统菜单中。

	// IDM_ABOUTBOX 必须在系统命令范围内。
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
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

	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE
}

void CDLLTestDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// 如果向对话框添加最小化按钮，则需要下面的代码
//  来绘制该图标。对于使用文档/视图模型的 MFC 应用程序，
//  这将由框架自动完成。

void CDLLTestDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 用于绘制的设备上下文

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 使图标在工作区矩形中居中
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
		CDialogEx::OnPaint();
	}
}

//当用户拖动最小化窗口时系统调用此函数取得光标
//显示。
HCURSOR CDLLTestDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CDLLTestDlg::OnBnClickedButton1()
{
	// TODO: 在此添加控件通知处理程序代码
	m_output.Clear();
	CString input;
	string outdll;
	string indll;
	CString output;
	m_input.GetWindowText(input);
	indll = input.GetBuffer(input.GetLength());
	HMODULE hm;
	hm = LoadLibrary(_T("sha1transform.dll"));
	if(hm == NULL)
	{
		AfxMessageBox(_T("导入失败"));
	}
	typedef string(*transform)(string);
	transform pfn = (transform) GetProcAddress(hm,"SHA1Transform");
	if(pfn == NULL)
	{
		AfxMessageBox(_T("获得地址失败"));
	}
	outdll = pfn(indll);
	output = outdll.c_str();
	m_output.SetWindowText(output);	
	FreeLibrary(hm);
}


void CDLLTestDlg::OnBnClickedButton2()
{
	// TODO: 在此添加控件通知处理程序代码
	m_outInfo.Clear();
	CString name;
	CString passWord;
	CString high;
	CString low;
	m_name.GetWindowText(name);
	m_passWord.GetWindowText(passWord);
	m_high.GetWindowText(high);
	m_low.GetWindowText(low);
	string namestr = name.GetBuffer(sizeof(name));
	string passWordstr = passWord.GetBuffer(sizeof(passWord));
	string highstr = high.GetBuffer(sizeof(high));
	string lowstr = low.GetBuffer(sizeof(low));
	HMODULE hm = LoadLibrary("sha1transform");
	typedef string(*info)(string&,string&,string&,string&);
	info pfn = (info)GetProcAddress(hm,"HashLoginInfo");
	string loginInfo;
	loginInfo = pfn(namestr,highstr,lowstr,passWordstr);
	CString out;
	out = loginInfo.c_str();
	m_outInfo.SetWindowText(out);
	FreeLibrary(hm);
}
