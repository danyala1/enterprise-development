using Microsoft.AspNetCore.Mvc;
using UniversityData.Api.Dto;
using UniversityData.Domain;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Controllers;

/// <summary>
/// Контроллер для управления факультетами.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FacultyController : ControllerBase
{
    private readonly IEntityService<Faculty> _service;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="FacultyController"/>.
    /// </summary>
    /// <param name="service">Сервис для управления факультетами.</param>
    public FacultyController(IEntityService<Faculty> service) => _service = service;

    /// <summary>
    /// Получает все факультеты.
    /// </summary>
    /// <returns>Список всех факультетов в виде <see cref="List{FacultyDto}"/>.</returns>
    [HttpGet]
    public ActionResult<List<FacultyDto>> GetAll()
    {
        try
        {
            var faculties = _service.GetAll();
            var facultyDtos = faculties.Select(f => new FacultyDto
            {
                Id = f.Id,
                Name = f.Name,
                UniversityId = f.UniversityId
            }).ToList();

            return Ok(facultyDtos);
        }
        catch (Exception ex)
        {
            // Логируем ошибку
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Получает факультет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор факультета.</param>
    /// <returns>Факультет с указанным идентификатором или 404, если не найден.</returns>
    [HttpGet("{id}")]
    public ActionResult<FacultyDto> GetById(int id)
    {
        try
        {
            var faculty = _service.GetById(id);
            if (faculty == null)
                return NotFound($"Faculty with ID {id} not found.");

            return Ok(new FacultyDto
            {
                Id = faculty.Id,
                Name = faculty.Name,
                UniversityId = faculty.UniversityId
            });
        }
        catch (Exception ex)
        {

            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Создает новый факультет.
    /// </summary>
    /// <param name="dto">Данные нового факультета.</param>
    /// <returns>Созданный факультет с кодом состояния 201.</returns>
    [HttpPost]
    public ActionResult<FacultyDto> Create(FacultyDto dto)
    {
        try
        {
            var faculty = new Faculty
            {
                Name = dto.Name,
                UniversityId = dto.UniversityId
            };

            _service.Create(faculty);
            return CreatedAtAction(nameof(GetById), new { id = faculty.Id }, new FacultyDto
            {
                Id = faculty.Id,
                Name = faculty.Name,
                UniversityId = faculty.UniversityId
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Обновляет существующий факультет.
    /// </summary>
    /// <param name="id">Идентификатор факультета для обновления.</param>
    /// <param name="dto">Обновленные данные факультета.</param>
    /// <returns>Код состояния 204, если обновление прошло успешно.</returns>
    [HttpPut("{id}")]
    public ActionResult Update(int id, FacultyDto dto)
    {
        try
        {
            var faculty = new Faculty
            {
                Name = dto.Name,
                UniversityId = dto.UniversityId
            };

            _service.Update(id, faculty);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    /// <summary>
    /// Удаляет факультет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор факультета для удаления.</param>
    /// <returns>Код состояния 204, если удаление прошло успешно.</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        try
        {
            _service.Delete(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {

            return StatusCode(500, ex.Message);
        }
    }
}
