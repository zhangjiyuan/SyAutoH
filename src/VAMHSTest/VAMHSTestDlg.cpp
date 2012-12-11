

// VAMHSTestDlg.cpp : 实现文件
//

#include "stdafx.h"
#include "VAMHSTest.h"
#include "VAMHSTestDlg.h"
#include "afxdialogex.h"
#include "../VirtualAMHS/VirtualAMHS.h"
#include "CMarkup.h"
#include <iostream>
#include "DlgAddOht.h"
using namespace std;
#ifdef _DEBUG
#define new DEBUG_NEW
#endif

CVirtualAMHS* g_pVDev = NULL;
MAP_ItemOHT g_mapOHTs;
const int STOCKER_ID = 24;

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

CVAMHSTestDlg::~CVAMHSTestDlg()
{
	MAP_ItemOHT::iterator it;
	for(it = g_mapOHTs.begin();it != g_mapOHTs.end();it++)
	{
		it->second->nOnline = 0;
	}
	SaveXML();
	it = g_mapOHTs.begin();
	while(it != g_mapOHTs.end())
	{
		delete it->second;
		++it;
	}
	g_mapOHTs.clear();
}

void CVAMHSTestDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LIST_OHT, m_listCtrlOHT);
	DDX_Control(pDX, IDC_LIST_FOUP, m_listCtrlFOUP);
	DDX_Control(pDX, IDC_COMBO_OHT_TeachPOSType, m_cbOhtTeachType);
	DDX_Control(pDX, IDC_EDIT1, m_ConstSpeed);
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
	ON_BN_CLICKED(IDC_BN_SetPos, &CVAMHSTestDlg::OnBnClickedBnTeachPos)
	ON_WM_TIMER()
	ON_BN_CLICKED(IDC_BN_STK_HISTORY, &CVAMHSTestDlg::OnBnClickedBnStkHistory)
	ON_BN_CLICKED(IDC_BN_OHT_OFF, &CVAMHSTestDlg::OnBnClickedBnOhtOff)
	ON_BN_CLICKED(IDC_TeachPOS_Edit, &CVAMHSTestDlg::OnBnClickedTeachposEdit)
	ON_BN_CLICKED(IDC_OHT_DEL, &CVAMHSTestDlg::OnBnClickedOhtDel)
	ON_BN_CLICKED(IDC_SENDALL_BUTTON, &CVAMHSTestDlg::OnBnClickedSendallButton)
	ON_BN_CLICKED(IDC_ASK_FOR_PATH, &CVAMHSTestDlg::OnBnClickedAskForPath)
	ON_BN_CLICKED(IDC_SPEED_SET_BUTTON, &CVAMHSTestDlg::OnBnClickedSpeedSetButton)
	ON_BN_CLICKED(IDC_BN_ALLOHTOnLine, &CVAMHSTestDlg::OnBnClickedBnAllohtonline)
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
	g_pVDev = new CVirtualAMHS();
	SetTimer(100, 500, NULL);

	m_cbOhtTeachType.AddString(L"0x01 直道位置点");
	m_cbOhtTeachType.AddString(L"0x02 弯道位置点");
	m_cbOhtTeachType.AddString(L"0x04 道岔位置点");
	m_cbOhtTeachType.AddString(L"0x08 减速点");
	m_cbOhtTeachType.AddString(L"0x10 停止点");
	m_cbOhtTeachType.AddString(L"0x20 取放点");


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
	int nOHT_ID = GetSelectOhtID();
	int nPosTime;
	int nPosition;
	int nStatusTime;
	int nHand;
	CMarkup XML;
	CString path;
	path = GetPath();
	path += "../Config/OHTandTeachPos.xml";
	XML.Load(path);
	XML.FindElem();
	XML.FindChildElem(_T("OHTList"));
	XML.IntoElem();
	while(XML.FindChildElem(_T("OHT")))
	{
		XML.IntoElem();
		int nID = GetElemData(XML,_T("ID"));
		if(nID == nOHT_ID)
		{
			nPosition = GetElemData(XML,_T("POS"));
			nHand = GetElemData(XML,_T("HAND"));
			nPosTime = GetElemData(XML,_T("PosTime"));
			nStatusTime = GetElemData(XML,_T("StatusTime"));
		}
		XML.OutOfElem();
	}
	XML.OutOfElem();
	if (nOHT_ID >= 0)
	{
		int nAdd = g_pVDev->OHT_Auth(nOHT_ID,nPosition,nHand);
		int nInit = g_pVDev->OHT_Init(nOHT_ID,nPosTime,nStatusTime);
	}
}


