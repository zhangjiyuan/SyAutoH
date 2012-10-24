using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCS;

namespace GuiAccess
{
    public sealed class DataHubCallbackI : GuiDataUpdaterDisp_
    {
        public override void UpdateData(string sTag, string sval, Ice.Current current)
        {
            string strTag = sTag;
        }
    }
}
