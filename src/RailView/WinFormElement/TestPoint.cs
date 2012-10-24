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
        List<RailEle> testCoorList = new List<RailEle>();
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
                Int16 offset = Int16.Parse(str);
                offsetOfText = offset;
            }
        }
    }
}
