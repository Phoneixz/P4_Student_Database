using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StudentDatabase.Models
{
    public class StudentDatabaseDbContextFactory : IDesignTimeDbContextFactory<StudentDatabaseDbContext>
    {
        public StudentDatabaseDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<StudentDatabaseDbContext>();
            string connectionstring = "Server=DESKTOP-QLCSCTJ;Database=Student_Database;Trusted_Connection=True;";
            options.UseSqlServer(connectionstring);
            return new StudentDatabaseDbContext(options.Options);
        }

  
    }
}
