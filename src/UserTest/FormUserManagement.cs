using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GuiAccess;

namespace UserTest
{
    
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent();
            Init_listViewStockerFoups();
            Init_listView_MesLocation();
            Init_listView_MesFoups();
        }
        private string[] RightCollection = 
            new string[] { "NoRight", "Viewer", "Guest", "Operator", "Admin", "SuperAdmin"};
        private UserCli userMge = new UserCli();
        private MESLink mesLink = new MESLink();
        private DataHubCli dataHubLink = new DataHubCli();
        private int m_nSession = 0;
        private string strUserLogin = "";

        private MCS.GuiDataItem guiData = new MCS.GuiDataItem();

        private void Init_listView_MesFoups()
        {
            lVMes_Foup.Clear();
            lVMes_Foup.Columns.Clear();
            lVMes_Foup.Columns.Add("Lot", 60, HorizontalAlignment.Center);
            lVMes_Foup.Columns.Add("BarCode", 60, HorizontalAlignment.Center);
            lVMes_Foup.Columns.Add("Status", 60, HorizontalAlignment.Center);
            lVMes_Foup.Columns.Add("Location", 60, HorizontalAlignment.Center);
            lVMes_Foup.Columns.Add("OHT Pos", 60, HorizontalAlignment.Center);
        }

        private void Init_listView_MesLocation()
        {
            lVMes_Location.Clear();
            lVMes_Location.Columns.Clear();
            lVMes_Location.Columns.Add("Name", 80, HorizontalAlignment.Center);
            lVMes_Location.Columns.Add("Type", 60, HorizontalAlignment.Center);
            lVMes_Location.Columns.Add("BarCode", 60, HorizontalAlignment.Center);
        }

        private void Init_listViewStockerFoups()
        {
            listViewStockerFoups.Clear();
            listViewStockerFoups.Columns.Clear();
            listViewStockerFoups.Columns.Add("ID", 60, HorizontalAlignment.Center);
            listViewStockerFoups.Columns.Add("Lot", 60, HorizontalAlignment.Center);
            listViewStockerFoups.Columns.Add("Location", 60, HorizontalAlignment.Center);
            listViewStockerFoups.Columns.Add("LocType", 60, HorizontalAlignment.Center);
            listViewStockerFoups.Columns.Add("Status", 60, HorizontalAlignment.Center);
        }

        private void bnLogin_Click(object sender, EventArgs e)
        {
            string strHash = UserHash.HashUserInfo(this.textBoxUser.Text,
                this.maskedTextBoxPW.Text);
           
            m_nSession = userMge.Login(this.textBoxUser.Text, strHash); 
            
            //this.labelHashUser.Text = strHash + " s: " + m_nSession.ToString();
            if (m_nSession > 0)
            {
                this.tabControl1.SelectedIndex = 1;
                strUserLogin = this.textBoxUser.Text;
                this.textBoxLoginUser.Text = strUserLogin;
                this.comboBoxUserRight.SelectedIndex = 4;

                this.Text = "MCS Control  Login User: " + this.textBoxUser.Text;
           
            }
            else
            {
                MessageBox.Show("Login failed, please check your user name and password.");
            }
          
        }

        private void GuiDataUpdate(MCS.GuiDataItem item)
        {
            //if (strTag.CompareTo("TEST") == 0)
            //{
            //    this.labelCBTest.Text = sVal;
            //}
            //if (strTag.CompareTo("OHT.POS") == 0)
            //{
            //    this.labelCBTest.Text = sVal;
            //}
            lock(guiData)
            {
                guiData = item;
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userMge.ConnectServer();
            mesLink.ConnectServer();
            dataHubLink.ConnectServer();
            dataHubLink.DataUpdater += new DataUpdaterHander(GuiDataUpdate);
            dataHubLink.Async_SetCallBack();

            this.comboBoxUserRight.Items.Clear();
            foreach (string strRight in RightCollection)
            {
                this.comboBoxUserRight.Items.Add(strRight);
            }
            this.comboBoxUserRight.SelectedIndex = 0;

            //this.tabControl1.TabPages.RemoveAt(2);
            timer1.Start();
        }

        private void bnNewUser_Click(object sender, EventArgs e)
        {
            FormNewUser newUser = new FormNewUser();
            DialogResult dlgResult = newUser.ShowDialog();
            if (dlgResult ==  DialogResult.OK)
            {
                string strName = newUser.StrName;
                string strPW = newUser.StrPassword;
                int nUserRight = newUser.NRight;

                int nRet = userMge.CreateUser(strName,
                    strPW, nUserRight, m_nSession);

                if (0 == nRet)
                {
                    MessageBox.Show("Success create user.");
                    RefreshUserList();
                }
                else
                {
                    MessageBox.Show("Failed to create user.");
                }
            }

            
        }

        private void buttonUserGet_Click(object sender, EventArgs e)
        {
            RefreshUserList();
        }

        private void RefreshUserList()
        {
            int nCount = userMge.GetUserCount(m_nSession);
            if (nCount > 20)
            {
                nCount = 20;
            }
            MCS.User[] userNames = userMge.GetUserList(0, nCount, m_nSession);
            if (userNames != null)
            {
                this.listViewUserList.Items.Clear();
                foreach (MCS.User aUser in userNames)
                {
                    ListViewItem item = this.listViewUserList.Items.Add(aUser.nID.ToString());
                    item.Tag = aUser.nID;
                    item.SubItems.Add(aUser.sName);
                    string strRight = RightCollection[aUser.nRight];
                    item.SubItems.Add(strRight);
                }
            }
        }

        private void buttonUserPW_Click(object sender, EventArgs e)
        {
            int nSelected = this.listViewUserList.SelectedItems.Count;
            if (nSelected > 0)
            {
                int nUserRight = this.comboBoxUserRight.SelectedIndex;
                foreach (ListViewItem item in this.listViewUserList.SelectedItems)
                {
                    int nID = (int)item.Tag;
                    string user = item.SubItems[1].Text;
                   
                    FormUserPassword userPW = new FormUserPassword();
                    userPW.SetData(user);
                    DialogResult dlgResult = userPW.ShowDialog();
                    if (DialogResult.OK == dlgResult)
                    { 
                        userMge.SetUserPW(nID, userPW.NewPassword, m_nSession);
                        RefreshUserList();
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user.");
            }
        }

        private void buttonUserRight_Click(object sender, EventArgs e)
        {
            int nSelected = this.listViewUserList.SelectedItems.Count;
            if (nSelected > 0)
            {
                foreach (ListViewItem item in this.listViewUserList.SelectedItems)
                {
                    int nID = (int)item.Tag;
                    string user = item.SubItems[1].Text;
                    FormUserRight userRight = new FormUserRight();
                    userRight.SetData(user, 3);

                    DialogResult dlgResult = userRight.ShowDialog();
                    if (DialogResult.OK == dlgResult)
                    {
                        int nUserRight = userRight.UserRight;
                        int nRet = userMge.SetUserRight(nID, nUserRight, m_nSession);
                        if (nRet == -5)
                        {
                            MessageBox.Show("Right limited, can not execuate command.");
                            return;
                        }
                    }

                  
                }
                RefreshUserList();
            }
            else
            {
                MessageBox.Show("Please select a user.");
            }


        }

        private void buttonUserDelete_Click(object sender, EventArgs e)
        {
            int nSelected = this.listViewUserList.SelectedItems.Count;
            if (nSelected > 0)
            {
                foreach (ListViewItem item in this.listViewUserList.SelectedItems)
                {
                    int nID = (int)item.Tag;
                    userMge.DeleteUser(nID, m_nSession);
                }
                RefreshUserList();
            }
        }

        private void bnLogout_Click(object sender, EventArgs e)
        {
            if (m_nSession > 0)
            {
                userMge.Logout(m_nSession);
                m_nSession = 0;
                this.Text = "MCS Control Logout";
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nSesected = this.tabControl1.SelectedIndex;
            if (m_nSession <= 0)
            {
                this.tabControl1.SelectedIndex = 0;
                return;
            }

            if (this.tabControl1.SelectedIndex == 1)
            {
                RefreshUserList();
            }
        }

        private void bnOHTGo_Click(object sender, EventArgs e)
        {
            string strPos = this.tbOhtMoveTo.Text;
            int nPos = 0;
            try
            { 
                nPos = System.Convert.ToInt32(strPos);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            string sVal = dataHubLink.ReadData("OHT", m_nSession);

            int nWRet = dataHubLink.WriteData("OHT", "MOVE", m_nSession);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (guiData)
            {
                labelCBTest.Text = guiData.sVal;
            }
        }

        private void bnSTK_History_Click(object sender, EventArgs e)
        {
            int nWret = dataHubLink.WriteData("STK.HISTORY", "GET", m_nSession);
        }

        private void bnSetPosTime_Click(object sender, EventArgs e)
        {
            string strPosTime = tBPosTime.Text;
            int nPosTime = 0;
            try
            {
                nPosTime = System.Convert.ToByte(strPosTime);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            string strVal;
            strVal = string.Format("<{0}, {1}>", 254, nPosTime);

            int nWRet = dataHubLink.WriteData("OHT.POSTIME", strVal, m_nSession);
        }

        private void maskedTextBoxPW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.CompareTo('\r') == 0)
            {
                bnLogin_Click(null, null);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MessageBox.Show("Refresh Foups in MCS");
            tBMesFS_Lot.Text = "345";
            tBMesFS_BC.Text = "11982";
            tBMesFS_ST.Text = "Ready";
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void linkOHTMoveToRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataHubLink.Async_WriteData("OHT.GetPosTable", "", m_nSession);
        }
    }
}
