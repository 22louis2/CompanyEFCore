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
    public class DepartmentRepository : IDepartmentRepository
    {
        /// <summary>
        /// Method to Add to the Department Table
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public Department AddDept(Department department)
        {
            // Initializing my DbContext Class
            using CompanyContext ctx = new CompanyContext();
            var dept = ctx.Departments.Where(d => d.DepartmentName.ToLower() == department.DepartmentName.ToLower()).FirstOrDefault();
            if (dept != null) {
                throw new Exception("Department Already Exists");
            }
            else
            {
                // Adding to the Department Table using EFCore DbContext
                ctx.Departments.Add(department);
                ctx.SaveChanges();
                return department;
            }
            
        }

        /// <summary>
        /// Method to Delete the Department and its Employees Associated with that Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department DeleteDept(int id)
        {
            // Initializing my EFCore DbContext Class
            using CompanyContext ctx = new CompanyContext();
            var department = ctx.Departments.Find(id);

            if (department != null)
            {
                // Removing from the Department Table using the DbContext 
                ctx.Departments.Remove(department);
                ctx.SaveChanges();
            }

            return department;
        }

        /// <summary>
        /// Method to update the Department Table using DbContext
        /// </summary>
        /// <param name="departmentChanges"></param>
        /// <returns></returns>
        public Department UpdateDept(Department departmentChanges)
        {
            // Initializing the EFCore DbContext Class
            using CompanyContext ctx = new CompanyContext();
            // Update the Department Tables using the DbContext
            ctx.Departments.Update(departmentChanges);
            ctx.SaveChanges();
            return departmentChanges;
        }

        /// <summary>
        /// Method to Get all the Department in the Department Table into
        /// the ComboBox
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllDeptToCombo()
        {
            // Initializing the various List needed for the method
            var dept = new List<string>();
            var list = new List<Department>();

            // Initializing the EFCore DbContext Class
            using CompanyContext ctx = new CompanyContext();

            // Searching the Department Class and Ordering the items
            list = ctx.Departments.OrderBy(e => e.DepartmentId).ToList();

            // Looping through Items gotten from the Department Table
            foreach (var item in list)
            {
                // Adding to the dept List
                dept.Add(item.DepartmentName);
            }

            return dept;
        }

        /// <summary>
        /// Method to Get all the Department from the Database Department Table
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAllDept()
        {
            // Initializing the EFCore DbContext Class
            using CompanyContext ctx = new CompanyContext();
            return ctx.Departments.Select(e => new { e.DepartmentId, e.DepartmentName}).ToList();
        }
    }
}
