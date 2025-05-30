using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeManagement
{
   
    public partial class Deduction: Form
    {
        public Deduction() 
        {
            InitializeComponent();
            LoadAllDeduction();
            //PopulateEmployeeNames();
            PopulateDeductionCategory();
            LoadEmployees();
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit; 

        }

        private void payollBackButton_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.ShowDialog();
            this.Close();
        }

        private void Deduction_Load(object sender, EventArgs e)
        {
            LoadAllDeduction();
        }
        private void LoadEmployees()
        {
            try
            {
                string query = "SELECT employeeID, CONCAT(Fname, ' ', Lname) AS FullName FROM employee";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbConn.Instance.Connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Add default "Select Employee" option
                    DataRow newRow = dt.NewRow();
                    newRow["employeeID"] = DBNull.Value;
                    newRow["FullName"] = "Select Employee";
                    dt.Rows.InsertAt(newRow, 0);

                    // Configure ComboBox
                    EmployeeBox.DisplayMember = "FullName";  // What users see
                    EmployeeBox.ValueMember = "employeeID";  // Actual value
                    EmployeeBox.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void PopulateEmployeeNames()
        //{
        //    List<string> employeeNames = dbConn.GetEmployeeNames();


        //    if (employeeNames.Count == 0)
        //    {
        //        MessageBox.Show("No employee names found.");
        //        return;
        //    }


        //    EmployeeBox.Items.Clear();


        //    EmployeeBox.Items.AddRange(employeeNames.ToArray());
        //}
        private void PopulateDeductionCategory()
        {
            List<string> deductioncategoy = dbConn.GetDeductionCategory();
            if (deductioncategoy.Count == 0)
            {
                MessageBox.Show("No deduction categories found.");
                return;
            }
            deductionBox.Items.Clear();
            deductionBox.Items.AddRange(deductioncategoy.ToArray());

        }

        private void deductionAddButton_Click(object sender, EventArgs e)
        {
            if (EmployeeBox.SelectedIndex <= 0 || EmployeeBox.SelectedValue == null || EmployeeBox.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Please select a valid employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int employeeID = Convert.ToInt32(EmployeeBox.SelectedValue);
            string deductionName = deductionBox.Text.Trim();

            if (string.IsNullOrEmpty(deductionName))
            {
                MessageBox.Show("Please select a deduction category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string amountText = amountBox.Text.Trim();
            if (!decimal.TryParse(amountText, out decimal parsedAmount) || parsedAmount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if deduction already exists
            string checkQuery = @"
        SELECT COUNT(*) 
        FROM deductions d
        INNER JOIN deductionCategory dc ON d.deductionCatID = dc.deductionCatID
        WHERE d.employeeID = @EmployeeID AND dc.deductionName = @DeductionName";

            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, dbConn.Instance.Connection))
            {
                checkCmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                checkCmd.Parameters.AddWithValue("@DeductionName", deductionName);

                if (dbConn.Instance.Connection.State != ConnectionState.Open)
                    dbConn.Instance.Connection.Open();

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("This employee already has the selected deduction.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Convert amount
            int amount = (int)Math.Round(parsedAmount);

            // Insert deduction
            if (dbConn.AddDeduction(employeeID, deductionName, amount))
            {
                MessageBox.Show("Deduction added successfully!");
                LoadAllDeduction();
                deductionBox.Text = "";
                amountBox.Text = "";
            }
            else
            {
                MessageBox.Show("Failed to add deduction. Please try again.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void LoadAllDeduction()
        {
            dataGridView1.DataSource = dbConn.GetDeductions();
            if (dataGridView1.Columns.Contains("deductionID"))
            {
                dataGridView1.Columns["deductionID"].Visible = false;
                
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dbConn.UpdateDeductionFromGrid(dataGridView1, e.RowIndex); // 👈 Single-line simplified logic
            LoadAllDeduction(); // Reload the data to reflect changes
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void EmployeeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

