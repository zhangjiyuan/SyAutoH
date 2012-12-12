// DlgAddOht.cpp : 实现文件
//

#include "stdafx.h"
#include "VAMHSTest.h"
#include "DlgAddOht.h"
#include "afxdialogex.h"


// CDlgAddOht 对话框

IMPLEMENT_DYNAMIC(CDlgAddOht, CDialogEx)

CDlgAddOht::CDlgAddOht(CWnd* pParent /*=NULL*/)
	: CDialogEx(CDlgAddOht::IDD, pParent)
{

}

CDlgAddOht::~CDlgAddOht()
{
}

void CDlgAddOht::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CDlgAddOht, CDialogEx)
	ON_BN_CLICKED(IDOK, &CDlgAddOht::OnBnClickedOk)
END_MESSAGE_MAP()


// CDlgAddOht 消息处理程序


void CDlgAddOht::OnBnClickedOk()
{
	int nOHT_ID = GetDlgItemInt(IDC_EDIT_OHTID);
	if (nOHT_ID >= 0 && nOHT_ID < 254)
	{
		m_nOhtID = nOHT_ID;
		CDialogEx::OnOK();
	}
	else
	{
		MessageBox(_T("不合理的OHT ID值, 应在0至253之间."));
	}
}