void CVAMHSTestDlg::OnDestroy()
{
	CDialogEx::OnDestroy();

	// TODO: 在此处添加消息处理程序代码
	//SaveXML();

	if (g_pVDev != NULL)
	{
		delete g_pVDev;
		g_pVDev = NULL;
	}
	FreeConsole();                      // 释放控制台资源
}


void CVAMHSTestDlg::OnBnClickedBnAddstk()
{
	g_pVDev->Stocker_Auth(STOCKER_ID, "192.168.55.10");
}

void CVAMHSTestDlg::OnBnClickedBnStkIn()
{
	CString strFoup;
	GetDlgItemText(IDC_EDIT_STK_FOUP, strFoup);
	g_pVDev->Stocker_ManualInputFoup(STOCKER_ID, strFoup);
}


void CVAMHSTestDlg::OnBnClickedBnStkOut()
{
	CString strFoup;
	GetDlgItemText(IDC_EDIT_STK_FOUP, strFoup);
	g_pVDev->Stocker_ManualOutputFoup(STOCKER_ID, strFoup);
}
int CVAMHSTestDlg::GetElemData(CMarkup xml,CString tag)
{
	xml.FindChildElem(tag);
	xml.IntoElem();
	CString data = xml.GetData();
	int value = _ttoi(data);
	xml.OutOfElem();
	return value;
}
void CVAMHSTestDlg::SaveXML()
{
	CStringW filePath = GetPath();
	filePath += "../Config/OHTandTeachPos.xml";
	CMarkup XML;
	XML.Load(filePath);
	MAP_ItemOHT::iterator it;
	for(it = g_mapOHTs.begin();it != g_mapOHTs.end();it++)
	{
		int nPosTime;
		int nStatusTime;
		int nID = it->second->nID;
		bool contain = false;
		XML.ResetMainPos();
	    XML.FindElem();
	    XML.FindChildElem(_T("OHTList"));
	    XML.IntoElem();
		while(XML.FindChildElem(_T("OHT")))
		{
			XML.FindChildElem(_T("ID"));
			XML.IntoElem();
			int xID = GetElemData(XML,_T("ID"));
			XML.OutOfElem();
			if(xID == nID)
			{
				contain = true;
				XML.FindChildElem(_T("PosTime"));
				XML.IntoElem();
				CString CPosTime = XML.GetData();
				nPosTime = _ttoi(CPosTime);
				XML.OutOfElem();
				XML.FindChildElem(_T("StatusTime"));
				XML.IntoElem();
				CString CStatusTime;
				CStatusTime = XML.GetData();
				nStatusTime = _ttoi(CStatusTime);
				XML.OutOfElem();
				XML.RemoveChildElem();
				XML.AddChildElem(_T("OHT"));
				XML.IntoElem();
				XML.AddChildElem(_T("ID"),xID);
				XML.AddChildElem(_T("POS"),it->second->nPosition);
				XML.AddChildElem(_T("HAND"),it->second->nHandStatus);
				XML.AddChildElem(_T("Online"),it->second->nOnline);
		        if(it->second->nPosTime > 0)
			    {
					XML.AddChildElem(_T("PosTime"),it->second->nPosTime);
			    }
				else if(nPosTime <= 0)
					XML.AddChildElem(_T("PosTime"),nPosTime);
			    if(it->second->nStatusTime > 0)
			    {
					XML.AddChildElem(_T("StatusTime"),it->second->nStatusTime);
			    }
				else if(nStatusTime <= 0)
				{
					XML.AddChildElem(_T("StatusTime"),nStatusTime);
				}
				XML.OutOfElem();
				XML.OutOfElem();
			}
		}
		if(!contain)
		{
			XML.AddChildElem(_T("OHT"));
			XML.IntoElem();
			XML.AddChildElem(_T("ID"),it->second->nID);
			XML.AddChildElem(_T("POS"),it->second->nPosition);
			XML.AddChildElem(_T("HAND"),it->second->nHandStatus);
			XML.AddChildElem(_T("Online"),it->second->nOnline);
			if(it->second->nPosTime > 0)
				XML.AddChildElem(_T("PosTime"),it->second->nPosTime);
			else
				XML.AddChildElem(_T("PosTime"),0);
			if(it->second->nStatusTime > 0)
				XML.AddChildElem(_T("StatusTime"),it->second->nStatusTime);
			else
				XML.AddChildElem(_T("StatusTime"),0);
			XML.OutOfElem();
			XML.OutOfElem();
		}
	}
	XML.OutOfElem();
	XML.Save(filePath);
}
void CVAMHSTestDlg::ReadXML()
{
	CStringW filePath = GetPath();
	filePath += "../Config/OHTandTeachPos.xml";
	CMarkup XML;
	if(!XML.Load(filePath))
	{
		XML.SetDoc(_T("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n")); 
		XML.AddElem(_T("OHTandTeachPosList"));
		XML.IntoElem();
		XML.AddElem(_T("OHTList"));
		XML.AddElem(_T("TeachPosList"));
		XML.Save(filePath);
		return ;
	}
	int item = 0;
	XML.ResetMainPos();
	XML.FindElem();
	XML.FindChildElem(_T("OHTList"));
	XML.IntoElem();
	while(XML.FindChildElem(_T("OHT")))
	{
		XML.IntoElem();  //into OHT
		ItemOHT* pOht = new ItemOHT;
		int ID = GetElemData(XML,_T("ID"));
		int POS = GetElemData(XML,_T("POS"));
		int HAND = GetElemData(XML,_T("HAND"));
		int Online = GetElemData(XML,_T("Online"));
		int posTime = GetElemData(XML,_T("PosTime"));
		int statusTime = GetElemData(XML,_T("StatusTime"));
		pOht->nHandStatus = HAND;
		pOht->nID = ID;
		pOht->nOnline = Online;
		pOht->nPosition = POS;
		pOht->nPosTime = posTime;
		pOht->nStatusTime = statusTime;
		g_mapOHTs.insert(std::make_pair(ID, pOht));
		CString str;
		m_listCtrlOHT.InsertItem(0, str);
		SetOHTListItemData(pOht, 0);
		XML.OutOfElem();
	}
	XML.OutOfElem();
}
void CVAMHSTestDlg::DeleteElem(int nID)
{
	CMarkup XML;
	CString path;
	path = GetPath();
	path += "../Config/OHTandTeachPos.xml";
	XML.Load(path);
	XML.FindElem();
	XML.FindChildElem(_T("OHTList"));
	XML.IntoElem();
	while(XML.FindChildElem(_T("OHT")))
	{
		XML.IntoElem();
		int xID = GetElemData(XML,_T("ID"));
		if(xID == nID)
		{
			XML.OutOfElem();
			XML.RemoveChildElem();
		}
		XML.OutOfElem();
	}
	XML.Save(path);
}
CStringW CVAMHSTestDlg::GetPath()
{
	TCHAR path[200];
	GetModuleFileName(NULL,path,200);
	wstring ws = path;
	size_t nBar = ws.find_last_of('\\') + 1;
	ws = ws.substr(0, nBar);
	CStringW csw = ws.c_str();
	return csw;
}

