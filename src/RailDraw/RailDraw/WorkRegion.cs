using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using WeifenLuo.WinFormsUI.Docking;

namespace RailDraw
{
    public partial class WorkRegion : DockContent
    {
        public bool winShown = false;

        public WorkRegion()
        {
            InitializeComponent();
        }

        private void WorkRegion_Load(object sender, EventArgs e)
        {
            Point sizeTabPage = (Point)this.panel1.Size;
            this.pictureBox1.Size = (Size)sizeTabPage;
            this.pictureBox1.Location = new Point(0);
        }

        private void WorkRegion_Shown(object sender, EventArgs e)
        {
            winShown = true;
        }

        private void WorkRegion_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            winShown = false;
        }

        public void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.pictureBox1.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.MouseEnter -= new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave -= new System.EventHandler(this.pictureBox1_MouseLeave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            ((FatherWindow)this.ParentForm).CreateElement(e.Location, this.pictureBox1.ClientSize);
            this.Activate();
        }

        public void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = CommonFunction.CreatCursor("draw");
        }

        public void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ((FatherWindow)this.ParentForm).drawDoc.Draw(e.Graphics);
            g.ResetTransform();
            base.OnPaint(e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ((FatherWindow)this.ParentForm).PicMouseDown(sender, e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            ((FatherWindow)this.ParentForm).PicMouseMove(sender, e);
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            ((FatherWindow)this.ParentForm).PicMouseUp(sender, e);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ((FatherWindow)this.ParentForm).PicMouseClick(sender, e);
        }

        public void contextmenustrip_Click(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.ToolStripMenuItem)
            {
                System.Windows.Forms.ToolStripMenuItem item = (System.Windows.Forms.ToolStripMenuItem)sender;
                System.Windows.Forms.ContextMenuStrip parent = (System.Windows.Forms.ContextMenuStrip)item.GetCurrentParent();
                int i = parent.Items.IndexOf(item);
                Int16 multi = Convert.ToInt16(i + 1);
                switch (multi)
                {
                    case 1:
                        ((FatherWindow)this.ParentForm).CutElement();
                        break;
                    case 2:
                        ((FatherWindow)this.ParentForm).CopyElement();
                        break;
                    case 3:
                        ((FatherWindow)this.ParentForm).PasteElement();
                        break;
                    case 4:
                        ((FatherWindow)this.ParentForm).DeleteElement();
                        break;
                }
            }
        }

        public void DeleteElement()
        {
            ((FatherWindow)this.ParentForm).DeleteElement();
        }

        public void ContextMenuStripCreate(bool var)
        {
            contextMenuStripWorkReg.Items.Clear();
            //contextMenuStripWorkReg.Items.Add("cut");
            //contextMenuStripWorkReg.Items.Add("copy");
            //contextMenuStripWorkReg.Items.Add("paste");
            //contextMenuStripWorkReg.Items.Add("delete");
            contextMenuStripWorkReg.Items.Add("cut", global::RailDraw.Properties.Resources.cut);
            contextMenuStripWorkReg.Items.Add("copy", global::RailDraw.Properties.Resources.Copy);
            contextMenuStripWorkReg.Items.Add("paste", global::RailDraw.Properties.Resources.Paste);
            contextMenuStripWorkReg.Items.Add("delete", global::RailDraw.Properties.Resources.delete);
            for (Int16 i = 0; i < contextMenuStripWorkReg.Items.Count; i++)
            {
                contextMenuStripWorkReg.Items[i].Click += new EventHandler(contextmenustrip_Click);
            }
            contextMenuStripWorkReg.Show(Cursor.Position);
            if (var)
            {
                contextMenuStripWorkReg.Items[2].Enabled = false;
            }
            else
            {
                if (((FatherWindow)this.ParentForm).drawDoc.CutAndCopyObjectList.Count > 0)
                {
                    contextMenuStripWorkReg.Items[0].Enabled = false;
                    contextMenuStripWorkReg.Items[1].Enabled = false;
                    contextMenuStripWorkReg.Items[3].Enabled = false;
                }
                else
                {
                    contextMenuStripWorkReg.Items[0].Enabled = false;
                    contextMenuStripWorkReg.Items[1].Enabled = false;
                    contextMenuStripWorkReg.Items[2].Enabled = false;
                    contextMenuStripWorkReg.Items[3].Enabled = false;
                }
            }
        }
    }
}
