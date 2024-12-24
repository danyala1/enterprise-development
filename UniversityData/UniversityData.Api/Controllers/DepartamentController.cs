using Microsoft.AspNetCore.Mvc;
using UniversityData.Api.Dto;
using UniversityData.Domain;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Controllers;
/// <summary>
/// Контроллер для управления департаментами.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IEntityService<Department> _service;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="DepartmentController"/>.
    /// </summary>
    /// <param name="service">Сервис для управления департаментами.</param>
    public DepartmentController(IEntityService<Department> service) => _service = service;

    /// <summary>
    /// Получает все департаменты.
    /// </summary>
    /// <returns>Список всех департаментов.</returns>
    [HttpGet]
    public ActionResult<List<DepartmentDto>> GetAll()
    {
        var departments = _service.GetAll();
        return Ok(departments);
    }

    /// <summary>
    /// Получает департамент по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор департамента.</param>
    /// <returns>Департамент с указанным идентификатором или 404, если не найден.</returns>
    [HttpGet("{id}")]
    public ActionResult<DepartmentDto> GetById(int id)
    {
        var department = _service.GetById(id);
        if (department == null)
            return NotFound();
        return Ok(department);
    }

    /// <summary>
    /// Создает новый департамент.
    /// </summary>
    /// <param name="dto">Данные нового департамента.</param>
    /// <returns>Созданный департамент с кодом состояния 201.</returns>
    [HttpPost]
    public ActionResult<DepartmentDto> Create(DepartmentDto dto)
    {

        var department = new Department
        {
            Name = dto.Name,
            Id = dto.FacultyId
        };

        _service.Create(department);
        return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
    }

    /// <summary>
    /// Обновляет существующий департамент.
    /// </summary>
    /// <param name="id">Идентификатор департамента для обновления.</param>
    /// <param name="dto">Обновленные данные департамента.</param>
    /// <returns>Код состояния 204, если обновление прошло успешно.</returns>
    [HttpPut("{id}")]
    public ActionResult<DepartmentDto> Update(int id, DepartmentDto dto)
    {
        var department = new Department
        {
            Name = dto.Name
        };

        _service.Update(id, department);
        return NoContent();
    }

    /// <summary>
    /// Удаляет департамент по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор департамента для удаления.</param>
    /// <returns>Код состояния 204, если удаление прошло успешно.</returns>
    [HttpDelete("{id}")]
    public ActionResult<DepartmentDto> Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}