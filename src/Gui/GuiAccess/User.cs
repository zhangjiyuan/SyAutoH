using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GuiAccess
{
    public static class UserHash
    {
        //service interface
        [DllImport("cypAce.dll", EntryPoint = "CypHashUserInfo", 
            CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern string HashUserInfo(string name, string pw);
    }
}
