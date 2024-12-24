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
    private readonly IEntityService<University> _service;
    private readonly IAnalyticsService _analyticsService;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="UniversityController"/>.
    /// </summary>
    /// <param name="service">Сервис для управления университетами.</param>
    /// <param name="analyticsService">Сервис для аналитических запросов.</param>
    public UniversityController(IEntityService<University> service, IAnalyticsService analyticsService)
    {
        _service = service;
        _analyticsService = analyticsService;
    }

    /// <summary>
    /// Получает все университеты.
    /// </summary>
    /// <returns>Список всех университетов.</returns>
    [HttpGet]
    public ActionResult<UniversityDto> GetAll()
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
    public ActionResult<UniversityDto> GetById(int id)
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
    public ActionResult<UniversityDto> Create(UniversityDto dto)
    {
        if (dto.RectorId == 0)
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
            RectorId = dto.RectorId,
            Faculties =  []
          
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
    public ActionResult<UniversityDto> Update(int id, UniversityDto dto)
    {
        if (dto.RectorId == 0)
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
            RectorId = dto.RectorId,
            Faculties = []
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
    public ActionResult<UniversityDto> Delete(int id)
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
    public ActionResult<UniversityDto> GetTopUniversitiesByDepartments()
    {
        var result = _analyticsService.GetTopUniversitiesByDepartments();
        return Ok(result);
    }

    /// <summary>
    /// Получает университеты по типу собственности.
    /// </summary>
    /// <param name="ownership">Тип собственности университета.</param>
    /// <returns>Список университетов с указанным типом собственности.</returns>
    [HttpGet("ownership/{ownership}")]
    public ActionResult<UniversityDto> GetUniversitiesByOwnership(string ownership)
    {
        var result = _analyticsService.GetUniversitiesByOwnership(ownership);
        return Ok(result);
    }

    /// <summary>
    /// Получает сводку по университетам по типу собственности.
    /// </summary>
    /// <returns>Сводка по университетам по типу собственности.</returns>
    [HttpGet("summary")]
    public ActionResult<OwnershipSummaryDto> GetSummaryByOwnership()
    {
        var summary = _analyticsService.GetSummaryByOwnership();
        return Ok(summary);
    }
}