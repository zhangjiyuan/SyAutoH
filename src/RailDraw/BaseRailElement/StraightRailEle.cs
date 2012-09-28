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

        private int lenght = 100;
        public int Lenght
        {
            get { return lenght; }
            set { lenght = value; }
        }

        private int startAngle = 0;
        [Browsable(false)]
        public int StartAngle
        {
            get { return startAngle; }
            set { startAngle = value; }
        }

        private int rotateAngle = 90;

        [XmlIgnore]
        [Browsable(false)]
        public List<Point> PointList
        {
            get { return objectStaightOp.PointList; }
        }

        public StraightRailEle() { GraphType = 1; }

        public StraightRailEle CreatEle(Point pt, Size size, int multiFactor)
        {
            Point[] pts = new Point[2];
            DrawMultiFactor = multiFactor;
            objectStaightOp.DrawMultiFactor = multiFactor;
            pt.Offset(pt.X / DrawMultiFactor - pt.X, pt.Y / DrawMultiFactor - pt.Y);
            pts[0] = pt;
            if ((pt.X + Lenght) > size.Width)
            {
                pts[0] = new Point(pt.X - lenght, pt.Y);
                pts[1] = new Point(pt.X, pt.Y);
            }
            else
            {
                pts[0] = new Point(pt.X, pt.Y);
                pts[1] = new Point(pt.X + lenght, pt.Y);
            }
            PointList.AddRange(pts);
            return this;
        }

        public override void Draw(Graphics canvas)
        {
            if (canvas == null)
                throw new Exception("Graphics对象Canvas不能为空");
            if (PointList.Count < 2)
            {
                throw new Exception("绘制线条的点至少需要2个");
            }
            int n = PointList.Count;
            Point[] pts = new Point[n];
            PointList.CopyTo(pts);
            if (pts[0].Y == pts[1].Y)
            {
                if (lenght != Math.Abs(pts[0].X - pts[1].X))
                {
                    if (pts[0].X < pts[1].X)
                    {
                        pts[1].X = pts[0].X + lenght;
                    }
                    else
                    {
                        pts[1].X = pts[0].X - lenght;
                    }
                }
            }
            else if (pts[0].X == pts[1].X)
            {
                if (lenght != Math.Abs(pts[0].Y - pts[1].Y))
                {
                    pts[1].Y = pts[0].Y + lenght;
                }
            }
            for (int i = 0; i < n; i++)
                pts[i].Offset(pts[i].X * (DrawMultiFactor - 1), pts[i].Y * (DrawMultiFactor - 1));
            canvas.DrawLines(pen, pts);
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
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            lenght = objectStaightOp.Scale(handle, dx, dy, lenght);
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
            startAngle -= rotateAngle;
            objectStaightOp.Rotate(pt, rotateAngle);
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
            startAngle += rotateAngle;
            objectStaightOp.Rotate(pt, rotateAngle);
        }
       
        public override void DrawEnlargeOrShrink(float drawMultiFactor)
        {
            objectStaightOp.DrawMultiFactor = Convert.ToInt16(drawMultiFactor);
            base.DrawEnlargeOrShrink(drawMultiFactor);
        }

        public override void ChangePropertyValue()
        {
            Point[] pts = new Point[2];
            PointList.CopyTo(pts);
            if (PointList[0].X == PointList[1].X)
            {
                if (PointList[0].Y < PointList[1].Y)
                    pts[1].Y = pts[0].Y + lenght;
                else
                    pts[0].Y = pts[1].Y + lenght;
            }
            else if (PointList[0].Y == PointList[1].Y)
            {
                if (PointList[0].X < PointList[1].X)
                    pts[1].X = pts[0].X + lenght;
                else
                    pts[0].X = pts[1].X + lenght;
            }
            PointList.Clear();
            PointList.AddRange(pts);
            base.ChangePropertyValue();
        }

        public object Clone()
        {
            StraightRailEle cl = new StraightRailEle();
            cl.pen = pen;
            cl.PointList.AddRange(PointList);
            cl.lenght = lenght;
            cl.DrawMultiFactor = DrawMultiFactor;
            cl.objectStaightOp.DrawMultiFactor = DrawMultiFactor;
            return cl;
        }

        public override bool ChosedInRegion(Rectangle rect)
        {
            return objectStaightOp.ChosedInRegion(rect);          
        }
    }
}
