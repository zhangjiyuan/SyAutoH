using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RailView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ComponentLocChanged();
            this.Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ComponentLocChanged();
        }

        public void ComponentLocChanged()
        {
            Size railViewSz = this.ClientSize;
            Size menuSz = this.menuStrip1.Size;
            Size baseInfoSz = this.baseInfoTreeView1.Size;
            Size showRegSz = this.showRegion1.Size;
            Size sysStaSz = this.systemStatues1.Size;
            baseInfoSz.Height = railViewSz.Height - menuSz.Height-10;
            sysStaSz.Width = railViewSz.Width - baseInfoSz.Width - 10;
            sysStaSz.Height = 150;
            showRegSz.Width = sysStaSz.Width;
            showRegSz.Height = railViewSz.Height - menuSz.Height - 10 - sysStaSz.Height;
            this.baseInfoTreeView1.Size = baseInfoSz;
            this.showRegion1.Size = showRegSz;
            this.systemStatues1.Size = sysStaSz;
            this.showRegion1.Location = new Point(
                baseInfoTreeView1.Left + baseInfoTreeView1.Width + 10, menuSz.Height);
            this.systemStatues1.Location = new Point(
                showRegion1.Location.X, showRegion1.Location.Y + showRegion1.Height);
        }       
    }   
}
