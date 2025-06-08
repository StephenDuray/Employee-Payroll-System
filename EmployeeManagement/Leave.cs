using MySql.Data.MySqlClient;
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
    public partial class Leave: Form
    {
        public Leave()
        {
            InitializeComponent();
            LoadEmployeeNames();
        }

        private void EmployeeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EmployeeBox.SelectedIndex > 0)
            {
                string selectedEmployeeName = EmployeeBox.SelectedItem.ToString();
            }
        }
        private List<KeyValuePair<int, string>> GetEmployeeNamesWithIDs()
        {
            List<KeyValuePair<int, string>> employees = new List<KeyValuePair<int, string>>();

            string query = "SELECT employeeID, CONCAT(Fname, ' ', Lname) AS FullName FROM employee";
            using (MySqlCommand cmd = new MySqlCommand(query, dbConn.Instance.Connection))
            {
                if (dbConn.Instance.Connection.State != ConnectionState.Open)
                    dbConn.Instance.Connection.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("employeeID");
                        string name = reader.GetString("FullName");
                        employees.Add(new KeyValuePair<int, string>(id, name));
                    }
                }
            }

            return employees;
        }
        private void LoadEmployeeNames()
        {
            try
            {
                var employees = GetEmployeeNamesWithIDs();

                EmployeeBox.Items.Clear();

                EmployeeBox.Items.Add(new KeyValuePair<int, string>(0, "Select Employee"));

                foreach (var employee in employees)
                {
                    EmployeeBox.Items.Add(employee);
                }

                EmployeeBox.DisplayMember = "Value";
                EmployeeBox.ValueMember = "Key";
                EmployeeBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee names: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (EmployeeBox.SelectedIndex > 0)
            {
                int employeeId = ((KeyValuePair<int, string>)EmployeeBox.SelectedItem).Key;
                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;

                // Validate date range
                if (startDate > endDate)
                {
                    MessageBox.Show("Start date cannot be after end date.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isLeaveWithPay = isLeavewithPay.Checked;

                try
                {
                    bool success = dbConn.AddLeaveRecord(employeeId, startDate, endDate, isLeaveWithPay);

                    if (success)
                    {
                        MessageBox.Show("Leave processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to process leave.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
