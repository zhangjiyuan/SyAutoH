using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCS;

namespace GuiAccess
{
    public class DataHubCli : IceNet
    {
        private GuiDataHubPrx remote = null;
        private GuiDataUpdaterPrx dataCallback = null;
        public DataHubCli()
        {
            ProxyKey = "DataHub";
        }

        public override void GetProxy()
        {
            remote = GuiDataHubPrxHelper.uncheckedCast(m_objectPrx);

            Ice.ObjectAdapter adapter = Communicator.createObjectAdapter("DataHubCB");
            adapter.add(new DataHubCallbackI(), Communicator.stringToIdentity("callbackReceiver"));
            adapter.activate();

            dataCallback = GuiDataUpdaterPrxHelper.uncheckedCast(
                                           adapter.createProxy(Communicator.stringToIdentity("callbackReceiver")));
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
