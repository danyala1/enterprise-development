using Microsoft.AspNetCore.Mvc;
using Api.Dto;
using UniversityData.Domain;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _service.GetAll();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _service.GetById(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public IActionResult Create(DepartmentDto dto)
        {
            var department = new Department
            {
                Name = dto.Name
            };

            _service.Create(department);
            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, DepartmentDto dto)
        {
            var department = new Department
            {
                Name = dto.Name
            };

            _service.Update(id, department);
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
