using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MCS.GuiHub;

namespace MCSControlLib
{
    public partial class pageStockerOpt : baseControlPage, IMcsControlBase
    {
        private byte stockorId = 0;

        private const string TKey_ID = "ID";
        private const string TKey_BarCode = "BarCode";
        private const string TKey_Lot = "Lot";
        private const string TKey_Status = "Status";

        private DataTable m_tableFoupsInfo = null;

        public pageStockerOpt(byte id)
        {
            InitializeComponent();
            stockorId = id;
        }

        private void pageStockerOpt_Load(object sender, EventArgs e)
        {
            InitFoupsInfoTable();
            dataGridViewFoupsInStocker.DataSource = m_tableFoupsInfo;
        }

        protected override void InitProcessDictionary()
        {
            m_dictProcess.Add(PushData.upFoupsTable, ProcessFoupsTable);
        }

        private void InitFoupsInfoTable()
        {
            if (null == m_tableFoupsInfo)
            {
                m_tableFoupsInfo = new DataTable("Foups");
                m_tableFoupsInfo.Columns.Add(TKey_ID, typeof(System.Byte));
                m_tableFoupsInfo.Columns[TKey_ID].AllowDBNull = false;
                m_tableFoupsInfo.PrimaryKey = new DataColumn[] { m_tableFoupsInfo.Columns["ID"] };
                m_tableFoupsInfo.Columns.Add(TKey_BarCode, typeof(System.UInt16));
                m_tableFoupsInfo.Columns.Add(TKey_Lot, typeof(System.UInt16));
                m_tableFoupsInfo.Columns.Add(TKey_Status, typeof(System.UInt16));

                m_tableFoupsInfo.AcceptChanges();
            }
        }

        private void ProcessFoupsTable(ArrayList item)
        {
            if (item.Count > 1)
            {
                byte nID = Convert.ToByte(item[0]);
                UInt16 nBarCode = Convert.ToUInt16(item[1]);
                UInt16 nLot = Convert.ToUInt16(item[2]);
                UInt16 nStatus = Convert.ToUInt16(item[3]);
                DataRow row = m_tableFoupsInfo.Rows.Find(nID);
                if (null != row)
                {
                    row[TKey_BarCode] = nBarCode;
                    row[TKey_Lot] = nLot;
                    row[TKey_Status] = nStatus;
                    row.AcceptChanges();
                }
                else
                {
                    row = m_tableFoupsInfo.NewRow();
                    row[TKey_ID] = nID;
                    row[TKey_BarCode] = nBarCode;
                    row[TKey_Lot] = nLot;
                    row[TKey_Status] = nStatus;
                    row.AcceptChanges();
                }
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void bnAlarmHistory_Click(object sender, EventArgs e)
        {
            formSTKAlarmHistory hisAlarm = new formSTKAlarmHistory();
            hisAlarm.ShowDialog();
        }

        private void bnFoupHistory_Click(object sender, EventArgs e)
        {
            formSTKFoupHistory hisFoup = new formSTKFoupHistory();
            hisFoup.ShowDialog();
        }

        private void linkLabelStkFoupRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void btnBackTimeStatus_Click(object sender, EventArgs e)
        {
            string strTime = tBBackTimeStatus.Text;
            byte nID = stockorId;
            Int32 nTime = 0;
            nTime = TryConver.ToInt32(strTime);
            string strVal;
            strVal = string.Format("<{0},{1}>", nID, nTime);

            int nWRet = m_dataHub.WriteData(GuiCommand.StkStatusTime, strVal);
        }

        private void btnBackTimeFoups_Click(object sender, EventArgs e)
        {
            string strTime = tBBackTimeFoups.Text;
            byte nID = stockorId;
            Int32 nTime = 0;
            nTime = TryConver.ToInt32(strTime);
            string strVal;
            strVal = string.Format("<{0},{1}>", nID, nTime);

            int nWRet = m_dataHub.WriteData(GuiCommand.StkSetFoupInfoBackTime, strVal);
        }

        private void lLStkInfoStatus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            byte nID = stockorId;
            string strVal = string.Format("<{0}>", nID);

            int nWRet = m_dataHub.WriteData(GuiCommand.StkInquiryStatus, strVal);
        }

        private void btnFoupMoveIn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            byte nID = stockorId;
            byte nOpt = 2;
            if (btn.Name == "btnFoupMoveIn")
                nOpt = 0;
            else if (btn.Name == "btnFoupMoveOut")
                nOpt = 1;
            byte nMode = TryConver.ToByte(cBFoupMove.SelectedIndex.ToString());
            int nData = Convert.ToInt32(tBFoupMove.Text);
            string strVal;
            strVal = string.Format("<{0},{1},{2},{3}>", nID, nOpt, nMode, nData);

            int nWRet = m_dataHub.WriteData(GuiCommand.StkHandFoup, strVal);
        }

        
    }
}
