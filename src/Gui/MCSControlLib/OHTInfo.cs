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
        private byte m_uIdSelected = 0;

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
                m_tableOHTInfo.Columns.Add("ID", typeof(System.Byte));
                m_tableOHTInfo.Columns["ID"].AllowDBNull = false;
                m_tableOHTInfo.PrimaryKey = new DataColumn[]{m_tableOHTInfo.Columns["ID"]};
                m_tableOHTInfo.Columns.Add("Position", typeof(System.Int32));
                m_tableOHTInfo.Columns.Add("Hand", typeof(System.Byte));
                m_tableOHTInfo.Columns.Add("Status", typeof(System.Byte));
                m_tableOHTInfo.Columns.Add("Alarm", typeof(System.Byte));
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
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                DataGridViewRow row = rows[0];
                m_uIdSelected = TryConver.ToByte(row.Cells[0].Value.ToString());
            }
            tBOHTID.Text = m_uIdSelected.ToString();
        }

        private void GetOHTIDbyTextBox()
        {
            m_uIdSelected = TryConver.ToByte(tBOHTID.Text);
        }

        private void bnSetPosTime_Click(object sender, EventArgs e)
        {
            string strTime = tBPosTime.Text;
            byte nTime = 0;
            GetOHTIDbyTextBox();
            nTime = TryConver.ToByte(strTime);
            string strVal;
            strVal = string.Format("<{0}, {1}>", m_uIdSelected, nTime);

            int nWRet = m_dataHub.WriteData("OHT.POSTIME", strVal);
        }

        private void bnSetStatusTime_Click(object sender, EventArgs e)
        {
            string strTime = tBStatusTime.Text;
            byte nTime = 0;
            GetOHTIDbyTextBox();
            nTime = TryConver.ToByte(strTime);
            string strVal;
            strVal = string.Format("<{0}, {1}>", m_uIdSelected, nTime);

            int nWRet = m_dataHub.WriteData("OHT.STATUSTIME", strVal);
        }

        private byte GetBufID()
        {
            byte uBufID = 0;
            uBufID = TryConver.ToByte(tBBuffID.Text);
            return uBufID;
        }

        private void bnPick_Click(object sender, EventArgs e)
        {
            GetOHTIDbyTextBox();
            byte uBuffID = GetBufID();
            Foup_Pick_Place(m_uIdSelected, uBuffID, 0);
        }

        private void Foup_Pick_Place(byte uID, byte uTarget, byte uOperation)
        {
            string strVal;
            strVal = string.Format("<{0},{1},{3}>", uID, uTarget, uOperation);
            int nWRet = m_dataHub.WriteData("OHT.FOUPHANDING", strVal);
        }

        private void bnPlace_Click(object sender, EventArgs e)
        {
            GetOHTIDbyTextBox();
            byte uBuffID = GetBufID();
            Foup_Pick_Place(m_uIdSelected, uBuffID, 1);
        }
    }
}
