using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MCS;

namespace GuiAccess
{
    public class UserCli
    {
        private Ice.Communicator communicator = null;
        private UserManagementPrx remote = null;

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
                string strProxy = initData.properties.getProperty("UserAce.Proxy");
                remote =
                    UserManagementPrxHelper.uncheckedCast(communicator.stringToProxy(strProxy));
                remote.ice_timeout(1000);
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

        public int Login(string sName, string sHash)
        {
            int nRet = 0;
            try
            { 
                nRet = remote.Login(sName, sHash);
            }
            catch (System.Exception /*ex*/)
            {
            	
            }
           
            return nRet;
        }
    }
}
