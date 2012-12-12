using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MCS.GuiHub;

namespace MCSControlLib
{
    public partial class pageSTKInfo : baseControlPage, IMcsControlBase
    {
       

        public pageSTKInfo()
        {
            InitializeComponent();

            if (null != this.DataChange)
            {
                this.DataChange(this, 23);
            }
        }

        public event DataChangeHander DataChange;

        public override void PageInit()
        {
            PushData[] cmds = new PushData[] { PushData.upStkInfo };
            m_dataHub.Async_SetPushCmdList(cmds);
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
