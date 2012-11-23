using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MCSControlLib;

namespace MCSControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GuiAccess.UserCli userLink = new GuiAccess.UserCli();
            userLink.ConnectServer();
            bool bNeedLogin = true;
            while (true == bNeedLogin)
            {
                LoginForm login = new LoginForm();
                login.UserManagement = userLink;
                login.ShowDialog();
                if (login.IsLogin == false)
                {
                    this.Close();
                    bNeedLogin = false;
                }
                else
                {
                    MainForm mainForm = new MainForm();
                    mainForm.UserName = login.UserName;
                    mainForm.Session = login.Session;
                    mainForm.ShowDialog();
                    userLink.Logout(mainForm.Session);
                    bNeedLogin = mainForm.NeedLogin;
                }
            }
            
            userLink.Disconnect();
            this.Close();
        }
    }
}
