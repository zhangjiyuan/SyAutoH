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
           
        }

        private void InitForm()
        {
            //ComponentLocChanged();        
            formOperation.FormShowRegionInit();
            formOperation.AddVehicleNode(baseInfoTreeView);
            //test using, finally delete
            TestRailDrawCoor();
            this.Invalidate();
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

        private void baseInfoTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            TreeView tempTree = sender as TreeView;
            Point pt = tempTree.PointToClient(Cursor.Position);
            TreeViewHitTestInfo info = tempTree.HitTest(pt.X, pt.Y);
            TreeNode node = info.Node;
            if (node != null && MouseButtons.Right == e.Button)
            {
                tempTree.SelectedNode = node;
                //switch (node.Name)
                //{
                //    case "CarsOnline":
                //        baseInfoMenu.Items.Clear();
                //        baseInfoMenu.Items.Add("add vehicle");
                //        for (int i = 0; i < baseInfoMenu.Items.Count; i++)
                //        {
                //            baseInfoMenu.Items[i].Click += new EventHandler(contextmenu_Click);
                //        }
                //        baseInfoMenu.Show(Cursor.Position.X, Cursor.Position.Y);
                //        break;
                //    case "QueueAssign":
                //        baseInfoMenu.Items.Clear();
                //        for (int i = 0; i < baseInfoMenu.Items.Count; i++)
                //        {
                //            baseInfoMenu.Items[i].Click += new EventHandler(contextmenu_Click);
                //        }
                //        baseInfoMenu.Show(Cursor.Position.X, Cursor.Position.Y);
                //        break;
                //    case "Alarm":
                //        baseInfoMenu.Items.Clear();
                //        for (int i = 0; i < baseInfoMenu.Items.Count; i++)
                //        {
                //            baseInfoMenu.Items[i].Click += new EventHandler(contextmenu_Click);
                //        }
                //        baseInfoMenu.Show(Cursor.Position.X, Cursor.Position.Y);
                //        break;
                //    default:
                //        break;
                //}
            }
        }

        private void contextmenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                switch (item.Text)
                {
                    case "add vehicle":
                        formOperation.AddVehicleNode(baseInfoTreeView);
                        break;
                    case "456":
                        MessageBox.Show("dfd");
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitForm();
        }
    }   
}
