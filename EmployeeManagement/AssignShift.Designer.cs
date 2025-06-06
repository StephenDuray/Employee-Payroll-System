namespace EmployeeManagement
{
    partial class AssignShift
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
            this.employeeNameLabel = new System.Windows.Forms.Label();
            this.shiftTypeLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.shiftTypeBox = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.BackButton = new System.Windows.Forms.Button();
            this.assignShiftButton = new System.Windows.Forms.Button();
            this.assignShiftempBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // employeeNameLabel
            // 
            this.employeeNameLabel.AutoSize = true;
            this.employeeNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeNameLabel.Location = new System.Drawing.Point(77, 120);
            this.employeeNameLabel.Name = "employeeNameLabel";
            this.employeeNameLabel.Size = new System.Drawing.Size(156, 20);
            this.employeeNameLabel.TabIndex = 0;
            this.employeeNameLabel.Text = "Employee Name: ";
            // 
            // shiftTypeLabel
            // 
            this.shiftTypeLabel.AutoSize = true;
            this.shiftTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shiftTypeLabel.Location = new System.Drawing.Point(93, 171);
            this.shiftTypeLabel.Name = "shiftTypeLabel";
            this.shiftTypeLabel.Size = new System.Drawing.Size(106, 20);
            this.shiftTypeLabel.TabIndex = 1;
            this.shiftTypeLabel.Text = "Shift Type: ";
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateLabel.Location = new System.Drawing.Point(97, 231);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(102, 20);
            this.startDateLabel.TabIndex = 2;
            this.startDateLabel.Text = "Start Date:";
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateLabel.Location = new System.Drawing.Point(106, 288);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(93, 20);
            this.endDateLabel.TabIndex = 3;
            this.endDateLabel.Text = "End Date:";
            // 
            // shiftTypeBox
            // 
            this.shiftTypeBox.FormattingEnabled = true;
            this.shiftTypeBox.Location = new System.Drawing.Point(239, 169);
            this.shiftTypeBox.Name = "shiftTypeBox";
            this.shiftTypeBox.Size = new System.Drawing.Size(228, 24);
            this.shiftTypeBox.TabIndex = 5;
            this.shiftTypeBox.SelectedIndexChanged += new System.EventHandler(this.shiftyTypeBox_SelectedIndexChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Location = new System.Drawing.Point(239, 229);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(228, 22);
            this.dtpStart.TabIndex = 6;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Location = new System.Drawing.Point(239, 288);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(228, 22);
            this.dtpEnd.TabIndex = 7;
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
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click_1);
            // 
            // assignShiftButton
            // 
            this.assignShiftButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.assignShiftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignShiftButton.Image = global::EmployeeManagement.Properties.Resources.buttonassign;
            this.assignShiftButton.Location = new System.Drawing.Point(228, 345);
            this.assignShiftButton.Name = "assignShiftButton";
            this.assignShiftButton.Size = new System.Drawing.Size(185, 60);
            this.assignShiftButton.TabIndex = 8;
            this.assignShiftButton.Text = "Apply  Shift";
            this.assignShiftButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.assignShiftButton.UseVisualStyleBackColor = true;
            this.assignShiftButton.Click += new System.EventHandler(this.assignShiftButton_Click);
            // 
            // assignShiftempBox
            // 
            this.assignShiftempBox.FormattingEnabled = true;
            this.assignShiftempBox.Location = new System.Drawing.Point(239, 116);
            this.assignShiftempBox.Name = "assignShiftempBox";
            this.assignShiftempBox.Size = new System.Drawing.Size(228, 24);
            this.assignShiftempBox.TabIndex = 26;
            this.assignShiftempBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // AssignShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(555, 434);
            this.Controls.Add(this.assignShiftempBox);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.assignShiftButton);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.shiftTypeBox);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.shiftTypeLabel);
            this.Controls.Add(this.employeeNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AssignShift";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssignShift";
            this.Load += new System.EventHandler(this.AssignShift_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label employeeNameLabel;
        private System.Windows.Forms.Label shiftTypeLabel;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.ComboBox shiftTypeBox;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button assignShiftButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ComboBox assignShiftempBox;
    }
}