using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuiAccess;

namespace MCSControlLib
{
    public interface IMcsControlBase
    {
        void ProcessGuiData(List<MCS.GuiDataItem> list);
        GuiAccess.DataHubCli DataHub
        {
            set;
            get;
        }
    }
}
