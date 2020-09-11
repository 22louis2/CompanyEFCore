using EFCoreCompanyLib.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EFCoreCompanyLib.Repository
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Methods the Employee Class must implement
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public Employee AddEmp(Employee employee, string dept);
        public Employee DeleteEmp(int id);
        public Employee UpdateEmp(Employee employeeChanges, string dept);
        public IEnumerable GetAllEmp();
        public IEnumerable GetAllEmpAndDept();
        public IEnumerable GetAllEmpAndDeptGroupedByDept();
        public IEnumerable GetEmployeeBySalaryAbove150000();
        public IEnumerable GetAllDeptNotAssignedAnEmp();
        public IEnumerable GetAllEmpAndDeptAssignedAndNotAssigned();
    }
}
