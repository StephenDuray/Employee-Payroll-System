using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class addpayrollPeriod: Form
    {   
        private Payroll Payroll;
        public addpayrollPeriod(Payroll payroll)
        {
            InitializeComponent();
            Payroll = payroll;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {

        }

        private void addpayrollPeriod_Load(object sender, EventArgs e)
        {

        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();         // Hide current addpayrollPeriod form
            Payroll.Show();
        }

        private void addAttendButton_Click(object sender, EventArgs e)
        {
            // Assuming you're using DateTimePickers
            DateTime periodStart = dateTimePicker1.Value.Date;
            DateTime periodEnd = dateTimePicker2.Value.Date;
            DateTime dateGenerated = DateTime.Now;

            // Check if the period already exists
            bool exists = dbConn.Instance.DoesPayrollPeriodExist(periodStart, periodEnd);
            if (exists)
            {
                MessageBox.Show("This payroll period already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert the new period
            bool success = dbConn.Instance.InsertPayrollPeriod(periodStart, periodEnd, dateGenerated);
            if (success)
            {
                MessageBox.Show("Payroll period successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Hide();         // Hide current addpayrollPeriod form
            }
            else
            {
                MessageBox.Show("Failed to add payroll period.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
