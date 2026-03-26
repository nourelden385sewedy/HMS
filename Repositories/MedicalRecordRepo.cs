using HMS.Data;
using HMS.Data.Models;
using HMS.Repositories.GenericRepo;
using HMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repositories
{
    public class MedicalRecordRepo : GenericRepo<MedicalRecord>, IMedicalRecordRepo
    {
        public MedicalRecordRepo(HMSDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsInfoAsync()
        {
            return await _context.MedicalRecords
                .Include(m => m.Patient)
                .ToListAsync();
        }
    }
}
