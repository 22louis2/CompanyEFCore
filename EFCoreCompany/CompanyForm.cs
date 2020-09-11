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
        /// <summary>
        /// Properties Declaration
        /// </summary>
        int EmpID { get; set; }
        int DeptID { get; set; }
        public IEmployeeRepository ResEmp { get; set; }
        public IDepartmentRepository ResDept { get; set; }

        /// <summary>
        /// Form Constructor
        /// </summary>
        /// <param name="resEmp"></param>
        /// <param name="resDept"></param>
        public CompanyForm(IEmployeeRepository resEmp, IDepartmentRepository resDept)
        {
            InitializeComponent();
            this.ResEmp = resEmp;
            this.ResDept = resDept;
        }

        /// <summary>
        /// On Form Load, Methods to Perform
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            searchComboBox.Items.Add("");
        }

        /// <summary>
        /// Event to be triggered when trying to Add Department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDept_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox10.Text != "")
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
                } else
                {
                    MessageBox.Show("Input Field is empty");
                }

                textBox10.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("New Department could not be Added. Check if it already exists");
            }
        }

        /// <summary>
        /// Event to be triggered when Deleting a Department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteDept_Click(object sender, EventArgs e)
        {
            try
            {
                ResDept.DeleteDept(DeptID);

                dataGridView1.DataSource = ResEmp.GetAllEmp();
                dataGridView2.DataSource = ResDept.GetAllDept();

                comboBox1.Items.Clear();
                var comboDept = ResDept.GetAllDeptToCombo();
                foreach (var item in comboDept)
                {
                    comboBox1.Items.Add(item);
                }

                textBox10.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Department Could not be Deleted");
            }
        }

        /// <summary>
        /// Event to be triggered when Update a Department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateDept_Click(object sender, EventArgs e)
        {
            try
            {
                ResDept.UpdateDept(
                new Department
                {
                    DepartmentId = DeptID,
                    DepartmentName = textBox10.Text
                }
            );

                dataGridView2.DataSource = ResDept.GetAllDept();
                dataGridView1.DataSource = ResEmp.GetAllEmp();

                comboBox1.Items.Clear();
                var comboDept = ResDept.GetAllDeptToCombo();
                foreach (var item in comboDept)
                {
                    comboBox1.Items.Add(item);
                }

                textBox10.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("Department could not be Updated");
            }
        }

        /// <summary>
        /// Event to be triggered when Add an Employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            try
            {
                decimal.TryParse(textBox6.Text, out decimal d);

                if(decimal.TryParse(textBox6.Text, out decimal _))
                {
                    ResEmp.AddEmp(new Employee
                    {
                        FirstName = textBox1.Text,
                        LastName = textBox2.Text,
                        Email = textBox3.Text,
                        PhoneNumber = textBox4.Text,
                        HireDate = dateTimePicker1.Value,
                        Salary = d
                    },
                    comboBox1.Text
                    );

                    dataGridView1.DataSource = ResEmp.GetAllEmp();
                }
                else
                {
                    MessageBox.Show("Enter Valid Input");
                }
                
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox6.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("Fill up Relevant Fields. New Employee details could not be Added");
            }
        }


        /// <summary>
        /// Event to be triggered when Deleting an Employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            try
            {
                ResEmp.DeleteEmp(EmpID);
                dataGridView1.DataSource = ResEmp.GetAllEmp();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox6.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("Employee details could not be Deleted");
            }
        }

        /// <summary>
        /// Event to be triggered when Updating an Employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            try
            {
                decimal.TryParse(textBox6.Text, out decimal d);

                if(decimal.TryParse(textBox6.Text, out decimal _))
                {
                    ResEmp.UpdateEmp(new Employee
                    {
                        EmployeeId = EmpID,
                        FirstName = textBox1.Text,
                        LastName = textBox2.Text,
                        Email = textBox3.Text,
                        PhoneNumber = textBox4.Text,
                        HireDate = dateTimePicker1.Value,
                        Salary = d
                    }, comboBox1.Text);

                    dataGridView1.DataSource = ResEmp.GetAllEmp();
                }
                else
                {
                    MessageBox.Show("Enter Valid Input");
                }

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox6.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("Employee details could not be Updated");
            }
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

        /// <summary>
        /// Event to be triggered when a value is selected in order to perform it searches
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var test = CUDOperations.getAllEmp();
            if (searchComboBox.SelectedIndex == 0)
            {
                dataGridView1.DataSource = ResEmp.GetAllEmpAndDept();
            }
            else if(searchComboBox.SelectedIndex == 1)
            {
                dataGridView1.DataSource = ResEmp.GetAllEmpAndDeptGroupedByDept();
            }
            else if(searchComboBox.SelectedIndex == 2)
            {
                dataGridView1.DataSource = ResEmp.GetEmployeeBySalaryAbove150000();
            }
            else if(searchComboBox.SelectedIndex == 3)
            {
                dataGridView1.DataSource = ResEmp.GetAllDeptNotAssignedAnEmp();
            } 
            else if(searchComboBox.SelectedIndex == 4)
            {
                dataGridView1.DataSource = ResEmp.GetAllEmpAndDeptAssignedAndNotAssigned();
            }
            else if(searchComboBox.SelectedIndex == 5)
            {
                dataGridView1.DataSource = ResEmp.GetAllEmp();
            }
        }
    }
}
