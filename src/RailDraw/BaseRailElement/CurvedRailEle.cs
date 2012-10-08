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
        private ObjectCurvedOp objectCurvedOp = new ObjectCurvedOp();

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

        private Point oldFirstDot = Point.Empty;

        private Point firstDot = Point.Empty;
        public Point FirstDot
        {
            get { return firstDot; }
            set { oldFirstDot = firstDot; firstDot = value; }
        }

        private Point oldSecDot = Point.Empty;

        private Point secDot = Point.Empty;
        public Point SecDot
        {
            get { return secDot; }
            set { oldSecDot = secDot; secDot = value; }
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

        public CurvedRailEle CreatEle(Point centerDot, Size size, int multiFactor)
        {
            DrawMultiFactor = multiFactor;
            objectCurvedOp.DrawMultiFactor = DrawMultiFactor;
            Point pt = centerDot;
            pt.Offset(centerDot.X / DrawMultiFactor - centerDot.X, centerDot.Y / DrawMultiFactor - centerDot.Y);
            center = pt;
            directionCurved = DirectonCurved.first;
            Point pt_first = new Point(center.X + radiu, center.Y);
            Point pt_sec = new Point(center.X, center.Y + radiu);
            firstDot = pt_first;
            secDot = pt_sec;
            return this;
        }

        public override void Draw(Graphics canvas)
        {
            if (canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");
            if (center.IsEmpty)
            {
                throw new Exception("对象不存在");
            }
            Rectangle rc = new Rectangle();
            rc.Location = new Point((center.X - radiu) * DrawMultiFactor, (center.Y - radiu) * DrawMultiFactor);
            rc.Width = radiu * 2 * DrawMultiFactor;
            rc.Height = radiu * 2 * DrawMultiFactor;
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rc, startAngle, sweepAngle);
            Pen pen = new Pen(Color.Black, 1);
            canvas.DrawPath(pen, gp);
            pen.Dispose();
            gp.Dispose();
        }

        public override void DrawTracker(Graphics canvas)
        {
            objectCurvedOp.DrawTracker(canvas, center, radiu, directionCurved);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return objectCurvedOp.HitTest(point, isSelected, center, radiu, directionCurved);
        }

        protected override void Translate(int offsetX, int offsetY)
        {
            Point pt = center;
            pt.Offset(offsetX, offsetY);
            Center = pt;
            pt = firstDot;
            pt.Offset(offsetX, offsetY);
            firstDot = pt;
            pt = secDot;
            pt.Offset(offsetX, offsetY);
            secDot = pt;
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            Point pt_first = firstDot;
            Point pt_sec = secDot;
            Rectangle rc = objectCurvedOp.Scale(handle, dx, dy, center, radiu, directionCurved);
            Center = rc.Location;
            Radiu = rc.Width;
            switch (directionCurved)
            {
                case DirectonCurved.first:
                    pt_first.X = center.X + radiu;
                    pt_first.Y = center.Y;                   
                    pt_sec.X = center.X;
                    pt_sec.Y = center.Y + radiu;
                    break;
                case DirectonCurved.second:
                    pt_first.X = center.X;
                    pt_first.Y = center.Y + radiu;
                    pt_sec.X = center.X - radiu;
                    pt_sec.Y = center.Y;
                    break;
                case DirectonCurved.third:
                    pt_first.X = center.X - radiu;
                    pt_first.Y = center.Y;
                    pt_sec.X = center.X;
                    pt_sec.Y = center.Y - radiu;
                    break;
                case DirectonCurved.four:
                    pt_first.X = center.X;
                    pt_first.Y = center.Y - radiu;
                    pt_sec.X = center.X + radiu;
                    pt_sec.Y = center.Y;
                    break;
                case DirectonCurved.NULL:
                    break;
            }
            firstDot = pt_first;
            secDot = pt_sec;
        }

        public override void RotateCounterClw()
        {
            base.RotateCounterClw();
            RotateAngle = -90;
            Matrix matrix = new Matrix();
            PointF pt_center = new PointF();
            Point[] pts = new Point[4];
            pts[0] = center;
            pts[1] = firstDot;
            pts[2] = secDot;
            startAngle = (startAngle + 360) % 360;
            switch (startAngle)
            {
                case 0:
                    directionCurved = DirectonCurved.first;
                    pt_center.X = (float)(center.X + firstDot.X) / 2;
                    pt_center.Y = (float)(center.Y + secDot.Y) / 2;
                    directionCurved = DirectonCurved.four;
                    break;
                case 90:
                    directionCurved = DirectonCurved.second;
                    pt_center.X = (float)(center.X + secDot.X) / 2;
                    pt_center.Y = (float)(center.Y + firstDot.Y) / 2;
                    directionCurved = DirectonCurved.first;
                    break;
                case 180:
                    directionCurved = DirectonCurved.third;
                    pt_center.X = (float)(center.X + firstDot.X) / 2;
                    pt_center.Y = (float)(center.Y + secDot.Y) / 2;
                    directionCurved = DirectonCurved.second;
                    break;
                case 270:
                    directionCurved = DirectonCurved.four;
                    pt_center.X = (float)(center.X + secDot.X) / 2;
                    pt_center.Y = (float)(center.Y + firstDot.Y) / 2;
                    directionCurved = DirectonCurved.third;
                    break;
            }
            startAngle += rotateAngle;
            matrix.RotateAt(rotateAngle, pt_center);
            matrix.TransformPoints(pts);
            center =pts[0];
            firstDot = pts[1];
            secDot = pts[2];
        }

        public override void RotateClw()
        {
            base.RotateClw();
            RotateAngle = 90;
            Matrix matrix = new Matrix();
            PointF pt_center = PointF.Empty;
            Point[] pts = new Point[4];
            pts[0] = center;
            pts[1] = firstDot;
            pts[2] = secDot;
            startAngle = (startAngle + 360) % 360;
            switch (startAngle)
            {
                case 0:
                    directionCurved = DirectonCurved.first;
                    pt_center.X = (float)(center.X + firstDot.X) / 2;
                    pt_center.Y = (float)(center.Y + secDot.Y) / 2;
                    directionCurved = DirectonCurved.second;
                    break;
                case 90:
                    directionCurved = DirectonCurved.second;
                    pt_center.X = (float)(center.X + secDot.X) / 2;
                    pt_center.Y = (float)(center.Y + firstDot.Y) / 2;
                    directionCurved = DirectonCurved.third;
                    break;
                case 180:
                    directionCurved = DirectonCurved.third;
                    pt_center.X = (float)(center.X + firstDot.X) / 2;
                    pt_center.Y = (float)(center.Y + secDot.Y) / 2;
                    directionCurved = DirectonCurved.four;
                    break;
                case 270:
                    directionCurved = DirectonCurved.four;
                    pt_center.X = (float)(center.X + secDot.X) / 2;
                    pt_center.Y = (float)(center.Y + firstDot.Y) / 2;
                    directionCurved = DirectonCurved.first;
                    break;
            }
            startAngle += rotateAngle;
            matrix.RotateAt(rotateAngle, pt_center);
            matrix.TransformPoints(pts);
            center = pts[0];
            firstDot = pts[1];
            secDot = pts[2];
        }

        public object Clone()
        {
            CurvedRailEle cl = new CurvedRailEle();
            Point pt = new Point();
            pt = center;
            pt.Offset(20, 20);
            cl.Center = pt;
            pt = firstDot;
            pt.Offset(20, 20);
            cl.firstDot = pt;
            pt = secDot;
            pt.Offset(20, 20);
            cl.secDot = pt;
            cl.Radiu = Radiu;
            cl.startAngle = startAngle;
            cl.sweepAngle = sweepAngle;
            cl.DrawMultiFactor = DrawMultiFactor;
            cl.directionCurved = directionCurved;
            cl.objectCurvedOp.DrawMultiFactor = DrawMultiFactor;
            return cl;
        }

        public override void DrawEnlargeOrShrink(float multiFactor)
        {
            objectCurvedOp.DrawMultiFactor = Convert.ToInt16(multiFactor);
            base.DrawEnlargeOrShrink(DrawMultiFactor);
        }

        public override void ChangePropertyValue()
        {
            Point[] pts = new Point[3];
            int dx = 0, dy = 0;
            if (oldRadiu != radiu)
            {
                switch (directionCurved)
                {
                    case DirectonCurved.first:
                        pts[0].X = center.X + radiu;
                        pts[0].Y = center.Y;
                        pts[1].X = center.X;
                        pts[1].Y = center.Y + radiu;
                        break;
                    case DirectonCurved.second:
                        pts[0].X = center.X;
                        pts[0].Y = center.Y + radiu;
                        pts[1].X = center.X - radiu;
                        pts[1].Y = center.Y;
                        break;
                    case DirectonCurved.third:
                        pts[0].X = center.X - radiu;
                        pts[0].Y = center.Y;
                        pts[1].X = center.X;
                        pts[1].Y = center.Y - radiu;
                        break;
                    case DirectonCurved.four:
                        pts[0].X = center.X;
                        pts[0].Y = center.Y - radiu;
                        pts[1].X = center.X + radiu;
                        pts[1].Y = center.Y;
                        break;
                    case DirectonCurved.NULL:
                        break;
                }
                firstDot = pts[0];
                secDot = pts[1];
                oldRadiu = radiu;
            }
            else if (oldCenter.X != center.X
                || oldCenter.Y != center.Y)
            {           
                dx = center.X - oldCenter.X;
                dy = center.Y - oldCenter.Y;
                firstDot.Offset(dx, dy);
                secDot.Offset(dx, dy);
                oldCenter = center;
            }
            else if (oldFirstDot.X != firstDot.X
                || oldFirstDot.Y != firstDot.Y)
            {
                dx = firstDot.X - oldFirstDot.X;
                dy = firstDot.Y - oldFirstDot.Y;
                center.Offset(dx, dy);
                secDot.Offset(dx, dy);
                oldFirstDot = firstDot;
            }
            else if (oldSecDot.X != secDot.X
                || oldSecDot.Y != secDot.Y)
            {
                dx = secDot.X - oldSecDot.X;
                dy = secDot.Y - oldSecDot.Y;
                center.Offset(dx, dy);
                firstDot.Offset(dx, dy);
                oldSecDot = secDot;
            }
            base.ChangePropertyValue();
        }

        public override bool ChosedInRegion(Rectangle rect)
        {
            Point[] pts = new Point[3];
            pts[0].X = center.X * DrawMultiFactor;
            pts[0].Y = center.Y * DrawMultiFactor;
            pts[1].X = firstDot.X * DrawMultiFactor;
            pts[1].Y = firstDot.Y * DrawMultiFactor;
            pts[2].X = secDot.X * DrawMultiFactor;
            pts[2].Y = secDot.Y * DrawMultiFactor;
            if (rect.Contains(pts[0]) && rect.Contains(pts[1]) && rect.Contains(pts[2]))
                return true;
            else
                return false;
        }
    }
}
