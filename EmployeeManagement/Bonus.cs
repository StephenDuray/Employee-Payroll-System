using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class Bonus : Form
    {
        public Bonus()
        {
            InitializeComponent();
            LoadEmployees();
            LoadBonusCategories();
            LoadPayrollPeriods();
        }

        private void Bonus_Load(object sender, EventArgs e)
        {

        }

        private void LoadEmployees()
        {
            string query = "SELECT employeeID, CONCAT(Fname, ' ', Lname) AS FullName FROM employee";

            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbConn.Instance.Connection);
                adapter.Fill(dt);

                DataRow blankRow = dt.NewRow();
                blankRow["employeeID"] = DBNull.Value;
                blankRow["Fullname"] = "Select Employee";
                dt.Rows.InsertAt(blankRow, 0);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "FullName";
                comboBox1.ValueMember = "employeeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}");
            }
        }
        private void LoadBonusCategories()
        {
            string query = "SELECT bunosCatID, bunosName FROM bunoscategory";
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbConn.Instance.Connection);
                adapter.Fill(dt);

                DataRow blankRow = dt.NewRow();
                blankRow["bunosCatID"] = DBNull.Value;
                blankRow["bunosName"] = "Select Bonus";
                dt.Rows.InsertAt(blankRow, 0);

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "bunosName";
                comboBox2.ValueMember = "bunosCatID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bonus categories: {ex.Message}");
            }
        }
        private void LoadPayrollPeriods()
        {
            string query = "SELECT periodID, periodStart, periodEnd FROM payrollperiod ORDER BY periodStart DESC";
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbConn.Instance.Connection);
                adapter.Fill(dt);

                dt.Columns.Add("Display", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    DateTime start = Convert.ToDateTime(row["periodStart"]);
                    DateTime end = Convert.ToDateTime(row["periodEnd"]);
                    row["Display"] = $"{start:MMMM d} to {end:dd} {end:yyyy}";
                }

                DataRow blankRow = dt.NewRow();
                blankRow["periodID"] = DBNull.Value;
                blankRow["Display"] = "Select Period";
                dt.Rows.InsertAt(blankRow, 0);

                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "Display";
                comboBox3.ValueMember = "periodID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payroll periods: {ex.Message}");
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void payollBackButton_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void SaveBonus_Click(object sender, EventArgs e)
        {
            // Validate selections
            if (comboBox1.SelectedValue == null || comboBox1.SelectedValue == DBNull.Value ||
                comboBox2.SelectedValue == null || comboBox2.SelectedValue == DBNull.Value ||
                comboBox3.SelectedValue == null || comboBox3.SelectedValue == DBNull.Value ||
                string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please complete all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBox1.Text, out decimal amount) || amount < 0)
            {
                MessageBox.Show("Please enter a valid bonus amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeID = Convert.ToInt32(comboBox1.SelectedValue);
            int bunosCatID = Convert.ToInt32(comboBox2.SelectedValue);
            int periodID = Convert.ToInt32(comboBox3.SelectedValue);
            DateTime bonusDate = dateTimePicker1.Value.Date; // <-- Get the date from the DateTimePicker

            // Optional: Check for duplicate bonus for this employee, category, and period
            string checkQuery = @"SELECT COUNT(*) FROM bunos WHERE employeeID = @employeeID AND bunosCatID = @bunosCatID AND periodID = @periodID AND bonusDate = @bonusDate";
            string insertQuery = @"INSERT INTO bunos (employeeID, bunosCatID, amount, periodID, bonusDate) VALUES (@employeeID, @bunosCatID, @amount, @periodID, @bonusDate)";

            var conn = dbConn.Instance.Connection;
            if (conn.State != ConnectionState.Open)
                conn.Open();

            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@employeeID", employeeID);
                checkCmd.Parameters.AddWithValue("@bunosCatID", bunosCatID);
                checkCmd.Parameters.AddWithValue("@periodID", periodID);
                checkCmd.Parameters.AddWithValue("@bonusDate", bonusDate);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("This bonus has already been assigned to this employee for the selected period and date.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
            {
                insertCmd.Parameters.AddWithValue("@employeeID", employeeID);
                insertCmd.Parameters.AddWithValue("@bunosCatID", bunosCatID);
                insertCmd.Parameters.AddWithValue("@amount", amount);
                insertCmd.Parameters.AddWithValue("@periodID", periodID);
                insertCmd.Parameters.AddWithValue("@bonusDate", bonusDate);

                insertCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Bonus added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Optionally clear fields or refresh bonus list
            textBox1.Clear();
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}

