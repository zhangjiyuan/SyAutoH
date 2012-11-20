using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RailView
{
    public partial class TestCoordination : Form
    {
        List<RailEle> testCoorList=new List<RailEle>();
        public Int16 offsetOfText = -1;
        public TestCoordination()
        {
            InitializeComponent();
        }

        //private void ReadOffsetNum(int tempSection)
        //{
        //    switch (testCoorList[tempSection].graphType)
        //    {
        //        case 1:
        //            StraightEle strTemp = (StraightEle)testCoorList[tempSection];
        //            offsetRange.Text = "0-" + strTemp.lenght.ToString();
        //            break;
        //        case 2:
        //            CurvedEle curTemp = (CurvedEle)testCoorList[tempSection];
        //            offsetRange.Text = "0-90";
        //            break;
        //        case 3:
        //            CrossEle croTemp = (CrossEle)testCoorList[tempSection];
        //            int tempInteger = croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.X;
        //            offsetRange.Text = "0-" + tempInteger.ToString();
        //            break;
        //        default:
        //            break;
        //    }
        //}

        private void offsetText_TextChanged(object sender, EventArgs e)
        {
           string str = offsetText.Text;
            if (str != "")
            {
                Int16 offset = Int16.Parse(str);
                offsetOfText = offset;
            }
        }
    }
}
