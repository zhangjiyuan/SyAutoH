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

        private List<Point> _saveList = new List<Point>();
        public List<Point> SaveList
        {
            get { return _saveList; }
            set { _saveList = value; }
        }

        public void DrawTracker(Graphics canvas)
        {
            if (canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");
            int n = PointList.Count;
            Point[] points = new Point[n];
            PointList.CopyTo(points);
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
                Rectangle rc = GetRedrawRc();
                Point[] wrapper = new Point[1];
                wrapper[0] = point;
                if (rc.Contains(wrapper[0]))
                    return 0;
            }
            return -1;
        }

        public int HandleHitTest(Point point)
        {
            int n = PointList.Count;
            Point[] points = new Point[n];
            PointList.CopyTo(points);
            for (int i = 0; i < n; i++)
            {
                Point pt = points[i];
                Rectangle rc = new Rectangle(pt.X - 3, pt.Y - 3, 6, 6);
                if (rc.Contains(point)) 
                    return i + 1;
            }
            return -1;
        }

        public void Translate(int offsetX, int offsetY)
        {
            int n = PointList.Count;
            for (int i = 0; i < n; i++)
            {
                Point pt = PointList[i];
                pt.Offset(offsetX, offsetY);
                PointList[i] = pt;
            }
        }

        public int Scale(int handle, int dx, int dy, int lenght)
        {
            Point pt1 = new Point(0);
            Point pt2 = new Point(0);
            int n = PointList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                pt1 = PointList[i];
                pt2 = PointList[i + 1];
            }
            if (pt1.Y == pt2.Y)
            {
                Point pt = PointList[handle - 1];
                pt.Offset(dx, 0);
                PointList[handle - 1] = pt;
                return Math.Abs(PointList[1].X - PointList[0].X);
            }
            else if (pt1.X == pt2.X)
            {
                Point pt = PointList[handle - 1];
                pt.Offset(0, dy);
                PointList[handle - 1] = pt;
                return Math.Abs(PointList[1].Y - PointList[0].Y);
            }
            return lenght;
        }

        public void ChangeDirection(Point pt, Size sz)
        {
            float angle = 90;
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, pt);

            int n = PointList.Count;
            Point[] points = new Point[n];
            PointList.CopyTo(points);
            matrix.TransformPoints(points);

            for (int i = 0; i < n; i++)
            {
                Rectangle rc = new Rectangle(0, 0, sz.Width, sz.Height);
                if (!rc.Contains(points[i]))
                {
                    if (points[n - 2].X == points[n - 1].X)
                    {
                        int _height =Math.Abs(points[1].Y - points[0].Y);
                        if (points[i].Y < 0)
                        {
                            points[0].Y = 1;
                            points[1].Y = points[0].Y + _height;
                        }
                        else if (points[i].Y > sz.Height)
                        {
                            points[0].Y = sz.Height - 2;
                            points[1].Y = points[0].Y - _height;
                        }
                    }
                    else if (points[n - 2].Y == points[n - 1].Y)
                    {
                        int _width = Math.Abs(points[1].X - points[0].X);
                        if (points[i].X < 0)
                        {
                            points[0].X = 1;
                            points[1].X = points[0].X + _width;
                        }
                        else if (points[i].X > sz.Width)
                        {
                            points[0].X = sz.Width - 2;
                            points[1].X = points[0].X - _width;
                        }
                    }
                    PointList.Clear();
                    PointList.AddRange(points);
                    return;
                }
            }
            PointList.Clear();
            PointList.AddRange(points);
        }

        public void Rotate(Point pt, int angle)
        {
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, pt);

            int n = PointList.Count;
            Point[] points = new Point[n];
            PointList.CopyTo(points);
            matrix.TransformPoints(points);
            PointList.Clear();
            PointList.AddRange(points);
        }

        public Rectangle GetRedrawRc()
        {
            int n = PointList.Count;
            int minX, minY, maxX, maxY;
            maxX = minX = PointList[0].X; maxY = minY = PointList[0].Y;
            for (int i = 1; i < n; i++)
            {
                if (PointList[i].X < minX)
                    minX = PointList[i].X;
                else if (PointList[i].X > maxX)
                    maxX = PointList[i].X;
                if (PointList[i].Y < minY)
                    minY = PointList[i].Y;
                else if (PointList[i].Y > maxY)
                    maxY = PointList[i].Y;
            }
            Rectangle rc = new Rectangle(minX, minY, maxX - minX, maxY - minY);
            rc.Inflate(5, 5);
            return rc;
        }

        public Region GetRedrawRegion()
        {
            int n = PointList.Count;
            int minX, minY, maxX, maxY;
            maxX = minX = PointList[0].X; maxY = minY = PointList[0].Y;
            for (int i = 1; i < n; i++)
            {
                if (PointList[i].X < minX)
                    minX = PointList[i].X;
                else if (PointList[i].X > maxX)
                    maxX = PointList[i].X;
                if (PointList[i].Y < minY)
                    minY = PointList[i].Y;
                else if (PointList[i].Y > maxY)
                    maxY = PointList[i].Y;
            }
            Rectangle rc = new Rectangle(minX, minY, maxX - minX, maxY - minY);
            rc.Inflate(10, 10);
            Region region = new Region(rc);
            return region;
        }
    }
}
