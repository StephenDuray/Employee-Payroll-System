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
                        // Process the QR code content
                        ProcessQRCode(qrContent);
                    }
                    else
                    {
                        label1.Text = "No QR code detected.";
                    }
                }
            }
        }

        private void ProcessQRCode(string qrContent)
        {
            if (!int.TryParse(qrContent.Trim(), out int employeeId))
            {
                label1.Text = "Invalid QR Code content.";
                return;
            }

            DateTime currentDate = DateTime.Now.Date;

            if (!dbConn.HasShiftOnDate(employeeId, currentDate))
            {
                label1.Text = "No shift assigned for today.";
                return;
            }

            // Check if there's an existing attendance record for today
            var (timeIn, timeOut) = dbConn.GetAttendanceRecord(employeeId, currentDate);

            string employeeName = dbConn.GetEmployeeNameByID(employeeId);

            if (timeIn == null)
            {
                // No record exists, so this is a time in
                TimeSpan newTimeIn = DateTime.Now.TimeOfDay;
                dbConn.AddAttendanceWithTimeIn(employeeId, currentDate, newTimeIn);
                label1.Text = $"{employeeName} has timed in at {newTimeIn}.";
            }
            else if (timeOut == null)
            {
                // Record exists but no time out, so this is a time out
                TimeSpan newTimeOut = DateTime.Now.TimeOfDay;
                dbConn.UpdateAttendanceWithTimeOut(employeeId, currentDate, newTimeOut);
                label1.Text = $"{employeeName} has timed out at {newTimeOut}.";
            }
            else
            {
                // Both time in and time out are already recorded
                label1.Text = "Attendance for today is already complete.";
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
