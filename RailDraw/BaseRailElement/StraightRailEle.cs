using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BaseRailElement
{
    class StraightRailEle : BaseRailEle
    {
        private float _lenght = 10;
        public float Lenght
        {
            get { return _lenght; }
            set { _lenght = value; }
        }

        public void CreatEle(Point pt)
        {
            ;
        }
    }
}
