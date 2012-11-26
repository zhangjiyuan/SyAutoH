namespace OptsRightsEdit
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleRight = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Add_Row = new System.Windows.Forms.Button();
            this.Delete_Row = new System.Windows.Forms.Button();
            this.Save_Data = new System.Windows.Forms.Button();
            this.rightInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OPT,
            this.MODE,
            this.RoleRight});
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(348, 317);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // OPT
            // 
            this.OPT.HeaderText = "OPT";
            this.OPT.Name = "OPT";
            // 
            // MODE
            // 
            this.MODE.HeaderText = "MODE";
            this.MODE.Name = "MODE";
            // 
            // RoleRight
            // 
            this.RoleRight.DataPropertyName = "ID";
            this.RoleRight.HeaderText = "RoleRight";
            this.RoleRight.Name = "RoleRight";
            this.RoleRight.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RoleRight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Add_Row
            // 
            this.Add_Row.Location = new System.Drawing.Point(390, 40);
            this.Add_Row.Name = "Add_Row";
            this.Add_Row.Size = new System.Drawing.Size(101, 35);
            this.Add_Row.TabIndex = 1;
            this.Add_Row.Text = "添加新行";
            this.Add_Row.UseVisualStyleBackColor = true;
            this.Add_Row.Click += new System.EventHandler(this.Add_Row_Click);
            // 
            // Delete_Row
            // 
            this.Delete_Row.Location = new System.Drawing.Point(390, 177);
            this.Delete_Row.Name = "Delete_Row";
            this.Delete_Row.Size = new System.Drawing.Size(101, 35);
            this.Delete_Row.TabIndex = 2;
            this.Delete_Row.Text = "删除行信息";
            this.Delete_Row.UseVisualStyleBackColor = true;
            this.Delete_Row.Click += new System.EventHandler(this.Delete_Row_Click);
            // 
            // Save_Data
            // 
            this.Save_Data.Location = new System.Drawing.Point(390, 322);
            this.Save_Data.Name = "Save_Data";
            this.Save_Data.Size = new System.Drawing.Size(101, 35);
            this.Save_Data.TabIndex = 3;
            this.Save_Data.Text = "保存数据";
            this.Save_Data.UseVisualStyleBackColor = true;
            this.Save_Data.Click += new System.EventHandler(this.Save_Data_Click);
            // 
            // rightInfoBindingSource
            // 
            this.rightInfoBindingSource.DataMember = "RightInfo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "OptsRights Edit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 404);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save_Data);
            this.Controls.Add(this.Delete_Row);
            this.Controls.Add(this.Add_Row);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Add_Row;
        private System.Windows.Forms.Button Delete_Row;
        private System.Windows.Forms.Button Save_Data;
        private System.Windows.Forms.BindingSource rightInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODE;
        private System.Windows.Forms.DataGridViewComboBoxColumn RoleRight;
        private System.Windows.Forms.Label label1;
    }
}

