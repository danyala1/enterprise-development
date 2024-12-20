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
public class SpecialtyController : ControllerBase
{
    private readonly ISpecialtyService _service;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="SpecialtyController"/>.
    /// </summary>
    /// <param name="service">Сервис для управления специальностями.</param>
    public SpecialtyController(ISpecialtyService service)
    {
        _service = service;
    }

    /// <summary>
    /// Получает все специальности.
    /// </summary>
    /// <returns>Список всех специальностей.</returns>
    [HttpGet]
    public IActionResult GetAll()
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
    public IActionResult GetById(int id)
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

    /// <summary>
    /// Обновляет существующую специальность.
    /// </summary>
    /// <param name="id">Идентификатор специальности для обновления.</param>
    /// <param name="dto">Обновленные данные специальности.</param>
    /// <returns>Код состояния 204, если обновление прошло успешно.</returns>
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

    /// <summary>
    /// Удаляет специальность по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор специальности для удаления.</param>
    /// <returns>Код состояния 204, если удаление прошло успешно.</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var specialty = _service.GetById(id);
        if (specialty == null)
            return NotFound();

        _service.Delete(id);
        return NoContent();
    }

    /// <summary>
    /// Получает топ специальностей по количеству групп.
    /// </summary>
    /// <returns>Список топ специальных с наибольшим количеством групп.</returns>
    [HttpGet("top")]
    public IActionResult GetTopSpecialties()
    {
        var result = _service.GetTopSpecialtiesByGroups();
        return Ok(result);
    }
}
