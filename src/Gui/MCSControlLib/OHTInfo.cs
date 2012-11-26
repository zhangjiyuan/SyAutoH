using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCSControlLib
{
    public partial class OHTInfo : UserControl, IMcsControlBase
    {
        private GuiAccess.DataHubCli m_dataHub = null;
        private Dictionary<int, OhtInfoData> m_dictOhtInfo = new Dictionary<int, OhtInfoData>();
        private DataSet m_dataSet = new DataSet();
        private DataTable m_tableOHTInfo = null;
        public OHTInfo()
        {
            InitializeComponent();
        }
        public GuiAccess.DataHubCli DataHub
        {
            set
            {
                m_dataHub = value;
            }
            get
            {
                return m_dataHub;
            }
        }

        public void ProcessGuiData(List<MCS.GuiDataItem> list)
        {
            foreach (MCS.GuiDataItem item in list)
            {
                ProcessGuiDataItem(item);
            }
        }

        private void ProcessGuiDataItem(MCS.GuiDataItem guiData)
        {
            ArrayList alDatas = GuiAccess.DataHubCli.ConvertToArrayList(guiData.sVal);
            if (guiData.sTag.CompareTo("OHT.Info") == 0)
            {
                foreach (ArrayList item in alDatas)
                {
                    ProcessOHTInfo(item);
                }
            }
            else if (guiData.sTag.CompareTo("OHT.Pos") == 0)
            {
                foreach (ArrayList item in alDatas)
                {
                    ProcessOHTPos(item);
                }
            }

            UpdateTableData();
        }

        private void ProcessOHTInfo(ArrayList item)
        {
            if (3 == item.Count)
            {
                OhtInfoData info = null;
                string strTCP = item[1] + ":" + item[2];
                int nID = Convert.ToInt16(item[0]);
                m_dictOhtInfo.TryGetValue(nID, out info);
                if (null != info)
                {
                    info.TcpInfo = strTCP;
                }
                else
                {
                    info = new OhtInfoData();
                    info.ID = nID;
                    info.TcpInfo = strTCP;
                    m_dictOhtInfo.Add(nID, info);
                }

            }
        }

        private void ProcessOHTPos(ArrayList item)
        {
            if (3 == item.Count)
            {
                OhtInfoData info = null;
                int nID = Convert.ToInt16(item[0]);
                long nPosition = Convert.ToInt64(item[1]);
                int nHand = Convert.ToInt16(item[2]);

                m_dictOhtInfo.TryGetValue(nID, out info);
                if (null != info)
                {
                    info.Position = nPosition;
                    info.Hand = nHand;
                }
                else
                {
                    info = new OhtInfoData();
                    info.ID = nID;
                    info.Position = nPosition;
                    info.Hand = nHand;
                    m_dictOhtInfo.Add(nID, info);
                }
            }
        }

        private void UpdateTableData()
        {
            foreach (KeyValuePair<int, OhtInfoData> item in m_dictOhtInfo)
            {
                OhtInfoData info = item.Value;
                DataRow row = m_tableOHTInfo.Rows.Find(info.ID);
                if (null != row)
                {
                    SetRowData(row, info);
                    row.AcceptChanges();
                }
                else
                {
                    row = m_tableOHTInfo.NewRow();
                    row["ID"] = info.ID;
                    SetRowData(row, info);
                    m_tableOHTInfo.Rows.Add(row);
                    m_tableOHTInfo.AcceptChanges();
                }
            }
        }

        private void SetRowData(DataRow row, OhtInfoData info)
        {
            row["Position"] = info.Position;
            row["Hand"] = info.Hand;
            row["Status"] = info.Status;
            row["Alarm"] = info.Alarm;
            row["TcpInfo"] = info.TcpInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Oht Info test");
        }

        private void InitDataTable()
        {
            m_tableOHTInfo = m_dataSet.Tables["OHT"];
            if (null == m_tableOHTInfo)
            {
                m_tableOHTInfo = new DataTable("OHT");
                m_tableOHTInfo.Columns.Add("ID", typeof(System.Int32));
                m_tableOHTInfo.Columns["ID"].AllowDBNull = false;
                m_tableOHTInfo.PrimaryKey = new DataColumn[]{m_tableOHTInfo.Columns["ID"]};
                m_tableOHTInfo.Columns.Add("Position", typeof(System.Int32));
                m_tableOHTInfo.Columns.Add("Hand", typeof(System.Int32));
                m_tableOHTInfo.Columns.Add("Status", typeof(System.Int32));
                m_tableOHTInfo.Columns.Add("Alarm", typeof(System.Int32));
                m_tableOHTInfo.Columns.Add("TcpInfo", typeof(System.String));

                m_tableOHTInfo.AcceptChanges();

                m_dataSet.Tables.Add(m_tableOHTInfo);
                m_dataSet.AcceptChanges();
            }
        }

        private void OHTInfo_Load(object sender, EventArgs e)
        {
            InitDataTable();
            dataGridView1.DataSource = m_tableOHTInfo;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string nID = "254";
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                DataGridViewRow row = rows[0];
                nID = row.Cells[0].Value.ToString();
               
            }
            
            tBOHTID.Text = nID;
        }

        private void bnSetPosTime_Click(object sender, EventArgs e)
        {
            string strPosTime = tBPosTime.Text;
            int nPosTime = 0;
            int nID = 0;
            try
            {
                nID = Convert.ToByte(tBOHTID.Text);
            }
            catch (System.Exception /*ex*/)
            {
                nID = 254;
            }
            try
            {
                nPosTime = System.Convert.ToByte(strPosTime);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            string strVal;
            strVal = string.Format("<{0}, {1}>", nID, nPosTime);

            int nWRet = m_dataHub.WriteData("OHT.POSTIME", strVal);
        }

        private void bnSetStatusTime_Click(object sender, EventArgs e)
        {
            string strPosTime = tBStatusTime.Text;
            int nPosTime = 0;
            int nID = 0;
            try
            {
                nID = Convert.ToByte(tBOHTID.Text);
            }
            catch (System.Exception /*ex*/)
            {
                nID = 254;
            }
            try
            {
                nPosTime = System.Convert.ToByte(strPosTime);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            string strVal;
            strVal = string.Format("<{0}, {1}>", nID, nPosTime);

            int nWRet = m_dataHub.WriteData("OHT.STATUSTIME", strVal);
        }
    }
}
