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
    public class StraightRailEle : BaseRailEle
    {
        private ObjectStraightOp objectStaightOp = new ObjectStraightOp();
        private Pen pen = new Pen(Color.Black, 1);

        private int showLenght = 100;
        [XmlIgnore]
        [Browsable(false)]
        public int ShowLenght
        {
            get { return showLenght; }
            set { showLenght = value; }
        }

        private int realLenght = 100;
        public int Lenght
        {
            get { return realLenght; }
            set { realLenght = value; }
        }

        private int rotateAngle = 90;
        [Browsable(false)]
        public int RotateAngel
        {
            get { return rotateAngle; }
            set { rotateAngle = value; }
        }

        [XmlIgnore]
        [Browsable(false)]
        public List<Point> PointList
        {
            get { return objectStaightOp.PointList; }
        }

        [Browsable(false)]
        public List<Point> SaveList
        {
            get { return objectStaightOp.SaveList; }
        }        

        public StraightRailEle() { GraphType = 1; }

        public StraightRailEle CreatEle(Point pt, Size size, float multiFactor)
        {
            Point[] pts = new Point[2];
            DrawMultiFactor = multiFactor;
            pts[0] = pt;
            ShowLenght = (int)(ShowLenght * DrawMultiFactor);
            if ((pt.X + ShowLenght) > size.Width)
            {
                pts[0] = new Point(pt.X - ShowLenght, pt.Y);
                pts[1] = new Point(pt.X, pt.Y);
            }
            else
            {
                pts[0] = new Point(pt.X, pt.Y);
                pts[1] = new Point(pt.X + ShowLenght, pt.Y);
            }
            PointList.AddRange(pts);
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
                    throw new Exception("绘制线条的点至少需要2个");
                }
                else
                {
                    Point[] pts = new Point[2];
                    SaveList.CopyTo(pts);
                    PointList.AddRange(pts);
                    ShowLenght = Lenght;
                }
            }
            int n = PointList.Count;
            Point[] points = new Point[n];
            PointList.CopyTo(points);
            if (points[0].Y == points[1].Y)
            {
                if (ShowLenght != Math.Abs(points[0].X - points[1].X))
                {
                    if (points[0].X < points[1].X)
                    {
                        points[1].X = points[0].X + ShowLenght;
                    }
                    else
                    {
                        points[1].X = points[0].X - ShowLenght;
                    }
                }
            }
            else if (points[0].X == points[1].X)
            {
                if (ShowLenght != Math.Abs(points[0].Y - points[1].Y))
                {
                    points[1].Y = points[0].Y + ShowLenght;
                }
            }
            PointList.Clear();
            PointList.AddRange(points);
            canvas.DrawLines(pen, points);
        }

        public override void DrawTracker(Graphics canvas)
        {
            objectStaightOp.DrawTracker(canvas);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return objectStaightOp.HitTest(point, isSelected);
        }

        protected override void Translate(int offsetX, int offsetY)
        {
            objectStaightOp.Translate(offsetX, offsetY);
            PtlToSavel();
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            ShowLenght = objectStaightOp.Scale(handle, dx, dy, ShowLenght);
            PtlToSavel();
        }

        protected override void Rotate(Point pt, Size sz)
        {
            objectStaightOp.ChangeDirection(pt, sz);
        }

        public override void RotateCounterClw()
        {
            base.RotateCounterClw();
            Point pt = new Point();
            if (PointList[0].X == PointList[1].X)
            {
                pt.X = PointList[0].X;
                pt.Y = (PointList[0].Y + PointList[1].Y) / 2;
            }
            else if (PointList[0].Y == PointList[1].Y)
            {
                pt.X = (PointList[0].X + PointList[1].X) / 2;
                pt.Y = PointList[0].Y;
            }
            RotateAngel = -90;
            objectStaightOp.Rotate(pt, RotateAngel);
            PtlToSavel();
        }

        public override void RotateClw()
        {
            base.RotateClw();
            Point pt = new Point();
            if (PointList[0].X == PointList[1].X)
            {
                pt.X = PointList[0].X;
                pt.Y = (PointList[0].Y + PointList[1].Y) / 2;
            }
            else if (PointList[0].Y == PointList[1].Y)
            {
                pt.X = (PointList[0].X + PointList[1].X) / 2;
                pt.Y = PointList[0].Y;
            }
            RotateAngel = 90;
            objectStaightOp.Rotate(pt, RotateAngel);
            PtlToSavel();
        }
       
        public override void DrawEnlargeOrShrink(float drawMultiFactor)
        {
            Point[] pts = new Point[2];
            pts[0] = SaveList[0];
            pts[1] = SaveList[1];
            if (drawMultiFactor > 1)
            {
                pts[0].X = (int)(pts[0].X * DrawMultiFactor);
                pts[0].Y = (int)(pts[0].Y * DrawMultiFactor);
                pts[1].X = (int)(pts[1].X * DrawMultiFactor);
                pts[1].Y = (int)(pts[1].Y * DrawMultiFactor);
            }
            PointList.Clear();
            PointList.AddRange(pts);
            ShowLenght  =(int) Math.Sqrt((double)(pts[0].X - pts[1].X) * (pts[0].X - pts[1].X) + (double)(pts[0].Y - pts[1].Y) * (pts[0].Y - pts[1].Y));
            base.DrawEnlargeOrShrink(drawMultiFactor);
        }

        public override void ChangePropertyValue()
        {

            base.ChangePropertyValue();
        }

        public object Clone()
        {
            StraightRailEle cl = new StraightRailEle();
            cl.pen = pen;
            cl.PointList.AddRange(PointList);
            cl.ShowLenght = ShowLenght;
            return cl;
        }

        private void PtlToSavel()
        {
            Point[] pts = new Point[2];
            pts[0] = PointList[0];
            pts[1] = PointList[1];
            if (DrawMultiFactor > 1)
            {
                pts[0].X = (int)(pts[0].X / DrawMultiFactor);
                pts[0].Y = (int)(pts[0].Y / DrawMultiFactor);
                pts[1].X = (int)(pts[1].X / DrawMultiFactor);
                pts[1].Y = (int)(pts[1].Y / DrawMultiFactor);
                Lenght =(int) Math.Sqrt((double)(pts[0].X - pts[1].X) * (pts[0].X - pts[1].X) + (double)(pts[0].Y - pts[1].Y) * (pts[0].Y - pts[1].Y));
            }
            SaveList.Clear();
            SaveList.AddRange(pts);
        }
    }
}
