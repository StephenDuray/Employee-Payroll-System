using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeManagement
{
	public partial class AddAttendance : Form
	{
		private Dashboard dashboard;
		public AddAttendance(Dashboard dashboard)
		{
			InitializeComponent();
			this.Load += new System.EventHandler(this.AddAttendance_Load);
			comboBox1.TextChanged += (s, e) => LoadForLateUnderTimeHoursWork();
			dtp1.ValueChanged += (s, e) => LoadForLateUnderTimeHoursWork();
			dtp2.ValueChanged += (s, e) => LoadForLateUnderTimeHoursWork();
			this.dashboard = dashboard;

		}

		private void AddAttendance_Load(object sender, EventArgs e)
		{
			dtp1.Format = DateTimePickerFormat.Custom;
			dtp1.CustomFormat = "MM/dd/yyyy HH:mm:ss";
			dtp1.ShowUpDown = true;

			dtp2.Format = DateTimePickerFormat.Custom;
			dtp2.CustomFormat = "MM/dd/yyyy HH:mm:ss";
			dtp2.ShowUpDown = true;
		}

		private void attendEmployeeIDBox_TextChanged(object sender, EventArgs e)
		{
		   
		}

		private void dtp1_ValueChanged(object sender, EventArgs e)
		{
			// CalculateAttendanceFields();
		}

		private void dtp2_ValueChanged(object sender, EventArgs e)
		{
			// CalculateAttendanceFields();
		}

        //private void CalculateAttendanceFields()
        //{
        //    DateTime timeIn = dtp1.Value;
        //    DateTime timeOut = dtp2.Value;

        //    if (timeOut <= timeIn)
        //    {
        //        lateBox.Text = "";
        //        undertimeBox.Text = "";
        //        totalworkBox.Text = "";
        //        return;
        //    }

        //    // Simple calculation: total work = timeOut - timeIn - 1 hour lunch
        //    TimeSpan rawWorked = timeOut - timeIn;
        //    TimeSpan worked = rawWorked - TimeSpan.FromHours(1);
        //    if (worked.TotalMinutes < 0) worked = TimeSpan.Zero;

        //    // If you want to allow manual entry for late/undertime, leave these blank
        //    // Or, you can set them to 0 by default
        //    lateBox.Text = "0";
        //    undertimeBox.Text = "0";
        //    totalworkBox.Text = $"{(int)worked.TotalHours}h {worked.Minutes}m";
        //}
        private void addAttendButton_Click(object sender, EventArgs e)
        {
            // ✅ Step 1: Validate employee selection
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid employee.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if SelectedValue is DBNull before converting
            object selectedValue = comboBox1.SelectedValue;
            if (selectedValue == DBNull.Value)
            {
                MessageBox.Show("Invalid employee selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int employeeID = Convert.ToInt32(selectedValue); // Using ValueMember for safety
            DateTime selectedDate = dtp1.Value.Date;

            // ✅ Step 2: Get status from radio buttons — only Present or Absent
            string status = "";

            if (radioButton1.Checked)
                status = "Present";
            else if (radioButton2.Checked)
                status = "Absent";
            else
            {
                MessageBox.Show("Please select if the employee is Present or Absent.", "Missing Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Step 3: Handle absent case first (skip time validations)
            TimeSpan timeIn, timeOut;
            int minutesLates = 0;
            int underTimeMinutes = 0;
            string hoursworked = "0h 0m";

            if (status == "Absent")
            {
                timeIn = TimeSpan.Zero;
                timeOut = TimeSpan.Zero;

                // Auto-update DateTimePickers to 00:00
                dtp1.Value = selectedDate.AddHours(0).AddMinutes(0);
                dtp2.Value = selectedDate.AddHours(0).AddMinutes(0);
            }
            else
            {
                // ✅ Step 4: Validate shift exists
                if (!dbConn.HasShiftAssignedOnDate(employeeID, selectedDate))
                {
                    MessageBox.Show("The selected employee does not have a shift assigned on this date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ Step 5: Time validations for Present status
                timeIn = dtp1.Value.TimeOfDay;
                timeOut = dtp2.Value.TimeOfDay;

                if (timeOut <= timeIn)
                {
                    MessageBox.Show("Time out must be later than Time in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ Step 6: Late, Undertime, Hours Worked
                minutesLates = Convert.ToInt32(lateBox.Text);
                underTimeMinutes = Convert.ToInt32(undertimeBox.Text);
                hoursworked = totalworkBox.Text;
            }

            // ✅ Step 7: Prevent duplicate attendance
            if (dbConn.AttendanceExists(employeeID, selectedDate))
            {
                MessageBox.Show("Attendance for this employee on this date already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ Step 8: Save attendance
            if (dbConn.AddAttendance(employeeID, selectedDate, timeIn, timeOut, minutesLates, underTimeMinutes, hoursworked, status))
            {
                MessageBox.Show("Attendance added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to add attendance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearInputFields()
		{
			comboBox1.Items.Clear();
			lateBox.Clear();
			undertimeBox.Clear();
			totalworkBox.Clear();
			dtp1.Value = DateTime.Now; 
			dtp2.Value = DateTime.Now; 
		}
        private void LoadForLateUnderTimeHoursWork()
        {
            // If the employee is marked as Absent, reset the fields and return early
            if (radioButton2.Checked)
            {
                ResetFields();
                return;
            }

            if (comboBox1.SelectedIndex <= 0)
            {
                // Only show the message if the user interacts with the ComboBox but selects nothing
                if (comboBox1.DroppedDown || comboBox1.Focused)
                {
                    MessageBox.Show("Please select a valid employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            // Get the selected employee ID directly
            int employeeID = Convert.ToInt32(comboBox1.SelectedValue);

            // Time validation: Ensure Time In is before Time Out
            DateTime timeIn = dtp1.Value;
            DateTime timeOut = dtp2.Value;

            if (timeIn > timeOut)
            {
                MessageBox.Show("Time In cannot be after Time Out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL query to fetch shift timings for the employee
            string shiftQuery = "SELECT timeIn, timeOut FROM shiftemployee es INNER JOIN shift s ON s.shiftID = es.shiftID WHERE es.employeeID = @id";

            using (MySqlCommand cmd = new MySqlCommand(shiftQuery, dbConn.Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@id", employeeID);

                if (dbConn.Instance.Connection.State != ConnectionState.Open)
                    dbConn.Instance.Connection.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        TimeSpan shiftIn = reader.GetTimeSpan("timeIn");
                        TimeSpan shiftOut = reader.GetTimeSpan("timeOut");

                        TimeSpan actualIn = timeIn.TimeOfDay;
                        TimeSpan actualOut = timeOut.TimeOfDay;

                        // Calculate late minutes
                        int lateMinutes = Math.Max(0, (int)(actualIn - shiftIn).TotalMinutes);

                        // Calculate undertime minutes
                        int undertimeMinutes = Math.Max(0, (int)(shiftOut - actualOut).TotalMinutes);

                        // Clamp actualIn and actualOut to within the shift boundaries
                        TimeSpan effectiveStart = actualIn > shiftIn ? actualIn : shiftIn;
                        TimeSpan effectiveEnd = actualOut < shiftOut ? actualOut : shiftOut;

                        TimeSpan rawWorked = effectiveEnd - effectiveStart;

                        // Deduct 1 hour for lunch
                        TimeSpan worked = rawWorked - TimeSpan.FromHours(1);
                        if (worked.TotalMinutes < 0) worked = TimeSpan.Zero;

                        // Update the UI with the calculated values
                        lateBox.Text = lateMinutes.ToString();                          // Late
                        undertimeBox.Text = undertimeMinutes.ToString();                    // Undertime
                        totalworkBox.Text = $"{(int)worked.TotalHours}h {worked.Minutes}m"; // Total worked time
                    }
                    else
                    {
                        MessageBox.Show("No shift assigned to this employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ResetFields()
        {
            lateBox.Text = "0";
            undertimeBox.Text = "0";
            totalworkBox.Text = "0h 0m";
        }

        private void totalworkBox_TextChanged(object sender, EventArgs e)
		{

		}

		private void AddAttendance_Load_1(object sender, EventArgs e)
		{
            // Populate the ComboBox with employee names when the form loads
            //ComboBoxNames();
            LoadEmployeesToComboBox();

        }

		private void BackButton_Click(object sender, EventArgs e)
		{
			// Call the ShowEmployeeControls method from Dashboard
			dashboard.ShowAllAttendance();  // This will show the employee controls as per EmployeeButton_Click logic

			// Trigger EmployeeButton_Click directly to simulate the button click
			dashboard.attendanceButton_Click(sender, e);  // This triggers the functionality of the EmployeeButton

			// Hide the current AddAttendance form
			this.Hide();  // This hides the AddAttendance form, but Dashboard stays open
			dashboard.Show();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

           /// Only process if a valid employee is selected(not the default "Select Employee")
             if (comboBox1.SelectedValue != null && comboBox1.SelectedValue != DBNull.Value)
            {
                int selectedEmployeeID = Convert.ToInt32(comboBox1.SelectedValue);

               

                // Example: LoadEmployeeDetails(selectedEmployeeID);
                // Example: CalculateAttendance(selectedEmployeeID);
            }
            else
            {
                // Handle "Select Employee" case
                // Clear fields or reset values if needed
            }
        }
        private void LoadEmployeesToComboBox()
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
                    comboBox1.DisplayMember = "FullName";  // What users see
                    comboBox1.ValueMember = "employeeID";  // Actual value
                    comboBox1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void attendEmployeeName_TextChanged(object sender, EventArgs e)
		{

		}

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }





        //private void addAttendButton_Click(object sender, EventArgs e)
        //{

        //    int employeeID = int.Parse(attendEmployeeIDBox.Text.Trim());

        //    DateTime dateTime = dtp1.Value;
        //    DateTime dateTimeOut = dtp2.Value;
        //    DateTime dateAttendance = dateTime.Date;
        //    TimeSpan timeIn = dateTime.TimeOfDay;
        //    TimeSpan timeOut = dateTimeOut.TimeOfDay;
        //    int lateMinutes = Convert.ToInt32(lateBox.Text);
        //    int underTime = Convert.ToInt32(undertimeBox.Text);
        //    string hoursWorked = totalworkBox.Text;

        //    if (dateTimeOut <= dateTime)
        //    {
        //        MessageBox.Show("Time out must be later than Time in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (dbConn.AddAttendance(employeeID, dateAttendance, timeIn, timeOut, lateMinutes, underTime, hoursWorked))
        //    {
        //        MessageBox.Show("Attendance added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
    }
}
