using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Odbc;
using EmployeeManagement;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
namespace EmployeeManagement
{
    public sealed class dbConn
    {
        private static readonly Lazy<dbConn> instance = new Lazy<dbConn>(() => new dbConn());
        private MySqlConnection connection;
        

        private dbConn()
        {
            string connectionString = "server=localhost;database=employeemanagementsystem;user=root;password=;";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public static dbConn Instance => instance.Value;

        public MySqlConnection Connection
        {
            get
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                return connection;
            }
        }
        
        public static bool AuthenticateUser(string username, string password)
        {
            string query = "SELECT * FROM admin WHERE username = @username AND password = SHA2(@password, 256)";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public static bool AddUser(string username, string password, string Fname, string Lname)
        {
            string query = "INSERT INTO admin (username, password, Fname, Lname) " +
                           "VALUES (@username, SHA2(@password, 256), @Fname, @Lname)";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@Fname", Fname);
                cmd.Parameters.AddWithValue("@Lname", Lname);
                return cmd.ExecuteNonQuery() > 0;   
            }
        }
        public static int AddEmployee(string Fname, string Lname, string Gender, string Email, DateTime DateofBirth, string Position, int hourlyRate, string ContactNum, string DepartmentName, byte[] imageBytes)
        {
            string query = @"
        INSERT INTO employee (Fname, Lname, Gender, DateofBirth, Position, hourlyRate, ContactNum, Email, departmentID, photo)
        SELECT @Fname, @Lname, @Gender, @DateofBirth, @Position, @hourlyRate, @ContactNum, @Email, d.departmentID, @photo
        FROM departments d
        WHERE d.departmentName = @DepartmentName;
        SELECT LAST_INSERT_ID();"; // Get the last inserted ID

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@Fname", Fname);
                cmd.Parameters.AddWithValue("@Lname", Lname);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@DateofBirth", DateofBirth);
                cmd.Parameters.AddWithValue("@Position", Position);
                cmd.Parameters.AddWithValue("@hourlyRate", hourlyRate);
                cmd.Parameters.AddWithValue("@ContactNum", ContactNum);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);
                cmd.Parameters.AddWithValue("@photo", imageBytes);

