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
                LoadNames();
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
                
                using (addpayrollPeriod addPeriodForm = new addpayrollPeriod(this))
                {
                    if (addPeriodForm.ShowDialog() == DialogResult.OK)
                    {
                       
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
            private string deductionTypes;
            private string bonusTypes;

        private void LoadPayrollSummary()
        {
            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int selectedId))
            {
                DataRowView selectedPeriod = comboBox2.SelectedItem as DataRowView;
                if (selectedPeriod == null || selectedPeriod["periodStart"] == DBNull.Value || selectedPeriod["periodEnd"] == DBNull.Value)
                {
                    ClearTextBoxes();
                    return;
                }

                DateTime periodStart = Convert.ToDateTime(selectedPeriod["periodStart"]);
                DateTime periodEnd = Convert.ToDateTime(selectedPeriod["periodEnd"]);

                // ############### REVISED SQL QUERY ###############
                // This query now starts from the employee table to ensure calculations
                // are performed even if there are no attendance records for the period.
                string query = @"
        SELECT
            e.employeeID,
            e.hourlyRate,
            IFNULL(att_summary.total_hours_worked, 0) AS total_hours_worked,
            IFNULL(att_summary.total_late_minutes, 0) AS total_late_minutes,
            IFNULL(att_summary.total_undertime_minutes, 0) AS total_undertime_minutes,
            IFNULL((SELECT GROUP_CONCAT(CONCAT(dc.deductionName, ': ₱', d.amount) SEPARATOR '\n')
                    FROM deductions d
                    JOIN deductionCategory dc ON d.deductionCatID = dc.deductionCatID
                    WHERE d.employeeID = e.employeeID), 'None') AS detailed_deductions,
            IFNULL((SELECT GROUP_CONCAT(CONCAT(bc.bunosName, ': ₱', b.amount) SEPARATOR '\n')
                    FROM bunos b
                    JOIN bunosCategory bc ON b.bunosCatID = bc.bunosCatID
                    WHERE b.employeeID = e.employeeID
                      AND b.bonusDate BETWEEN @period_start AND @period_end), 'None') AS detailed_bonuses,
            IFNULL((SELECT SUM(amount) FROM deductions WHERE employeeID = e.employeeID), 0) AS total_deductions,
            IFNULL((SELECT SUM(amount) FROM bunos
                     WHERE employeeID = e.employeeID
                       AND bonusDate BETWEEN @period_start AND @period_end), 0) AS bonus,
            IFNULL((SELECT SUM(DATEDIFF(LEAST(@period_end, l.endDate), GREATEST(@period_start, l.startDate)) + 1)
                     FROM leaverecord l
                     WHERE l.employeeID = e.employeeID
                       AND l.isLeaveWithPay = 1
                       AND l.startDate <= @period_end
                       AND l.endDate >= @period_start), 0) AS paid_leave_days
        FROM
            employee e
        LEFT JOIN (
            SELECT
                a.employeeID,
                (SUM(TIMESTAMPDIFF(MINUTE, a.timeIn, a.timeOut)) - (COUNT(a.employeeID) * 60)) / 60 AS total_hours_worked,
                SUM(GREATEST(TIMESTAMPDIFF(MINUTE, s.timeIn, a.timeIn), 0)) AS total_late_minutes,
                SUM(GREATEST(TIMESTAMPDIFF(MINUTE, a.timeOut, s.timeOut), 0)) AS total_undertime_minutes
            FROM attendance a
            JOIN shiftemployee se ON a.employeeID = se.employeeID AND a.date BETWEEN se.startDate AND se.endDate
            JOIN shift s ON se.shiftID = s.shiftID
            WHERE a.employeeID = @employee_id
              AND a.date BETWEEN @period_start AND @period_end
              AND a.status != 'Absent'
            GROUP BY a.employeeID
        ) AS att_summary ON e.employeeID = att_summary.employeeID
        WHERE
            e.employeeID = @employee_id
        GROUP BY
            e.employeeID, e.hourlyRate;
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
                            int paidLeaveDays = Convert.ToInt32(reader["paid_leave_days"]);

                            deductionTypes = reader["detailed_deductions"].ToString();
                            bonusTypes = reader["detailed_bonuses"].ToString();

                            // Same calculation logic as before, but now it will have the correct data
                            decimal totalHours = hoursWorked + (paidLeaveDays * 8); // Assuming 8 hours per leave day
                            decimal grossPay = Math.Max(totalHours * hourlyRate, 0);
                            decimal totalPenalty = ((totalLates + totalUndertime) / 60) * hourlyRate;
                            decimal netPay = Math.Max(grossPay - totalPenalty - totalDeductions + totalBonuses, 0);

                            textBox1.Text = totalLates.ToString("F0");
                            textBox2.Text = totalUndertime.ToString("F0");
                            textBox3.Text = grossPay.ToString("F2");
                            textBox4.Text = totalPenalty.ToString("F2");
                            textBox5.Text = totalDeductions.ToString("F2");
                            textBox6.Text = totalBonuses.ToString("F2");
                            textBox7.Text = netPay.ToString("F2");

                            button1.Visible = netPay > 0;
                        }
                        else
                        {
                            MessageBox.Show("Could not find employee data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ClearTextBoxes();
                        }
                    }
                }
            }
            else
            {
                ClearTextBoxes();
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
            Font headerFont = new Font("Arial", 14, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 12);
            Font totalFont = new Font("Arial", 12, FontStyle.Bold);
            Brush brush = Brushes.Black;
            int startX = 50;
            int startY = 50;
            int lineHeight = 30;

            e.Graphics.DrawString("Payroll Summary", titleFont, brush, startX + 175, startY);
            startY += lineHeight * 2;


            e.Graphics.DrawString("Employee Name: " + comboBox1.Text, bodyFont, brush, startX, startY);
            startY += lineHeight;

            
            
            e.Graphics.DrawLine(Pens.Black, startX, startY, startX + 500, startY);
            startY += lineHeight;

            if (decimal.TryParse(textBox1.Text, out decimal totalLates) && totalLates > 0)
            {
                e.Graphics.DrawString("Late (minutes)", bodyFont, brush, startX, startY);
                e.Graphics.DrawString(textBox1.Text, bodyFont, brush, startX + 300, startY);
                startY += lineHeight;
            }


            if (decimal.TryParse(textBox2.Text, out decimal totalUndertime) && totalUndertime > 0)
            {
                e.Graphics.DrawString("Undertime (minutes)", bodyFont, brush, startX, startY);
                e.Graphics.DrawString(textBox2.Text, bodyFont, brush, startX + 300, startY);
                startY += lineHeight;
            }

            e.Graphics.DrawString("Gross Pay", bodyFont, brush, startX, startY);
            e.Graphics.DrawString("₱" + textBox3.Text, bodyFont, brush, startX + 300, startY);
            startY += lineHeight;

            e.Graphics.DrawString("Penalty", bodyFont, brush, startX, startY);
            e.Graphics.DrawString("₱" + textBox4.Text, bodyFont, brush, startX + 300, startY);
            startY += lineHeight;

            if (decimal.TryParse(textBox5.Text, out decimal totalDeductions) && totalDeductions > 0)
            {
                e.Graphics.DrawString("Deductions", bodyFont, brush, startX, startY);
                e.Graphics.DrawString("₱" + textBox5.Text, bodyFont, brush, startX + 300, startY);
                startY += lineHeight;
            }

            if (decimal.TryParse(textBox6.Text, out decimal totalBonuses) && totalBonuses > 0)
            {
                e.Graphics.DrawString("Bonuses", bodyFont, brush, startX, startY);
                e.Graphics.DrawString("₱" + textBox6.Text, bodyFont, brush, startX + 300, startY);
                startY += lineHeight;
            }

            e.Graphics.DrawLine(Pens.Black, startX, startY, startX + 500, startY);
            startY += lineHeight;

            e.Graphics.DrawString("Net Pay", totalFont, brush, startX, startY);
            e.Graphics.DrawString("₱" + textBox7.Text, totalFont, brush, startX + 300, startY);
            startY += lineHeight * 2;

            e.Graphics.DrawString("Date Printed: " + DateTime.Now.ToString("MMMM dd, yyyy HH:mm tt"), bodyFont, brush, startX, startY);
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


                    LoadPayrollSummary();

                    PrintDialog print = new PrintDialog();
                    print.Document = printDocument1;

                    DialogResult result = print.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        printDocument1.Print();

                        decimal.TryParse(textBox3.Text, out decimal grossPay);
                        decimal.TryParse(textBox4.Text, out decimal penalty);
                        decimal.TryParse(textBox5.Text, out decimal deductions);
                        decimal.TryParse(textBox6.Text, out decimal bonuses);
                        decimal.TryParse(textBox7.Text, out decimal netPay);

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
                            cmd.Parameters.AddWithValue("@bunos", bonuses); 
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
                comboBox1.SelectedIndex = 0; 
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

                    dt.Columns.Add("Display", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime start = Convert.ToDateTime(row["periodStart"]);
                        DateTime end = Convert.ToDateTime(row["periodEnd"]);

                        row["Display"] = $"{start:MMMM d} to {end:dd} / {end:yyyy}";
                    }

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
                        comboBox1.Text = reader["Name"].ToString(); 

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
