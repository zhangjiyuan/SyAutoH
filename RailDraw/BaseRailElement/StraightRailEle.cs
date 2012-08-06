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
        private float _lenght = 100;
        public float Lenght
        {
            get { return _lenght; }
            set { _lenght = value; }
        }

        [Browsable(false)]
        public List<Point> PointList
        {
            get { return _ObjectStaightOp.PointList; }
        }

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
            Point[] points = new Point[PointList.Count];

            PointList.CopyTo(points);

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
            _ObjectStaightOp.Scale(handle, dx, dy);
        }
    }
}
