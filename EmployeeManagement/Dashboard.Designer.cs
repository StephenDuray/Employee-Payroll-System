namespace EmployeeManagement
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SearchButton = new System.Windows.Forms.Button();
            this.attendanceSearchLabel = new System.Windows.Forms.Label();
            this.attendancenameLabel = new System.Windows.Forms.Label();
            this.attendanceNameBox = new System.Windows.Forms.TextBox();
            this.attendancestartDTP = new System.Windows.Forms.DateTimePicker();
            this.attendanceEndDTP = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datelabel = new System.Windows.Forms.Label();
            this.timelabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.DateeLabel = new System.Windows.Forms.Label();
            this.TimeeLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TotalemployeesQuery = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.terminatedLabelQuery = new System.Windows.Forms.Label();
            this.terminatedLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LabelActiveQuery = new System.Windows.Forms.Label();
            this.LabelActive = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.deductoinButton = new System.Windows.Forms.Button();
            this.bonusButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.payrollButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.DashboardButton = new System.Windows.Forms.Button();
            this.EmployeeButton = new System.Windows.Forms.Button();
            this.addShiftButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.attendanceButton = new System.Windows.Forms.Button();
            this.addAttendanceButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.Location = new System.Drawing.Point(347, 331);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(145, 20);
            this.searchLabel.TabIndex = 7;
            this.searchLabel.Text = "Search Employee:";
            this.searchLabel.Visible = false;
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(515, 326);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(397, 30);
            this.searchBox.TabIndex = 8;
            this.searchBox.Visible = false;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(370, 394);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(815, 299);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(918, 326);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(83, 30);
            this.SearchButton.TabIndex = 12;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Visible = false;
            // 
            // attendanceSearchLabel
            // 
            this.attendanceSearchLabel.AutoSize = true;
            this.attendanceSearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendanceSearchLabel.Location = new System.Drawing.Point(405, 331);
            this.attendanceSearchLabel.Name = "attendanceSearchLabel";
            this.attendanceSearchLabel.Size = new System.Drawing.Size(87, 20);
            this.attendanceSearchLabel.TabIndex = 14;
            this.attendanceSearchLabel.Text = "Employee:";
            this.attendanceSearchLabel.Visible = false;
            // 
            // attendancenameLabel
            // 
            this.attendancenameLabel.AutoSize = true;
            this.attendancenameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendancenameLabel.Location = new System.Drawing.Point(434, 366);
            this.attendancenameLabel.Name = "attendancenameLabel";
            this.attendancenameLabel.Size = new System.Drawing.Size(58, 20);
            this.attendancenameLabel.TabIndex = 16;
            this.attendancenameLabel.Text = "Name:";
            this.attendancenameLabel.Visible = false;
            // 
            // attendanceNameBox
            // 
            this.attendanceNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendanceNameBox.Location = new System.Drawing.Point(498, 364);
            this.attendanceNameBox.Name = "attendanceNameBox";
            this.attendanceNameBox.Size = new System.Drawing.Size(191, 30);
            this.attendanceNameBox.TabIndex = 17;
            this.attendanceNameBox.Visible = false;
            // 
            // attendancestartDTP
            // 
            this.attendancestartDTP.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendancestartDTP.Location = new System.Drawing.Point(821, 326);
            this.attendancestartDTP.Name = "attendancestartDTP";
            this.attendancestartDTP.Size = new System.Drawing.Size(200, 22);
            this.attendancestartDTP.TabIndex = 18;
            // 
            // attendanceEndDTP
            // 
            this.attendanceEndDTP.Location = new System.Drawing.Point(821, 366);
            this.attendanceEndDTP.Name = "attendanceEndDTP";
            this.attendanceEndDTP.Size = new System.Drawing.Size(200, 22);
            this.attendanceEndDTP.TabIndex = 19;
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateLabel.Location = new System.Drawing.Point(731, 371);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(84, 20);
            this.endDateLabel.TabIndex = 20;
            this.endDateLabel.Text = "End Date:";
            this.endDateLabel.Visible = false;
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateLabel.Location = new System.Drawing.Point(724, 328);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(91, 20);
            this.startDateLabel.TabIndex = 21;
            this.startDateLabel.Text = "Start Date:";
            this.startDateLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(535, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 22);
            this.label1.TabIndex = 23;
            this.label1.Text = "qwerty";
            this.label1.Visible = false;
            // 
            // datelabel
            // 
            this.datelabel.AutoSize = true;
            this.datelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelabel.Location = new System.Drawing.Point(427, 220);
            this.datelabel.Name = "datelabel";
            this.datelabel.Size = new System.Drawing.Size(64, 25);
            this.datelabel.TabIndex = 24;
            this.datelabel.Text = "Date:";
            this.datelabel.Visible = false;
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timelabel.Location = new System.Drawing.Point(424, 268);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(67, 25);
            this.timelabel.TabIndex = 25;
            this.timelabel.Text = "Time:";
            this.timelabel.Visible = false;
            this.timelabel.Click += new System.EventHandler(this.timelabel_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.deductoinButton);
            this.panel1.Controls.Add(this.bonusButton);
            this.panel1.Controls.Add(this.ExitButton);
            this.panel1.Controls.Add(this.payrollButton);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.DashboardButton);
            this.panel1.Controls.Add(this.EmployeeButton);
            this.panel1.Controls.Add(this.addShiftButton);
            this.panel1.Controls.Add(this.LogOutButton);
            this.panel1.Controls.Add(this.attendanceButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 907);
            this.panel1.TabIndex = 26;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // DateeLabel
            // 
            this.DateeLabel.AutoSize = true;
            this.DateeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateeLabel.Location = new System.Drawing.Point(366, 224);
            this.DateeLabel.Name = "DateeLabel";
            this.DateeLabel.Size = new System.Drawing.Size(55, 20);
            this.DateeLabel.TabIndex = 27;
            this.DateeLabel.Text = "Date:";
            this.DateeLabel.Visible = false;
            // 
            // TimeeLabel
            // 
            this.TimeeLabel.AutoSize = true;
            this.TimeeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeeLabel.Location = new System.Drawing.Point(366, 268);
            this.TimeeLabel.Name = "TimeeLabel";
            this.TimeeLabel.Size = new System.Drawing.Size(56, 20);
            this.TimeeLabel.TabIndex = 28;
            this.TimeeLabel.Text = "Time:";
            this.TimeeLabel.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(515, 331);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(174, 24);
            this.comboBox1.TabIndex = 29;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.pictureBox6);
            this.mainPanel.Controls.Add(this.panel4);
            this.mainPanel.Controls.Add(this.panel3);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Location = new System.Drawing.Point(326, 326);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(904, 545);
            this.mainPanel.TabIndex = 30;
            this.mainPanel.Visible = false;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.TotalemployeesQuery);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(612, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(277, 181);
            this.panel4.TabIndex = 2;
            // 
            // TotalemployeesQuery
            // 
            this.TotalemployeesQuery.AutoSize = true;
            this.TotalemployeesQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TotalemployeesQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalemployeesQuery.Location = new System.Drawing.Point(26, 51);
            this.TotalemployeesQuery.Name = "TotalemployeesQuery";
            this.TotalemployeesQuery.Size = new System.Drawing.Size(0, 51);
            this.TotalemployeesQuery.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total Employees";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.terminatedLabelQuery);
            this.panel3.Controls.Add(this.terminatedLabel);
            this.panel3.Location = new System.Drawing.Point(314, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(277, 181);
            this.panel3.TabIndex = 1;
            // 
            // terminatedLabelQuery
            // 
            this.terminatedLabelQuery.AutoSize = true;
            this.terminatedLabelQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.terminatedLabelQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terminatedLabelQuery.Location = new System.Drawing.Point(43, 52);
            this.terminatedLabelQuery.Name = "terminatedLabelQuery";
            this.terminatedLabelQuery.Size = new System.Drawing.Size(0, 51);
            this.terminatedLabelQuery.TabIndex = 3;
            // 
            // terminatedLabel
            // 
            this.terminatedLabel.AutoSize = true;
            this.terminatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terminatedLabel.Location = new System.Drawing.Point(93, 135);
            this.terminatedLabel.Name = "terminatedLabel";
            this.terminatedLabel.Size = new System.Drawing.Size(168, 32);
            this.terminatedLabel.TabIndex = 2;
            this.terminatedLabel.Text = "Terminated";
            this.terminatedLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.LabelActiveQuery);
            this.panel2.Controls.Add(this.LabelActive);
            this.panel2.Location = new System.Drawing.Point(14, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 181);
            this.panel2.TabIndex = 0;
            // 
            // LabelActiveQuery
            // 
            this.LabelActiveQuery.AutoSize = true;
            this.LabelActiveQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelActiveQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelActiveQuery.Location = new System.Drawing.Point(49, 54);
            this.LabelActiveQuery.Name = "LabelActiveQuery";
            this.LabelActiveQuery.Size = new System.Drawing.Size(0, 51);
            this.LabelActiveQuery.TabIndex = 1;
            // 
            // LabelActive
            // 
            this.LabelActive.AutoSize = true;
            this.LabelActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelActive.Location = new System.Drawing.Point(144, 135);
            this.LabelActive.Name = "LabelActive";
            this.LabelActive.Size = new System.Drawing.Size(103, 36);
            this.LabelActive.TabIndex = 0;
            this.LabelActive.Text = "Active";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::EmployeeManagement.Properties.Resources.scan;
            this.button1.Location = new System.Drawing.Point(438, 711);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 63);
            this.button1.TabIndex = 4;
            this.button1.Text = " Scan";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::EmployeeManagement.Properties.Resources.working;
            this.pictureBox6.Location = new System.Drawing.Point(11, 269);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(881, 264);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 3;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::EmployeeManagement.Properties.Resources.activeje;
            this.pictureBox3.Location = new System.Drawing.Point(120, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(142, 129);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::EmployeeManagement.Properties.Resources.active;
            this.pictureBox4.Location = new System.Drawing.Point(99, 7);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(175, 125);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::EmployeeManagement.Properties.Resources.emops;
            this.pictureBox5.Location = new System.Drawing.Point(132, 7);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(133, 127);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // deductoinButton
            // 
            this.deductoinButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deductoinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deductoinButton.Image = global::EmployeeManagement.Properties.Resources.deduction1;
            this.deductoinButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deductoinButton.Location = new System.Drawing.Point(20, 655);
            this.deductoinButton.Name = "deductoinButton";
            this.deductoinButton.Size = new System.Drawing.Size(278, 59);
            this.deductoinButton.TabIndex = 31;
            this.deductoinButton.Text = "      Deduction";
            this.deductoinButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deductoinButton.UseVisualStyleBackColor = true;
            this.deductoinButton.Click += new System.EventHandler(this.deductoinButton_Click);
            // 
            // bonusButton
            // 
            this.bonusButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bonusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bonusButton.Image = global::EmployeeManagement.Properties.Resources.bonus;
            this.bonusButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bonusButton.Location = new System.Drawing.Point(21, 727);
            this.bonusButton.Name = "bonusButton";
            this.bonusButton.Size = new System.Drawing.Size(278, 59);
            this.bonusButton.TabIndex = 30;
            this.bonusButton.Text = "      Bonus";
            this.bonusButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bonusButton.UseVisualStyleBackColor = true;
            this.bonusButton.Click += new System.EventHandler(this.bonusButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.White;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Image = global::EmployeeManagement.Properties.Resources.exitButton1;
            this.ExitButton.Location = new System.Drawing.Point(197, 828);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(102, 48);
            this.ExitButton.TabIndex = 29;
            this.ExitButton.Text = " Exit";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // payrollButton
            // 
            this.payrollButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.payrollButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payrollButton.Image = global::EmployeeManagement.Properties.Resources.icons8_money_transfer_48;
            this.payrollButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.payrollButton.Location = new System.Drawing.Point(21, 586);
            this.payrollButton.Name = "payrollButton";
            this.payrollButton.Size = new System.Drawing.Size(278, 59);
            this.payrollButton.TabIndex = 15;
            this.payrollButton.Text = "      Payroll";
            this.payrollButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.payrollButton.UseVisualStyleBackColor = true;
            this.payrollButton.Click += new System.EventHandler(this.payrollButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = global::EmployeeManagement.Properties.Resources.Logo;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(312, 260);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // DashboardButton
            // 
            this.DashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DashboardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashboardButton.Image = global::EmployeeManagement.Properties.Resources.icons8_dashboard_layout_24;
            this.DashboardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DashboardButton.Location = new System.Drawing.Point(21, 293);
            this.DashboardButton.Name = "DashboardButton";
            this.DashboardButton.Size = new System.Drawing.Size(278, 59);
            this.DashboardButton.TabIndex = 0;
            this.DashboardButton.Text = "         Dashboard   ";
            this.DashboardButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DashboardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DashboardButton.UseVisualStyleBackColor = true;
            this.DashboardButton.Click += new System.EventHandler(this.DashboardButton_Click);
            // 
            // EmployeeButton
            // 
            this.EmployeeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EmployeeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeButton.Image = global::EmployeeManagement.Properties.Resources.employee1;
            this.EmployeeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EmployeeButton.Location = new System.Drawing.Point(21, 364);
            this.EmployeeButton.Name = "EmployeeButton";
            this.EmployeeButton.Size = new System.Drawing.Size(278, 59);
            this.EmployeeButton.TabIndex = 1;
            this.EmployeeButton.Text = "     Employees";
            this.EmployeeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EmployeeButton.UseVisualStyleBackColor = true;
            this.EmployeeButton.Click += new System.EventHandler(this.EmployeeButton_Click);
            // 
            // addShiftButton
            // 
            this.addShiftButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addShiftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addShiftButton.Image = global::EmployeeManagement.Properties.Resources.addShift;
            this.addShiftButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addShiftButton.Location = new System.Drawing.Point(21, 514);
            this.addShiftButton.Name = "addShiftButton";
            this.addShiftButton.Size = new System.Drawing.Size(278, 59);
            this.addShiftButton.TabIndex = 3;
            this.addShiftButton.Text = "     Assign Shift";
            this.addShiftButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addShiftButton.UseVisualStyleBackColor = true;
            this.addShiftButton.Click += new System.EventHandler(this.addShiftButton_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.Image = global::EmployeeManagement.Properties.Resources.icons8_logout_rounded_30;
            this.LogOutButton.Location = new System.Drawing.Point(21, 828);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(119, 48);
            this.LogOutButton.TabIndex = 5;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.LogOutButton.UseVisualStyleBackColor = true;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // attendanceButton
            // 
            this.attendanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.attendanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendanceButton.Image = global::EmployeeManagement.Properties.Resources.nda;
            this.attendanceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.attendanceButton.Location = new System.Drawing.Point(21, 441);
            this.attendanceButton.Name = "attendanceButton";
            this.attendanceButton.Size = new System.Drawing.Size(278, 59);
            this.attendanceButton.TabIndex = 13;
            this.attendanceButton.Text = "        Attendance";
            this.attendanceButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.attendanceButton.UseVisualStyleBackColor = true;
            this.attendanceButton.Click += new System.EventHandler(this.attendanceButton_Click);
            // 
            // addAttendanceButton
            // 
            this.addAttendanceButton.BackColor = System.Drawing.Color.White;
            this.addAttendanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addAttendanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAttendanceButton.Image = global::EmployeeManagement.Properties.Resources.icons8_add_button_48;
            this.addAttendanceButton.Location = new System.Drawing.Point(985, 698);
            this.addAttendanceButton.Name = "addAttendanceButton";
            this.addAttendanceButton.Size = new System.Drawing.Size(200, 65);
            this.addAttendanceButton.TabIndex = 22;
            this.addAttendanceButton.Text = " Add";
            this.addAttendanceButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addAttendanceButton.UseVisualStyleBackColor = false;
            this.addAttendanceButton.Click += new System.EventHandler(this.addAttendanceButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.White;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Image = global::EmployeeManagement.Properties.Resources.update;
            this.UpdateButton.Location = new System.Drawing.Point(900, 711);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(200, 65);
            this.UpdateButton.TabIndex = 10;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Visible = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.White;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Image = global::EmployeeManagement.Properties.Resources.icons8_add_button_48;
            this.AddButton.Location = new System.Drawing.Point(438, 711);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(200, 65);
            this.AddButton.TabIndex = 9;
            this.AddButton.Text = " Add";
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Visible = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::EmployeeManagement.Properties.Resources.employee;
            this.pictureBox1.Location = new System.Drawing.Point(370, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(860, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1253, 907);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.TimeeLabel);
            this.Controls.Add(this.DateeLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.timelabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addAttendanceButton);
            this.Controls.Add(this.datelabel);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.attendanceEndDTP);
            this.Controls.Add(this.attendancestartDTP);
            this.Controls.Add(this.attendanceNameBox);
            this.Controls.Add(this.attendancenameLabel);
            this.Controls.Add(this.attendanceSearchLabel);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DashboardButton;
        private System.Windows.Forms.Button EmployeeButton;
        private System.Windows.Forms.Button addShiftButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button attendanceButton;
        private System.Windows.Forms.Label attendanceSearchLabel;
        private System.Windows.Forms.Label attendancenameLabel;
        private System.Windows.Forms.TextBox attendanceNameBox;
        private System.Windows.Forms.DateTimePicker attendancestartDTP;
        private System.Windows.Forms.DateTimePicker attendanceEndDTP;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Button addAttendanceButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label datelabel;
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label DateeLabel;
        private System.Windows.Forms.Label TimeeLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button payrollButton;
        private System.Windows.Forms.Button deductoinButton;
        private System.Windows.Forms.Button bonusButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LabelActive;
        private System.Windows.Forms.Label LabelActiveQuery;
        private System.Windows.Forms.Label terminatedLabel;
        private System.Windows.Forms.Label terminatedLabelQuery;
        private System.Windows.Forms.Label TotalemployeesQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button button1;
    }
}