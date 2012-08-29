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

        private int lenghtOfStrai = 100;
        public int LineOfCross
        {
            get { return lenghtOfStrai; }
            set { lenghtOfStrai = value; }
        }

//        private int lenghtOfCross = 0;
//        public int LenghtOfCross
 //       {
//            get { return lenghtOfCross; }
//            set { lenghtOfCross = value; }
//        }

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

//        private int angleOfStrai = 0;
//        public int AngleOfStrai
//        {
//            get { return angleOfStrai; }
//            set { angleOfStrai = value; }
//        }

//        private int angleOfross = 45;
//        public int AngleOfCross
//        {
//            get { return angleOfross; }
//            set { angleOfross = value; }
//        }

        private int startAngle = 0;
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
        public DirectionCross DirectionOfCross
        {
            get { return directionOfCross; }
            set { directionOfCross = value; }
        }

        public CrossEle() { GraphType = 5; }

        public CrossEle CreatEle(Point pt, Size size, float multiFactor)
        {
            Point[] pts = new Point[8];
            DrawMultiFactor = multiFactor;
            pts[0] = pt;
            pts[1].X = (int)(pts[0].X + 30 * multiFactor);
            pts[1].Y = pts[0].Y;
            pts[2].X = (int)(pts[0].X + 30 * multiFactor);
            pts[2].Y = (int)(pts[0].Y + 5 * multiFactor);
            pts[3].X = (int)(pts[0].X + 70 * multiFactor);
            pts[3].Y = (int)(pts[0].Y + 5 * multiFactor);
            pts[4].X = (int)(pts[0].X + 70 * multiFactor);
            pts[4].Y = pts[0].Y;
            pts[5].X = (int)(pts[0].X + lenghtOfStrai * multiFactor);
            pts[5].Y = pts[0].Y;
            pts[6].X = (int)(pts[0].X + 30 * multiFactor);
            pts[6].Y = (int)(pts[0].Y - 5 * multiFactor);
            pts[7].X = (int)(pts[0].X + 70 * multiFactor);
            pts[7].Y = (int)(pts[0].Y - 45* multiFactor);
            PointList.AddRange(pts);
            DirectionOfCross = DirectionCross.first;
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
            objectCrossOp.DrawTracker(canvas, DirectionOfCross);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return objectCrossOp.HitTest(point, isSelected, DirectionOfCross);
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
            objectCrossOp.scale(handle, dx, dy);
            PtlToSavel();
        }

        public override void RotateCounterClw()
        {
            base.RotateCounterClw();
            RotateAngle = -90;
            Matrix matrix = new Matrix();
            PointF ptCenter = new PointF();
            Point[] points = new Point[8];
            Point[] pts = new Point[4];
            pts[0] = PointList[0];
            pts[1] = PointList[3];
            pts[2] = PointList[5];
            pts[3] = PointList[7];
            StartAngle = (StartAngle + 360) % 360;
            switch (startAngle)
            {
                case 0:
                    DirectionOfCross = DirectionCross.first;
                    ptCenter.X = ((float)(pts[0].X + pts[2].X)) / 2;
                    ptCenter.Y = ((float)(pts[1].Y + pts[3].Y)) / 2;
                    DirectionOfCross = DirectionCross.four;
                    break;
                case 90:
                    DirectionOfCross = DirectionCross.second;
                    ptCenter.X = ((float)(pts[1].X + pts[3].X)) / 2;
                    ptCenter.Y = ((float)(pts[0].Y + pts[2].Y)) / 2;
                    DirectionOfCross = DirectionCross.first;
                    break;
                case 180:
                    DirectionOfCross = DirectionCross.third;
                    ptCenter.X = ((float)(pts[0].X + pts[2].X)) / 2;
                    ptCenter.Y = ((float)(pts[1].Y + pts[3].Y)) / 2;
                    DirectionOfCross = DirectionCross.second;
                    break;
                case 270:
                    DirectionOfCross = DirectionCross.four;
                    ptCenter.X = ((float)(pts[1].X + pts[3].X)) / 2;
                    ptCenter.Y = ((float)(pts[0].Y + pts[2].Y)) / 2;
                    DirectionOfCross = DirectionCross.third;
                    break;
                default:
                    break;
            }
            StartAngle += RotateAngle;
            matrix.RotateAt(RotateAngle, ptCenter);
            PointList.CopyTo(points);
            matrix.TransformPoints(points);
            PointList.Clear();
            PointList.AddRange(points);
            PtlToSavel();
        }

        public override void RotateClw()
        {
            base.RotateCounterClw();
            RotateAngle = 90;
            Matrix matrix = new Matrix();
            PointF ptCenter = new PointF();
            Point[] points = new Point[8];
            Point[] pts = new Point[4];
            pts[0] = PointList[0];
            pts[1] = PointList[3];
            pts[2] = PointList[5];
            pts[3] = PointList[7];
            StartAngle = (StartAngle + 360) % 360;
            switch (startAngle)
            {
                case 0:
                    DirectionOfCross = DirectionCross.first;
                    ptCenter.X = ((float)(pts[0].X + pts[2].X)) / 2;
                    ptCenter.Y = ((float)(pts[1].Y + pts[3].Y)) / 2;
                    DirectionOfCross = DirectionCross.second;
                    break;
                case 90:
                    DirectionOfCross = DirectionCross.second;
                    ptCenter.X = ((float)(pts[1].X + pts[3].X)) / 2;
                    ptCenter.Y = ((float)(pts[0].Y + pts[2].Y)) / 2;
                    DirectionOfCross = DirectionCross.third;
                    break;
                case 180:
                    DirectionOfCross = DirectionCross.third;
                    ptCenter.X = ((float)(pts[0].X + pts[2].X)) / 2;
                    ptCenter.Y = ((float)(pts[1].Y + pts[3].Y)) / 2;
                    DirectionOfCross = DirectionCross.four;
                    break;
                case 270:
                    DirectionOfCross = DirectionCross.four;
                    ptCenter.X = ((float)(pts[1].X + pts[3].X)) / 2;
                    ptCenter.Y = ((float)(pts[0].Y + pts[2].Y)) / 2;
                    DirectionOfCross = DirectionCross.first;
                    break;
                default:
                    break;
            }
            StartAngle += RotateAngle;
            matrix.RotateAt(RotateAngle, ptCenter);
            PointList.CopyTo(points);
            matrix.TransformPoints(points);
            PointList.Clear();
            PointList.AddRange(points);
            PtlToSavel();
        }

        public object Clone()
        {
            CrossEle cl = new CrossEle();
            cl.lenghtOfStrai = lenghtOfStrai;
            cl.StartAngle = StartAngle;
            cl.RotateAngle = RotateAngle;
            cl.PointList.AddRange(PointList);
            cl.SaveList.AddRange(SaveList);
            cl.DirectionOfCross = DirectionOfCross;
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
                    pts[i].X = (int)(pts[i].X * DrawMultiFactor);
                    pts[i].Y = (int)(pts[i].Y * DrawMultiFactor);
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
                    pts[i].X = (int)(pts[i].X / DrawMultiFactor);
                    pts[i].Y = (int)(pts[i].Y / DrawMultiFactor);
                }
            }
            SaveList.Clear();
            SaveList.AddRange(pts);
        }
    }
}
