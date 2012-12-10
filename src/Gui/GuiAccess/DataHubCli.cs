using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using MCS;

namespace GuiAccess
{
    public delegate void DataUpdaterHander(GuiDataItem item);
    public class DataHubCli : IceNet
    {
        private GuiDataHubPrx remote = null;
        private int m_nSession = 0;
        private GuiDataUpdaterPrx dataCallback = null;
        private DataHubCallbackI dataHubCB = null;
        private DateTime m_updateTime = DateTime.Now;
        public System.DateTime UpdateTime
        {
            get { return m_updateTime; }
        }
        public int Session
        {
            get { return m_nSession; }
            set { m_nSession = value; }
        }

        public event DataUpdaterHander DataUpdater;
        public DataHubCli()
        {
            ProxyKey = "DataHub";
        }

        public override void Disconnect()
        {
            remote.begin_EraseDataUpdater(dataCallback);
            base.Disconnect();
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

        public void CallBack(GuiDataItem item)
        {
            if (null != this.DataUpdater)
            {
                m_updateTime = DateTime.Now;
                this.DataUpdater(item);
            }
        }

        public void Async_WriteData(MCS.GuiHub.GuiCommand nCmd, string sVal, int nSession)
        {
            try
            {
                remote.begin_WriteData(nCmd, sVal, nSession);
            }
            catch (System.Exception /*ex*/)
            {

            }
        }

        public void Async_WriteData(MCS.GuiHub.GuiCommand nCmd, string sVal)
        {
            try
            {
                remote.begin_WriteData(nCmd, sVal, m_nSession);
            }
            catch (System.Exception /*ex*/)
            {

            }
        }

        public int WriteData(MCS.GuiHub.GuiCommand nCmd, string sVal, int nSession)
        {
            int nRet = -1;
            try
            {
                nRet = remote.WriteData(nCmd, sVal, nSession);
            }
            catch (System.Exception /*ex*/)
            {

            }

            return nRet;
        }

        public int WriteData(MCS.GuiHub.GuiCommand nCmd, string sVal)
        {
            int nRet = -1;
            try
            {
                nRet = remote.WriteData(nCmd, sVal, m_nSession);
            }
            catch (System.Exception /*ex*/)
            {

            }

            return nRet;
        }

        public string ReadData(MCS.GuiHub.GuiCommand nCmd, int nSession)
        {
            string strRet = "";
            try
            {
                strRet = remote.ReadData(nCmd, nSession);
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

        public void Async_SetCallBack()
        {
            try
            {
                remote.begin_SetDataUpdater(dataCallback);
            }
            catch (System.Exception /*ex*/)
            {

            }
        }

        static public ArrayList ConvertToArrayList(string strVal)
        {
            ArrayList list = new ArrayList();

            string strSplit = "<>";
            char[] spliter = strSplit.ToCharArray();
            string[] strItem = strVal.Split(spliter);
            foreach (string strDataGroup in strItem)
            {
                if (strDataGroup.Length > 0)
                {
                    ArrayList alData = new ArrayList();
                    string[] strParams = strDataGroup.Split(',');
                    foreach (string spV in strParams)
                    {
                        alData.Add(spV);
                    }
                    list.Add(alData);
                }
            }

            return list;
        }
    }
}
