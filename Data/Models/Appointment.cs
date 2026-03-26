using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Notes { get; set; }
        public DateTime AppointmentDate { get; set; }
        
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; } = null!;
    }
}
