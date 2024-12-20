using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Services;

/// <summary>
/// Сервис для управления факультетами.
/// </summary>
public class FacultyService : IFacultyService
{
    private readonly UniversityDbContext _context;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="FacultyService"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public FacultyService(UniversityDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получает все факультеты.
    /// </summary>
    /// <returns>Список всех факультетов.</returns>
    public List<Faculty> GetAll()
    {
        return _context.Faculties
            .Include(f => f.Departments)
            .ToList();
    }

    /// <summary>
    /// Получает факультет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор факультета.</param>
    /// <returns>Факультет с указанным идентификатором или <c>null</c>, если не найден.</returns>
    public Faculty? GetById(int id)
    {
        return _context.Faculties
            .Include(f => f.Departments)
            .FirstOrDefault(f => f.Id == id);
    }

    /// <summary>
    /// Создает новый факультет.
    /// </summary>
    /// <param name="faculty">Данные нового факультета.</param>
    public void Create(Faculty faculty)
    {
        _context.Faculties.Add(faculty);
        _context.SaveChanges(); 
    }

    /// <summary>
    /// Обновляет существующий факультет.
    /// </summary>
    /// <param name="id">Идентификатор факультета для обновления.</param>
    /// <param name="faculty">Обновленные данные факультета.</param>
    public void Update(int id, Faculty faculty)
    {
        var existingFaculty = GetById(id);
        if (existingFaculty != null)
        {
            existingFaculty.Name = faculty.Name;
            existingFaculty.Departments = faculty.Departments; 
            _context.SaveChanges(); 
        }
    }

    /// <summary>
    /// Удаляет факультет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор факультета для удаления.</param>
    public void Delete(int id)
    {
        var faculty = GetById(id);
        if (faculty != null)
        {
            _context.Faculties.Remove(faculty);
            _context.SaveChanges(); 
        }
    }
}
