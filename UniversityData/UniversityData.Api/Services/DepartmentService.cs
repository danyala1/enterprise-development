using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Services;

/// <summary>
/// Сервис для управления департаментами.
/// </summary>
public class DepartmentService : IDepartmentService
{
    private readonly UniversityDbContext _context;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="DepartmentService"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public DepartmentService(UniversityDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получает все департаменты.
    /// </summary>
    /// <returns>Список всех департаментов.</returns>
    public List<Department> GetAll()
    {
        return _context.Departments
            .Include(d => d.Specialties)
            .ToList();
    }

    /// <summary>
    /// Получает департамент по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор департамента.</param>
    /// <returns>Департамент с указанным идентификатором или <c>null</c>, если не найден.</returns>
    public Department? GetById(int id)
    {
        return _context.Departments
            .Include(d => d.Specialties)
            .FirstOrDefault(d => d.Id == id);
    }

    /// <summary>
    /// Создает новый департамент.
    /// </summary>
    /// <param name="department">Данные нового департамента.</param>
    public void Create(Department department)
    {
        _context.Departments.Add(department);
        _context.SaveChanges(); 
    }

    /// <summary>
    /// Обновляет существующий департамент.
    /// </summary>
    /// <param name="id">Идентификатор департамента для обновления.</param>
    /// <param name="department">Обновленные данные департамента.</param>
    public void Update(int id, Department department)
    {
        var existingDepartment = GetById(id);
        if (existingDepartment != null)
        {
            existingDepartment.Name = department.Name;
            _context.SaveChanges(); 
        }
    }

    /// <summary>
    /// Удаляет департамент по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор департамента для удаления.</param>
    public void Delete(int id)
    {
        var department = GetById(id);
        if (department != null)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }
    }
}
