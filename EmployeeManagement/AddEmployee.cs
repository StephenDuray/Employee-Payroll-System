using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            // Check for empty fields
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(departmentName) ||
                string.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            // Check for valid hourly rate
            if (!int.TryParse(hourlyRateBox.Text.Trim(), out int hourlyRate))
            {
                MessageBox.Show("Please enter a valid hourly rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            
            phoneNoText = Regex.Replace(phoneNoText, @"\D", "");

            // Check for valid phone number
            if (!Regex.IsMatch(phoneNoText, @"^\d{11}$"))
            {
                MessageBox.Show("Contact number must be exactly 11 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            // Add employee to the database
            if (dbConn.AddEmployee(firstName, lastName, gender, dob, position, hourlyRate, phoneNoText, email, departmentName))
            {
                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to add employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFields();
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
    }
}

