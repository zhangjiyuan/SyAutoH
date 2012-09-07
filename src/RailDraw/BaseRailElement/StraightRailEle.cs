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
        public int RotateAngle
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

        public StraightRailEle CreatEle(Point pt, Size size, int multiFactor)
        {
            Point[] pts = new Point[2];
            DrawMultiFactor = multiFactor;
            pts[0] = pt;
            showLenght = showLenght * DrawMultiFactor;
            if ((pt.X + showLenght) > size.Width)
            {
                pts[0] = new Point(pt.X - showLenght, pt.Y);
                pts[1] = new Point(pt.X, pt.Y);
            }
            else
            {
                pts[0] = new Point(pt.X, pt.Y);
                pts[1] = new Point(pt.X + showLenght, pt.Y);
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
                    showLenght = realLenght;
                }
            }
            int n = PointList.Count;
            Point[] points = new Point[n];
            PointList.CopyTo(points);
            if (points[0].Y == points[1].Y)
            {
                if (showLenght != Math.Abs(points[0].X - points[1].X))
                {
                    if (points[0].X < points[1].X)
                    {
                        points[1].X = points[0].X + showLenght;
                    }
                    else
                    {
                        points[1].X = points[0].X - showLenght;
                    }
                }
            }
            else if (points[0].X == points[1].X)
            {
                if (showLenght != Math.Abs(points[0].Y - points[1].Y))
                {
                    points[1].Y = points[0].Y + showLenght;
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
            showLenght = objectStaightOp.Scale(handle, dx, dy, ShowLenght);
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
            rotateAngle = -90;
            objectStaightOp.Rotate(pt, rotateAngle);
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
            rotateAngle = 90;
            objectStaightOp.Rotate(pt, rotateAngle);
            PtlToSavel();
        }
       
        public override void DrawEnlargeOrShrink(float drawMultiFactor)
        {
            Point[] pts = new Point[2];
            pts[0] = SaveList[0];
            pts[1] = SaveList[1];
            if (drawMultiFactor > 1)
            {
                pts[0].X = pts[0].X * DrawMultiFactor;
                pts[0].Y = pts[0].Y * DrawMultiFactor;
                pts[1].X = pts[1].X * DrawMultiFactor;
                pts[1].Y = pts[1].Y * DrawMultiFactor;
            }
            PointList.Clear();
            PointList.AddRange(pts);
            ShowLenght = Math.Abs(pts[0].X - pts[1].X) + Math.Abs(pts[0].Y - pts[1].Y);
            base.DrawEnlargeOrShrink(drawMultiFactor);
        }

        public override void ChangePropertyValue()
        {
            Point[] ptfs = new Point[2];
            PointList.CopyTo(ptfs);
            showLenght = realLenght * DrawMultiFactor;
            if (PointList[0].X == PointList[1].X)
            {
                if (PointList[0].Y < PointList[1].Y)
                    ptfs[1].Y = ptfs[0].Y + ShowLenght;
                else
                    ptfs[0].Y = ptfs[1].Y + ShowLenght;
            }
            else if (PointList[0].Y == PointList[1].Y)
            {
                if (PointList[0].X < PointList[1].X)
                    ptfs[1].X = ptfs[0].X + showLenght;
                else
                    ptfs[0].X = ptfs[1].X + showLenght;
            }
            PointList.Clear();
            PointList.AddRange(ptfs);
            PtlToSavel();
            base.ChangePropertyValue();
        }

        public object Clone()
        {
            StraightRailEle cl = new StraightRailEle();
            cl.pen = pen;
            cl.PointList.AddRange(PointList);
            cl.showLenght = showLenght;
            cl.DrawMultiFactor = DrawMultiFactor;
            return cl;
        }

        private void PtlToSavel()
        {
            Point[] pts = new Point[2];
            pts[0] = PointList[0];
            pts[1] = PointList[1];
            if (DrawMultiFactor > 1)
            {
                pts[0].X = pts[0].X / DrawMultiFactor;
                pts[0].Y = pts[0].Y / DrawMultiFactor;
                pts[1].X = pts[1].X / DrawMultiFactor;
                pts[1].Y = pts[1].Y / DrawMultiFactor;
            }
            realLenght = Math.Abs(pts[0].X - pts[1].X) + Math.Abs(pts[0].Y - pts[1].Y);
            SaveList.Clear();
            SaveList.AddRange(pts);
        }

        public override bool ChosedInRegion(Rectangle rect)
        {
            return objectStaightOp.ChosedInRegion(rect);          
        }
    }
}
