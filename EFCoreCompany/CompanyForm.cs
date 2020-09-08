using EFCoreCompanyLib.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFCoreCompanyLib;
using EFCoreCompanyLib.Model;

namespace EFCoreCompany
{
    public partial class CompanyForm : Form
    {
        int EmpID { get; set; }
        int DeptID { get; set; }
        public IEmployeeRepository ResEmp { get; set; }
        public IDepartmentRepository ResDept { get; set; }
        public CompanyForm(IEmployeeRepository resEmp, IDepartmentRepository resDept)
        {
            InitializeComponent();
            this.ResEmp = resEmp;
            this.ResDept = resDept;
        }

        private void CompanyForm_Load(object sender, EventArgs e)
        {
            var comboDept = ResDept.GetAllDeptToCombo();
            var dept = ResDept.GetAllDept();
            var emp = ResEmp.GetAllEmp();

            dataGridView1.DataSource = emp;
            dataGridView2.DataSource = dept;

            foreach (var item in comboDept)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            ResDept.AddDept(
                new Department
                {
                    DepartmentName = textBox10.Text
                }
            );

            dataGridView2.DataSource = ResDept.GetAllDept();

            comboBox1.Items.Clear();
            var comboDept = ResDept.GetAllDeptToCombo();
            foreach (var item in comboDept)
            {
                comboBox1.Items.Add(item);
            }

            textBox10.Clear();
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            ResEmp.AddEmp(new Employee
            { 
                FirstName = textBox1.Text,
                LastName = textBox2.Text,
                Email = textBox3.Text,
                PhoneNumber = textBox4.Text,
                HireDate = dateTimePicker1.Value,
                Salary = decimal.Parse(textBox6.Text)
            },
            comboBox1.Text);

            dataGridView1.DataSource = ResEmp.GetAllEmp();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
        }

        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            ResEmp.DeleteEmp(EmpID);
            dataGridView1.DataSource = ResEmp.GetAllEmp();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();

        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            ResEmp.UpdateEmp(new Employee
            {
                EmployeeId = EmpID,
                FirstName = textBox1.Text,
                LastName = textBox2.Text,
                Email = textBox3.Text,
                PhoneNumber = textBox4.Text,
                HireDate = dateTimePicker1.Value,
                Salary = decimal.Parse(textBox6.Text)
            }, comboBox1.Text);

            dataGridView1.DataSource = ResEmp.GetAllEmp();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView1.CurrentRow.Selected = true;
                    EmpID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["EmployeeId"].FormattedValue.ToString());
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].FormattedValue.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["LastName"].FormattedValue.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["PhoneNumber"].FormattedValue.ToString();
                    textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["Salary"].FormattedValue.ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["HireDate"].FormattedValue.ToString());
                    comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["DepartmentName2"].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Field Data Inputted or Clicked");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView2.CurrentRow.Selected = true;
                    DeptID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["DepartmentId"].FormattedValue.ToString());
                    textBox10.Text = dataGridView2.Rows[e.RowIndex].Cells["DepartmentName"].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Field Data Inputted or Clicked");
            }
        }
    }
}
