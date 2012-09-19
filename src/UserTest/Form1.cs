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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string[] RightCollection = 
            new string[] { "NoRight", "Viewer", "Guest", "Operator", "Admin", "SuperAdmin"};
        private UserCli userMge = new UserCli();
        private MESLink mesLink = new MESLink();
        private int m_nSession = 0;

        private void bnLogin_Click(object sender, EventArgs e)
        {
            string strHash = UserHash.HashUserInfo(this.textBoxUser.Text,
                this.maskedTextBoxPW.Text);
           
            m_nSession = userMge.Login(this.textBoxUser.Text, strHash); 
            
            this.labelHashUser.Text = strHash + " s: " + m_nSession.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userMge.ConnectServer();
            mesLink.ConnectServer();
            this.comboBoxUserRight.Items.Clear();
            foreach (string strRight in RightCollection)
            {
                this.comboBoxUserRight.Items.Add(strRight);
            }
            this.comboBoxUserRight.SelectedIndex = 0;
        }

        private void bnNewUser_Click(object sender, EventArgs e)
        {
            string strName = this.textBoxNewUser.Text;
            if (strName.Length <= 0)
            {
                MessageBox.Show("Name must not null.");
                return;
            }
            string strPW = this.textBoxNewPassword.Text;
            string strPW2 = this.textBoxPWagain.Text;
            if (strPW.CompareTo(strPW2) != 0)
            {
                MessageBox.Show("Passwords not same.");
                return;
            }
            int nUserRight = this.comboBoxUserRight.SelectedIndex;

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

        private void buttonPickFoup_Click(object sender, EventArgs e)
        {
            string strFoupName = this.textBoxFoupName.Text;
            int nLocal = Convert.ToInt32(this.textBoxLocation.Text);
            int nType = Convert.ToInt32(this.textBoxLocType.Text);

            mesLink.PickFoup(strFoupName, nLocal, nType);
        }

        private void buttonPlaceFoup_Click(object sender, EventArgs e)
        {
            string strFoupName = this.textBoxFoupName.Text;
            int nLocal = Convert.ToInt32(this.textBoxLocation.Text);
            int nType = Convert.ToInt32(this.textBoxLocType.Text);

            mesLink.PlaceFoup(strFoupName, nLocal, nType);
        }

        private void buttonGetFoupID_Click(object sender, EventArgs e)
        {
            int nLocal = 0;
            int nType = 0;
            string strFoupName = this.textBoxFoupName.Text;
            mesLink.GetFoupLocation(strFoupName, out nLocal, out nType);
            
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
            string strPW = this.textBoxNewPassword.Text;
            string strPW2 = this.textBoxPWagain.Text;
            if (strPW.CompareTo(strPW2) != 0)
            {
                MessageBox.Show("Passwords not same.");
                return;
            }

            int nSelected = this.listViewUserList.SelectedItems.Count;
            if (nSelected > 0)
            {
                int nUserRight = this.comboBoxUserRight.SelectedIndex;
                foreach (ListViewItem item in this.listViewUserList.SelectedItems)
                {
                    int nID = (int)item.Tag;
                    userMge.SetUserPW(nID, strPW, m_nSession);
                }
            }
        }

        private void buttonUserRight_Click(object sender, EventArgs e)
        {
            int nSelected = this.listViewUserList.SelectedItems.Count;
            if (nSelected > 0)
            {
                int nUserRight = this.comboBoxUserRight.SelectedIndex;
                foreach (ListViewItem item in this.listViewUserList.SelectedItems)
                {
                    int nID = (int)item.Tag;
                    int nRet = userMge.SetUserRight(nID, nUserRight, m_nSession);
                    if (nRet == -5)
                    {
                        MessageBox.Show("Right limited, can not execuate command.");
                        return;
                    }
                }
                RefreshUserList();
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
            }
        }
    }
}
