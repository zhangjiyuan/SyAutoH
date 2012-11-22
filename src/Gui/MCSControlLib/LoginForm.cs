using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCSControlLib
{
    public partial class LoginForm : Form
    {
        private bool m_isLogin = false;
        private GuiAccess.UserCli userMge = new GuiAccess.UserCli();
        public bool IsLogin
        {
            get { return m_isLogin; }
        }
        private int m_nSession = 0;
        public int Session
        {
            get { return m_nSession; }
        }
        private string m_strUserName = "";
        public string UserName
        {
            get { return m_strUserName; }
        }
        private int m_nUserID = 0;
        public int UserID
        {
            get { return m_nUserID; }
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void bnLogin_Click(object sender, EventArgs e)
        {
            string strHash = GuiAccess.UserHash.HashUserInfo(this.textBoxUser.Text,
                this.maskedTextBoxPW.Text);

            int m_nSession = userMge.Login(this.textBoxUser.Text, strHash);

            if (m_nSession > 0)
            {
                m_strUserName = this.textBoxUser.Text;
                //m_nUserID = userMge.g
                m_isLogin = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed, please check your user name and password.");
            }
           
        }

        private void bnLogout_Click(object sender, EventArgs e)
        {
            userMge.Logout(m_nSession);
            this.Close();
        }

        private void maskedTextBoxPW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.CompareTo('\r') == 0)
            {
                bnLogin_Click(null, null);
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            userMge.Disconnect();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            userMge.ConnectServer();
        }
    }
}
