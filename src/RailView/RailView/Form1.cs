using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using GuiAccess;
using WinFormElement;

namespace RailView
{
    public partial class Form1 : Form
    {
        WinFormElement.FormOperation formOperation = new WinFormElement.FormOperation();
        public Form1()
        {
            InitializeComponent();
        }

        private DataHubCli dataHubLink = new DataHubCli();
        private Queue<MCS.GuiDataItem> quGuiData = new Queue<MCS.GuiDataItem>();

        private void InitForm()
        {
            //ComponentLocChanged();        
            formOperation.FormShowRegionInit();
            //test using, finally delete
            TestRailDrawCoor();
            this.showPic.Invalidate();
          //  this.Invalidate();
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
            timer.Interval = 200;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        //test using, finally delete
        public void StartTimer(object source, System.Timers.ElapsedEventArgs e)
        {
            ProcessGuiDataBuf();
            this.showPic.Invalidate();
        }

        private void ProcessGuiDataBuf()
        {
            lock (quGuiData)
            {
                while (quGuiData.Count != 0)
                {
                    MCS.GuiDataItem item = quGuiData.Dequeue();
                    UpdateOHTPosition(item);
                }
            }
        }

        private void UpdateOHTPosition(MCS.GuiDataItem guiDataItem)
        {
                if (guiDataItem.enumTag.CompareTo(MCS.GuiHub.PushData.upOhtPos) != 0)
                {
                    return;
                }
                if (guiDataItem.sVal.Length < 1)
                {
                    return;
                }
                string strVal = guiDataItem.sVal;
               
                string strSplit = "<>";
                char[] spliter = strSplit.ToCharArray();
                string[] strItem = strVal.Split(spliter);

                List<OhtPos> listOht = new List<OhtPos>();
                foreach (string strOht in strItem)
                {
                    if (strOht.Length > 0)
                    {
                        string[] strParams = strOht.Split(',');
                        if (strParams.Length == 3)
                        {
                            OhtPos oht = new OhtPos();
                            oht.nID = Convert.ToByte(strParams[0]);
                            oht.nPos = Convert.ToUInt32(strParams[1]);
                            oht.nHand = Convert.ToByte(strParams[2]);
                            listOht.Add(oht);
                        }
                    }
                }

                formOperation.UpdateOHTPos(listOht);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            InitForm();

            dataHubLink.ConnectServer();
            dataHubLink.DataUpdater += new DataUpdaterHander(GuiDataUpdate);
            dataHubLink.Async_SetCallBack();
        }

        private void GuiDataUpdate(long lTime, MCS.GuiDataItem guiData)
        {
            lock (quGuiData)
            {
                quGuiData.Enqueue(guiData);
            }
        }

        private void quitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Want to Quit?", "Warnning", MessageBoxButtons.OKCancel) )
            {
                this.Close();
            }
        }

        private void screenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (FormBorderStyle.None == this.FormBorderStyle)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.screenToolStripMenuItem.Text = "Full Screen";
                this.screenToolStripMenuItem.Image = global::RailView.Properties.Resources.full_screen2;
            }
            else
            {
                this.TopMost = true;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.screenToolStripMenuItem.Text = "Normal Screen";
                this.screenToolStripMenuItem.Image = global::RailView.Properties.Resources.normal_screen2;
            }
        }
    }   
}
