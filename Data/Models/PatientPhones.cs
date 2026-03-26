namespace HMS.Data.Models
{
    public class PatientPhones
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public int PatientId { get; set; }
    }
}
