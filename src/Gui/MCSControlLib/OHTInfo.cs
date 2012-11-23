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
            if (guiData.sTag.CompareTo("OHT.Info") == 0)
            {
                string strVal = guiData.sVal;
                string strSplit = "<>";
                char[] spliter = strSplit.ToCharArray();
                string[] strItem = strVal.Split(spliter);
                foreach (string strOht in strItem)
                {
                    if (strOht.Length > 0)
                    {
                        string[] strParams = strOht.Split(',');
                        if (strParams.Length == 3)
                        {
                            OhtInfoData info = null;
                            string strTCP = strParams[1] + ":" + strParams[2];
                            int nID = Convert.ToInt16(strParams[0]);

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
                }
            }
            else if (guiData.sTag.CompareTo("OHT.Pos") == 0)
            {
                string strVal = guiData.sVal;
                string strSplit = "<>";
                char[] spliter = strSplit.ToCharArray();
                string[] strItem = strVal.Split(spliter);
                foreach (string strOht in strItem)
                {
                    if (strOht.Length > 0)
                    {
                        string[] strParams = strOht.Split(',');
                        if (strParams.Length == 3)
                        {
                            OhtInfoData info = null;
                            int nID = Convert.ToInt16(strParams[0]);
                            long nPosition = Convert.ToInt64(strParams[1]);
                            int nHand = Convert.ToInt16(strParams[2]);

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
                }
            }

            dataGridView1.DataSource = m_dictOhtInfo.Values.ToList();
            //m_dataSet = m_dictOhtInfo.Values.ToList() as DataSet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Oht Info test");
        }

        private void OHTInfo_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = m_dataSet;
        }
    }
}