                try
                {
                    if (Instance.Connection.State != ConnectionState.Open)
                        Instance.Connection.Open();

                    int employeeId = Convert.ToInt32(cmd.ExecuteScalar());
                    return employeeId;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("MySQL Error: " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                finally
                {
                    if (Instance.Connection.State == ConnectionState.Open)
                        Instance.Connection.Close();
                }
            }
        }
        public static List<string> GetEmployeeNames()
        {
            var employeeNames = new List<string>();
            string query = "SELECT CONCAT(Fname, ' ', Lname) AS FullName FROM employee";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employeeNames.Add(reader.GetString(0));  // Assuming the employee name is in the first column
                    }
                }
            }

            return employeeNames;
        }

        public static bool UpdateEmployee(int employeeID, string Fname, string Lname, string Gender, DateTime DateofBirth, string Position, int hourlyRate, string ContactNum, string Email, string DepartmentName, string Status)
        {
            string query = @"
             UPDATE employee 
             SET Fname = @Fname, Lname = @Lname, Gender = @Gender, DateofBirth = @DateofBirth, 
                 Position = @Position, hourlyRate = @HourlyRate, ContactNum = @ContactNum, 
                 Email = @Email, departmentID = (SELECT departmentID FROM departments WHERE departmentName = @DepartmentName),
                 Status = @Status
             WHERE employeeID = @EmployeeID";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@Fname", Fname);
                cmd.Parameters.AddWithValue("@Lname", Lname);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@DateofBirth", DateofBirth);
                cmd.Parameters.AddWithValue("@Position", Position);
                cmd.Parameters.AddWithValue("@HourlyRate", hourlyRate);
                cmd.Parameters.AddWithValue("@ContactNum", ContactNum);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static List<string> GetDepartmentNames()
        {
            var departments = new List<string>();
            string query = "SELECT departmentName FROM departments"; 
            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        departments.Add(reader.GetString(0));
                    }
                }
            }
            return departments;
        }
        public static List<string> GetShiftType()
        { 
            var shifts = new List<string>();
            string query = "SELECT shiftType FROM shift";
            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        shifts.Add(reader.GetString(0));
                    }
                }
            }
            return shifts;
        }
        public static DataTable GetAllEmployees() // kani para inig search sa employee sa employeebutton ni mahhitabo
        {
            DataTable dt = new DataTable();
            string query = @"SELECT CONCAT(e.Fname,' ',e.Lname) as Name, e.Gender, e.DateofBirth, e.Position, e.hourlyRate, e.ContactNum, e.Email, d.departmentName as Department, e.Status
                    FROM employee e
                    JOIN departments d ON e.departmentID = d.departmentID";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public static DataTable SearchEmployees(string searchText)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT e.employeeID, e.Fname, e.Lname, e.Gender, e.DateofBirth, e.Position, e.hourlyRate, 
                            e.ContactNum, e.Email, d.departmentName AS Department, e.Status
                     FROM employee e
                     JOIN departments d ON e.departmentID = d.departmentID
                     WHERE e.Fname LIKE @search OR e.Lname LIKE @search OR e.Email LIKE @search OR e.ContactNum LIKE @search";
            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public static DataRow GetEmployeeRowByID(int employeeID)
        {
            string query = @"SELECT e.employeeID, e.Fname, e.Lname, e.Gender, e.DateofBirth, e.Position, e.hourlyRate, 
                            e.ContactNum, e.Email, d.departmentName AS Department, e.Status
                     FROM employee e
                     JOIN departments d ON e.departmentID = d.departmentID
                     WHERE e.employeeID = @EmployeeID";
            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt.Rows.Count == 1 ? dt.Rows[0] : null;
                }
            }
        }

        public static DataTable EmployeeSearch(int employeeID, string searchText)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT e.employeeID, CONCAT(e.Fname, ' ', e.Lname) AS Name, e.Gender, e.DateofBirth, e.Position, e.hourlyRate, 
               e.ContactNum, e.Email, d.departmentName AS Department, e.Status 
                FROM employee e 
               JOIN departments d ON e.departmentID = d.departmentID
               WHERE 
               (@employeeID = 0 AND 
                (
                    @searchText = '' 
                    OR e.Fname LIKE @search 
                    OR e.Lname LIKE @search
                )
                 )
                    OR (e.employeeID = @employeeID)
                     ";


            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@employeeID", employeeID);
                cmd.Parameters.AddWithValue("@searchText", searchText ?? "");
                cmd.Parameters.AddWithValue("@search", "%" + (searchText ?? "") + "%");
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public static bool AddShiftEmployee(int employeeID, int shiftID, DateTime startDate, DateTime endDate)
        {
            // First, insert the shift assignment into the shiftemployee table
            string insertQuery = @"
                  INSERT INTO shiftemployee (employeeID, shiftID, startDate, endDate)
                  VALUES (@employeeID, @shiftID, @startDate, @endDate);";

            using (MySqlCommand cmd = new MySqlCommand(insertQuery, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@employeeID", employeeID);
                cmd.Parameters.AddWithValue("@shiftID", shiftID);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Optionally, retrieve the shiftType if needed
                        string shiftTypeQuery = @"
                        SELECT s.shiftType 
                        FROM shift s 
                        WHERE s.shiftID = @shiftID;
                    ";

                        using (MySqlCommand typeCmd = new MySqlCommand(shiftTypeQuery, Instance.Connection))
                        {
                            typeCmd.Parameters.AddWithValue("@shiftID", shiftID);
                            string shiftType = typeCmd.ExecuteScalar()?.ToString();

                            // You can now use shiftType as needed, e.g., log it or return it
                            System.Diagnostics.Debug.WriteLine("Shift Type: " + shiftType);
                        }

                        return true; // Insertion was successful
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception for debugging
                    System.Diagnostics.Debug.WriteLine("Error in AddShiftEmployee: " + ex.Message);
                    return false; // Insertion failed
                }
            }

            return false; // Insertion failed
        }
       
        public static int GetShiftIDByName(string shiftName)
        {
            string query = "SELECT shiftID FROM shift WHERE shiftType = @shiftType LIMIT 1;";
            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@shiftType", shiftName);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
        public static bool ExistingShift(int employeeID, DateTime newStart, DateTime newEnd)
        {
            string query = @"
                     SELECT COUNT(*) FROM shiftemployee
                     WHERE employeeID = @employeeID
                     AND NOT (@newEnd < startDate OR @newStart > endDate)";
            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@employeeID", employeeID);
                cmd.Parameters.AddWithValue("@newStart", newStart);
                cmd.Parameters.AddWithValue("@newEnd", newEnd);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        public static bool AttendanceExists(int employeeID, DateTime date)
        {
            string query = "SELECT COUNT(*) FROM attendance WHERE employeeID = @EmployeeID AND date = @Date";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@Date", date.Date);  // Ensure to compare only the date part

                // Open connection if necessary
                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                // Execute query and check if the attendance exists
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;  // If the count is greater than 0, attendance exists
            }
        }

        public static string GetEmployeeNameByID(int employeeID) // attendance 
        {
            string query = "SELECT CONCAT(Fname, ' ', Lname) FROM employee WHERE employeeID = @employeeID";
            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@employeeID", employeeID);
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
        }
        //public static bool AddAttendance(int employeeId, DateTime date, TimeSpan timeIn, TimeSpan timeOut, int minutesLates, int undertimeMinutes, string hoursWorked)
        //{
        //    string query = @"INSERT INTO attendance (employeeID, date, timeIn, timeOut, minutesLates, undertimeMinutes, hoursWorked)
        //             VALUES (@employeeId, @date, @timeIn, @timeOut, @lateMinutes, @minutesLates, @hoursWorked)";

        //    using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
        //    {
        //        cmd.Parameters.AddWithValue("@employeeId", employeeId);
        //        cmd.Parameters.AddWithValue("@date", date);
        //        cmd.Parameters.AddWithValue("@timeIn", timeIn);
        //        cmd.Parameters.AddWithValue("@timeOut", timeOut);
        //        cmd.Parameters.AddWithValue("@minutesLates", minutesLates);
        //        cmd.Parameters.AddWithValue("@undertimeMinutes", undertimeMinutes);
        //        cmd.Parameters.AddWithValue("@hoursWorked", hoursWorked);

        //        try
        //        {
        //            return cmd.ExecuteNonQuery() > 0;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //    }
        //}

        public static bool AddAttendance(long employeeId, DateTime dateAttendance, TimeSpan timeIn, TimeSpan timeOut, int minutesLates, int underTimeminutes, string hoursWorked, string status) // 👈 Add status parameter  
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = Instance.Connection;
                cmd.CommandText = @"
        INSERT INTO attendance 
            (employeeID, date, timeIn, timeOut, minutesLates, underTimeminutes, hoursWorked, status) 
        VALUES 
            (@employeeId, @dateAttendance, @timeIn, @timeOut, @minutesLates, @underTimeminutes, @hoursWorked, @status);
    ";

                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@dateAttendance", dateAttendance.Date);
                cmd.Parameters.AddWithValue("@timeIn", timeIn);
                cmd.Parameters.AddWithValue("@timeOut", timeOut);
                cmd.Parameters.AddWithValue("@minutesLates", minutesLates);
                cmd.Parameters.AddWithValue("@underTimeminutes", underTimeminutes);
                cmd.Parameters.AddWithValue("@hoursWorked", hoursWorked ?? "00:00");
                cmd.Parameters.AddWithValue("@status", status);  // 👈 Add status parameter here

                try
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("No attendance record was inserted. Check if duplicate entry or constraint exists.", "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("MySQL Error: " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                        cmd.Connection.Close();
                }
            }

        }

        public static bool AttendanceExists(long employeeId, DateTime date)
        {
            string query = "SELECT COUNT(*) FROM attendance WHERE employee_id = @employeeId AND DATE(date) = @date";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@date", date.Date);

                try
                {
                    if (Instance.Connection.State != ConnectionState.Open)
                    {
                        Instance.Connection.Open();
                    }

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // Return true if attendance exists
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error in AttendanceExists: " + ex.Message);
                    return false; // Handle error appropriately
                }
                finally
                {
                    if (Instance.Connection.State == ConnectionState.Open)
                    {
                        Instance.Connection.Close();
                    }
                }
            }
        }
        public static bool HasAssignedShift(int employeeID)
        {
            string query = "SELECT COUNT(*) FROM shiftemployee WHERE employeeID = @EmployeeID";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                // Open connection if necessary
                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                // Execute query and get the result
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;  // If the count is greater than 0, the employee has a shift assigned
            }
        }
        public static bool HasShiftAssignedOnDate(int employeeID, DateTime date)
        {
            string query = "SELECT COUNT(*) FROM shiftemployee WHERE employeeID = @EmployeeID AND @Date BETWEEN startDate AND endDate";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@Date", date);  // Date to check

                // Open connection if necessary
                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                // Execute the query and check if a shift exists
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;  // Return true if a shift is found
            }
        }
        public static List<string> GetDeductionCategory()
        {
            List<string> deductionCategories = new List<string>();
            string query = @"SELECT deductionName FROM deductionCategory";
            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        deductionCategories.Add(reader.GetString(0));  // Assuming the deduction name is in the first column
                    }
                }
                return deductionCategories;
            }            
        }
        public int GetEmployeeIDByName(string firstName, string lastName)
        {
            string query = "SELECT employeeID FROM employee WHERE LOWER(Fname) = LOWER(@FirstName) AND LOWER(Lname) = LOWER(@LastName)";
            int employeeID = 0;

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);

                // Open connection if necessary
                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                // Execute query to get employee ID
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employeeID = reader.GetInt32(0);  // Assuming employeeID is in the first column
                    }
                    else
                    {
                        // Log the values being searched for debugging
                        System.Diagnostics.Debug.WriteLine($"Employee not found: FirstName = {firstName}, LastName = {lastName}");
                        throw new Exception("Employee not found."); // Throw an exception to handle it in the calling method
                    }
                }
            }

            return employeeID;
        }

        public static List<string> GetBunosNames() 
        {
            List<string> bonusNames = new List<string>();
            string query = "SELECT bunosName FROM bunosCategory"; // Assuming you have a table named bonusCategory
            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bonusNames.Add(reader.GetString(0));  // Assuming the bonus name is in the first column
                    }
                }
            }
            return bonusNames;
        }


            public static bool AddDeduction(int employeeID, string deductionName, decimal amount)
            {
             int deductionCatID = 0;

                // Get the deductionCatID from deductionCategories by name
                string getDeductionCatIDQuery = @"
                SELECT deductionCatID 
                FROM deductionCategory 
                WHERE deductionName = @deductionName";

                using (MySqlCommand getCatIdCmd = new MySqlCommand(getDeductionCatIDQuery, Instance.Connection))
                {
                    getCatIdCmd.Parameters.AddWithValue("@deductionName", deductionName);

                    if (Instance.Connection.State != ConnectionState.Open)
                        Instance.Connection.Open();

                    object result = getCatIdCmd.ExecuteScalar();
                    if (result != null)
                    {
                        deductionCatID = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Deduction category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                // Insert into deductions table
                    string insertQuery = @"
                    INSERT INTO deductions (employeeID, deductionCatID, amount) 
                    VALUES (@employeeID, @deductionCatID, @amount)";

                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, Instance.Connection))
                {
                    insertCmd.Parameters.AddWithValue("@employeeID", employeeID);
                    insertCmd.Parameters.AddWithValue("@deductionCatID", deductionCatID);
                    insertCmd.Parameters.AddWithValue("@amount", amount);

                    return insertCmd.ExecuteNonQuery() > 0;
                }
                
             }
            public static bool AddBonus(int employeeID, string bonusName, decimal amount) 
            {
                int  bunosCatID = 0;
                // Get the bonusCatID from bunosCategory by name
                    string getBonusCatIDQuery = @"
                        SELECT bunosCatID 
                        FROM bunosCategory 
                        WHERE bunosName = @bunosName";
                    using (MySqlCommand getCatIdCmd = new MySqlCommand(getBonusCatIDQuery, Instance.Connection))
                    {
                        getCatIdCmd.Parameters.AddWithValue("@bunosName", bonusName);
                        if (Instance.Connection.State != ConnectionState.Open)
                            Instance.Connection.Open();
                              object result = getCatIdCmd.ExecuteScalar();
                        if (result != null)
                        {
                            bunosCatID = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Bonus category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                         string insertQuery = @"INSERT INTO bunos    (employeeID, bunosCatID, amount)
                                                      VALUES (@employeeID, @bunosCatID, @amount)";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, Instance.Connection))
                        {
                            insertCmd.Parameters.AddWithValue("@employeeID", employeeID);
                            insertCmd.Parameters.AddWithValue("@bunosCatID", bunosCatID);
                            insertCmd.Parameters.AddWithValue("@amount", amount);

                            return insertCmd.ExecuteNonQuery() > 0;
                        }
             }
        public static bool EmployeeHasBonus(int employeeID, string bonusName)
        {
            int bunosCatID = 0;

            // Step 1: Get the bunosCatID for the given bonus name
            string getCatIDQuery = "SELECT bunosCatID FROM bunosCategory WHERE bunosName = @bonusName";

            using (MySqlCommand getCatIDCmd = new MySqlCommand(getCatIDQuery, Instance.Connection))
            {
                getCatIDCmd.Parameters.AddWithValue("@bonusName", bonusName);

                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                object result = getCatIDCmd.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Bonus category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                bunosCatID = Convert.ToInt32(result);
            }

            // Step 2: Check if a record already exists in the bunos table
            string checkQuery = @"
                SELECT COUNT(*) 
                FROM bunos 
                WHERE employeeID = @employeeID AND bunosCatID = @bunosCatID";

            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, Instance.Connection))
            {
                checkCmd.Parameters.AddWithValue("@employeeID", employeeID);
                checkCmd.Parameters.AddWithValue("@bunosCatID", bunosCatID);

                object result = checkCmd.ExecuteScalar();
                int count = Convert.ToInt32(result);
                return count > 0;
            }
        }


        public static DataTable GetAllAttendanceData()
        {
            string query = @"
        SELECT 
            e.employeeID, 
            CONCAT(e.Fname, ' ', e.Lname) AS Name,
            a.date AS Date,
            a.timeIn AS TimeIn,
            a.timeOut AS TimeOut,
            a.minutesLates AS Late,
            a.underTimeMinutes AS Undertime,
            a.hoursworked AS TotalHours,
            a.status AS Status,  -- Added status field
            s.shiftType AS ShiftType, 
            s.timeIn AS ShiftStart, 
            s.timeOut AS ShiftEnd
        FROM attendance a
        INNER JOIN employee e ON a.employeeID = e.employeeID
        INNER JOIN (
            SELECT se.employeeID, MAX(se.shiftID) AS shiftID
            FROM shiftemployee se
            GROUP BY se.employeeID
        ) latest_se ON latest_se.employeeID = e.employeeID
        INNER JOIN shift s ON latest_se.shiftID = s.shiftID
        ORDER BY a.date DESC";

            DataTable dt = new DataTable();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching all attendance data: " + ex.Message);
                return null;
            }

            return dt;
        }

        public static DataTable GetDeductions()
        {
                string query = @"
            SELECT 
                d.deductionID,
                CONCAT(e.Fname, ' ', e.Lname) AS EmployeeName,
                dc.deductionName,
                d.amount
            FROM 
                deductions d
            JOIN 
                employee e ON d.employeeID = e.employeeID
            JOIN 
                deductionCategory dc ON d.deductionCatID = dc.deductionCatID
            ORDER BY 
                e.employeeID;";

            DataTable dt = new DataTable();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
                {
                    if (Instance.Connection.State != ConnectionState.Open)
                        Instance.Connection.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching deductions: " + ex.Message);
                return null;
            }

            return dt;
        }
        public static void UpdateDeductionFromGrid(DataGridView grid, int rowIndex)
        {
            try
            {
                var row = grid.Rows[rowIndex];

                int deductionID = Convert.ToInt32(row.Cells["deductionID"].Value);
                string deductionName = row.Cells["deductionName"].Value.ToString();
                decimal amount = Convert.ToDecimal(row.Cells["amount"].Value);

                // Lookup deduction category ID based on the name
                int deductionCatID = GetDeductionCategoryIDByName(deductionName);

                // Call the actual update function
                if (UpdateDeduction(deductionID, deductionCatID, amount))
                {
                    MessageBox.Show("Deduction updated successfully."); // Success message
                }
                else
                {
                    MessageBox.Show("Failed to update deduction.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating: " + ex.Message);
            }
        }
        public static int GetDeductionCategoryIDByName(string name)
        {
            string query = "SELECT deductionCatID FROM deductionCategory WHERE deductionName = @name";
            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@name", name);

                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
        public static bool UpdateDeduction(int deductionID, int deductionCatID, decimal amount)
        {
            string query = "UPDATE deductions SET deductionCatID = @catID, amount = @amount WHERE deductionID = @id";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@catID", deductionCatID);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@id", deductionID);

                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool DoesPayrollPeriodExist(DateTime start, DateTime end)
        {
            string query = "SELECT COUNT(*) FROM payrollPeriod WHERE periodStart = @start AND periodEnd = @end";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection))
            {
                cmd.Parameters.AddWithValue("@start", start.Date);
                cmd.Parameters.AddWithValue("@end", end.Date);

                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }


        public bool InsertPayrollPeriod(DateTime start, DateTime end, DateTime generatedDate)
        {
            string insertQuery = "INSERT INTO payrollPeriod (periodStart, periodEnd, generatedDate) VALUES (@start, @end, @dateGen)";
            using (MySqlCommand cmd = new MySqlCommand(insertQuery, Connection))
            {
                cmd.Parameters.AddWithValue("@start", start.Date);
                cmd.Parameters.AddWithValue("@end", end.Date);
                cmd.Parameters.AddWithValue("@dateGen", generatedDate);

                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        // PARA MAKUHA ANG LATE DILI PANI FINAL 
        public static DataTable GetEmployeeAttendanceStatus(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();

            string query = @"
        WITH RECURSIVE calendar AS (
            SELECT @startDate AS date
            UNION ALL
            SELECT DATE_ADD(date, INTERVAL 1 DAY)
            FROM calendar
            WHERE date < @endDate
        ),
        schedule AS (
            SELECT se.employeeID, c.date
            FROM shiftemployee se
            JOIN calendar c ON c.date BETWEEN FROM_UNIXTIME(se.startDate) AND FROM_UNIXTIME(se.endDate)
        ),
        att_status AS (
            SELECT 
                s.employeeID,
                s.date,
                CASE 
                    WHEN a.date IS NOT NULL THEN 'Present'
                    ELSE 'Absent'
                END AS status
            FROM schedule s
            LEFT JOIN attendance a ON a.employeeID = s.employeeID AND a.date = s.date
        )
        SELECT 
            CONCAT(e.firstName, ' ', e.lastName) AS employeeName,
            att_status.date,
            att_status.status
        FROM att_status
        JOIN employee e ON e.employeeID = att_status.employeeID
        ORDER BY employeeName, att_status.date;
    ";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
        public static bool AddAttendanceWithTimeIn(int employeeId, DateTime date, TimeSpan timeIn)
        {
            string query = @"
            INSERT INTO attendance (employeeID, date, timeIn, status) 
            VALUES (@employeeId, @date, @timeIn, 'Present')";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@timeIn", timeIn);

                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static bool HasShiftOnDate(int employeeId, DateTime date)
        {
            string query = @"
            SELECT COUNT(*) 
            FROM shiftemployee 
            WHERE employeeID = @employeeId 
            AND @date BETWEEN startDate AND endDate";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@date", date);

                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        public static bool UpdateAttendanceWithTimeOut(int employeeId, DateTime date, TimeSpan timeOut)
        {
            string query = @"
            UPDATE attendance 
            SET timeOut = @timeOut 
            WHERE employeeID = @employeeId AND date = @date";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@timeOut", timeOut);

                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static (TimeSpan? TimeIn, TimeSpan? TimeOut) GetAttendanceRecord(int employeeId, DateTime date)
        {
            string query = @"
                SELECT timeIn, timeOut 
                FROM attendance 
                WHERE employeeID = @employeeId AND date = @date";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@date", date);

                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        TimeSpan? timeIn = reader.IsDBNull(reader.GetOrdinal("timeIn")) ? (TimeSpan?)null : reader.GetTimeSpan("timeIn");
                        TimeSpan? timeOut = reader.IsDBNull(reader.GetOrdinal("timeOut")) ? (TimeSpan?)null : reader.GetTimeSpan("timeOut");
                        return (timeIn, timeOut);
                    }
                }
            }
            return (null, null);
        }
        public static bool UpdateAttendanceMetrics(int employeeId, DateTime date, int lateMinutes, int undertimeMinutes, string hoursWorked)
        {
            string query = @"
                UPDATE attendance 
                SET minutesLates = @lateMinutes, 
                    underTimeMinutes = @undertimeMinutes, 
                    hoursWorked = @hoursWorked 
                WHERE employeeID = @employeeId AND date = @date";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@lateMinutes", lateMinutes);
                cmd.Parameters.AddWithValue("@undertimeMinutes", undertimeMinutes);
                cmd.Parameters.AddWithValue("@hoursWorked", hoursWorked);

                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static (TimeSpan? shiftStart, TimeSpan? shiftEnd) GetShiftTimings(int employeeId, DateTime date)
        {
            string query = @"
                SELECT s.timeIn, s.timeOut
                FROM shiftemployee se
                INNER JOIN shift s ON se.shiftID = s.shiftID
                WHERE se.employeeID = @employeeId
                  AND @date BETWEEN se.startDate AND se.endDate
                LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@date", date);

                if (Instance.Connection.State != ConnectionState.Open)
                    Instance.Connection.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        TimeSpan shiftStart = reader.GetTimeSpan("timeIn");
                        TimeSpan shiftEnd = reader.GetTimeSpan("timeOut");
                        return (shiftStart, shiftEnd);
                    }
                }
            }

            // Return null if no shift is found
            return (null, null);
        }
        public static bool AddLeaveRecord(int employeeId, DateTime startDate, DateTime endDate, bool isLeaveWithPay)
        {
            string query = @"
                INSERT INTO leaveRecord (employeeID, startDate, endDate, isLeaveWithPay) 
                VALUES (@employeeId, @startDate, @endDate, @isLeaveWithPay)";

            using (MySqlCommand cmd = new MySqlCommand(query, Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@isLeaveWithPay", isLeaveWithPay);

                try
                {
                    if (Instance.Connection.State != ConnectionState.Open)
                        Instance.Connection.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("MySQL Error: " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (Instance.Connection.State == ConnectionState.Open)
                        Instance.Connection.Close();
                }
            }
        }
       
    }
}

