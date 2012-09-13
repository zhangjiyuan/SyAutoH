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

        private UserCli userMge = new UserCli();
        private void bnLogin_Click(object sender, EventArgs e)
        {
            string strHash = UserHash.HashUserInfo(this.textBoxUser.Text,
                this.maskedTextBoxPW.Text);
            this.labelHashUser.Text = strHash;
            userMge.Login(this.textBoxUser.Text, strHash);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userMge.ConnectServer();
        }
    }
}
