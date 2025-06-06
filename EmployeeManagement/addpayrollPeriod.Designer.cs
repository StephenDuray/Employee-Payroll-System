namespace EmployeeManagement
{
    partial class addpayrollPeriod
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
            this.BackButton = new System.Windows.Forms.Button();
            this.endperiodLabel = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.periodStartLabel = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.addAttendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.BackButton.TabIndex = 26;
            this.BackButton.Text = "Back";
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click_1);
            // 
            // endperiodLabel
            // 
            this.endperiodLabel.AutoSize = true;
            this.endperiodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endperiodLabel.Location = new System.Drawing.Point(57, 155);
            this.endperiodLabel.Name = "endperiodLabel";
            this.endperiodLabel.Size = new System.Drawing.Size(109, 22);
            this.endperiodLabel.TabIndex = 60;
            this.endperiodLabel.Text = "Period End";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(114, 207);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(52, 22);
            this.date.TabIndex = 59;
            this.date.Text = "Date";
            // 
            // periodStartLabel
            // 
            this.periodStartLabel.AutoSize = true;
            this.periodStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodStartLabel.Location = new System.Drawing.Point(57, 105);
            this.periodStartLabel.Name = "periodStartLabel";
            this.periodStartLabel.Size = new System.Drawing.Size(117, 22);
            this.periodStartLabel.TabIndex = 58;
            this.periodStartLabel.Text = "Period Start";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(206, 105);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(245, 22);
            this.dateTimePicker1.TabIndex = 61;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(206, 155);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(245, 22);
            this.dateTimePicker2.TabIndex = 62;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(206, 207);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(245, 22);
            this.dateTimePicker3.TabIndex = 63;
            // 
            // addAttendButton
            // 
            this.addAttendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addAttendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAttendButton.Image = global::EmployeeManagement.Properties.Resources.addAttendance;
            this.addAttendButton.Location = new System.Drawing.Point(206, 251);
            this.addAttendButton.Name = "addAttendButton";
            this.addAttendButton.Size = new System.Drawing.Size(200, 60);
            this.addAttendButton.TabIndex = 64;
            this.addAttendButton.Text = " Add ";
            this.addAttendButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addAttendButton.UseVisualStyleBackColor = true;
            this.addAttendButton.Click += new System.EventHandler(this.addAttendButton_Click);
            // 
            // addpayrollPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addAttendButton);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.endperiodLabel);
            this.Controls.Add(this.date);
            this.Controls.Add(this.periodStartLabel);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addpayrollPeriod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addpayrollPeriod";
            this.Load += new System.EventHandler(this.addpayrollPeriod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label endperiodLabel;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label periodStartLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Button addAttendButton;
    }
}