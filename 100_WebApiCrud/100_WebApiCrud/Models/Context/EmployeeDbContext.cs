using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _100_WebApiCrud.Models.Entity.Context
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext()
        {
            Database.Connection.ConnectionString = "Server=DESKTOP-92AU4IL;Database=EmployeeCrudDB;Trusted_Connection=True;";
        }

        public DbSet<Employee> Employees { get; set; }
    }
}