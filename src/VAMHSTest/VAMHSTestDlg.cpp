
// VAMHSTestDlg.cpp : 实现文件
//

#include "stdafx.h"
#include "VAMHSTest.h"
#include "VAMHSTestDlg.h"
#include "afxdialogex.h"
#include "../VirtualAMHS/VirtualAMHS.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

CVirtualAMHS* pVirualAMHSDevice = NULL;
MAP_ItemOHT g_mapOHTs;
const int StockerID = 24;

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


// CVAMHSTestDlg 对话框



CVAMHSTestDlg::CVAMHSTestDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CVAMHSTestDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CVAMHSTestDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LIST_OHT, m_listCtrlOHT);
	DDX_Control(pDX, IDC_LIST_FOUP, m_listCtrlFOUP);
}

BEGIN_MESSAGE_MAP(CVAMHSTestDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BN_AddOHT, &CVAMHSTestDlg::OnBnClickedBnOHTonline)
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BN_AddSTK, &CVAMHSTestDlg::OnBnClickedBnAddstk)
	ON_BN_CLICKED(IDC_BN_STK_IN, &CVAMHSTestDlg::OnBnClickedBnStkIn)
	ON_BN_CLICKED(IDC_BN_STK_OUT, &CVAMHSTestDlg::OnBnClickedBnStkOut)
	ON_BN_CLICKED(IDC_BN_OHT_Add, &CVAMHSTestDlg::OnBnClickedBnOhtAdd)
	ON_BN_CLICKED(IDC_BN_SetHand, &CVAMHSTestDlg::OnBnClickedBnSethand)
	ON_BN_CLICKED(IDC_BN_SetPos, &CVAMHSTestDlg::OnBnClickedBnSetpos)
END_MESSAGE_MAP()


// CVAMHSTestDlg 消息处理程序

BOOL CVAMHSTestDlg::OnInitDialog()
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
	InitListCtrlOHT();
	InitListCtrlFOUP();
	AllocConsole();                     // 打开控制台资源
	FILE* file;
	freopen_s( &file, "CONOUT$", "w+t", stdout);// 申请写

	pVirualAMHSDevice = new CVirtualAMHS();

	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE
}

void CVAMHSTestDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CVAMHSTestDlg::OnPaint()
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
HCURSOR CVAMHSTestDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CVAMHSTestDlg::OnBnClickedBnOHTonline()
{
	int nItem = m_listCtrlOHT.GetNextItem(-1, LVNI_ALL | LVNI_SELECTED);
	int nOHT_ID = m_listCtrlOHT.GetItemData(nItem);
	int nAdd = pVirualAMHSDevice->AddOHT(nOHT_ID);
}


void CVAMHSTestDlg::OnDestroy()
{
	CDialogEx::OnDestroy();

	// TODO: 在此处添加消息处理程序代码
	if (pVirualAMHSDevice != NULL)
	{
		delete pVirualAMHSDevice;
		pVirualAMHSDevice = NULL;
	}
	FreeConsole();                      // 释放控制台资源

	MAP_ItemOHT::iterator it;
	it = g_mapOHTs.begin();
	while(it != g_mapOHTs.end())
	{
		delete it->second;
		++it;
	}
	g_mapOHTs.clear();
}


void CVAMHSTestDlg::OnBnClickedBnAddstk()
{
	pVirualAMHSDevice->AddStocker(StockerID, "192.168.55.10");
}


void CVAMHSTestDlg::OnBnClickedBnStkIn()
{
	CString strFoup;
	GetDlgItemText(IDC_EDIT_STK_FOUP, strFoup);
	pVirualAMHSDevice->ManualInputFoup(StockerID, strFoup);
}


void CVAMHSTestDlg::OnBnClickedBnStkOut()
{
	CString strFoup;
	GetDlgItemText(IDC_EDIT_STK_FOUP, strFoup);
	pVirualAMHSDevice->ManualOutputFoup(StockerID, strFoup);

}


void CVAMHSTestDlg::OnBnClickedBnOhtAdd()
{
	int nOHT_ID = GetDlgItemInt(IDC_EDIT_OHTID);
	if (nOHT_ID >= 0 && nOHT_ID < 254)
	{
		MAP_ItemOHT::iterator it = g_mapOHTs.find(nOHT_ID);
		MAP_ItemOHT::iterator itEnd = g_mapOHTs.end();
		if (it != g_mapOHTs.end())
		{
			MessageBox(_T("OHT己存在!"));
		}
		else
		{
			// add
			ItemOHT* pOht = new ItemOHT;
			g_mapOHTs.insert(std::make_pair(nOHT_ID, pOht));
			pOht->nID = nOHT_ID;
			pOht->nPosition = 0;
			pOht->nHandStatus = 0;

			CString str;
			str.Format(_T("%d"), nOHT_ID);
			m_listCtrlOHT.InsertItem(0, str);
			str.Format(_T("%d"), pOht->nPosition);
			m_listCtrlOHT.SetItemText(0, 1, str);
			str.Format(_T("%d"), pOht->nHandStatus);
			m_listCtrlOHT.SetItemText(0, 2, str);
			//str.Format(_T("%d"), pOht->nHandStatus);
			m_listCtrlOHT.SetItemText(0, 3, _T("Idle"));
			m_listCtrlOHT.SetItemText(0, 4, _T("Off"));
			m_listCtrlOHT.SetItemData(0, nOHT_ID);
		}
	}
	else
	{
		MessageBox(_T("不合理的OHT ID值, 应在0至253之间."));
	}
}


void CVAMHSTestDlg::OnBnClickedBnSethand()
{
	// TODO: 在此添加控件通知处理程序代码
}


void CVAMHSTestDlg::OnBnClickedBnSetpos()
{
	// TODO: 在此添加控件通知处理程序代码
}


void CVAMHSTestDlg::InitListCtrlOHT(void)
{
	DWORD dwStyle;
	dwStyle = m_listCtrlOHT.GetStyle();  //取得样式
	dwStyle =    LVS_EX_GRIDLINES | LVS_EX_FULLROWSELECT ;   //添加样式
	m_listCtrlOHT.SetExtendedStyle(dwStyle);     //重新设置

	m_listCtrlOHT.InsertColumn(0, _T("ID"), LVCFMT_CENTER, 30);
	m_listCtrlOHT.InsertColumn(1, _T("POS"), LVCFMT_CENTER, 80);
	m_listCtrlOHT.InsertColumn(2, _T("HAND"), LVCFMT_CENTER, 50);
	m_listCtrlOHT.InsertColumn(3, _T("Status"), LVCFMT_CENTER, 50);
	m_listCtrlOHT.InsertColumn(4, _T("Online"), LVCFMT_CENTER, 50);
}


void CVAMHSTestDlg::InitListCtrlFOUP(void)
{
	DWORD dwStyle;
	dwStyle = m_listCtrlFOUP.GetStyle();  //取得样式
	dwStyle =    LVS_EX_GRIDLINES | LVS_EX_FULLROWSELECT ;   //添加样式
	m_listCtrlFOUP.SetExtendedStyle(dwStyle);     //重新设置

	m_listCtrlFOUP.InsertColumn(0, _T("ID"), LVCFMT_CENTER, 100);
	m_listCtrlFOUP.InsertColumn(1, _T("Location"), LVCFMT_CENTER, 80);
	m_listCtrlFOUP.InsertColumn(2, _T("Status"), LVCFMT_CENTER, 50);

}
