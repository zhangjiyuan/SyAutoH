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

        private Point showCenterDoc = Point.Empty;
        [XmlIgnore]
        [Browsable(false)]
        public Point ShowCenterDoc
        {
            get { return showCenterDoc; }
            set { showCenterDoc = value; }
        }

        private int showRadius = 50;
        [XmlIgnore]
        [Browsable(false)] 
        public int ShowRadius
        {
            get { return showRadius; }
            set { showRadius = value; }
        }

        private Point showFirstDoc = Point.Empty;
        [XmlIgnore]
        [Browsable(false)]  
        public Point ShowFirstDoc
        {
            get { return showFirstDoc; }
            set { showFirstDoc = value; }
        }

        private Point showSecondDot = Point.Empty;
        [XmlIgnore]
        [Browsable(false)]   
        public Point ShowSecondDot
        {
            get { return showSecondDot; }
            set { showSecondDot = value; }
        }

        private int startAngle = 0;
        public int StartAngle
        {
            get { return startAngle; }
            set { startAngle = value; }
        }

        private int sweepAngle = 90;
        private int SweepAngle
        {
            get { return sweepAngle; }
            set { sweepAngle = value; }
        }

        private int rotateAngle = 90;
        [Browsable(false)]
        public int RotateAngle
        {
            get { return rotateAngle; }
            set { rotateAngle = value; }
        }

        private Point center = new Point();                
        public Point Center
        {
            get { return center; }
            set { center = value; }
        }

        private int radiu = 50;
        public int Radiu
        {
            get { return radiu; }
            set { radiu = value; }
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
            first, 
            second, 
            third, 
            four,
            NULL
        }
        private DirectonCurved directionCurved = DirectonCurved.NULL;
        public DirectonCurved DirectionCurvedAttribute
        {
            get { return directionCurved; }
            set { directionCurved = value; }
        }
        
        public CurvedRailEle() { GraphType = 2; }

        public CurvedRailEle CreatEle(Point center, Size size, float multiFactor)
        {
            ShowCenterDoc = center;
            DirectionCurvedAttribute = DirectonCurved.first;
            DrawMultiFactor = multiFactor;
            ShowRadius = (int)(ShowRadius * multiFactor);
            Point pt_first = new Point();
            Point pt_sec = new Point();
            pt_first.X = center.X + ShowRadius;
            pt_first.Y = center.Y;
            pt_sec.X = center.X;
            pt_sec.Y = center.Y + ShowRadius;
            ShowFirstDoc = pt_first;
            ShowSecondDot = pt_sec;
            PtlToSavel();
            return this;
        }

        public override void Draw(Graphics canvas)
        {
            if (canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");
            if (ShowCenterDoc.IsEmpty)
            {
                if (Center.IsEmpty)
                {
                    throw new Exception("对象不存在");
                }
                else
                {
                    ShowCenterDoc = Center;
                    ShowRadius = Radiu;
                    ShowFirstDoc = FirstDot;
                    ShowSecondDot = SecDot;
                }
            }
            Rectangle rc = new Rectangle();
            rc.Location = new Point(ShowCenterDoc .X - ShowRadius, ShowCenterDoc.Y - ShowRadius);
            rc.Width = ShowRadius * 2;
            rc.Height = ShowRadius * 2;
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rc, StartAngle, SweepAngle);
            Pen pen = new Pen(Color.Black, 1);
            canvas.DrawPath(pen, gp);
            pen.Dispose();
            gp.Dispose();
        }

        public override void DrawTracker(Graphics _canvas)
        {
            objectCurved.DrawTracker(_canvas, ShowCenterDoc, ShowRadius, DirectionCurvedAttribute);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return objectCurved.HitTest(point, isSelected, ShowCenterDoc, ShowRadius, DirectionCurvedAttribute);
        }

        protected override void Translate(int offsetX, int offsetY)
        {
            Point pt = ShowCenterDoc;
            pt.Offset(offsetX, offsetY);
            ShowCenterDoc = pt;
            pt = ShowFirstDoc;
            pt.Offset(offsetX, offsetY);
            ShowFirstDoc = pt;
            pt = ShowSecondDot;
            pt.Offset(offsetX, offsetY);
            ShowSecondDot = pt;
            PtlToSavel();
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            Point pt_first = new Point(ShowFirstDoc.X, ShowFirstDoc.Y);
            Point pt_sec = new Point(ShowSecondDot.X, ShowSecondDot.Y);
            Rectangle rc = objectCurved.Scale(handle, dx, dy, ShowCenterDoc, ShowRadius, DirectionCurvedAttribute);
            ShowCenterDoc = rc.Location;
            ShowRadius = rc.Width;
            switch (DirectionCurvedAttribute)
            {
                case DirectonCurved.first:
                    pt_first.X = ShowCenterDoc.X + ShowRadius;
                    pt_first.Y = ShowCenterDoc.Y;
                    pt_sec.X = ShowCenterDoc.X;
                    pt_sec.Y = ShowCenterDoc.Y + ShowRadius;
                    break;
                case DirectonCurved.second:
                    pt_first.X = ShowCenterDoc.X;
                    pt_first.Y = ShowCenterDoc.Y + ShowRadius;
                    pt_sec.X = ShowCenterDoc.X - ShowRadius;
                    pt_sec.Y = ShowCenterDoc.Y;
                    break;
                case DirectonCurved.third:
                    pt_first.X = ShowCenterDoc.X - ShowRadius;
                    pt_first.Y = ShowCenterDoc.Y;
                    pt_sec.X = ShowCenterDoc.X;
                    pt_sec.Y = ShowCenterDoc.Y - ShowRadius;
                    break;
                case DirectonCurved.four:
                    pt_first.X = ShowCenterDoc.X;
                    pt_first.Y = ShowCenterDoc.Y - ShowRadius;
                    pt_sec.X = ShowCenterDoc.X + ShowRadius;
                    pt_sec.Y = ShowCenterDoc.Y;
                    break;
                case DirectonCurved.NULL:
                    break;
            }
            ShowFirstDoc = pt_first;
            ShowSecondDot = pt_sec;
            PtlToSavel();
        }

        public override void RotateCounterClw()
        {
            base.RotateCounterClw();
            RotateAngle = -90;
            Matrix matrix = new Matrix();
            PointF pt_center = new PointF();
            Point[] pts = new Point[4];
            pts[0] = ShowCenterDoc;
            pts[1] = new Point(ShowFirstDoc.X, ShowFirstDoc.Y);
            pts[2] = new Point(ShowSecondDot.X, ShowSecondDot.Y);
            StartAngle = (StartAngle + 360) % 360;
            switch (StartAngle)
            {
                case 0:
                    DirectionCurvedAttribute = DirectonCurved.first;
                    pt_center.X = ((float)(ShowCenterDoc.X + ShowFirstDoc.X)) / 2;
                    pt_center.Y = ((float)(ShowCenterDoc.Y + ShowSecondDot.Y)) / 2;
                    DirectionCurvedAttribute = DirectonCurved.four;
                    break;
                case 90:
                    DirectionCurvedAttribute = DirectonCurved.second;
                    pt_center.X = ((float)(ShowCenterDoc.X + ShowSecondDot.X)) / 2;
                    pt_center.Y = ((float)(ShowCenterDoc.Y + ShowFirstDoc.Y)) / 2;
                    DirectionCurvedAttribute = DirectonCurved.first;
                    break;
                case 180:
                    DirectionCurvedAttribute = DirectonCurved.third;
                    pt_center.X = ((float)(ShowCenterDoc.X + ShowFirstDoc.X)) / 2;
                    pt_center.Y = ((float)(ShowCenterDoc.Y + ShowSecondDot.Y)) / 2;
                    DirectionCurvedAttribute = DirectonCurved.second;
                    break;
                case 270:
                    DirectionCurvedAttribute = DirectonCurved.four;
                    pt_center.X = ((float)(ShowCenterDoc.X + ShowSecondDot.X)) / 2;
                    pt_center.Y = ((float)(ShowCenterDoc.Y + ShowFirstDoc.Y)) / 2;
                    DirectionCurvedAttribute = DirectonCurved.third;
                    break;
            }
            StartAngle += RotateAngle;
            matrix.RotateAt(RotateAngle, pt_center);
            matrix.TransformPoints(pts);
            ShowCenterDoc = pts[0];
            ShowFirstDoc = pts[1];
            ShowSecondDot = pts[2];
            PtlToSavel();
        }

        public override void RotateClw()
        {
            base.RotateClw();
            RotateAngle = 90;
            Matrix matrix = new Matrix();
            Point pt_center = new Point();
            Point[] pts = new Point[4];
            pts[0] = ShowCenterDoc;
            pts[1] = new Point(ShowFirstDoc.X, ShowFirstDoc.Y);
            pts[2] = new Point(ShowSecondDot.X, ShowSecondDot.Y);
            StartAngle = (StartAngle + 360) % 360;
            switch (StartAngle)
            {
                case 0:
                    DirectionCurvedAttribute = DirectonCurved.first;
                    pt_center.X = (ShowCenterDoc.X + ShowFirstDoc.X) / 2;
                    pt_center.Y = (ShowCenterDoc.Y + ShowSecondDot.Y) / 2;
                    DirectionCurvedAttribute = DirectonCurved.second;
                    break;
                case 90:
                    DirectionCurvedAttribute = DirectonCurved.second;
                    pt_center.X = (ShowCenterDoc.X + ShowSecondDot.X) / 2;
                    pt_center.Y = (ShowCenterDoc.Y + ShowFirstDoc.Y) / 2;
                    DirectionCurvedAttribute = DirectonCurved.third;
                    break;
                case 180:
                    DirectionCurvedAttribute = DirectonCurved.third;
                    pt_center.X = (ShowCenterDoc.X + ShowFirstDoc.X) / 2;
                    pt_center.Y = (ShowCenterDoc.Y + ShowSecondDot.Y) / 2;
                    DirectionCurvedAttribute = DirectonCurved.four;
                    break;
                case 270:
                    DirectionCurvedAttribute = DirectonCurved.four;
                    pt_center.X = (ShowCenterDoc.X + ShowSecondDot.X) / 2;
                    pt_center.Y = (ShowCenterDoc.Y + ShowFirstDoc.Y) / 2;
                    DirectionCurvedAttribute = DirectonCurved.first;
                    break;
            }
            StartAngle += RotateAngle;
            matrix.RotateAt(RotateAngle, pt_center);
            matrix.TransformPoints(pts);
            ShowCenterDoc = pts[0];
            ShowFirstDoc = pts[1];
            ShowSecondDot = pts[2];
            PtlToSavel();
        }

        public object Clone()
        {
            CurvedRailEle cl = new CurvedRailEle();
            cl.Center = Center;
            cl.Radiu = Radiu;
            cl.FirstDot = FirstDot;
            cl.SecDot = SecDot;
            cl.ShowCenterDoc = ShowCenterDoc;
            cl.ShowRadius = ShowRadius;
            cl.ShowFirstDoc = ShowFirstDoc;
            cl.ShowSecondDot = ShowSecondDot;
            cl.StartAngle = StartAngle;
            cl.SweepAngle = SweepAngle;
            cl.DrawMultiFactor = DrawMultiFactor;
            cl.DirectionCurvedAttribute = DirectionCurvedAttribute;
            return cl;
        }

        public override void DrawEnlargeOrShrink(float multiFactor)
        {
            Point[] pts = new Point[3];
            pts[0] = Center;
            pts[1] = FirstDot;
            pts[2] = SecDot;
            if (multiFactor > 1)
            {
                pts[0].X = (int)(pts[0].X * DrawMultiFactor);
                pts[0].Y = (int)(pts[0].Y * DrawMultiFactor);
                pts[1].X = (int)(pts[1].X * DrawMultiFactor);
                pts[1].Y = (int)(pts[1].Y * DrawMultiFactor);
                pts[2].X = (int)(pts[2].X * DrawMultiFactor);
                pts[2].Y = (int)(pts[2].Y * DrawMultiFactor);               
            }
            ShowCenterDoc = pts[0];
            ShowFirstDoc = pts[1];
            ShowSecondDot = pts[2];
            ShowRadius = (int)Math.Sqrt((double)(pts[0].X - pts[1].X) * (pts[0].X - pts[1].X) + (double)(pts[0].Y - pts[1].Y) * (pts[0].Y - pts[1].Y));
            base.DrawEnlargeOrShrink(DrawMultiFactor);
        }

        private void PtlToSavel()
        {
            Point[] pts = new Point[3];
            pts[0] = ShowCenterDoc;
            pts[1] = ShowFirstDoc;
            pts[2] = ShowSecondDot;
            if (DrawMultiFactor > 1)
            {
                pts[0].X = (int)(pts[0].X / DrawMultiFactor);
                pts[0].Y = (int)(pts[0].Y / DrawMultiFactor);
                pts[1].X = (int)(pts[1].X / DrawMultiFactor);
                pts[1].Y = (int)(pts[1].Y / DrawMultiFactor);
                pts[2].X = (int)(pts[2].X / DrawMultiFactor);
                pts[2].Y = (int)(pts[2].Y / DrawMultiFactor);               
            }
            Center = pts[0];
            FirstDot = pts[1];
            SecDot = pts[2];
            Radiu = (int)Math.Sqrt((double)(pts[0].X - pts[1].X) * (pts[0].X - pts[1].X) + (double)(pts[0].Y - pts[1].Y) * (pts[0].Y - pts[1].Y));
        }

        public override void ChangePropertyValue()
        {
            base.ChangePropertyValue();
//            ShowCenterDoc = _ObjectCurved.ChangePropertyValue(ShowCenterDoc, ShowFirstDoc, SecondDot, ShowRadius);
        }
    }
}
