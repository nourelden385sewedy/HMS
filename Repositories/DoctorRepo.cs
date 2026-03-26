using HMS.Data;
using HMS.Data.Models;
using HMS.Repositories.GenericRepo;
using HMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repositories
{
    public class DoctorRepo : GenericRepo<Doctor>, IDoctorRepo
    {
        public DoctorRepo(HMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsInfoAsync()
        {
            return await _context.Doctors
                .Include(d => d.Appointments)
                .Include(d => d.Department)
                .OrderByDescending(d => d.Appointments.Count())
                .ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDepartmentSummary()
        {
            return await _context.Doctors
                 .Include(d => d.Department)
                 .Include(d => d.Appointments)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetDepartmentSummary2()
        {
            return await _context.Departments
                .Include(d => d.Doctors).ThenInclude(d => d.Appointments)
                .ToListAsync();
        }
    }
}
