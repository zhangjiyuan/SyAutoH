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

        private float _radius = 30;
        public float Radius
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

        private float _interval = 20;               //interval between straight and curved
        public float Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }

        private float _lenghtofstr = 30;
        public float LenghtOfStr
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
            _centerdoc = center;
            _direction_cross_l = DIRECTION_CROSS_L.FIRST;
            Point[] points = new Point[2];
            points[0] = new Point(center.X, center.Y + (int)_radius + (int)_interval);
            points[1] = new Point(points[0].X + (int)_lenghtofstr, points[0].Y);
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
            rc.Location = new Point(_centerdoc.X - (int)_radius, _centerdoc.Y - (int)_radius);
            rc.Width = (int)_radius * 2;
            rc.Height = (int)_radius * 2;
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rc, _startangle, _sweepangle);
            Pen pen = new Pen(Color.Black, 1);
            _canvas.DrawPath(pen, gp);
            _canvas.DrawLines(pen, points);
            pen.Dispose();
            gp.Dispose();
        }

        public override void DrawTracker(Graphics _canvas)
        {
            _ObjectCrL.DrawTracker(_canvas, _centerdoc, (int)_radius, _direction_cross_l);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return _ObjectCrL.HitTest(point, isSelected, _centerdoc, (int)_radius, _direction_cross_l, (int)_lenghtofstr, (int)_interval);
        }

        protected override void Translate(int offsetX, int offsetY)
        {
            Point pt = _centerdoc;
            pt.Offset(offsetX, offsetY);
            _centerdoc = pt;
            _ObjectCrL.Translate(offsetX, offsetY);
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            Rectangle rc = _ObjectCrL.Scale(handle, dx, dy, _centerdoc, (int)_radius, _direction_cross_l, (int)_lenghtofstr, (int)_interval);
            switch (_direction_cross_l)
            {
                case DIRECTION_CROSS_L.FIRST:
                    _centerdoc = rc.Location;
                    _lenghtofstr = Math.Abs(PointList[1].X - PointList[0].X);
                    break;
                case DIRECTION_CROSS_L.SECOND:
                    _centerdoc = new Point(rc.Right, rc.Top);
                    _lenghtofstr = Math.Abs(PointList[1].Y - PointList[0].Y);
                    break;
                case DIRECTION_CROSS_L.THIRD:
                    _centerdoc = new Point(rc.Right, rc.Bottom);
                    _lenghtofstr = Math.Abs(PointList[1].X - PointList[0].X);
                    break;
                case DIRECTION_CROSS_L.FOUR:
                    _centerdoc = new Point(rc.Left, rc.Bottom);
                    _lenghtofstr = Math.Abs(PointList[1].Y - PointList[0].Y);
                    break;
            }
            _radius = rc.Width;
        }

        protected override void Rotate(Point pt, Size sz)
        {
            if (0 == _startangle)
            {
                _startangle = 90;
                _direction_cross_l = DIRECTION_CROSS_L.SECOND;
            }
            else if (90 == _startangle)
            {
                _startangle = 180;
                _direction_cross_l = DIRECTION_CROSS_L.THIRD;
            }
            else if (180 == _startangle)
            {
                _startangle = 270;
                _direction_cross_l = DIRECTION_CROSS_L.FOUR;
            }
            else if (270 == _startangle)
            {
                _startangle = 0;
                _direction_cross_l = DIRECTION_CROSS_L.FIRST;
            }
            _ObjectCrL.ChangeDirection(_centerdoc, sz);
        }

        public object Clone()
        {
            CrossLeftEle cl = new CrossLeftEle();
            cl._centerdoc = _centerdoc;
            cl._radius = _radius;
            cl._firstdoc = _firstdoc;
            cl._seconddot = _seconddot;
            cl._startangle = _startangle;
            cl._sweepangle = _sweepangle;
            cl._interval = _interval;
            cl._lenghtofstr = _lenghtofstr;
            cl.PointList.AddRange(PointList);
            cl._direction_cross_l = _direction_cross_l;
            return cl;
        }
    }
}
