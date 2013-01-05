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
    public partial class pageLogOnline : baseControlPage, IMcsControlBase
    {
        private LogWinClientCS.LogWinClient logClient = new LogWinClientCS.LogWinClient();
        private System.Windows.Forms.Timer timer1;
        private event EventHandler UpdateList;
        private event EventHandler GetNowMsg;
        private int m_nQueryType = 0;
        public pageLogOnline()
        {
            InitializeComponent();
            UpdateList += new EventHandler(EvUpdate);
            GetNowMsg += new EventHandler(Form1_GetNowMsg);
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void bnPause_Click(object sender, EventArgs e)
        {

        }
        class InfoCall
        {
            public int nStart = 0;
            public int nCount = 0;
            public int[] types = null;
            public int[] ids = null;
        };
    }
}
