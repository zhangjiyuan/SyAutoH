namespace UserTest
{
    partial class FormUserPassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOldPW = new System.Windows.Forms.TextBox();
            this.textBoxNewPW = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPWAgain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "User:";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(78, 10);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.ReadOnly = true;
            this.textBoxUserName.Size = new System.Drawing.Size(165, 21);
            this.textBoxUserName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Old PW:";
            // 
            // textBoxOldPW
            // 
            this.textBoxOldPW.Location = new System.Drawing.Point(78, 45);
            this.textBoxOldPW.Name = "textBoxOldPW";
            this.textBoxOldPW.PasswordChar = '*';
            this.textBoxOldPW.Size = new System.Drawing.Size(165, 21);
            this.textBoxOldPW.TabIndex = 3;
            // 
            // textBoxNewPW
            // 
            this.textBoxNewPW.Location = new System.Drawing.Point(78, 72);
            this.textBoxNewPW.Name = "textBoxNewPW";
            this.textBoxNewPW.PasswordChar = '*';
            this.textBoxNewPW.Size = new System.Drawing.Size(165, 21);
            this.textBoxNewPW.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "New PW:";
            // 
            // textBoxPWAgain
            // 
            this.textBoxPWAgain.Location = new System.Drawing.Point(78, 99);
            this.textBoxPWAgain.Name = "textBoxPWAgain";
            this.textBoxPWAgain.PasswordChar = '*';
            this.textBoxPWAgain.Size = new System.Drawing.Size(165, 21);
            this.textBoxPWAgain.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "PW again:";
            // 
            // bnCancel
            // 
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(78, 138);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 32);
            this.bnCancel.TabIndex = 8;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // bnAccept
            // 
            this.bnAccept.Location = new System.Drawing.Point(168, 138);
            this.bnAccept.Name = "bnAccept";
            this.bnAccept.Size = new System.Drawing.Size(75, 32);
            this.bnAccept.TabIndex = 9;
            this.bnAccept.Text = "Accept";
            this.bnAccept.UseVisualStyleBackColor = true;
            this.bnAccept.Click += new System.EventHandler(this.bnAccept_Click);
            // 
            // FormUserPassword
            // 
            this.AcceptButton = this.bnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(258, 179);
            this.Controls.Add(this.bnAccept);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.textBoxPWAgain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNewPW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxOldPW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label1);
            this.Name = "FormUserPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOldPW;
        private System.Windows.Forms.TextBox textBoxNewPW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPWAgain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnAccept;
    }
}