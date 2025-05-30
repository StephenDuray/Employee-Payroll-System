namespace EmployeeManagement
{
    partial class AddAttendance
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.TimeOut = new System.Windows.Forms.Label();
            this.TimeIn = new System.Windows.Forms.Label();
            this.lateLabel = new System.Windows.Forms.Label();
            this.undertimeLabel = new System.Windows.Forms.Label();
            this.totalhrsworkLabel = new System.Windows.Forms.Label();
            this.lateBox = new System.Windows.Forms.TextBox();
            this.undertimeBox = new System.Windows.Forms.TextBox();
            this.totalworkBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.addAttendButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(96, 92);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(73, 22);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name :";
            // 
            // dtp2
            // 
            this.dtp2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp2.Location = new System.Drawing.Point(237, 176);
            this.dtp2.Margin = new System.Windows.Forms.Padding(4);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(163, 22);
            this.dtp2.TabIndex = 4;
            // 
            // dtp1
            // 
            this.dtp1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.Location = new System.Drawing.Point(237, 134);
            this.dtp1.Margin = new System.Windows.Forms.Padding(4);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(163, 22);
            this.dtp1.TabIndex = 3;
            // 
            // TimeOut
            // 
            this.TimeOut.AutoSize = true;
            this.TimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeOut.Location = new System.Drawing.Point(82, 174);
            this.TimeOut.Name = "TimeOut";
            this.TimeOut.Size = new System.Drawing.Size(98, 22);
            this.TimeOut.TabIndex = 5;
            this.TimeOut.Text = "Time Out:";
            // 
            // TimeIn
            // 
            this.TimeIn.AutoSize = true;
            this.TimeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeIn.Location = new System.Drawing.Point(92, 137);
            this.TimeIn.Name = "TimeIn";
            this.TimeIn.Size = new System.Drawing.Size(82, 22);
            this.TimeIn.TabIndex = 6;
            this.TimeIn.Text = "Time In:";
            // 
            // lateLabel
            // 
            this.lateLabel.AutoSize = true;
            this.lateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lateLabel.Location = new System.Drawing.Point(56, 256);
            this.lateLabel.Name = "lateLabel";
            this.lateLabel.Size = new System.Drawing.Size(138, 22);
            this.lateLabel.TabIndex = 9;
            this.lateLabel.Text = "Late (minutes)";
            // 
            // undertimeLabel
            // 
            this.undertimeLabel.AutoSize = true;
            this.undertimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undertimeLabel.Location = new System.Drawing.Point(23, 296);
            this.undertimeLabel.Name = "undertimeLabel";
            this.undertimeLabel.Size = new System.Drawing.Size(190, 22);
            this.undertimeLabel.TabIndex = 11;
            this.undertimeLabel.Text = "Undertime (minutes)";
            // 
            // totalhrsworkLabel
            // 
            this.totalhrsworkLabel.AutoSize = true;
            this.totalhrsworkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalhrsworkLabel.Location = new System.Drawing.Point(18, 338);
            this.totalhrsworkLabel.Name = "totalhrsworkLabel";
            this.totalhrsworkLabel.Size = new System.Drawing.Size(189, 22);
            this.totalhrsworkLabel.TabIndex = 10;
            this.totalhrsworkLabel.Text = "Total Hours Worked";
            // 
            // lateBox
            // 
            this.lateBox.BackColor = System.Drawing.Color.LightGray;
            this.lateBox.Location = new System.Drawing.Point(237, 258);
            this.lateBox.Name = "lateBox";
            this.lateBox.Size = new System.Drawing.Size(163, 22);
            this.lateBox.TabIndex = 13;
            // 
            // undertimeBox
            // 
            this.undertimeBox.BackColor = System.Drawing.Color.LightGray;
            this.undertimeBox.Location = new System.Drawing.Point(237, 298);
            this.undertimeBox.Name = "undertimeBox";
            this.undertimeBox.Size = new System.Drawing.Size(163, 22);
            this.undertimeBox.TabIndex = 14;
            // 
            // totalworkBox
            // 
            this.totalworkBox.BackColor = System.Drawing.Color.LightGray;
            this.totalworkBox.Location = new System.Drawing.Point(237, 340);
            this.totalworkBox.Name = "totalworkBox";
            this.totalworkBox.Size = new System.Drawing.Size(163, 22);
            this.totalworkBox.TabIndex = 15;
            this.totalworkBox.TextChanged += new System.EventHandler(this.totalworkBox_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(237, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(163, 24);
            this.comboBox1.TabIndex = 26;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.White;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Image = global::EmployeeManagement.Properties.Resources.exitButton2;
            this.BackButton.Location = new System.Drawing.Point(0, 0);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(104, 52);
            this.BackButton.TabIndex = 25;
            this.BackButton.Text = "Back";
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // addAttendButton
            // 
            this.addAttendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addAttendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAttendButton.Image = global::EmployeeManagement.Properties.Resources.addAttendance;
            this.addAttendButton.Location = new System.Drawing.Point(217, 378);
            this.addAttendButton.Name = "addAttendButton";
            this.addAttendButton.Size = new System.Drawing.Size(163, 60);
            this.addAttendButton.TabIndex = 16;
            this.addAttendButton.Text = " Add ";
            this.addAttendButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addAttendButton.UseVisualStyleBackColor = true;
            this.addAttendButton.Click += new System.EventHandler(this.addAttendButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 22);
            this.label1.TabIndex = 27;
            this.label1.Text = "Status:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(237, 214);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(74, 20);
            this.radioButton1.TabIndex = 28;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Present";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(327, 215);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(70, 20);
            this.radioButton2.TabIndex = 29;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Absent";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // AddAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(568, 450);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.addAttendButton);
            this.Controls.Add(this.totalworkBox);
            this.Controls.Add(this.undertimeBox);
            this.Controls.Add(this.lateBox);
            this.Controls.Add(this.undertimeLabel);
            this.Controls.Add(this.totalhrsworkLabel);
            this.Controls.Add(this.lateLabel);
            this.Controls.Add(this.TimeIn);
            this.Controls.Add(this.TimeOut);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddAttendance";
            this.Load += new System.EventHandler(this.AddAttendance_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label TimeOut;
        private System.Windows.Forms.Label TimeIn;
        private System.Windows.Forms.Label lateLabel;
        private System.Windows.Forms.Label undertimeLabel;
        private System.Windows.Forms.Label totalhrsworkLabel;
        private System.Windows.Forms.TextBox lateBox;
        private System.Windows.Forms.TextBox undertimeBox;
        private System.Windows.Forms.TextBox totalworkBox;
        private System.Windows.Forms.Button addAttendButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}