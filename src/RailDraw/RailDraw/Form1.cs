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
    public partial class Form1 : Form
    {
        BaseRailElement.DrawDoc doc1 = new BaseRailElement.DrawDoc();
        BaseRailElement.ObjectBaseEvents _ObjectEvent = new BaseRailElement.ObjectBaseEvents();      
        private bool pic1 = false;
        private bool pic2 = false;
        private bool pic3 = false;
        private bool pic4 = false;
        Point _downpoint= Point.Empty;
        bool mouse_is_down = false;
        bool drap_is_down = false;
        Size drawreg_orig_size = new Size();
        const float const_multi_factor = 0.1f;
        private float multi_factor = 1;
        private string sProjectPath = "";

        public Form1()
        {
            InitializeComponent();
            MyInit();
            Document=doc1;
            drawreg_orig_size.Width = DrawRegion.Width;
            drawreg_orig_size.Height = DrawRegion.Height;
        }

        private void MyInit()
        {
            // 设置Control的相关Style，主要与绘制有关
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ContainerControl |
                ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.UserMouse, true);
            doc1.Name = "main";           
        }

        protected static DrawDoc _document = DrawDoc.EmptyDocument;
        public static DrawDoc Document
        {
            get { return _document; }
            set { _document = value; BaseEvents.Document = value; }
        }

        [DllImport("user32")]
        private static extern IntPtr LoadCursorFromFile(string fileName);

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && !drap_is_down)
            {
                Size dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                byte[] cursorbuffer = RailDraw.Properties.Resources.draw;
                FileStream fs = new FileStream("temp_cur.dat", FileMode.Create);
                fs.Write(cursorbuffer, 0, cursorbuffer.Length);
                fs.Close();
                Cursor a= new Cursor(LoadCursorFromFile("temp_cur.dat"));
                File.Delete("temp_cur.dat");
                this.Cursor = a;
                pic1 = true;               
            }
            else if (drap_is_down)
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
                    BaseRailElement.StraightRailEle _straightrailele = new BaseRailElement.StraightRailEle();
                    Point pt = new Point(pt_new_e.X, pt_new_e.Y);
                    doc1.DrawObjectList.Add(_straightrailele.CreatEle(pt, DrawRegion.Size, multi_factor));
                    doc1.Select(_straightrailele);
                    DrawRegion.Invalidate();
                    propertyGrid1.Invalidate();
                }               
                pic1 = false;
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && !drap_is_down)
            {
                Size dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                byte[] cursorbuffer = RailDraw.Properties.Resources.draw;
                FileStream fs = new FileStream("temp_cur.dat", FileMode.Create);
                fs.Write(cursorbuffer, 0, cursorbuffer.Length);
                fs.Close();
                Cursor a = new Cursor(LoadCursorFromFile("temp_cur.dat"));
                File.Delete("temp_cur.dat");
                this.Cursor = a;
                pic2 = true;
            }
            else if (drap_is_down)
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
                    BaseRailElement.CurvedRailEle _curverailele = new BaseRailElement.CurvedRailEle();
                    Point pt = new Point(pt_new_e.X, pt_new_e.Y);
                    doc1.DrawObjectList.Add(_curverailele.CreatEle(pt, DrawRegion.Size, multi_factor));
                    doc1.Select(_curverailele);
                    DrawRegion.Invalidate();
                    propertyGrid1.SelectedObject = _curverailele;
                    propertyGrid1.Invalidate();
                }               
                pic2 = false;
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && !drap_is_down)
            {
                Size dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                byte[] cursorbuffer = RailDraw.Properties.Resources.draw;
                FileStream fs = new FileStream("temp_cur.dat", FileMode.Create);
                fs.Write(cursorbuffer, 0, cursorbuffer.Length);
                fs.Close();
                Cursor a = new Cursor(LoadCursorFromFile("temp_cur.dat"));
                File.Delete("temp_cur.dat");
                this.Cursor = a;
                pic3 = true;
            }
            else if (drap_is_down)
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
                    BaseRailElement.CrossLeftEle _crossleft = new BaseRailElement.CrossLeftEle();
                    Point pt = new Point(pt_new_e.X, pt_new_e.Y);
                    doc1.DrawObjectList.Add(_crossleft.CreatEle(pt, DrawRegion.Size, multi_factor));
                    doc1.Select(_crossleft);
                    DrawRegion.Invalidate();
                    propertyGrid1.Invalidate();
                }
                this.Cursor = System.Windows.Forms.Cursors.Default;
                pic3 = false;
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Size dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                                   e.Y - (dragSize.Height / 2)), dragSize);
                pic4 = true;
            }
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            if (pic4)
            {
                PictureBox pic = sender as PictureBox;
                Point pt_new_e = PicPtTrans(sender, e);
                if (0 < pt_new_e.X && DrawRegion.Size.Width > pt_new_e.X && 0 < pt_new_e.Y && DrawRegion.Size.Height > pt_new_e.Y)
                {
                    BaseRailElement.CrossRightEle _crossright = new BaseRailElement.CrossRightEle();
                    Point pt = new Point(pt_new_e.X, pt_new_e.Y);
                    doc1.DrawObjectList.Add(_crossright.CreatEle(pt, DrawRegion.Size, multi_factor));
                    doc1.Select(_crossright);
                    DrawRegion.Invalidate();
                    propertyGrid1.Invalidate();
                }
                pic4 = false;
            }
        }
        
        private void DrawRegion_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = ClientToDrawregion(e.Location);
            switch (e.Button)
            {
                case MouseButtons.Left:                    
                    _ObjectEvent.OnLButtonDown(pt);
                    mouse_is_down = true;
                    break;
            }
            this.DrawRegion.Invalidate();
        }

        private void DrawRegion_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = ClientToDrawregion(e.Location);
            if (mouse_is_down && !drap_is_down)
            {
                _ObjectEvent.OnMouseMove(pt);                    
                this.DrawRegion.Invalidate();
            }
        }

        private void DrawRegion_MouseUp(object sender, MouseEventArgs e)
        {
            Point pt = ClientToDrawregion(e.Location);
            if (mouse_is_down)
                mouse_is_down = false;
            if (drap_is_down)
            {
                Point pt_offset = _ObjectEvent.DrapDrawRegion(pt);
                DrawRegion.Location = new Point(DrawRegion.Location.X + pt_offset.X, DrawRegion.Location.Y + pt_offset.Y);
                drap_is_down = true;
            }
        }

        private void DrawRegion_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs _DoubleClick = (MouseEventArgs)e;
            Point pt = ClientToDrawregion(_DoubleClick.Location);
            _ObjectEvent.OnMouseDoubleClick(pt, this.DrawRegion.Size);
            DrawRegion.Invalidate();
            propertyGrid1.Refresh();
        }

        private void DrawRegion_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_document.SelectedDrawObjectList.Count > 0)              
                {
                    BaseRailEle _BaseRaiEle = _document.SelectedDrawObjectList[0];
                    propertyGrid1.SelectedObject = _BaseRaiEle;
                    propertyGrid1.Refresh();
                }
                else
                {
                    propertyGrid1.SelectedObject = _document;
                    propertyGrid1.Refresh();                    
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

        private void counter_clw_Click(object sender, EventArgs e)
        {
            if (_document.SelectedDrawObjectList.Count > 0)
            {
                _document.SelectedDrawObjectList[0].RotateCounterClw();
                DrawRegion.Invalidate();
                propertyGrid1.Refresh();
            }          
        }

        private void clw_Click(object sender, EventArgs e)
        {
            if (_document.SelectedDrawObjectList.Count > 0)
            {
                _document.SelectedDrawObjectList[0].RotateClw();
                DrawRegion.Invalidate();
                propertyGrid1.Refresh();
            }
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
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string projectpath = saveFile.FileName;
                        sProjectPath = projectpath;
                        //save form
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

        private void enlarge_Click(object sender, EventArgs e)
        {
            if (DrawRegion.Width < drawreg_orig_size.Width * 2)
            {
                DrawRegion.Width += (int)(drawreg_orig_size.Width * const_multi_factor);
                DrawRegion.Height += (int)(drawreg_orig_size.Height * const_multi_factor);
                multi_factor = DrawRegion.Width / (float)drawreg_orig_size.Width;
                _document.Draw_Multi_Factor = multi_factor;
                int n = _document.DrawObjectList.Count;
                for (int i = 0; i < n; i++)
                {
                    _document.DrawObjectList[i].Draw_Multi_Factor = multi_factor;
                }
                DrawRegion.Invalidate();
            }
        }

        private void shorten_Click(object sender, EventArgs e)
        {
            if (DrawRegion.Width > drawreg_orig_size.Width)
            {
                DrawRegion.Width -= (int)(drawreg_orig_size.Width * const_multi_factor);
                DrawRegion.Height -= (int)(drawreg_orig_size.Height * const_multi_factor);
                multi_factor = DrawRegion.Width / (float)drawreg_orig_size.Width;
                _document.Draw_Multi_Factor = multi_factor;
                int n=_document.DrawObjectList.Count;
                for (int i = 0; i < n; i++)
                {
                    _document.DrawObjectList[i].Draw_Multi_Factor = multi_factor;
                }
                DrawRegion.Invalidate();
            }
        }

        public void ResizeCanvase()
        {
            int display_width = panel2.Width;
            int display_height = panel2.Height;
            int real_width = DrawRegion.Width;
            int real_height = DrawRegion.Height;
            int dw, dh, max_dw, max_dh;

            if (real_width > display_width)
            {
                dw = display_width - vScrollBar1.Width;
                dh = display_height - hScrollBar1.Height;
                max_dw = real_width - dw;
                max_dh = real_height - dh;

                hScrollBar1.Visible = true;
                hScrollBar1.Width = dw;
                hScrollBar1.Top = dh;
                hScrollBar1.Left = 0;
                hScrollBar1.Maximum = max_dw;
                hScrollBar1.LargeChange = max_dw / 5;
                hScrollBar1.SmallChange = max_dw / 20;

                vScrollBar1.Visible = true;
                vScrollBar1.Height = dh;
                vScrollBar1.Top = 0;
                vScrollBar1.Left = dw;
                vScrollBar1.Maximum = max_dh;
                vScrollBar1.LargeChange = max_dh / 5;
                vScrollBar1.SmallChange = max_dh / 20;
            }
            else
            {
                hScrollBar1.Visible = false;
                vScrollBar1.Visible = false;

                DrawRegion.Width = display_width;
                DrawRegion.Height = display_height;
            }
            DrawRegion.Invalidate();
        }

        public Point PicPtTrans(object sender, MouseEventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            Point pt_original = pic.Location;
            Point pt_new = e.Location;
            Point pt_parent = pic.Parent.Location;
            Point pt_dr = DrawRegion.Parent.Location;
            Point pt_transform = new Point(pt_new.X + pt_original.X + pt_parent.X - DrawRegion.Location.X - pt_dr.X,
                pt_new.Y + pt_original.Y + pt_parent.Y - DrawRegion.Location.Y - pt_dr.Y);
            pt_transform = ClientToDrawregion(pt_transform);
            return pt_transform;
        }

        public Point ClientToDrawregion(Point original_pt)
        {
            Point convert_pt = Point.Empty;
            convert_pt.X = original_pt.X + hScrollBar1.Value;
            convert_pt.Y = original_pt.Y + vScrollBar1.Value;
            return convert_pt;
        }

        private void DrawRegion_Paint(object sender, PaintEventArgs e)
        {
            int dx = hScrollBar1.Value;
            int dy = vScrollBar1.Value;
            Graphics g = e.Graphics;
            g.TranslateTransform(-dx, -dy);
            doc1.Draw(e.Graphics);
            g.ResetTransform();
            base.OnPaint(e);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            DrawRegion.Invalidate();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            DrawRegion.Invalidate();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _ObjectEvent.ChangePropertyValue();
            DrawRegion.Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Point form_size = new Point(this.Width, this.Height);
            Point panel_1_location = panel1.Location;
            Point panel_2_location = panel2.Location;
            Point propertygrid_location = propertyGrid1.Location;
            Point panel_1_size = new Point(panel1.Width, panel1.Height);
            Point panel_2_size = new Point(panel2.Width, panel2.Height);
            Point propertygrid_size = new Point(propertyGrid1.Width, propertyGrid1.Height);
            int left_border = panel_1_location.X;
            int right_border = left_border;
            int top_border = panel_1_location.Y + SystemInformation.CaptionHeight;
            int bottom_border = panel_1_location.Y;

            //set location var
            propertygrid_location.X = form_size.X - propertygrid_size.X - right_border-20;
                ;
            //set size var
            panel_1_size.Y = form_size.Y - top_border - bottom_border;
            panel_2_size.X = propertygrid_location.X - panel_2_location.X - 10;
            panel_2_size.Y = panel_1_size.Y;
            propertygrid_size.Y = panel_1_size.Y;
            //set location
            propertyGrid1.Left = propertygrid_location.X;
            //set size
            panel1.Height = panel_1_size.Y;
            panel2.Width = panel_2_size.X;
            panel2.Height = panel_2_size.Y;
            propertyGrid1.Height = propertygrid_size.Y;
        }

        private void drap_Click(object sender, EventArgs e)
        {
            drap_is_down = true;
        }

        private void mouse_Click(object sender, EventArgs e)
        {
            drap_is_down = false;
            this.Cursor = System.Windows.Forms.Cursors.Default; 
        }


        private void DrawRegion_MouseEnter(object sender, EventArgs e)
        {
            if (drap_is_down)
            {
                byte[] cursorbuffer = RailDraw.Properties.Resources.drap;
                FileStream fs = new FileStream("temp_cur.dat", FileMode.Create);
                fs.Write(cursorbuffer, 0, cursorbuffer.Length);
                fs.Close();
                Cursor a = new Cursor(LoadCursorFromFile("temp_cur.dat"));
                File.Delete("temp_cur.dat");
                this.Cursor = a;
            }
 
        }

        private void DrawRegion_MouseLeave(object sender, EventArgs e)
        {
            if (drap_is_down)
                this.Cursor = System.Windows.Forms.Cursors.Default;
        }
    }
}
