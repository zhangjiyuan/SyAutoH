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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("在线车辆");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("以分配队列");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("报警");
            this.baseInfoTreeView = new System.Windows.Forms.TreeView();
            this.showRegion = new System.Windows.Forms.Panel();
            this.showPic = new System.Windows.Forms.PictureBox();
            this.systemStatues = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRegion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showPic)).BeginInit();
            this.systemStatues.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseInfoTreeView
            // 
            this.baseInfoTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.baseInfoTreeView.Location = new System.Drawing.Point(12, 28);
            this.baseInfoTreeView.Name = "baseInfoTreeView";
            treeNode1.Name = "CarsOnline";
            treeNode1.Text = "在线车辆";
            treeNode2.Name = "QueueAssign";
            treeNode2.Text = "以分配队列";
            treeNode3.Name = "Alarm";
            treeNode3.Text = "报警";
            this.baseInfoTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.baseInfoTreeView.Size = new System.Drawing.Size(109, 502);
            this.baseInfoTreeView.TabIndex = 0;
            // 
            // showRegion
            // 
            this.showRegion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.showRegion.Controls.Add(this.showPic);
            this.showRegion.Location = new System.Drawing.Point(127, 28);
            this.showRegion.Name = "showRegion";
            this.showRegion.Size = new System.Drawing.Size(600, 400);
            this.showRegion.TabIndex = 1;
            // 
            // showPic
            // 
            this.showPic.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.showPic.Location = new System.Drawing.Point(0, 0);
            this.showPic.Name = "showPic";
            this.showPic.Size = new System.Drawing.Size(600, 400);
            this.showPic.TabIndex = 0;
            this.showPic.TabStop = false;
            this.showPic.Paint += new System.Windows.Forms.PaintEventHandler(this.showPic_Paint);
            // 
            // systemStatues
            // 
            this.systemStatues.Controls.Add(this.tabPage1);
            this.systemStatues.Controls.Add(this.tabPage2);
            this.systemStatues.Location = new System.Drawing.Point(129, 430);
            this.systemStatues.Name = "systemStatues";
            this.systemStatues.SelectedIndex = 0;
            this.systemStatues.Size = new System.Drawing.Size(600, 100);
            this.systemStatues.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(592, 74);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(661, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(738, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(738, 540);
            this.Controls.Add(this.systemStatues);
            this.Controls.Add(this.showRegion);
            this.Controls.Add(this.baseInfoTreeView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "RailView";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.showRegion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showPic)).EndInit();
            this.systemStatues.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private TreeView baseInfoTreeView;
        private Panel showRegion;
        private PictureBox showPic;
        private TabControl systemStatues;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
    }
}