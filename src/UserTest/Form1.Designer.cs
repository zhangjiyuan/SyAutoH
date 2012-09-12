namespace UserTest
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
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBoxPW = new System.Windows.Forms.MaskedTextBox();
            this.bnLogin = new System.Windows.Forms.Button();
            this.bnLogout = new System.Windows.Forms.Button();
            this.labelHashUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(59, 6);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(124, 21);
            this.textBoxUser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // maskedTextBoxPW
            // 
            this.maskedTextBoxPW.Location = new System.Drawing.Point(254, 6);
            this.maskedTextBoxPW.Name = "maskedTextBoxPW";
            this.maskedTextBoxPW.PasswordChar = '*';
            this.maskedTextBoxPW.Size = new System.Drawing.Size(120, 21);
            this.maskedTextBoxPW.TabIndex = 3;
            // 
            // bnLogin
            // 
            this.bnLogin.Location = new System.Drawing.Point(380, 4);
            this.bnLogin.Name = "bnLogin";
            this.bnLogin.Size = new System.Drawing.Size(75, 23);
            this.bnLogin.TabIndex = 4;
            this.bnLogin.Text = "Login";
            this.bnLogin.UseVisualStyleBackColor = true;
            this.bnLogin.Click += new System.EventHandler(this.bnLogin_Click);
            // 
            // bnLogout
            // 
            this.bnLogout.Location = new System.Drawing.Point(461, 4);
            this.bnLogout.Name = "bnLogout";
            this.bnLogout.Size = new System.Drawing.Size(75, 23);
            this.bnLogout.TabIndex = 5;
            this.bnLogout.Text = "Logout";
            this.bnLogout.UseVisualStyleBackColor = true;
            // 
            // labelHashUser
            // 
            this.labelHashUser.AutoSize = true;
            this.labelHashUser.Location = new System.Drawing.Point(57, 30);
            this.labelHashUser.Name = "labelHashUser";
            this.labelHashUser.Size = new System.Drawing.Size(59, 12);
            this.labelHashUser.TabIndex = 6;
            this.labelHashUser.Text = "Hash Info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 344);
            this.Controls.Add(this.labelHashUser);
            this.Controls.Add(this.bnLogout);
            this.Controls.Add(this.bnLogin);
            this.Controls.Add(this.maskedTextBoxPW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPW;
        private System.Windows.Forms.Button bnLogin;
        private System.Windows.Forms.Button bnLogout;
        private System.Windows.Forms.Label labelHashUser;
    }
}

