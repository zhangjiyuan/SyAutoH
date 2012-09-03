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
using System.Windows.Forms;

namespace BaseRailElement
{
    public class CrossEle : BaseRailEle
    {
        ObjectCrossOp objectCrossOp = new ObjectCrossOp();
        private Pen pen = new Pen(Color.Black, 1);

        private bool mirror = false;
        [Browsable(false)]
        public bool Mirror
        {
            get { return mirror; }
            set { mirror = value; }
        }

        private int lenghtOfStrai = 100;

        private int firstPart = 30;
        [Category("lenght")]
        public int FirstPart
        {
            get { return objectCrossOp.FirstPart; }
            set { firstPart = value; objectCrossOp.FirstPart = value; }
        }

        private int secPart = 40;
        [Category("lenght")]
        public int SecPart
        {
            get { return objectCrossOp.SecPart; }
            set { secPart = value; objectCrossOp.SecPart = value; }
        }

        private int thPart = 30;
        [Category("lenght")]
        public int ThPart
        {
            get { return objectCrossOp.ThPart; }
            set { thPart = value; objectCrossOp.ThPart = value; }
        }

        private Point fourPart = new Point(40, 40);
        [Category("lenght")]
        public Point FourPart
        {
            get { return objectCrossOp.FourPart; }
            set { fourPart = value; objectCrossOp.FourPart = value; }
        }

        [XmlIgnore]
        [Browsable(false)]
        public List<Point> PointList
        {
            get { return objectCrossOp.PointList; }
        }

        [Browsable(false)]
        public List<Point> SaveList
        {
            get { return objectCrossOp.SaveList; }
        }

        private int startAngle = 0;
        [Browsable(false)]
        public int StartAngle
        {
            get { return startAngle; }
            set { startAngle = value; }
        }

        private int rotateAngle = 90;
        [Browsable(false)]
        public int RotateAngle
        {
            get { return rotateAngle; }
            set { rotateAngle = value; }
        }

        public enum DirectionCross
        {
            first,
            second,
            third,
            four,
            NULL
        }
        private DirectionCross directionOfCross = DirectionCross.NULL;
        [Browsable(false)]
        public DirectionCross DirectionOfCross
        {
            get { return directionOfCross; }
            set { directionOfCross = value; }
        }

        public CrossEle() { GraphType = 5; }

        public CrossEle CreatEle(Point pt, Size size, int multiFactor)
        {
            Point[] pts = new Point[8];
            DrawMultiFactor = multiFactor;
            pts[0] = pt;
            pts[1].X = pts[0].X + firstPart * multiFactor;
            pts[1].Y = pts[0].Y;
            pts[2].X = pts[1].X;
            pts[2].Y = pts[0].Y + 5 * multiFactor;
            pts[3].X = pts[0].X + (firstPart + secPart) * multiFactor;
            pts[3].Y = pts[2].Y;
            pts[4].X = pts[3].X;
            pts[4].Y = pts[0].Y;
            pts[5].X = pts[0].X + lenghtOfStrai * multiFactor;
            pts[5].Y = pts[0].Y;
            pts[6].X = pts[1].X;
            pts[6].Y = pts[0].Y - 5 * multiFactor;
            pts[7].X = pts[3].X;
            pts[7].Y = pts[0].Y - 45* multiFactor;
            PointList.AddRange(pts);
            directionOfCross = DirectionCross.first;
            PtlToSavel();
            return this;
        }

