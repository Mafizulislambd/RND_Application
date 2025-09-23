using EmpServerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmpServerApi.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> EmployeeDb { get; set; }
    }
}
