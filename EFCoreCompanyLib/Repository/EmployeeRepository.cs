using EFCoreCompanyLib.Helper;
using EFCoreCompanyLib.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreCompanyLib.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <summary>
        /// Method to Add to the Employee Table
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public Employee AddEmp(Employee employee, string dept)
        {
            using CompanyContext ctx = new CompanyContext();
            var deptSearch = ctx.Departments.Where(x => x.DepartmentName == dept).FirstOrDefault();
            employee.Department = deptSearch;
            ctx.Employees.Add(employee);
            ctx.SaveChanges();
            return employee;
        }

        /// <summary>
        /// Method to Delete From the Employee Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee DeleteEmp(int id)
        {
            using CompanyContext ctx = new CompanyContext();
            var employee = ctx.Employees.Find(id);

            if(employee != null)
            {
                ctx.Employees.Remove(employee);
                ctx.SaveChanges();
            }

            return employee;
        }

        /// <summary>
        /// Method to Update the Employee Table
        /// </summary>
        /// <param name="employeeChanges"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public Employee UpdateEmp(Employee employeeChanges, string dept)
        {
            using CompanyContext ctx = new CompanyContext();
            var deptSearch = ctx.Departments.Where(x => x.DepartmentName == dept).FirstOrDefault();
            employeeChanges.Department = deptSearch;
            ctx.Employees.Update(employeeChanges);
            ctx.SaveChanges();
            return employeeChanges;
        }

        /// <summary>
        /// Method to Get all The Employee From the Employee Table
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAllEmp()
        {
            using CompanyContext ctx = new CompanyContext();
            return ctx.Employees
                .Include(s => s.Department)
                .Select(e => new { e.EmployeeId, e.FirstName, e.LastName, e.Email, e.PhoneNumber, e.HireDate, e.Salary, e.Department.DepartmentId, e.Department.DepartmentName })
                .ToList();
        }


        /// <summary>
        /// Method to get all the Employee Assigned to a Department
        /// In the Employee Table
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAllEmpAndDept()
        {
            using CompanyContext ctx = new CompanyContext();
            return ctx.Employees
                .Include(s => s.Department)
                .Where(s => s.Department.DepartmentName != null)
                .Select(e => new { e.FirstName, e.LastName, e.Department.DepartmentName })
                .ToList();
        }

        /// <summary>
        /// Method to get all the Employee and Grouped by their Department
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAllEmpAndDeptGroupedByDept()
        {
            using CompanyContext ctx = new CompanyContext();
            return ctx.Employees
                .Where(s => s.Department.DepartmentName != null)
                .OrderBy(s => s.Department.DepartmentName)
                .Select(e => new { e.FirstName, e.LastName, e.Department.DepartmentName })
                .ToList();
        }

        /// <summary>
        /// Method to Get All Employee that Earns above 1500000
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetEmployeeBySalaryAbove150000()
        {
            using CompanyContext ctx = new CompanyContext();
            return ctx.Employees
                .Where(x => x.Salary >= 150000)
                .Select(e => new { e.FirstName, e.LastName, e.Salary })
                .ToList();
        }

        /// <summary>
        /// Method to Get All Department Not Assigned An Employee
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAllDeptNotAssignedAnEmp()
        {
            using CompanyContext ctx = new CompanyContext();

            List<string> allEmployees = ctx.Employees
                .Where(x => x.Department.DepartmentName != null)
                .Select(x => x.Department.DepartmentName)
                .ToList();

            var dept = ctx.Departments
                .Where(x => !allEmployees.Contains(x.DepartmentName))
                .Select(s => new { Department = s.DepartmentName })
                .ToList();

            return dept;
        }

        /// <summary>
        /// Method to get all Employee and Department
        /// Whether Assigned or Not Assigned
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAllEmpAndDeptAssignedAndNotAssigned()
        {
            using CompanyContext ctx = new CompanyContext();
            return ctx.Employees
                .Include(s => s.Department)
                .Select(e => new { e.FirstName, e.LastName, e.Department.DepartmentName })
                .ToList();
        }
    }
}
