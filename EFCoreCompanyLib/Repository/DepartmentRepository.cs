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
        //private readonly CompanyContext ctx = new CompanyContext();
        public Department AddDept(Department department)
        {
            using CompanyContext ctx = new CompanyContext();
            ctx.Departments.Add(department);
            ctx.SaveChanges();
            return department;
        }

        public Department DeleteDept(int id)
        {
            using CompanyContext ctx = new CompanyContext();
            var department = ctx.Departments.Find(id);

            if (department != null)
            {
                ctx.Departments.Remove(department);
                ctx.SaveChanges();
            }

            return department;
        }

        public Department UpdateDept(Department departmentChanges)
        {
            using CompanyContext ctx = new CompanyContext();
            ctx.Departments.Update(departmentChanges);
            ctx.SaveChanges();
            return departmentChanges;
        }

        public List<string> GetAllDeptToCombo()
        {
            var dept = new List<string>();
            var list = new List<Department>();

            using CompanyContext ctx = new CompanyContext();
            list = ctx.Departments.OrderBy(e => e.DepartmentId).ToList();

            foreach (var item in list)
            {
                dept.Add(item.DepartmentName);
            }

            return dept;
        }

        public IEnumerable GetAllDept()
        {
            using CompanyContext ctx = new CompanyContext();
            return ctx.Departments.Select(e => new { e.DepartmentId, e.DepartmentName}).ToList();
        }
    }
}
