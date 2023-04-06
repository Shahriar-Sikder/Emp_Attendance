using Emp_Attendance.Models;
using Microsoft.EntityFrameworkCore;

namespace Emp_Attendance.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Emp_Details>  Employees { get; set; }
    }
}
