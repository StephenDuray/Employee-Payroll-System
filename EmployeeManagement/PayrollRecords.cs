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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeManagement
{
    public partial class PayrollRecords: Form
    {
        public PayrollRecords()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

        }

        private void payollBackButton_Click(object sender, EventArgs e)
        {
            Payroll payroll = new Payroll();
            payroll.Show();
            this.Hide();
        }

        private void PayrollRecords_Load(object sender, EventArgs e)
        {

            LoadPayrollPeriods();
            PayrollHistory();
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex > 0 && comboBox1.SelectedValue != null && comboBox1.SelectedValue != DBNull.Value)
            {
                int periodID = Convert.ToInt32(comboBox1.SelectedValue);
                FilterPayrollHistory(periodID);
            }
            else
            {
                PayrollHistory(); // Show all if "Select Period" is chosen
            }
        }
        private void PayrollHistory()
        {
            string query = @"
        SELECT 
            p.payrollID,
            CONCAT(e.Fname, ' ', e.Lname) AS Name,
            pp.periodStart,
            pp.periodEnd,
            p.grossPay,
            p.totalPenalty,
            p.totalDeductions,
            p.bunos AS Bonus,
            p.netPay
        FROM payroll p
        JOIN employee e ON p.employeeID = e.employeeID
        JOIN payrollperiod pp ON p.periodID = pp.periodID
        ORDER BY pp.periodStart DESC, e.Lname, e.Fname
    ";

            var conn = dbConn.Instance.Connection;
            if (conn.State != ConnectionState.Open)
                conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["payrollID"].Visible = false;
            }
        }

        private void LoadPayrollPeriods()
        {
            string query = "SELECT periodID, periodStart, periodEnd FROM payrollperiod ORDER BY periodStart DESC";

            var conn = dbConn.Instance.Connection;
            if (conn.State != ConnectionState.Open)
                conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Add a display column for formatted period
                dt.Columns.Add("Display", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    DateTime start = Convert.ToDateTime(row["periodStart"]);
                    DateTime end = Convert.ToDateTime(row["periodEnd"]);
                    row["Display"] = $"{start:MMMM d} to {end:dd} {end:yyyy}";
                }

                // Optionally add a default selection
                DataRow defaultRow = dt.NewRow();
                defaultRow["Display"] = "Select Period";
                defaultRow["periodID"] = DBNull.Value;
                defaultRow["periodStart"] = DBNull.Value;
                defaultRow["periodEnd"] = DBNull.Value;
                dt.Rows.InsertAt(defaultRow, 0);

                

                comboBox1.DisplayMember = "Display";
                comboBox1.ValueMember = "periodID";
                comboBox1.DataSource = dt;
            }
        }
       

        private void FilterPayrollHistory(int periodID)
        {
            string query = @"
        SELECT 
            p.payrollID,
            CONCAT(e.Fname, ' ', e.Lname) AS Name,
            pp.periodStart,
            pp.periodEnd,
            p.grossPay,
            p.totalPenalty,
            p.totalDeductions,
            p.bunos AS Bonus,
            p.netPay
        FROM payroll p
        JOIN employee e ON p.employeeID = e.employeeID
        JOIN payrollperiod pp ON p.periodID = pp.periodID
        WHERE p.periodID = @periodID
        ORDER BY pp.periodStart DESC, e.Lname, e.Fname
    ";

            var conn = dbConn.Instance.Connection;
            if (conn.State != ConnectionState.Open)
                conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@periodID", periodID);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.Columns["payrollID"].Visible = false;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["payrollID"].Value != null)
                {
                    long payrollID = Convert.ToInt64(row.Cells["payrollID"].Value);

                    Payroll payrollForm = new Payroll();
                    payrollForm.PrintPayroll(payrollID);
                    // Optionally show the form if you want
                    // payrollForm.Show();
                }
            }
        }
    }

}

