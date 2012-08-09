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
    public class CurvedRailEle:BaseRailEle
    {
        private ObjectCurvedOp _ObjectCurved = new ObjectCurvedOp();
        private int _direction = 0;
        private Point _centerdoc = Point.Empty;
        public Point CenterDoc
        {
            get { return _centerdoc; }
            set { _centerdoc = value; }
        }

        private float _radius = 50;
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

        [Browsable(false)]
        private int _startangle = 0;
        private int StartAngle
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

        public CurvedRailEle() { GraphType = 2; }

        public CurvedRailEle CreatEle(Point center, Size size)
        {
            _centerdoc = center;

//            Rectangle rc = new Rectangle(center.X, center.Y, (int)_radius, (int)_radius);
            
            return this;
        }

        public override void Draw(Graphics _canvas)
        {
            if (_canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");
            if (_centerdoc.IsEmpty)
                throw new Exception("对象不存在");
            Rectangle rc = new Rectangle();
//            if (_startangle == 0)
//            {
                rc.Location = new Point(_centerdoc.X - (int)_radius, _centerdoc.Y - (int)_radius);
                rc.Width = (int)_radius*2;
                rc.Height = (int)_radius*2;
//            }
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rc, _startangle, _sweepangle);
            Pen pen = new Pen(Color.Black, 1);
            _canvas.DrawPath(pen, gp);
            pen.Dispose();
            gp.Dispose();
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return _ObjectCurved.HitTest(point, isSelected, _centerdoc, (int)_radius, _direction);
        }

        public override void DrawTracker(Graphics _canvas)
        {
            _ObjectCurved.DrawTracker(_canvas, _centerdoc, (int)_radius, _direction);
        }
        
        protected override void Translate(int offsetX, int offsetY)
        {
            _centerdoc.Offset(offsetX, offsetY);
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            Rectangle rc = _ObjectCurved.Scale(handle, dx, dy, _centerdoc, (int)_radius, _direction);
            _centerdoc = rc.Location;
            _radius = rc.Width;
        }

        protected override void Rotate(Point pt, Size sz)
        {
            if (0 == _startangle)
            {
                _startangle = 90;
                _direction = 1;
            }
            else if (90 == _startangle)
            {
                _startangle = 180;
                _direction = 2;
            }
            else if (180 == _startangle)
            {
                _startangle = 270;
                _direction = 3;
            }
            else if (270 == _startangle)
            {
                _startangle = 0;
                _direction = 0;
            }
        }
    }
}
