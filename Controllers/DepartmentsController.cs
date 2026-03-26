using HMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepo _departmentsRepo;

        public DepartmentsController(IDepartmentRepo departmentsRepo)
        {
            _departmentsRepo = departmentsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            var deps = await _departmentsRepo.GetAllDepartmentsInfoAsync();

            if (deps.Count() == 0)
                return NotFound("There aren't any Departments right now");

            var departments = deps.Select(d => new
            {
                d.Id,
                d.Name,
                TotalDoctors = d.Doctors.Count(),
                Doctors = d.Doctors.Select(doc => new
                {
                    doc.Id,
                    doc.Name,
                }).ToList()
            }).ToList();


            return Ok(departments);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentAsync(int id)
        {
            var dep = await _departmentsRepo.GetDepartmentByidAsync(id);

            if (dep == null)
                return NotFound($"Department with Id {id} not found");

            if (dep.Doctors.Count() > 0)
                return BadRequest($"Can't delete this Department, it contains {dep.Doctors.Count()} Doctor(s)");

            _departmentsRepo.Delete(dep);
            await _departmentsRepo.SaveChangesAsync();

            return Ok("Department Deleted Successfully");
        }

    }
}
