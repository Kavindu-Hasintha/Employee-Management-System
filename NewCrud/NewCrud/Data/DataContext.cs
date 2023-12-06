using Microsoft.EntityFrameworkCore;
using NewCrud.Models;
using System.Data.SqlClient;
using System;

namespace NewCrud.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=DESKTOP-VRF2530\\MSSQL2022;Initial Catalog=crud_full_stack;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }*/
    }
}
