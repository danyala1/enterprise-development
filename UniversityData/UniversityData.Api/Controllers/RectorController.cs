using Api.Dto;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Domain;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectorController : ControllerBase
    {
        private readonly IRectorService _rectorService;

        public RectorController(IRectorService rectorService)
        {
            _rectorService = rectorService;
        }

        // Получить список всех ректоров
        [HttpGet]
        public ActionResult<List<RectorDto>> GetAll()
        {
            var rectors = _rectorService.GetAll();
            var rectorDtos = rectors.Select(r => new RectorDto
            {
                FullName = r.FullName,
                Degree = r.Degree,
                Title = r.Title,
                Position = r.Position,
                UniversityId = r.Id // Добавляем UniversityId
            }).ToList();

            return Ok(rectorDtos);
        }

        // Получить ректора по ID
        [HttpGet("{id}")]
        public ActionResult<RectorDto> GetById(int id)
        {
            var rector = _rectorService.GetById(id);
            if (rector == null)
            {
                return NotFound();
            }

            var rectorDto = new RectorDto
            {
                FullName = rector.FullName,
                Degree = rector.Degree,
                Title = rector.Title,
                Position = rector.Position,
                UniversityId = rector.Id // Добавляем UniversityId
            };

            return Ok(rectorDto);
        }

        // Создать нового ректора
        [HttpPost]
        public ActionResult Create(RectorDto rectorDto)
        {
            if (rectorDto == null)
            {
                return BadRequest();
            }

            var rector = new Rector
            {
                FullName = rectorDto.FullName,
                Degree = rectorDto.Degree,
                Title = rectorDto.Title,
                Position = rectorDto.Position,
                Id = rectorDto.UniversityId // Устанавливаем UniversityId
            };

            _rectorService.Create(rector);
            return CreatedAtAction(nameof(GetById), new { id = rector.Id }, rectorDto);
        }

        // Обновить информацию о ректоре
        [HttpPut("{id}")]
        public ActionResult Update(int id, RectorDto rectorDto)
        {
            var rector = _rectorService.GetById(id);
            if (rector == null)
            {
                return NotFound();
            }

            rector.FullName = rectorDto.FullName;
            rector.Degree = rectorDto.Degree;
            rector.Title = rectorDto.Title;
            rector.Position = rectorDto.Position;
            rector.Id = rectorDto.UniversityId; // Обновляем UniversityId

            _rectorService.Update(id, rector);
            return NoContent(); // Успешное обновление, но без контента
        }

        // Удалить ректора
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var rector = _rectorService.GetById(id);
            if (rector == null)
            {
                return NotFound();
            }

            _rectorService.Delete(id);
            return NoContent(); // Успешное удаление
        }
    }
}
