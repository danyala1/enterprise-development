using UniversityData.Domain;
using UniversityData.Api.Dto;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Services;

/// <summary>
/// Сервис для управления университетами.
/// </summary>
public class UniversityService : IUniversityService
{   
    private readonly UniversityDbContext _context;
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="UniversityService"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public UniversityService(UniversityDbContext context) => _context = context;

    /// <summary>
    /// Получает все университеты.
    /// </summary>
    /// <returns>Список всех университетов в виде <see cref="UniversityDto"/>.</returns>
    public List<UniversityDto> GetAll()
    {
        return _context.Universities
            .Select(u => new UniversityDto
            {
                RegistrationNumber = u.RegistrationNumber,
                Name = u.Name,
                Address = u.Address,
                InstitutionOwnership = u.InstitutionOwnership,
                BuildingOwnership = u.BuildingOwnership
            })
            .ToList();
    }

    /// <summary>
    /// Получает университет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор университета.</param>
    /// <returns>Университет с указанным идентификатором или <c>null</c>, если не найден.</returns>
    public UniversityDto? GetById(int id)
    {
        var university = _context.Universities.FirstOrDefault(u => u.RegistrationNumber == id);
        if (university == null)
            return null;

        return new UniversityDto
        {
            RegistrationNumber = university.RegistrationNumber,
            Name = university.Name,
            Address = university.Address,
            InstitutionOwnership = university.InstitutionOwnership,
            BuildingOwnership = university.BuildingOwnership,
            RectorId = university.RectorId
        };
    }

    /// <summary>
    /// Создает новый университет.
    /// </summary>
    /// <param name="university">Данные нового университета.</param>
    public void Create(University university)
    {
        _context.Universities.Add(university);
        _context.SaveChanges();
    }

    /// <summary>
    /// Обновляет существующий университет.
    /// </summary>
    /// <param name="id">Идентификатор университета для обновления.</param>
    /// <param name="university">Обновленные данные университета.</param>
    public void Update(int id, University university)
    {
        var existingUniversity = _context.Universities.FirstOrDefault(u => u.RegistrationNumber == id);
        if (existingUniversity != null)
        {
            existingUniversity.Name = university.Name;
            existingUniversity.Address = university.Address;
            existingUniversity.InstitutionOwnership = university.InstitutionOwnership;
            existingUniversity.BuildingOwnership = university.BuildingOwnership;
        }
        _context.SaveChanges();
    }

    /// <summary>
    /// Удаляет университет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор университета для удаления.</param>
    public void Delete(int id)
    {
        var university = _context.Universities.Find(id);
        if (university != null)
        {
            _context.Universities.Remove(university);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Получает топ 5 специальностей по количеству групп.
    /// </summary>
    /// <returns>Список топ 5 специальностей в виде <see cref="SpecialtyDto"/>.</returns>
    public List<SpecialtyDto> GetTop5SpecialtiesByGroups()
    {
        return _context.Universities
            .SelectMany(u => u.Faculties.SelectMany(f => f.Departments.SelectMany(d => d.Specialties)))
            .OrderByDescending(s => s.GroupCount)
            .Take(5)
            .Select(s => new SpecialtyDto
            {
                Name = s.Name,
                Code = s.Code,
                GroupCount = s.GroupCount
            })
            .ToList();
    }

    /// <summary>
    /// Получает детали университета по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор университета.</param>
    /// <returns>Детали университета в виде <see cref="UniversityDto"/> или <c>null</c>, если не найден.</returns>
    public UniversityDto? GetUniversityDetails(int id)
    {
        var university = GetById(id);
        if (university == null)
            return null;

        return new UniversityDto
        {
            RegistrationNumber = university.RegistrationNumber,
            Name = university.Name,
            Address = university.Address,
            InstitutionOwnership = university.InstitutionOwnership,
            BuildingOwnership = university.BuildingOwnership
        };
    }
}
