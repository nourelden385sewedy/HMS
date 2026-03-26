using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Data.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal Salary { get; set; }


        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; } = null!;
    }
}
