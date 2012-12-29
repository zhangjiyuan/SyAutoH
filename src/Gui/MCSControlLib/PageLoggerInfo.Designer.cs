namespace MCSControlLib
{
    partial class PageLoggerInfo
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.listLog = new System.Windows.Forms.TabPage();
            this.listViewAlarm = new System.Windows.Forms.TabPage();
            this.listOfflineLog = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tBOnlineIDS = new System.Windows.Forms.TextBox();
            this.Pause_button = new System.Windows.Forms.Button();
            this.Filter_button = new System.Windows.Forms.Button();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.checkBoxInfo = new System.Windows.Forms.CheckBox();
            this.checkBoxWarning = new System.Windows.Forms.CheckBox();
            this.checkBoxError = new System.Windows.Forms.CheckBox();
            this.checkBoxDebug = new System.Windows.Forms.CheckBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.colIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEventID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.collastTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colfirstTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colcount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bnfirstPage = new System.Windows.Forms.Button();
            this.bnFormer = new System.Windows.Forms.Button();
            this.bnNext = new System.Windows.Forms.Button();
            this.bnLastPage = new System.Windows.Forms.Button();
            this.bnClear = new System.Windows.Forms.Button();
            this.bnClearAll = new System.Windows.Forms.Button();
            this.tbEventID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.bnHome = new System.Windows.Forms.Button();
            this.bnPageDown = new System.Windows.Forms.Button();
            this.bnPageUp = new System.Windows.Forms.Button();
            this.bnEnd = new System.Windows.Forms.Button();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.tbPage = new System.Windows.Forms.TextBox();
            this.bnSearch = new System.Windows.Forms.Button();
            this.bnGoto = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.bnStatictis = new System.Windows.Forms.Button();
            this.bn_Filter = new System.Windows.Forms.Button();
            this.checkBox_Info = new System.Windows.Forms.CheckBox();
            this.checkBox_Warning = new System.Windows.Forms.CheckBox();
            this.checkBox_Debug = new System.Windows.Forms.CheckBox();
            this.checkBox_Error = new System.Windows.Forms.CheckBox();
            this.colhID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhEventID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.listLog.SuspendLayout();
            this.listViewAlarm.SuspendLayout();
            this.listOfflineLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.listLog);
            this.tabControl1.Controls.Add(this.listViewAlarm);
            this.tabControl1.Controls.Add(this.listOfflineLog);
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 590);
            this.tabControl1.TabIndex = 0;
            // 
            // listLog
            // 
            this.listLog.BackColor = System.Drawing.Color.LightGray;
            this.listLog.Controls.Add(this.label2);
            this.listLog.Controls.Add(this.checkBoxDebug);
            this.listLog.Controls.Add(this.checkBoxError);
            this.listLog.Controls.Add(this.checkBoxWarning);
            this.listLog.Controls.Add(this.checkBoxInfo);
            this.listLog.Controls.Add(this.checkBoxAll);
            this.listLog.Controls.Add(this.Filter_button);
            this.listLog.Controls.Add(this.Pause_button);
            this.listLog.Controls.Add(this.tBOnlineIDS);
            this.listLog.Controls.Add(this.listView1);
            this.listLog.Location = new System.Drawing.Point(4, 22);
            this.listLog.Name = "listLog";
            this.listLog.Padding = new System.Windows.Forms.Padding(3);
            this.listLog.Size = new System.Drawing.Size(876, 564);
            this.listLog.TabIndex = 0;
            this.listLog.Text = "OnLine Log";
            // 
            // listViewAlarm
            // 
            this.listViewAlarm.BackColor = System.Drawing.Color.LightGray;
            this.listViewAlarm.Controls.Add(this.label1);
            this.listViewAlarm.Controls.Add(this.tbEventID);
            this.listViewAlarm.Controls.Add(this.bnClearAll);
            this.listViewAlarm.Controls.Add(this.bnClear);
            this.listViewAlarm.Controls.Add(this.bnLastPage);
            this.listViewAlarm.Controls.Add(this.bnNext);
            this.listViewAlarm.Controls.Add(this.bnFormer);
            this.listViewAlarm.Controls.Add(this.bnfirstPage);
            this.listViewAlarm.Controls.Add(this.listView2);
            this.listViewAlarm.Location = new System.Drawing.Point(4, 22);
            this.listViewAlarm.Name = "listViewAlarm";
            this.listViewAlarm.Padding = new System.Windows.Forms.Padding(3);
            this.listViewAlarm.Size = new System.Drawing.Size(876, 564);
            this.listViewAlarm.TabIndex = 1;
            this.listViewAlarm.Text = "AlarmView";
            // 
            // listOfflineLog
            // 
            this.listOfflineLog.BackColor = System.Drawing.Color.LightGray;
            this.listOfflineLog.Controls.Add(this.checkBox_Error);
            this.listOfflineLog.Controls.Add(this.checkBox_Debug);
            this.listOfflineLog.Controls.Add(this.checkBox_Warning);
            this.listOfflineLog.Controls.Add(this.checkBox_Info);
            this.listOfflineLog.Controls.Add(this.bn_Filter);
            this.listOfflineLog.Controls.Add(this.bnStatictis);
            this.listOfflineLog.Controls.Add(this.label6);
            this.listOfflineLog.Controls.Add(this.bnGoto);
            this.listOfflineLog.Controls.Add(this.bnSearch);
            this.listOfflineLog.Controls.Add(this.tbPage);
            this.listOfflineLog.Controls.Add(this.tbKey);
            this.listOfflineLog.Controls.Add(this.bnEnd);
            this.listOfflineLog.Controls.Add(this.bnPageUp);
            this.listOfflineLog.Controls.Add(this.bnPageDown);
            this.listOfflineLog.Controls.Add(this.bnHome);
            this.listOfflineLog.Controls.Add(this.label5);
            this.listOfflineLog.Controls.Add(this.dateTimePicker2);
            this.listOfflineLog.Controls.Add(this.dateTimePicker1);
            this.listOfflineLog.Controls.Add(this.label4);
            this.listOfflineLog.Controls.Add(this.label3);
            this.listOfflineLog.Controls.Add(this.listView3);
            this.listOfflineLog.Location = new System.Drawing.Point(4, 22);
            this.listOfflineLog.Name = "listOfflineLog";
            this.listOfflineLog.Padding = new System.Windows.Forms.Padding(3);
            this.listOfflineLog.Size = new System.Drawing.Size(876, 564);
            this.listOfflineLog.TabIndex = 2;
            this.listOfflineLog.Text = "OffLine Log";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Info;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Time,
            this.EventID,
            this.Message,
            this.User,
            this.Type});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(6, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(698, 552);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 66;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 142;
            // 
            // EventID
            // 
            this.EventID.Text = "EventID";
            this.EventID.Width = 73;
            // 
            // Message
            // 
            this.Message.Text = "Message";
            this.Message.Width = 227;
            // 
            // User
            // 
            this.User.Text = "User";
            this.User.Width = 91;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 95;
            // 
            // tBOnlineIDS
            // 
            this.tBOnlineIDS.Location = new System.Drawing.Point(725, 41);
            this.tBOnlineIDS.Multiline = true;
            this.tBOnlineIDS.Name = "tBOnlineIDS";
            this.tBOnlineIDS.Size = new System.Drawing.Size(100, 30);
            this.tBOnlineIDS.TabIndex = 1;
            // 
            // Pause_button
            // 
            this.Pause_button.Location = new System.Drawing.Point(725, 77);
            this.Pause_button.Name = "Pause_button";
            this.Pause_button.Size = new System.Drawing.Size(100, 34);
            this.Pause_button.TabIndex = 2;
            this.Pause_button.Text = "Pause";
            this.Pause_button.UseVisualStyleBackColor = true;
            // 
            // Filter_button
            // 
            this.Filter_button.Location = new System.Drawing.Point(725, 117);
            this.Filter_button.Name = "Filter_button";
            this.Filter_button.Size = new System.Drawing.Size(100, 35);
            this.Filter_button.TabIndex = 3;
            this.Filter_button.Text = "Filter";
            this.Filter_button.UseVisualStyleBackColor = true;
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(725, 158);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(42, 16);
            this.checkBoxAll.TabIndex = 4;
            this.checkBoxAll.Text = "All";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            // 
            // checkBoxInfo
            // 
            this.checkBoxInfo.AutoSize = true;
            this.checkBoxInfo.Location = new System.Drawing.Point(725, 180);
            this.checkBoxInfo.Name = "checkBoxInfo";
            this.checkBoxInfo.Size = new System.Drawing.Size(48, 16);
            this.checkBoxInfo.TabIndex = 5;
            this.checkBoxInfo.Text = "Info";
            this.checkBoxInfo.UseVisualStyleBackColor = true;
            // 
            // checkBoxWarning
            // 
            this.checkBoxWarning.AutoSize = true;
            this.checkBoxWarning.Location = new System.Drawing.Point(725, 202);
            this.checkBoxWarning.Name = "checkBoxWarning";
            this.checkBoxWarning.Size = new System.Drawing.Size(66, 16);
            this.checkBoxWarning.TabIndex = 6;
            this.checkBoxWarning.Text = "Warning";
            this.checkBoxWarning.UseVisualStyleBackColor = true;
            // 
            // checkBoxError
            // 
            this.checkBoxError.AutoSize = true;
            this.checkBoxError.Location = new System.Drawing.Point(725, 224);
            this.checkBoxError.Name = "checkBoxError";
            this.checkBoxError.Size = new System.Drawing.Size(54, 16);
            this.checkBoxError.TabIndex = 7;
            this.checkBoxError.Text = "Error";
            this.checkBoxError.UseVisualStyleBackColor = true;
            // 
            // checkBoxDebug
            // 
            this.checkBoxDebug.AutoSize = true;
            this.checkBoxDebug.Location = new System.Drawing.Point(725, 246);
            this.checkBoxDebug.Name = "checkBoxDebug";
            this.checkBoxDebug.Size = new System.Drawing.Size(54, 16);
            this.checkBoxDebug.TabIndex = 8;
            this.checkBoxDebug.Text = "Debug";
            this.checkBoxDebug.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.SystemColors.Info;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIndex,
            this.colEventID,
            this.collastTime,
            this.colMessage,
            this.colfirstTime,
            this.colcount});
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(6, 6);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(702, 492);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // colIndex
            // 
            this.colIndex.Text = "Index";
            // 
            // colEventID
            // 
            this.colEventID.Text = "ID";
            // 
            // collastTime
            // 
            this.collastTime.Text = "LastTime";
            this.collastTime.Width = 150;
            // 
            // colMessage
            // 
            this.colMessage.Text = "Message";
            this.colMessage.Width = 207;
            // 
            // colfirstTime
            // 
            this.colfirstTime.Text = "FirstTime";
            this.colfirstTime.Width = 161;
            // 
            // colcount
            // 
            this.colcount.Text = "Count";
            // 
            // bnfirstPage
            // 
            this.bnfirstPage.Location = new System.Drawing.Point(6, 515);
            this.bnfirstPage.Name = "bnfirstPage";
            this.bnfirstPage.Size = new System.Drawing.Size(43, 23);
            this.bnfirstPage.TabIndex = 1;
            this.bnfirstPage.Text = "|<";
            this.bnfirstPage.UseVisualStyleBackColor = true;
            // 
            // bnFormer
            // 
            this.bnFormer.Location = new System.Drawing.Point(55, 515);
            this.bnFormer.Name = "bnFormer";
            this.bnFormer.Size = new System.Drawing.Size(45, 23);
            this.bnFormer.TabIndex = 2;
            this.bnFormer.Text = "<";
            this.bnFormer.UseVisualStyleBackColor = true;
            // 
            // bnNext
            // 
            this.bnNext.Location = new System.Drawing.Point(106, 515);
            this.bnNext.Name = "bnNext";
            this.bnNext.Size = new System.Drawing.Size(44, 23);
            this.bnNext.TabIndex = 3;
            this.bnNext.Text = ">";
            this.bnNext.UseVisualStyleBackColor = true;
            // 
            // bnLastPage
            // 
            this.bnLastPage.Location = new System.Drawing.Point(156, 515);
            this.bnLastPage.Name = "bnLastPage";
            this.bnLastPage.Size = new System.Drawing.Size(43, 23);
            this.bnLastPage.TabIndex = 4;
            this.bnLastPage.Text = ">|";
            this.bnLastPage.UseVisualStyleBackColor = true;
            // 
            // bnClear
            // 
            this.bnClear.Location = new System.Drawing.Point(729, 86);
            this.bnClear.Name = "bnClear";
            this.bnClear.Size = new System.Drawing.Size(100, 33);
            this.bnClear.TabIndex = 5;
            this.bnClear.Text = "Clear";
            this.bnClear.UseVisualStyleBackColor = true;
            // 
            // bnClearAll
            // 
            this.bnClearAll.Location = new System.Drawing.Point(729, 125);
            this.bnClearAll.Name = "bnClearAll";
            this.bnClearAll.Size = new System.Drawing.Size(100, 33);
            this.bnClearAll.TabIndex = 6;
            this.bnClearAll.Text = "Clear All";
            this.bnClearAll.UseVisualStyleBackColor = true;
            // 
            // tbEventID
            // 
            this.tbEventID.Location = new System.Drawing.Point(729, 42);
            this.tbEventID.Multiline = true;
            this.tbEventID.Name = "tbEventID";
            this.tbEventID.Size = new System.Drawing.Size(100, 28);
            this.tbEventID.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(727, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "EventID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(723, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "EventID:";
            // 
            // listView3
            // 
            this.listView3.BackColor = System.Drawing.SystemColors.Info;
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colhID,
            this.colhTime,
            this.colhEventID,
            this.colhMessage,
            this.colhUser,
            this.colhType});
            this.listView3.GridLines = true;
            this.listView3.Location = new System.Drawing.Point(6, 76);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(718, 482);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "From:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "To:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(60, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(155, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(268, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(153, 21);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Page Number: 1/44";
            // 
            // bnHome
            // 
            this.bnHome.Location = new System.Drawing.Point(174, 47);
            this.bnHome.Name = "bnHome";
            this.bnHome.Size = new System.Drawing.Size(41, 23);
            this.bnHome.TabIndex = 6;
            this.bnHome.Text = "|<";
            this.bnHome.UseVisualStyleBackColor = true;
            // 
            // bnPageDown
            // 
            this.bnPageDown.Location = new System.Drawing.Point(221, 47);
            this.bnPageDown.Name = "bnPageDown";
            this.bnPageDown.Size = new System.Drawing.Size(41, 23);
            this.bnPageDown.TabIndex = 7;
            this.bnPageDown.Text = "<";
            this.bnPageDown.UseVisualStyleBackColor = true;
            // 
            // bnPageUp
            // 
            this.bnPageUp.Location = new System.Drawing.Point(268, 47);
            this.bnPageUp.Name = "bnPageUp";
            this.bnPageUp.Size = new System.Drawing.Size(41, 23);
            this.bnPageUp.TabIndex = 8;
            this.bnPageUp.Text = ">";
            this.bnPageUp.UseVisualStyleBackColor = true;
            // 
            // bnEnd
            // 
            this.bnEnd.Location = new System.Drawing.Point(315, 47);
            this.bnEnd.Name = "bnEnd";
            this.bnEnd.Size = new System.Drawing.Size(41, 23);
            this.bnEnd.TabIndex = 9;
            this.bnEnd.Text = ">|";
            this.bnEnd.UseVisualStyleBackColor = true;
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(493, 6);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(100, 21);
            this.tbKey.TabIndex = 10;
            // 
            // tbPage
            // 
            this.tbPage.Location = new System.Drawing.Point(493, 43);
            this.tbPage.Name = "tbPage";
            this.tbPage.Size = new System.Drawing.Size(100, 21);
            this.tbPage.TabIndex = 11;
            // 
            // bnSearch
            // 
            this.bnSearch.Location = new System.Drawing.Point(621, 4);
            this.bnSearch.Name = "bnSearch";
            this.bnSearch.Size = new System.Drawing.Size(75, 23);
            this.bnSearch.TabIndex = 12;
            this.bnSearch.Text = "Search";
            this.bnSearch.UseVisualStyleBackColor = true;
            // 
            // bnGoto
            // 
            this.bnGoto.Location = new System.Drawing.Point(621, 41);
            this.bnGoto.Name = "bnGoto";
            this.bnGoto.Size = new System.Drawing.Size(75, 23);
            this.bnGoto.TabIndex = 13;
            this.bnGoto.Text = "Go to";
            this.bnGoto.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(446, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "Key:";
            // 
            // bnStatictis
            // 
            this.bnStatictis.Location = new System.Drawing.Point(744, 94);
            this.bnStatictis.Name = "bnStatictis";
            this.bnStatictis.Size = new System.Drawing.Size(101, 30);
            this.bnStatictis.TabIndex = 15;
            this.bnStatictis.Text = "Statictis";
            this.bnStatictis.UseVisualStyleBackColor = true;
            // 
            // bn_Filter
            // 
            this.bn_Filter.Location = new System.Drawing.Point(744, 130);
            this.bn_Filter.Name = "bn_Filter";
            this.bn_Filter.Size = new System.Drawing.Size(101, 30);
            this.bn_Filter.TabIndex = 16;
            this.bn_Filter.Text = "Filter";
            this.bn_Filter.UseVisualStyleBackColor = true;
            // 
            // checkBox_Info
            // 
            this.checkBox_Info.AutoSize = true;
            this.checkBox_Info.Location = new System.Drawing.Point(744, 166);
            this.checkBox_Info.Name = "checkBox_Info";
            this.checkBox_Info.Size = new System.Drawing.Size(48, 16);
            this.checkBox_Info.TabIndex = 17;
            this.checkBox_Info.Text = "Info";
            this.checkBox_Info.UseVisualStyleBackColor = true;
            // 
            // checkBox_Warning
            // 
            this.checkBox_Warning.AutoSize = true;
            this.checkBox_Warning.Location = new System.Drawing.Point(744, 188);
            this.checkBox_Warning.Name = "checkBox_Warning";
            this.checkBox_Warning.Size = new System.Drawing.Size(66, 16);
            this.checkBox_Warning.TabIndex = 18;
            this.checkBox_Warning.Text = "Warning";
            this.checkBox_Warning.UseVisualStyleBackColor = true;
            // 
            // checkBox_Debug
            // 
            this.checkBox_Debug.AutoSize = true;
            this.checkBox_Debug.Location = new System.Drawing.Point(744, 210);
            this.checkBox_Debug.Name = "checkBox_Debug";
            this.checkBox_Debug.Size = new System.Drawing.Size(54, 16);
            this.checkBox_Debug.TabIndex = 19;
            this.checkBox_Debug.Text = "Debug";
            this.checkBox_Debug.UseVisualStyleBackColor = true;
            // 
            // checkBox_Error
            // 
            this.checkBox_Error.AutoSize = true;
            this.checkBox_Error.Location = new System.Drawing.Point(744, 232);
            this.checkBox_Error.Name = "checkBox_Error";
            this.checkBox_Error.Size = new System.Drawing.Size(54, 16);
            this.checkBox_Error.TabIndex = 20;
            this.checkBox_Error.Text = "Error";
            this.checkBox_Error.UseVisualStyleBackColor = true;
            // 
            // colhID
            // 
            this.colhID.Text = "ID";
            // 
            // colhTime
            // 
            this.colhTime.Text = "Time";
            this.colhTime.Width = 154;
            // 
            // colhEventID
            // 
            this.colhEventID.Text = "EventID";
            // 
            // colhMessage
            // 
            this.colhMessage.Text = "Message";
            this.colhMessage.Width = 265;
            // 
            // colhUser
            // 
            this.colhUser.Text = "User";
            this.colhUser.Width = 109;
            // 
            // colhType
            // 
            this.colhType.Text = "Type";
            this.colhType.Width = 65;
            // 
            // PageLoggerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.tabControl1);
            this.Name = "PageLoggerInfo";
            this.Size = new System.Drawing.Size(887, 596);
            this.tabControl1.ResumeLayout(false);
            this.listLog.ResumeLayout(false);
            this.listLog.PerformLayout();
            this.listViewAlarm.ResumeLayout(false);
            this.listViewAlarm.PerformLayout();
            this.listOfflineLog.ResumeLayout(false);
            this.listOfflineLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage listLog;
        private System.Windows.Forms.TabPage listViewAlarm;
        private System.Windows.Forms.TabPage listOfflineLog;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader EventID;
        private System.Windows.Forms.ColumnHeader Message;
        private System.Windows.Forms.ColumnHeader User;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.CheckBox checkBoxDebug;
        private System.Windows.Forms.CheckBox checkBoxError;
        private System.Windows.Forms.CheckBox checkBoxWarning;
        private System.Windows.Forms.CheckBox checkBoxInfo;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.Button Filter_button;
        private System.Windows.Forms.Button Pause_button;
        private System.Windows.Forms.TextBox tBOnlineIDS;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader colIndex;
        private System.Windows.Forms.ColumnHeader colEventID;
        private System.Windows.Forms.ColumnHeader collastTime;
        private System.Windows.Forms.ColumnHeader colMessage;
        private System.Windows.Forms.ColumnHeader colfirstTime;
        private System.Windows.Forms.ColumnHeader colcount;
        private System.Windows.Forms.Button bnfirstPage;
        private System.Windows.Forms.TextBox tbEventID;
        private System.Windows.Forms.Button bnClearAll;
        private System.Windows.Forms.Button bnClear;
        private System.Windows.Forms.Button bnLastPage;
        private System.Windows.Forms.Button bnNext;
        private System.Windows.Forms.Button bnFormer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnEnd;
        private System.Windows.Forms.Button bnPageUp;
        private System.Windows.Forms.Button bnPageDown;
        private System.Windows.Forms.Button bnHome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Button bnGoto;
        private System.Windows.Forms.Button bnSearch;
        private System.Windows.Forms.TextBox tbPage;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_Error;
        private System.Windows.Forms.CheckBox checkBox_Debug;
        private System.Windows.Forms.CheckBox checkBox_Warning;
        private System.Windows.Forms.CheckBox checkBox_Info;
        private System.Windows.Forms.Button bn_Filter;
        private System.Windows.Forms.Button bnStatictis;
        private System.Windows.Forms.ColumnHeader colhID;
        private System.Windows.Forms.ColumnHeader colhTime;
        private System.Windows.Forms.ColumnHeader colhEventID;
        private System.Windows.Forms.ColumnHeader colhMessage;
        private System.Windows.Forms.ColumnHeader colhUser;
        private System.Windows.Forms.ColumnHeader colhType;
    }
}
