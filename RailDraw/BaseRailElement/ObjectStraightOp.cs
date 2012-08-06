using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BaseRailElement
{
    public class ObjectStraightOp
    {
        private List<Point> _pointList = new List<Point>();
        public List<Point> PointList
        {
            get { return _pointList; }
            set { _pointList = value; }
        }

        public void DrawTracker(Graphics canvas)
        {
            if (canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");

            int n = _pointList.Count;
            Point[] points = new Point[n];
            _pointList.CopyTo(points);

            Pen pen = new Pen(Color.White);
            pen.Width = 2;
            SolidBrush bsh = new SolidBrush(Color.Black);


            for (int i = 0; i < n; i++)
            {
                Point pt = points[i];
                Rectangle rc = new Rectangle(pt.X - 3, pt.Y - 3, 6, 6);
                canvas.DrawRectangle(pen, rc);
                canvas.FillRectangle(bsh, rc);
            }
            pen.Dispose();
            bsh.Dispose();
        }

        public int HitTest(Point point, bool isSelected)
        {
            int n = PointList.Count;

            if (isSelected)
            {
                int hit = HandleHitTest(point);
                if (hit >= 0) return hit;
            }

            for (int i = 0; i < n - 1; i++)
            {
                Point pt1 = PointList[i];
                Point pt2 = PointList[i + 1];

                float angle = 0;
                int length = 0;
                if (pt1.X == pt2.X)
                {
                    angle = pt1.Y < pt2.Y ? 90 : -90;
                    length = Math.Abs(pt1.Y - pt2.Y);
                }
                else if (pt1.Y == pt2.Y)
                {
                    angle = pt1.X < pt2.X ? 0 : 180;
                    length = Math.Abs(pt1.X - pt2.X);
                }
                else
                {
                    float tan = (float)(pt2.Y - pt1.Y) / (pt2.X - pt1.X);
                    angle = (float)(Math.Atan(tan) * 180 / Math.PI);
                    int n1 = (pt2.Y - pt1.Y) * (pt2.Y - pt1.Y) + (pt2.X - pt1.X) * (pt2.X - pt1.X);
                    double d1 = Math.Sqrt(n1);
                    length = Convert.ToInt32(d1);
                }
                Rectangle rc = new Rectangle(pt1.X - 5, pt1.Y - 5, length + 10, 10);
                Point[] wrapper = new Point[1];
                wrapper[0] = point;
                if (angle != 0)
                {
                    Matrix matrix = new Matrix();
                    matrix.RotateAt(-angle, pt1);
                    matrix.TransformPoints(wrapper);
                }
                if (rc.Contains(wrapper[0]))
                    return 0;
            }

            return -1;
        }
        public int HandleHitTest(Point point)
        {
            int n = _pointList.Count;
            Point[] points = new Point[n];
            _pointList.CopyTo(points);

            for (int i = 0; i < n; i++)
            {
                Point pt = points[i];
                Rectangle rc = new Rectangle(pt.X - 3, pt.Y - 3, 6, 6);
                if (rc.Contains(point)) return i + 1;
            }

            return -1;
        }

        public void Translate(int offsetX, int offsetY)
        {
            int n = _pointList.Count;
            for (int i = 0; i < n; i++)
            {
                Point pt = _pointList[i];
                pt.Offset(offsetX, offsetY);
                _pointList[i] = pt;
            }
        }

        public void Scale(int handle, int dx, int dy)
        {
            Point pt = _pointList[handle - 1];
            pt.Offset(dx, 0);
            _pointList[handle - 1] = pt;
        }

        public Region GetRedrawRegion()
        {
            int n = _pointList.Count;
            int minX, minY, maxX, maxY;
            maxX = minX = _pointList[0].X; maxY = minY = _pointList[0].Y;
            for (int i = 1; i < n; i++)
            {
                if (_pointList[i].X < minX)
                    minX = _pointList[i].X;
                else if (_pointList[i].X > maxX)
                    maxX = _pointList[i].X;

                if (_pointList[i].Y < minY)
                    minY = _pointList[i].Y;
                else if (_pointList[i].Y > maxY)
                    maxY = _pointList[i].Y;

            }

            Rectangle rc = new Rectangle(minX, minY, maxX - minX, maxY - minY);
            rc.Inflate(10, 10);
            Region region = new Region(rc);
            return region;
        }
    }
}
