using Microsoft.AspNetCore.Mvc;
using UniversityData.Api.Dto;
using UniversityData.Domain;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Controllers;

/// <summary>
/// Контроллер для управления университетами.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UniversityController : ControllerBase
{
    private readonly IUniversityService _service;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="UniversityController"/>.
    /// </summary>
    /// <param name="service">Сервис для управления университетами.</param>
    public UniversityController(IUniversityService service) => _service = service;

    /// <summary>
    /// Получает все университеты.
    /// </summary>
    /// <returns>Список всех университетов.</returns>
    [HttpGet]
    public IActionResult GetAll()
    {
        var universities = _service.GetAll();
        return Ok(universities);
    }

    /// <summary>
    /// Получает университет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор университета.</param>
    /// <returns>Университет с указанным идентификатором или 404, если не найден.</returns>
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var university = _service.GetById(id);
        if (university == null)
            return NotFound();
        return Ok(university);
    }

    /// <summary>
    /// Создает новый университет.
    /// </summary>
    /// <param name="dto">Данные нового университета.</param>
    /// <returns>Созданный университет с кодом состояния 201.</returns>
    [HttpPost]
    public IActionResult Create(UniversityDto dto)
    {
        if (dto.Rector == null)
        {
            return BadRequest("Rector information is required.");
        }

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

        return CreatedAtAction(nameof(GetById), new { id = university.RegistrationNumber }, dto);
    }

    /// <summary>
    /// Обновляет существующий университет.
    /// </summary>
    /// <param name="id">Идентификатор университета для обновления.</param>
    /// <param name="dto">Обновленные данные университета.</param>
    /// <returns>Код состояния 204, если обновление прошло успешно.</returns>
    [HttpPut("{id}")]
    public IActionResult Update(int id, UniversityDto dto)
    {
        if (dto.Rector == null)
        {
            return BadRequest("Rector information is required.");
        }

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


    /// <summary>
    /// Удаляет университет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор университета для удаления.</param>
    /// <returns>Код состояния 204, если удаление прошло успешно.</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var university = _service.GetById(id);
        if (university == null)
        {
            return NotFound();
        }

        _service.Delete(id);
        return NoContent();
    }

    /// <summary>
    /// Получает топ университетов по количеству департаментов.
    /// </summary>
    /// <returns>Список топ университетов с наибольшим количеством департаментов.</returns>
    [HttpGet("top-departments")]
    public IActionResult GetTopUniversitiesByDepartments()
    {
        var result = _service.GetTopUniversitiesByDepartments();
        return Ok(result);
    }

    /// <summary>
    /// Получает университеты по типу собственности.
    /// </summary>
    /// <param name="ownership">Тип собственности университета.</param>
    /// <returns>Список университетов с указанным типом собственности.</returns>
    [HttpGet("ownership/{ownership}")]
    public IActionResult GetUniversitiesByOwnership(string ownership)
    {
        var result = _service.GetUniversitiesByOwnership(ownership);
        return Ok(result);
    }

    /// <summary>
    /// Получает сводку по университетам по типу собственности.
    /// </summary>
    /// <returns>Сводка по университетам по типу собственности.</returns>
    [HttpGet("summary")]
    public IActionResult GetSummaryByOwnership()
    {
        var summary = _service.GetSummaryByOwnership();
        return Ok(summary);
    }
}
