namespace UserTest
{
    partial class FormUserRight
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxUserRight = new System.Windows.Forms.ComboBox();
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnAccept = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxOldRight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "Right:";
            // 
            // comboBoxUserRight
            // 
            this.comboBoxUserRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserRight.FormattingEnabled = true;
            this.comboBoxUserRight.Items.AddRange(new object[] {
            "NoRight",
            "Viewer",
            "Guest",
            "Operator",
            "Admin",
            "SuperAdmin"});
            this.comboBoxUserRight.Location = new System.Drawing.Point(59, 86);
            this.comboBoxUserRight.Name = "comboBoxUserRight";
            this.comboBoxUserRight.Size = new System.Drawing.Size(165, 20);
            this.comboBoxUserRight.TabIndex = 18;
            // 
            // bnCancel
            // 
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(59, 131);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 34);
            this.bnCancel.TabIndex = 29;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnAccept
            // 
            this.bnAccept.Location = new System.Drawing.Point(149, 131);
            this.bnAccept.Name = "bnAccept";
            this.bnAccept.Size = new System.Drawing.Size(75, 34);
            this.bnAccept.TabIndex = 28;
            this.bnAccept.Text = "Accept";
            this.bnAccept.UseVisualStyleBackColor = true;
            this.bnAccept.Click += new System.EventHandler(this.bnAccept_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(59, 12);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.ReadOnly = true;
            this.textBoxUserName.Size = new System.Drawing.Size(165, 21);
            this.textBoxUserName.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "User:";
            // 
            // textBoxOldRight
            // 
            this.textBoxOldRight.Location = new System.Drawing.Point(59, 39);
            this.textBoxOldRight.Name = "textBoxOldRight";
            this.textBoxOldRight.ReadOnly = true;
            this.textBoxOldRight.Size = new System.Drawing.Size(165, 21);
            this.textBoxOldRight.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "Right:";
            // 
            // FormUserRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 178);
            this.Controls.Add(this.textBoxOldRight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnAccept);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxUserRight);
            this.Name = "FormUserRight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Right";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxUserRight;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnAccept;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxOldRight;
        private System.Windows.Forms.Label label2;
    }
}