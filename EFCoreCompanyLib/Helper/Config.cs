using System;
using System.Collections.Generic;
using System.Text;
using EFCoreCompanyLib;
using EFCoreCompanyLib.Repository;

namespace EFCoreCompanyLib.Helper
{
    public class Config
    {
        /// <summary>
        /// Interface Properties 
        /// </summary>
        public static IEmployeeRepository IEmp { get; set; }
        public static IDepartmentRepository IDept { get; set; }
        /// <summary>
        /// Method to get my Interfaces to the UI Form
        /// </summary>
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
