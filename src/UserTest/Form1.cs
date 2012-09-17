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
        private MESLink mesLink = new MESLink();
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
            mesLink.ConnectServer();
        }

        private void bnNewUser_Click(object sender, EventArgs e)
        {
            int nRet = userMge.CreateUser(this.textBoxUser.Text,
                this.maskedTextBoxPW.Text, 3);
            if (0 == nRet)
            {
                MessageBox.Show("Success create user.");
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
    }
}
