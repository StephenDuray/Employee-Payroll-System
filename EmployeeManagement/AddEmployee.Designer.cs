namespace EmployeeManagement
{
    partial class AddEmployee
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
            this.Fname = new System.Windows.Forms.Label();
            this.Lname = new System.Windows.Forms.Label();
            this.Gender = new System.Windows.Forms.Label();
            this.DOB = new System.Windows.Forms.Label();
            this.FnameBox = new System.Windows.Forms.TextBox();
            this.LnameBox = new System.Windows.Forms.TextBox();
            this.dateTimepicker = new System.Windows.Forms.DateTimePicker();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.positionLabel = new System.Windows.Forms.Label();
            this.positionBox = new System.Windows.Forms.TextBox();
            this.hourlyLabel = new System.Windows.Forms.Label();
            this.hourlyRateBox = new System.Windows.Forms.TextBox();
            this.contactNumberLabel = new System.Windows.Forms.Label();
            this.contactnumberBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.DepartmentLabel = new System.Windows.Forms.Label();
            this.departmentBox = new System.Windows.Forms.ComboBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.addImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Fname
            // 
            this.Fname.AutoSize = true;
            this.Fname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fname.Location = new System.Drawing.Point(40, 91);
            this.Fname.Name = "Fname";
            this.Fname.Size = new System.Drawing.Size(113, 22);
            this.Fname.TabIndex = 1;
            this.Fname.Text = "First Name:";
            this.Fname.Click += new System.EventHandler(this.label1_Click);
            // 
            // Lname
            // 
            this.Lname.AutoSize = true;
            this.Lname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lname.Location = new System.Drawing.Point(42, 134);
            this.Lname.Name = "Lname";
            this.Lname.Size = new System.Drawing.Size(111, 22);
            this.Lname.TabIndex = 2;
            this.Lname.Text = "Last Name:";
            // 
            // Gender
            // 
            this.Gender.AutoSize = true;
            this.Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gender.Location = new System.Drawing.Point(70, 173);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(82, 22);
            this.Gender.TabIndex = 3;
            this.Gender.Text = "Gender:";
            // 
            // DOB
            // 
            this.DOB.AutoSize = true;
            this.DOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOB.Location = new System.Drawing.Point(18, 211);
            this.DOB.Name = "DOB";
            this.DOB.Size = new System.Drawing.Size(129, 22);
            this.DOB.TabIndex = 4;
            this.DOB.Text = "Date of Birth:";
            // 
            // FnameBox
            // 
            this.FnameBox.BackColor = System.Drawing.Color.LightGray;
            this.FnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FnameBox.Location = new System.Drawing.Point(183, 92);
            this.FnameBox.Name = "FnameBox";
            this.FnameBox.Size = new System.Drawing.Size(241, 28);
            this.FnameBox.TabIndex = 7;
            // 
            // LnameBox
            // 
            this.LnameBox.BackColor = System.Drawing.Color.LightGray;
            this.LnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnameBox.Location = new System.Drawing.Point(183, 137);
            this.LnameBox.Name = "LnameBox";
            this.LnameBox.Size = new System.Drawing.Size(241, 28);
            this.LnameBox.TabIndex = 8;
            this.LnameBox.TextChanged += new System.EventHandler(this.LnameBox_TextChanged);
            // 
            // dateTimepicker
            // 
            this.dateTimepicker.CalendarMonthBackground = System.Drawing.Color.LightGray;
            this.dateTimepicker.Location = new System.Drawing.Point(183, 211);
            this.dateTimepicker.Name = "dateTimepicker";
            this.dateTimepicker.Size = new System.Drawing.Size(241, 22);
            this.dateTimepicker.TabIndex = 10;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(194, 176);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 20);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Male";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(295, 176);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 20);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Female";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionLabel.Location = new System.Drawing.Point(49, 248);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(88, 22);
            this.positionLabel.TabIndex = 14;
            this.positionLabel.Text = "Position:";
            // 
            // positionBox
            // 
            this.positionBox.BackColor = System.Drawing.Color.LightGray;
            this.positionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionBox.Location = new System.Drawing.Point(183, 248);
            this.positionBox.Name = "positionBox";
            this.positionBox.Size = new System.Drawing.Size(241, 28);
            this.positionBox.TabIndex = 15;
            // 
            // hourlyLabel
            // 
            this.hourlyLabel.AutoSize = true;
            this.hourlyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hourlyLabel.Location = new System.Drawing.Point(17, 292);
            this.hourlyLabel.Name = "hourlyLabel";
            this.hourlyLabel.Size = new System.Drawing.Size(122, 22);
            this.hourlyLabel.TabIndex = 16;
            this.hourlyLabel.Text = "Hourly Rate:";
            // 
            // hourlyRateBox
            // 
            this.hourlyRateBox.BackColor = System.Drawing.Color.LightGray;
            this.hourlyRateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hourlyRateBox.Location = new System.Drawing.Point(183, 292);
            this.hourlyRateBox.Name = "hourlyRateBox";
            this.hourlyRateBox.Size = new System.Drawing.Size(241, 28);
            this.hourlyRateBox.TabIndex = 17;
            // 
            // contactNumberLabel
            // 
            this.contactNumberLabel.AutoSize = true;
            this.contactNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNumberLabel.Location = new System.Drawing.Point(10, 342);
            this.contactNumberLabel.Name = "contactNumberLabel";
            this.contactNumberLabel.Size = new System.Drawing.Size(148, 22);
            this.contactNumberLabel.TabIndex = 18;
            this.contactNumberLabel.Text = "Phone Number:";
            // 
            // contactnumberBox
            // 
            this.contactnumberBox.BackColor = System.Drawing.Color.LightGray;
            this.contactnumberBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactnumberBox.Location = new System.Drawing.Point(183, 339);
            this.contactnumberBox.Name = "contactnumberBox";
            this.contactnumberBox.Size = new System.Drawing.Size(241, 28);
            this.contactnumberBox.TabIndex = 19;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(59, 386);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(65, 22);
            this.EmailLabel.TabIndex = 20;
            this.EmailLabel.Text = "Email:";
            // 
            // EmailBox
            // 
            this.EmailBox.BackColor = System.Drawing.Color.LightGray;
            this.EmailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailBox.Location = new System.Drawing.Point(183, 380);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(241, 28);
            this.EmailBox.TabIndex = 21;
            // 
            // DepartmentLabel
            // 
            this.DepartmentLabel.AutoSize = true;
            this.DepartmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentLabel.Location = new System.Drawing.Point(28, 432);
            this.DepartmentLabel.Name = "DepartmentLabel";
            this.DepartmentLabel.Size = new System.Drawing.Size(119, 22);
            this.DepartmentLabel.TabIndex = 22;
            this.DepartmentLabel.Text = "Department:";
            // 
            // departmentBox
            // 
            this.departmentBox.BackColor = System.Drawing.Color.White;
            this.departmentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentBox.FormattingEnabled = true;
            this.departmentBox.Location = new System.Drawing.Point(183, 431);
            this.departmentBox.Name = "departmentBox";
            this.departmentBox.Size = new System.Drawing.Size(241, 28);
            this.departmentBox.TabIndex = 23;
            this.departmentBox.SelectedIndexChanged += new System.EventHandler(this.departmentBox_SelectedIndexChanged);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.White;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Image = global::EmployeeManagement.Properties.Resources.exitButton1;
            this.ExitButton.Location = new System.Drawing.Point(775, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(96, 52);
            this.ExitButton.TabIndex = 25;
            this.ExitButton.Text = " Exit";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Visible = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click_1);
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
            this.BackButton.TabIndex = 24;
            this.BackButton.Text = "Back";
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.White;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Image = global::EmployeeManagement.Properties.Resources.addEmployee;
            this.AddButton.Location = new System.Drawing.Point(555, 486);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(178, 60);
            this.AddButton.TabIndex = 13;
            this.AddButton.Text = "Add";
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(527, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // addImage
            // 
            this.addImage.BackColor = System.Drawing.Color.White;
            this.addImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addImage.Image = global::EmployeeManagement.Properties.Resources.addEmployee;
            this.addImage.Location = new System.Drawing.Point(555, 380);
            this.addImage.Name = "addImage";
            this.addImage.Size = new System.Drawing.Size(178, 60);
            this.addImage.TabIndex = 27;
            this.addImage.Text = "Image";
            this.addImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addImage.UseVisualStyleBackColor = false;
            this.addImage.Click += new System.EventHandler(this.addImage_Click);
            // 
            // AddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(869, 581);
            this.Controls.Add(this.addImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.departmentBox);
            this.Controls.Add(this.DepartmentLabel);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.contactnumberBox);
            this.Controls.Add(this.contactNumberLabel);
            this.Controls.Add(this.hourlyRateBox);
            this.Controls.Add(this.hourlyLabel);
            this.Controls.Add(this.positionBox);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.dateTimepicker);
            this.Controls.Add(this.LnameBox);
            this.Controls.Add(this.FnameBox);
            this.Controls.Add(this.DOB);
            this.Controls.Add(this.Gender);
            this.Controls.Add(this.Lname);
            this.Controls.Add(this.Fname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.AddEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Fname;
        private System.Windows.Forms.Label Lname;
        private System.Windows.Forms.Label Gender;
        private System.Windows.Forms.Label DOB;
        private System.Windows.Forms.TextBox FnameBox;
        private System.Windows.Forms.TextBox LnameBox;
        private System.Windows.Forms.DateTimePicker dateTimepicker;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.TextBox positionBox;
        private System.Windows.Forms.Label hourlyLabel;
        private System.Windows.Forms.TextBox hourlyRateBox;
        private System.Windows.Forms.Label contactNumberLabel;
        private System.Windows.Forms.TextBox contactnumberBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.Label DepartmentLabel;
        private System.Windows.Forms.ComboBox departmentBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button addImage;
    }
}