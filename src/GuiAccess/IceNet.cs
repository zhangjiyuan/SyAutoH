using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GuiAccess
{
    public class IceNet
    {
        private Ice.Communicator communicator = null;
        public Ice.Communicator Communicator
        {
            get { return communicator; }
        }
        public Ice.ObjectPrx m_objectPrx = null;
        public virtual void GetProxy() { }

        private string strProxyKey;
        public string ProxyKey
        {
            get { return strProxyKey; }
            set { strProxyKey = value; }
        }
        private string GetProcessPath()
        {
            string strPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            FileInfo fi = new FileInfo(strPath);
            strPath = fi.DirectoryName;
            return strPath;
        }

        public void ConnectServer()
        {
            try
            {
                Ice.InitializationData initData = new Ice.InitializationData();
                initData.properties = Ice.Util.createProperties();

                string strConfigFile = GetProcessPath() + @"\..\Config\IceClientConfig.txt";
                try
                {
                    initData.properties.load(strConfigFile);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                communicator = Ice.Util.initialize(initData);
                string sProxy = strProxyKey + ".Proxy";
                string strProxy = initData.properties.getProperty(sProxy);
                m_objectPrx = communicator.stringToProxy(strProxy);
            
                GetProxy();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Disconnect()
        {
            if (null != communicator)
            {
                communicator.destroy();
            }
        }
    }
}
