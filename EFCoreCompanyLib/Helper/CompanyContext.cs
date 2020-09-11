using System;
using System.Collections.Generic;
using System.Text;
using EFCoreCompanyLib.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCompanyLib.Helper
{
    public class CompanyContext : DbContext
    {
        /// <summary>
        /// My DbSet and Connection String Implementation
        /// </summary>
        private readonly string connString = @"Server=.\MSSQLSERVER03;Database=CompanyDB;Trusted_Connection=True;";
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Configuring my DbContext
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connString);
        }

        /// <summary>
        /// Configuring my DbContext when the model gets created
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany<Employee>(c => c.Employees)
                .WithOne(s => s.Department)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
