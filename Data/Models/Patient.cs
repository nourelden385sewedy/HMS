using System.ComponentModel.DataAnnotations;

namespace HMS.Data.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [MaxLength(120)]
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public ICollection<PatientPhones> Phones { get; set; } = new List<PatientPhones>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public MedicalRecord? MedicalRecord { get; set; }
    }
}
