using HMS.Data.Models;
using HMS.Repositories.GenericRepo;

namespace HMS.Repositories.Interfaces
{
    public interface IDoctorRepo : IGenericRepo<Doctor>
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsInfoAsync();
        Task<IEnumerable<Doctor>> GetDepartmentSummary();
        Task<IEnumerable<Department>> GetDepartmentSummary2();

    }
}
