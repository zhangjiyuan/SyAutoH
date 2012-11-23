using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BaseRailElement
{
    public class ObjectLabelOp
    {
        private int drawMultiFactor = 1;
        public int DrawMultiFactor
        {
            set { drawMultiFactor = value; }
        }

        public void DrawTracker(Graphics canvas, Rectangle rect)
        {
            if (canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");
            Pen pen = new Pen(Color.White, 2);
            SolidBrush bsh = new SolidBrush(Color.Black);
            Point[] pts = new Point[4];
            pts[0] = rect.Location;
            pts[1] = new Point(pts[0].X + rect.Width, pts[0].Y);
            pts[2] = new Point(pts[0].X, pts[0].Y + rect.Height);
            pts[3] = new Point(pts[0].X + rect.Width, pts[0].Y + rect.Height);
            for (int i = 0; i < 4; i++)
            {
                Rectangle rc = new Rectangle(pts[i].X - 3, pts[i].Y - 3, 6, 6);
                canvas.DrawRectangle(pen, rc);
                canvas.FillRectangle(bsh, rc);
            }
            pen.Dispose();
            bsh.Dispose();
        }

        public int HitTest(Point pt, bool isSelected, Rectangle rect)
        {
            if (isSelected)
            {
                int handleHit = HandleHitTest(pt, rect);
                if (handleHit > 0)
                    return handleHit;
            }
            if (rect.Contains(pt))
                return 0;
            return -1;
        }

        public int HandleHitTest(Point pt, Rectangle rect)
        {
            Point[] pts = new Point[4];
            pts[0] = rect.Location;
            pts[1] = new Point(rect.X + rect.Width, rect.Y);
            pts[2] = new Point(rect.X + rect.Width, rect.Y + rect.Height);
            pts[3] = new Point(rect.X, rect.Y + rect.Height);
            for (int i = 0; i < 4; i++)
            {
                Point point = pts[i];
                Rectangle rc = new Rectangle(point.X - 3, point.Y - 3, 6, 6);
                if (rc.Contains(pt))
                    return i + 1;
            }
            return -1;
        }

        public Rectangle Scale(int handle, Rectangle rect, int dx, int dy)
        {
            Point[] pts = new Point[4];
            pts[0] = rect.Location;
            pts[1] = new Point(rect.X + rect.Width, rect.Y);
            pts[2] = new Point(rect.X, rect.Y + rect.Height);
            pts[3] = new Point(rect.X + rect.Width, rect.Y + rect.Height);
            switch (handle)
            {
                case 1:
                    pts[0].Offset(dx, dy);
                    return new Rectangle(pts[0].X, pts[0].Y, pts[3].X - pts[0].X, pts[3].Y - pts[0].Y);
                case 2:
                    pts[1].Offset(dx, dy);
                    return new Rectangle(pts[0].X, pts[1].Y, pts[1].X - pts[0].X, pts[3].Y - pts[1].Y);
                case 3:
                    pts[3].Offset(dx, dy);
                    return new Rectangle(pts[0].X, pts[0].Y, pts[3].X - pts[0].X, pts[3].Y - pts[0].Y);
                case 4:
                    pts[2].Offset(dx, dy);
                    return new Rectangle(pts[2].X, pts[0].Y, pts[3].X - pts[2].X, pts[2].Y - pts[0].Y);
                default:
                    break;
            }
            return new Rectangle(pts[0].X, pts[0].Y, pts[3].X - pts[0].X, pts[3].Y - pts[0].Y);
        }
    }
}
