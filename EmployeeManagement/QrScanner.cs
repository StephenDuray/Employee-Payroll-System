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
                        MessageBox.Show("No QR code detected.", "Scan Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void ProcessQRCode(string qrContent)
        {
            if (!int.TryParse(qrContent.Trim(), out int employeeId))
            {
                MessageBox.Show("Invalid QR Code content.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime currentDate = DateTime.Now.Date;

            if (!dbConn.HasShiftOnDate(employeeId, currentDate))
            {
                MessageBox.Show("No shift assigned for today.", "Shift Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show($"{employeeName} has timed in at {newTimeIn}.", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (timeOut == null)
            {
                // Record exists but no time out, so this is a time out
                TimeSpan newTimeOut = DateTime.Now.TimeOfDay;
                dbConn.UpdateAttendanceWithTimeOut(employeeId, currentDate, newTimeOut);
                MessageBox.Show($"{employeeName} has timed out at {newTimeOut}.", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Both time in and time out are already recorded
                MessageBox.Show("Attendance for today is already complete.", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
