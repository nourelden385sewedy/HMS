using HMS.Data;
using HMS.Data.Models;
using HMS.Repositories.GenericRepo;
using HMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repositories
{
    public class PatientRepo : GenericRepo<Patient>, IPatientRepo
    {
        public PatientRepo(HMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Patient>> GetActivePatientsAsync()
        {
            var last30Days = DateTime.Now.AddDays(-30);

            return await _context.Patients
                .Include(p => p.Appointments)
                .Where(p => p.Appointments.Any(a => a.AppointmentDate >= last30Days))
                .ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsInfoAsync()
        {
            return await _context.Patients
                .Include(p => p.Phones)
                .Include(p => p.MedicalRecord)
                .Include(p => p.Appointments).ThenInclude(p => p.Doctor)
                .OrderByDescending(p => p.Appointments.Count()).ToListAsync();
        }
    }
}
