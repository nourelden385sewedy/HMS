using HMS.Data.Models;
using HMS.Repositories.GenericRepo;

namespace HMS.Repositories.Interfaces
{
    public interface IDepartmentRepo : IGenericRepo<Department>
    {
        Task<IEnumerable<Department>> GetAllDepartmentsInfoAsync();
        Task<Department?> GetDepartmentByidAsync(int id);
    }
}
