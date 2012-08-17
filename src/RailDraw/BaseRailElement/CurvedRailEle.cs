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
    public class CurvedRailEle : BaseRailEle
    {
        private ObjectCurvedOp _ObjectCurved = new ObjectCurvedOp();
        
        private Point _centerdoc = Point.Empty;
        public Point CenterDoc
        {
            get { return _centerdoc; }
            set { _centerdoc = value; }
        }

        private int _radius = 50;
        public int Radius
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

        private int _startangle = 0;
        public int StartAngle
        {
            get { return _startangle; }
            set { _startangle = value; }
        }

        private int _sweepangle = 90;
        private int SweepAngle
        {
            get { return _sweepangle; }
            set { _sweepangle = value; }
        }

        public enum DIRECTION_CURVED
        {
            FIRST, 
            SECOND, 
            THIRD, 
            FOUR,
            NULL
        }
        private DIRECTION_CURVED _direction_curved = DIRECTION_CURVED.NULL;
        public DIRECTION_CURVED DIRECTION_CURVED_ATTRIBUTE
        {
            get { return _direction_curved; }
            set { _direction_curved = value; }
        }

        public CurvedRailEle() { GraphType = 2; }

        public CurvedRailEle CreatEle(Point center, Size size)
        {
           CenterDoc = center;
            DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.FIRST;
            Point pt_first = new Point();
            Point pt_sec = new Point();
            pt_first.X = center.X + Radius;
            pt_first.Y = center.Y;
            pt_sec.X = center.X;
            pt_sec.Y = center.Y + Radius;
            FirstDoc = pt_first;
            SecondDot = pt_sec;
            return this;
        }

        public override void Draw(Graphics _canvas)
        {
            if (_canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");
            if (_centerdoc.IsEmpty)
                throw new Exception("对象不存在");
            Rectangle rc = new Rectangle();
            rc.Location = new Point(CenterDoc .X - Radius, CenterDoc.Y - Radius);
            rc.Width = Radius * 2;
            rc.Height = Radius * 2;
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rc, StartAngle, SweepAngle);
            Pen pen = new Pen(Color.Black, 1);
            _canvas.DrawPath(pen, gp);
            pen.Dispose();
            gp.Dispose();
        }

        public override void DrawTracker(Graphics _canvas)
        {
            _ObjectCurved.DrawTracker(_canvas, CenterDoc, Radius, DIRECTION_CURVED_ATTRIBUTE);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return _ObjectCurved.HitTest(point, isSelected, CenterDoc, Radius, DIRECTION_CURVED_ATTRIBUTE);
        }

        protected override void Translate(int offsetX, int offsetY)
        {
            Point pt = CenterDoc;
            pt.Offset(offsetX, offsetY);
            CenterDoc = pt;
            pt = FirstDoc;
            pt.Offset(offsetX, offsetY);
            FirstDoc = pt;
            pt = SecondDot;
            pt.Offset(offsetX, offsetY);
            SecondDot = pt;
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            Point pt_first = new Point(FirstDoc.X, FirstDoc.Y);
            Point pt_sec = new Point(SecondDot.X, SecondDot.Y);
            Rectangle rc = _ObjectCurved.Scale(handle, dx, dy, CenterDoc, Radius, DIRECTION_CURVED_ATTRIBUTE);
            CenterDoc = rc.Location;
            Radius = rc.Width;
            switch (DIRECTION_CURVED_ATTRIBUTE)
            {
                case DIRECTION_CURVED.FIRST:
                    pt_first.X = CenterDoc.X + Radius;
                    pt_first.Y = CenterDoc.Y;
                    pt_sec.X = CenterDoc.X;
                    pt_sec.Y = CenterDoc.Y + Radius;
                    break;
                case DIRECTION_CURVED.SECOND:
                    pt_first.X = CenterDoc.X;
                    pt_first.Y = CenterDoc.Y + Radius;
                    pt_sec.X = CenterDoc.X - Radius;
                    pt_sec.Y = CenterDoc.Y;
                    break;
                case DIRECTION_CURVED.THIRD:
                    pt_first.X = CenterDoc.X - Radius;
                    pt_first.Y = CenterDoc.Y;
                    pt_sec.X = CenterDoc.X;
                    pt_sec.Y = CenterDoc.Y - Radius;
                    break;
                case DIRECTION_CURVED.FOUR:
                    pt_first.X = CenterDoc.X;
                    pt_first.Y = CenterDoc.Y - Radius;
                    pt_sec.X = CenterDoc.X + Radius;
                    pt_sec.Y = CenterDoc.Y;
                    break;
                case DIRECTION_CURVED.NULL:
                    break;
            }
            FirstDoc = pt_first;
            SecondDot = pt_sec;
        }

        protected override void Rotate(Point pt, Size sz)
        {
            Point pt_first = new Point(FirstDoc.X, FirstDoc.Y);
            Point pt_sec = new Point(SecondDot.X, SecondDot.Y);
            switch (StartAngle)
            {
                case 0:
                    StartAngle = 90;
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.SECOND;
                    pt_first.X = CenterDoc.X;
                    pt_first.Y = CenterDoc.Y + Radius;
                    pt_sec.X = CenterDoc.X - Radius;
                    pt_sec.Y = CenterDoc.Y;
                    break;
                case 90:
                    StartAngle = 180;
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.THIRD;
                    pt_first.X = CenterDoc.X - Radius;
                    pt_first.Y = CenterDoc.Y;
                    pt_sec.X = CenterDoc.X;
                    pt_sec.Y = CenterDoc.Y - Radius;
                    break;
                case 180:
                    StartAngle = 270;
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.FOUR;
                    pt_first.X = CenterDoc.X;
                    pt_first.Y = CenterDoc.Y - Radius;
                    pt_sec.X = CenterDoc.X + Radius;
                    pt_sec.Y = CenterDoc.Y;
                    break;
                case 270:
                    StartAngle = 0;
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.FIRST;
                    pt_first.X = CenterDoc.X + Radius;
                    pt_first.Y = CenterDoc.Y;
                    pt_sec.X = CenterDoc.X;
                    pt_sec.Y = CenterDoc.Y + Radius;
                    break;
            }
            FirstDoc = pt_first;
            SecondDot = pt_sec;
        }

        public object Clone()
        {
            CurvedRailEle cl = new CurvedRailEle();
            cl.CenterDoc = CenterDoc;
            cl.Radius = Radius;
            cl.FirstDoc = FirstDoc;
            cl.SecondDot = SecondDot;
            cl.StartAngle = StartAngle;
            cl.SweepAngle = SweepAngle;
            cl.DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED_ATTRIBUTE;
            return cl;
        }

        public override void ChangePropertyValue()
        {
            base.ChangePropertyValue();
            CenterDoc = _ObjectCurved.ChangePropertyValue(CenterDoc, FirstDoc, SecondDot, Radius);
        }
    }
}
