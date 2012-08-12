﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BaseRailElement
{
    public class ObjectCrossLeftOp
    {
        private List<Point> _pointList = new List<Point>();
        public List<Point> PointList
        {
            get { return _pointList; }
            set { _pointList = value; }
        }

        public void DrawTracker(Graphics canvas, Point center, int radiu, int direction)
        {
            if (canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");

            Pen pen = new Pen(Color.White, 2);
            SolidBrush bsh = new SolidBrush(Color.Black);

            Point[] points = new Point[4];
            if (0 == direction)
            {
                points[0] = center;
                points[1] = new Point(center.X + radiu, center.Y);
            }
            else if (1 == direction)
            {
                points[0] = center;
                points[1] = new Point(center.X, center.Y + radiu);
            }
            else if (2 == direction)
            {
                points[0] = center;
                points[1] = new Point(center.X - radiu, center.Y);
            }
            else if (3 == direction)
            {
                points[0] = center;
                points[1] = new Point(center.X, center.Y - radiu);
            }

            points[2] = _pointList[1];
            points[3] = _pointList[0];

            for (int i = 0; i < 4; i++)
            {
                Rectangle rc = new Rectangle(points[i].X - 3, points[i].Y - 3, 6, 6);
                canvas.DrawRectangle(pen, rc);
                canvas.FillRectangle(bsh, rc);
            }
            pen.Dispose();
            bsh.Dispose();
        }

        public int HitTest(Point point, bool isSelected, Point center, int radiu, int direction, int lenghtstr, int interval)
        {
            if (isSelected)
            {
                int handleHit = HandleHitTest(point, center, radiu, direction);
                if (handleHit > 0) return handleHit;
            }

            // 判断是否在内部
            Point[] wrapper = new Point[1];
            wrapper[0] = point;

            Rectangle rc = new Rectangle();
            Point[] points = new Point[4];
            if (0 == direction)
            {
                points[0] = center;
                if (lenghtstr > radiu)
                {
                    points[1] = new Point(_pointList[1].X, center.Y);
                    points[2] = _pointList[1];
                }
                else
                {
                    points[1] = new Point(center.X + radiu, center.Y);
                    points[2] = new Point(center.X + radiu, _pointList[1].Y);
                }
                points[3] = _pointList[0];
                rc = new Rectangle(points[0].X, points[0].Y, points[1].X - points[0].X, points[3].Y - points[0].Y);
            }
            else if (1 == direction)
            {
                points[0] = center;
                if (lenghtstr > radiu)
                {
                    points[1] = new Point(center.X, _pointList[1].Y);
                    points[2] = _pointList[1];
                }
                else
                {
                    points[1] = new Point(center.X, center.Y + radiu);
                    points[2] = new Point(_pointList[1].X, center.Y + radiu);
                }
                points[3] = _pointList[0];
                rc = new Rectangle(points[3].X, points[3].Y, points[1].X - points[3].X, points[1].Y - points[3].Y);
            }
            else if (2 == direction)
            {
                points[0] = center;
                if (lenghtstr > radiu)
                {
                    points[1] = new Point(_pointList[1].X, center.Y);
                    points[2] = _pointList[1];
                }
                else
                {
                    points[1] = new Point(center.X - radiu, center.Y);
                    points[2] = new Point(center.X - radiu, _pointList[1].Y);
                }
                points[3] = _pointList[0];
                rc = new Rectangle(points[2].X, points[2].Y, points[0].X - points[2].X, points[0].Y - points[2].Y);
            }
            else if (3 == direction)
            {
                points[0] = center;
                if (lenghtstr > radiu)
                {
                    points[1] = new Point(center.X, _pointList[1].Y);
                    points[2] = _pointList[1];
                }
                else
                {
                    points[1] = new Point(center.X, center.Y - radiu);
                    points[2] = new Point(_pointList[1].X, center.Y - radiu);
                }
                points[3] = _pointList[0];
                rc = new Rectangle(points[1].X, points[1].Y, points[3].X - points[1].X, points[3].Y - points[1].Y);
            }

            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rc);
            Region region = new Region(path);
            if (region.IsVisible(wrapper[0]))
                return 0;
            else
                return -1;
        }

        public int HandleHitTest(Point point, Point center, int radiu, int direction)          //角度
        {
            Point[] points = new Point[4];
            if (0 == direction)
            {
                points[0] = center;
                points[1] = new Point(center.X + radiu, center.Y);
            }
            else if (1 == direction)
            {
                points[0] = center;
                points[1] = new Point(center.X, center.Y + radiu);
            }
            else if (2 == direction)
            {
                points[0] = center;
                points[1] = new Point(center.X - radiu, center.Y);
            }
            else if (3 == direction)
            {
                points[0] = center;
                points[1] = new Point(center.X, center.Y - radiu);
            }
            points[2] = _pointList[1];
            points[3] = _pointList[0];

            for (int i = 0; i < 4; i++)
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

        public Rectangle Scale(int handle, int dx, int dy, Point center, int radiu, int direction, int lenghtofstr, int interval)
        {
            Point[] points = new Point[4];
            Point[] pointlist = new Point[2];
            PointList.CopyTo(pointlist);
            if (0 == direction)
            {
                points[0] = center;
                if (lenghtofstr > radiu)
                {
                    points[1] = new Point(_pointList[1].X, center.Y);
                    points[2] = _pointList[1];
                }
                else
                {
                    points[1] = new Point(center.X + radiu, center.Y);
                    points[2] = new Point(center.X + radiu, _pointList[1].Y);
                }
                points[3] = _pointList[0];
            }
            else if (1 == direction)
            {
                points[0] = center;
                if (lenghtofstr > radiu)
                {
                    points[1] = new Point(center.X, _pointList[1].Y);
                    points[2] = _pointList[1];
                }
                else
                {
                    points[1] = new Point(center.X, center.Y + radiu);
                    points[2] = new Point(_pointList[1].X, center.Y + radiu);
                }
                points[3] = _pointList[0];
            }
            else if (2 == direction)
            {
                points[0] = center;
                if (lenghtofstr > radiu)
                {
                    points[1] = new Point(_pointList[1].X, center.Y);
                    points[2] = _pointList[1];
                }
                else
                {
                    points[1] = new Point(center.X - radiu, center.Y);
                    points[2] = new Point(center.X - radiu, _pointList[1].Y);
                }
                points[3] = _pointList[0];
            }
            else if (3 == direction)
            {
                points[0] = center;
                if (lenghtofstr > radiu)
                {
                    points[1] = new Point(center.X, _pointList[1].Y);
                    points[2] = _pointList[1];
                }
                else
                {
                    points[1] = new Point(center.X, center.Y - radiu);
                    points[2] = new Point(_pointList[1].X, center.Y - radiu);
                }
                points[3] = _pointList[0];
            }

            Point pt = points[handle - 1];
            Point[] wrapper = new Point[] { pt };

            if (0 == direction)
            {
                if (1 == handle)
                {
                    int var = -dx;
                    if (20 > radiu)
                    {
                        if (dx < 0)
                        {
                            pt.Offset(dx, dx);
                            pointlist[0].Offset(0, var);
                            pointlist[1].Offset(0, var);
                            PointList.Clear();
                            PointList.AddRange(pointlist);
                        }
                        else
                        {
                            return new Rectangle(pt.X, pt.Y, radiu, radiu);
                        }
                    }
                    pt.Offset(dx, dx);
                    pointlist[0].Offset(0, var);
                    pointlist[1].Offset(0, var);
                    PointList.Clear();
                    PointList.AddRange(pointlist);
                }
                else if (2 == handle)
                {
                    return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                }
                else if (3 == handle)
                {
                    Point point = _pointList[1];
                    point.Offset(dx, 0);
                    _pointList[1] = point;
                    return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                }
                else if (4 == handle)
                {
                    return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                }
            }
            else if (1 == direction)
            {
                if (1 == handle)
                {
                    int var = -dx;
                    if (20 > radiu)
                    {
                        if (dx > 0)
                        {
                            pt.Offset(dx, 0);
                            pointlist[0].Offset(var, 0);
                            pointlist[1].Offset(var, 0);
                            PointList.Clear();
                            PointList.AddRange(pointlist);
                        }
                        else
                        {
                            return new Rectangle(points[0].X - radiu, points[0].Y, radiu, radiu);
                        }
                    }
                    pt.Offset(dx, 0);
                    pointlist[0].Offset(var, 0);
                    pointlist[1].Offset(var, 0);
                    PointList.Clear();
                    PointList.AddRange(pointlist);
                }
                else if (2 == handle)
                {
                    return new Rectangle(points[0].X - radiu, points[0].Y, radiu, radiu);
                }
                else if (3 == handle)
                {
                    Point point = _pointList[1];
                    point.Offset(0, dy);
                    _pointList[1] = point;
                    return new Rectangle(points[0].X - radiu, points[0].Y, radiu, radiu);
                }
                else if (4 == handle)
                {
                    return new Rectangle(points[0].X - radiu, points[0].Y, radiu, radiu);
                }
            }
            else if (2 == direction)
            {
                if (1 == handle)
                {
                    int var = -dx;
                    if (20 > radiu)
                    {
                        if (dx > 0)
                        {
                            pt.Offset(dx, 0);
                            pointlist[0].Offset(0, var);
                            pointlist[1].Offset(0, var);
                            PointList.Clear();
                            PointList.AddRange(pointlist);
                        }
                        else
                        {
                            return new Rectangle(points[0].X - radiu, points[0].Y - radiu, radiu, radiu);
                        }
                    }
                    pt.Offset(dx, 0);
                    pointlist[0].Offset(0, var);
                    pointlist[1].Offset(0, var);
                    PointList.Clear();
                    PointList.AddRange(pointlist);
                }
                else if (2 == handle)
                {
                    return new Rectangle(points[0].X - radiu, points[0].Y - radiu, radiu, radiu);
                }
                else if (3 == handle)
                {
                    Point point = _pointList[1];
                    point.Offset(dx, 0);
                    _pointList[1] = point;
                    return new Rectangle(points[0].X - radiu, points[0].Y - radiu, radiu, radiu);
                }
                else if (4 == handle)
                {
                    return new Rectangle(points[0].X - radiu, points[0].Y - radiu, radiu, radiu);
                }
            }
            else if (3 == direction)
            {
                if (1 == handle)
                {
                    int var = -dx;
                    if (20 > radiu)
                    {
                        if (dx < 0)
                        {
                            pt.Offset(dx, 0);
                            pointlist[0].Offset(var, 0);
                            pointlist[1].Offset(var, 0);
                            PointList.Clear();
                            PointList.AddRange(pointlist);
                        }
                        else
                        {
                            return new Rectangle(points[0].X, points[0].Y - radiu, radiu, radiu);
                        }
                    }
                    pt.Offset(dx, 0);
                    pointlist[0].Offset(var, 0);
                    pointlist[1].Offset(var, 0);
                    PointList.Clear();
                    PointList.AddRange(pointlist);
                }
                else if (2 == handle)
                {
                    return new Rectangle(points[0].X, points[0].Y - radiu, radiu, radiu);
                }
                else if (3 == handle)
                {
                    Point point = _pointList[1];
                    point.Offset(0, dy);
                    _pointList[1] = point;
                    return new Rectangle(points[0].X, points[0].Y - radiu, radiu, radiu);
                }
                else if (4 == handle)
                {
                    return new Rectangle(points[0].X, points[0].Y - radiu, radiu, radiu);
                }
            }

            wrapper[0] = pt;

            int dw, dh;
            dw = wrapper[0].X - points[handle - 1].X;
            dh = wrapper[0].Y - points[handle - 1].Y;
            if (0 == direction)
            {
                radiu -= dw;
                center = wrapper[0];
                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
            }
            else if (1 == direction)
            {
                radiu += dw;
                center = wrapper[0];
                return new Rectangle(points[0].X - radiu, points[0].Y, radiu, radiu);
            }
            else if (2 == direction)
            {
                radiu += dw;
                center = wrapper[0];
                return new Rectangle(points[0].X - radiu, points[0].Y - radiu, radiu, radiu);
            }
            else if (3 == direction)
            {
                radiu -= dw;
                center = wrapper[0];
                return new Rectangle(points[0].X, points[0].Y - radiu, radiu, radiu);
            }

            return new Rectangle(pt.X, pt.Y, radiu, radiu);
        }

        public void ChangeDirection(Point pt, Size sz)
        {
            float angle = 90;
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, pt);

            int n = _pointList.Count;
            Point[] points = new Point[n];
            _pointList.CopyTo(points);
            matrix.TransformPoints(points);
            _pointList.Clear();
            _pointList.AddRange(points);
        }
    }
}