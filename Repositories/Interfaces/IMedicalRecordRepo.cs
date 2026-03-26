using HMS.Data.Models;
using HMS.Repositories.GenericRepo;

namespace HMS.Repositories.Interfaces
{
    public interface IMedicalRecordRepo : IGenericRepo<MedicalRecord>
    {
        Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsInfoAsync();
    }
}