        public override void Draw(Graphics canvas)
        {           
            if (canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");
            if (PointList.Count < 2)
            {
                if (SaveList.Count < 2)
                {
                    throw new Exception("对象不存在");
                }
                else
                {
                    Point[] pts = new Point[8];
                    SaveList.CopyTo(pts);
                    PointList.AddRange(pts);
                }
            }
            int n = PointList.Count;
            Point[] points = new Point[2];
            for (int i=0; i < n; i++, i++)
            {
                points[0] = PointList[i];
                points[1] = PointList[i + 1];
                canvas.DrawLines(pen, points);
            }
        }

        public override void DrawTracker(Graphics canvas)
        {
            objectCrossOp.DrawTracker(canvas, directionOfCross);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return objectCrossOp.HitTest(point, isSelected, directionOfCross, Mirror);
        }

        protected override void Translate(int offsetX, int offsetY)
        {
            Point[] pts = new Point[8];
            PointList.CopyTo(pts);
            for (int i = 0; i < 8; i++)
            {
                pts[i].Offset(offsetX, offsetY);
            }
            PointList.Clear();
            PointList.AddRange(pts);
            PtlToSavel();
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            objectCrossOp.scale(handle, dx, dy, Mirror);
            PtlToSavel();
        }

        public override void RotateCounterClw()
        {
            base.RotateCounterClw();
            rotateAngle = -90;
            Matrix matrix = new Matrix();
            PointF ptCenter = new PointF();
            PointF[] points = new PointF[8];
            PointF[] pts = new PointF[4];
            pts[0] = PointList[0];
            pts[1] = PointList[3];
            pts[2] = PointList[5];
            pts[3] = PointList[7];
            startAngle = (startAngle + 360) % 360;
            switch (startAngle)
            {
                case 0:
                    directionOfCross = DirectionCross.first;
                    ptCenter.X = ((float)(pts[0].X + pts[2].X)) / 2;
                    ptCenter.Y = ((float)(pts[1].Y + pts[3].Y)) / 2;
                    directionOfCross = DirectionCross.four;
                    break;
                case 90:
                    directionOfCross = DirectionCross.second;
                    ptCenter.X = ((float)(pts[1].X + pts[3].X)) / 2;
                    ptCenter.Y = ((float)(pts[0].Y + pts[2].Y)) / 2;
                    directionOfCross = DirectionCross.first;
                    break;
                case 180:
                    directionOfCross = DirectionCross.third;
                    ptCenter.X = ((float)(pts[0].X + pts[2].X)) / 2;
                    ptCenter.Y = ((float)(pts[1].Y + pts[3].Y)) / 2;
                    directionOfCross = DirectionCross.second;
                    break;
                case 270:
                    directionOfCross = DirectionCross.four;
                    ptCenter.X = ((float)(pts[1].X + pts[3].X)) / 2;
                    ptCenter.Y = ((float)(pts[0].Y + pts[2].Y)) / 2;
                    directionOfCross = DirectionCross.third;
                    break;
                default:
                    break;
            }
            startAngle += rotateAngle;
            matrix.RotateAt(rotateAngle, ptCenter);
            for (int i = 0; i < 8; i++)
            {
                points[i] = PointList[i];
            }
            matrix.TransformPoints(points);
            PointList.Clear();
            for (int i = 0; i < 8; i++)
            {
                PointList.Add(Point.Ceiling(points[i]));
            }
            PtlToSavel();
        }

        public override void RotateClw()
        {
            base.RotateCounterClw();
            rotateAngle = 90;
            Matrix matrix = new Matrix();
            PointF ptCenter = new PointF();
            PointF[] points = new PointF[8];
            PointF[] pts = new PointF[4];
            pts[0] = PointList[0];
            pts[1] = PointList[3];
            pts[2] = PointList[5];
            pts[3] = PointList[7];
            startAngle = (startAngle + 360) % 360;
            switch (startAngle)
            {
                case 0:
                    directionOfCross = DirectionCross.first;
                    ptCenter.X = ((float)(pts[0].X + pts[2].X)) / 2;
                    ptCenter.Y = ((float)(pts[1].Y + pts[3].Y)) / 2;
                    directionOfCross = DirectionCross.second;
                    break;
                case 90:
                    directionOfCross = DirectionCross.second;
                    ptCenter.X = ((float)(pts[1].X + pts[3].X)) / 2;
                    ptCenter.Y = ((float)(pts[0].Y + pts[2].Y)) / 2;
                    directionOfCross = DirectionCross.third;
                    break;
                case 180:
                    directionOfCross = DirectionCross.third;
                    ptCenter.X = ((float)(pts[0].X + pts[2].X)) / 2;
                    ptCenter.Y = ((float)(pts[1].Y + pts[3].Y)) / 2;
                    directionOfCross = DirectionCross.four;
                    break;
                case 270:
                    directionOfCross = DirectionCross.four;
                    ptCenter.X = ((float)(pts[1].X + pts[3].X)) / 2;
                    ptCenter.Y = ((float)(pts[0].Y + pts[2].Y)) / 2;
                    directionOfCross = DirectionCross.first;
                    break;
                default:
                    break;
            }
            startAngle += rotateAngle;
            matrix.RotateAt(RotateAngle, ptCenter);
            for (int i = 0; i < 8; i++)
            {
                points[i] = PointList[i];
            }
            matrix.TransformPoints(points);
            PointList.Clear();
            for (int i = 0; i < 8; i++)
            {
                PointList.Add(Point.Ceiling(points[i]));
            }
            PtlToSavel();
        }

        public object Clone()
        {
            CrossEle cl = new CrossEle();
            cl.lenghtOfStrai = lenghtOfStrai;
            cl.startAngle = startAngle;
            cl.rotateAngle = rotateAngle;
            cl.PointList.AddRange(PointList);
            cl.SaveList.AddRange(SaveList);
            cl.directionOfCross = directionOfCross;
            cl.DrawMultiFactor = DrawMultiFactor;
            return this;
        }

        public override void DrawEnlargeOrShrink(float multiFactor)
        {
            Point[] pts = new Point[8];
            SaveList.CopyTo(pts);
            if (multiFactor > 1)
            {
                for (int i = 0; i < 8; i++)
                {
                    pts[i].X = pts[i].X * DrawMultiFactor;
                    pts[i].Y = pts[i].Y * DrawMultiFactor;
                }                
            }
            PointList.Clear();
            PointList.AddRange(pts);
            base.DrawEnlargeOrShrink(DrawMultiFactor);
        }

        private void PtlToSavel()
        {
            Point[] pts = new Point[8];
            PointList.CopyTo(pts);
            if (DrawMultiFactor > 1)
            {
                for (int i = 0; i < 8; i++)
                {
                    pts[i].X = pts[i].X / DrawMultiFactor;
                    pts[i].Y = pts[i].Y / DrawMultiFactor;
                }
            }
            SaveList.Clear();
            SaveList.AddRange(pts);
        }

        public override void ObjectMirror()
        {
            PointF ptCenter = PointF.Empty;
            PointF[] pts = new PointF[8];
            for (int i = 0; i < 8; i++)
                pts[i] = PointList[i];
            if (PointList[0].Y == PointList[5].Y)
            {
                ptCenter = new PointF((float)(PointList[0].X + PointList[5].X) / 2, PointList[0].Y);
                for (int i = 0; i < 8; i++)
                {
                    if (pts[i].X < ptCenter.X)
                        pts[i].X += 2 * Math.Abs(pts[i].X - ptCenter.X);
                    else
                        pts[i].X -= 2 * Math.Abs(pts[i].X - ptCenter.X);
                }
            }
            else if (PointList[0].X == PointList[5].X)
            {
                ptCenter = new PointF(PointList[0].X, (float)(PointList[0].Y + PointList[5].Y) / 2);
                for (int i = 0; i < 8; i++)
                {
                    if (pts[i].Y < ptCenter.Y)
                        pts[i].Y += 2 * Math.Abs(pts[i].Y - ptCenter.Y);
                    else
                        pts[i].Y -= 2 * Math.Abs(pts[i].Y - ptCenter.Y);
                }
            }
            if (mirror)
                mirror = false;
            else if (!mirror)
                mirror = true;
            PointList.Clear();
            for (int i = 0; i < 8; i++)
                PointList.Add(Point.Ceiling(pts[i]));
            PtlToSavel();
        }

        public override void ChangePropertyValue()
        {
            Point[] ptsList = new Point[8];
            PointList.CopyTo(ptsList);
            switch (directionOfCross)
            {
                case DirectionCross.first:
                    if (PointList[0].X < PointList[1].X)
                    {
                        ptsList[0].X = PointList[1].X - firstPart;
                        ptsList[3].X = ptsList[1].X + secPart;
                        ptsList[4].X = ptsList[3].X;
                        ptsList[5].X = ptsList[3].X + thPart;
                        ptsList[7].X = ptsList[6].X + fourPart.X;
                        ptsList[7].Y = ptsList[6].Y - fourPart.Y;
                    }
                    else
                    {
                        ptsList[0].X = PointList[1].X + firstPart;
                        ptsList[3].X = ptsList[1].X - secPart;
                        ptsList[4].X = ptsList[3].X;
                        ptsList[5].X = ptsList[3].X - thPart;
                        ptsList[7].X = ptsList[6].X - fourPart.X;
                        ptsList[7].Y = ptsList[6].Y - fourPart.Y;
                    }
                    PointList.Clear();
                    PointList.AddRange(ptsList);
                    break;
                case DirectionCross.second:
                    if (PointList[0].Y < PointList[1].Y)
                    {
                        ptsList[0].Y = ptsList[1].Y - firstPart;
                        ptsList[3].Y = ptsList[1].Y + secPart;
                        ptsList[4].Y = ptsList[3].Y;
                        ptsList[5].Y = ptsList[3].Y + thPart;
                        ptsList[7].X = ptsList[6].X + fourPart.X;
                        ptsList[7].Y = ptsList[6].Y + fourPart.Y;
                    }
                    else
                    {
                        ptsList[0].Y = ptsList[1].Y + firstPart;
                        ptsList[3].Y = ptsList[1].Y - secPart;
                        ptsList[4].Y = ptsList[3].Y;
                        ptsList[5].Y = ptsList[3].Y - thPart;
                        ptsList[7].X = ptsList[6].X + fourPart.X;
                        ptsList[7].Y = ptsList[6].Y - fourPart.Y;
                    }
                    PointList.Clear();
                    PointList.AddRange(ptsList);
                    break;
                case DirectionCross.third:
                    if (PointList[0].X < PointList[1].X)
                    {
                        ptsList[0].X = PointList[1].X - firstPart;
                        ptsList[3].X = ptsList[1].X + secPart;
                        ptsList[4].X = ptsList[3].X;
                        ptsList[5].X = ptsList[3].X + thPart;
                        ptsList[7].X = ptsList[6].X + fourPart.X;
                        ptsList[7].Y = ptsList[6].Y + fourPart.Y;
                    }
                    else
                    {
                        ptsList[0].X = PointList[1].X + firstPart;
                        ptsList[3].X = ptsList[1].X - secPart;
                        ptsList[4].X = ptsList[3].X;
                        ptsList[5].X = ptsList[3].X - thPart;
                        ptsList[7].X = ptsList[6].X - fourPart.X;
                        ptsList[7].Y = ptsList[6].Y + fourPart.Y;
                    }
                    PointList.Clear();
                    PointList.AddRange(ptsList);
                    break;
                case DirectionCross.four:
                    if (PointList[0].Y < PointList[1].Y)
                    {
                        ptsList[0].Y = ptsList[1].Y - firstPart;
                        ptsList[3].Y = ptsList[1].Y + secPart;
                        ptsList[4].Y = ptsList[3].Y;
                        ptsList[5].Y = ptsList[3].Y + thPart;
                        ptsList[7].X = ptsList[6].X - fourPart.X;
                        ptsList[7].Y = ptsList[6].Y + fourPart.Y;
                    }
                    else
                    {
                        ptsList[0].Y = ptsList[1].Y + firstPart;
                        ptsList[3].Y = ptsList[1].Y - secPart;
                        ptsList[4].Y = ptsList[3].Y;
                        ptsList[5].Y = ptsList[3].Y - thPart;
                        ptsList[7].X = ptsList[6].X - fourPart.X;
                        ptsList[7].Y = ptsList[6].Y - fourPart.Y;
                    }
                    PointList.Clear();
                    PointList.AddRange(ptsList);
                    break;
                case DirectionCross.NULL:
                    break;
            }
        }
    }
}
