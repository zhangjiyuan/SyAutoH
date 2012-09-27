using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserTest
{
    public partial class FormUserPassword : Form
    {
        public FormUserPassword()
        {
            InitializeComponent();
        }

        private string strPassword = "";
        private string strOldPassword = "";
        public string OldPassword
        {
            get { return strOldPassword; }
        }
        public string NewPassword
        {
            get { return strPassword; }
        }
        private void bnAccept_Click(object sender, EventArgs e)
        {
            if (this.textBoxNewPW.Text.CompareTo(this.textBoxPWAgain.Text) != 0)
            {
                MessageBox.Show("Passwords is not same.");
                return;
            }
            strOldPassword = this.textBoxOldPW.Text;
            strPassword = this.textBoxPWAgain.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {

        }

        public void SetData(string strUser)
        {
            this.textBoxUserName.Text = strUser;
        }
    }
}
