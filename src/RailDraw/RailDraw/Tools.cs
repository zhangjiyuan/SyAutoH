using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RailDraw
{
    public partial class Tools : Form
    {
        public bool picLine = false;
        public ListViewItem itemSelected = null;
        public bool winShown = false;

        public Tools()
        {
            InitializeComponent();
        }

        private void Tools_Load(object sender, EventArgs e)
        {
            toolImageList.Images.Add("line", Properties.Resources.line);
            toolImageList.Images.Add("curve", Properties.Resources.curve);
            toolImageList.Images.Add("cross", Properties.Resources.cross);
            eleBtn_Click(sender, e);
        }

        private void Tools_Shown(object sender, EventArgs e)
        {
            winShown = true;
        }

        private void Tools_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            winShown = false;
        }

        [DllImport("user32")]
        private static extern IntPtr LoadCursorFromFile(string fileName);

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                itemSelected = listView1.GetItemAt(e.X, e.Y);
                if (itemSelected != null && e.Button == MouseButtons.Left)
                {
                    this.Cursor = CommonFunction.CreatCursor("draw");
                    picLine = true;
                    FatherWindow temp = (FatherWindow)(this.ParentForm);
                    temp.workRegion.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(temp.workRegion.pictureBox1_MouseUp);
                    temp.workRegion.pictureBox1.MouseEnter += new System.EventHandler(temp.workRegion.pictureBox1_MouseEnter);
                    temp.workRegion.pictureBox1.MouseLeave += new System.EventHandler(temp.workRegion.pictureBox1_MouseLeave);
                }
            }
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                FatherWindow temp = (FatherWindow)(this.ParentForm);
                temp.workRegion.pictureBox1.MouseUp -= new System.Windows.Forms.MouseEventHandler(temp.workRegion.pictureBox1_MouseUp);
                temp.workRegion.pictureBox1.MouseEnter -= new System.EventHandler(temp.workRegion.pictureBox1_MouseEnter);
                temp.workRegion.pictureBox1.MouseLeave -= new System.EventHandler(temp.workRegion.pictureBox1_MouseLeave);
                picLine = false;
            }
        }

        private void eleBtn_Click(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;
            eleBtn.Dock = DockStyle.Top;
            others.Dock = DockStyle.Bottom;
            listView1.BringToFront();
            listView1.Dock = DockStyle.Fill;
            listView1.Clear();

            ListViewItem item = new ListViewItem();
            item.Text = "直轨";
            item.ImageKey = "line";
            listView1.Items.Add(item);

            ListViewItem item1 = new ListViewItem();
            item1.Text = "弯轨";
            item1.ImageKey = "curve";
            listView1.Items.Add(item1);

            ListViewItem item2 = new ListViewItem();
            item2.Text = "叉轨";
            item2.ImageKey = "cross";
            listView1.Items.Add(item2);
        }

        private void others_Click(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;
            eleBtn.Dock = DockStyle.Top;
            others.Dock = DockStyle.Top;
            listView1.BringToFront();
            listView1.Dock = DockStyle.Fill;
            listView1.Clear();
        }

        EventHandlerList toolsEventList = new EventHandlerList();
        public void AddEvent(Control control, string eventname, EventHandler eventhandler)
        { }
        public void DelEvent(Control control, string eventname)
        { }
    }
}
