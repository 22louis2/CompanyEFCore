using EFCoreCompanyLib.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EFCoreCompanyLib.Repository
{
    public interface IEmployeeRepository
    {
        public Employee AddEmp(Employee employee, string dept);
        public Employee DeleteEmp(int id);
        public Employee UpdateEmp(Employee employeeChanges, string dept);
        public IEnumerable GetAllEmp();
    }
}
