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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("GEM Communcation:");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("GEM Control:");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("MCS System Status:");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("MCS Availabilty:");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Test Mode:");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Queued:");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Waitting:");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Transfering:");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Paused:");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Canceling:");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Aborting:");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Transfer Count:", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Auto Transfer Executable:");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Transfering:");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Stage:");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Maintenance:");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("OFF-LINE:");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Removed:");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("OHT Count:", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("ZCU Count:");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Error:");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Fork Count:", new System.Windows.Forms.TreeNode[] {
            treeNode21});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.showRegion = new System.Windows.Forms.Panel();
            this.showPic = new System.Windows.Forms.PictureBox();
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
            baseInfoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.showRegion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showPic)).BeginInit();
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
            this.SuspendLayout();
            // 
            // baseInfoMenu
            // 
            baseInfoMenu.Name = "contextMenuStrip1";
            baseInfoMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
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
            // showRegion
            // 
            this.showRegion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.showRegion.Controls.Add(this.showPic);
            this.showRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showRegion.Location = new System.Drawing.Point(0, 0);
            this.showRegion.Name = "showRegion";
            this.showRegion.Size = new System.Drawing.Size(756, 446);
            this.showRegion.TabIndex = 1;
            // 
            // showPic
            // 
            this.showPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.showPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showPic.Location = new System.Drawing.Point(0, 0);
            this.showPic.Name = "showPic";
            this.showPic.Size = new System.Drawing.Size(752, 442);
            this.showPic.TabIndex = 0;
            this.showPic.TabStop = false;
            this.showPic.Paint += new System.Windows.Forms.PaintEventHandler(this.showPic_Paint);
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
            this.systemStatues.Size = new System.Drawing.Size(756, 239);
            this.systemStatues.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(748, 213);
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
            this.listView1.Size = new System.Drawing.Size(742, 207);
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
            this.tabPage2.Size = new System.Drawing.Size(748, 213);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "OHT Status";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(748, 213);
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
            treeNode1.Name = "GEM Communcation:";
            treeNode1.Text = "GEM Communcation:";
            treeNode2.Name = "GEM Control:";
            treeNode2.Tag = "ONLINE";
            treeNode2.Text = "GEM Control:";
            treeNode3.Name = "MCS System Status:";
            treeNode3.Text = "MCS System Status:";
            treeNode4.Name = "节点0";
            treeNode4.Text = "MCS Availabilty:";
            treeNode5.Name = "Test Mode:";
            treeNode5.Text = "Test Mode:";
            treeNode6.Name = "Queued:";
            treeNode6.Text = "Queued:";
            treeNode7.Name = "Waitting:";
            treeNode7.Text = "Waitting:";
            treeNode8.Name = "Transfering:";
            treeNode8.Text = "Transfering:";
            treeNode9.Name = "Paused:";
            treeNode9.Text = "Paused:";
            treeNode10.Name = "Canceling:";
            treeNode10.Text = "Canceling:";
            treeNode11.Name = "Aborting:";
            treeNode11.Text = "Aborting:";
            treeNode12.Name = "Transfer Count:";
            treeNode12.Text = "Transfer Count:";
            treeNode13.Name = "Auto Transfer Executable:";
            treeNode13.Text = "Auto Transfer Executable:";
            treeNode14.Name = "Transfering:";
            treeNode14.Text = "Transfering:";
            treeNode15.Name = "Stage:";
            treeNode15.Text = "Stage:";
            treeNode16.Name = "Maintenance:";
            treeNode16.Text = "Maintenance:";
            treeNode17.Name = "OFF-LINE:";
            treeNode17.Text = "OFF-LINE:";
            treeNode18.Name = "Removed:";
            treeNode18.Text = "Removed:";
            treeNode19.Name = "OHT Count:";
            treeNode19.Text = "OHT Count:";
            treeNode20.Name = "ZCU Count:";
            treeNode20.Text = "ZCU Count:";
            treeNode21.Name = "Error:";
            treeNode21.Text = "Error:";
            treeNode22.Name = "Fork Count:";
            treeNode22.Text = "Fork Count:";
            this.baseInfoTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode12,
            treeNode19,
            treeNode20,
            treeNode22});
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
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.showRegion);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.systemStatues);
            this.splitContainer2.Size = new System.Drawing.Size(758, 693);
            this.splitContainer2.SplitterDistance = 448;
            this.splitContainer2.TabIndex = 0;
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.showRegion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showPic)).EndInit();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Panel showRegion;
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
    }
}