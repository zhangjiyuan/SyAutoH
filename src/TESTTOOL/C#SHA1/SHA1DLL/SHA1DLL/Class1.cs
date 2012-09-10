using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace SHA1DLL
{
    public class Class1
    {
        public string SHA1Transform(string inMessage)
        {
            string outMessage;
            SHA1 sha = new SHA1CryptoServiceProvider();
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] dataToHash = enc.GetBytes(inMessage);
            byte[] dataHash = sha.ComputeHash(dataToHash);
            outMessage = BitConverter.ToString(dataHash);
            outMessage = outMessage.Replace("-", "");
            return outMessage;
        }
        public string HashLoginInfo(string sName, string sHighMark, string sLowMark, string sPassword)
        {
            string infoInHash;
            char firstWord;
            sName = sName.ToLower();
            firstWord =sName[0];
            char[] last = new char[4];
            for(int i=0;i<4;i++)
            {
                last[3-i] = (char)(((firstWord>>i)&0x00000001)+'\0');
            }
            string middle="";
            for (int i = 0; i < 4; i++)
            {
                if (last[i] == 0)
                    middle += sLowMark;
                else
                    middle += sHighMark;
            }
            string messageInfo=sName+middle+sPassword;
            infoInHash=SHA1Transform(messageInfo);
            return infoInHash;
        }

    }
}
