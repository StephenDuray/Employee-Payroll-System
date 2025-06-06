using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace EmployeeManagement
{
    public partial class AddEmployee : Form
    {
        private Dashboard dashboard;
        public AddEmployee(Dashboard dashboard)
        {
            InitializeComponent();
            kEyPresshandler();
            hourlyRateHandler();
            phoneNUmberhandler();
            this.dashboard = dashboard;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            // Example: Get department names from the database
            List<string> departments = dbConn.GetDepartmentNames(); // You must have this method in dbConn

            departmentBox.Items.Clear();
            departmentBox.Items.AddRange(departments.ToArray());
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void ClearFields()
        {
            FnameBox.Text = "";
            LnameBox.Text = "";
            EmailBox.Text = "";
            contactnumberBox.Text = "";
            departmentBox.SelectedIndex = -1;
            positionBox.Text = "";
            hourlyRateBox.Text = "";
            dateTimepicker.Value = DateTime.Now;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        public void kEyPress(Object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetter(e.KeyChar) &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        public void HourlyRateBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void hourlyRateHandler()
        {
            
            hourlyRateBox.KeyPress += HourlyRateBox_KeyPress;
        }
        public void phoneNumber(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void phoneNUmberhandler()
        {

            contactnumberBox.KeyPress += phoneNumber;
        }
        private void kEyPresshandler()
        {
            
            FnameBox.KeyPress += kEyPress;
            LnameBox.KeyPress += kEyPress;
            positionBox.KeyPress += kEyPress;
            
            
        }


        private void ContactnumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            string firstName = FnameBox.Text.Trim();
            string lastName = LnameBox.Text.Trim();
            string gender = radioButton1.Checked ? "Male" : (radioButton2.Checked ? "Female" : "");
            string email = EmailBox.Text.Trim();
            string phoneNoText = contactnumberBox.Text.Trim();
            string departmentName = departmentBox.Text.Trim();
            string position = positionBox.Text.Trim();
            DateTime dob = dateTimepicker.Value;

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(departmentName) ||
                string.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dob.Year >= DateTime.Now.Year)
            {
                MessageBox.Show("Birthday year must be less than the current year.", "Invalid Birthday", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(hourlyRateBox.Text.Trim(), out int hourlyRate))
            {
                MessageBox.Show("Please enter a valid hourly rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            phoneNoText = Regex.Replace(phoneNoText, @"\D", "");

            if (!Regex.IsMatch(phoneNoText, @"^\d{11}$"))
            {
                MessageBox.Show("Contact number must be exactly 11 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convert image to byte array
            byte[] imageBytes = null;
            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    imageBytes = ms.ToArray();
                    pictureBox1.Image = null;
                }
            }

            // Add employee and get the new employee ID
            int employeeId = dbConn.AddEmployee(firstName, lastName, gender, email, dob, position, hourlyRate, phoneNoText, departmentName, imageBytes);
            if (employeeId != -1)
            {
                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Generate QR code with employee ID
                string qrContent = employeeId.ToString();
                Bitmap qrCode = GenerateQRCode(qrContent);

                // Save the QR code as an image file
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Employee_{employeeId}_QRCode.png");
                qrCode.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                MessageBox.Show($"QR Code saved to {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally, print the QR code
                PrintQRCode(qrCode);

                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to add employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void departmentBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // Call the ShowEmployeeControls method from Dashboard
            dashboard.ShowEmployeeControls();  // This will show the employee controls as per EmployeeButton_Click logic

            // Trigger EmployeeButton_Click directly to simulate the button click
            dashboard.EmployeeButton_Click(sender, e);  // This triggers the functionality of the EmployeeButton

            // Hide the current AddAttendance form
            this.Hide();  // This hides the AddAttendance form, but Dashboard stays open
            dashboard.Show();
        }

        private void LnameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
           
        }

        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void headerLabel_Click(object sender, EventArgs e)
        {

        }
       

        private Bitmap GenerateQRCode(string content)
        {
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 500,
                    Height = 500
                }
            };
            return writer.Write(content);
        }

        private void PrintQRCode(Bitmap qrCode)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                // Center the QR code on the page
                int x = (e.PageBounds.Width - qrCode.Width) / 2;
                int y = (e.PageBounds.Height - qrCode.Height) / 2;
                e.Graphics.DrawImage(qrCode, x, y);
            };

            try
            {
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing QR code: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addImage_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image selectedImage = Image.FromFile(openFileDialog.FileName);
                        pictureBox1.Image = selectedImage;
                        pictureBox1.Refresh(); // Ensure the PictureBox is refreshed to display the image
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

