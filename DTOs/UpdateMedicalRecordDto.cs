using HMS.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.DTOs
{
    public class UpdateMedicalRecordDto
    {
        [Required]
        public string Diagnosis { get; set; } = string.Empty;
        public string? Treatment { get; set; }

    }
}
