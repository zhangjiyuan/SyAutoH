using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MCS.GuiHub;

namespace MCSControlLib
{
    public partial class baseControlPage : UserControl
    {
        protected GuiAccess.DataHubCli m_dataHub = null;
        
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

        public virtual void PageInit()
        {

        }

        public virtual void PageExit()
        {
            PushData[] cmds = new PushData[] { };
            m_dataHub.Async_SetPushCmdList(cmds);
        }
    }
}
