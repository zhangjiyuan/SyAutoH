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
    public partial class FormNewUser : Form
    {
        public FormNewUser()
        {
            InitializeComponent();
        }

        private string strName;
        public string StrName
        {
            get { return strName; }
        }
        private string strPassword;
        public string StrPassword
        {
            get { return strPassword; }
        }
        private int nRight;
        public int NRight
        {
            get { return nRight; }
        }
        private void bnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bnAccept_Click(object sender, EventArgs e)
        {
            if (this.textBoxNewUser.Text.Length <= 0)
            {
                MessageBox.Show("Please set User Name.");
                return;
            }
            if (this.textBoxNewPassword.Text.CompareTo(this.textBoxPWagain.Text) == 0)
            {
                strName = this.textBoxNewUser.Text;
                strPassword = this.textBoxPWagain.Text;
                nRight = this.comboBoxUserRight.SelectedIndex;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("New PW and PW again are not same.");
            }
           
        }
    }
}