void CVAMHSTestDlg::OnBnClickedBnOhtAdd()
{
	CDlgAddOht dlgAddOht;
	if(dlgAddOht.DoModal() == IDOK)
	{
		int nOHT_ID = dlgAddOht.OhtID();
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
			pOht->nOnline = 0;

			CString str;
			m_listCtrlOHT.InsertItem(0, str);
			SetOHTListItemData(pOht, 0);
		}
	}
}


void CVAMHSTestDlg::OnBnClickedBnSethand()
{
	// TODO: 在此添加控件通知处理程序代码
	int hand_Set = GetDlgItemInt(IDC_EDIT_OHT_HAND);
	if((hand_Set != 0) && (hand_Set != 1))
		MessageBox(_T("Set the wrong hand,it should be 0 or 1 !"));
	int nOHT_ID = GetSelectOhtID();
	MAP_ItemOHT::iterator it = g_mapOHTs.find(nOHT_ID);
	it->second->nHandStatus = hand_Set;
	SaveXML();
}


void CVAMHSTestDlg::OnBnClickedBnTeachPos()
{
	int nPos = 0;
	int nSpeed = 0;

	nPos = GetDlgItemInt(IDC_EDIT_OHT_POS);
	nSpeed  = GetDlgItemInt(IDC_EDIT_OHT_SPEED);
	int nTypeString = m_cbOhtTeachType.GetCurSel();
	int nType = 0;
	switch(nTypeString)
	{
	case 0:
		nType = 0x01;
		break;
	case 1:
		nType = 0x02;
		break;
	case 2:
		nType = 0x04;
		break;
	case 3:
		nType = 0x08;
		break;
	case 4:
		nType = 0x10;
		break;
	case 5:
		nType = 0x20;
		break;
	default:
		nType = 0x01;
		break;
	}

	int nOhtID = 0;
	nOhtID = GetSelectOhtID();
	CStringW filePath = GetPath();
	filePath += "../Config/OHTandTeachPos.xml";
	CMarkup xml;
	xml.Load(filePath);
	xml.ResetMainPos();
	xml.FindElem();
	//xml.IntoElem();
	xml.FindChildElem(_T("TeachPosList"));
	xml.IntoElem();
    xml.AddChildElem(_T("TeachPos"));//add the elem failed 

	xml.IntoElem();
	xml.AddChildElem(_T("DeviceID"),nOhtID);
	xml.AddChildElem(_T("POS"),nPos);
	CString Type;
	Type.Format(_T("%d"),nType);
	xml.AddChildElem(_T("Type"),Type);
	xml.AddChildElem(_T("Speed"),nSpeed);
	xml.OutOfElem();
	xml.OutOfElem();
	xml.Save(filePath);
	g_pVDev->SetTeachPosition(nOhtID, nPos, nType, nSpeed);
	//m_Dialog.DoModal();
}

