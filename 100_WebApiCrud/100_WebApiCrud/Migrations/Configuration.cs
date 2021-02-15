namespace _100_WebApiCrud.Migrations
{
    using _100_WebApiCrud.Models.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_100_WebApiCrud.Models.Entity.Context.EmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_100_WebApiCrud.Models.Entity.Context.EmployeeDbContext context)
        {
            if (!context.Employees.Any())
            {
                List<Employee> employees = new List<Employee>
            {
                new Employee{FirstName="Nancy",LastName="Davoilo",Title="Test"},
                new Employee{FirstName="Andrew",LastName="Fuller",Title="Test"},
                new Employee{FirstName="Anne",LastName="Dothsworth",Title="Test"}
            };

                foreach (var employee in employees)
                {
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
            }
        }
    }
}
