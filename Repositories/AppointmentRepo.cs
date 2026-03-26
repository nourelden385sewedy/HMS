using HMS.Data;
using HMS.Data.Models;
using HMS.Repositories.GenericRepo;
using HMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repositories
{
    public class AppointmentRepo : GenericRepo<Appointment>, IAppointmentRepo
    {
        public AppointmentRepo(HMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsInfoAsync()
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor).ThenInclude(d => d.Department)
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();
        }
    }
}
