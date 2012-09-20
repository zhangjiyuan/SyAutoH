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
            this.bnNewUser = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUser = new System.Windows.Forms.TabPage();
            this.buttonUserGet = new System.Windows.Forms.Button();
            this.buttonUserPW = new System.Windows.Forms.Button();
            this.buttonUserRight = new System.Windows.Forms.Button();
            this.buttonUserDelete = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxUserRight = new System.Windows.Forms.ComboBox();
            this.listViewUserList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxPWagain = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNewUser = new System.Windows.Forms.TextBox();
            this.tabPageMES = new System.Windows.Forms.TabPage();
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
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.labelHashUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBoxPW = new System.Windows.Forms.MaskedTextBox();
            this.bnLogout = new System.Windows.Forms.Button();
            this.bnLogin = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageUser.SuspendLayout();
            this.tabPageMES.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnNewUser
            // 
            this.bnNewUser.Location = new System.Drawing.Point(303, 27);
            this.bnNewUser.Name = "bnNewUser";
            this.bnNewUser.Size = new System.Drawing.Size(124, 23);
            this.bnNewUser.TabIndex = 7;
            this.bnNewUser.Text = "New User";
            this.bnNewUser.UseVisualStyleBackColor = true;
            this.bnNewUser.Click += new System.EventHandler(this.bnNewUser_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLogin);
            this.tabControl1.Controls.Add(this.tabPageUser);
            this.tabControl1.Controls.Add(this.tabPageMES);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(519, 454);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageUser
            // 
            this.tabPageUser.Controls.Add(this.label11);
            this.tabPageUser.Controls.Add(this.buttonUserGet);
            this.tabPageUser.Controls.Add(this.buttonUserPW);
            this.tabPageUser.Controls.Add(this.buttonUserRight);
            this.tabPageUser.Controls.Add(this.buttonUserDelete);
            this.tabPageUser.Controls.Add(this.label10);
            this.tabPageUser.Controls.Add(this.comboBoxUserRight);
            this.tabPageUser.Controls.Add(this.listViewUserList);
            this.tabPageUser.Controls.Add(this.textBoxPWagain);
            this.tabPageUser.Controls.Add(this.label9);
            this.tabPageUser.Controls.Add(this.textBoxNewPassword);
            this.tabPageUser.Controls.Add(this.label3);
            this.tabPageUser.Controls.Add(this.label4);
            this.tabPageUser.Controls.Add(this.textBoxNewUser);
            this.tabPageUser.Controls.Add(this.bnNewUser);
            this.tabPageUser.Location = new System.Drawing.Point(4, 22);
            this.tabPageUser.Name = "tabPageUser";
            this.tabPageUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUser.Size = new System.Drawing.Size(511, 428);
            this.tabPageUser.TabIndex = 0;
            this.tabPageUser.Text = "User Management";
            this.tabPageUser.UseVisualStyleBackColor = true;
            // 
            // buttonUserGet
            // 
            this.buttonUserGet.Location = new System.Drawing.Point(303, 184);
            this.buttonUserGet.Name = "buttonUserGet";
            this.buttonUserGet.Size = new System.Drawing.Size(124, 23);
            this.buttonUserGet.TabIndex = 21;
            this.buttonUserGet.Text = "Get User List";
            this.buttonUserGet.UseVisualStyleBackColor = true;
            this.buttonUserGet.Click += new System.EventHandler(this.buttonUserGet_Click);
            // 
            // buttonUserPW
            // 
            this.buttonUserPW.Location = new System.Drawing.Point(303, 143);
            this.buttonUserPW.Name = "buttonUserPW";
            this.buttonUserPW.Size = new System.Drawing.Size(124, 23);
            this.buttonUserPW.TabIndex = 20;
            this.buttonUserPW.Text = "Set Password";
            this.buttonUserPW.UseVisualStyleBackColor = true;
            this.buttonUserPW.Click += new System.EventHandler(this.buttonUserPW_Click);
            // 
            // buttonUserRight
            // 
            this.buttonUserRight.Location = new System.Drawing.Point(303, 104);
            this.buttonUserRight.Name = "buttonUserRight";
            this.buttonUserRight.Size = new System.Drawing.Size(124, 23);
            this.buttonUserRight.TabIndex = 19;
            this.buttonUserRight.Text = "Set Right";
            this.buttonUserRight.UseVisualStyleBackColor = true;
            this.buttonUserRight.Click += new System.EventHandler(this.buttonUserRight_Click);
            // 
            // buttonUserDelete
            // 
            this.buttonUserDelete.Location = new System.Drawing.Point(303, 65);
            this.buttonUserDelete.Name = "buttonUserDelete";
            this.buttonUserDelete.Size = new System.Drawing.Size(124, 23);
            this.buttonUserDelete.TabIndex = 18;
            this.buttonUserDelete.Text = "Delete";
            this.buttonUserDelete.UseVisualStyleBackColor = true;
            this.buttonUserDelete.Click += new System.EventHandler(this.buttonUserDelete_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 375);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "Right:";
            // 
            // comboBoxUserRight
            // 
            this.comboBoxUserRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserRight.FormattingEnabled = true;
            this.comboBoxUserRight.Items.AddRange(new object[] {
            "Viewer",
            "Guest",
            "Operator",
            "Admin",
            "SAdmin"});
            this.comboBoxUserRight.Location = new System.Drawing.Point(335, 372);
            this.comboBoxUserRight.Name = "comboBoxUserRight";
            this.comboBoxUserRight.Size = new System.Drawing.Size(121, 20);
            this.comboBoxUserRight.TabIndex = 16;
            // 
            // listViewUserList
            // 
            this.listViewUserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewUserList.FullRowSelect = true;
            this.listViewUserList.GridLines = true;
            this.listViewUserList.HideSelection = false;
            this.listViewUserList.Location = new System.Drawing.Point(8, 27);
            this.listViewUserList.Name = "listViewUserList";
            this.listViewUserList.Size = new System.Drawing.Size(243, 393);
            this.listViewUserList.TabIndex = 15;
            this.listViewUserList.UseCompatibleStateImageBehavior = false;
            this.listViewUserList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Right";
            // 
            // textBoxPWagain
            // 
            this.textBoxPWagain.Location = new System.Drawing.Point(335, 345);
            this.textBoxPWagain.Name = "textBoxPWagain";
            this.textBoxPWagain.PasswordChar = '*';
            this.textBoxPWagain.Size = new System.Drawing.Size(124, 21);
            this.textBoxPWagain.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(273, 348);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "PW again:";
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(335, 318);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '*';
            this.textBoxNewPassword.Size = new System.Drawing.Size(124, 21);
            this.textBoxNewPassword.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "User:";
            // 
            // textBoxNewUser
            // 
            this.textBoxNewUser.Location = new System.Drawing.Point(335, 291);
            this.textBoxNewUser.Name = "textBoxNewUser";
            this.textBoxNewUser.Size = new System.Drawing.Size(124, 21);
            this.textBoxNewUser.TabIndex = 8;
            // 
            // tabPageMES
            // 
            this.tabPageMES.Controls.Add(this.buttonPlaceFoup);
            this.tabPageMES.Controls.Add(this.label8);
            this.tabPageMES.Controls.Add(this.textBoxLocType);
            this.tabPageMES.Controls.Add(this.textBoxLocation);
            this.tabPageMES.Controls.Add(this.label7);
            this.tabPageMES.Controls.Add(this.buttonPickFoup);
            this.tabPageMES.Controls.Add(this.buttonGetFoupID);
            this.tabPageMES.Controls.Add(this.label6);
            this.tabPageMES.Controls.Add(this.textBoxFoupID);
            this.tabPageMES.Controls.Add(this.label5);
            this.tabPageMES.Controls.Add(this.textBoxFoupName);
            this.tabPageMES.Location = new System.Drawing.Point(4, 22);
            this.tabPageMES.Name = "tabPageMES";
            this.tabPageMES.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMES.Size = new System.Drawing.Size(511, 428);
            this.tabPageMES.TabIndex = 1;
            this.tabPageMES.Text = "MES Simulator";
            this.tabPageMES.UseVisualStyleBackColor = true;
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
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.groupBox1);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Size = new System.Drawing.Size(511, 428);
            this.tabPageLogin.TabIndex = 2;
            this.tabPageLogin.Text = "Login";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxUser);
            this.groupBox1.Controls.Add(this.labelHashUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.maskedTextBoxPW);
            this.groupBox1.Controls.Add(this.bnLogout);
            this.groupBox1.Controls.Add(this.bnLogin);
            this.groupBox1.Location = new System.Drawing.Point(76, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 140);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login / Logout";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "User:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(79, 20);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(124, 21);
            this.textBoxUser.TabIndex = 0;
            // 
            // labelHashUser
            // 
            this.labelHashUser.AutoSize = true;
            this.labelHashUser.Location = new System.Drawing.Point(77, 99);
            this.labelHashUser.Name = "labelHashUser";
            this.labelHashUser.Size = new System.Drawing.Size(59, 12);
            this.labelHashUser.TabIndex = 6;
            this.labelHashUser.Text = "Hash Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // maskedTextBoxPW
            // 
            this.maskedTextBoxPW.Location = new System.Drawing.Point(79, 53);
            this.maskedTextBoxPW.Name = "maskedTextBoxPW";
            this.maskedTextBoxPW.PasswordChar = '*';
            this.maskedTextBoxPW.Size = new System.Drawing.Size(124, 21);
            this.maskedTextBoxPW.TabIndex = 3;
            // 
            // bnLogout
            // 
            this.bnLogout.Location = new System.Drawing.Point(231, 56);
            this.bnLogout.Name = "bnLogout";
            this.bnLogout.Size = new System.Drawing.Size(75, 23);
            this.bnLogout.TabIndex = 5;
            this.bnLogout.Text = "Logout";
            this.bnLogout.UseVisualStyleBackColor = true;
            this.bnLogout.Click += new System.EventHandler(this.bnLogout_Click);
            // 
            // bnLogin
            // 
            this.bnLogin.Location = new System.Drawing.Point(231, 20);
            this.bnLogin.Name = "bnLogin";
            this.bnLogin.Size = new System.Drawing.Size(75, 23);
            this.bnLogin.TabIndex = 4;
            this.bnLogin.Text = "Login";
            this.bnLogin.UseVisualStyleBackColor = true;
            this.bnLogin.Click += new System.EventHandler(this.bnLogin_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "User List:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 454);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageUser.ResumeLayout(false);
            this.tabPageUser.PerformLayout();
            this.tabPageMES.ResumeLayout(false);
            this.tabPageMES.PerformLayout();
            this.tabPageLogin.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnNewUser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNewUser;
        private System.Windows.Forms.TabPage tabPageMES;
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
        private System.Windows.Forms.Button buttonUserGet;
        private System.Windows.Forms.Button buttonUserPW;
        private System.Windows.Forms.Button buttonUserRight;
        private System.Windows.Forms.Button buttonUserDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxUserRight;
        private System.Windows.Forms.ListView listViewUserList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label labelHashUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPW;
        private System.Windows.Forms.Button bnLogout;
        private System.Windows.Forms.Button bnLogin;
        private System.Windows.Forms.Label label11;
    }
}

