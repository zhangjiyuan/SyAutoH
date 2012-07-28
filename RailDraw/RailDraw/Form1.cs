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
        private string str;

        public Form1()
        {
            InitializeComponent();
            MyInit();
        }

        private void MyInit()
        {
            // 设置Control的相关Style，主要与绘制有关
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ContainerControl |
                ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.UserMouse, true);

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here
            int dx = hScrollBar1.Value;
            int dy = vScrollBar1.Value;
            Graphics g = pe.Graphics;

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // Remember the point where the mouse down occurred. The DragSize indicates
                // the size that the mouse can move before a drag event should be started.      
                Size dragSize = SystemInformation.DragSize;
                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                                   e.Y - (dragSize.Height / 2)), dragSize);

            }
            //        str = "pic1 mouse down";
            //         MessageBox.Show(str);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (panel2.Location.X <= e.X && panel2.Location.X + panel2.Size.Width >= e.X && panel2.Location.Y <= e.Y && panel2.Location.Y + panel2.Size.Height >= e.Y)
            {
                str = "pic111 mouse up";
                MessageBox.Show(str);
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

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
        }

        private void panel2_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void panel2_DragEnter(object sender, DragEventArgs e)
        {

        }
    }
}
