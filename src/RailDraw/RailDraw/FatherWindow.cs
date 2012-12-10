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

            proRegion.Show(this.dockPanel1);
            proRegion.DockTo(this.dockPanel1, DockStyle.Left);
            Debug.WriteLine(string.Format("programRegion location {0} size {1}", proRegion.Location, proRegion.Size));

            proPage.Show(this.dockPanel1);
            proPage.DockTo(this.dockPanel1, DockStyle.Left);
            Debug.WriteLine(string.Format("proPage location {0} size {1}", proPage.Location, proPage.Size));

            workRegion.Size = (Size)new Point(workSize.X / 6 * 4, workSize.Y);
            workRegion.Show(this.dockPanel1);
            workRegion.DockTo(this.dockPanel1, DockStyle.Fill);
            Debug.WriteLine(string.Format("workRegion location {0} size {1}", workRegion.Location, workRegion.Size));

            tools.Show(this.dockPanel1);
            tools.DockTo(this.dockPanel1, DockStyle.Right);
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
            this.workRegion.pictureBox1.Focus();
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
            this.workRegion.Activate();
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
                        drawDoc.SelectedDrawObjectList.Clear();
                        proRegion.treeNodeList.Clear();
                        proRegion.treeView1.Nodes[0].Nodes.Clear();
                        this.workRegion.pictureBox1.Invalidate();
                        this.proRegion.Invalidate();
                        break;
                    case DialogResult.No:
                        drawDoc.DrawObjectList.Clear();
                        drawDoc.SelectedDrawObjectList.Clear();
                        proRegion.treeNodeList.Clear();
                        proRegion.treeView1.Nodes[0].Nodes.Clear();
                        this.workRegion.pictureBox1.Invalidate();
                        this.proRegion.Invalidate();
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
                drawDoc.DrawObjectList.Clear();
                drawDoc.SelectedDrawObjectList.Clear();
                proRegion.treeNodeList.Clear();
                proRegion.treeView1.Nodes[0].Nodes.Clear();
                this.workRegion.pictureBox1.Top = 0;
                this.workRegion.pictureBox1.Left = 0;
                this.workRegion.pictureBox1.Width = drawregOrigSize.Width;
                this.workRegion.pictureBox1.Height = drawregOrigSize.Height;
                drapIsDown = false;
                this.Cursor = System.Windows.Forms.Cursors.Default;
                try
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(projectpath);
                    if (OpenXmlFile(ds))
                        BaseRailElement.ObjectBaseEvents.Document = drawDoc;
                }
                catch
                {
                    MessageBox.Show("open error");
                }
            }
            this.workRegion.pictureBox1.Invalidate();
            this.proRegion.Invalidate();
            this.proRegion.treeView1.Invalidate();
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
                    drawDoc.DataXmlSave();
                    drawDoc.ds.WriteXml(projectpath);
                }
                catch(Exception ex)
                {
                    //MessageBox.Show("save error");
                    Debug.WriteLine(string.Format("error is: {0}", ex));
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
            proRegion.AddElementNode(this.workRegion.Text, railLalal.railText);
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
                    drawDoc.DataXmlSave();
                    drawDoc.ds.WriteXml(projectpath);
                }
                catch
                {
                    MessageBox.Show("save error");
                }
            }
        }

        private bool OpenXmlFile(DataSet ds)
        {
            try
            {
                foreach (DataTable dt in ds.Tables)
                {
                    DataColumn dc = dt.Columns[0];
                    if (dc.ColumnName == "GraphType")
                    {
                        switch (dt.Rows[0][0].ToString())
                        {
                            case "1":
                                BaseRailElement.StraightRailEle strTemp = new BaseRailElement.StraightRailEle();
                                string str ="";
                                string[] strPointArray = { };
                                Point ptTemp=Point.Empty;
                                Int16 pointListVolStr = 0;
                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    switch (dt.Columns[i].ColumnName)
                                    {
                                        case "GraphType":
                                            strTemp.GraphType = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "Speed":
                                            strTemp.Speed = Convert.ToSingle(dt.Rows[0][i]);
                                            break;
                                        case "SegmentNumber":
                                            strTemp.SegmentNumber = Convert.ToInt16(dt.Rows[0][i]);
                                            break;
                                        case "TagNumber":
                                            strTemp.TagNumber = Convert.ToInt16(dt.Rows[0][i]);
                                            break;
                                        case "Lenght":
                                            strTemp.Lenght = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "StartAngle":
                                            strTemp.StartAngle = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "StartDot":
                                            strTemp.StartDot = Convert.ToString(dt.Rows[0][i]);
                                            break;
                                        case "PointListVol":
                                            pointListVolStr = Convert.ToInt16(dt.Rows[0][i]);
                                            for (int j = 0; j < pointListVolStr; j++)
                                            {
                                                str = dt.Rows[0][i + j + 1].ToString();
                                                str = str.Substring(1, str.Length - 2);
                                                strPointArray = str.Split(',');
                                                ptTemp = new Point() { X = int.Parse(strPointArray[0].Substring(2)), Y = int.Parse(strPointArray[1].Substring(2)) };
                                                strTemp.PointList.Add(ptTemp);
                                            }
                                            break;
                                        case "DrawMultiFactor":
                                            strTemp.DrawMultiFactor = Convert.ToInt16(dt.Rows[0][i]);
                                            break;
                                        case "startPoint":
                                            str = dt.Rows[0][i].ToString();
                                            str = str.Substring(1, str.Length - 2);
                                            strPointArray = str.Split(',');
                                            ptTemp = new Point() { X = int.Parse(strPointArray[0].Substring(2)), Y = int.Parse(strPointArray[1].Substring(2)) };
                                            strTemp.StartPoint = ptTemp;
                                            break;
                                        case "endPoint":
                                            str = dt.Rows[0][i].ToString();
                                            str = str.Substring(1, str.Length - 2);
                                            strPointArray = str.Split(',');
                                            ptTemp = new Point() { X = int.Parse(strPointArray[0].Substring(2)), Y = int.Parse(strPointArray[1].Substring(2)) };
                                            strTemp.EndPoint = ptTemp;
                                            break;
                                        case "railText":
                                            strTemp.railText = dt.Rows[0][i].ToString();
                                            break;
                                        case "rotateAngle":
                                            strTemp.RotateAngle = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "nextCoding":
                                            strTemp.NextCoding = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "prevCoding":
                                            strTemp.PrevCoding = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                    }
                                }
                                AddElement(strTemp);
                                break;
                            case "2":
                                BaseRailElement.CurvedRailEle curTemp = new BaseRailElement.CurvedRailEle();
                                string strcur = "";
                                string[] strPointArrayCur = { };
                                Point ptcur = Point.Empty;
                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    switch (dt.Columns[i].ColumnName)
                                    {
                                        case "GraphType":
                                            curTemp.GraphType = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "Speed":
                                            curTemp.Speed = Convert.ToSingle(dt.Rows[0][i]);
                                            break;
                                        case "SegmentNumber":
                                            curTemp.SegmentNumber = Convert.ToInt16(dt.Rows[0][i]);
                                            break;
                                        case "TagNumber":
                                            curTemp.TagNumber = Convert.ToInt16(dt.Rows[0][i]);
                                            break;
                                        case "StartAngle":
                                            curTemp.StartAngle = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "SweepAngle":
                                            curTemp.SweepAngle = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "Radiu":
                                            curTemp.Radiu = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "Center":
                                            strcur = dt.Rows[0][i].ToString();
                                            strcur = strcur.Substring(1, strcur.Length - 2);
                                            strPointArrayCur = strcur.Split(',');
                                            ptcur = new Point() { X = int.Parse(strPointArrayCur[0].Substring(2)), Y = int.Parse(strPointArrayCur[1].Substring(2)) };
                                            curTemp.Center = ptcur;
                                            break;
                                        case "FirstDot":
                                            strcur = dt.Rows[0][i].ToString();
                                            strcur = strcur.Substring(1, strcur.Length - 2);
                                            strPointArrayCur = strcur.Split(',');
                                            ptcur = new Point() { X = int.Parse(strPointArrayCur[0].Substring(2)), Y = int.Parse(strPointArrayCur[1].Substring(2)) };
                                            curTemp.FirstDot = ptcur;
                                            break;
                                        case "SecDot":
                                            strcur = dt.Rows[0][i].ToString();
                                            strcur = strcur.Substring(1, strcur.Length - 2);
                                            strPointArrayCur = strcur.Split(',');
                                            ptcur = new Point() { X = int.Parse(strPointArrayCur[0].Substring(2)), Y = int.Parse(strPointArrayCur[1].Substring(2)) };
                                            curTemp.SecDot = ptcur;
                                            break;
                                        case "DirectionCurvedAttribute":
                                            curTemp.DirectionCurvedAttribute = (BaseRailElement.CurvedRailEle.DirectonCurved)Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "startPoint":
                                            str = dt.Rows[0][i].ToString();
                                            str = str.Substring(1, str.Length - 2);
                                            strPointArrayCur = str.Split(',');
                                            ptcur = new Point() { X = int.Parse(strPointArrayCur[0].Substring(2)), Y = int.Parse(strPointArrayCur[1].Substring(2)) };
                                            curTemp.StartPoint = ptcur;
                                            break;
                                        case "endPoint":
                                            str = dt.Rows[0][i].ToString();
                                            str = str.Substring(1, str.Length - 2);
                                            strPointArrayCur = str.Split(',');
                                            ptcur = new Point() { X = int.Parse(strPointArrayCur[0].Substring(2)), Y = int.Parse(strPointArrayCur[1].Substring(2)) };
                                            curTemp.EndPoint = ptcur;
                                            break;
                                        case "startCoding":
                                            curTemp.StartCoding = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "endCoding":
                                            curTemp.EndCoding = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "railText":
                                            curTemp.railText = dt.Rows[0][i].ToString();
                                            break;
                                        case "rotateAngle":
                                            curTemp.RotateAngle = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "oldRadiu":
                                            curTemp.oldRadiu = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "oldCenter":
                                            str = dt.Rows[0][i].ToString();
                                            str = str.Substring(1, str.Length - 2);
                                            strPointArrayCur = str.Split(',');
                                            ptcur = new Point() { X = int.Parse(strPointArrayCur[0].Substring(2)), Y = int.Parse(strPointArrayCur[1].Substring(2)) };
                                            curTemp.oldCenter = ptcur;
                                            break;
                                        case "oldFirstDot":
                                            str = dt.Rows[0][i].ToString();
                                            str = str.Substring(1, str.Length - 2);
                                            strPointArrayCur = str.Split(',');
                                            ptcur = new Point() { X = int.Parse(strPointArrayCur[0].Substring(2)), Y = int.Parse(strPointArrayCur[1].Substring(2)) };
                                            curTemp.oldFirstDot = ptcur;
                                            break;
                                        case "oldSecDot":
                                            str = dt.Rows[0][i].ToString();
                                            str = str.Substring(1, str.Length - 2);
                                            strPointArrayCur = str.Split(',');
                                            ptcur = new Point() { X = int.Parse(strPointArrayCur[0].Substring(2)), Y = int.Parse(strPointArrayCur[1].Substring(2)) };
                                            curTemp.oldSecDot = ptcur;
                                            break;
                                    }
                                }
                                AddElement(curTemp);
                                break;
                            case "3":
                                BaseRailElement.CrossEle croTemp = new BaseRailElement.CrossEle();
                                string strcro = "";
                                string[] strPointArrayCro = { };
                                Point ptcro = Point.Empty;
                                Int16 pointListVolCro = 0;
                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    switch (dt.Columns[i].ColumnName)
                                    {
                                        case "GraphType":
                                            croTemp.GraphType = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "Speed":
                                            croTemp.Speed = Convert.ToSingle(dt.Rows[0][i]);
                                            break;
                                        case "SegmentNumber":
                                            croTemp.SegmentNumber = Convert.ToInt16(dt.Rows[0][i]);
                                            break;
                                        case "TagNumber":
                                            croTemp.TagNumber = Convert.ToInt16(dt.Rows[0][i]);
                                            break;
                                        case "Mirror":
                                            croTemp.Mirror = Convert.ToBoolean(dt.Rows[0][i]);
                                            break;
                                        case "FirstPart":
                                            croTemp.FirstPart = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "SecPart":
                                            croTemp.SecPart = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "ThPart":
                                            croTemp.ThPart = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "FourPart":
                                            strcro = dt.Rows[0][i].ToString();
                                            strcro = strcro.Substring(1, strcro.Length - 2);
                                            strPointArrayCro = strcro.Split(',');
                                            ptcro = new Point() { X = int.Parse(strPointArrayCro[0].Substring(2)), Y = int.Parse(strPointArrayCro[1].Substring(2)) };
                                            croTemp.FourPart = ptcro;
                                            break;
                                        case "StartAngle":
                                            croTemp.StartAngle = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "RotateAngle":
                                            croTemp.RotateAngle = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "DirectionOfCross":
                                            croTemp.DirectionOfCross = (BaseRailElement.CrossEle.DirectionCross)Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "PointListVol":
                                            pointListVolCro = Convert.ToInt16(dt.Rows[0][i]);
                                            for (Int16 j = 0; j < pointListVolCro; j++)
                                            {
                                                strcro = dt.Rows[0][i + j + 1].ToString();
                                                strcro = strcro.Substring(1, strcro.Length - 2);
                                                strPointArrayCro = strcro.Split(',');
                                                ptcro = new Point() { X = int.Parse(strPointArrayCro[0].Substring(2)), Y = int.Parse(strPointArrayCro[1].Substring(2)) };
                                                croTemp.PointList.Add(ptcro);
                                            }
                                            break;
                                        case "drawMultiFactor":
                                            croTemp.DrawMultiFactor = Convert.ToInt16(dt.Rows[0][i]);
                                            break;
                                        case "startPoint":
                                            strcro = dt.Rows[0][i].ToString();
                                            strcro = strcro.Substring(1, strcro.Length - 2);
                                            strPointArrayCro = strcro.Split(',');
                                            ptcro = new Point() { X = int.Parse(strPointArrayCro[0].Substring(2)), Y = int.Parse(strPointArrayCro[1].Substring(2)) };
                                            croTemp.StartPoint = ptcro;
                                            break;
                                        case "endPoint":
                                            strcro = dt.Rows[0][i].ToString();
                                            strcro = strcro.Substring(1, strcro.Length - 2);
                                            strPointArrayCro = strcro.Split(',');
                                            ptcro = new Point() { X = int.Parse(strPointArrayCro[0].Substring(2)), Y = int.Parse(strPointArrayCro[1].Substring(2)) };
                                            croTemp.EndPoint = ptcro;
                                            break;
                                        case "startCoding":
                                            croTemp.StartCoding = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "endCoding":
                                            croTemp.EndCoding = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "railText":
                                            croTemp.railText = dt.Rows[0][i].ToString();
                                            break;
                                        case "lenghtOfStrai":
                                            croTemp.LenghtOfStrai = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "nextCoding":
                                            croTemp.NextCoding = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "prevCoding":
                                            croTemp.PrevCoding = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "thirdDotCoding":
                                            croTemp.ThirdDotCoding = Convert.ToInt32(dt.Rows[0][i]);
                                            break;
                                        case "startDot":
                                            croTemp.StartDot = dt.Rows[0][i].ToString();
                                            break;
                                    }
                                }
                                AddElement(croTemp);
                                break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("this is a error when open xml save file");
                return false;
            }
            return true;
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
            Point workRegSize = (Point)this.workRegion.panel1.Size;
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
                    strRailEle.CreatEle(mousePt, workRegionSize, multiFactor, this.tools.itemSelected.Text);
                    AddElement(strRailEle);
                    drawDoc.SelectOne(strRailEle);
                    workRegion.pictureBox1.Invalidate();
                    proPage.propertyGrid1.SelectedObject = strRailEle;
                    proPage.propertyGrid1.Refresh();
                    break;
                case "弯轨":
                    BaseRailElement.CurvedRailEle curRailEle = new BaseRailElement.CurvedRailEle();
                    curRailEle.CreatEle(mousePt, workRegionSize, multiFactor, this.tools.itemSelected.Text);
                    AddElement(curRailEle);
                    drawDoc.SelectOne(curRailEle);
                    workRegion.pictureBox1.Invalidate();
                    proPage.propertyGrid1.SelectedObject = curRailEle;
                    proPage.propertyGrid1.Refresh();
                    break;
                case "叉轨":
                    BaseRailElement.CrossEle croRailEle = new BaseRailElement.CrossEle();
                    croRailEle.CreatEle(mousePt, workRegionSize, multiFactor, this.tools.itemSelected.Text);
                    AddElement(croRailEle);
                    drawDoc.SelectOne(croRailEle);
                    workRegion.pictureBox1.Invalidate();
                    proPage.propertyGrid1.SelectedObject = croRailEle;
                    proPage.propertyGrid1.Refresh();
                    break;
                default:
                    break;
            }
            this.tools.itemSelected = null;
        }

        private void AddElement(BaseRailEle baseRailEle)
        {
            switch (baseRailEle.railText)
            {
                case "直轨":
                    BaseRailElement.StraightRailEle strRailEle = (BaseRailElement.StraightRailEle)baseRailEle;
                    drawDoc.DrawObjectList.Add(strRailEle);
                    proRegion.AddElementNode(this.workRegion.Text, strRailEle.railText);
                    break;
                case "弯轨":
                    BaseRailElement.CurvedRailEle curRailEle = (BaseRailElement.CurvedRailEle)baseRailEle;
                    drawDoc.DrawObjectList.Add(curRailEle);
                    proRegion.AddElementNode(this.workRegion.Text, curRailEle.railText);
                    break;
                case "叉轨":
                    BaseRailElement.CrossEle croRailEle = (BaseRailElement.CrossEle)baseRailEle;
                    drawDoc.DrawObjectList.Add(croRailEle);
                    proRegion.AddElementNode(this.workRegion.Text, croRailEle.railText);
                    break;
            }
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
                this.proRegion.AddElementNode(this.workRegion.Text, drawDoc.CutAndCopyObjectList[0].railText);
                this.drawDoc.Paste();
                this.workRegion.pictureBox1.Invalidate();
            }
        }

        public void DeleteElement()
        {
            for (Int16 i = 0; i < drawDoc.SelectedDrawObjectList.Count; )
            {
                Int16 num = Convert.ToInt16(drawDoc.DrawObjectList.IndexOf(drawDoc.SelectedDrawObjectList[0]));
                this.proRegion.DeleteElementNode(this.workRegion.Text, num);
                this.drawDoc.Delete(num);
                this.workRegion.pictureBox1.Invalidate();
            }
        }

        public void WorkRegionKeyMove(Keys key)
        {
            BaseRailElement.ObjectBaseEvents.Direction direction = BaseRailElement.ObjectBaseEvents.Direction.Null;
            switch (key)
            {
                case Keys.Up:
                    direction = BaseRailElement.ObjectBaseEvents.Direction.up;
                    break;
                case Keys.Down:
                    direction = BaseRailElement.ObjectBaseEvents.Direction.down;
                    break;
                case Keys.Left:
                    direction = BaseRailElement.ObjectBaseEvents.Direction.left;
                    break;
                case Keys.Right:
                    direction = BaseRailElement.ObjectBaseEvents.Direction.right;
                    break;
                default:
                    break;
            }
            objectEvent.WorkRegionKeyDown(direction);
            this.workRegion.pictureBox1.Invalidate();
        }
    }
}
