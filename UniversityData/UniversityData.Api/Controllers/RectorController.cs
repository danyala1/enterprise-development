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
    private readonly IRectorService _rectorService;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="RectorController"/>.
    /// </summary>
    /// <param name="rectorService">Сервис для управления ректорами.</param>
    public RectorController(IRectorService rectorService) => _rectorService = rectorService;

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
            UniversityId = r.Id
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
            UniversityId = rector.Id
        };

        return Ok(rectorDto);
    }

    /// <summary>
    /// Создает нового ректора.
    /// </summary>
    /// <param name="rectorDto">Данные нового ректора.</param>
    /// <returns>Созданный ректор с кодом состояния 201.</returns>
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
            Id = rectorDto.UniversityId
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
        var rector = _rectorService.GetById(id);
        if (rector == null)
        {
            return NotFound();
        }

        rector.FullName = rectorDto.FullName;
        rector.Degree = rectorDto.Degree;
        rector.Title = rectorDto.Title;
        rector.Position = rectorDto.Position;
        rector.Id = rectorDto.UniversityId;

        _rectorService.Update(id, rector);
        return NoContent();
    }

    /// <summary>
    /// Удаляет ректора по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор ректора для удаления.</param>
    /// <returns>Код состояния 204, если удаление прошло успешно.</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var rector = _rectorService.GetById(id);
        if (rector == null)
        {
            return NotFound();
        }

        _rectorService.Delete(id);
        return NoContent();
    }
}
