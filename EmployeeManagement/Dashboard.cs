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
        public partial class Dashboard: Form
        {
            public Dashboard()
            {
                InitializeComponent();

                attendancestartDTP.ValueChanged += AttendaceDateRangeChanged;
                attendanceEndDTP.ValueChanged += AttendaceDateRangeChanged;
                LoadEmployeeNamesToComboBox();
            //this.attendanceSearchBox.TextChanged += new System.EventHandler(this.attendanceButton_Click);


        }

            private void LogOutButton_Click(object sender, EventArgs e)
            {
                Login login = new Login();
                login.Show();
                this.Close();


            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                DateTime now = DateTime.Now;
                datelabel.Text = now.ToString("dd/MM/yyyy");
                timelabel.Text = now.ToString("hh:mm:ss tt");
            }
            public void ShowEmployeeControls()
            {
                addAttendanceButton.Visible = false;
                attendanceSearchLabel.Visible = false;
                comboBox1.Visible = false;
                attendancenameLabel.Visible = false;
                attendanceNameBox.Visible = false;
                attendancestartDTP.Visible = false;
                attendanceEndDTP.Visible = false;
                startDateLabel.Visible = false;
                endDateLabel.Visible = false;
                datelabel.Visible = false;
                timelabel.Visible = false;
                DateeLabel.Visible = false;
                TimeeLabel.Visible = false;

                searchLabel.Visible = true;
                searchBox.Visible = true;
                AddButton.Visible = true;
                UpdateButton.Visible = true;
                dataGridView1.Visible = true;
                SearchButton.Visible = true;
                LoadEmployeesToGrid();
            }
        public void EmployeeButton_Click(object sender, EventArgs e)
            {
            ShowEmployeeControls();
            }
            private void Dashboard_FormClosing(object sender, FormClosingEventArgs e) // to exit the form 
            {
                Application.Exit();
            }

            private void AddButton_Click(object sender, EventArgs e)
            {
                AddEmployee addEmployee = new AddEmployee(this);
                addEmployee.Show();
               
            }

            private void Dashboard_Load(object sender, EventArgs e)
            {
                attendanceSearchLabel.Visible = false;
                comboBox1.Visible = false;
                attendancenameLabel.Visible = false;
                attendanceNameBox.Visible = false;
                attendancestartDTP.Visible = false;
                attendanceEndDTP.Visible = false;
                startDateLabel.Visible = false;
                endDateLabel.Visible = false;
                addAttendanceButton.Visible = false;

                DateeLabel.Visible = true;
                TimeeLabel.Visible = true;

        }
            private void LoadEmployeesToGrid()
            {
                dataGridView1.DataSource = dbConn.GetAllEmployees();
            }
        private void LoadAllAttendance()
        {
            dataGridView1.DataSource = dbConn.GetAllAttendanceData();
            if (dataGridView1.Columns.Contains("employeeID"))
            {
                dataGridView1.Columns["employeeID"].Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void AddButtonDept_Click(object sender, EventArgs e)
            {

            }

            private void UpdateButton_Click(object sender, EventArgs e)
            {
                UpdateEmployee updateEmployee = new UpdateEmployee(this);
                updateEmployee.Show();
                
            }
            private void searchBox_TextChanged(object sender, EventArgs e) // For showing employee names in the textbox
            {
                string searchText = searchBox.Text.Trim();
                label1.Visible = true;
                if (string.IsNullOrEmpty(searchText))
                {
                    DataTable allEmployees = dbConn.GetAllEmployees();
                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = allEmployees;

                    // Clear the label if all employees are shown
                    label1.Text = string.Empty;
                }
                else
                {
                    int employeeID;
                    bool isNumeric = int.TryParse(searchText, out employeeID);

                    DataTable filteredEmployees = dbConn.EmployeeSearch(isNumeric ? employeeID : 0, searchText);
                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = filteredEmployees;

                    // Check if the filtered DataTable is empty
                    if (filteredEmployees.Rows.Count == 0)
                    {
                        label1.Text = "Employee not found"; // Show message if no employees found
                    }
                    else
                    {
                        label1.Text = string.Empty; // Clear the label if employees are found
                    }
                }
            }



            // Optional helper method to reorder columns explicitly
            // KANI PARA NI MAG ORDER ANG COLUMN SA DATA GRID VIEW

            //private void ReorderDataGridViewColumns()
            //{
            //    if (dataGridView1.Columns.Contains("employeeID"))
            //    {
            //        dataGridView1.Columns["employeeID"].DisplayIndex = 0;
            //    }
            //    if (dataGridView1.Columns.Contains("Name"))
            //    {
            //        dataGridView1.Columns["Name"].DisplayIndex = 1;
            //    }
            //}

            private void addShiftButton_Click(object sender, EventArgs e)
                {
                    AssignShift assignShift = new AssignShift();
                    assignShift.ShowDialog();
                    this.Close();
                    
                }
            public void ShowAllAttendance() 
                {
                searchLabel.Visible = false;
                searchBox.Visible = false;
                SearchButton.Visible = false;
                AddButton.Visible = false;
                UpdateButton.Visible = false;
                datelabel.Visible = false;
                timelabel.Visible = false;

                attendanceSearchLabel.Visible = true;
                addAttendanceButton.Visible = true;
                comboBox1.Visible = true;
                attendancestartDTP.Visible = true;
                attendanceEndDTP.Visible = true;
                startDateLabel.Visible = true;
                endDateLabel.Visible = true;
                dataGridView1.Visible = true;


                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                LoadAllAttendance();
             }
           

        public void attendanceButton_Click(object sender, EventArgs e)
            {
                

            ShowAllAttendance();
            }

            private void DashboardButton_Click(object sender, EventArgs e)
            {
                datelabel.Visible = true;
                timelabel.Visible = true;
                DateeLabel.Visible = true;
                TimeeLabel.Visible = true;

                dataGridView1.Visible = false;
                label1.Visible = false;
                comboBox1.Visible =false;
                attendanceNameBox.Visible = false;
                searchLabel.Visible = false;
                searchBox.Visible = false;
                attendanceSearchLabel.Visible = false;
                endDateLabel.Visible = false;
                startDateLabel.Visible = false;
                SearchButton.Visible = false;
                AddButton.Visible = false;
                UpdateButton.Visible = false;
                attendanceEndDTP.Visible = false;
                attendancestartDTP.Visible=false;
                addAttendanceButton.Visible = false;
        }

            private void addAttendanceButton_Click(object sender, EventArgs e)
            {
                // Pass the current instance of Dashboard to AddAttendance
                    AddAttendance addAttendance = new AddAttendance(this);  // 'this' refers to the current instance of Dashboard
                    addAttendance.Show();  // Show the AddAttendance form as a dialog
                

                DateeLabel.Visible = false;
                TimeeLabel.Visible = false;
            }

            private void panel1_Paint(object sender, PaintEventArgs e)
            {

                datelabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
                timelabel.Text = DateTime.Now.ToString("hh:mm:ss tt");


                DashboardButton.Visible = true;
                EmployeeButton.Visible = true;
                addShiftButton.Visible = true;
                attendanceButton.Visible = true;
                LogOutButton.Visible = true;
                datelabel.Visible = true;
                timelabel.Visible = true;
                timer1.Start();
            }

            private void timer1_Tick_1(object sender, EventArgs e)
            {
                datelabel.Text = DateTime.Now.ToLongDateString();
                timer1.Start();
                timelabel.Text = DateTime.Now.ToLongTimeString();

            }

        private void LoadFilteredAttendanceByDateRange(DateTime startDate, DateTime endDate)
        {
            // Check if the start date is after the end date
            if (startDate > endDate)
            {
                MessageBox.Show("Start date must be before or equal to end date.", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                SELECT DISTINCT 
                    e.employeeID,
                    CONCAT(e.Fname, ' ', e.Lname) AS FullName,
                    a.Date AS AttendanceDate,
                    a.timeIn,
                    a.timeOut,
                    a.status AS Status  -- Added status column
                FROM employee e
                INNER JOIN attendance a ON e.employeeID = a.employeeID
                WHERE a.Date BETWEEN @startDate AND @endDate
                ORDER BY a.Date, e.Lname";
            try
            {
                MySqlConnection conn = dbConn.Instance.Connection;

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                    cmd.Parameters.AddWithValue("@endDate", endDate.Date);

                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No attendance records found for the selected date range.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        dataGridView1.AutoGenerateColumns = true;
                        //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        //dataGridView1.Columns.Clear(); // Clear any previous columns
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadEmployeeNamesToComboBox()
        {
            string query = "SELECT employeeID, CONCAT(Fname, ' ', Lname) AS FullName FROM employee";

            try
            {
                MySqlConnection conn = dbConn.Instance.Connection;
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                DataTable dt = new DataTable();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                // Add placeholder row
                DataRow newRow = dt.NewRow();
                newRow["employeeID"] = DBNull.Value;
                newRow["FullName"] = "Select Employee";
                dt.Rows.InsertAt(newRow, 0);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "FullName";
                comboBox1.ValueMember = "employeeID";
                comboBox1.SelectedIndex = 0;

                // Event handler to load attendance when selection changes
                comboBox1.SelectedIndexChanged += (s, e) =>
                {
                    if (comboBox1.SelectedIndex <= 0 || comboBox1.SelectedValue == null || comboBox1.SelectedValue == DBNull.Value)
                        return;

                    int employeeID = Convert.ToInt32(comboBox1.SelectedValue);

                    // Modified query to include status
                    string attendanceQuery = @"
            SELECT 
                e.employeeID,
                CONCAT(e.Fname, ' ', e.Lname) AS FullName,
                a.Date AS AttendanceDate,
                a.timeIn,
                a.timeOut,
                a.status  -- Added status column
            FROM employee e
            INNER JOIN attendance a ON e.employeeID = a.employeeID
            WHERE e.employeeID = @employeeID
            ORDER BY a.Date";

                    try
                    {
                        using (MySqlCommand attCmd = new MySqlCommand(attendanceQuery, conn))
                        {
                            attCmd.Parameters.AddWithValue("@employeeID", employeeID);

                            using (MySqlDataAdapter attAdapter = new MySqlDataAdapter(attCmd))
                            {
                                DataTable attTable = new DataTable();
                                attAdapter.Fill(attTable);

                                dataGridView1.AutoGenerateColumns = true;
                                dataGridView1.DataSource = attTable;
                                dataGridView1.Columns["employeeID"].Visible = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading attendance: " + ex.Message);
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message);
            }
        }

        private void AttendaceDateRangeChanged(object sender, EventArgs e)
        {
            DateTime startDate = attendancestartDTP.Value;
            DateTime endDate = attendanceEndDTP.Value;

            LoadFilteredAttendanceByDateRange(startDate, endDate);
        }

        private void timelabel_Click(object sender, EventArgs e)
            {

            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }

            private void ExitButton_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

        private void payrollButton_Click(object sender, EventArgs e)
        {
            Payroll payroll = new Payroll();
            payroll.ShowDialog(); // Show the Payroll form as a dialog
            this.Close(); // Close the current Dashboard form
        }

        public void deductoinButton_Click(object sender, EventArgs e)
        {
            Deduction deductoin = new Deduction();
            deductoin.ShowDialog();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }
    }
    }
