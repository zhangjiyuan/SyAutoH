using System;
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

        public void DrawTracker(
            Graphics canvas,
            Point center,
            int radiu,
            CrossLeftEle.DIRECTION_CROSS_L _direction)
        {
            if (canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");

            Pen pen = new Pen(Color.White, 2);
            SolidBrush bsh = new SolidBrush(Color.Black);

            Point[] points = new Point[4];
            
            switch (_direction)
            {
                case CrossLeftEle.DIRECTION_CROSS_L.FIRST:
                    points[0] = center;
                    points[1] = new Point(center.X + radiu, center.Y);
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.SECOND:
                    points[0] = center;
                    points[1] = new Point(center.X, center.Y + radiu);
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.THIRD:
                    points[0] = center;
                    points[1] = new Point(center.X - radiu, center.Y);
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.FOUR:
                    points[0] = center;
                    points[1] = new Point(center.X, center.Y - radiu);
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.NULL:
                    break;
            }
            points[2] = PointList[1];
            points[3] = PointList[0];

            for (int i = 0; i < 4; i++)
            {
                Rectangle rc = new Rectangle(points[i].X - 3, points[i].Y - 3, 6, 6);
                canvas.DrawRectangle(pen, rc);
                canvas.FillRectangle(bsh, rc);
            }
            pen.Dispose();
            bsh.Dispose();
        }

        public int HitTest(
            Point point,
            bool isSelected,
            Point center,
            int radiu,
            CrossLeftEle.DIRECTION_CROSS_L _direction,
            int lenghtstr,
            int interval)
        {
            if (isSelected)
            {
                int handleHit = HandleHitTest(point, center, radiu, _direction);
                if (handleHit > 0) return handleHit;
            }

            // 判断是否在内部
            Point[] wrapper = new Point[1];
            wrapper[0] = point;

            Rectangle rc = new Rectangle();
            Point[] points = new Point[4];
           
            switch (_direction)
            {
                case CrossLeftEle.DIRECTION_CROSS_L.FIRST:
                    points[0] = center;
                    if (lenghtstr > radiu)
                    {
                        points[1] = new Point(PointList[1].X, center.Y);
                        points[2] = PointList[1];
                    }
                    else
                    {
                        points[1] = new Point(center.X + radiu, center.Y);
                        points[2] = new Point(center.X + radiu, PointList[1].Y);
                    }
                    points[3] = PointList[0];
                    rc = new Rectangle(points[0].X, points[0].Y, points[1].X - points[0].X, points[3].Y - points[0].Y);
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.SECOND:
                    points[0] = center;
                    if (lenghtstr > radiu)
                    {
                        points[1] = new Point(center.X, PointList[1].Y);
                        points[2] = PointList[1];
                    }
                    else
                    {
                        points[1] = new Point(center.X, center.Y + radiu);
                        points[2] = new Point(PointList[1].X, center.Y + radiu);
                    }
                    points[3] = PointList[0];
                    rc = new Rectangle(points[3].X, points[3].Y, points[1].X - points[3].X, points[1].Y - points[3].Y);
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.THIRD:
                    points[0] = center;
                    if (lenghtstr > radiu)
                    {
                        points[1] = new Point(PointList[1].X, center.Y);
                        points[2] = PointList[1];
                    }
                    else
                    {
                        points[1] = new Point(center.X - radiu, center.Y);
                        points[2] = new Point(center.X - radiu, PointList[1].Y);
                    }
                    points[3] = PointList[0];
                    rc = new Rectangle(points[2].X, points[2].Y, points[0].X - points[2].X, points[0].Y - points[2].Y);
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.FOUR:
                    points[0] = center;
                    if (lenghtstr > radiu)
                    {
                        points[1] = new Point(center.X, PointList[1].Y);
                        points[2] = PointList[1];
                    }
                    else
                    {
                        points[1] = new Point(center.X, center.Y - radiu);
                        points[2] = new Point(PointList[1].X, center.Y - radiu);
                    }
                    points[3] = PointList[0];
                    rc = new Rectangle(points[1].X, points[1].Y, points[3].X - points[1].X, points[3].Y - points[1].Y);
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.NULL:
                    break;
            }
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rc);
            Region region = new Region(path);
            if (region.IsVisible(wrapper[0]))
                return 0;
            else
                return -1;
        }

        public int HandleHitTest(Point point, Point center, int radiu, CrossLeftEle.DIRECTION_CROSS_L _direction)          //角度
        {
            Point[] points = new Point[4];            
            switch (_direction)
            {
                case CrossLeftEle.DIRECTION_CROSS_L.FIRST:
                    points[0] = center;
                    points[1] = new Point(center.X + radiu, center.Y);
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.SECOND:
                    points[0] = center;
                    points[1] = new Point(center.X, center.Y + radiu);
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.THIRD:
                    points[0] = center;
                    points[1] = new Point(center.X - radiu, center.Y);
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.FOUR:
                    points[0] = center;
                    points[1] = new Point(center.X, center.Y - radiu);
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.NULL:
                    break;
            }
            points[2] = PointList[1];
            points[3] = PointList[0];

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
            int n = PointList.Count;
            for (int i = 0; i < n; i++)
            {
                Point pt = PointList[i];
                pt.Offset(offsetX, offsetY);
                PointList[i] = pt;
            }
        }

        public Rectangle Scale(
            int handle,
            int dx,
            int dy,
            Point center,
            int radiu,
            CrossLeftEle.DIRECTION_CROSS_L _direction,
            int lenghtofstr,
            int interval)
        {
            Point[] points = new Point[4];
            Point[] pointlist = new Point[2];
            PointList.CopyTo(pointlist);
            switch (_direction)
            {
                case CrossLeftEle.DIRECTION_CROSS_L.FIRST:
                    points[0] = center;
                    if (lenghtofstr > radiu)
                    {
                        points[1] = new Point(PointList[1].X, center.Y);
                        points[2] = PointList[1];
                    }
                    else
                    {
                        points[1] = new Point(center.X + radiu, center.Y);
                        points[2] = new Point(center.X + radiu, PointList[1].Y);
                    }
                    points[3] = PointList[0];
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.SECOND:
                    points[0] = center;
                    if (lenghtofstr > radiu)
                    {
                        points[1] = new Point(center.X, PointList[1].Y);
                        points[2] = PointList[1];
                    }
                    else
                    {
                        points[1] = new Point(center.X, center.Y + radiu);
                        points[2] = new Point(PointList[1].X, center.Y + radiu);
                    }
                    points[3] = PointList[0];
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.THIRD:
                    points[0] = center;
                    if (lenghtofstr > radiu)
                    {
                        points[1] = new Point(PointList[1].X, center.Y);
                        points[2] = PointList[1];
                    }
                    else
                    {
                        points[1] = new Point(center.X - radiu, center.Y);
                        points[2] = new Point(center.X - radiu, PointList[1].Y);
                    }
                    points[3] = PointList[0];
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.FOUR:
                    points[0] = center;
                    if (lenghtofstr > radiu)
                    {
                        points[1] = new Point(center.X, PointList[1].Y);
                        points[2] = PointList[1];
                    }
                    else
                    {
                        points[1] = new Point(center.X, center.Y - radiu);
                        points[2] = new Point(PointList[1].X, center.Y - radiu);
                    }
                    points[3] = PointList[0];
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.NULL:
                    break;
            }
            Point pt = points[handle - 1];
            Point[] wrapper = new Point[] { pt };            
            switch (_direction)
            {
                case CrossLeftEle.DIRECTION_CROSS_L.FIRST:
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
                        Point point = PointList[1];
                        point.Offset(dx, 0);
                        PointList[1] = point;
                        return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                    }
                    else if (4 == handle)
                    {
                        return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                    }
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.SECOND:
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
                        Point point = PointList[1];
                        point.Offset(0, dy);
                        PointList[1] = point;
                        return new Rectangle(points[0].X - radiu, points[0].Y, radiu, radiu);
                    }
                    else if (4 == handle)
                    {
                        return new Rectangle(points[0].X - radiu, points[0].Y, radiu, radiu);
                    }
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.THIRD:
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
                        Point point = PointList[1];
                        point.Offset(dx, 0);
                        PointList[1] = point;
                        return new Rectangle(points[0].X - radiu, points[0].Y - radiu, radiu, radiu);
                    }
                    else if (4 == handle)
                    {
                        return new Rectangle(points[0].X - radiu, points[0].Y - radiu, radiu, radiu);
                    }
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.FOUR:
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
                        Point point = PointList[1];
                        point.Offset(0, dy);
                        PointList[1] = point;
                        return new Rectangle(points[0].X, points[0].Y - radiu, radiu, radiu);
                    }
                    else if (4 == handle)
                    {
                        return new Rectangle(points[0].X, points[0].Y - radiu, radiu, radiu);
                    }
                    break;
                case CrossLeftEle.DIRECTION_CROSS_L.NULL:
                    break;
            }
            wrapper[0] = pt;

            int dw, dh;
            dw = wrapper[0].X - points[handle - 1].X;
            dh = wrapper[0].Y - points[handle - 1].Y;
            switch (_direction)
            {
                case CrossLeftEle.DIRECTION_CROSS_L.FIRST:
                    radiu -= dw;
                    center = wrapper[0];
                    return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                case CrossLeftEle.DIRECTION_CROSS_L.SECOND:
                    radiu += dw;
                    center = wrapper[0];
                    return new Rectangle(points[0].X - radiu, points[0].Y, radiu, radiu);
                case CrossLeftEle.DIRECTION_CROSS_L.THIRD:
                    radiu += dw;
                    center = wrapper[0];
                    return new Rectangle(points[0].X - radiu, points[0].Y - radiu, radiu, radiu);
                case CrossLeftEle.DIRECTION_CROSS_L.FOUR:
                    radiu -= dw;
                    center = wrapper[0];
                    return new Rectangle(points[0].X, points[0].Y - radiu, radiu, radiu);
                case CrossLeftEle.DIRECTION_CROSS_L.NULL:
                    break;
            }
            return new Rectangle(pt.X, pt.Y, radiu, radiu);
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
            PointList.Clear();
            PointList.AddRange(points);
        }
    }
}
