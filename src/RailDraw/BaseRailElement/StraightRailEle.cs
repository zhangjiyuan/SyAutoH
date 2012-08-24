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
        private ObjectStraightOp _ObjectStaightOp = new ObjectStraightOp();
        private Pen pen = new Pen(Color.Black, 1);

        private int show_lenght = 100;
        [XmlIgnore]
        [Browsable(false)]
        public int Show_Lenght
        {
            get { return show_lenght; }
            set { show_lenght = value; }
        }

        private int real_lenght = 100;
        public int Real_Lenght
        {
            get { return real_lenght; }
            set { real_lenght = value; }
        }

        private int _rotate_angle = 90;
        [Browsable(false)]
        public int Rotate_Angel
        {
            get { return _rotate_angle; }
            set { _rotate_angle = value; }
        }

        [XmlIgnore]
        [Browsable(false)]
        public List<Point> PointList
        {
            get { return _ObjectStaightOp.PointList; }
        }

        [Browsable(false)]
        public List<Point> SaveList
        {
            get { return _ObjectStaightOp.SaveList; }
        }        

        public StraightRailEle() { GraphType = 1; }

        public StraightRailEle CreatEle(Point pt, Size size, float multi_factor)
        {
            Point[] pts = new Point[2];
            Draw_Multi_Factor = multi_factor;
            pts[0] = pt;
            Show_Lenght = (int)(Show_Lenght * Draw_Multi_Factor);
            if ((pt.X + Show_Lenght) > size.Width)
            {
                pts[0] = new Point(pt.X - Show_Lenght, pt.Y);
                pts[1] = new Point(pt.X, pt.Y);
            }
            else
            {
                pts[0] = new Point(pt.X, pt.Y);
                pts[1] = new Point(pt.X + Show_Lenght, pt.Y);
            }
            PointList.AddRange(pts);
            PtlToSavel();
            return this;
        }

        public override void Draw(Graphics _canvas)
        {
            if (_canvas == null)
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
                    Show_Lenght = Real_Lenght;
                }
            }
            int n = PointList.Count;
            Point[] points = new Point[n];
            PointList.CopyTo(points);
            if (points[0].Y == points[1].Y)
            {
                if (Show_Lenght != Math.Abs(points[0].X - points[1].X))
                {
                    if (points[0].X < points[1].X)
                    {
                        points[1].X = points[0].X + Show_Lenght;
                    }
                    else
                    {
                        points[1].X = points[0].X - Show_Lenght;
                    }
                }
            }
            else if (points[0].X == points[1].X)
            {
                if (Show_Lenght != Math.Abs(points[0].Y - points[1].Y))
                {
                    points[1].Y = points[0].Y + Show_Lenght;
                }
            }
            PointList.Clear();
            PointList.AddRange(points);
            _canvas.DrawLines(pen, points);
        }

        public override void DrawTracker(Graphics _canvas)
        {
            _ObjectStaightOp.DrawTracker(_canvas);
        }

        public override int HitTest(Point point, bool isSelected)
        {
            return _ObjectStaightOp.HitTest(point, isSelected);
        }

        protected override void Translate(int offsetX, int offsetY)
        {
            _ObjectStaightOp.Translate(offsetX, offsetY);
            PtlToSavel();
        }

        protected override void Scale(int handle, int dx, int dy)
        {
            Show_Lenght = _ObjectStaightOp.Scale(handle, dx, dy, Show_Lenght);
            PtlToSavel();
        }

        protected override void Rotate(Point pt, Size sz)
        {
            _ObjectStaightOp.ChangeDirection(pt, sz);
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
            Rotate_Angel = -90;
            _ObjectStaightOp.Rotate(pt, Rotate_Angel);
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
            Rotate_Angel = 90;
            _ObjectStaightOp.Rotate(pt, Rotate_Angel);
            PtlToSavel();
        }
       
        public override void DrawEnlargeOrShrink(float _draw_multi_factor)
        {
            Point[] pts = new Point[2];
            pts[0] = SaveList[0];
            pts[1] = SaveList[1];
            if (_draw_multi_factor > 1)
            {
                pts[0].X = (int)(pts[0].X * Draw_Multi_Factor);
                pts[0].Y = (int)(pts[0].Y * Draw_Multi_Factor);
                pts[1].X = (int)(pts[1].X * Draw_Multi_Factor);
                pts[1].Y = (int)(pts[1].Y * Draw_Multi_Factor);
            }
            PointList.Clear();
            PointList.AddRange(pts);
            Show_Lenght  =(int) Math.Sqrt((double)(pts[0].X - pts[1].X) * (pts[0].X - pts[1].X) + (double)(pts[0].Y - pts[1].Y) * (pts[0].Y - pts[1].Y));
            base.DrawEnlargeOrShrink(draw_multi_factor);
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
            cl.Show_Lenght = Show_Lenght;
            return cl;
        }

        private void PtlToSavel()
        {
            Point[] pts = new Point[2];
            pts[0] = PointList[0];
            pts[1] = PointList[1];
            if (Draw_Multi_Factor > 1)
            {
                pts[0].X = (int)(pts[0].X / Draw_Multi_Factor);
                pts[0].Y = (int)(pts[0].Y / Draw_Multi_Factor);
                pts[1].X = (int)(pts[1].X / Draw_Multi_Factor);
                pts[1].Y = (int)(pts[1].Y / Draw_Multi_Factor);
                Real_Lenght =(int) Math.Sqrt((double)(pts[0].X - pts[1].X) * (pts[0].X - pts[1].X) + (double)(pts[0].Y - pts[1].Y) * (pts[0].Y - pts[1].Y));
            }
            SaveList.Clear();
            SaveList.AddRange(pts);
        }
    }
}
