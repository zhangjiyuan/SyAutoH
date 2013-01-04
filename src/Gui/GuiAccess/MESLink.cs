using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCS;

namespace GuiAccess
{
    public class MESLink : IceNet
    {
        private MESLinkPrx remote = null;

        public override void GetProxy()
        {
            remote = MESLinkPrxHelper.uncheckedCast(m_objectPrx);
        }

        public MESLink()
        {
            ProxyKey = "MESLink";
        }

        public int PlaceFoup(int nBarCode, int nDevID, int nDevType)
        {
             int nRet = 0;
            try
            {
                nRet = remote.PlaceFoup(nBarCode, nDevID, nDevType);
            }
            catch (System.Exception /*ex*/)
            {
            	
            }
           
            return nRet;
        }

        public int PickFoup(int nFoupBarCode, int nDevID, int nDevType)
        {
            int nRet = 0;
            try
            {
                nRet = remote.PickFoup(nFoupBarCode, nDevID, nDevType);
            }
            catch (System.Exception /*ex*/)
            {

            }

            return nRet;
        }

        public int GetFoupLocation(int nFoupBarCode, out int nDevID, out int nDevType)
        {
            int nRet = 0;
            LocFoup location;
            nDevID = 0;
            nDevType = 0;

            try
            {
                location = remote.GetFoup(nFoupBarCode);
                nDevID = location.nDevID;
                nDevType = location.nLocType;
            }
            catch (System.Exception /*ex*/)
            {
                nRet = -1;
            }

            return nRet;
        }
    }
}
