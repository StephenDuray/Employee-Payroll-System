namespace EmployeeManagement
{
    partial class Leave
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
            this.EmployeeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.AddButton = new System.Windows.Forms.Button();
            this.isLeavewithPay = new System.Windows.Forms.RadioButton();
            this.isLeavewithouPayCheckBox = new System.Windows.Forms.RadioButton();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Fname
            // 
            this.Fname.AutoSize = true;
            this.Fname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fname.Location = new System.Drawing.Point(106, 110);
            this.Fname.Name = "Fname";
            this.Fname.Size = new System.Drawing.Size(73, 22);
            this.Fname.TabIndex = 2;
            this.Fname.Text = "Name :";
            // 
            // EmployeeBox
            // 
            this.EmployeeBox.FormattingEnabled = true;
            this.EmployeeBox.Location = new System.Drawing.Point(211, 112);
            this.EmployeeBox.Name = "EmployeeBox";
            this.EmployeeBox.Size = new System.Drawing.Size(226, 24);
            this.EmployeeBox.TabIndex = 60;
            this.EmployeeBox.SelectedIndexChanged += new System.EventHandler(this.EmployeeBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 22);
            this.label1.TabIndex = 61;
            this.label1.Text = "Leave Start: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 22);
            this.label2.TabIndex = 62;
            this.label2.Text = "Leave End: ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(211, 171);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(226, 22);
            this.dateTimePicker1.TabIndex = 63;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(211, 220);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(226, 22);
            this.dateTimePicker2.TabIndex = 64;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.White;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Image = global::EmployeeManagement.Properties.Resources.addEmployee;
            this.AddButton.Location = new System.Drawing.Point(211, 305);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(226, 60);
            this.AddButton.TabIndex = 65;
            this.AddButton.Text = "Set Leave";
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // isLeavewithPay
            // 
            this.isLeavewithPay.AutoSize = true;
            this.isLeavewithPay.Location = new System.Drawing.Point(200, 262);
            this.isLeavewithPay.Name = "isLeavewithPay";
            this.isLeavewithPay.Size = new System.Drawing.Size(118, 20);
            this.isLeavewithPay.TabIndex = 66;
            this.isLeavewithPay.TabStop = true;
            this.isLeavewithPay.Text = "Leave with Pay";
            this.isLeavewithPay.UseVisualStyleBackColor = true;
            // 
            // isLeavewithouPayCheckBox
            // 
            this.isLeavewithouPayCheckBox.AutoSize = true;
            this.isLeavewithouPayCheckBox.Location = new System.Drawing.Point(324, 262);
            this.isLeavewithouPayCheckBox.Name = "isLeavewithouPayCheckBox";
            this.isLeavewithouPayCheckBox.Size = new System.Drawing.Size(123, 20);
            this.isLeavewithouPayCheckBox.TabIndex = 67;
            this.isLeavewithouPayCheckBox.TabStop = true;
            this.isLeavewithouPayCheckBox.Text = "Leave W/O Pay";
            this.isLeavewithouPayCheckBox.UseVisualStyleBackColor = true;
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
            this.BackButton.TabIndex = 68;
            this.BackButton.Text = "Back";
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Leave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.isLeavewithouPayCheckBox);
            this.Controls.Add(this.isLeavewithPay);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmployeeBox);
            this.Controls.Add(this.Fname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Leave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QrScanner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Fname;
        private System.Windows.Forms.ComboBox EmployeeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.RadioButton isLeavewithPay;
        private System.Windows.Forms.RadioButton isLeavewithouPayCheckBox;
        private System.Windows.Forms.Button BackButton;
    }
}