using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Data.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string? Treatment { get; set; }
        public DateTime LastUpdated { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; } = null!;

        
    }
}
