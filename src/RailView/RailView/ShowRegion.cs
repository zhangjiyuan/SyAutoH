using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RailView
{
    public partial class ShowRegion : UserControl
    {
        private ReadRailInfo readRailInfo = new ReadRailInfo();
        public ShowRegion()
        {
            InitializeComponent();
            readRailInfo.OpenFile();
        }
    }
}
