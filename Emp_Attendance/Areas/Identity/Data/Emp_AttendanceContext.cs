using Emp_Attendance.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Emp_Attendance.Data;

public class Emp_AttendanceContext : IdentityDbContext<Emp_AttendanceUser>
{
    public Emp_AttendanceContext(DbContextOptions<Emp_AttendanceContext> options)
        : base(options)
    {
    }
    public DbSet<Emp_AttendanceUser> EmpUser { get; set; }


}
