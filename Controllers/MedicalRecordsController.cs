using HMS.DTOs;
using HMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordRepo _medicalRecordRepo;

        public MedicalRecordsController(IMedicalRecordRepo medicalRecordRepo)
        {
            _medicalRecordRepo = medicalRecordRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMedicalRecordsAsync()
        {
            var medicals = await _medicalRecordRepo.GetAllMedicalRecordsInfoAsync();

            var medicalRecords = medicals.Select(m => new
            {
                m.Id,
                m.Diagnosis,
                m.Treatment,
                m.LastUpdated,
                PatientInfo = new
                {
                    m.Patient.Id,
                    m.Patient.FullName,
                    m.Patient.Email,
                    m.Patient.DateOfBirth,
                }
            }).ToList();

            return Ok(medicalRecords);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalRecordAsync(int id, UpdateMedicalRecordDto dto)
        {
            var medicalRecord = await _medicalRecordRepo.GetByIdAsync(id);

            if (medicalRecord == null)
                return NotFound($"Medical Record with Id {id} not found");

            medicalRecord.Diagnosis = dto.Diagnosis;
            medicalRecord.Treatment = dto.Treatment;
            medicalRecord.LastUpdated = DateTime.Now;

            _medicalRecordRepo.Update(medicalRecord);
            await _medicalRecordRepo.SaveChangesAsync();

            return Ok("Medical Record Updated Successfully");
        }
    }
}
