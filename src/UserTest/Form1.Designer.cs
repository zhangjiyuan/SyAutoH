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
            this.bnNewUser = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNewUser = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonPlaceFoup = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLocType = new System.Windows.Forms.TextBox();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonPickFoup = new System.Windows.Forms.Button();
            this.buttonGetFoupID = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxFoupID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFoupName = new System.Windows.Forms.TextBox();
            this.textBoxPWagain = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.labelHashUser.Location = new System.Drawing.Point(542, 9);
            this.labelHashUser.Name = "labelHashUser";
            this.labelHashUser.Size = new System.Drawing.Size(59, 12);
            this.labelHashUser.TabIndex = 6;
            this.labelHashUser.Text = "Hash Info";
            // 
            // bnNewUser
            // 
            this.bnNewUser.Location = new System.Drawing.Point(198, 6);
            this.bnNewUser.Name = "bnNewUser";
            this.bnNewUser.Size = new System.Drawing.Size(75, 23);
            this.bnNewUser.TabIndex = 7;
            this.bnNewUser.Text = "Create";
            this.bnNewUser.UseVisualStyleBackColor = true;
            this.bnNewUser.Click += new System.EventHandler(this.bnNewUser_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(511, 299);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxPWagain);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.textBoxNewPassword);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBoxNewUser);
            this.tabPage1.Controls.Add(this.bnNewUser);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(503, 273);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User Management";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(68, 33);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '*';
            this.textBoxNewPassword.Size = new System.Drawing.Size(124, 21);
            this.textBoxNewPassword.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "User:";
            // 
            // textBoxNewUser
            // 
            this.textBoxNewUser.Location = new System.Drawing.Point(68, 6);
            this.textBoxNewUser.Name = "textBoxNewUser";
            this.textBoxNewUser.Size = new System.Drawing.Size(124, 21);
            this.textBoxNewUser.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonPlaceFoup);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.textBoxLocType);
            this.tabPage2.Controls.Add(this.textBoxLocation);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.buttonPickFoup);
            this.tabPage2.Controls.Add(this.buttonGetFoupID);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBoxFoupID);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBoxFoupName);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(503, 273);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MES Simulator";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonPlaceFoup
            // 
            this.buttonPlaceFoup.Location = new System.Drawing.Point(179, 96);
            this.buttonPlaceFoup.Name = "buttonPlaceFoup";
            this.buttonPlaceFoup.Size = new System.Drawing.Size(75, 23);
            this.buttonPlaceFoup.TabIndex = 10;
            this.buttonPlaceFoup.Text = "Place Foup";
            this.buttonPlaceFoup.UseVisualStyleBackColor = true;
            this.buttonPlaceFoup.Click += new System.EventHandler(this.buttonPlaceFoup_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(159, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "LocType:";
            // 
            // textBoxLocType
            // 
            this.textBoxLocType.Location = new System.Drawing.Point(218, 60);
            this.textBoxLocType.Name = "textBoxLocType";
            this.textBoxLocType.Size = new System.Drawing.Size(82, 21);
            this.textBoxLocType.TabIndex = 8;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(73, 60);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(69, 21);
            this.textBoxLocation.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "Location:";
            // 
            // buttonPickFoup
            // 
            this.buttonPickFoup.Location = new System.Drawing.Point(73, 96);
            this.buttonPickFoup.Name = "buttonPickFoup";
            this.buttonPickFoup.Size = new System.Drawing.Size(75, 23);
            this.buttonPickFoup.TabIndex = 5;
            this.buttonPickFoup.Text = "Pick Foup";
            this.buttonPickFoup.UseVisualStyleBackColor = true;
            this.buttonPickFoup.Click += new System.EventHandler(this.buttonPickFoup_Click);
            // 
            // buttonGetFoupID
            // 
            this.buttonGetFoupID.Location = new System.Drawing.Point(179, 6);
            this.buttonGetFoupID.Name = "buttonGetFoupID";
            this.buttonGetFoupID.Size = new System.Drawing.Size(75, 23);
            this.buttonGetFoupID.TabIndex = 4;
            this.buttonGetFoupID.Text = "Get FoupID";
            this.buttonGetFoupID.UseVisualStyleBackColor = true;
            this.buttonGetFoupID.Click += new System.EventHandler(this.buttonGetFoupID_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "FoupID:";
            // 
            // textBoxFoupID
            // 
            this.textBoxFoupID.Location = new System.Drawing.Point(73, 33);
            this.textBoxFoupID.Name = "textBoxFoupID";
            this.textBoxFoupID.Size = new System.Drawing.Size(100, 21);
            this.textBoxFoupID.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "FoupName:";
            // 
            // textBoxFoupName
            // 
            this.textBoxFoupName.Location = new System.Drawing.Point(73, 6);
            this.textBoxFoupName.Name = "textBoxFoupName";
            this.textBoxFoupName.Size = new System.Drawing.Size(100, 21);
            this.textBoxFoupName.TabIndex = 0;
            // 
            // textBoxPWagain
            // 
            this.textBoxPWagain.Location = new System.Drawing.Point(68, 60);
            this.textBoxPWagain.Name = "textBoxPWagain";
            this.textBoxPWagain.PasswordChar = '*';
            this.textBoxPWagain.Size = new System.Drawing.Size(124, 21);
            this.textBoxPWagain.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "PW again:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 344);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelHashUser);
            this.Controls.Add(this.bnLogout);
            this.Controls.Add(this.bnLogin);
            this.Controls.Add(this.maskedTextBoxPW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.Button bnNewUser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNewUser;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Button buttonPlaceFoup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxLocType;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonPickFoup;
        private System.Windows.Forms.Button buttonGetFoupID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxFoupID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFoupName;
        private System.Windows.Forms.TextBox textBoxPWagain;
        private System.Windows.Forms.Label label9;
    }
}

