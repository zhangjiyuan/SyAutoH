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
        public  int sectionOfText = -1;
        public int offsetOfText = -1;
        public TestCoordination()
        {
            InitializeComponent();
        }

        public void ReadSectionNum(List<RailEle> tempList)
        {
            int num = tempList.Count-1;
            sectionRange.Text = "0-" + num.ToString();
            testCoorList.AddRange(tempList);
        }

        private void sectionText_TextChanged(object sender, EventArgs e)
        {
            string str = sectionText.Text;
            if (str != "")
            {
                int section = int.Parse(str);
                if (section >= 0 && section < 17)
                {
                    ReadOffsetNum(section);
                    sectionOfText = section;
                }
            }
        }

        private void ReadOffsetNum(int tempSection)
        {
            switch (testCoorList[tempSection].graphType)
            {
                case 1:
                    StraightEle strTemp = (StraightEle)testCoorList[tempSection];
                    offsetRange.Text = "0-" + strTemp.lenght.ToString();
                    break;
                case 2:
                    CurvedEle curTemp = (CurvedEle)testCoorList[tempSection];
                    offsetRange.Text = "0-90";
                    break;
                case 3:
                    CrossEle croTemp = (CrossEle)testCoorList[tempSection];
                    int tempInteger = croTemp.firstPart + croTemp.secPart + croTemp.thPart + croTemp.fourPart.X;
                    offsetRange.Text = "0-" + tempInteger.ToString();
                    break;
                default:
                    break;
            }
        }

        private void offsetText_TextChanged(object sender, EventArgs e)
        {
            string str = offsetText.Text;
            if (str != "")
            {
                int offset = int.Parse(str);
                offsetOfText = offset;
            }
        }
    }
}
