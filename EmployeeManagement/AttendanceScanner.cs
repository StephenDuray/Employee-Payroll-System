using AForge.Video;
using AForge.Video.DirectShow;
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
    public partial class AttendanceScanner: Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public AttendanceScanner()
        {
            InitializeComponent();
            InitializeCamera();
        }

        private void AttendanceScanner_Load(object sender, EventArgs e)
        {

        }
        private void InitializeCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No camera found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            videoSource.Start();
        }
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            //bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            int cropWidth = 180;
            int cropHeight = 180;
            int cropX = (bitmap.Width - cropWidth) / 2;
            int cropY = (bitmap.Height - cropHeight) / 2;
            Rectangle cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            Bitmap croppedBitmap = bitmap.Clone(cropRect, bitmap.PixelFormat);

            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new MethodInvoker(delegate
                {
                    pictureBox1.Image?.Dispose(); 
                    pictureBox1.Image = (Bitmap)croppedBitmap.Clone(); 
                }));
            }
            else
            {
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = (Bitmap)croppedBitmap.Clone();
            }

            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(croppedBitmap);
            if (result != null)
            {
                videoSource.SignalToStop();

                this.Invoke(new MethodInvoker(delegate
                {
                    MessageBox.Show($"Employee ID: {result.Text}", "Scan Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProcessQRCode(result.Text); 
                }));
            }

            bitmap.Dispose();
            croppedBitmap.Dispose();
        }
        private void QrScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }

        private void stopButton_Click_1(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }
        private void ProcessQRCode(string qrContent)
        {
            // Update the label instead of showing a message box
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
    }
}
