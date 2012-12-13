using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCS;

namespace GuiAccess
{
    public delegate void DataChangeHander(long lTime, GuiDataItem item);
    public sealed class DataHubCallbackI : GuiDataUpdaterDisp_
    {
        public event DataChangeHander DataChange;

        public override void UpdateData_async(MCS.AMD_GuiDataUpdater_UpdateData updater, 
            long lTime,
            GuiDataItem data, Ice.Current current)
        {
            updater.ice_response();
             if (null != this.DataChange)
             {
                 this.DataChange(lTime, data);
             }
        }
       
    }
}
