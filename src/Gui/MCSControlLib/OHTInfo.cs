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
    public partial class OHTInfo : UserControl, IMcsControlBase
    {
        private GuiAccess.DataHubCli m_dataHub = null;
        private Dictionary<int, OhtInfoData> m_dictOhtInfo = new Dictionary<int, OhtInfoData>();
        private DataTable m_tableOHTInfo = null;
        private DataTable m_tableKeyPos = null;
        private DataTable m_tablePathView = null;
        private byte m_uIdSelected = 0;
        private delegate void ProcessHandler(ArrayList item);
        private Dictionary<PushData, ProcessHandler> m_dictProcess = new Dictionary<PushData, ProcessHandler>();
        private int m_nPathPosition = 0;

        public OHTInfo()
        {
            InitializeComponent();

            InitProcessDictionary();
        }

        private void InitProcessDictionary()
        {
            m_dictProcess.Add(PushData.upOhtInfo, ProcessOHTInfo);
            m_dictProcess.Add(PushData.upOhtPos, ProcessOHTPos);
            m_dictProcess.Add(PushData.upOhtPosTable, ProcessPosTable);
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

        public  void ProcessGuiData(List<MCS.GuiDataItem> list)
        {
            foreach (MCS.GuiDataItem item in list)
            {
                ProcessGuiDataItem(item);
            }
        }

        private void ProcessGuiDataItem(MCS.GuiDataItem guiData)
        {
            
            ProcessHandler handler = null;
            bool bGet = m_dictProcess.TryGetValue(guiData.enumTag, out handler);
            if (true == bGet)
            {
                ArrayList alDatas = GuiAccess.DataHubCli.ConvertToArrayList(guiData.sVal);
                foreach (ArrayList item in alDatas)
                {
                    handler(item);
                }
            }
        }

        private void ProcessPosTable(ArrayList item)
        {
            if (4 == item.Count)
            {
                UInt32 uPos = Convert.ToUInt32(item[1]);
                Byte uType = TryConver.ToByte(item[2].ToString());
                Byte uSpeed = TryConver.ToByte(item[3].ToString());
                DataRow row = m_tableKeyPos.Rows.Find(uPos);
                if (null != row)
                {
                    row["Name"] = item[0].ToString();
                    row["Type"] = uType;
                    row["Speed"] = uSpeed;
                    row.AcceptChanges();
                }
                else
                {
                    row = m_tableKeyPos.NewRow();
                    row["Position"] = uPos;
                    row["Name"] = item[0].ToString();
                    row["Type"] = uType;
                    row["Speed"] = uSpeed;
                    m_tableKeyPos.Rows.Add(row);
                    m_tableKeyPos.AcceptChanges();
                }
            }
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
                UpdateOhtInfo(info);
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
                UpdateOhtInfo(info);
            }
        }

        private void UpdateOhtInfo(OhtInfoData info)
        {
            DataRow row = m_tableOHTInfo.Rows.Find(info.ID);
            if (null != row)
            {
                SetRowOHTInfoData(row, info);
                row.AcceptChanges();
            }
            else
            {
                row = m_tableOHTInfo.NewRow();
                row["ID"] = info.ID;
                SetRowOHTInfoData(row, info);
                m_tableOHTInfo.Rows.Add(row);
                m_tableOHTInfo.AcceptChanges();
            }
        }

        private void SetRowOHTInfoData(DataRow row, OhtInfoData info)
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

        private void InitKeyPosTable()
        {
            if (null == m_tableKeyPos)
            {
                m_tableKeyPos = new DataTable("KeyPos");
                m_tableKeyPos.Columns.Add("Position", typeof(System.UInt32));
                m_tableKeyPos.Columns["Position"].AllowDBNull = false;
                m_tableKeyPos.PrimaryKey = new DataColumn[] { m_tableKeyPos.Columns["Position"] };
                m_tableKeyPos.Columns.Add("Name", typeof(System.String));
                m_tableKeyPos.Columns.Add("Type", typeof(System.Byte));
                m_tableKeyPos.Columns.Add("Speed", typeof(System.Byte));

                m_tableKeyPos.AcceptChanges();
            }
        }

        private void InitDataTable()
        {
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
            }
        }

        private void OHTInfo_Load(object sender, EventArgs e)
        {
            InitDataTable();
            InitKeyPosTable();
            dataGridViewOHTInfo.DataSource = m_tableOHTInfo;
            dataGridViewKeyPos.DataSource = m_tableKeyPos;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridViewOHTInfo.SelectedRows;
            if (rows.Count > 0)
            {
                DataGridViewRow row = rows[0];
                m_uIdSelected = TryConver.ToByte(row.Cells[0].Value.ToString());
            }
            tBOHTID.Text = m_uIdSelected.ToString();
            checkBox1.Checked = false;
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

            int nWRet = m_dataHub.WriteData(GuiCommand.OhtPosTime, strVal);
        }

        private void bnSetStatusTime_Click(object sender, EventArgs e)
        {
            string strTime = tBStatusTime.Text;
            byte nTime = 0;
            GetOHTIDbyTextBox();
            nTime = TryConver.ToByte(strTime);
            string strVal;
            strVal = string.Format("<{0}, {1}>", m_uIdSelected, nTime);

            int nWRet = m_dataHub.WriteData(GuiCommand.OhtStatusTime, strVal);
        }

        private byte GetBufID()
        {
            byte uBufID = 0;
            uBufID = TryConver.ToByte(tBBuffID.Text);
            tBBuffID.Text = uBufID.ToString();
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
            string strVal = "";
            strVal = string.Format("<{0},{1},{2}>", uID, uTarget, uOperation);
            int nWRet = m_dataHub.WriteData(GuiCommand.OhtFoupHanding, strVal);
        }

        private void bnPlace_Click(object sender, EventArgs e)
        {
            GetOHTIDbyTextBox();
            byte uBuffID = GetBufID();
            Foup_Pick_Place(m_uIdSelected, uBuffID, 1);
        }

        private void linkLabelRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_dataHub.Async_WriteData(GuiCommand.OhtGetPosTable, "");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (true == checkBox1.Checked)
            {
                tBOHTID.Text = "254";
            }
        }

        private void linkLabelSetFrom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //int nTo = 0;
            //nTo = TryConver.ToInt32(textBoxPathTo.Text);
            //if (nTo == m_nPathPosition)
            //{
            //    MessageBox.Show("Do not set same point.");
            //}
            //else
            //{
                this.textBoxPathFrom.Text = m_nPathPosition.ToString();
            //}
        }

        private void dataGridViewKeyPos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridViewKeyPos.SelectedRows;
            if (rows.Count > 0)
            {
                DataGridViewRow row = rows[0];
                m_nPathPosition = TryConver.ToByte(row.Cells[0].Value.ToString());
            }
        }

        private void linkLabelSetTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //int nFrom = 0;
            //nFrom = TryConver.ToInt32(textBoxPathFrom.Text);
            //if (nFrom == m_nPathPosition)
            //{
            //    MessageBox.Show("Do not set same point.");
            //}
            //else
            //{
                this.textBoxPathTo.Text = m_nPathPosition.ToString();
            //}
        }

        private void dataGridViewKeyPos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void bnSetPath_Click(object sender, EventArgs e)
        {
            m_tablePathView = m_tableKeyPos.Clone();
            int nFrom = TryConver.ToInt32(textBoxPathFrom.Text);
            int nTo = TryConver.ToInt32(textBoxPathTo.Text);
            string strSQL = String.Format("Position >= {0} and Position <= {1}", nFrom, nTo);
            DataRow[] rows = m_tableKeyPos.Select(strSQL);
            foreach (DataRow row in rows)
            {
                //pathview.Rows.Add(row);
                DataRow newRow = m_tablePathView.NewRow();
                newRow.ItemArray = row.ItemArray;
                m_tablePathView.Rows.Add(newRow);
            }
            //int nCount = rows.Length;
            
            this.dataGridViewPath.DataSource = m_tablePathView;
        }
    }
}
