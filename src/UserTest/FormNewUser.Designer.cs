namespace UserTest
{
    partial class FormNewUser
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
            this.textBoxPWagain = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNewUser = new System.Windows.Forms.TextBox();
            this.bnAccept = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 25;
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
            this.comboBoxUserRight.Location = new System.Drawing.Point(75, 93);
            this.comboBoxUserRight.Name = "comboBoxUserRight";
            this.comboBoxUserRight.Size = new System.Drawing.Size(166, 20);
            this.comboBoxUserRight.TabIndex = 24;
            // 
            // textBoxPWagain
            // 
            this.textBoxPWagain.Location = new System.Drawing.Point(75, 66);
            this.textBoxPWagain.Name = "textBoxPWagain";
            this.textBoxPWagain.PasswordChar = '*';
            this.textBoxPWagain.Size = new System.Drawing.Size(166, 21);
            this.textBoxPWagain.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "PW again:";
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(75, 39);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '*';
            this.textBoxNewPassword.Size = new System.Drawing.Size(166, 21);
            this.textBoxNewPassword.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "Name:";
            // 
            // textBoxNewUser
            // 
            this.textBoxNewUser.Location = new System.Drawing.Point(75, 12);
            this.textBoxNewUser.Name = "textBoxNewUser";
            this.textBoxNewUser.Size = new System.Drawing.Size(166, 21);
            this.textBoxNewUser.TabIndex = 18;
            // 
            // bnAccept
            // 
            this.bnAccept.Location = new System.Drawing.Point(75, 146);
            this.bnAccept.Name = "bnAccept";
            this.bnAccept.Size = new System.Drawing.Size(75, 34);
            this.bnAccept.TabIndex = 26;
            this.bnAccept.Text = "Accept";
            this.bnAccept.UseVisualStyleBackColor = true;
            this.bnAccept.Click += new System.EventHandler(this.bnAccept_Click);
            // 
            // bnCancel
            // 
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(166, 146);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 34);
            this.bnCancel.TabIndex = 27;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // FormNewUser
            // 
            this.AcceptButton = this.bnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(255, 192);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnAccept);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxUserRight);
            this.Controls.Add(this.textBoxPWagain);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNewUser);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewUser";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxUserRight;
        private System.Windows.Forms.TextBox textBoxPWagain;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNewUser;
        private System.Windows.Forms.Button bnAccept;
        private System.Windows.Forms.Button bnCancel;
    }
}