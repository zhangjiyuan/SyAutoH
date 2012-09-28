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

namespace RailDraw
{
    public partial class RailDraw : Form
    {
        BaseRailElement.DrawDoc doc1 = new BaseRailElement.DrawDoc();
        BaseRailElement.ObjectBaseEvents objectEvent = new BaseRailElement.ObjectBaseEvents();      
        private bool pic1 = false;
        private bool pic2 = false;
        private bool pic3 = false;
        bool mouseIsDown = false;
        bool drapIsDown = false;
        Size drawregOrigSize = new Size();
        const int CONST_MULTI_FACTOR = 1;
        private int multiFactor = 1;
        private string sProjectPath = "";

        public RailDraw()
        {
            InitializeComponent();
            MyInit();
            Document=doc1;
            drawregOrigSize.Width = DrawRegion.Width;
            drawregOrigSize.Height = DrawRegion.Height;
        }

        private void MyInit()
        {
            // 设置Control的相关Style，主要与绘制有关
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ContainerControl |
                ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.UserMouse, true);       
        }

        protected static DrawDoc document = DrawDoc.EmptyDocument;
        public static DrawDoc Document
        {
            get { return document; }
            set { document = value; BaseEvents.Document = value; }
        }

        [DllImport("user32")]
        private static extern IntPtr LoadCursorFromFile(string fileName);

