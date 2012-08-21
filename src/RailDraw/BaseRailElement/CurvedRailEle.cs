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
        private ObjectCurvedOp _ObjectCurved = new ObjectCurvedOp();
        
        private Point _centerdoc = Point.Empty;
        public Point CenterDoc
        {
            get { return _centerdoc; }
            set { _centerdoc = value; }
        }

        private int _radius = 50;
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        private Point _firstdoc = Point.Empty;
        public Point FirstDoc
        {
            get { return _firstdoc; }
            set { _firstdoc = value; }
        }

        private Point _seconddot = Point.Empty;
        public Point SecondDot
        {
            get { return _seconddot; }
            set { _seconddot = value; }
        }

        private int _startangle = 0;
        public int StartAngle
        {
            get { return _startangle; }
            set { _startangle = value; }
        }

        private int _sweepangle = 90;
        private int SweepAngle
        {
            get { return _sweepangle; }
            set { _sweepangle = value; }
        }

        private int _rotate_angle = 90;
        [Browsable(false)]
        public int Rotate_Angle
        {
            get { return _rotate_angle; }
            set { _rotate_angle = value; }
        }

        private Point _save_center = new Point();
        [XmlIgnore]
        [Browsable(false)]        
        public Point Save_Center
        {
            get { return _save_center; }
            set { _save_center = value; }
        }

        private int _save_radiu = 50;
        [XmlIgnore]
        [Browsable(false)]       
        public int Save_Radiu
        {
            get { return _save_radiu; }
            set { _save_radiu = value; }
        }

        private Point _save_first_dot = Point.Empty;
        [XmlIgnore]
        [Browsable(false)]       
        public Point Save_First_Dot
        {
            get { return _save_first_dot; }
            set { _save_first_dot = value; }
        }

        private Point _save_sec_dot = Point.Empty;
        [XmlIgnore]
        [Browsable(false)]        
        public Point Save_Sec_Dot
        {
            get { return _save_sec_dot; }
            set { _save_sec_dot = value; }
        }

        public enum DIRECTION_CURVED
        {
            FIRST, 
            SECOND, 
            THIRD, 
            FOUR,
            NULL
        }
        private DIRECTION_CURVED _direction_curved = DIRECTION_CURVED.NULL;
        public DIRECTION_CURVED DIRECTION_CURVED_ATTRIBUTE
        {
            get { return _direction_curved; }
            set { _direction_curved = value; }
        }

        public CurvedRailEle() { GraphType = 2; }

        public CurvedRailEle CreatEle(Point center, Size size)
        {
            CenterDoc = center;
            DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.FIRST;
            Point pt_first = new Point();
            Point pt_sec = new Point();
            pt_first.X = center.X + Radius;
            pt_first.Y = center.Y;
            pt_sec.X = center.X;
            pt_sec.Y = center.Y + Radius;
            FirstDoc = pt_first;
            SecondDot = pt_sec;

            Save_Center = CenterDoc;
            Save_First_Dot = FirstDoc;
            Save_Sec_Dot = SecondDot;
            return this;
        }

        public override void Draw(Graphics _canvas)
        {
            if (_canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");
            if (_centerdoc.IsEmpty)
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
            _ObjectCurved.DrawTracker(_canvas, CenterDoc, Radius, DIRECTION_CURVED_ATTRIBUTE);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return _ObjectCurved.HitTest(point, isSelected, CenterDoc, Radius, DIRECTION_CURVED_ATTRIBUTE);
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
            Rectangle rc = _ObjectCurved.Scale(handle, dx, dy, CenterDoc, Radius, DIRECTION_CURVED_ATTRIBUTE);
            CenterDoc = rc.Location;
            Radius = rc.Width;
            switch (DIRECTION_CURVED_ATTRIBUTE)
            {
                case DIRECTION_CURVED.FIRST:
                    pt_first.X = CenterDoc.X + Radius;
                    pt_first.Y = CenterDoc.Y;
                    pt_sec.X = CenterDoc.X;
                    pt_sec.Y = CenterDoc.Y + Radius;
                    break;
                case DIRECTION_CURVED.SECOND:
                    pt_first.X = CenterDoc.X;
                    pt_first.Y = CenterDoc.Y + Radius;
                    pt_sec.X = CenterDoc.X - Radius;
                    pt_sec.Y = CenterDoc.Y;
                    break;
                case DIRECTION_CURVED.THIRD:
                    pt_first.X = CenterDoc.X - Radius;
                    pt_first.Y = CenterDoc.Y;
                    pt_sec.X = CenterDoc.X;
                    pt_sec.Y = CenterDoc.Y - Radius;
                    break;
                case DIRECTION_CURVED.FOUR:
                    pt_first.X = CenterDoc.X;
                    pt_first.Y = CenterDoc.Y - Radius;
                    pt_sec.X = CenterDoc.X + Radius;
                    pt_sec.Y = CenterDoc.Y;
                    break;
                case DIRECTION_CURVED.NULL:
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
            Rotate_Angle = -90;
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
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.FIRST;
                    pt_center.X = ((float)(CenterDoc.X + FirstDoc.X)) / 2;
                    pt_center.Y = ((float)(CenterDoc.Y + SecondDot.Y)) / 2;
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.FOUR;
                    break;
                case 90:
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.SECOND;
                    pt_center.X = ((float)(CenterDoc.X + SecondDot.X)) / 2;
                    pt_center.Y = ((float)(CenterDoc.Y + FirstDoc.Y)) / 2;
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.FIRST;
                    break;
                case 180:
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.THIRD;
                    pt_center.X = ((float)(CenterDoc.X + FirstDoc.X)) / 2;
                    pt_center.Y = ((float)(CenterDoc.Y + SecondDot.Y)) / 2;
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.SECOND;
                    break;
                case 270:
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.FOUR;
                    pt_center.X = ((float)(CenterDoc.X + SecondDot.X)) / 2;
                    pt_center.Y = ((float)(CenterDoc.Y + FirstDoc.Y)) / 2;
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.THIRD;
                    break;
            }
            StartAngle += Rotate_Angle;
            matrix.RotateAt(Rotate_Angle, pt_center);
            matrix.TransformPoints(pts);
            CenterDoc = pts[0];
            FirstDoc = pts[1];
            SecondDot = pts[2];
            PtlToSavel();
        }

        public override void RotateClw()
        {
            base.RotateClw();
            Rotate_Angle = 90;
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
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.FIRST;
                    pt_center.X = (CenterDoc.X + FirstDoc.X) / 2;
                    pt_center.Y = (CenterDoc.Y + SecondDot.Y) / 2;
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.SECOND;
                    break;
                case 90:
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.SECOND;
                    pt_center.X = (CenterDoc.X + SecondDot.X) / 2;
                    pt_center.Y = (CenterDoc.Y + FirstDoc.Y) / 2;
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.THIRD;
                    break;
                case 180:
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.THIRD;
                    pt_center.X = (CenterDoc.X + FirstDoc.X) / 2;
                    pt_center.Y = (CenterDoc.Y + SecondDot.Y) / 2;
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.FOUR;
                    break;
                case 270:
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.FOUR;
                    pt_center.X = (CenterDoc.X + SecondDot.X) / 2;
                    pt_center.Y = (CenterDoc.Y + FirstDoc.Y) / 2;
                    DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED.FIRST;
                    break;
            }
            StartAngle += Rotate_Angle;
            matrix.RotateAt(Rotate_Angle, pt_center);
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
            cl.DIRECTION_CURVED_ATTRIBUTE = DIRECTION_CURVED_ATTRIBUTE;
            return cl;
        }

        public override void DrawEnlargeOrShrink(float _draw_multi_factor)
        {
            Point[] pts = new Point[3];
            pts[0] = Save_Center;
            pts[1] = Save_First_Dot;
            pts[2] = Save_Sec_Dot;
            if (_draw_multi_factor > 1)
            {
                pts[0].X = (int)(pts[0].X * Draw_Multi_Factor);
                pts[0].Y = (int)(pts[0].Y * Draw_Multi_Factor);
                pts[1].X = (int)(pts[1].X * Draw_Multi_Factor);
                pts[1].Y = (int)(pts[1].Y * Draw_Multi_Factor);
                pts[2].X = (int)(pts[2].X * Draw_Multi_Factor);
                pts[2].Y = (int)(pts[2].Y * Draw_Multi_Factor);               
            }
            CenterDoc = pts[0];
            FirstDoc = pts[1];
            SecondDot = pts[2];
            Radius = (int)Math.Sqrt((double)(pts[0].X - pts[1].X) * (pts[0].X - pts[1].X) + (double)(pts[0].Y - pts[1].Y) * (pts[0].Y - pts[1].Y));
            base.DrawEnlargeOrShrink(draw_multi_factor);
        }

        private void PtlToSavel()
        {
            Point[] pts = new Point[3];
            pts[0] = CenterDoc;
            pts[1] = FirstDoc;
            pts[2] = SecondDot;
            if (Draw_Multi_Factor > 1)
            {
                pts[0].X = (int)(pts[0].X / draw_multi_factor);
                pts[0].Y = (int)(pts[0].Y / draw_multi_factor);
                pts[1].X = (int)(pts[1].X / draw_multi_factor);
                pts[1].Y = (int)(pts[1].Y / draw_multi_factor);
                pts[2].X = (int)(pts[2].X / draw_multi_factor);
                pts[2].Y = (int)(pts[2].Y / draw_multi_factor);               
            }
            Save_Center = pts[0];
            Save_First_Dot = pts[1];
            Save_Sec_Dot = pts[2];
            Save_Radiu = (int)Math.Sqrt((double)(pts[0].X - pts[1].X) * (pts[0].X - pts[1].X) + (double)(pts[0].Y - pts[1].Y) * (pts[0].Y - pts[1].Y));
        }

        public override void ChangePropertyValue()
        {
            base.ChangePropertyValue();
//            CenterDoc = _ObjectCurved.ChangePropertyValue(CenterDoc, FirstDoc, SecondDot, Radius);
        }
    }
}
