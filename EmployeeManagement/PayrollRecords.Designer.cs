namespace EmployeeManagement
{
    partial class PayrollRecords
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
            this.payollBackButton.TabIndex = 55;
            this.payollBackButton.Text = "Back";
            this.payollBackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.payollBackButton.UseVisualStyleBackColor = false;
            this.payollBackButton.Click += new System.EventHandler(this.payollBackButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(132, 111);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(538, 254);
            this.dataGridView1.TabIndex = 56;
            // 
            // PayrollRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.payollBackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PayrollRecords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PayrollRecords";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button payollBackButton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}