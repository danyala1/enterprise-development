using Microsoft.AspNetCore.Mvc;
using Api.Dto;
using UniversityData.Domain;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _service;

        public FacultyController(IFacultyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var faculties = _service.GetAll();
            return Ok(faculties);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var faculty = _service.GetById(id);
            if (faculty == null)
                return NotFound();
            return Ok(faculty);
        }

        [HttpPost]
        public IActionResult Create(FacultyDto dto)
        {
            var faculty = new Faculty
            {
                Name = dto.Name,
                Departments = new List<Department>()
            };

            _service.Create(faculty);
            return CreatedAtAction(nameof(GetById), new { id = faculty.Id }, faculty);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, FacultyDto dto)
        {
            var faculty = new Faculty
            {
                Name = dto.Name,
                Departments = new List<Department>()
            };

            _service.Update(id, faculty);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
