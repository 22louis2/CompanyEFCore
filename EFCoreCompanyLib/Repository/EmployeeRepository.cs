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
        //private static CompanyContext _ctx = new CompanyContext();
        public Employee AddEmp(Employee employee, string dept)
        {
            using CompanyContext ctx = new CompanyContext();
            var deptSearch = ctx.Departments.Where(x => x.DepartmentName == dept).FirstOrDefault();
            employee.Department = deptSearch;
            ctx.Employees.Add(employee);
            ctx.SaveChanges();
            return employee;
        }

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

        public Employee UpdateEmp(Employee employeeChanges, string dept)
        {
            using CompanyContext ctx = new CompanyContext();
            var deptSearch = ctx.Departments.Where(x => x.DepartmentName == dept).FirstOrDefault();
            employeeChanges.Department = deptSearch;
            ctx.Employees.Update(employeeChanges);
            ctx.SaveChanges();
            return employeeChanges;
        }

        public IEnumerable GetAllEmp()
        {
            using CompanyContext ctx = new CompanyContext();
            return ctx.Employees.Include(s => s.Department).Select(e => new { e.EmployeeId, e.FirstName, e.LastName, e.Email, e.PhoneNumber, e.HireDate, e.Salary, e.Department.DepartmentId, e.Department.DepartmentName }).ToList();
        }
    }
}
