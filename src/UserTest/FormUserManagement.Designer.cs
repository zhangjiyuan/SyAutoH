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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bnMesFouptoLocation = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBMesLS_TP = new System.Windows.Forms.TextBox();
            this.tBMesLS_BC = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lVMes_Location = new System.Windows.Forms.ListView();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tBMesFS_POS = new System.Windows.Forms.TextBox();
            this.tBMesFS_CAR = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tBMesFS_ST = new System.Windows.Forms.TextBox();
            this.tBMesFS_BC = new System.Windows.Forms.TextBox();
            this.tBMesFS_Lot = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lVMes_Foup = new System.Windows.Forms.ListView();
            this.tabOHT = new System.Windows.Forms.TabPage();
            this.bnSetPosTime = new System.Windows.Forms.Button();
            this.tBPosTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.labelCBTest = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOhtMoveTo = new System.Windows.Forms.TextBox();
            this.bnOHTGo = new System.Windows.Forms.Button();
            this.listViewOHTs = new System.Windows.Forms.ListView();
            this.tabSTK = new System.Windows.Forms.TabPage();
            this.listViewStockerSelect = new System.Windows.Forms.ListView();
            this.listViewStockerFoups = new System.Windows.Forms.ListView();
            this.bnSTK_History = new System.Windows.Forms.Button();
            this.tabFoups = new System.Windows.Forms.TabPage();
            this.listViewFoups = new System.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageUser.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageMES.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabOHT.SuspendLayout();
            this.tabSTK.SuspendLayout();
            this.tabFoups.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabFoups);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(960, 454);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPageLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPageLogin.Controls.Add(this.groupBox1);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Size = new System.Drawing.Size(875, 428);
            this.tabPageLogin.TabIndex = 2;
            this.tabPageLogin.Text = "Login";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.maskedTextBoxPW);
            this.groupBox1.Controls.Add(this.bnLogout);
            this.groupBox1.Controls.Add(this.bnLogin);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(189, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 131);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login / Logout";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "User:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(88, 22);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(124, 21);
            this.textBoxUser.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(14, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // maskedTextBoxPW
            // 
            this.maskedTextBoxPW.Location = new System.Drawing.Point(88, 53);
            this.maskedTextBoxPW.Name = "maskedTextBoxPW";
            this.maskedTextBoxPW.PasswordChar = '*';
            this.maskedTextBoxPW.Size = new System.Drawing.Size(124, 21);
            this.maskedTextBoxPW.TabIndex = 3;
            this.maskedTextBoxPW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBoxPW_KeyPress);
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
            this.tabPageUser.BackColor = System.Drawing.Color.Moccasin;
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
            this.tabPageUser.Size = new System.Drawing.Size(875, 428);
            this.tabPageUser.TabIndex = 0;
            this.tabPageUser.Text = "User Management";
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
            this.tabPageMES.BackColor = System.Drawing.Color.PaleGreen;
            this.tabPageMES.Controls.Add(this.groupBox5);
            this.tabPageMES.Controls.Add(this.button3);
            this.tabPageMES.Controls.Add(this.button2);
            this.tabPageMES.Controls.Add(this.button1);
            this.tabPageMES.Controls.Add(this.bnMesFouptoLocation);
            this.tabPageMES.Controls.Add(this.groupBox4);
            this.tabPageMES.Controls.Add(this.label15);
            this.tabPageMES.Controls.Add(this.lVMes_Location);
            this.tabPageMES.Controls.Add(this.linkLabel1);
            this.tabPageMES.Controls.Add(this.groupBox3);
            this.tabPageMES.Controls.Add(this.label12);
            this.tabPageMES.Controls.Add(this.lVMes_Foup);
            this.tabPageMES.Location = new System.Drawing.Point(4, 22);
            this.tabPageMES.Name = "tabPageMES";
            this.tabPageMES.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMES.Size = new System.Drawing.Size(952, 428);
            this.tabPageMES.TabIndex = 1;
            this.tabPageMES.Text = "MES Simulator";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBox1);
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Location = new System.Drawing.Point(192, 286);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(164, 134);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Map Info";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(50, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 20);
            this.comboBox1.TabIndex = 29;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(11, 49);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(147, 78);
            this.textBox3.TabIndex = 28;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 12);
            this.label19.TabIndex = 26;
            this.label19.Text = "Name:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(220, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "Continue";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Pause";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bnMesFouptoLocation
            // 
            this.bnMesFouptoLocation.Location = new System.Drawing.Point(206, 36);
            this.bnMesFouptoLocation.Name = "bnMesFouptoLocation";
            this.bnMesFouptoLocation.Size = new System.Drawing.Size(130, 23);
            this.bnMesFouptoLocation.TabIndex = 19;
            this.bnMesFouptoLocation.Text = "Foup to Location";
            this.bnMesFouptoLocation.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.tBMesLS_TP);
            this.groupBox4.Controls.Add(this.tBMesLS_BC);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(180, 183);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Location Selected";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(14, 99);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(147, 78);
            this.textBox2.TabIndex = 25;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(84, 21);
            this.textBox1.TabIndex = 23;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "Name:";
            // 
            // tBMesLS_TP
            // 
            this.tBMesLS_TP.Location = new System.Drawing.Point(77, 45);
            this.tBMesLS_TP.Name = "tBMesLS_TP";
            this.tBMesLS_TP.ReadOnly = true;
            this.tBMesLS_TP.Size = new System.Drawing.Size(84, 21);
            this.tBMesLS_TP.TabIndex = 21;
            this.tBMesLS_TP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tBMesLS_BC
            // 
            this.tBMesLS_BC.Location = new System.Drawing.Point(77, 20);
            this.tBMesLS_BC.Name = "tBMesLS_BC";
            this.tBMesLS_BC.ReadOnly = true;
            this.tBMesLS_BC.Size = new System.Drawing.Size(84, 21);
            this.tBMesLS_BC.TabIndex = 19;
            this.tBMesLS_BC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "BarCode:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(360, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 12);
            this.label15.TabIndex = 17;
            this.label15.Text = "Locations in MCS:";
            // 
            // lVMes_Location
            // 
            this.lVMes_Location.BackColor = System.Drawing.Color.Linen;
            this.lVMes_Location.Location = new System.Drawing.Point(362, 36);
            this.lVMes_Location.Name = "lVMes_Location";
            this.lVMes_Location.Size = new System.Drawing.Size(221, 384);
            this.lVMes_Location.TabIndex = 16;
            this.lVMes_Location.UseCompatibleStateImageBehavior = false;
            this.lVMes_Location.View = System.Windows.Forms.View.Details;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(819, 14);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(125, 12);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Refresh Foups in MCS";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.tBMesFS_POS);
            this.groupBox3.Controls.Add(this.tBMesFS_CAR);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.tBMesFS_ST);
            this.groupBox3.Controls.Add(this.tBMesFS_BC);
            this.groupBox3.Controls.Add(this.tBMesFS_Lot);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(6, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 225);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Foup Selected";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 141);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(131, 12);
            this.label18.TabIndex = 23;
            this.label18.Text = "Real Time Motion Info";
            // 
            // tBMesFS_POS
            // 
            this.tBMesFS_POS.Location = new System.Drawing.Point(77, 193);
            this.tBMesFS_POS.Name = "tBMesFS_POS";
            this.tBMesFS_POS.ReadOnly = true;
            this.tBMesFS_POS.Size = new System.Drawing.Size(84, 21);
            this.tBMesFS_POS.TabIndex = 22;
            this.tBMesFS_POS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tBMesFS_CAR
            // 
            this.tBMesFS_CAR.Location = new System.Drawing.Point(77, 169);
            this.tBMesFS_CAR.Name = "tBMesFS_CAR";
            this.tBMesFS_CAR.ReadOnly = true;
            this.tBMesFS_CAR.Size = new System.Drawing.Size(84, 21);
            this.tBMesFS_CAR.TabIndex = 21;
            this.tBMesFS_CAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 196);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 20;
            this.label17.Text = "Position:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 172);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 19;
            this.label16.Text = "Carrier:";
            // 
            // tBMesFS_ST
            // 
            this.tBMesFS_ST.Location = new System.Drawing.Point(77, 67);
            this.tBMesFS_ST.Name = "tBMesFS_ST";
            this.tBMesFS_ST.ReadOnly = true;
            this.tBMesFS_ST.Size = new System.Drawing.Size(84, 21);
            this.tBMesFS_ST.TabIndex = 18;
            this.tBMesFS_ST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tBMesFS_BC
            // 
            this.tBMesFS_BC.Location = new System.Drawing.Point(77, 43);
            this.tBMesFS_BC.Name = "tBMesFS_BC";
            this.tBMesFS_BC.ReadOnly = true;
            this.tBMesFS_BC.Size = new System.Drawing.Size(84, 21);
            this.tBMesFS_BC.TabIndex = 17;
            this.tBMesFS_BC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tBMesFS_Lot
            // 
            this.tBMesFS_Lot.Location = new System.Drawing.Point(77, 19);
            this.tBMesFS_Lot.Name = "tBMesFS_Lot";
            this.tBMesFS_Lot.ReadOnly = true;
            this.tBMesFS_Lot.Size = new System.Drawing.Size(84, 21);
            this.tBMesFS_Lot.TabIndex = 16;
            this.tBMesFS_Lot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "BarCode:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "Lot:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Status:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(587, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "Foups in MCS:";
            // 
            // lVMes_Foup
            // 
            this.lVMes_Foup.BackColor = System.Drawing.Color.SkyBlue;
            this.lVMes_Foup.Location = new System.Drawing.Point(589, 36);
            this.lVMes_Foup.Name = "lVMes_Foup";
            this.lVMes_Foup.Size = new System.Drawing.Size(355, 384);
            this.lVMes_Foup.TabIndex = 11;
            this.lVMes_Foup.UseCompatibleStateImageBehavior = false;
            this.lVMes_Foup.View = System.Windows.Forms.View.Details;
            // 
            // tabOHT
            // 
            this.tabOHT.BackColor = System.Drawing.Color.SandyBrown;
            this.tabOHT.Controls.Add(this.bnSetPosTime);
            this.tabOHT.Controls.Add(this.tBPosTime);
            this.tabOHT.Controls.Add(this.label9);
            this.tabOHT.Controls.Add(this.labelCBTest);
            this.tabOHT.Controls.Add(this.label3);
            this.tabOHT.Controls.Add(this.tbOhtMoveTo);
            this.tabOHT.Controls.Add(this.bnOHTGo);
            this.tabOHT.Controls.Add(this.listViewOHTs);
            this.tabOHT.Location = new System.Drawing.Point(4, 22);
            this.tabOHT.Name = "tabOHT";
            this.tabOHT.Padding = new System.Windows.Forms.Padding(3);
            this.tabOHT.Size = new System.Drawing.Size(875, 428);
            this.tabOHT.TabIndex = 3;
            this.tabOHT.Text = "OHT Info";
            // 
            // bnSetPosTime
            // 
            this.bnSetPosTime.Location = new System.Drawing.Point(187, 283);
            this.bnSetPosTime.Name = "bnSetPosTime";
            this.bnSetPosTime.Size = new System.Drawing.Size(126, 23);
            this.bnSetPosTime.TabIndex = 7;
            this.bnSetPosTime.Text = "Set POS BackTime";
            this.bnSetPosTime.UseVisualStyleBackColor = true;
            this.bnSetPosTime.Click += new System.EventHandler(this.bnSetPosTime_Click);
            // 
            // tBPosTime
            // 
            this.tBPosTime.Location = new System.Drawing.Point(91, 285);
            this.tBPosTime.Name = "tBPosTime";
            this.tBPosTime.Size = new System.Drawing.Size(90, 21);
            this.tBPosTime.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "POS BackTime";
            // 
            // labelCBTest
            // 
            this.labelCBTest.Location = new System.Drawing.Point(8, 326);
            this.labelCBTest.Name = "labelCBTest";
            this.labelCBTest.Size = new System.Drawing.Size(495, 97);
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
            this.tbOhtMoveTo.Location = new System.Drawing.Point(91, 255);
            this.tbOhtMoveTo.Name = "tbOhtMoveTo";
            this.tbOhtMoveTo.Size = new System.Drawing.Size(90, 21);
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
            this.tabSTK.Controls.Add(this.listViewStockerSelect);
            this.tabSTK.Controls.Add(this.listViewStockerFoups);
            this.tabSTK.Controls.Add(this.bnSTK_History);
            this.tabSTK.Location = new System.Drawing.Point(4, 22);
            this.tabSTK.Name = "tabSTK";
            this.tabSTK.Padding = new System.Windows.Forms.Padding(3);
            this.tabSTK.Size = new System.Drawing.Size(875, 428);
            this.tabSTK.TabIndex = 4;
            this.tabSTK.Text = "Stocker Info";
            this.tabSTK.UseVisualStyleBackColor = true;
            // 
            // listViewStockerSelect
            // 
            this.listViewStockerSelect.FullRowSelect = true;
            this.listViewStockerSelect.GridLines = true;
            this.listViewStockerSelect.Location = new System.Drawing.Point(593, 6);
            this.listViewStockerSelect.Name = "listViewStockerSelect";
            this.listViewStockerSelect.Size = new System.Drawing.Size(167, 293);
            this.listViewStockerSelect.TabIndex = 2;
            this.listViewStockerSelect.UseCompatibleStateImageBehavior = false;
            this.listViewStockerSelect.View = System.Windows.Forms.View.Details;
            // 
            // listViewStockerFoups
            // 
            this.listViewStockerFoups.FullRowSelect = true;
            this.listViewStockerFoups.GridLines = true;
            this.listViewStockerFoups.Location = new System.Drawing.Point(8, 6);
            this.listViewStockerFoups.Name = "listViewStockerFoups";
            this.listViewStockerFoups.Size = new System.Drawing.Size(579, 293);
            this.listViewStockerFoups.TabIndex = 1;
            this.listViewStockerFoups.UseCompatibleStateImageBehavior = false;
            this.listViewStockerFoups.View = System.Windows.Forms.View.Details;
            // 
            // bnSTK_History
            // 
            this.bnSTK_History.Location = new System.Drawing.Point(385, 397);
            this.bnSTK_History.Name = "bnSTK_History";
            this.bnSTK_History.Size = new System.Drawing.Size(118, 23);
            this.bnSTK_History.TabIndex = 0;
            this.bnSTK_History.Text = "history Foups";
            this.bnSTK_History.UseVisualStyleBackColor = true;
            this.bnSTK_History.Click += new System.EventHandler(this.bnSTK_History_Click);
            // 
            // tabFoups
            // 
            this.tabFoups.Controls.Add(this.listViewFoups);
            this.tabFoups.Location = new System.Drawing.Point(4, 22);
            this.tabFoups.Name = "tabFoups";
            this.tabFoups.Padding = new System.Windows.Forms.Padding(3);
            this.tabFoups.Size = new System.Drawing.Size(875, 428);
            this.tabFoups.TabIndex = 5;
            this.tabFoups.Text = "Foup Info";
            this.tabFoups.UseVisualStyleBackColor = true;
            // 
            // listViewFoups
            // 
            this.listViewFoups.FullRowSelect = true;
            this.listViewFoups.GridLines = true;
            this.listViewFoups.Location = new System.Drawing.Point(10, 6);
            this.listViewFoups.Name = "listViewFoups";
            this.listViewFoups.Size = new System.Drawing.Size(495, 293);
            this.listViewFoups.TabIndex = 2;
            this.listViewFoups.UseCompatibleStateImageBehavior = false;
            this.listViewFoups.View = System.Windows.Forms.View.Details;
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
            this.ClientSize = new System.Drawing.Size(960, 454);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormUserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MCS Control";
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabOHT.ResumeLayout(false);
            this.tabOHT.PerformLayout();
            this.tabSTK.ResumeLayout(false);
            this.tabFoups.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnNewUser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLoginUser;
        private System.Windows.Forms.TabPage tabPageMES;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Button bnSetPosTime;
        private System.Windows.Forms.TextBox tBPosTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView listViewStockerFoups;
        private System.Windows.Forms.TabPage tabFoups;
        private System.Windows.Forms.ListView listViewFoups;
        private System.Windows.Forms.ListView listViewStockerSelect;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView lVMes_Foup;
        private System.Windows.Forms.TextBox tBMesFS_ST;
        private System.Windows.Forms.TextBox tBMesFS_BC;
        private System.Windows.Forms.TextBox tBMesFS_Lot;
        private System.Windows.Forms.ListView lVMes_Location;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tBMesLS_TP;
        private System.Windows.Forms.TextBox tBMesLS_BC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bnMesFouptoLocation;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tBMesFS_POS;
        private System.Windows.Forms.TextBox tBMesFS_CAR;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label19;
    }
}

