using Microsoft.AspNetCore.Mvc;
using Api.Dto;
using UniversityData.Domain;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyService _service;

        public SpecialtyController(ISpecialtyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var specialties = _service.GetAll();
            return Ok(specialties);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var specialty = _service.GetById(id);
            if (specialty == null)
                return NotFound();
            return Ok(specialty);
        }

        [HttpPost]
        public IActionResult Create(SpecialtyDto dto)
        {
            var specialty = new Specialty
            {
                Code = dto.Code,
                Name = dto.Name,
                GroupCount = dto.GroupCount
            };

            _service.Create(specialty);
            return CreatedAtAction(nameof(GetById), new { id = specialty.Id }, specialty);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SpecialtyDto dto)
        {
            var specialty = new Specialty
            {
                Code = dto.Code,
                Name = dto.Name,
                GroupCount = dto.GroupCount
            };

            _service.Update(id, specialty);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpGet("top")]
        public IActionResult GetTopSpecialties()
        {
            var result = _service.GetTopSpecialtiesByGroups();
            return Ok(result);
        }
    }
}
