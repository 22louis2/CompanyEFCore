using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFCoreCompanyLib;
using EFCoreCompanyLib.Helper;
using EFCoreCompanyLib.Repository;

namespace EFCoreCompany
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Dependency Injection Performed
            Config.PlugSocket();
            IEmployeeRepository resEmp = Config.IEmp;
            IDepartmentRepository resDept = Config.IDept;

            Application.Run(new CompanyForm(resEmp, resDept));
        }
    }
}
