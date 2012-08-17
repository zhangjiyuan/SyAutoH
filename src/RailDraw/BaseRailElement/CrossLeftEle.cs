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
    public class CrossLeftEle : BaseRailEle
    {
        ObjectCrossLeftOp _ObjectCrL = new ObjectCrossLeftOp();
        
        private Point _centerdoc = Point.Empty;
        public Point CenterDoc
        {
            get { return _centerdoc; }
            set { _centerdoc = value; }
        }

        private int _radius = 30;
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        [Browsable(false)]
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

        private int _interval = 20;               //interval between straight and curved
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }

        private int _lenghtofstr = 30;
        public int LenghtOfStr
        {
            get { return _lenghtofstr; }
            set { _lenghtofstr = value; }
        }

        [Browsable(false)]
        public List<Point> PointList
        {
            get { return _ObjectCrL.PointList; }
        }

        public enum DIRECTION_CROSS_L
        {
            FIRST, 
            SECOND, 
            THIRD, 
            FOUR,
            NULL
        }
        private DIRECTION_CROSS_L _direction_cross_l = DIRECTION_CROSS_L.NULL;
        public DIRECTION_CROSS_L DIRECTION_CROSS_L_ATTRIBUTE
        {
            get { return _direction_cross_l; }
            set { _direction_cross_l = value; }
        }

        public CrossLeftEle() { GraphType = 3; }

        public CrossLeftEle CreatEle(Point center, Size size)
        {
            CenterDoc = center;
            DIRECTION_CROSS_L_ATTRIBUTE = DIRECTION_CROSS_L.FIRST;
            Point[] points = new Point[2];
            points[0] = new Point(center.X, center.Y + Radius + Interval);
            points[1] = new Point(points[0].X + LenghtOfStr, points[0].Y);
            PointList.AddRange(points);
            return this;
        }

        public override void Draw(Graphics _canvas)
        {
            if (_canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");
            if (_centerdoc.IsEmpty)
                throw new Exception("对象不存在");
            Point[] points = new Point[2];
            PointList.CopyTo(points);
            Rectangle rc = new Rectangle();
            rc.Location = new Point(CenterDoc.X - Radius, CenterDoc.Y - Radius);
            rc.Width = Radius * 2;
            rc.Height = Radius * 2;
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rc, StartAngle, SweepAngle);
            Pen pen = new Pen(Color.Black, 1);
            _canvas.DrawPath(pen, gp);
            _canvas.DrawLines(pen, points);
            pen.Dispose();
            gp.Dispose();
        }

        public override void DrawTracker(Graphics _canvas)
        {
            _ObjectCrL.DrawTracker(_canvas, CenterDoc, Radius, DIRECTION_CROSS_L_ATTRIBUTE);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return _ObjectCrL.HitTest(point, isSelected, CenterDoc, Radius, DIRECTION_CROSS_L_ATTRIBUTE, LenghtOfStr, Interval);
        }

        protected override void Translate(int offsetX, int offsetY)
        {
            Point pt = CenterDoc;
            pt.Offset(offsetX, offsetY);
            CenterDoc = pt;
            _ObjectCrL.Translate(offsetX, offsetY);
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            Rectangle rc = _ObjectCrL.Scale(handle, dx, dy, CenterDoc, Radius, DIRECTION_CROSS_L_ATTRIBUTE, LenghtOfStr, Interval);
            switch (DIRECTION_CROSS_L_ATTRIBUTE)
            {
                case DIRECTION_CROSS_L.FIRST:
                    CenterDoc = rc.Location;
                    LenghtOfStr = Math.Abs(PointList[1].X - PointList[0].X);
                    break;
                case DIRECTION_CROSS_L.SECOND:
                    CenterDoc = new Point(rc.Right, rc.Top);
                    LenghtOfStr = Math.Abs(PointList[1].Y - PointList[0].Y);
                    break;
                case DIRECTION_CROSS_L.THIRD:
                    CenterDoc = new Point(rc.Right, rc.Bottom);
                    LenghtOfStr = Math.Abs(PointList[1].X - PointList[0].X);
                    break;
                case DIRECTION_CROSS_L.FOUR:
                    CenterDoc = new Point(rc.Left, rc.Bottom);
                    LenghtOfStr = Math.Abs(PointList[1].Y - PointList[0].Y);
                    break;
            }
            Radius = rc.Width;
        }

        protected override void Rotate(Point pt, Size sz)
        {
            if (0 == StartAngle)
            {
                StartAngle = 90;
                DIRECTION_CROSS_L_ATTRIBUTE = DIRECTION_CROSS_L.SECOND;
            }
            else if (90 == StartAngle)
            {
                StartAngle = 180;
                DIRECTION_CROSS_L_ATTRIBUTE = DIRECTION_CROSS_L.THIRD;
            }
            else if (180 == _startangle)
            {
                StartAngle = 270;
                DIRECTION_CROSS_L_ATTRIBUTE = DIRECTION_CROSS_L.FOUR;
            }
            else if (270 == _startangle)
            {
                StartAngle = 0;
                DIRECTION_CROSS_L_ATTRIBUTE = DIRECTION_CROSS_L.FIRST;
            }
            _ObjectCrL.ChangeDirection(CenterDoc, sz);
        }

        public object Clone()
        {
            CrossLeftEle cl = new CrossLeftEle();
            cl.CenterDoc = CenterDoc;
            cl.Radius = Radius;
            cl.FirstDoc = FirstDoc;
            cl.SecondDot = SecondDot;
            cl.StartAngle = StartAngle;
            cl.SweepAngle = SweepAngle;
            cl.Interval = Interval;
            cl.LenghtOfStr = LenghtOfStr;
            cl.PointList.AddRange(PointList);
            cl.DIRECTION_CROSS_L_ATTRIBUTE = DIRECTION_CROSS_L_ATTRIBUTE;
            return cl;
        }
    }
}
