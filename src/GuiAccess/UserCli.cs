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

        public int Logout(int nUser)
        {
            int nRet = 0;
            try
            {
                nRet = remote.Logout(nUser);
            }
            catch (System.Exception /*ex*/)
            {
            	
            }
            return nRet;
        }

        public int CreateUser(string user, string pass, int session)
        {
            int nRet = 0;
            try
            {
                nRet = remote.CreateUser(user, pass, session);
            }
            catch (System.Exception /*ex*/)
            {

            }
            return nRet;
        }

        public int DeleteUser(int nUID, int session)
        {
            int nRet = 0;
            try
            {
                nRet = remote.DeleteUser(nUID, session);
            }
            catch (System.Exception /*ex*/)
            {

            }
            return nRet;
        }

        public MCS.User[] GetUserList(int nBegin, int nCount)
        {
            try
            {
                return remote.GetUserList(nBegin, nCount);
            }
            catch (System.Exception /*ex*/)
            {

            }
            return null;
        }
        public int GetUserCount()
        {
            int nRet = 0;
            try
            {
                nRet = remote.GetUserCount();
            }
            catch (System.Exception /*ex*/)
            {

            }
            return nRet;
        }
        public int SetUserPW(int nUID, string pass, int session)
        {
            int nRet = 0;
            try
            {
                nRet = remote.SetUserPW(nUID, pass, session);
            }
            catch (System.Exception /*ex*/)
            {

            }
            return nRet;
        }
        int SetUserRight(int nUID, int nRight, int session)
        {
            int nRet = 0;
            try
            {
                nRet = remote.SetUserRight(nUID, nRight, session);
            }
            catch (System.Exception /*ex*/)
            {

            }
            return nRet;
        }
    }
}
