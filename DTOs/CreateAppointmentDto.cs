using System.ComponentModel.DataAnnotations;

namespace HMS.DTOs
{
    public class CreateAppointmentDto
    {
        [Required, AllowedValues("Scheduled", "Completed", "Cancelled", ErrorMessage = "Status must be Scheduled, Completed, or Cancelled.")]
        public string Status { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Notes { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; } = DateTime.UtcNow.AddDays(2);


        public int PatientId { get; set; }

        public int DoctorId { get; set; }
    }
}
