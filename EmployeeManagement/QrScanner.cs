using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace EmployeeManagement
{
    public partial class QrScanner: Form
    {
        public QrScanner()
        {
            InitializeComponent();
        }

        private void qrCodePictureBox_Click(object sender, EventArgs e)
        {

        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select an image file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load the selected image into the PictureBox
                    Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                    qrCodePictureBox.Image = bitmap;

                    // Scan the QR code from the image
                    string qrContent = ScanQRCode(bitmap);
                    if (!string.IsNullOrEmpty(qrContent))
                    {
                        MessageBox.Show($"QR Code Content: {qrContent}", "Scan Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No QR code detected.", "Scan Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private string ScanQRCode(Bitmap bitmap)
        {
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            return result?.Text;
        }
    }
}
