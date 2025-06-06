    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

    namespace EmployeeManagement
    {
        public partial class Payroll : Form
        {
            public Payroll()
            {
                InitializeComponent();
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                LoadNames(); // Load employee names into the combo box
                LoadPayrollPeriods();



            }

            private void Payroll_Load(object sender, EventArgs e)
            {
           
            
            }

            private void label2_Click(object sender, EventArgs e)
            {

            }
            private void LoadNames() 
            {
            
                string query = "SELECT employeeID, CONCAT(Fname, ' ', Lname) AS FullName FROM employee";

                var conn = dbConn.Instance.Connection;
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                DataTable dt = new DataTable();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
                DataRow defaultRow = dt.NewRow();
                defaultRow["employeeID"] = DBNull.Value;
                defaultRow["FullName"] = "Select Employee";
                dt.Rows.InsertAt(defaultRow, 0);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "FullName";
                comboBox1.ValueMember = "employeeID";
            }

        

            private void deductionButton_Click(object sender, EventArgs e)
            {
                // Open the form modally
                using (addpayrollPeriod addPeriodForm = new addpayrollPeriod(this))
                {
                    if (addPeriodForm.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh the payroll periods combo box after the dialog closes
                        LoadPayrollPeriods();
                    }
                }
            }

            private void bunosButton_Click(object sender, EventArgs e)
            {

            }

            private void payollBackButton_Click(object sender, EventArgs e)
            {

                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }

            private void EmployeeBox_SelectedIndexChanged(object sender, EventArgs e)
            {

            }


            private void deductionAddButton_Click(object sender, EventArgs e)
            {

            }

            private void button1_Click(object sender, EventArgs e)
            {

            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {

            }

            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {


                LoadPayrollSummary();


            }
        private void LoadPayrollSummary()
        {
            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int selectedId))
            {
                // Get the selected payroll period's start and end dates
                DataRowView selectedPeriod = comboBox2.SelectedItem as DataRowView;
                if (selectedPeriod == null || selectedPeriod["periodStart"] == DBNull.Value || selectedPeriod["periodEnd"] == DBNull.Value)
                {
                    // No valid period selected
                    ClearTextBoxes();
                    return;
                }

                DateTime periodStart = Convert.ToDateTime(selectedPeriod["periodStart"]);
                DateTime periodEnd = Convert.ToDateTime(selectedPeriod["periodEnd"]);

                string query = @"
            SELECT 
                e.employeeID AS employeeID,
                e.hourlyRate,
                (SUM(TIMESTAMPDIFF(MINUTE, a.timeIn, a.timeOut)) - (COUNT(*) * 60)) / 60 AS total_hours_worked,
                SUM(GREATEST(TIMESTAMPDIFF(MINUTE, s.timeIn, a.timeIn), 0)) AS total_late_minutes,
                SUM(GREATEST(TIMESTAMPDIFF(MINUTE, a.timeOut, s.timeOut), 0)) AS total_undertime_minutes,
                IFNULL((SELECT SUM(amount) FROM deductions WHERE employeeID = e.employeeID), 0) AS total_deductions,
                IFNULL(
                    (SELECT SUM(amount) FROM bunos 
                     WHERE employeeID = e.employeeID 
                       AND bonusDate BETWEEN @period_start AND @period_end
                    ), 0
                ) AS bonus
            FROM attendance a
            JOIN employee e ON e.employeeID = a.employeeID
            JOIN shiftemployee se ON se.employeeID = a.employeeID
                AND a.date BETWEEN se.startDate AND se.endDate
            JOIN shift s ON s.shiftID = se.shiftID
            WHERE a.employeeID = @employee_id
              AND a.status != 'Absent'
              AND a.date BETWEEN @period_start AND @period_end
            GROUP BY e.employeeID;
        ";

                var conn = dbConn.Instance.Connection;
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employee_id", selectedId);
                    cmd.Parameters.AddWithValue("@period_start", periodStart);
                    cmd.Parameters.AddWithValue("@period_end", periodEnd);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal hourlyRate = Convert.ToDecimal(reader["hourlyRate"]);
                            decimal totalLates = Convert.ToDecimal(reader["total_late_minutes"]);
                            decimal totalUndertime = Convert.ToDecimal(reader["total_undertime_minutes"]);
                            decimal hoursWorked = Convert.ToDecimal(reader["total_hours_worked"]);
                            decimal totalDeductions = Convert.ToDecimal(reader["total_deductions"]);
                            decimal totalBonuses = Convert.ToDecimal(reader["bonus"]);

                            // Calculate gross pay based on actual hours worked
                            decimal grossPay = Math.Max(hoursWorked * hourlyRate, 0);

                            // Calculate total penalty
                            decimal totalPenalty = ((totalLates + totalUndertime) / 60) * hourlyRate;

                            // Calculate net pay ensuring it is not negative
                            decimal netPay = Math.Max(grossPay - totalPenalty - totalDeductions + totalBonuses, 0);

                            textBox1.Text = totalLates.ToString("F0");
                            textBox2.Text = totalUndertime.ToString("F0");
                            textBox3.Text = grossPay.ToString("F2");
                            textBox4.Text = totalPenalty.ToString("F2");
                            textBox5.Text = totalDeductions.ToString("F2");
                            textBox6.Text = totalBonuses.ToString("F2");
                            textBox7.Text = netPay.ToString("F2");

                            // Hide button1 if netPay is zero
                            button1.Visible = netPay > 0;
                        }
                        else
                        {
                            ClearTextBoxes();
                        }
                    }
                }
            }
        }
        private void ClearTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            button1.Visible = false;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
            {
                Font titleFont = new Font("Arial", 20, FontStyle.Bold);
                Font bodyFont = new Font("Arial", 12);
                Brush brush = Brushes.Black;
                int startX = 50;
                int startY = 50;
                int lineHeight = 30;

                e.Graphics.DrawString("------Payroll Summary------", titleFont, brush, startX, startY);

                startY += lineHeight * 2;

                e.Graphics.DrawString("Employee Name: " + comboBox1.Text, bodyFont, brush, startX, startY);
                startY += lineHeight;

                e.Graphics.DrawString("Late (minutes): " + textBox1.Text, bodyFont, brush, startX, startY);
                startY += lineHeight;

                e.Graphics.DrawString("Undertime (minutes): " + textBox2.Text, bodyFont, brush, startX, startY);
                startY += lineHeight;

                e.Graphics.DrawString("Gross Pay: ₱" + textBox3.Text, bodyFont, brush, startX, startY);
                startY += lineHeight;

                e.Graphics.DrawString("Penalty: ₱" + textBox4.Text, bodyFont, brush, startX, startY);
                startY += lineHeight;

                e.Graphics.DrawString("Deductions: ₱" + textBox5.Text, bodyFont, brush, startX, startY);
                startY += lineHeight;

                e.Graphics.DrawString("Bonus: ₱" + textBox6.Text, bodyFont, brush, startX, startY);
                startY += lineHeight;

                e.Graphics.DrawString("Net Pay: ₱" + textBox7.Text, bodyFont, brush, startX, startY);
                startY += lineHeight;

                e.Graphics.DrawString("Date Printed: " + DateTime.Now.ToString("MMMM dd, yyyy HH:mm tt"),bodyFont , brush,startX,startY);
                startY += lineHeight * 3;
            }


        
            private void button1_Click_2(object sender, EventArgs e)
            {
                if (comboBox1.SelectedValue == null || comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a valid employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox2.SelectedValue == null || comboBox2.SelectedValue == DBNull.Value || comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a valid payroll period.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int employeeId = Convert.ToInt32(comboBox1.SelectedValue);
                DateTime periodStart;

                try
                {
                    periodStart = Convert.ToDateTime(comboBox2.SelectedValue);
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("Selected payroll period is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MySqlConnection conn = dbConn.Instance.Connection;

                try
                {
                    // ✅ Get periodID using the selected periodStart
                    int periodId = 0;
                    string getPeriodIdQuery = "SELECT periodID FROM payrollperiod WHERE periodStart = @periodStart LIMIT 1";

                    using (MySqlCommand getPeriodCmd = new MySqlCommand(getPeriodIdQuery, conn))
                    {
                        getPeriodCmd.Parameters.AddWithValue("@periodStart", periodStart);
                        object resultObj = getPeriodCmd.ExecuteScalar();
                        if (resultObj != null && resultObj != DBNull.Value)
                        {
                            periodId = Convert.ToInt32(resultObj);
                        }
                        else
                        {
                            MessageBox.Show("Selected payroll period was not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // ✅ Check if payroll already exists
                    string checkQuery = "SELECT COUNT(*) FROM payroll WHERE employeeID = @employeeID AND periodID = @periodID";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@employeeID", employeeId);
                        checkCmd.Parameters.AddWithValue("@periodID", periodId);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("This employee already has a payroll record for the selected payroll period.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // ✅ Load payroll data before printing
                    LoadPayrollSummary();

                    PrintDialog print = new PrintDialog();
                    print.Document = printDocument1;

                    DialogResult result = print.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        printDocument1.Print();

                        // ✅ Parse values from textboxes
                        decimal.TryParse(textBox3.Text, out decimal grossPay);
                        decimal.TryParse(textBox4.Text, out decimal penalty);
                        decimal.TryParse(textBox5.Text, out decimal deductions);
                        decimal.TryParse(textBox6.Text, out decimal bonuses);
                        decimal.TryParse(textBox7.Text, out decimal netPay);

                        // ✅ Insert new payroll record
                        string insertQuery = @"
                    INSERT INTO payroll (employeeID, periodID, grossPay, totalPenalty, totalDeductions, bunos, netPay)
                    VALUES (@employeeID, @periodID, @grossPay, @penalty, @deductions, @bunos, @netPay)";

                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@employeeID", employeeId);
                            cmd.Parameters.AddWithValue("@periodID", periodId);
                            cmd.Parameters.AddWithValue("@grossPay", grossPay);
                            cmd.Parameters.AddWithValue("@penalty", penalty);
                            cmd.Parameters.AddWithValue("@deductions", deductions);
                            cmd.Parameters.AddWithValue("@bunos", bonuses); // ✔ Ensure this column name is correct
                            cmd.Parameters.AddWithValue("@netPay", netPay);

                            cmd.ExecuteNonQuery();
                        }

                        
                        MessageBox.Show("Payroll printed and saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void ClearFormFields()
            {
                comboBox1.SelectedIndex = 0; // Reset to "Select Employee"
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }

            private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
            LoadPayrollSummary();
            }
            public void LoadPayrollPeriods()
            {
                string query = "SELECT periodStart, periodEnd FROM payrollperiod ORDER BY periodStart DESC";

                MySqlConnection conn = dbConn.Instance.Connection;

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Add "Display" column
                    dt.Columns.Add("Display", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime start = Convert.ToDateTime(row["periodStart"]);
                        DateTime end = Convert.ToDateTime(row["periodEnd"]);

                        // Format: May 1 to 15 / 2025
                        row["Display"] = $"{start:MMMM d} to {end:dd} / {end:yyyy}";
                    }

                    // Add "Select Period" as the first row
                    DataRow defaultRow = dt.NewRow();
                    defaultRow["Display"] = "Select Period";
                    defaultRow["periodStart"] = DBNull.Value;
                    defaultRow["periodEnd"] = DBNull.Value;
                    dt.Rows.InsertAt(defaultRow, 0);

                    comboBox2.DisplayMember = "Display";
                    comboBox2.ValueMember = "periodStart";
                    comboBox2.DataSource = dt;
                }
            }

            private void button2_Click(object sender, EventArgs e)
            {
                PayrollRecords payrollRecords = new PayrollRecords();
                payrollRecords.Show();
            
            }
        public void PrintPayroll(long payrollID)
        {
            // Load payroll data for the given payrollID
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
        WHERE p.payrollID = @payrollID
        LIMIT 1";

            var conn = dbConn.Instance.Connection;
            if (conn.State != ConnectionState.Open)
                conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@payrollID", payrollID);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        comboBox1.Text = reader["Name"].ToString(); // Set employee name for printing

                        decimal grossPay = Convert.ToDecimal(reader["grossPay"]);
                        decimal totalPenalty = Convert.ToDecimal(reader["totalPenalty"]);
                        decimal totalDeductions = Convert.ToDecimal(reader["totalDeductions"]);
                        decimal totalBonuses = Convert.ToDecimal(reader["Bonus"]);
                        decimal netPay = Convert.ToDecimal(reader["netPay"]);

                        textBox3.Text = grossPay.ToString("F2");
                        textBox4.Text = totalPenalty.ToString("F2");
                        textBox5.Text = totalDeductions.ToString("F2");
                        textBox6.Text = totalBonuses.ToString("F2");
                        textBox7.Text = netPay.ToString("F2");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }

                    else
                    {
                        //ClearFormFields();
                    }

                }
            }

            // Trigger the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
