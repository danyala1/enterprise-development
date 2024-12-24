using UniversityData.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Domain;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Controllers;

/// <summary>
/// Контроллер для управления ректорами.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RectorController : ControllerBase
{
    private readonly IEntityService<Rector> _rectorService;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="RectorController"/>.
    /// </summary>
    /// <param name="rectorService">Сервис для управления ректорами.</param>
    public RectorController(IEntityService<Rector> rectorService) => _rectorService = rectorService;

    /// <summary>
    /// Получает всех ректоров.
    /// </summary>
    /// <returns>Список всех ректоров.</returns>
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
            UniversityId = r.UniversityId
        }).ToList();

        return Ok(rectorDtos);
    }

    /// <summary>
    /// Получает ректора по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор ректора.</param>
    /// <returns>Ректор с указанным идентификатором или 404, если не найден.</returns>
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
            UniversityId = rector.UniversityId // Используйте правильное поле
        };

        return Ok(rectorDto);
    }

    /// <summary>
    /// Создает нового ректора.
    /// </summary>
    /// <param name="rectorDto">Данные нового ректора.</param>
    /// <returns>Созданный ректор с кодом состояния 201.</returns>
    [HttpPost]
    public ActionResult<RectorDto> Create(RectorDto rectorDto)
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
            UniversityId = rectorDto.UniversityId
            
        };

        _rectorService.Create(rector);
        return CreatedAtAction(nameof(GetById), new { id = rector.Id }, rectorDto);
    }

    /// <summary>
    /// Обновляет существующего ректора.
    /// </summary>
    /// <param name="id">Идентификатор ректора для обновления.</param>
    /// <param name="rectorDto">Обновленные данные ректора.</param>
    /// <returns>Код состояния 204, если обновление прошло успешно.</returns>
    [HttpPut("{id}")]
    public ActionResult Update(int id, RectorDto rectorDto)
    {
        var existingRector = _rectorService.GetById(id);
        if (existingRector == null)
        {
            return NotFound();
        }

        existingRector.FullName = rectorDto.FullName;
        existingRector.Degree = rectorDto.Degree;
        existingRector.Title = rectorDto.Title;
        existingRector.Position = rectorDto.Position;

        _rectorService.Update(id, existingRector); // Передаем существующего ректора для обновления
        return NoContent();
    }

    /// <summary>
    /// Удаляет ректора по идентификатору.
    /// </summary>
    /// <param name="rectorIdDto">DTO с идентификатором ректора для удаления.</param>
    /// <returns>Код состояния 204, если удаление прошло успешно.</returns>
    [HttpDelete]
    public ActionResult Delete([FromBody] RectorIdDto rectorIdDto)
    {
        var existingRector = _rectorService.GetById(rectorIdDto.Id);
        if (existingRector == null)
        {
            return NotFound();
        }

        _rectorService.Delete(rectorIdDto.Id);
        return NoContent();
    }
}
