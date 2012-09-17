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
    public class CurvedRailEle : BaseRailEle
    {
        private ObjectCurvedOp objectCurved = new ObjectCurvedOp();

        private int showRadius = 50;
        private Point showCenterDot = Point.Empty;
        private Point showFirstDot = Point.Empty;
        private Point showSecondDot = Point.Empty;

        private int startAngle = 0;
        [Browsable(false)]
        public int StartAngle
        {
            get { return startAngle; }
            set { startAngle = value; }
        }

        private int sweepAngle = 90;
        [Browsable(false)]
        public int SweepAngle
        {
            get { return sweepAngle; }
            set { sweepAngle = value; }
        }

        private int rotateAngle = 90;
        [Browsable(false)]
        private int RotateAngle
        {
            get { return rotateAngle; }
            set { rotateAngle = value; }
        }

        private Point oldCenter = new Point();

        private Point center = new Point();                
        public Point Center
        {
            get { return center; }
            set { oldCenter = center; center = value; }
        }

        private int oldRadiu = 50;

        private int radiu = 50;
        public int Radiu
        {
            get { return radiu; }
            set { oldRadiu = radiu; radiu = value; }
        }

        private Point firstDot = Point.Empty;
        public Point FirstDot
        {
            get { return firstDot; }
            set { firstDot = value; }
        }

        private Point secDot = Point.Empty;
        public Point SecDot
        {
            get { return secDot; }
            set { secDot = value; }
        }

        public enum DirectonCurved
        {
            first, second, third, four, NULL
        }
        private DirectonCurved directionCurved = DirectonCurved.NULL;
        [Browsable(false)]
        public DirectonCurved DirectionCurvedAttribute
        {
            get { return directionCurved; }
            set { directionCurved = value; }
        }
        
        public CurvedRailEle() { GraphType = 2; }

        public CurvedRailEle CreatEle(Point center, Size size, int multiFactor)
        {
            showCenterDot = center;
            directionCurved = DirectonCurved.first;
            DrawMultiFactor = multiFactor;
            showRadius = showRadius * multiFactor;
            Point pt_first = new Point(center.X + showRadius, center.Y);
            Point pt_sec = new Point(center.X, center.Y + showRadius);
            showFirstDot = pt_first;
            showSecondDot = pt_sec;
            PtlToSavel();
            return this;
        }

        public override void Draw(Graphics canvas)
        {
            if (canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");
            if (showCenterDot.IsEmpty)
            {
                if (center.IsEmpty)
                {
                    throw new Exception("对象不存在");
                }
                else
                {
                    showCenterDot = center;
                    showRadius = Radiu;
                    showFirstDot = firstDot;
                    showSecondDot = secDot;
                }
            }
            Rectangle rc = new Rectangle();
            rc.Location = new Point(showCenterDot .X - showRadius, showCenterDot.Y - showRadius);
            rc.Width = showRadius * 2;
            rc.Height = showRadius * 2;
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rc, startAngle, SweepAngle);
            Pen pen = new Pen(Color.Black, 1);
            canvas.DrawPath(pen, gp);
            pen.Dispose();
            gp.Dispose();
        }

        public override void DrawTracker(Graphics canvas)
        {
            objectCurved.DrawTracker(canvas, showCenterDot, showRadius, directionCurved);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return objectCurved.HitTest(point, isSelected, showCenterDot, showRadius, directionCurved);
        }

        protected override void Translate(int offsetX, int offsetY)
        {
            Point pt = showCenterDot;
            pt.Offset(offsetX, offsetY);
            showCenterDot = pt;
            pt = showFirstDot;
            pt.Offset(offsetX, offsetY);
            showFirstDot = pt;
            pt = showSecondDot;
            pt.Offset(offsetX, offsetY);
            showSecondDot = pt;
            PtlToSavel();
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            Point pt_first = new Point(showFirstDot.X, showFirstDot.Y);
            Point pt_sec = new Point(showSecondDot.X, showSecondDot.Y);
            Rectangle rc = objectCurved.Scale(handle, dx, dy, showCenterDot, showRadius, directionCurved);
            showCenterDot = rc.Location;
            showRadius = rc.Width;
            switch (directionCurved)
            {
                case DirectonCurved.first:
                    pt_first.X = showCenterDot.X + showRadius;
                    pt_first.Y = showCenterDot.Y;                   
                    pt_sec.X = showCenterDot.X;
                    pt_sec.Y = showCenterDot.Y + showRadius;
                    break;
                case DirectonCurved.second:
                    pt_first.X = showCenterDot.X;
                    pt_first.Y = showCenterDot.Y + showRadius;
                    pt_sec.X = showCenterDot.X - showRadius;
                    pt_sec.Y = showCenterDot.Y;
                    break;
                case DirectonCurved.third:
                    pt_first.X = showCenterDot.X - showRadius;
                    pt_first.Y = showCenterDot.Y;
                    pt_sec.X = showCenterDot.X;
                    pt_sec.Y = showCenterDot.Y - showRadius;
                    break;
                case DirectonCurved.four:
                    pt_first.X = showCenterDot.X;
                    pt_first.Y = showCenterDot.Y - showRadius;
                    pt_sec.X = showCenterDot.X + showRadius;
                    pt_sec.Y = showCenterDot.Y;
                    break;
                case DirectonCurved.NULL:
                    break;
            }
            showFirstDot = pt_first;
            showSecondDot = pt_sec;
            PtlToSavel();
        }

        public override void RotateCounterClw()
        {
            base.RotateCounterClw();
            RotateAngle = -90;
            Matrix matrix = new Matrix();
            PointF pt_center = new PointF();
            Point[] pts = new Point[4];
            pts[0] = showCenterDot;
            pts[1] = new Point(showFirstDot.X, showFirstDot.Y);
            pts[2] = new Point(showSecondDot.X, showSecondDot.Y);
            startAngle = (startAngle + 360) % 360;
            switch (startAngle)
            {
                case 0:
                    directionCurved = DirectonCurved.first;
                    pt_center.X = (float)(showCenterDot.X + showFirstDot.X) / 2;
                    pt_center.Y = (float)(showCenterDot.Y + showSecondDot.Y) / 2;
                    directionCurved = DirectonCurved.four;
                    break;
                case 90:
                    directionCurved = DirectonCurved.second;
                    pt_center.X = (float)(showCenterDot.X + showSecondDot.X) / 2;
                    pt_center.Y = (float)(showCenterDot.Y + showFirstDot.Y) / 2;
                    directionCurved = DirectonCurved.first;
                    break;
                case 180:
                    directionCurved = DirectonCurved.third;
                    pt_center.X = (float)(showCenterDot.X + showFirstDot.X) / 2;
                    pt_center.Y = (float)(showCenterDot.Y + showSecondDot.Y) / 2;
                    directionCurved = DirectonCurved.second;
                    break;
                case 270:
                    directionCurved = DirectonCurved.four;
                    pt_center.X = (float)(showCenterDot.X + showSecondDot.X) / 2;
                    pt_center.Y = (float)(showCenterDot.Y + showFirstDot.Y) / 2;
                    directionCurved = DirectonCurved.third;
                    break;
            }
            startAngle += rotateAngle;
            matrix.RotateAt(rotateAngle, pt_center);
            matrix.TransformPoints(pts);
            showCenterDot =pts[0];
            showFirstDot = pts[1];
            showSecondDot = pts[2];
            PtlToSavel();
        }

        public override void RotateClw()
        {
            base.RotateClw();
            RotateAngle = 90;
            Matrix matrix = new Matrix();
            PointF pt_center = PointF.Empty;
            Point[] pts = new Point[4];
            pts[0] = showCenterDot;
            pts[1] = new Point(showFirstDot.X, showFirstDot.Y);
            pts[2] = new Point(showSecondDot.X, showSecondDot.Y);
            startAngle = (startAngle + 360) % 360;
            switch (startAngle)
            {
                case 0:
                    directionCurved = DirectonCurved.first;
                    pt_center.X = (float)(showCenterDot.X + showFirstDot.X) / 2;
                    pt_center.Y = (float)(showCenterDot.Y + showSecondDot.Y) / 2;
                    directionCurved = DirectonCurved.second;
                    break;
                case 90:
                    directionCurved = DirectonCurved.second;
                    pt_center.X = (float)(showCenterDot.X + showSecondDot.X) / 2;
                    pt_center.Y = (float)(showCenterDot.Y + showFirstDot.Y) / 2;
                    directionCurved = DirectonCurved.third;
                    break;
                case 180:
                    directionCurved = DirectonCurved.third;
                    pt_center.X = (float)(showCenterDot.X + showFirstDot.X) / 2;
                    pt_center.Y = (float)(showCenterDot.Y + showSecondDot.Y) / 2;
                    directionCurved = DirectonCurved.four;
                    break;
                case 270:
                    directionCurved = DirectonCurved.four;
                    pt_center.X = (float)(showCenterDot.X + showSecondDot.X) / 2;
                    pt_center.Y = (float)(showCenterDot.Y + showFirstDot.Y) / 2;
                    directionCurved = DirectonCurved.first;
                    break;
            }
            startAngle += rotateAngle;
            matrix.RotateAt(rotateAngle, pt_center);
            matrix.TransformPoints(pts);
            showCenterDot = pts[0];
            showFirstDot = pts[1];
            showSecondDot = pts[2];
            PtlToSavel();
        }

        public object Clone()
        {
            CurvedRailEle cl = new CurvedRailEle();
            Point pt = new Point();
            cl.Center = center;
            cl.Radiu = Radiu;
            cl.firstDot = firstDot;
            cl.secDot = secDot;
            cl.showRadius = showRadius;
            pt = showCenterDot;
            pt.Offset(20, 20);
            cl.showCenterDot = pt;
            pt = showFirstDot;
            pt.Offset(20, 20);
            cl.showFirstDot = pt;
            pt = showSecondDot;
            pt.Offset(20, 20);
            cl.showSecondDot = pt;
            cl.startAngle = startAngle;
            cl.sweepAngle = sweepAngle;
            cl.DrawMultiFactor = DrawMultiFactor;
            cl.directionCurved = directionCurved;
            return cl;
        }

        public override void DrawEnlargeOrShrink(float multiFactor)
        {
            Point[] pts = new Point[3];
            pts[0] = center;
            pts[1] = firstDot;
            pts[2] = secDot;
            if (multiFactor > 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    pts[i].X = pts[i].X * DrawMultiFactor;
                    pts[i].Y = pts[i].Y * DrawMultiFactor;
                }
            }
            showCenterDot = pts[0];
            showFirstDot = pts[1];
            showSecondDot = pts[2];
            showRadius = Math.Abs(pts[0].X - pts[1].X) + Math.Abs(pts[0].Y - pts[1].Y);
            base.DrawEnlargeOrShrink(DrawMultiFactor);
        }

        private void PtlToSavel()
        {
            Point[] pts = new Point[3];
            pts[0] = showCenterDot;
            pts[1] = showFirstDot;
            pts[2] = showSecondDot;
            if (DrawMultiFactor > 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    pts[i].X = pts[i].X / DrawMultiFactor;
                    pts[i].Y = pts[i].Y / DrawMultiFactor;
                }           
            }
            Center = pts[0];
            firstDot = pts[1];
            secDot =pts[2];
            Radiu = Math.Abs(pts[0].X - pts[1].X) + Math.Abs(pts[0].Y - pts[1].Y);
        }

        public override void ChangePropertyValue()
        {
            Point[] pts = new Point[3];
            if (showRadius / DrawMultiFactor != Radiu)
            {
                showRadius = Radiu * DrawMultiFactor;               
                Rectangle rc = new Rectangle(
                    showCenterDot.X - showRadius, showCenterDot.Y - showRadius, 2 * showRadius, 2 * showRadius);
                switch (directionCurved)
                {
                    case DirectonCurved.first:
                        pts[0].X = showCenterDot.X + showRadius;
                        pts[0].Y = showCenterDot.Y;
                        pts[1].X = showCenterDot.X;
                        pts[1].Y = showCenterDot.Y + showRadius;
                        break;
                    case DirectonCurved.second:
                        pts[0].X = showCenterDot.X;
                        pts[0].Y = showCenterDot.Y + showRadius;
                        pts[1].X = showCenterDot.X - showRadius;
                        pts[1].Y = showCenterDot.Y;
                        break;
                    case DirectonCurved.third:
                        pts[0].X = showCenterDot.X - showRadius;
                        pts[0].Y = showCenterDot.Y;
                        pts[1].X = showCenterDot.X;
                        pts[1].Y = showCenterDot.Y - showRadius;
                        break;
                    case DirectonCurved.four:
                        pts[0].X = showCenterDot.X;
                        pts[0].Y = showCenterDot.Y - showRadius;
                        pts[1].X = showCenterDot.X + showRadius;
                        pts[1].Y = showCenterDot.Y;
                        break;
                    case DirectonCurved.NULL:
                        break;
                }
                showFirstDot = pts[0];
                showSecondDot = pts[1];               
            }
            else if (showCenterDot.X / DrawMultiFactor != center.X
                || showCenterDot.Y / DrawMultiFactor != center.Y)
            {
                int dx = 0, dy = 0;
                dx = center.X - oldCenter.X;
                dy = center.Y - oldCenter.Y;
                dx *= DrawMultiFactor;
                dy *= DrawMultiFactor;
                pts[0] = showFirstDot;
                pts[1] = showSecondDot;
                pts[2] = showCenterDot;
                for (int i = 0; i < 3; i++)
                {
                    pts[i].Offset(dx, dy);
                }
                showFirstDot = pts[0];
                showSecondDot = pts[1];
                showCenterDot = pts[2];
            }
            PtlToSavel();
            base.ChangePropertyValue();
        }

        public override bool ChosedInRegion(Rectangle rect)
        {
            if (rect.Contains(showCenterDot) && 
                rect.Contains(showFirstDot) && 
                rect.Contains(showSecondDot))
                return true;
            else
                return false;
        }
    }
}
