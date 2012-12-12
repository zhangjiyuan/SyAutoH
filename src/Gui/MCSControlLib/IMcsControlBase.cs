﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuiAccess;

namespace MCSControlLib
{
    public delegate void DataChangeHander(object sender, int nIndex);
    public interface IMcsControlBase
    {
        event DataChangeHander DataChange;

        void ProcessGuiData(List<MCS.GuiDataItem> list);
        GuiAccess.DataHubCli DataHub
        {
            set;
            get;
        }
    }
}
