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
        
        private Point centerDoc = Point.Empty;
        public Point CenterDoc
        {
            get { return centerDoc; }
            set { centerDoc = value; }
        }

        private int radius = 50;
        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        private Point firstDoc = Point.Empty;
        public Point FirstDoc
        {
            get { return firstDoc; }
            set { firstDoc = value; }
        }

        private Point secondDot = Point.Empty;
        public Point SecondDot
        {
            get { return secondDot; }
            set { secondDot = value; }
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

        private Point saveCenter = new Point();
        [XmlIgnore]
        [Browsable(false)]        
        public Point SaveCenter
        {
            get { return saveCenter; }
            set { saveCenter = value; }
        }

        private int saveRadiu = 50;
        [XmlIgnore]
        [Browsable(false)]       
        public int SaveRadiu
        {
            get { return saveRadiu; }
            set { saveRadiu = value; }
        }

        private Point saveFirstDot = Point.Empty;
        [XmlIgnore]
        [Browsable(false)]       
        public Point SaveFirstDot
        {
            get { return saveFirstDot; }
            set { saveFirstDot = value; }
        }

        private Point saveSecDot = Point.Empty;
        [XmlIgnore]
        [Browsable(false)]        
        public Point SaveSecDot
        {
            get { return saveSecDot; }
            set { saveSecDot = value; }
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
            CenterDoc = center;
            DirectionCurvedAttribute = DirectonCurved.first;
            DrawMultiFactor = multiFactor;
            Radius = (int)(Radius * multiFactor);
            Point pt_first = new Point();
            Point pt_sec = new Point();
            pt_first.X = center.X + Radius;
            pt_first.Y = center.Y;
            pt_sec.X = center.X;
            pt_sec.Y = center.Y + Radius;
            FirstDoc = pt_first;
            SecondDot = pt_sec;
            PtlToSavel();
            return this;
        }

        public override void Draw(Graphics _canvas)
        {
            if (_canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");
            if (CenterDoc.IsEmpty)
                throw new Exception("对象不存在");
            Rectangle rc = new Rectangle();
            rc.Location = new Point(CenterDoc .X - Radius, CenterDoc.Y - Radius);
            rc.Width = Radius * 2;
            rc.Height = Radius * 2;
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rc, StartAngle, SweepAngle);
            Pen pen = new Pen(Color.Black, 1);
            _canvas.DrawPath(pen, gp);
            pen.Dispose();
            gp.Dispose();
        }

        public override void DrawTracker(Graphics _canvas)
        {
            objectCurved.DrawTracker(_canvas, CenterDoc, Radius, DirectionCurvedAttribute);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return objectCurved.HitTest(point, isSelected, CenterDoc, Radius, DirectionCurvedAttribute);
        }

        protected override void Translate(int offsetX, int offsetY)
        {
            Point pt = CenterDoc;
            pt.Offset(offsetX, offsetY);
            CenterDoc = pt;
            pt = FirstDoc;
            pt.Offset(offsetX, offsetY);
            FirstDoc = pt;
            pt = SecondDot;
            pt.Offset(offsetX, offsetY);
            SecondDot = pt;
            PtlToSavel();
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            Point pt_first = new Point(FirstDoc.X, FirstDoc.Y);
            Point pt_sec = new Point(SecondDot.X, SecondDot.Y);
            Rectangle rc = objectCurved.Scale(handle, dx, dy, CenterDoc, Radius, DirectionCurvedAttribute);
            CenterDoc = rc.Location;
            Radius = rc.Width;
            switch (DirectionCurvedAttribute)
            {
                case DirectonCurved.first:
                    pt_first.X = CenterDoc.X + Radius;
                    pt_first.Y = CenterDoc.Y;
                    pt_sec.X = CenterDoc.X;
                    pt_sec.Y = CenterDoc.Y + Radius;
                    break;
                case DirectonCurved.second:
                    pt_first.X = CenterDoc.X;
                    pt_first.Y = CenterDoc.Y + Radius;
                    pt_sec.X = CenterDoc.X - Radius;
                    pt_sec.Y = CenterDoc.Y;
                    break;
                case DirectonCurved.third:
                    pt_first.X = CenterDoc.X - Radius;
                    pt_first.Y = CenterDoc.Y;
                    pt_sec.X = CenterDoc.X;
                    pt_sec.Y = CenterDoc.Y - Radius;
                    break;
                case DirectonCurved.four:
                    pt_first.X = CenterDoc.X;
                    pt_first.Y = CenterDoc.Y - Radius;
                    pt_sec.X = CenterDoc.X + Radius;
                    pt_sec.Y = CenterDoc.Y;
                    break;
                case DirectonCurved.NULL:
                    break;
            }
            FirstDoc = pt_first;
            SecondDot = pt_sec;
            PtlToSavel();
        }

        protected override void Rotate(Point pt, Size sz)
        {

        }

        public override void RotateCounterClw()
        {
            base.RotateCounterClw();
            RotateAngle = -90;
            Matrix matrix = new Matrix();
            PointF pt_center = new PointF();
            Point[] pts = new Point[4];
            pts[0] = CenterDoc;
            pts[1] = new Point(FirstDoc.X, FirstDoc.Y);
            pts[2] = new Point(SecondDot.X, SecondDot.Y);
            StartAngle = (StartAngle + 360) % 360;
            switch (StartAngle)
            {
                case 0:
                    DirectionCurvedAttribute = DirectonCurved.first;
                    pt_center.X = ((float)(CenterDoc.X + FirstDoc.X)) / 2;
                    pt_center.Y = ((float)(CenterDoc.Y + SecondDot.Y)) / 2;
                    DirectionCurvedAttribute = DirectonCurved.four;
                    break;
                case 90:
                    DirectionCurvedAttribute = DirectonCurved.second;
                    pt_center.X = ((float)(CenterDoc.X + SecondDot.X)) / 2;
                    pt_center.Y = ((float)(CenterDoc.Y + FirstDoc.Y)) / 2;
                    DirectionCurvedAttribute = DirectonCurved.first;
                    break;
                case 180:
                    DirectionCurvedAttribute = DirectonCurved.third;
                    pt_center.X = ((float)(CenterDoc.X + FirstDoc.X)) / 2;
                    pt_center.Y = ((float)(CenterDoc.Y + SecondDot.Y)) / 2;
                    DirectionCurvedAttribute = DirectonCurved.second;
                    break;
                case 270:
                    DirectionCurvedAttribute = DirectonCurved.four;
                    pt_center.X = ((float)(CenterDoc.X + SecondDot.X)) / 2;
                    pt_center.Y = ((float)(CenterDoc.Y + FirstDoc.Y)) / 2;
                    DirectionCurvedAttribute = DirectonCurved.third;
                    break;
            }
            StartAngle += RotateAngle;
            matrix.RotateAt(RotateAngle, pt_center);
            matrix.TransformPoints(pts);
            CenterDoc = pts[0];
            FirstDoc = pts[1];
            SecondDot = pts[2];
            PtlToSavel();
        }

        public override void RotateClw()
        {
            base.RotateClw();
            RotateAngle = 90;
            Matrix matrix = new Matrix();
            Point pt_center = new Point();
            Point[] pts = new Point[4];
            pts[0] = CenterDoc;
            pts[1] = new Point(FirstDoc.X, FirstDoc.Y);
            pts[2] = new Point(SecondDot.X, SecondDot.Y);
            StartAngle = (StartAngle + 360) % 360;
            switch (StartAngle)
            {
                case 0:
                    DirectionCurvedAttribute = DirectonCurved.first;
                    pt_center.X = (CenterDoc.X + FirstDoc.X) / 2;
                    pt_center.Y = (CenterDoc.Y + SecondDot.Y) / 2;
                    DirectionCurvedAttribute = DirectonCurved.second;
                    break;
                case 90:
                    DirectionCurvedAttribute = DirectonCurved.second;
                    pt_center.X = (CenterDoc.X + SecondDot.X) / 2;
                    pt_center.Y = (CenterDoc.Y + FirstDoc.Y) / 2;
                    DirectionCurvedAttribute = DirectonCurved.third;
                    break;
                case 180:
                    DirectionCurvedAttribute = DirectonCurved.third;
                    pt_center.X = (CenterDoc.X + FirstDoc.X) / 2;
                    pt_center.Y = (CenterDoc.Y + SecondDot.Y) / 2;
                    DirectionCurvedAttribute = DirectonCurved.four;
                    break;
                case 270:
                    DirectionCurvedAttribute = DirectonCurved.four;
                    pt_center.X = (CenterDoc.X + SecondDot.X) / 2;
                    pt_center.Y = (CenterDoc.Y + FirstDoc.Y) / 2;
                    DirectionCurvedAttribute = DirectonCurved.first;
                    break;
            }
            StartAngle += RotateAngle;
            matrix.RotateAt(RotateAngle, pt_center);
            matrix.TransformPoints(pts);
            CenterDoc = pts[0];
            FirstDoc = pts[1];
            SecondDot = pts[2];
            PtlToSavel();
        }

        public object Clone()
        {
            CurvedRailEle cl = new CurvedRailEle();
            cl.CenterDoc = CenterDoc;
            cl.Radius = Radius;
            cl.FirstDoc = FirstDoc;
            cl.SecondDot = SecondDot;
            cl.StartAngle = StartAngle;
            cl.SweepAngle = SweepAngle;
            cl.DirectionCurvedAttribute = DirectionCurvedAttribute;
            return cl;
        }

        public override void DrawEnlargeOrShrink(float _draw_multi_factor)
        {
            Point[] pts = new Point[3];
            pts[0] = SaveCenter;
            pts[1] = SaveFirstDot;
            pts[2] = SaveSecDot;
            if (_draw_multi_factor > 1)
            {
                pts[0].X = (int)(pts[0].X * DrawMultiFactor);
                pts[0].Y = (int)(pts[0].Y * DrawMultiFactor);
                pts[1].X = (int)(pts[1].X * DrawMultiFactor);
                pts[1].Y = (int)(pts[1].Y * DrawMultiFactor);
                pts[2].X = (int)(pts[2].X * DrawMultiFactor);
                pts[2].Y = (int)(pts[2].Y * DrawMultiFactor);               
            }
            CenterDoc = pts[0];
            FirstDoc = pts[1];
            SecondDot = pts[2];
            Radius = (int)Math.Sqrt((double)(pts[0].X - pts[1].X) * (pts[0].X - pts[1].X) + (double)(pts[0].Y - pts[1].Y) * (pts[0].Y - pts[1].Y));
            base.DrawEnlargeOrShrink(drawMultiFactor);
        }

        private void PtlToSavel()
        {
            Point[] pts = new Point[3];
            pts[0] = CenterDoc;
            pts[1] = FirstDoc;
            pts[2] = SecondDot;
            if (DrawMultiFactor > 1)
            {
                pts[0].X = (int)(pts[0].X / drawMultiFactor);
                pts[0].Y = (int)(pts[0].Y / drawMultiFactor);
                pts[1].X = (int)(pts[1].X / drawMultiFactor);
                pts[1].Y = (int)(pts[1].Y / drawMultiFactor);
                pts[2].X = (int)(pts[2].X / drawMultiFactor);
                pts[2].Y = (int)(pts[2].Y / drawMultiFactor);               
            }
            SaveCenter = pts[0];
            SaveFirstDot = pts[1];
            SaveSecDot = pts[2];
            SaveRadiu = (int)Math.Sqrt((double)(pts[0].X - pts[1].X) * (pts[0].X - pts[1].X) + (double)(pts[0].Y - pts[1].Y) * (pts[0].Y - pts[1].Y));
        }

        public override void ChangePropertyValue()
        {
            base.ChangePropertyValue();
//            CenterDoc = _ObjectCurved.ChangePropertyValue(CenterDoc, FirstDoc, SecondDot, Radius);
        }
    }
}
