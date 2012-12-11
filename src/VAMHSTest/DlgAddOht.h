#pragma once


// CDlgAddOht 对话框

class CDlgAddOht : public CDialogEx
{
	DECLARE_DYNAMIC(CDlgAddOht)

public:
	CDlgAddOht(CWnd* pParent = NULL);   // 标准构造函数
	virtual ~CDlgAddOht();

// 对话框数据
	enum { IDD = IDD_DLG_ADDOHT };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedOk();

private:
	int m_nOhtID;

public:
	int OhtID() const { return m_nOhtID; }
};
