using System;
using System.Collections.Generic;
using System.Text;
using EFCoreCompanyLib.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCompanyLib.Helper
{
    public class CompanyContext : DbContext
    {
        private readonly string connString = @"Server=.\MSSQLSERVER03;Database=CompanyDB;Trusted_Connection=True;";
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connString);
        }
    }
}
