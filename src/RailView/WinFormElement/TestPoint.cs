using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormElement
{
    public partial class TestPoint : Form
    {
        public Int16 offsetOfText = -1;
        public TestPoint()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            if (str != "")
            {
                offsetOfText = Int16.Parse(str);
            }
        }
    }
}
