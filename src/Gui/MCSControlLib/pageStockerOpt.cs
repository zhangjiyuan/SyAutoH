using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCSControlLib
{
    public partial class pageStockerOpt : baseControlPage, IMcsControlBase
    {
        public pageStockerOpt()
        {
            InitializeComponent();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void bnAlarmHistory_Click(object sender, EventArgs e)
        {
            formSTKAlarmHistory hisAlarm = new formSTKAlarmHistory();
            hisAlarm.ShowDialog();
        }

        private void bnFoupHistory_Click(object sender, EventArgs e)
        {
            formSTKFoupHistory hisFoup = new formSTKFoupHistory();
            hisFoup.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
