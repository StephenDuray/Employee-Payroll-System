using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class UpdateEmployee : Form
    {
        private int? selectedEmployeeID = null;
        private Dashboard dashboard;

        public UpdateEmployee(Dashboard dashboard)
        {
            InitializeComponent();
            kEyPresshandler();
            hourlyRateHandler();
            PhoneNumHandler();
            this.dashboard = dashboard;
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {
            // Populate departmentBox with department names from the database
            departmentBox.Items.Clear();
            var departments = dbConn.GetDepartmentNames();
            foreach (var dept in departments)
            {
                departmentBox.Items.Add(dept);
            }

            statusBox.Items.Clear();
            statusBox.Items.Add("Active");
            
            statusBox.Items.Add("Terminated");
        }

        private void ClearFields()
        {
            FnameBox.Text = "";
            LnameBox.Text = "";
            EmailBox.Text = "";
            ContactBox.Text = "";
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

        public void PhoneNumKeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void PhoneNumHandler()
        {
            ContactBox.KeyPress += PhoneNumKeyPress;
        }

        private void Phone(object sender, KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HourlyRateBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
       

        private void hourlyRateHandler()
        {
            hourlyRateBox.KeyPress += HourlyRateBox_KeyPress;
        }

        private void kEyPresshandler()
        {
            FnameBox.KeyPress += kEyPress;
            LnameBox.KeyPress += kEyPress;
            positionBox.KeyPress += kEyPress;
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string firstName = FnameBox.Text.Trim();
            string lastName = LnameBox.Text.Trim();
            string gender = radioButton1.Checked ? "Male" : (radioButton2.Checked ? "Female" : "");
            string email = EmailBox.Text.Trim();
            string phoneNoText = ContactBox.Text.Trim();
            string departmentName = departmentBox.Text.Trim();
            string position = positionBox.Text.Trim();
            DateTime dob = dateTimepicker.Value;
            string status = statusBox.Text.Trim(); 

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(departmentName) ||
                string.IsNullOrWhiteSpace(position) ||
                string.IsNullOrWhiteSpace(status)) 
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Existing code...
            
            // Add email validation
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

           
            if (!selectedEmployeeID.HasValue)
            {
                MessageBox.Show("Please search and select an employee before updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int employeeID = selectedEmployeeID.Value;
           

            if (dbConn.UpdateEmployee(employeeID, firstName, lastName, gender, dob, position, hourlyRate, phoneNoText, email, departmentName, status))
            {
                MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dashboard.UpdateDashboardCounts(); 
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to update employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                // Simple regex check for basic email format
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private void searchEmployeeBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchEmployeeBox.Text.Trim();
            selectedEmployeeID = null; 
            searchnullLabel.Visible = true; 

            // Clear previous status message
            searchnullLabel.Text = "";

            if (string.IsNullOrEmpty(searchText))
            {
                ClearFields();
            }
            else
            {
                DataRow row = null;
                int id;
                if (int.TryParse(searchText, out id))
                {
                    row = dbConn.GetEmployeeRowByID(id);
                }
                else
                {
                    DataTable dt = dbConn.SearchEmployees(searchText);
                    if (dt.Rows.Count == 1)
                    {
                        row = dt.Rows[0];
                    }
                    else if (dt.Rows.Count > 1)
                    {
                        // Show message in status label instead of MessageBox
                        
                        ClearFields();
                        return;
                    }
                }

                if (row != null)
                {
                    FnameBox.Text = row["Fname"].ToString();
                    LnameBox.Text = row["Lname"].ToString();
                    EmailBox.Text = row["Email"].ToString();
                    ContactBox.Text = row["ContactNum"].ToString();
                    departmentBox.SelectedItem = row["Department"].ToString();
                    positionBox.Text = row["Position"].ToString();
                    hourlyRateBox.Text = row["hourlyRate"].ToString();
                    dateTimepicker.Value = Convert.ToDateTime(row["DateofBirth"]);
                    string gender = row["Gender"].ToString();
                    radioButton1.Checked = gender == "Male";
                    radioButton2.Checked = gender == "Female";
                    statusBox.SelectedItem = row["Status"].ToString();

                    selectedEmployeeID = Convert.ToInt32(row["EmployeeID"]);
                }
                else
                {
                    // Instead of MessageBox, show no results in label
                    searchnullLabel.Text = "Employee not found.";
                    ClearFields();
                }
            }
        }

       
        private int GetSelectedEmployeeID()
        {
            if (selectedEmployeeID.HasValue)
                return selectedEmployeeID.Value;

            throw new InvalidOperationException("No employee selected. Please search and select an employee first.");
        }

        private void statusBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            // Call the ShowEmployeeControls method from Dashboard
            dashboard.ShowEmployeeControls();  // This will show the employee controls as per EmployeeButton_Click logic

            // Trigger EmployeeButton_Click directly to simulate the button click
            dashboard.EmployeeButton_Click(sender, e);  // This triggers the functionality of the EmployeeButton

            // Hide the current AddAttendance form
            this.Hide();  // This hides the AddAttendance form, but Dashboard stays open
            dashboard.Show();
        }

        private void EmailBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
