using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreCompanyLib.Model
{
    public class Department
    {
        /// <summary>
        /// Department Model Properties Implementation
        /// </summary>
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
