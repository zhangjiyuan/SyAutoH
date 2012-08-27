using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BaseRailElement
{
    public class ObjectCurvedOp
    {
        public void DrawTracker(Graphics canvas, Point center, int radiu, CurvedRailEle.DirectonCurved _direction)
        {
            if (canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");

            Pen pen = new Pen(Color.White, 2);
            SolidBrush bsh = new SolidBrush(Color.Black);
            Point[] points = new Point[4];
            switch (_direction)
            {
                case CurvedRailEle.DirectonCurved.first:
                    points[0] = center;
                    points[1] = new Point(center.X + radiu, center.Y);
                    points[2] = new Point(center.X + radiu, center.Y + radiu);
                    points[3] = new Point(center.X, center.Y + radiu);                   
                    break;
                case CurvedRailEle.DirectonCurved.second:
                    points[0] = center;
                    points[1] = new Point(center.X, center.Y + radiu);
                    points[2] = new Point(center.X - radiu, center.Y + radiu);
                    points[3] = new Point(center.X - radiu, center.Y);
                    break;
                case CurvedRailEle.DirectonCurved.third:
                    points[0] = center;
                    points[1] = new Point(center.X - radiu, center.Y);
                    points[2] = new Point(center.X - radiu, center.Y - radiu);
                    points[3] = new Point(center.X, center.Y - radiu);
                    break;
                case CurvedRailEle.DirectonCurved.four:
                    points[0] = center;
                    points[1] = new Point(center.X, center.Y - radiu);
                    points[2] = new Point(center.X + radiu, center.Y - radiu);
                    points[3] = new Point(center.X + radiu, center.Y);
                    break;
                case CurvedRailEle.DirectonCurved.NULL:
                    break;
            }
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
            CurvedRailEle.DirectonCurved _direction)
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
                case CurvedRailEle.DirectonCurved.first:
                    points[0] = center;
                    points[2] = new Point(center.X + radiu, center.Y + radiu);
                    rc = new Rectangle(points[0].X, points[0].Y, points[2].X - points[0].X, points[2].Y - points[0].Y);
                    break;
                case CurvedRailEle.DirectonCurved.second:
                    points[1] = new Point(center.X, center.Y + radiu);
                    points[3] = new Point(center.X - radiu, center.Y);
                    rc = new Rectangle(points[3].X, points[3].Y, points[1].X - points[3].X, points[1].Y - points[3].Y);
                    break;
                case CurvedRailEle.DirectonCurved.third:
                    points[0] = center;
                    points[2] = new Point(center.X - radiu, center.Y - radiu);
                    rc = new Rectangle(points[2].X, points[2].Y, points[0].X - points[2].X, points[0].Y - points[2].Y);
                    break;
                case CurvedRailEle.DirectonCurved.four:
                    points[1] = new Point(center.X, center.Y - radiu);
                    points[3] = new Point(center.X + radiu, center.Y);
                    rc = new Rectangle(points[1].X, points[1].Y, points[3].X - points[1].X, points[3].Y - points[1].Y);
                    break;
                case CurvedRailEle.DirectonCurved.NULL:
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

        public int HandleHitTest(Point point,
            Point center,
            int radiu,
            CurvedRailEle.DirectonCurved _direction)
        {
            Point[] points = new Point[4];
            switch (_direction)
            {
                case CurvedRailEle.DirectonCurved.first:
                    points[0] = center;
                    points[1] = new Point(center.X + radiu, center.Y);
                    points[2] = new Point(center.X + radiu, center.Y + radiu);
                    points[3] = new Point(center.X, center.Y + radiu);
                    break;
                case CurvedRailEle.DirectonCurved.second:
                    points[0] = center;
                    points[1] = new Point(center.X, center.Y + radiu);
                    points[2] = new Point(center.X - radiu, center.Y + radiu);
                    points[3] = new Point(center.X - radiu, center.Y);
                    break;
                case CurvedRailEle.DirectonCurved.third:
                    points[0] = center;
                    points[1] = new Point(center.X - radiu, center.Y);
                    points[2] = new Point(center.X - radiu, center.Y - radiu);
                    points[3] = new Point(center.X, center.Y - radiu);
                    break;
                case CurvedRailEle.DirectonCurved.four:
                    points[0] = center;
                    points[1] = new Point(center.X, center.Y - radiu);
                    points[2] = new Point(center.X + radiu, center.Y - radiu);
                    points[3] = new Point(center.X + radiu, center.Y);
                    break;
                case CurvedRailEle.DirectonCurved.NULL:
                    break;
            }
            for (int i = 0; i < 4; i++)
            {
                Point pt = points[i];
                Rectangle rc = new Rectangle(pt.X - 3, pt.Y - 3, 6, 6);
                if (rc.Contains(point)) return i + 1;
            }
            return -1;
        }

        public Rectangle Scale(
            int handle,
            int dx,
            int dy,
            Point center,
            int radiu,
            CurvedRailEle.DirectonCurved _direction)
        {
            Point[] points = new Point[4];
            switch (_direction)
            {
                case CurvedRailEle.DirectonCurved.first:
                    points[0] = center;
                    points[1] = new Point(center.X + radiu, center.Y);
                    points[2] = new Point(center.X + radiu, center.Y + radiu);
                    points[3] = new Point(center.X, center.Y + radiu);
                    break;
                case CurvedRailEle.DirectonCurved.second:
                    points[0] = center;
                    points[1] = new Point(center.X, center.Y + radiu);
                    points[2] = new Point(center.X - radiu, center.Y + radiu);
                    points[3] = new Point(center.X - radiu, center.Y);
                    break;
                case CurvedRailEle.DirectonCurved.third:
                    points[0] = center;
                    points[1] = new Point(center.X - radiu, center.Y);
                    points[2] = new Point(center.X - radiu, center.Y - radiu);
                    points[3] = new Point(center.X, center.Y - radiu);
                    break;
                case CurvedRailEle.DirectonCurved.four:
                    points[0] = center;
                    points[1] = new Point(center.X, center.Y - radiu);
                    points[2] = new Point(center.X + radiu, center.Y - radiu);
                    points[3] = new Point(center.X + radiu, center.Y);
                    break;
                case CurvedRailEle.DirectonCurved.NULL:
                    break;
            }
            Point pt = points[handle - 1];
            Point[] wrapper = new Point[] { pt };
            switch (_direction)
            {
                case CurvedRailEle.DirectonCurved.first:
                    if (1 == handle)
                    {
                        int var = dx;
                        if (20 > radiu)
                        {
                            if (dx < 0)
                            {
                                pt.Offset(var, var);
                            }
                            else
                            {
                                return new Rectangle(pt.X, pt.Y, radiu, radiu);
                            }
                        }
                        pt.Offset(var, var);
                    }
                    else if (2 == handle)
                    {
                        if (20 > radiu)
                        {
                            if (dx > 0)
                            {
                                pt.Offset(dx, 0);
                            }
                            else
                            {
                                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                            }
                        }
                        pt.Offset(dx, 0);
                    }
                    else if (3 == handle)
                    {
                        int var = dx;
                        if (20 > radiu)
                        {
                            if (dx > 0)
                            {
                                pt.Offset(var, var);
                            }
                            else
                            {
                                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                            }
                        }
                        pt.Offset(var, var);
                    }
                    else if (4 == handle)
                    {
                        if (20 > radiu)
                        {
                            if (dy > 0)
                            {
                                pt.Offset(0, dy);
                            }
                            else
                            {
                                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                            }
                        }
                        pt.Offset(0, dy);
                    }
                    break;
                case CurvedRailEle.DirectonCurved.second:
                    if (1 == handle)
                    {
                        int var = dx;
                        if (20 > radiu)
                        {
                            if (dx > 0)
                            {
                                pt.Offset(var, var);
                            }
                            else
                            {
                                return new Rectangle(pt.X, pt.Y, radiu, radiu);
                            }
                        }
                        pt.Offset(var, var);
                    }
                    else if (2 == handle)
                    {
                        if (20 > radiu)
                        {
                            if (dy > 0)
                            {
                                pt.Offset(0, dy);
                            }
                            else
                            {
                                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                            }
                        }
                        pt.Offset(0, dy);
                    }
                    else if (3 == handle)
                    {
                        int var = dx;
                        if (20 > radiu)
                        {
                            if (dx < 0)
                            {
                                pt.Offset(var, var);
                            }
                            else
                            {
                                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                            }
                        }
                        pt.Offset(var, var);
                    }
                    else if (4 == handle)
                    {
                        if (20 > radiu)
                        {
                            if (dx < 0)
                            {
                                pt.Offset(dx, 0);
                            }
                            else
                            {
                                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                            }
                        }
                        pt.Offset(dx, 0);
                    }
                    break;
                case CurvedRailEle.DirectonCurved.third:
                    if (1 == handle)
                    {
                        int var = dx;
                        if (20 > radiu)
                        {
                            if (dx > 0)
                            {
                                pt.Offset(var, var);
                            }
                            else
                            {
                                return new Rectangle(pt.X, pt.Y, radiu, radiu);
                            }
                        }
                        pt.Offset(var, var);
                    }
                    else if (2 == handle)
                    {
                        if (20 > radiu)
                        {
                            if (dx < 0)
                            {
                                pt.Offset(dx, 0);
                            }
                            else
                            {
                                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                            }
                        }
                        pt.Offset(dx, 0);
                    }
                    else if (3 == handle)
                    {
                        int var = dx;
                        if (20 > radiu)
                        {
                            if (dx < 0)
                            {
                                pt.Offset(var, var);
                            }
                            else
                            {
                                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                            }
                        }
                        pt.Offset(var, var);
                    }
                    else if (4 == handle)
                    {
                        if (20 > radiu)
                        {
                            if (dy < 0)
                            {
                                pt.Offset(0, dy);
                            }
                            else
                            {
                                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                            }
                        }
                        pt.Offset(0, dy);
                    }
                    break;
                case CurvedRailEle.DirectonCurved.four:
                    if (1 == handle)
                    {
                        int var = dx;
                        if (20 > radiu)
                        {
                            if (dx < 0)
                            {
                                pt.Offset(var, var);
                            }
                            else
                            {
                                return new Rectangle(pt.X, pt.Y, radiu, radiu);
                            }
                        }
                        pt.Offset(var, var);
                    }
                    else if (2 == handle)
                    {
                        if (20 > radiu)
                        {
                            if (dy < 0)
                            {
                                pt.Offset(0, dy);
                            }
                            else
                            {
                                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                            }
                        }
                        pt.Offset(0, dy);
                    }
                    else if (3 == handle)
                    {
                        int var = dx;
                        if (20 > radiu)
                        {
                            if (dx > 0)
                            {
                                pt.Offset(var, var);
                            }
                            else
                            {
                                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                            }
                        }
                        pt.Offset(var, var);
                    }
                    else if (4 == handle)
                    {
                        if (20 > radiu)
                        {
                            if (dy > 0)
                            {
                                pt.Offset(0, dy);
                            }
                            else
                            {
                                return new Rectangle(points[0].X, points[0].Y, radiu, radiu);
                            }
                        }
                        pt.Offset(0, dy);
                    }
                    break;
                case CurvedRailEle.DirectonCurved.NULL:
                    break;
            }
            wrapper[0] = pt;

            int dw, dh;
            dw = wrapper[0].X - points[handle - 1].X;
            dh = wrapper[0].Y - points[handle - 1].Y;
            
            switch (_direction)
            {
                case CurvedRailEle.DirectonCurved.first:
                    switch (handle)
                    {
                        case 1:
                            radiu -= dw;
                            center = wrapper[0];
                            break;
                        case 2:
                            radiu += dw;
                            break;
                        case 3:
                            radiu += dw;
                            break;
                        case 4:
                            radiu += dh;
                            break;
                    }
                    break;
                case CurvedRailEle.DirectonCurved.second:
                    switch (handle)
                    {
                        case 1:
                            radiu += dw;
                            center = wrapper[0];
                            break;
                        case 2:
                            radiu += dh;
                            break;
                        case 3:
                            radiu -= dw;
                            break;
                        case 4:
                            radiu -= dw;
                            break;
                    }
                    break;
                case CurvedRailEle.DirectonCurved.third:
                    switch (handle)
                    {
                        case 1:
                            radiu += dw;
                            center = wrapper[0];
                            break;
                        case 2:
                            radiu -= dw;
                            break;
                        case 3:
                            radiu -= dw;
                            break;
                        case 4:
                            radiu -= dh;
                            break;
                    }
                    break;
                case CurvedRailEle.DirectonCurved.four:
                    switch (handle)
                    {
                        case 1:
                            radiu -= dw;
                            center = wrapper[0];
                            break;
                        case 2:
                            radiu -= dh;
                            break;
                        case 3:
                            radiu += dw;
                            break;
                        case 4:
                            radiu += dh;
                            break;
                    }
                    break;
                case CurvedRailEle.DirectonCurved.NULL:
                    break;
            }
            return new Rectangle(center.X, center.Y, radiu, radiu);
        }

        public Point ChangePropertyValue(
            Point center, 
            Point first_dot,
            Point second_dot,
            int radiu
            )
        {
            int lenght = 0;
            Point pt = new Point();
            if(first_dot.X==center.X)
            {
                if (radiu != Math.Abs(first_dot.Y - center.Y))
                {
                    lenght = Math.Abs(first_dot.Y - center.Y) - radiu; 
                    pt=center;
                    pt.Offset(0,lenght);
                    return pt;
                }
                else if (radiu != Math.Abs(second_dot.X - center.X))
                {
                    return pt=first_dot;
                }
            }
            else if (first_dot.Y == center.Y)
            { 
            }
            else if (second_dot.X == center.X)
            { 
            }
            else if (second_dot.Y == center.Y)
            { 
            }
            return pt=first_dot;
        }
    }
}
