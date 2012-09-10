using System.Drawing;
using System.Windows.Forms;

namespace RailDraw
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.new_btn = new System.Windows.Forms.ToolStripButton();
            this.open = new System.Windows.Forms.ToolStripButton();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cut = new System.Windows.Forms.ToolStripButton();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.paste = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.enlarge = new System.Windows.Forms.ToolStripButton();
            this.shorten = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.counter_clw = new System.Windows.Forms.ToolStripButton();
            this.clw = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.drap = new System.Windows.Forms.ToolStripButton();
            this.mouse = new System.Windows.Forms.ToolStripButton();
            this.mirror = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.addtext = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.DrawRegion = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChooseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuScale = new System.Windows.Forms.ToolStripMenuItem();
            this.menupercentone = new System.Windows.Forms.ToolStripMenuItem();
            this.menupercenttwo = new System.Windows.Forms.ToolStripMenuItem();
            this.menupercentthree = new System.Windows.Forms.ToolStripMenuItem();
            this.menupercentfour = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRegion)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.new_btn,
            this.open,
            this.save,
            this.toolStripSeparator1,
            this.cut,
            this.copy,
            this.paste,
            this.delete,
            this.toolStripSeparator2,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripSeparator3,
            this.enlarge,
            this.shorten,
            this.toolStripSeparator4,
            this.counter_clw,
            this.clw,
            this.toolStripSeparator5,
            this.drap,
            this.mouse,
            this.mirror,
            this.toolStripSeparator6,
            this.addtext});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(808, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // new_btn
            // 
            this.new_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.new_btn.Image = ((System.Drawing.Image)(resources.GetObject("new_btn.Image")));
            this.new_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(23, 22);
            this.new_btn.Text = "new";
            this.new_btn.Click += new System.EventHandler(this.new_btn_Click);
            // 
            // open
            // 
            this.open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.open.Image = ((System.Drawing.Image)(resources.GetObject("open.Image")));
            this.open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(23, 22);
            this.open.Text = "open";
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // save
            // 
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save.Image = ((System.Drawing.Image)(resources.GetObject("save.Image")));
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 22);
            this.save.Text = "save";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cut
            // 
            this.cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cut.Image = ((System.Drawing.Image)(resources.GetObject("cut.Image")));
            this.cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cut.Name = "cut";
            this.cut.Size = new System.Drawing.Size(23, 22);
            this.cut.Text = "cut";
            this.cut.Click += new System.EventHandler(this.cut_Click);
            // 
            // copy
            // 
            this.copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copy.Image = ((System.Drawing.Image)(resources.GetObject("copy.Image")));
            this.copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(23, 22);
            this.copy.Text = "copy";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // paste
            // 
            this.paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.paste.Image = ((System.Drawing.Image)(resources.GetObject("paste.Image")));
            this.paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(23, 22);
            this.paste.Text = "paste";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // delete
            // 
            this.delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delete.Image = ((System.Drawing.Image)(resources.GetObject("delete.Image")));
            this.delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.Text = "delete";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Enabled = false;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "revocation";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Enabled = false;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "regain";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // enlarge
            // 
            this.enlarge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.enlarge.Image = ((System.Drawing.Image)(resources.GetObject("enlarge.Image")));
            this.enlarge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.enlarge.Name = "enlarge";
            this.enlarge.Size = new System.Drawing.Size(23, 22);
            this.enlarge.Text = "enlarge";
            this.enlarge.Click += new System.EventHandler(this.enlarge_Click);
            // 
            // shorten
            // 
            this.shorten.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.shorten.Image = ((System.Drawing.Image)(resources.GetObject("shorten.Image")));
            this.shorten.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.shorten.Name = "shorten";
            this.shorten.Size = new System.Drawing.Size(23, 22);
            this.shorten.Text = "shorten";
            this.shorten.Click += new System.EventHandler(this.shorten_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // counter_clw
            // 
            this.counter_clw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.counter_clw.Image = ((System.Drawing.Image)(resources.GetObject("counter_clw.Image")));
            this.counter_clw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.counter_clw.Name = "counter_clw";
            this.counter_clw.Size = new System.Drawing.Size(23, 22);
            this.counter_clw.Text = "counter_clw";
            this.counter_clw.Click += new System.EventHandler(this.counter_clw_Click);
            // 
            // clw
            // 
            this.clw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clw.Image = ((System.Drawing.Image)(resources.GetObject("clw.Image")));
            this.clw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clw.Name = "clw";
            this.clw.Size = new System.Drawing.Size(23, 22);
            this.clw.Text = "clw";
            this.clw.Click += new System.EventHandler(this.clw_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // drap
            // 
            this.drap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drap.Image = ((System.Drawing.Image)(resources.GetObject("drap.Image")));
            this.drap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drap.Name = "drap";
            this.drap.Size = new System.Drawing.Size(23, 22);
            this.drap.Text = "drap";
            this.drap.Click += new System.EventHandler(this.drap_Click);
            // 
            // mouse
            // 
            this.mouse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mouse.Image = ((System.Drawing.Image)(resources.GetObject("mouse.Image")));
            this.mouse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mouse.Name = "mouse";
            this.mouse.Size = new System.Drawing.Size(23, 22);
            this.mouse.Text = "mouse";
            this.mouse.ToolTipText = "mouse";
            this.mouse.Click += new System.EventHandler(this.mouse_Click);
            // 
            // mirror
            // 
            this.mirror.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mirror.Image = ((System.Drawing.Image)(resources.GetObject("mirror.Image")));
            this.mirror.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mirror.Name = "mirror";
            this.mirror.Size = new System.Drawing.Size(23, 22);
            this.mirror.Text = "mirror";
            this.mirror.Click += new System.EventHandler(this.mirror_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // addtext
            // 
            this.addtext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addtext.Image = ((System.Drawing.Image)(resources.GetObject("addtext.Image")));
            this.addtext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addtext.Name = "addtext";
            this.addtext.Size = new System.Drawing.Size(23, 22);
            this.addtext.Text = "addtext";
            this.addtext.Click += new System.EventHandler(this.addtext_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(7, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(47, 384);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "叉轨";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "弯轨";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(6, 120);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseDown);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 64);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "直轨";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(655, 52);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(130, 385);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // DrawRegion
            // 
            this.DrawRegion.BackColor = System.Drawing.SystemColors.Control;
            this.DrawRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawRegion.Location = new System.Drawing.Point(-2, -2);
            this.DrawRegion.Name = "DrawRegion";
            this.DrawRegion.Size = new System.Drawing.Size(600, 400);
            this.DrawRegion.TabIndex = 2;
            this.DrawRegion.TabStop = false;
            this.DrawRegion.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawRegion_Paint);
            this.DrawRegion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawRegion_MouseClick);
            this.DrawRegion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawRegion_MouseDown);
            this.DrawRegion.MouseEnter += new System.EventHandler(this.DrawRegion_MouseEnter);
            this.DrawRegion.MouseLeave += new System.EventHandler(this.DrawRegion_MouseLeave);
            this.DrawRegion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawRegion_MouseMove);
            this.DrawRegion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawRegion_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.DrawRegion);
            this.panel2.Location = new System.Drawing.Point(60, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 385);
            this.panel2.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuView,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuOpen,
            this.menuSave,
            this.menuSaveAs,
            this.menuClose});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(39, 21);
            this.menuFile.Text = "File";
            // 
            // menuNew
            // 
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(120, 22);
            this.menuNew.Text = "New";
            this.menuNew.Click += new System.EventHandler(this.new_btn_Click);
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(120, 22);
            this.menuOpen.Text = "Open";
            this.menuOpen.Click += new System.EventHandler(this.open_Click);
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.Size = new System.Drawing.Size(120, 22);
            this.menuSave.Text = "Save";
            this.menuSave.Click += new System.EventHandler(this.save_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(120, 22);
            this.menuSaveAs.Text = "Save as";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuClose
            // 
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(120, 22);
            this.menuClose.Text = "Close";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCut,
            this.menuCopy,
            this.menuPaste,
            this.menuDelete,
            this.menuChooseAll});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(42, 21);
            this.menuEdit.Text = "Edit";
            // 
            // menuCut
            // 
            this.menuCut.Name = "menuCut";
            this.menuCut.Size = new System.Drawing.Size(113, 22);
            this.menuCut.Text = "Cut";
            this.menuCut.Click += new System.EventHandler(this.cut_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(113, 22);
            this.menuCopy.Text = "Copy";
            this.menuCopy.Click += new System.EventHandler(this.copy_Click);
            // 
            // menuPaste
            // 
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.Size = new System.Drawing.Size(113, 22);
            this.menuPaste.Text = "Paste";
            this.menuPaste.Click += new System.EventHandler(this.paste_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(113, 22);
            this.menuDelete.Text = "Delete";
            this.menuDelete.Click += new System.EventHandler(this.delete_Click);
            // 
            // menuChooseAll
            // 
            this.menuChooseAll.Name = "menuChooseAll";
            this.menuChooseAll.Size = new System.Drawing.Size(113, 22);
            this.menuChooseAll.Text = "All";
            this.menuChooseAll.Click += new System.EventHandler(this.menuChooseAll_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuScale});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(47, 21);
            this.menuView.Text = "View";
            // 
            // menuScale
            // 
            this.menuScale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menupercentone,
            this.menupercenttwo,
            this.menupercentthree,
            this.menupercentfour});
            this.menuScale.Name = "menuScale";
            this.menuScale.Size = new System.Drawing.Size(106, 22);
            this.menuScale.Text = "Scale";
            // 
            // menupercentone
            // 
            this.menupercentone.Name = "menupercentone";
            this.menupercentone.Size = new System.Drawing.Size(108, 22);
            this.menupercentone.Text = "100%";
            this.menupercentone.Click += new System.EventHandler(this.menupercentone_Click);
            // 
            // menupercenttwo
            // 
            this.menupercenttwo.Name = "menupercenttwo";
            this.menupercenttwo.Size = new System.Drawing.Size(108, 22);
            this.menupercenttwo.Text = "200%";
            this.menupercenttwo.Click += new System.EventHandler(this.menupercentone_Click);
            // 
            // menupercentthree
            // 
            this.menupercentthree.Name = "menupercentthree";
            this.menupercentthree.Size = new System.Drawing.Size(108, 22);
            this.menupercentthree.Text = "300%";
            this.menupercentthree.Click += new System.EventHandler(this.menupercentone_Click);
            // 
            // menupercentfour
            // 
            this.menupercentfour.Name = "menupercentfour";
            this.menupercentfour.Size = new System.Drawing.Size(108, 22);
            this.menupercentfour.Text = "400%";
            this.menupercentfour.Click += new System.EventHandler(this.menupercentone_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(47, 21);
            this.menuHelp.Text = "Help";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 457);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "RailDraw";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRegion)).EndInit();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton open;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cut;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton enlarge;
        private System.Windows.Forms.ToolStripButton shorten;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Rectangle dragBoxFromMouseDown;
        private PictureBox DrawRegion;
        private Panel panel2;
        private ToolStripButton counter_clw;
        private ToolStripButton clw;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton drap;
        private ToolStripButton mouse;
        private ToolStripButton new_btn;
        private ToolStripButton mirror;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton addtext;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuNew;
        private ToolStripMenuItem menuOpen;
        private ToolStripMenuItem menuSave;
        private ToolStripMenuItem menuSaveAs;
        private ToolStripMenuItem menuClose;
        private ToolStripMenuItem menuEdit;
        private ToolStripMenuItem menuCut;
        private ToolStripMenuItem menuCopy;
        private ToolStripMenuItem menuPaste;
        private ToolStripMenuItem menuDelete;
        private ToolStripMenuItem menuChooseAll;
        private ToolStripMenuItem menuView;
        private ToolStripMenuItem menuHelp;
        private ToolStripMenuItem menuScale;
        private ToolStripMenuItem menupercentone;
        private ToolStripMenuItem menupercenttwo;
        private ToolStripMenuItem menupercentthree;
        private ToolStripMenuItem menupercentfour;
    }
}

