using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class AssignShift : Form
    {
        public AssignShift()
        {
            InitializeComponent();
            LoadShiftTypes();
            assignShiftempBox.TextChanged += employeeIDBox_TextChanged;
        }
        public void kEyPress(Object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
        
        
        private void ClearFields()
        { 
            assignShiftempBox.Text = "";            
            shiftTypeBox.SelectedIndex = -1;
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
        }
        private void employeeIDBox_TextChanged(object sender, EventArgs e)
        {
          
        }


        private void employeeIDBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }
        private void LoadShiftTypes()
        {
            shiftTypeBox.Items.Clear();
            var shiftTypes = dbConn.GetShiftType();
            foreach (var shift in shiftTypes)
            {
                shiftTypeBox.Items.Add(shift);
            }
        }
        private void employeeNameBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void shiftyTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
      
        private void assignShiftButton_Click(object sender, EventArgs e)
        {
            // Ensure something is selected in the ComboBox
            if (assignShiftempBox.SelectedItem == null || string.IsNullOrWhiteSpace(assignShiftempBox.Text))
            {
                MessageBox.Show("Please select a valid employee.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get and trim full name
            string selectedEmployeeName = assignShiftempBox.SelectedItem.ToString().Trim();

            // Query using full name
            string query = "SELECT employeeID FROM employee WHERE CONCAT(Fname, ' ', Lname) = @FullName";
            int employeeID = 0;

            using (MySqlCommand cmd = new MySqlCommand(query, dbConn.Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@FullName", selectedEmployeeName);

                if (dbConn.Instance.Connection.State != ConnectionState.Open)
                    dbConn.Instance.Connection.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employeeID = reader.GetInt32("employeeID");
                    }
                    else
                    {
                        MessageBox.Show("Employee not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Validate shift type selection
            string selectedShiftType = shiftTypeBox.Text.Trim();
            if (string.IsNullOrEmpty(selectedShiftType))
            {
                MessageBox.Show("Please select a valid Shift Type.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieve shiftID from DB using shiftType name
            int shiftID = dbConn.GetShiftIDByName(selectedShiftType);
            if (shiftID == 0)
            {
                MessageBox.Show("Selected Shift Type not found in database.", "Invalid Shift Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime startDate = dtpStart.Value.Date;
            DateTime endDate = dtpEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for existing shift before adding
            if (dbConn.ExistingShift(employeeID, startDate, endDate))
            {
                MessageBox.Show("This employee already has a shift assigned within the selected date range.", "Conflict Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add the shift assignment to the database
            bool success = dbConn.AddShiftEmployee(employeeID, shiftID, startDate, endDate);
            if (success)
            {
                MessageBox.Show("Shift assignment added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally refresh your data grid or clear inputs here
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to add shift assignment. Please check the data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form_Load(object sender, EventArgs e)
        {
            // Populate ComboBox with employee names when the form loads
            PopulateEmployeeNames();
        }

        private void PopulateEmployeeNames()
        {
            List<string> employeeNames = dbConn.GetEmployeeNames();

            // Clear any existing items before adding new ones
            assignShiftempBox.Items.Clear();

            // Add the employee names to the ComboBox
            assignShiftempBox.Items.AddRange(employeeNames.ToArray());
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {

            Dashboard dashboard = new Dashboard();
            dashboard.ShowDialog();
            this.Hide();
        }

        private void AssignShift_Load(object sender, EventArgs e)
        {
            PopulateEmployeeNames();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { // Ensure something is selected
            if (assignShiftempBox.SelectedIndex != -1)
            {
                // Get the selected employee name
                string selectedEmployeeName = assignShiftempBox.SelectedItem.ToString();

                // Optionally, you can fetch the employee ID or do additional processing
                MessageBox.Show("You selected: " + selectedEmployeeName);
            }
            else
            {
                // Handle the case where no selection is made, if necessary
                MessageBox.Show("Please select an employee from the list.");
            }
        }
    }
}


