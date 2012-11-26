using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using BaseRailElement;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;

namespace RailDraw
{
    public partial class FatherWindow : Form
    {
        public ProgramRegion proRegion = new ProgramRegion();
        public PropertyPage proPage = new PropertyPage();
        public WorkRegion workRegion = new WorkRegion();
        public Tools tools = new Tools();
        public BaseRailElement.DrawDoc drawDoc = new BaseRailElement.DrawDoc();
        public BaseRailElement.ObjectBaseEvents objectEvent = new BaseRailElement.ObjectBaseEvents();
        private bool mouseIsDown = false;
        private bool drapIsDown = false;
        private string sProjectPath = "";
        private Size drawregOrigSize = new Size();
        private const Int16 CONST_MULTI_FACTOR = 1;
        private Int16 multiFactor = 1;
        private Point workSize = Point.Empty;

        //using for test
        SaveCodingRail saveCodingRail = new SaveCodingRail();

        public FatherWindow()
        {
            InitializeComponent();
        }

        private void FatherWindow_Load(object sender, EventArgs e)
        {
            BaseRailElement.ObjectBaseEvents.Document = drawDoc;
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            this.Size = (Size)new Point(screen.Width, screen.Height);
            this.Location = new Point(0, 0);
            Point size = (Point)this.ClientSize;
            int menuHeight = this.menuStrip1.Height;
            int toolHeight = this.toolStrip1.Height;
            int statusHeight = this.statusStrip1.Height;
            workSize = new Point(size.X - 4, size.Y - menuHeight - toolHeight - statusHeight - 4);
            Debug.WriteLine(string.Format("size {0} menuH {1} toolH {2} statusH {3}", size, menuHeight, toolHeight, statusHeight));

            proRegion.MdiParent = this;
            proRegion.Location = new Point(0, 0);
            proRegion.Size = (Size)new Point(workSize.X / 6, workSize.Y / 2);
            proRegion.Show();
            Debug.WriteLine(string.Format("programRegion location {0} size {1}", proRegion.Location, proRegion.Size));

            proPage.MdiParent = this;
            proPage.Location = new Point(0, workSize.Y / 2);
            proPage.Size = (Size)new Point(workSize.X / 6, workSize.Y / 2);
            proPage.Show();
            Debug.WriteLine(string.Format("proPage location {0} size {1}", proPage.Location, proPage.Size));
            workRegion.MdiParent = this;
            workRegion.Location = new Point(proRegion.Size.Width, 0);
            workRegion.Size = (Size)new Point(workSize.X / 6 * 4, workSize.Y);
            workRegion.Show();
            Debug.WriteLine(string.Format("workRegion location {0} size {1}", workRegion.Location, workRegion.Size));

            tools.MdiParent = this;
            tools.Location = new Point(proRegion.Size.Width + workRegion.Size.Width, 0);
            tools.Size = (Size)new Point(workSize.X / 6, workSize.Y);
            tools.Show();
            Debug.WriteLine(string.Format("tools location {0} size {1}", tools.Location, tools.Size));

            drawregOrigSize.Width = this.workRegion.pictureBox1.Width;
            drawregOrigSize.Height = this.workRegion.pictureBox1.Height;
        }

