using EFCoreCompanyLib.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EFCoreCompanyLib.Repository
{
    public interface IDepartmentRepository
    {
        public Department AddDept(Department department);
        public Department DeleteDept(int id);
        public Department UpdateDept(Department departmentChanges);
        public List<string> GetAllDeptToCombo();
        public IEnumerable GetAllDept();
    }
}
