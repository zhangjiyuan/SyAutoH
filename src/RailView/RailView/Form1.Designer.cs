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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemStatues1 = new RailView.SystemStatues();
            this.showRegion1 = new RailView.ShowRegion();
            this.baseInfoTreeView1 = new RailView.BaseInfoTreeView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // systemStatues1
            // 
            this.systemStatues1.Location = new System.Drawing.Point(176, 355);
            this.systemStatues1.Name = "systemStatues1";
            this.systemStatues1.Size = new System.Drawing.Size(400, 100);
            this.systemStatues1.TabIndex = 3;
            // 
            // showRegion1
            // 
            this.showRegion1.Location = new System.Drawing.Point(176, 25);
            this.showRegion1.Name = "showRegion1";
            this.showRegion1.Size = new System.Drawing.Size(500, 300);
            this.showRegion1.TabIndex = 2;
            // 
            // baseInfoTreeView1
            // 
            this.baseInfoTreeView1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.baseInfoTreeView1.Location = new System.Drawing.Point(0, 25);
            this.baseInfoTreeView1.Name = "baseInfoTreeView1";
            this.baseInfoTreeView1.Size = new System.Drawing.Size(170, 430);
            this.baseInfoTreeView1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(808, 497);
            this.Controls.Add(this.systemStatues1);
            this.Controls.Add(this.showRegion1);
            this.Controls.Add(this.baseInfoTreeView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "RailView";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private BaseInfoTreeView baseInfoTreeView1;
        private ShowRegion showRegion1;
        private SystemStatues systemStatues1;
    }
}