using HMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepo _patientRepo;

        public PatientsController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatientsAsync()
        {
            var pats = await _patientRepo.GetAllPatientsInfoAsync();

            var patients = pats.Select(p => new
            {
                p.Id,
                p.FullName,
                p.DateOfBirth,
                PhoneNumbers = p.Phones.Select(n => new
                {
                    n.PhoneNumber
                }).ToList(),
                Appointments = p.Appointments.Select(a => new
                {
                    DoctorName = a.Doctor.Name,
                    a.Id,
                    a.Status,
                    Notes = a.Notes ?? "There isn't any Note yet",
                    a.AppointmentDate
                }).ToList(),
                
            }).ToList();


            return Ok(patients);
        }


        [HttpGet("active")]
        public async Task<IActionResult> GetActivePatientsAsync()
        {

            var patients = await _patientRepo.GetActivePatientsAsync();
            var today = DateTime.Now;

            var activePatients = patients.Select(p => new
            {
                p.Id,
                p.FullName,
                p.DateOfBirth,
                LastAppointment = p.Appointments.OrderByDescending(a => a.AppointmentDate)
                    .Select(a => new
                    {
                        a.Id,
                        a.Status,
                        Notes = a.Notes ?? "There isn't any Note yet",
                        a.AppointmentDate,
                        Days = (today - a.AppointmentDate).Days,
                    }).FirstOrDefault(),
            }).ToList();

            return Ok(activePatients);
        }
    }
}
