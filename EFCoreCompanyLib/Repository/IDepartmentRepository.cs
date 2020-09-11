using EFCoreCompanyLib.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EFCoreCompanyLib.Repository
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Methods the Department Class must implement
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public Department AddDept(Department department);
        public Department DeleteDept(int id);
        public Department UpdateDept(Department departmentChanges);
        public List<string> GetAllDeptToCombo();
        public IEnumerable GetAllDept();
    }
}
