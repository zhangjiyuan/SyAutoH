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
        public event DataChangeHander DataChange;
        public pageStockerOpt()
        {
            InitializeComponent();

            if (null != this.DataChange)
            {
                this.DataChange(this, 24);
            }
        }

        public void ProcessGuiData(List<MCS.GuiDataItem> list)
        {
            foreach (MCS.GuiDataItem item in list)
            {
                //ProcessGuiDataItem(item);
            }
        }
    }
}
