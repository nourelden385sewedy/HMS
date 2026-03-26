using HMS.Data;
using HMS.Data.Models;
using HMS.Repositories.GenericRepo;
using HMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repositories
{
    public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
    {
        public DepartmentRepo(HMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsInfoAsync()
        {
            return await _context.Departments
                .Include(d => d.Doctors)
                .ToListAsync();
        }

        public async Task<Department?> GetDepartmentByidAsync(int id)
        {
            return await _context.Departments
                .Include(d => d.Doctors)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