        #region 拖放图元
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && !drapIsDown)
            {
                Size dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(
                    new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                CreatCursor("draw");
                pic1 = true;               
            }
            else if (drapIsDown)
            {
                this.Cursor = System.Windows.Forms.Cursors.No;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (pic1)
            {
                PictureBox pic = sender as PictureBox;
                Point pt_new_e = PicPtTrans(sender, e);
                if (0 < pt_new_e.X && DrawRegion.Size.Width > pt_new_e.X && 0 < pt_new_e.Y && DrawRegion.Size.Height > pt_new_e.Y)
                {
                    BaseRailElement.StraightRailEle strRailEle = new BaseRailElement.StraightRailEle();
                    Point pt = new Point(pt_new_e.X, pt_new_e.Y);
                    doc1.DrawObjectList.Add(strRailEle.CreatEle(pt, DrawRegion.Size, multiFactor));
                    doc1.SelectOne(strRailEle);
                    DrawRegion.Invalidate();
                    propertyGrid1.SelectedObject = strRailEle;
                    propertyGrid1.Invalidate();
                }               
                pic1 = false;
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && !drapIsDown)
            {
                Size dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(
                    new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                CreatCursor("draw");
                pic2 = true;
            }
            else if (drapIsDown)
            {
                this.Cursor = System.Windows.Forms.Cursors.No;
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (pic2)
            {
                PictureBox pic = sender as PictureBox;
                Point pt_new_e = PicPtTrans(sender, e);
                if (0 < pt_new_e.X && DrawRegion.Size.Width > pt_new_e.X && 0 < pt_new_e.Y && DrawRegion.Size.Height > pt_new_e.Y)
                {
                    BaseRailElement.CurvedRailEle CurveRailEle = new BaseRailElement.CurvedRailEle();
                    Point pt = new Point(pt_new_e.X, pt_new_e.Y);
                    doc1.DrawObjectList.Add(CurveRailEle.CreatEle(pt, DrawRegion.Size, multiFactor));
                    doc1.SelectOne(CurveRailEle);
                    DrawRegion.Invalidate();
                    propertyGrid1.SelectedObject = CurveRailEle;
                    propertyGrid1.Invalidate();
                }               
                pic2 = false;
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && !drapIsDown)
            {
                Size dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(
                    new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                CreatCursor("draw");
                pic3 = true;
            }
            else if (drapIsDown)
            {
                this.Cursor = System.Windows.Forms.Cursors.No;
            }
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (pic3)
            {
                PictureBox pic = sender as PictureBox;
                Point pt_new_e = PicPtTrans(sender, e);
                if (0 < pt_new_e.X && DrawRegion.Size.Width > pt_new_e.X && 0 < pt_new_e.Y && DrawRegion.Size.Height > pt_new_e.Y)
                {
                    BaseRailElement.CrossEle crossLeft = new CrossEle();
                    Point pt = new Point(pt_new_e.X, pt_new_e.Y);
                    doc1.DrawObjectList.Add(crossLeft.CreatEle(pt, DrawRegion.Size, multiFactor));
                    doc1.SelectOne(crossLeft);
                    DrawRegion.Invalidate();
                    propertyGrid1.SelectedObject = crossLeft;
                    propertyGrid1.Invalidate();
                }
                this.Cursor = System.Windows.Forms.Cursors.Default;
                pic3 = false;
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        #endregion

        #region 画图板鼠标操作
        private void DrawRegion_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = e.Location;
            switch (e.Button)
            {
                case MouseButtons.Left:                    
                    objectEvent.OnLButtonDown(pt);
                    mouseIsDown = true;
                    break;
            }
            this.DrawRegion.Invalidate();
        }

        private void DrawRegion_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = e.Location;
            if (mouseIsDown && !drapIsDown)
            {
                objectEvent.OnMouseMove(pt);                    
                this.DrawRegion.Invalidate();
            }
        }

        private void DrawRegion_MouseUp(object sender, MouseEventArgs e)
        {
            Point pt = e.Location;
            if (mouseIsDown)
                mouseIsDown = false;
            if (drapIsDown)
            {
                Point pt_offset = objectEvent.DrapDrawRegion(pt);
                DrawRegion.Location = new Point(DrawRegion.Location.X + pt_offset.X, DrawRegion.Location.Y + pt_offset.Y);
                drapIsDown = true;
            }
            objectEvent.OnLButtonUp(pt);
            this.DrawRegion.Invalidate();
        }

        private void DrawRegion_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (document.SelectedDrawObjectList.Count > 0)              
                {
                    BaseRailEle _BaseRaiEle = document.SelectedDrawObjectList[0];
                    propertyGrid1.SelectedObject = _BaseRaiEle;
                    propertyGrid1.Refresh();
                }
                else
                {
                    propertyGrid1.SelectedObject = document;
                    propertyGrid1.Refresh();                    
                }
            }
        }

        private void DrawRegion_MouseEnter(object sender, EventArgs e)
        {
            if (drapIsDown)
            {
                CreatCursor("drap");
            }
        }

        private void DrawRegion_MouseLeave(object sender, EventArgs e)
        {
            if (drapIsDown)
                this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void DrawRegion_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            doc1.Draw(e.Graphics);
            g.ResetTransform();
            base.OnPaint(e);
        }
        #endregion

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
            //            new_btn_Click(null, null);
            System.Environment.Exit(0);
        }

        private void menuChooseAll_Click(object sender, EventArgs e)
        {
            document.SelectedDrawObjectList.Clear();
            if (document.DrawObjectList.Count > 0)
            {
                foreach (BaseRailEle o in document.DrawObjectList)
                    document.SelectedDrawObjectList.Add(o);
            }
            DrawRegion.Invalidate();
        }

        private void menupercentone_Click(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.ToolStripMenuItem)
            {
                System.Windows.Forms.ToolStripMenuItem item = (System.Windows.Forms.ToolStripMenuItem)sender;
                System.Windows.Forms.ToolStrip parent = item.GetCurrentParent();
                int i = parent.Items.IndexOf(item);
                int multi = i + 1;
                DrawRegion.Width = drawregOrigSize.Width * multi;
                DrawRegion.Height = drawregOrigSize.Height * multi;
                EnlargeAndShortenCanvas(multi);
            }
        }
        #endregion

        #region 工具栏操作
        private void new_btn_Click(object sender, EventArgs e)
        {
            if (doc1.DrawObjectList.Count > 0)
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
                        document.DrawObjectList.Clear();
                        DrawRegion.Invalidate();
                        break;
                    case DialogResult.No:
                        document.DrawObjectList.Clear();
                        DrawRegion.Invalidate();
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
                Document = doc1;
                doc1.DrawObjectList.Clear();
                DrawRegion.Top = 0;
                DrawRegion.Left = 0;
                DrawRegion.Width = drawregOrigSize.Width;
                DrawRegion.Height = drawregOrigSize.Height;
                drapIsDown = false;
                this.Cursor = System.Windows.Forms.Cursors.Default;
                try
                {
                    FileStream fs = new FileStream(projectpath, FileMode.Open);
                    XmlSerializer mySerializer = new XmlSerializer(typeof(DrawDoc));
                    doc1 = (DrawDoc)mySerializer.Deserialize(fs);
                    fs.Close();
                    Document = doc1;
                }
                catch
                {
                    MessageBox.Show("open error");
                }
            }
            DrawRegion.Invalidate();
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
                    XmlSerializer mySerializer = new XmlSerializer(typeof(DrawDoc));
                    StreamWriter myWriter = new StreamWriter(projectpath);
                    mySerializer.Serialize(myWriter, doc1);
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
            doc1.Cut();
            DrawRegion.Invalidate();
        }

        private void copy_Click(object sender, EventArgs e)
        {
            doc1.Copy();
            DrawRegion.Invalidate();
        }

        private void paste_Click(object sender, EventArgs e)
        {
            doc1.Paste();
            DrawRegion.Invalidate();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            doc1.Delete();
            DrawRegion.Invalidate();
        }

        private void enlarge_Click(object sender, EventArgs e)
        {
            if (DrawRegion.Width < drawregOrigSize.Width * 4)
            {
                DrawRegion.Width += (drawregOrigSize.Width * CONST_MULTI_FACTOR);
                DrawRegion.Height += (drawregOrigSize.Height * CONST_MULTI_FACTOR);
                multiFactor = DrawRegion.Width / drawregOrigSize.Width;
                document.DrawMultiFactor = multiFactor;
                int n = document.DrawObjectList.Count;
                for (int i = 0; i < n; i++)
                {
                    document.DrawObjectList[i].DrawMultiFactor = multiFactor;
                }
                ChangeDrawRegionLoction();
                DrawRegion.Invalidate();
            }
        }

        private void shorten_Click(object sender, EventArgs e)
        {
            if (DrawRegion.Width > drawregOrigSize.Width)
            {
                DrawRegion.Width -= (drawregOrigSize.Width * CONST_MULTI_FACTOR);
                DrawRegion.Height -= (drawregOrigSize.Height * CONST_MULTI_FACTOR);
                multiFactor = DrawRegion.Width / drawregOrigSize.Width;
                document.DrawMultiFactor = multiFactor;
                int n = document.DrawObjectList.Count;
                for (int i = 0; i < n; i++)
                    document.DrawObjectList[i].DrawMultiFactor = multiFactor;
                DrawRegion.Invalidate();
                ChangeDrawRegionLoction();
            }
        }

        private void counter_clw_Click(object sender, EventArgs e)
        {
            if (document.SelectedDrawObjectList.Count > 0)
            {
                document.SelectedDrawObjectList[0].RotateCounterClw();
                DrawRegion.Invalidate();
                propertyGrid1.Refresh();
            }          
        }

        private void clw_Click(object sender, EventArgs e)
        {
            if (document.SelectedDrawObjectList.Count > 0)
            {
                document.SelectedDrawObjectList[0].RotateClw();
                DrawRegion.Invalidate();
                propertyGrid1.Refresh();
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
            if (Document.SelectedDrawObjectList.Count > 0)
            {
                Document.SelectedDrawObjectList[0].ObjectMirror();
                DrawRegion.Invalidate();
            }
        }

        private void addtext_Click(object sender, EventArgs e)
        {
            BaseRailElement.RailLabal railLalal = new RailLabal();
            document.DrawObjectList.Add(railLalal.CreatEle(multiFactor));
            DrawRegion.Invalidate();
        }
        #endregion        
        
        public Point PicPtTrans(object sender, MouseEventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            Point pt_original = pic.Location;
            Point pt_new = e.Location;
            Point pt_parent = pic.Parent.Location;
            Point pt_dr = DrawRegion.Parent.Location;
            Point pt_transform = new Point(pt_new.X + pt_original.X + pt_parent.X - DrawRegion.Location.X - pt_dr.X,
                pt_new.Y + pt_original.Y + pt_parent.Y - DrawRegion.Location.Y - pt_dr.Y);
            return pt_transform;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            objectEvent.ChangePropertyValue();
            DrawRegion.Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Point form_size = (Point)this.ClientSize;
            Point panel_1_location = panel1.Location;
            Point panel_2_location = panel2.Location;
            Point propertygrid_location = propertyGrid1.Location;
            Point panel_1_size = new Point(panel1.Width, panel1.Height);
            Point panel_2_size = new Point(panel2.Width, panel2.Height);
            Point propertygrid_size = new Point(propertyGrid1.Width, propertyGrid1.Height);

            panel_1_size.Y = form_size.Y - menuStrip1.Height - toolStrip1.Height - 20;
            panel_2_size.X = form_size.X - panel_1_size.X - propertygrid_size.X - 30;
            panel_2_size.Y = panel_1_size.Y;
            propertygrid_size.Y = panel_1_size.Y;
            //set location
            propertyGrid1.Left = panel_2_location.X + panel_2_size.X + 10;
            //set size
            panel1.Height = panel_1_size.Y;
            panel2.Width = panel_2_size.X;
            panel2.Height = panel_2_size.Y;
            propertyGrid1.Height = propertygrid_size.Y;
            ChangeDrawRegionLoction();
        }

        private void SaveFile(SaveFileDialog sFile)
        {
            if (sFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string projectpath = sFile.FileName;
                    sProjectPath = projectpath;
                    XmlSerializer mySerializer = new XmlSerializer(typeof(DrawDoc));
                    StreamWriter myWriter = new StreamWriter(projectpath);
                    mySerializer.Serialize(myWriter, doc1);
                    myWriter.Close();
                }
                catch
                {
                    MessageBox.Show("save error");
                }
            }
        }

        private void CreatCursor(string str)
        {
            byte[] cursorbuffer;
            FileStream fs;
            switch (str)
            {
                    
                case "drap":
                    cursorbuffer = RailDraw.Properties.Resources.drap;
                    fs = new FileStream("temp_cur.dat", FileMode.Create);
                    fs.Write(cursorbuffer, 0, cursorbuffer.Length);
                    fs.Close();
                    break;
                case "draw":
                    cursorbuffer = RailDraw.Properties.Resources.draw;
                    fs = new FileStream("temp_cur.dat", FileMode.Create);
                    fs.Write(cursorbuffer, 0, cursorbuffer.Length);
                    fs.Close();
                    break;
            }          
            Cursor a = new Cursor(LoadCursorFromFile("temp_cur.dat"));
            File.Delete("temp_cur.dat");
            this.Cursor = a;
        }

        private void ChangeDrawRegionLoction()
        {
            Point drawRegionLoc = Point.Empty;
            Point drawRegionSize = (Point)DrawRegion.Size;
            Point panel2Size = (Point)panel2.Size;
            Point centerDrawRegion = new Point(drawRegionSize.X / 2, drawRegionSize.Y / 2);
            Point centerPanel = new Point(panel2Size.X / 2, panel2Size.Y / 2);
            int dx = centerPanel.X - centerDrawRegion.X;
            int dy = centerPanel.Y - centerDrawRegion.Y;
            drawRegionLoc.Offset(dx, dy);
            DrawRegion.Location = drawRegionLoc;
        }

        private void EnlargeAndShortenCanvas(int drawMulti)
        {
            int n = document.DrawObjectList.Count;
            for (int i = 0; i < n; i++)
                document.DrawObjectList[i].DrawMultiFactor = drawMulti;
            DrawRegion.Invalidate();
            ChangeDrawRegionLoction();
        }
    }
}
