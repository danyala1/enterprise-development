using UniversityData.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Domain;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Controllers;

/// <summary>
/// Контроллер для управления специальностями.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SpecialtyController(IEntityService<Specialty> service, IAnalyticsService analyticsService) : ControllerBase
{
    private readonly IEntityService<Specialty> _service = service;
    private readonly IAnalyticsService _analyticsService = analyticsService;

    /// <summary>
    /// Получает все специальности.
    /// </summary>
    /// <returns>Список всех специальностей.</returns>
    [HttpGet]
    public ActionResult<SpecialtyDto> GetAll()
    {
        var specialties = _service.GetAll();
        return Ok(specialties);
    }

    /// <summary>
    /// Получает специальность по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор специальности.</param>
    /// <returns>Специальность с указанным идентификатором или 404, если не найдена.</returns>
    [HttpGet("{id}")]
    public ActionResult<SpecialtyDto> GetById(int id)
    {
        var specialty = _service.GetById(id);
        if (specialty == null)
            return NotFound();
        return Ok(specialty);
    }

    /// <summary>
    /// Создает новую специальность.
    /// </summary>
    /// <param name="dto">Данные новой специальности.</param>
    /// <returns>Созданная специальность с кодом состояния 201.</returns>
    [HttpPost]
    public ActionResult<SpecialtyDto> Create(SpecialtyDto dto)
    {
        var specialty = new Specialty
        {
            Code = dto.Code,
            Name = dto.Name,
            GroupCount = dto.GroupCount,
            UniversityId = dto.UniversityId,
            DepartmentId = dto.DepartmentId,
           
        };

        _service.Create(specialty);
        return CreatedAtAction(nameof(GetById), new { id = specialty.Id }, specialty);
    }

    /// <summary>
    /// Обновляет существующую специальность.
    /// </summary>
    /// <param name="id">Идентификатор специальности для обновления.</param>
    /// <param name="dto">Обновленные данные специальности.</param>
    /// <returns>Код состояния 204, если обновление прошло успешно.</returns>
    [HttpPut("{id}")]
    public ActionResult<SpecialtyDto> Update(int id, SpecialtyDto dto)
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

    /// <summary>
    /// Удаляет специальность по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор специальности для удаления.</param>
    /// <returns>Код состояния 204, если удаление прошло успешно.</returns>
    [HttpDelete("{id}")]
    public ActionResult<SpecialtyDto> Delete(int id)
    {
        var specialty = _service.GetById(id);
        if (specialty == null)
            return NotFound();

        _service.Delete(id);
        return NoContent();
    }

    /// <summary>
    /// Получает топ 5 специальностей по количеству групп.
    /// </summary>
    /// <returns>Список топ 5 специальных с наибольшим количеством групп.</returns>
    [HttpGet("top")]
    public ActionResult<SpecialtyDto> GetTopSpecialties()
    {
        var result = _analyticsService.GetTop5SpecialtiesByGroups(); 
        if (result == null || !result.Any())
            return NotFound();

        return Ok(result); 
    }
}