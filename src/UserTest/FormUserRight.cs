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
    public partial class FormUserRight : Form
    {
        public FormUserRight()
        {
            InitializeComponent();
        }

        private int nUserRight = 0;
        public int UserRight
        {
            get { return nUserRight; }
        }
        private void bnAccept_Click(object sender, EventArgs e)
        {
            nUserRight = this.comboBoxUserRight.SelectedIndex;
            this.DialogResult = DialogResult.OK;
        }

        public void SetData(string strUser, int nRight)
        {
            this.textBoxUserName.Text = strUser;
            this.comboBoxUserRight.SelectedIndex = nRight;
            string strRight = this.comboBoxUserRight.SelectedItem.ToString();
            this.textBoxOldRight.Text = strRight;
        }
    }
}
