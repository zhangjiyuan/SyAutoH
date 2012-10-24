using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCS;

namespace GuiAccess
{
    public delegate void DataChangeHander(string sTag, string sVal);
    public sealed class DataHubCallbackI : GuiDataUpdaterDisp_
    {
        public event DataChangeHander DataChange;
        //public override void UpdateData(string sTag, string sval, Ice.Current current)
        //{
        //    string strTag = sTag;
        //    if (null != this.DataChange)
        //    {
        //        this.DataChange(strTag, sval);
        //    }
        //}

        public override void UpdateData_async(MCS.AMD_GuiDataUpdater_UpdateData updater, 
            string sTag, string sVal, Ice.Current current)
        {
            updater.ice_response();
             if (null != this.DataChange)
             {
                 this.DataChange(sTag, sVal);
             }
        }
       
    }
}