        #region
        //workRegion Operation
        public void PicMouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    objectEvent.OnLButtonDown(e.Location);
                    mouseIsDown = true;
                    break;
                case MouseButtons.Right:
                    this.workRegion.contextMenuStripWorkReg.Items.Clear();
                    this.workRegion.ContextMenuStripCreate(objectEvent.OnRButtonDown(e.Location));
                    mouseIsDown = true;
                    break;
            }
            this.workRegion.pictureBox1.Invalidate();
        }

        public void PicMouseUp(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                mouseIsDown = false;
            }
            if (drapIsDown)
            {
                Point pt_offset = objectEvent.DrapDrawRegion(e.Location);
                Point picLoc = this.workRegion.pictureBox1.Location;
                this.workRegion.pictureBox1.Location = new Point(picLoc.X + pt_offset.X, picLoc.Y + pt_offset.Y);
                drapIsDown = true;
            }
            objectEvent.OnLButtonUp(e.Location);
            this.workRegion.pictureBox1.Invalidate();
        }

        public void PicMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown && !drapIsDown)
            {
                objectEvent.OnMouseMove(e.Location);
                this.workRegion.pictureBox1.Invalidate();
            }
        }

        public void PicMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (drawDoc.SelectedDrawObjectList.Count == 1)
                {
                    BaseRailElement.BaseRailEle baseEle = drawDoc.SelectedDrawObjectList[0];
                    Int16 i = Convert.ToInt16(drawDoc.DrawObjectList.IndexOf(drawDoc.SelectedDrawObjectList[0]));
                    SelectedElement(i);
                }
                else
                {
                    this.proPage.propertyGrid1.SelectedObject = null;
                    this.proRegion.treeView1.SelectedNode = null;
                    this.proPage.propertyGrid1.Refresh();
                }
            }
        }
        #endregion

        public void ChangePropertyValue()
        {
            objectEvent.ChangePropertyValue();
            this.workRegion.pictureBox1.Invalidate();
        }

        #region 菜单操作
        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            sProjectPath = "";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "configuration (*.xml)|*.xml";
            saveFile.InitialDirectory = "";
            saveFile.Title = "另存为文件";
            saveFile.FileName = "";
            SaveFile(saveFile);
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void menuChooseAll_Click(object sender, EventArgs e)
        {
            this.drawDoc.SelectedDrawObjectList.Clear();
            if (this.drawDoc.DrawObjectList.Count > 0)
            {
                foreach (BaseRailElement.BaseRailEle o in this.drawDoc.DrawObjectList)
                    this.drawDoc.SelectedDrawObjectList.Add(o);
            }
            this.workRegion.pictureBox1.Invalidate();
        }

        private void menupercentone_Click(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.ToolStripMenuItem)
            {
                System.Windows.Forms.ToolStripMenuItem item = (System.Windows.Forms.ToolStripMenuItem)sender;
                System.Windows.Forms.ToolStrip parent = item.GetCurrentParent();
                int i = parent.Items.IndexOf(item);
                Int16 multi = Convert.ToInt16(i + 1);
                this.workRegion.pictureBox1.Width = drawregOrigSize.Width * multi;
                this.workRegion.pictureBox1.Height = drawregOrigSize.Height * multi;
                EnlargeAndShortenCanvas(multi);
            }
        }

        private void programRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!proRegion.winShown)
            {
                proRegion.Show();
            }
            proRegion.Activate();
        }

        private void propertyPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!proPage.winShown)
            {
                proPage.Show();
            }
            proPage.Activate();
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!tools.winShown)
            {
                tools.Show();
            }
            tools.Activate();
        }

        private void workRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!workRegion.winShown)
            {
                workRegion.Show();
            }
            workRegion.Activate();
        }

        private void FatherWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion

        #region 工具栏操作
        private void new_btn_Click(object sender, EventArgs e)
        {
            if (drawDoc.DrawObjectList.Count > 0)
            {
                SaveOfNew save_form = new SaveOfNew();
                save_form.StartPosition = FormStartPosition.CenterParent;
                switch (save_form.ShowDialog())
                {
                    case DialogResult.Yes:
                        SaveFileDialog saveFile = new SaveFileDialog();
                        saveFile.Filter = "configuration (*.xml)|*.xml";
                        saveFile.InitialDirectory = "";
                        saveFile.Title = "存储文件";
                        saveFile.FileName = "";
                        SaveFile(saveFile);
                        drawDoc.DrawObjectList.Clear();
                        this.workRegion.pictureBox1.Invalidate();
                        break;
                    case DialogResult.No:
                        drawDoc.DrawObjectList.Clear();
                        this.workRegion.pictureBox1.Invalidate();
                        break;
                }
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            sProjectPath = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "configuration (*.xml)|*.xml";
            openFile.InitialDirectory = "";
            openFile.Title = "open files";
            openFile.FileName = "";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string projectpath = openFile.FileName;
                string sname = new FileInfo(projectpath).Name;
                drawDoc.DrawObjectList.Clear();
                this.workRegion.pictureBox1.Top = 0;
                this.workRegion.pictureBox1.Left = 0;
                this.workRegion.pictureBox1.Width = drawregOrigSize.Width;
                this.workRegion.pictureBox1.Height = drawregOrigSize.Height;
                drapIsDown = false;
                this.Cursor = System.Windows.Forms.Cursors.Default;
                try
                {
                    FileStream fs = new FileStream(projectpath, FileMode.Open);
                    XmlSerializer mySerializer = new XmlSerializer(typeof(BaseRailElement.DrawDoc));
                    drawDoc = (BaseRailElement.DrawDoc)mySerializer.Deserialize(fs);
                    fs.Close();
                    BaseRailElement.ObjectBaseEvents.Document = drawDoc;
                }
                catch
                {
                    MessageBox.Show("open error");
                }
            }
            this.workRegion.pictureBox1.Invalidate();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (sProjectPath == "")
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "configuration (*.xml)|*.xml";
                saveFile.InitialDirectory = "";
                saveFile.Title = "存储文件";
                saveFile.FileName = "";
                SaveFile(saveFile);
            }
            else
            {
                try
                {
                    string projectpath = sProjectPath;
                    XmlSerializer mySerializer = new XmlSerializer(typeof(BaseRailElement.DrawDoc));
                    StreamWriter myWriter = new StreamWriter(projectpath);
                    mySerializer.Serialize(myWriter, drawDoc);
                    myWriter.Close();
                }
                catch
                {
                    MessageBox.Show("save error");
                }
            }
        }

        private void cut_Click(object sender, EventArgs e)
        {
            this.drawDoc.Cut();
            this.workRegion.pictureBox1.Invalidate();
        }

        private void copy_Click(object sender, EventArgs e)
        {
            CopyElement();
        }

        private void paste_Click(object sender, EventArgs e)
        {
            PasteElement();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DeleteElement();
        }

        private void enlarge_Click(object sender, EventArgs e)
        {
            if (this.workRegion.pictureBox1.Width < drawregOrigSize.Width * 4)
            {
                this.workRegion.pictureBox1.Width += (drawregOrigSize.Width * CONST_MULTI_FACTOR);
                this.workRegion.pictureBox1.Height += (drawregOrigSize.Height * CONST_MULTI_FACTOR);
                multiFactor = Convert.ToInt16(this.workRegion.pictureBox1.Width / drawregOrigSize.Width);
                this.drawDoc.DrawMultiFactor = multiFactor;
                int n = this.drawDoc.DrawObjectList.Count;
                for (int i = 0; i < n; i++)
                {
                    this.drawDoc.DrawObjectList[i].DrawMultiFactor = multiFactor;
                }
                ChangeDrawRegionLoction();
                this.workRegion.pictureBox1.Invalidate();
            }
        }

        private void shorten_Click(object sender, EventArgs e)
        {
            if (this.workRegion.pictureBox1.Width > drawregOrigSize.Width)
            {
                this.workRegion.pictureBox1.Width -= (drawregOrigSize.Width * CONST_MULTI_FACTOR);
                this.workRegion.pictureBox1.Height -= (drawregOrigSize.Height * CONST_MULTI_FACTOR);
                multiFactor = Convert.ToInt16(this.workRegion.pictureBox1.Width / drawregOrigSize.Width);
                this.drawDoc.DrawMultiFactor = multiFactor;
                int n = this.drawDoc.DrawObjectList.Count;
                for (int i = 0; i < n; i++)
                    this.drawDoc.DrawObjectList[i].DrawMultiFactor = multiFactor;
                this.workRegion.pictureBox1.Invalidate();
                ChangeDrawRegionLoction();
            }
        }

        private void counter_clw_Click(object sender, EventArgs e)
        {
            if (this.drawDoc.SelectedDrawObjectList.Count > 0)
            {
                this.drawDoc.SelectedDrawObjectList[0].RotateCounterClw();
                this.workRegion.pictureBox1.Invalidate();
                this.proPage.propertyGrid1.Refresh();
            }   
        }

        private void clw_Click(object sender, EventArgs e)
        {
            if (this.drawDoc.SelectedDrawObjectList.Count > 0)
            {
                this.drawDoc.SelectedDrawObjectList[0].RotateClw();
                this.workRegion.pictureBox1.Invalidate();
                this.proPage.propertyGrid1.Refresh();
            }
        }

        private void drap_Click(object sender, EventArgs e)
        {
            drapIsDown = true;
        }

        private void mouse_Click(object sender, EventArgs e)
        {
            drapIsDown = false;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void mirror_Click(object sender, EventArgs e)
        {
            if (this.drawDoc.SelectedDrawObjectList.Count > 0)
            {
                this.drawDoc.SelectedDrawObjectList[0].ObjectMirror();
                this.workRegion.pictureBox1.Invalidate();
            }
        }

        private void addtext_Click(object sender, EventArgs e)
        {
            BaseRailElement.RailLabal railLalal = new BaseRailElement.RailLabal();
            this.drawDoc.DrawObjectList.Add(railLalal.CreatEle(multiFactor, this.tools.itemSelected.Text));
            drawDoc.SelectOne(railLalal);
            proRegion.AddElementNode(this.workRegion.tabPage1, railLalal.railText);
            this.workRegion.pictureBox1.Invalidate();
            proPage.propertyGrid1.SelectedObject = railLalal;
            proPage.propertyGrid1.Refresh();
        }
        #endregion

        private void SaveFile(SaveFileDialog sFile)
        {
            if (sFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string projectpath = sFile.FileName;
                    sProjectPath = projectpath;
                    XmlSerializer mySerializer = new XmlSerializer(typeof(BaseRailElement.DrawDoc));
                    StreamWriter myWriter = new StreamWriter(projectpath);
                    mySerializer.Serialize(myWriter, drawDoc);
                    myWriter.Close();
                }
                catch
                {
                    MessageBox.Show("save error");
                }
            }
        }

        private void EnlargeAndShortenCanvas(Int16 drawMulti)
        {
            int n = this.drawDoc.DrawObjectList.Count;
            for (int i = 0; i < n; i++)
                this.drawDoc.DrawObjectList[i].DrawMultiFactor = drawMulti;
            this.workRegion.pictureBox1.Invalidate();
            ChangeDrawRegionLoction();
        }

        private void ChangeDrawRegionLoction()
        {
            Point drawRegionLoc = Point.Empty;
            Point drawRegionSize = (Point)this.workRegion.pictureBox1.Size;
            Point workRegSize = (Point)this.workRegion.tabPage1.Size;
            Point centerDrawRegion = new Point(drawRegionSize.X / 2, drawRegionSize.Y / 2);
            Point centerWorkRegSize = new Point(workRegSize.X / 2, workRegSize.Y / 2);
            int dx = centerWorkRegSize.X - centerDrawRegion.X;
            int dy = centerWorkRegSize.Y - centerDrawRegion.Y;
            drawRegionLoc.Offset(dx, dy);
            this.workRegion.pictureBox1.Location = drawRegionLoc;
        }

        public void CreateElement(Point mousePt, Size workRegionSize)
        {
            switch (this.tools.itemSelected.Text)
            {
                case "直轨":
                    BaseRailElement.StraightRailEle strRailEle = new BaseRailElement.StraightRailEle();
                    drawDoc.DrawObjectList.Add(strRailEle.CreatEle(mousePt, workRegionSize, multiFactor, this.tools.itemSelected.Text));
                    drawDoc.SelectOne(strRailEle);
                    proRegion.AddElementNode(this.workRegion.tabPage1, strRailEle.railText);
                    workRegion.pictureBox1.Invalidate();
                    proPage.propertyGrid1.SelectedObject = strRailEle;
                    proPage.propertyGrid1.Refresh();
                    break;
                case "弯轨":
                    BaseRailElement.CurvedRailEle curRailEle = new BaseRailElement.CurvedRailEle();
                    drawDoc.DrawObjectList.Add(curRailEle.CreatEle(mousePt, workRegionSize, multiFactor, this.tools.itemSelected.Text));
                    drawDoc.SelectOne(curRailEle);
                    proRegion.AddElementNode(this.workRegion.tabPage1, curRailEle.railText);
                    workRegion.pictureBox1.Invalidate();
                    proPage.propertyGrid1.SelectedObject = curRailEle;
                    proPage.propertyGrid1.Refresh();
                    break;
                case "叉轨":
                    BaseRailElement.CrossEle croRailEle = new BaseRailElement.CrossEle();
                    drawDoc.DrawObjectList.Add(croRailEle.CreatEle(mousePt, workRegionSize, multiFactor, this.tools.itemSelected.Text));
                    drawDoc.SelectOne(croRailEle);
                    proRegion.AddElementNode(this.workRegion.tabPage1, croRailEle.railText);
                    workRegion.pictureBox1.Invalidate();
                    proPage.propertyGrid1.SelectedObject = croRailEle;
                    proPage.propertyGrid1.Refresh();
                    break;
                default:
                    break;
            }
            this.tools.itemSelected = null;
        }

        public void AddProjectNode(string str)
        {
            TreeNode rootNode = new TreeNode(str);
            this.proRegion.treeView1.Nodes.Add(rootNode);
        }

        public void SelectedElement(Int16 index)
        {
            drawDoc.SelectedDrawObjectList.Clear();
            if (index >= 0)
            {
                drawDoc.SelectedDrawObjectList.Add(drawDoc.DrawObjectList[index]);
                this.proRegion.treeView1.SelectedNode = this.proRegion.treeNodeList[index];
                this.proPage.propertyGrid1.SelectedObject = drawDoc.SelectedDrawObjectList[0];
            }
            else
            {
                this.proPage.propertyGrid1.SelectedObject = null;
            }
            this.proPage.propertyGrid1.Refresh();
            this.workRegion.pictureBox1.Invalidate();
        }

        public void CutElement()
        {
        }

        public void CopyElement()
        {
            this.drawDoc.Copy();
        }

        public void PasteElement()
        {
            for (Int16 i = 0; i < drawDoc.CutAndCopyObjectList.Count; )
            {
                this.proRegion.AddElementNode(this.workRegion.tabPage1, drawDoc.CutAndCopyObjectList[0].railText);
                this.drawDoc.Paste();
                this.workRegion.pictureBox1.Invalidate();
            }
        }

        public void DeleteElement()
        {
            for (Int16 i = 0; i < drawDoc.SelectedDrawObjectList.Count; )
            {
                Int16 num = Convert.ToInt16(drawDoc.DrawObjectList.IndexOf(drawDoc.SelectedDrawObjectList[0]));
                this.proRegion.DeleteElementNode(this.workRegion.tabPage1, num);
                this.drawDoc.Delete(num);
                this.workRegion.pictureBox1.Invalidate();
            }
        }
    }
}
