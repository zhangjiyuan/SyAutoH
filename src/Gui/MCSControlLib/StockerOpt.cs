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
    public partial class StockerOpt : UserControl, IMcsControlBase
    {
        public event DataChangeHander DataChange;
        public StockerOpt()
        {
            InitializeComponent();

            if (null != this.DataChange)
            {
                this.DataChange(this, 24);
            }
        }

        private GuiAccess.DataHubCli m_dataHub = null;
        public GuiAccess.DataHubCli DataHub
        {
            set
            {
                m_dataHub = value;
            }
            get
            {
                return m_dataHub;
            }
        }

        public void PageInit()
        {

        }

        public void PageExit()
        {

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
