using System;
using System.Collections.Generic;
using System.Text;
using EFCoreCompanyLib;
using EFCoreCompanyLib.Repository;

namespace EFCoreCompanyLib.Helper
{
    public class Config
    {
        public static IEmployeeRepository IEmp { get; set; }
        public static IDepartmentRepository IDept { get; set; }

        //public static SQLConnection Connect { get; set; }
        public static void PlugSocket()
        {
            // Initializing my Various Methods
            EmployeeRepository emp = new EmployeeRepository();
            DepartmentRepository dept = new DepartmentRepository();
            
            // Assigning it to the Interface Property
            IEmp = emp;
            IDept = dept;
        }
    }
}
