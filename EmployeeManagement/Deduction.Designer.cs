namespace EmployeeManagement
{
    partial class Deduction
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
            this.payollBackButton = new System.Windows.Forms.Button();
            this.employeeName = new System.Windows.Forms.Label();
            this.EmployeeBox = new System.Windows.Forms.ComboBox();
            this.deductionlabel = new System.Windows.Forms.Label();
            this.deductionBox = new System.Windows.Forms.ComboBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountBox = new System.Windows.Forms.TextBox();
            this.deductionAddButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // payollBackButton
            // 
            this.payollBackButton.BackColor = System.Drawing.Color.White;
            this.payollBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.payollBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payollBackButton.Image = global::EmployeeManagement.Properties.Resources.exitButton2;
            this.payollBackButton.Location = new System.Drawing.Point(0, 0);
            this.payollBackButton.Name = "payollBackButton";
            this.payollBackButton.Size = new System.Drawing.Size(104, 52);
            this.payollBackButton.TabIndex = 54;
            this.payollBackButton.Text = "Back";
            this.payollBackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.payollBackButton.UseVisualStyleBackColor = false;
            this.payollBackButton.Click += new System.EventHandler(this.payollBackButton_Click);
            // 
            // employeeName
            // 
            this.employeeName.AutoSize = true;
            this.employeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeName.Location = new System.Drawing.Point(15, 99);
            this.employeeName.Name = "employeeName";
            this.employeeName.Size = new System.Drawing.Size(150, 20);
            this.employeeName.TabIndex = 60;
            this.employeeName.Text = "Employee Name:";
            // 
            // EmployeeBox
            // 
            this.EmployeeBox.FormattingEnabled = true;
            this.EmployeeBox.Location = new System.Drawing.Point(184, 99);
            this.EmployeeBox.Name = "EmployeeBox";
            this.EmployeeBox.Size = new System.Drawing.Size(175, 24);
            this.EmployeeBox.TabIndex = 59;
            this.EmployeeBox.SelectedIndexChanged += new System.EventHandler(this.EmployeeBox_SelectedIndexChanged);
            // 
            // deductionlabel
            // 
            this.deductionlabel.AutoSize = true;
            this.deductionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deductionlabel.Location = new System.Drawing.Point(15, 148);
            this.deductionlabel.Name = "deductionlabel";
            this.deductionlabel.Size = new System.Drawing.Size(146, 20);
            this.deductionlabel.TabIndex = 62;
            this.deductionlabel.Text = "Deduction Type:";
            // 
            // deductionBox
            // 
            this.deductionBox.FormattingEnabled = true;
            this.deductionBox.Location = new System.Drawing.Point(184, 144);
            this.deductionBox.Name = "deductionBox";
            this.deductionBox.Size = new System.Drawing.Size(175, 24);
            this.deductionBox.TabIndex = 61;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountLabel.Location = new System.Drawing.Point(77, 187);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(84, 20);
            this.amountLabel.TabIndex = 64;
            this.amountLabel.Text = "Amount :";
            // 
            // amountBox
            // 
            this.amountBox.Location = new System.Drawing.Point(184, 187);
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(175, 22);
            this.amountBox.TabIndex = 63;
            // 
            // deductionAddButton
            // 
            this.deductionAddButton.BackColor = System.Drawing.Color.White;
            this.deductionAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deductionAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deductionAddButton.Image = global::EmployeeManagement.Properties.Resources.icons8_add_button_48;
            this.deductionAddButton.Location = new System.Drawing.Point(184, 254);
            this.deductionAddButton.Name = "deductionAddButton";
            this.deductionAddButton.Size = new System.Drawing.Size(175, 65);
            this.deductionAddButton.TabIndex = 70;
            this.deductionAddButton.Text = " Apply";
            this.deductionAddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deductionAddButton.UseVisualStyleBackColor = false;
            this.deductionAddButton.Click += new System.EventHandler(this.deductionAddButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(405, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(441, 260);
            this.dataGridView1.TabIndex = 71;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Deduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.deductionAddButton);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.deductionlabel);
            this.Controls.Add(this.deductionBox);
            this.Controls.Add(this.employeeName);
            this.Controls.Add(this.EmployeeBox);
            this.Controls.Add(this.payollBackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Deduction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deduction";
            this.Load += new System.EventHandler(this.Deduction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button payollBackButton;
        private System.Windows.Forms.Label employeeName;
        private System.Windows.Forms.ComboBox EmployeeBox;
        private System.Windows.Forms.Label deductionlabel;
        private System.Windows.Forms.ComboBox deductionBox;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TextBox amountBox;
        private System.Windows.Forms.Button deductionAddButton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}