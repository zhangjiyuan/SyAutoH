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
    class CrossRailEle : BaseRailEle
    {
        private float _lenghtofstr = 10;
        public float LenghtOfStr
        {
            get { return _lenghtofstr; }
            set { _lenghtofstr = value; }
        }

        private float _lenghtofcur = 10;
        public float LenghtOfCur
        {
            get { return _lenghtofcur; }
            set { _lenghtofcur = value; }
        }

        private Point _centerdoc = Point.Empty;
        public Point CenterDoc
        {
            get { return _centerdoc; }
            set { _centerdoc = value; }
        }

        private float _radius = 10;
        public float Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        private Point _firstdoc = Point.Empty;
        public Point FirstDoc
        {
            get { return _firstdoc; }
            set { _firstdoc = value; }
        }

        private Point _seconddot = Point.Empty;
        public Point SecondDot
        {
            get { return _seconddot; }
            set { _seconddot = value; }
        }

        private bool _mirror = false;
        public bool Mirror
        {
            get { return _mirror; }
            set { _mirror = value; }
        }
        public void CreatEle(Point pt)
        {
            ;
        }
    }
}
