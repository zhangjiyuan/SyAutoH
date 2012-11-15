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
            System.Windows.Forms.TreeNode treeNode155 = new System.Windows.Forms.TreeNode("GEM Communcation:");
            System.Windows.Forms.TreeNode treeNode156 = new System.Windows.Forms.TreeNode("GEM Control:");
            System.Windows.Forms.TreeNode treeNode157 = new System.Windows.Forms.TreeNode("MCS System Status:");
            System.Windows.Forms.TreeNode treeNode158 = new System.Windows.Forms.TreeNode("MCS Availabilty:");
            System.Windows.Forms.TreeNode treeNode159 = new System.Windows.Forms.TreeNode("Test Mode:");
            System.Windows.Forms.TreeNode treeNode160 = new System.Windows.Forms.TreeNode("Queued:");
            System.Windows.Forms.TreeNode treeNode161 = new System.Windows.Forms.TreeNode("Waitting:");
            System.Windows.Forms.TreeNode treeNode162 = new System.Windows.Forms.TreeNode("Transfering:");
            System.Windows.Forms.TreeNode treeNode163 = new System.Windows.Forms.TreeNode("Paused:");
            System.Windows.Forms.TreeNode treeNode164 = new System.Windows.Forms.TreeNode("Canceling:");
            System.Windows.Forms.TreeNode treeNode165 = new System.Windows.Forms.TreeNode("Aborting:");
            System.Windows.Forms.TreeNode treeNode166 = new System.Windows.Forms.TreeNode("Transfer Count:", new System.Windows.Forms.TreeNode[] {
            treeNode160,
            treeNode161,
            treeNode162,
            treeNode163,
            treeNode164,
            treeNode165});
            System.Windows.Forms.TreeNode treeNode167 = new System.Windows.Forms.TreeNode("Auto Transfer Executable:");
            System.Windows.Forms.TreeNode treeNode168 = new System.Windows.Forms.TreeNode("Transfering:");
            System.Windows.Forms.TreeNode treeNode169 = new System.Windows.Forms.TreeNode("Stage:");
            System.Windows.Forms.TreeNode treeNode170 = new System.Windows.Forms.TreeNode("Maintenance:");
            System.Windows.Forms.TreeNode treeNode171 = new System.Windows.Forms.TreeNode("OFF-LINE:");
            System.Windows.Forms.TreeNode treeNode172 = new System.Windows.Forms.TreeNode("Removed:");
            System.Windows.Forms.TreeNode treeNode173 = new System.Windows.Forms.TreeNode("OHT Count:", new System.Windows.Forms.TreeNode[] {
            treeNode167,
            treeNode168,
            treeNode169,
            treeNode170,
            treeNode171,
            treeNode172});
            System.Windows.Forms.TreeNode treeNode174 = new System.Windows.Forms.TreeNode("ZCU Count:");
            System.Windows.Forms.TreeNode treeNode175 = new System.Windows.Forms.TreeNode("Error:");
            System.Windows.Forms.TreeNode treeNode176 = new System.Windows.Forms.TreeNode("Fork Count:", new System.Windows.Forms.TreeNode[] {
            treeNode175});
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
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
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            baseInfoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 718);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(924, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
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
            this.tabPage2.Size = new System.Drawing.Size(748, 222);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "OHT Status";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(748, 222);
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
            treeNode155.Name = "GEM Communcation:";
            treeNode155.Text = "GEM Communcation:";
            treeNode156.Name = "GEM Control:";
            treeNode156.Tag = "ONLINE";
            treeNode156.Text = "GEM Control:";
            treeNode157.Name = "MCS System Status:";
            treeNode157.Text = "MCS System Status:";
            treeNode158.Name = "节点0";
            treeNode158.Text = "MCS Availabilty:";
            treeNode159.Name = "Test Mode:";
            treeNode159.Text = "Test Mode:";
            treeNode160.Name = "Queued:";
            treeNode160.Text = "Queued:";
            treeNode161.Name = "Waitting:";
            treeNode161.Text = "Waitting:";
            treeNode162.Name = "Transfering:";
            treeNode162.Text = "Transfering:";
            treeNode163.Name = "Paused:";
            treeNode163.Text = "Paused:";
            treeNode164.Name = "Canceling:";
            treeNode164.Text = "Canceling:";
            treeNode165.Name = "Aborting:";
            treeNode165.Text = "Aborting:";
            treeNode166.Name = "Transfer Count:";
            treeNode166.Text = "Transfer Count:";
            treeNode167.Name = "Auto Transfer Executable:";
            treeNode167.Text = "Auto Transfer Executable:";
            treeNode168.Name = "Transfering:";
            treeNode168.Text = "Transfering:";
            treeNode169.Name = "Stage:";
            treeNode169.Text = "Stage:";
            treeNode170.Name = "Maintenance:";
            treeNode170.Text = "Maintenance:";
            treeNode171.Name = "OFF-LINE:";
            treeNode171.Text = "OFF-LINE:";
            treeNode172.Name = "Removed:";
            treeNode172.Text = "Removed:";
            treeNode173.Name = "OHT Count:";
            treeNode173.Text = "OHT Count:";
            treeNode174.Name = "ZCU Count:";
            treeNode174.Text = "ZCU Count:";
            treeNode175.Name = "Error:";
            treeNode175.Text = "Error:";
            treeNode176.Name = "Fork Count:";
            treeNode176.Text = "Fork Count:";
            this.baseInfoTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode155,
            treeNode156,
            treeNode157,
            treeNode158,
            treeNode159,
            treeNode166,
            treeNode173,
            treeNode174,
            treeNode176});
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
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.screenToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click_1);
            // 
            // screenToolStripMenuItem
            // 
            this.screenToolStripMenuItem.Image = global::RailView.Properties.Resources.full_screen2;
            this.screenToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.screenToolStripMenuItem.Name = "screenToolStripMenuItem";
            this.screenToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
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
    }
}