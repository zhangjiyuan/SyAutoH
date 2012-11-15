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
        private string strVal = "";

        private void InitForm()
        {
            //ComponentLocChanged();        
            formOperation.FormShowRegionInit();
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
            timer.Interval = 200;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        //test using, finally delete
        public void StartTimer(object source, System.Timers.ElapsedEventArgs e)
        {
            UpdateOHTPosition();
            this.showPic.Invalidate();
        }

        private void UpdateOHTPosition()
        {
            lock (strVal)
            {
                if (strVal.Length < 1)
                {
                    return;
                }
               
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
            dataHubLink.SetCallBack();
        }

        private void GuiDataUpdate(string strTag, string sVal)
        {
            //if (strTag.CompareTo("TEST") == 0)
            //{
            //    this.labelCBTest.Text = sVal;
            //}
            //if (strTag.CompareTo("OHT.POS") == 0)
            //{
            //    this.labelCBTest.Text = sVal;
            //}
            lock (this)
            {
                strVal = sVal;
            }
        }
    }   
}
