using Microsoft.AspNetCore.Mvc;
using UniversityData.Api.Dto;
using UniversityData.Domain;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Controllers;

/// <summary>
/// Контроллер для управления факультетами.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class FacultyController : ControllerBase
{
    private readonly IFacultyService _service;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="FacultyController"/>.
    /// </summary>
    /// <param name="service">Сервис для управления факультетами.</param>
    public FacultyController(IFacultyService service) => _service = service;

    /// <summary>
    /// Получает все факультеты.
    /// </summary>
    /// <returns>Список всех факультетов.</returns>
    [HttpGet]
    public IActionResult GetAll()
    {
        var faculties = _service.GetAll();
        return Ok(faculties);
    }

    /// <summary>
    /// Получает факультет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор факультета.</param>
    /// <returns>Факультет с указанным идентификатором или 404, если не найден.</returns>
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var faculty = _service.GetById(id);
        if (faculty == null)
            return NotFound();
        return Ok(faculty);
    }

    /// <summary>
    /// Создает новый факультет.
    /// </summary>
    /// <param name="dto">Данные нового факультета.</param>
    /// <returns>Созданный факультет с кодом состояния 201.</returns>
    [HttpPost]
    public IActionResult Create(FacultyDto dto)
    {
        var faculty = new Faculty
        {
            Name = dto.Name,
            Departments = new List<Department>()
        };

        _service.Create(faculty);
        return CreatedAtAction(nameof(GetById), new { id = faculty.Id }, faculty);
    }

    /// <summary>
    /// Обновляет существующий факультет.
    /// </summary>
    /// <param name="id">Идентификатор факультета для обновления.</param>
    /// <param name="dto">Обновленные данные факультета.</param>
    /// <returns>Код состояния 204, если обновление прошло успешно.</returns>
    [HttpPut("{id}")]
    public IActionResult Updatec(int id, FacultyDto dto)
    {
        var faculty = new Faculty
        {
            Name = dto.Name,
            Departments = new List<Department>()
        };

        _service.Update(id, faculty);
        return NoContent();
    }

    /// <summary>
    /// Удаляет факультет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор факультета для удаления.</param>
    /// <returns>Код состояния 204, если удаление прошло успешно.</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}