void CVAMHSTestDlg::InitListCtrlOHT(void)
{
	DWORD dwStyle;
	dwStyle = m_listCtrlOHT.GetStyle();  //取得样式
	dwStyle =    LVS_EX_GRIDLINES | LVS_EX_FULLROWSELECT
		| LVS_EX_DOUBLEBUFFER;   //添加样式
	m_listCtrlOHT.SetExtendedStyle(dwStyle);     //重新设置

	m_listCtrlOHT.InsertColumn(0, _T("ID"), LVCFMT_CENTER, 30);
	m_listCtrlOHT.InsertColumn(1, _T("POS"), LVCFMT_CENTER, 80);
	m_listCtrlOHT.InsertColumn(2, _T("HAND"), LVCFMT_CENTER, 50);
	m_listCtrlOHT.InsertColumn(3, _T("Status"), LVCFMT_CENTER, 50);
	m_listCtrlOHT.InsertColumn(4, _T("Online"), LVCFMT_CENTER, 50);
	ReadXML();
}


void CVAMHSTestDlg::InitListCtrlFOUP(void)
{
	
	DWORD dwStyle;
	dwStyle = m_listCtrlFOUP.GetStyle();  //取得样式
	dwStyle = LVS_EX_GRIDLINES | LVS_EX_FULLROWSELECT ;   //添加样式
	m_listCtrlFOUP.SetExtendedStyle(dwStyle);     //重新设置
	m_listCtrlFOUP.InsertColumn(0, _T("ID"), LVCFMT_CENTER, 100);
	m_listCtrlFOUP.InsertColumn(1, _T("Location"), LVCFMT_CENTER, 80);
	m_listCtrlFOUP.InsertColumn(2, _T("Status"), LVCFMT_CENTER, 50);
	
}


void CVAMHSTestDlg::OnTimer(UINT_PTR nIDEvent)
{
	LIST_OHT ohts = g_pVDev->OHT_GetStatus();
	LIST_FOUP foups = g_pVDev->Stocker_GetFoupsStatus(STOCKER_ID);

	LIST_OHT::iterator itOht = ohts.begin();
	while(itOht != ohts.end())
	{
		MAP_ItemOHT::iterator itMap = g_mapOHTs.find(itOht->nID);
		if (itMap != g_mapOHTs.end())
		{
			itMap->second->nHandStatus = itOht->nHandStatus;
			itMap->second->nPosition = itOht->nPosition;
			itMap->second->nOnline = itOht->nOnline;
			itMap->second->nPosTime = itOht->nPosTime;
			itMap->second->nStatusTime = itOht->nStatusTime;
		}
		++itOht;
	}

	int nCount = m_listCtrlOHT.GetItemCount();
	for (int i=0; i<nCount; i++)
	{
		int nOht = m_listCtrlOHT.GetItemData(i);
		MAP_ItemOHT::iterator it = g_mapOHTs.find(nOht);
		if (it != g_mapOHTs.end())
		{
			ItemOHT* pOht = it->second;
			SetOHTListItemData(pOht, i);
		}
	}
	SaveXML();
	CDialogEx::OnTimer(nIDEvent);
}


