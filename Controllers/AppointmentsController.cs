using HMS.Data.Models;
using HMS.DTOs;
using HMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepo _appointmentsRepo;
        private readonly IDoctorRepo _doctorRepo;
        private readonly IPatientRepo _patientRepo;

        public AppointmentsController(IAppointmentRepo appointmentsRepo, IDoctorRepo doctorRepo, IPatientRepo patientRepo)
        {
            _appointmentsRepo = appointmentsRepo;
            _doctorRepo = doctorRepo;
            _patientRepo = patientRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointmentAsync(CreateAppointmentDto dto)
        {
            
            var doctor = await _doctorRepo.GetByIdAsync(dto.DoctorId);

            if (doctor == null)
                return NotFound($"Doctor with Id {dto.DoctorId} not found");

            var patient = await _patientRepo.GetByIdAsync(dto.PatientId);

            if (patient == null)
                return NotFound($"Patient with Id {dto.PatientId} not found");

            Appointment app = new Appointment()
            {
                Status = dto.Status,
                Notes = dto.Notes,
                AppointmentDate = dto.AppointmentDate,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
            };

            await _appointmentsRepo.CreateAsync(app);
            await _appointmentsRepo.SaveChangesAsync();

            return Ok("Appointment Created Successfully");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAppointmentsAsync()
        {

            var appoints = await _appointmentsRepo.GetAllAppointmentsInfoAsync();

            var appointments = appoints.Select(a => new
            {
                a.Id,
                a.Status,
                Notes = a.Notes ?? "There isn't any Note yet",
                a.AppointmentDate,
                Patient = new
                {
                    a.PatientId,
                    a.Patient.FullName,
                    a.Patient.Email
                },
                Doctor = new
                {
                    a.DoctorId,
                    a.Doctor.Name,
                    a.Doctor.Specialization
                },
                Department = a.Doctor.Department.Name
            }).ToList();

            return Ok(appointments);
        }


        [HttpGet("daily-summary")]
        public async Task<IActionResult> GetAppointmentsDailySummaryAsync()
        {
            var appoints = await _appointmentsRepo.GetAllAsync();

            var appointments = appoints.GroupBy(a => a.AppointmentDate.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    NumberOfAppointments = g.Count()
                })
                .ToList();

            return Ok(appointments);
        }
    }
}
