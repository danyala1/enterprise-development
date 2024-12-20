using Microsoft.AspNetCore.Mvc;
using Api.Dto;
using UniversityData.Domain;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService _service;

        public UniversityController(IUniversityService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var universities = _service.GetAll();
            return Ok(universities);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var university = _service.GetById(id);
            if (university == null)
                return NotFound();
            return Ok(university);
        }

        [HttpPost]
        public IActionResult Create(UniversityDto dto)
        {
            // Преобразуем UniversityDto в University
            var university = new University
            {
                RegistrationNumber = dto.RegistrationNumber,
                Name = dto.Name,
                Address = dto.Address,
                InstitutionOwnership = dto.InstitutionOwnership,
                BuildingOwnership = dto.BuildingOwnership,
                Rector = new Rector
                {
                    FullName = dto.Rector.FullName,
                    Degree = dto.Rector.Degree,
                    Title = dto.Rector.Title,
                    Position = dto.Rector.Position
                },
                Faculties = dto.Faculties.Select(f => new Faculty
                {
                    Name = f.Name
                }).ToList()
            };

            _service.Create(university);

            // После создания возвращаем UniversityDto
            return CreatedAtAction(nameof(GetById), new { id = university.RegistrationNumber }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UniversityDto dto)
        {
            // Преобразуем UniversityDto в University
            var university = new University
            {
                RegistrationNumber = id,
                Name = dto.Name,
                Address = dto.Address,
                InstitutionOwnership = dto.InstitutionOwnership,
                BuildingOwnership = dto.BuildingOwnership,
                Rector = new Rector
                {
                    FullName = dto.Rector.FullName,
                    Degree = dto.Rector.Degree,
                    Title = dto.Rector.Title,
                    Position = dto.Rector.Position
                },
                Faculties = dto.Faculties.Select(f => new Faculty
                {
                    Name = f.Name
                }).ToList()
            };

            _service.Update(id, university);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        // Аналитические запросы



        [HttpGet("top-departments")]
        public IActionResult GetTopUniversitiesByDepartments()
        {
            var result = _service.GetTopUniversitiesByDepartments();
            return Ok(result);
        }

        [HttpGet("ownership/{ownership}")]
        public IActionResult GetUniversitiesByOwnership(string ownership)
        {
            var result = _service.GetUniversitiesByOwnership(ownership);
            return Ok(result);
        }

        [HttpGet("summary")]
        public IActionResult GetSummaryByOwnership()
        {
            var summary = _service.GetSummaryByOwnership();
            return Ok(summary);
        }
    }
}