void CVAMHSTestDlg::SetOHTListItemData(ItemOHT* pOHT, int nListIndex)
{
	CString str;
	str.Format(_T("%d"), pOHT->nID);
	m_listCtrlOHT.SetItemText(nListIndex, 0, str);
	str.Format(_T("%d"), pOHT->nPosition);
	m_listCtrlOHT.SetItemText(nListIndex, 1, str);
	str.Format(_T("%d"), pOHT->nHandStatus);
	m_listCtrlOHT.SetItemText(nListIndex, 2, str);
	m_listCtrlOHT.SetItemText(nListIndex, 3, _T("Idle"));
	if (pOHT->nOnline > 0)
	{
		str = _T("On");
	}
	else
	{
		str = _T("Off");
	}
	m_listCtrlOHT.SetItemText(nListIndex, 4, str);
	m_listCtrlOHT.SetItemData(nListIndex, pOHT->nID);
}


void CVAMHSTestDlg::OnBnClickedBnStkHistory()
{
	g_pVDev->STK_History(STOCKER_ID);
}


int CVAMHSTestDlg::GetSelectOhtID(void)
{
	int nRet = -1;
	int nItem = m_listCtrlOHT.GetNextItem(-1, LVNI_ALL | LVNI_SELECTED);
	if (nItem >= 0)
	{
		nRet = m_listCtrlOHT.GetItemData(nItem);
	}
	else
	{
		nRet = -1;
	}
	return nRet;
}


void CVAMHSTestDlg::OnBnClickedBnOhtOff()
{
	int nOHT_ID = GetSelectOhtID();
	if (nOHT_ID >= 0)
	{
		int nAdd = g_pVDev->OHT_Offline(nOHT_ID);
	}
}
void CVAMHSTestDlg::OnBnClickedTeachposEdit()
{
	// TODO: 在此添加控件通知处理程序代码
	m_Dialog.DoModal();
}


void CVAMHSTestDlg::OnBnClickedOhtDel()
{
	// TODO: 在此添加控件通知处理程序代码
	int OHT_ID = GetSelectOhtID();
	CString str;
    int nId;
    POSITION pos = m_listCtrlOHT.GetFirstSelectedItemPosition();
    if(pos==NULL)
    {
		MessageBox(_T("请至少选择一项"));
		return;
	}
	nId=(int)m_listCtrlOHT.GetNextSelectedItem(pos);
	m_listCtrlOHT.DeleteItem(nId);
	MAP_ItemOHT::iterator it = g_mapOHTs.find(OHT_ID);
	g_mapOHTs.erase(it);
	DeleteElem(OHT_ID);
}


void CVAMHSTestDlg::OnBnClickedSendallButton()
{
	// TODO: 在此添加控件通知处理程序代码
	bool isFind = false;
	int OHT_ID = GetSelectOhtID();
	if(OHT_ID < 0)
	{
		MessageBox(_T("Please select the OHT!"));
		return ; 
	}
	CString path = GetPath();
	path += "../Config/OHTandTeachPos.xml";
	CMarkup xml;
	xml.Load(path);
	xml.FindElem();
	xml.FindChildElem(_T("TeachPosList"));
	xml.IntoElem();
	while(xml.FindChildElem(_T("TeachPos")))
	{
		xml.IntoElem();
		int ID = GetElemData(xml,_T("DeviceID"));
		if(ID == OHT_ID)
		{
			isFind = true;
			int nPos = GetElemData(xml,_T("POS"));
			int nType = GetElemData(xml,_T("Type"));
			int nSpeed = GetElemData(xml,_T("Speed"));
			g_pVDev->SetTeachPosition(ID, nPos, nType, nSpeed);
		}
		xml.OutOfElem();
	}
	xml.OutOfElem();
	if(!isFind)
		MessageBox(_T("The OHT selected has no TeachPos,please send them after edited!"));
}


void CVAMHSTestDlg::OnBnClickedAskForPath()
{
	// TODO: 在此添加控件通知处理程序代码
	int OHT_ID = GetSelectOhtID();
	if(OHT_ID < 0)
	{
		MessageBox(_T("Please select the OHT!"));
		return ; 
	}
	int askPath = g_pVDev->OHT_AskPath(OHT_ID);
}


void CVAMHSTestDlg::OnBnClickedSpeedSetButton()
{
	// TODO: 在此添加控件通知处理程序代码
	int OHT_ID = GetSelectOhtID();
	if(OHT_ID < 0)
	{
		MessageBox(_T("Please select the OHT!"));
		return ; 
	}
	int nSpeed = GetDlgItemInt(IDC_SPEED_SET_EDIT);
	int speedSet = g_pVDev->OHT_SetConstSpeed(OHT_ID,nSpeed);
}


void CVAMHSTestDlg::OnBnClickedBnAllohtonline()
{
	// TODO: 在此添加控件通知处理程序代码
}
