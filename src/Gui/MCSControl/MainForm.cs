using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCSControl
{
    public partial class MainForm : Form
    {
        private GuiAccess.DataHubCli m_dataHub = new GuiAccess.DataHubCli();
        private int m_nSession = -1;
        public int Session
        {
            get { return m_nSession; }
            set { m_nSession = value; }
        }
        private string m_strUserName = "";
        public string UserName
        {
            get { return m_strUserName; }
            set { m_strUserName = value; }
        }
        private bool m_bNeedLogin = false;
        public bool NeedLogin
        {
            get { return m_bNeedLogin; }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_dataHub.ConnectServer();
            toolStripStatusLabel_User.Text = "Logined User: " + m_strUserName + " ";
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_bNeedLogin = true;
            this.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_bNeedLogin = false;
            this.Close();
        }
    }
}
