using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCSControlLib
{
    public partial class OhtInfoData
    {
        private int nID;
        public int ID
        {
            get { return nID; }
            set { nID = value; }
        }
        private long nPosition;
        public long Position
        {
            get { return nPosition; }
            set { nPosition = value; }
        }
        private int nHand;
        public int Hand
        {
            get { return nHand; }
            set { nHand = value; }
        }
        private int nStatus;
        public int Status
        {
            get { return nStatus; }
            set { nStatus = value; }
        }
        private int nAlarm;
        public int Alarm
        {
            get { return nAlarm; }
            set { nAlarm = value; }
        }
        private string strTcpInfo;
        public string TcpInfo
        {
            get { return strTcpInfo; }
            set { strTcpInfo = value; }
        }
    }

    public partial class TryConver
    {
        static public byte ToByte(string value)
        {
            byte byteValue = 0;
            try
            {
                byteValue = System.Convert.ToByte(value);
            }
            catch (System.Exception /*ex*/)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                byteValue = 0;
            }
            return byteValue;
        }

        static public int ToInt32(string value)
        {
            int intValue = 0;
            try
            {
                intValue = System.Convert.ToInt32(value);
            }
            catch (System.Exception /*ex*/)
            {
                intValue = 0;
            }
            return intValue;
        }
    }
}
