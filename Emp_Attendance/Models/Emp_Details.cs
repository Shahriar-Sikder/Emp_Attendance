using System.ComponentModel.DataAnnotations.Schema;

namespace Emp_Attendance.Models
{
    public class Emp_Details
    {
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Designation { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoiningDate { get; set;}
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string PhoneNo { get; set; }
        public double Salary { get; set; }
        [Column(TypeName = "nvarchar(3)")]
        public string Attendance { get; set; }
    }
}
