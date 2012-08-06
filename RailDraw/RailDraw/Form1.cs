using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseRailElement;

namespace RailDraw
{
    public partial class Form1 : Form
    {
        BaseRailElement.DrawDoc doc1 = new BaseRailElement.DrawDoc();
        BaseRailElement.ObjectBaseEvents _ObjectEvent = new BaseRailElement.ObjectBaseEvents();
        
 
        private bool pic1 = false;
        private bool pic2 = false;
        private bool pic3 = false;
        Point _downpoint= Point.Empty;
        bool _IsMouseDown = false;

        public Form1()
        {
            InitializeComponent();
            MyInit();
            Document=doc1;
        }

        private void MyInit()
        {
            // 设置Control的相关Style，主要与绘制有关
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ContainerControl |
                ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.UserMouse, true);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Size dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                                   e.Y - (dragSize.Height / 2)), dragSize);
                pic1 = true;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (pic1)
            {
                PictureBox pic = sender as PictureBox;

                Point pt_new_e = PointTransform(sender, e);

                if (0 < pt_new_e.X && DrawRegion.Size.Width > pt_new_e.X && 0 < pt_new_e.Y && DrawRegion.Size.Height > pt_new_e.Y)
                {
                    BaseRailElement.StraightRailEle _straightrailele = new BaseRailElement.StraightRailEle();

                    Point pt = new Point(pt_new_e.X, pt_new_e.Y);
                    doc1.DrawObjectList.Add(_straightrailele.CreatEle(pt, DrawRegion.Size));
                    doc1.Select(_straightrailele);
                    DrawRegion.Invalidate();
                }
                pic1 = false;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {

        }

        public void ResizeCanvase()
        {
            ;
        }

        public Point ClientToDocument(Point point)
        {
            return point;
        }

        public Point PointTransform(object sender, MouseEventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            Point pt_original = pic.Location;
            Point pt_new = e.Location;
            Point pt_parent = pic.Parent.Location;
            Point pt_dr = DrawRegion.Location;
            Point pt_transform = new Point(pt_new.X + pt_original.X + pt_parent.X - pt_dr.X, pt_new.Y + pt_original.Y + pt_parent.Y - pt_dr.Y);
            return pt_transform;
        }

        protected static DrawDoc _document = DrawDoc.EmptyDocument;
        public static DrawDoc Document
        {
            get { return _document; }
            set { _document = value; BaseEvents.Document = value; }
        }

        private void DrawRegion_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = e.Location;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _ObjectEvent.OnLButtonDown(pt);
                    _IsMouseDown = true;
                    break;
            }
            this.DrawRegion.Invalidate();
        }

        private void DrawRegion_MouseMove(object sender, MouseEventArgs e)
        {
            if (_IsMouseDown)
            {
                _ObjectEvent.OnMouseMove(e.Location);
                this.DrawRegion.Invalidate();
            }
        }

        private void DrawRegion_MouseUp(object sender, MouseEventArgs e)
        {
            if (_IsMouseDown)
                _IsMouseDown = false;
        }

        private void DrawRegion_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Calling the base class OnPaint

            doc1.Draw(g);
            base.OnPaint(e);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            doc1.Delete();
            DrawRegion.Invalidate();
        }

        private void DrawRegion_DoubleClick(object sender, EventArgs e)
        {
  //          _ObjectEvent.OnMouseDoubleClick(point);
        }

    }
}
