using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCS;

namespace GuiAccess
{
    public delegate void DataUpdaterHander(string sTag, string sVal);
    public class DataHubCli : IceNet
    {
        private GuiDataHubPrx remote = null;
        private GuiDataUpdaterPrx dataCallback = null;
        private DataHubCallbackI dataHubCB = null;
        public event DataUpdaterHander DataUpdater;
        public DataHubCli()
        {
            ProxyKey = "DataHub";
        }

        public override void GetProxy()
        {
            remote = GuiDataHubPrxHelper.uncheckedCast(m_objectPrx);

           dataHubCB = new DataHubCallbackI();
           dataHubCB.DataChange += new DataChangeHander(CallBack);
            Ice.ObjectAdapter adapter = Communicator.createObjectAdapter("DataHubCB");
            adapter.add(dataHubCB, Communicator.stringToIdentity("callbackReceiver"));
            adapter.activate();

            dataCallback = GuiDataUpdaterPrxHelper.uncheckedCast(
                                           adapter.createProxy(Communicator.stringToIdentity("callbackReceiver")));
        }

        public void CallBack(string sTag, string sVal)
        {
            if (null != this.DataUpdater)
            {
                this.DataUpdater(sTag, sVal);
            }
        }

        public int WriteData(string strCmd, string sVal, int nSession)
        {
            int nRet = -1;
            try
            {
                nRet = remote.WriteData(strCmd, sVal, nSession);
            }
            catch (System.Exception /*ex*/)
            {

            }

            return nRet;
        }

        public string ReadData(string strCmd, int nSession)
        {
            string strRet = "";
            try
            {
                strRet = remote.ReadData(strCmd, nSession);
            }
            catch (System.Exception /*ex*/)
            {

            }

            return strRet;
        }

        public void SetCallBack()
        {
            try
            {
                remote.SetDataUpdater(dataCallback);
            }
            catch (System.Exception /*ex*/)
            {

            }
        }
    }
}
