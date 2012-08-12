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
using System.Windows.Forms;

namespace BaseRailElement
{
    public class StraightRailEle : BaseRailEle
    {
        private ObjectStraightOp _ObjectStaightOp = new ObjectStraightOp();
        private Pen pen = new Pen(Color.Black, 1);

        private int _lenght = 100;
        public int Lenght
        {
            get { return _lenght; }
            set { _lenght = value; }
        }

        [Browsable(false)]
        public List<Point> PointList
        {
            get { return _ObjectStaightOp.PointList; }
        }

        public StraightRailEle() { GraphType = 1; }

        public StraightRailEle CreatEle(Point pt, Size size)
        {
            Point pt1 = new Point(0, 0);
            Point pt2 = new Point(0, 0);
            if ((pt.X + _lenght) > size.Width)
            {
                pt1 = new Point(pt.X - (int)_lenght, pt.Y);
                pt2 = new Point(pt.X, pt.Y);
            }
            else
            {
                pt1 = new Point(pt.X, pt.Y);
                pt2 = new Point(pt.X + (int)_lenght, pt.Y);
            }
            PointList.Add(pt1);
            PointList.Add(pt2);
            return this;
        }

        public override void Draw(Graphics _canvas)
        {
            if (_canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");

            if (PointList.Count < 2)
                throw new Exception("绘制线条的点至少需要2个");
            int n = PointList.Count;
            Point[] points = new Point[n];
            PointList.CopyTo(points);
            if (points[0].Y == points[1].Y)
            {
                if (_lenght != Math.Abs(points[0].X - points[1].X))
                {
                    if (points[0].X < points[1].X)
                    {
                        points[1].X = points[0].X + _lenght;
                    }
                    else
                    {
                        points[1].X = points[0].X - _lenght;
                    }
                }
            }
            else if (points[0].X == points[1].X)
            {
                if (_lenght != Math.Abs(points[0].Y - points[1].Y))
                {
                    points[1].Y = points[0].Y + _lenght;
                }
            }
            PointList.Clear();
            PointList.AddRange(points);

            _canvas.DrawLines(pen, points);
        }

        public override void DrawTracker(Graphics _canvas)
        {
            _ObjectStaightOp.DrawTracker(_canvas);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return _ObjectStaightOp.HitTest(point, isSelected);
        }

        protected override void Translate(int offsetX, int offsetY)
        {
            _ObjectStaightOp.Translate(offsetX, offsetY);
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            _lenght = _ObjectStaightOp.Scale(handle, dx, dy, _lenght);
        }

        protected override void Rotate(Point pt, Size sz)
        {
            _ObjectStaightOp.ChangeDirection(pt, sz);
        }

        public object Clone()
        {
            StraightRailEle cl = new StraightRailEle();
            cl.pen = pen;
            cl.PointList.AddRange(PointList);
            cl._lenght = _lenght;
            return cl;
        }
    }
}
