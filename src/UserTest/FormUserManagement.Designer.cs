namespace UserTest
{
    partial class FormUserManagement
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
            this.bnNewUser = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBoxPW = new System.Windows.Forms.MaskedTextBox();
            this.bnLogout = new System.Windows.Forms.Button();
            this.bnLogin = new System.Windows.Forms.Button();
            this.tabPageUser = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxLoginUser = new System.Windows.Forms.TextBox();
            this.comboBoxUserRight = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonUserPW = new System.Windows.Forms.Button();
            this.buttonUserRight = new System.Windows.Forms.Button();
            this.buttonUserDelete = new System.Windows.Forms.Button();
            this.listViewUserList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.tabOHT = new System.Windows.Forms.TabPage();
            this.labelCBTest = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOhtMoveTo = new System.Windows.Forms.TextBox();
            this.bnOHTGo = new System.Windows.Forms.Button();
            this.listViewOHTs = new System.Windows.Forms.ListView();
            this.tabSTK = new System.Windows.Forms.TabPage();
            this.bnSTK_History = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageUser.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageMES.SuspendLayout();
            this.tabOHT.SuspendLayout();
            this.tabSTK.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabOHT);
            this.tabControl1.Controls.Add(this.tabSTK);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(519, 454);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
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
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.maskedTextBoxPW);
            this.groupBox1.Controls.Add(this.bnLogout);
            this.groupBox1.Controls.Add(this.bnLogin);
            this.groupBox1.Location = new System.Drawing.Point(76, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 118);
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
            // tabPageUser
            // 
            this.tabPageUser.Controls.Add(this.groupBox2);
            this.tabPageUser.Controls.Add(this.label11);
            this.tabPageUser.Controls.Add(this.buttonUserPW);
            this.tabPageUser.Controls.Add(this.buttonUserRight);
            this.tabPageUser.Controls.Add(this.buttonUserDelete);
            this.tabPageUser.Controls.Add(this.listViewUserList);
            this.tabPageUser.Controls.Add(this.bnNewUser);
            this.tabPageUser.Location = new System.Drawing.Point(4, 22);
            this.tabPageUser.Name = "tabPageUser";
            this.tabPageUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUser.Size = new System.Drawing.Size(511, 428);
            this.tabPageUser.TabIndex = 0;
            this.tabPageUser.Text = "User Management";
            this.tabPageUser.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxLoginUser);
            this.groupBox2.Controls.Add(this.comboBoxUserRight);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(271, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current User";
            // 
            // textBoxLoginUser
            // 
            this.textBoxLoginUser.Location = new System.Drawing.Point(60, 20);
            this.textBoxLoginUser.Name = "textBoxLoginUser";
            this.textBoxLoginUser.ReadOnly = true;
            this.textBoxLoginUser.Size = new System.Drawing.Size(120, 21);
            this.textBoxLoginUser.TabIndex = 8;
            // 
            // comboBoxUserRight
            // 
            this.comboBoxUserRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserRight.Enabled = false;
            this.comboBoxUserRight.FormattingEnabled = true;
            this.comboBoxUserRight.Items.AddRange(new object[] {
            "Viewer",
            "Guest",
            "Operator",
            "Admin",
            "SAdmin"});
            this.comboBoxUserRight.Location = new System.Drawing.Point(60, 60);
            this.comboBoxUserRight.Name = "comboBoxUserRight";
            this.comboBoxUserRight.Size = new System.Drawing.Size(120, 20);
            this.comboBoxUserRight.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "Right:";
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
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Right";
            this.columnHeader3.Width = 80;
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
            // tabOHT
            // 
            this.tabOHT.Controls.Add(this.labelCBTest);
            this.tabOHT.Controls.Add(this.label3);
            this.tabOHT.Controls.Add(this.tbOhtMoveTo);
            this.tabOHT.Controls.Add(this.bnOHTGo);
            this.tabOHT.Controls.Add(this.listViewOHTs);
            this.tabOHT.Location = new System.Drawing.Point(4, 22);
            this.tabOHT.Name = "tabOHT";
            this.tabOHT.Padding = new System.Windows.Forms.Padding(3);
            this.tabOHT.Size = new System.Drawing.Size(511, 428);
            this.tabOHT.TabIndex = 3;
            this.tabOHT.Text = "OHT Info";
            this.tabOHT.UseVisualStyleBackColor = true;
            // 
            // labelCBTest
            // 
            this.labelCBTest.Location = new System.Drawing.Point(8, 285);
            this.labelCBTest.Name = "labelCBTest";
            this.labelCBTest.Size = new System.Drawing.Size(495, 138);
            this.labelCBTest.TabIndex = 4;
            this.labelCBTest.Text = "label9";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "OHT Move To:";
            // 
            // tbOhtMoveTo
            // 
            this.tbOhtMoveTo.Location = new System.Drawing.Point(81, 255);
            this.tbOhtMoveTo.Name = "tbOhtMoveTo";
            this.tbOhtMoveTo.Size = new System.Drawing.Size(100, 21);
            this.tbOhtMoveTo.TabIndex = 2;
            // 
            // bnOHTGo
            // 
            this.bnOHTGo.Location = new System.Drawing.Point(187, 253);
            this.bnOHTGo.Name = "bnOHTGo";
            this.bnOHTGo.Size = new System.Drawing.Size(75, 23);
            this.bnOHTGo.TabIndex = 1;
            this.bnOHTGo.Text = "Go";
            this.bnOHTGo.UseVisualStyleBackColor = true;
            this.bnOHTGo.Click += new System.EventHandler(this.bnOHTGo_Click);
            // 
            // listViewOHTs
            // 
            this.listViewOHTs.Location = new System.Drawing.Point(8, 6);
            this.listViewOHTs.Name = "listViewOHTs";
            this.listViewOHTs.Size = new System.Drawing.Size(495, 245);
            this.listViewOHTs.TabIndex = 0;
            this.listViewOHTs.UseCompatibleStateImageBehavior = false;
            this.listViewOHTs.View = System.Windows.Forms.View.Details;
            // 
            // tabSTK
            // 
            this.tabSTK.Controls.Add(this.bnSTK_History);
            this.tabSTK.Location = new System.Drawing.Point(4, 22);
            this.tabSTK.Name = "tabSTK";
            this.tabSTK.Padding = new System.Windows.Forms.Padding(3);
            this.tabSTK.Size = new System.Drawing.Size(511, 428);
            this.tabSTK.TabIndex = 4;
            this.tabSTK.Text = "Stocker Info";
            this.tabSTK.UseVisualStyleBackColor = true;
            // 
            // bnSTK_History
            // 
            this.bnSTK_History.Location = new System.Drawing.Point(385, 116);
            this.bnSTK_History.Name = "bnSTK_History";
            this.bnSTK_History.Size = new System.Drawing.Size(118, 23);
            this.bnSTK_History.TabIndex = 0;
            this.bnSTK_History.Text = "history Foups";
            this.bnSTK_History.UseVisualStyleBackColor = true;
            this.bnSTK_History.Click += new System.EventHandler(this.bnSTK_History_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 454);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormUserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageUser.ResumeLayout(false);
            this.tabPageUser.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageMES.ResumeLayout(false);
            this.tabPageMES.PerformLayout();
            this.tabOHT.ResumeLayout(false);
            this.tabOHT.PerformLayout();
            this.tabSTK.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnNewUser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLoginUser;
        private System.Windows.Forms.TabPage tabPageMES;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPW;
        private System.Windows.Forms.Button bnLogout;
        private System.Windows.Forms.Button bnLogin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabOHT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOhtMoveTo;
        private System.Windows.Forms.Button bnOHTGo;
        private System.Windows.Forms.ListView listViewOHTs;
        private System.Windows.Forms.Label labelCBTest;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabSTK;
        private System.Windows.Forms.Button bnSTK_History;
    }
}

