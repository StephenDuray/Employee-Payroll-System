namespace EmployeeManagement
{
    partial class QrScanner
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
            this.qrCodePictureBox = new System.Windows.Forms.PictureBox();
            this.generateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // qrCodePictureBox
            // 
            this.qrCodePictureBox.Location = new System.Drawing.Point(12, 12);
            this.qrCodePictureBox.Name = "qrCodePictureBox";
            this.qrCodePictureBox.Size = new System.Drawing.Size(376, 426);
            this.qrCodePictureBox.TabIndex = 0;
            this.qrCodePictureBox.TabStop = false;
            this.qrCodePictureBox.Click += new System.EventHandler(this.qrCodePictureBox_Click);
            // 
            // generateButton
            // 
            this.generateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.Image = global::EmployeeManagement.Properties.Resources.addAttendance;
            this.generateButton.Location = new System.Drawing.Point(489, 207);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(238, 60);
            this.generateButton.TabIndex = 17;
            this.generateButton.Text = "Scan QR ";
            this.generateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // QrScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.qrCodePictureBox);
            this.Name = "QrScanner";
            this.Text = "QrScanner";
            ((System.ComponentModel.ISupportInitialize)(this.qrCodePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox qrCodePictureBox;
        private System.Windows.Forms.Button generateButton;
    }
}