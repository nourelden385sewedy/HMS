using HMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepo _doctorRepo;

        public DoctorsController(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var docs = await _doctorRepo.GetAllDoctorsInfoAsync();

            var doctors = docs.Select(d => new
            {
                d.Id,
                d.Name,
                d.Specialization,
                d.Salary,
                Department = d.Department.Name,
                TotalAppointments = d.Appointments.Count()
            }).ToList();

            return Ok(doctors);
        }


        // Department Summary with Grouping
        [HttpGet("department-summary-1")]
        public async Task<IActionResult> GetDepartmentSummary()
        {
            var doctors = await _doctorRepo.GetDepartmentSummary();

            var summary = doctors.GroupBy(d => d.Department.Name)
                .Select(g => new
                {
                    DepartmentName = g.Key,
                    DoctorsCount = g.Count(),
                    TotalAppointments = g.Sum(d => d.Appointments.Count())
                }).ToList();

            return Ok(summary);
        }


        
        [HttpGet("department-summary-2")]
        public async Task<IActionResult> GetDepartmentSummary2()
        {
            var departments = await _doctorRepo.GetDepartmentSummary2();
            
            var summary = departments.Select(d => new
            {
                DepartmentName = d.Name,
                DoctorsCount = d.Doctors.Count(),
                TotalAppointments = d.Doctors.Sum(d => d.Appointments.Count())
            }).ToList();

            return Ok(summary);
        }
    }
}
