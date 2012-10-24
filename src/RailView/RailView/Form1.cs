using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace RailView
{
    public partial class Form1 : Form
    {
        WinFormElement.FormOperation formOperation = new WinFormElement.FormOperation();

        public Form1()
        {
            InitializeComponent();
            ComponentLocChanged();
            formOperation.FormShowRegionInit();
            formOperation.Test();
            //test using, finally delete
            TestRailDrawCoor();   
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
            Size baseInfoSz = this.baseInfoTreeView.Size;
            Size showRegSz = this.showRegion.Size;
            Size sysStaSz = this.systemStatues.Size;
            baseInfoSz.Height = railViewSz.Height - menuSz.Height-10;
            sysStaSz.Width = railViewSz.Width - baseInfoSz.Width - 30;
            sysStaSz.Height = 100;
            showRegSz.Width = sysStaSz.Width;
            showRegSz.Height = railViewSz.Height - menuSz.Height - 10 - sysStaSz.Height;
            this.baseInfoTreeView.Size = baseInfoSz;
            this.showRegion.Size = showRegSz;
            this.showPic.Size = showRegSz;
            this.systemStatues.Size = sysStaSz;            
            this.showRegion.Location = new Point(
                baseInfoTreeView.Left + baseInfoTreeView.Width + 10, menuSz.Height);
            this.systemStatues.Location = new Point(
                showRegion.Location.X, showRegion.Location.Y + showRegion.Height);
  
        }

        private void showPic_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            formOperation.ShowRegion(g);
            base.OnPaint(e);
        }

        //test using, finally delete
        public void TestRailDrawCoor()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(StartTimer);
            timer.Interval = 3000;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        //test using, finally delete
        public void StartTimer(object source, System.Timers.ElapsedEventArgs e)
        {
            this.showPic.Invalidate();
        }
    }   
}
