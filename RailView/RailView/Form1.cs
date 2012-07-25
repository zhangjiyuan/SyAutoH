using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

    }
}
