using System.Drawing;
using System.Windows.Forms;
namespace RailView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ContextMenuStrip baseInfoMenu;
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("GEM Communcation:");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("GEM Control:");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("MCS System Status:");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("MCS Availabilty:");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Test Mode:");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Queued:");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Waitting:");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Transfering:");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Paused:");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Canceling:");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Aborting:");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Transfer Count:", new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33});
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Auto Transfer Executable:");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Transfering:");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Stage:");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Maintenance:");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("OFF-LINE:");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Removed:");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("OHT Count:", new System.Windows.Forms.TreeNode[] {
            treeNode35,
            treeNode36,
            treeNode37,
            treeNode38,
            treeNode39,
            treeNode40});
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("ZCU Count:");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Error:");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Fork Count:", new System.Windows.Forms.TreeNode[] {
            treeNode43});
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.systemStatues = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.baseInfoTreeView = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.showPic = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            baseInfoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip1.SuspendLayout();
            this.systemStatues.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showPic)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseInfoMenu
            // 
            baseInfoMenu.Name = "baseInfoMenu";
            baseInfoMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 718);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(924, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel2.Text = "Ready";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // systemStatues
            // 
            this.systemStatues.Controls.Add(this.tabPage1);
            this.systemStatues.Controls.Add(this.tabPage2);
            this.systemStatues.Controls.Add(this.tabPage3);
            this.systemStatues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemStatues.Location = new System.Drawing.Point(0, 0);
            this.systemStatues.Name = "systemStatues";
            this.systemStatues.SelectedIndex = 0;
            this.systemStatues.Size = new System.Drawing.Size(756, 240);
            this.systemStatues.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(748, 214);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Transfer Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(742, 208);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Transfer Status";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Carrier ID";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Carrier Status";
            this.columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "OHT Command Status";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Source";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Destination";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Recipt Time";
            this.columnHeader7.Width = 80;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(748, 214);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "OHT Status";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(748, 214);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Equipment Status";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // baseInfoTreeView
            // 
            this.baseInfoTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.baseInfoTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.baseInfoTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseInfoTreeView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseInfoTreeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.baseInfoTreeView.Location = new System.Drawing.Point(0, 0);
            this.baseInfoTreeView.Name = "baseInfoTreeView";
            treeNode23.Name = "GEM Communcation:";
            treeNode23.Text = "GEM Communcation:";
            treeNode24.Name = "GEM Control:";
            treeNode24.Tag = "ONLINE";
            treeNode24.Text = "GEM Control:";
            treeNode25.Name = "MCS System Status:";
            treeNode25.Text = "MCS System Status:";
            treeNode26.Name = "节点0";
            treeNode26.Text = "MCS Availabilty:";
            treeNode27.Name = "Test Mode:";
            treeNode27.Text = "Test Mode:";
            treeNode28.Name = "Queued:";
            treeNode28.Text = "Queued:";
            treeNode29.Name = "Waitting:";
            treeNode29.Text = "Waitting:";
            treeNode30.Name = "Transfering:";
            treeNode30.Text = "Transfering:";
            treeNode31.Name = "Paused:";
            treeNode31.Text = "Paused:";
            treeNode32.Name = "Canceling:";
            treeNode32.Text = "Canceling:";
            treeNode33.Name = "Aborting:";
            treeNode33.Text = "Aborting:";
            treeNode34.Name = "Transfer Count:";
            treeNode34.Text = "Transfer Count:";
            treeNode35.Name = "Auto Transfer Executable:";
            treeNode35.Text = "Auto Transfer Executable:";
            treeNode36.Name = "Transfering:";
            treeNode36.Text = "Transfering:";
            treeNode37.Name = "Stage:";
            treeNode37.Text = "Stage:";
            treeNode38.Name = "Maintenance:";
            treeNode38.Text = "Maintenance:";
            treeNode39.Name = "OFF-LINE:";
            treeNode39.Text = "OFF-LINE:";
            treeNode40.Name = "Removed:";
            treeNode40.Text = "Removed:";
            treeNode41.Name = "OHT Count:";
            treeNode41.Text = "OHT Count:";
            treeNode42.Name = "ZCU Count:";
            treeNode42.Text = "ZCU Count:";
            treeNode43.Name = "Error:";
            treeNode43.Text = "Error:";
            treeNode44.Name = "Fork Count:";
            treeNode44.Text = "Fork Count:";
            this.baseInfoTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode34,
            treeNode41,
            treeNode42,
            treeNode44});
            this.baseInfoTreeView.Size = new System.Drawing.Size(160, 691);
            this.baseInfoTreeView.TabIndex = 0;
            this.baseInfoTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.baseInfoTreeView_MouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.baseInfoTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(924, 693);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.showPic);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.systemStatues);
            this.splitContainer2.Size = new System.Drawing.Size(758, 693);
            this.splitContainer2.SplitterDistance = 447;
            this.splitContainer2.TabIndex = 0;
            // 
            // showPic
            // 
            this.showPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.showPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showPic.Location = new System.Drawing.Point(0, 0);
            this.showPic.Name = "showPic";
            this.showPic.Size = new System.Drawing.Size(756, 445);
            this.showPic.TabIndex = 0;
            this.showPic.TabStop = false;
            this.showPic.Paint += new System.Windows.Forms.PaintEventHandler(this.showPic_Paint);
            this.showPic.Resize += new System.EventHandler(this.showPic_Resize);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click_1);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.screenToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // screenToolStripMenuItem
            // 
            this.screenToolStripMenuItem.Image = global::RailView.Properties.Resources.full_screen2;
            this.screenToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.screenToolStripMenuItem.Name = "screenToolStripMenuItem";
            this.screenToolStripMenuItem.Size = new System.Drawing.Size(148, 32);
            this.screenToolStripMenuItem.Text = "Full Screen";
            this.screenToolStripMenuItem.Click += new System.EventHandler(this.screenToolStripMenuItem_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(924, 740);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RailView";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.systemStatues.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showPic)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private PictureBox showPic;
        private TabControl systemStatues;
        private TabPage tabPage1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TreeView baseInfoTreeView;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem screenToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel2;
    }
}