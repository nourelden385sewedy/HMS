using HMS.Data.Models;
using HMS.Repositories.GenericRepo;

namespace HMS.Repositories.Interfaces
{
    public interface IPatientRepo : IGenericRepo<Patient>
    {
        Task<IEnumerable<Patient>> GetAllPatientsInfoAsync();
        Task<IEnumerable<Patient>> GetActivePatientsAsync();
    }
}
