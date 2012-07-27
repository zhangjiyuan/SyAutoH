using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseRailElement;

namespace RailView
{
    public partial class Form1 : Form
    {
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

        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            ;
        }

        private void panel2_DragEnter(object sender, DragEventArgs e)
        {
            ;
        }

        public void ResizeCanvase()
        {
            ;
        }

        public Point ClientToDocument(Point point)
        {
            return point;
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

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

        }

        private void pictureBox1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

        }

        private void pictureBox2_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox3_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void pictureBox3_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

        }
    }
}
