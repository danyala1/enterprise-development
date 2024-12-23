using UniversityData.Api.Dto;
using UniversityData.Api.Services.Interfaces;
using UniversityData.Domain;
using Microsoft.EntityFrameworkCore;

namespace UniversityData.Api.Services;

/// <summary>
/// Сервис для аналитических запросов.
/// </summary>
public class AnalyticsService : IAnalyticsService
{
    private readonly UniversityDbContext _context;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="AnalyticsService"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public AnalyticsService(UniversityDbContext context) => _context = context;

    /// <summary>
    /// Получает топ университетов по количеству департаментов.
    /// </summary>
    /// <returns>Список топ университетов в виде <see cref="UniversityDto"/>.</returns>
    public List<UniversityDto> GetTopUniversitiesByDepartments()
    {
        return _context.Universities
            .OrderByDescending(u => u.Faculties.SelectMany(f => f.Departments).Count()) 
            .Take(5)
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
    /// Получает топ 5 специальностей по количеству групп.
    /// </summary>
    /// <returns>Список топ 5 специальностей в виде <see cref="SpecialtyDto"/>.</returns>
    public List<SpecialtyDto> GetTop5SpecialtiesByGroups()
    {
        return _context.Universities
            .SelectMany(u => u.Faculties.SelectMany(f => f.Departments.SelectMany(d => d.Specialties)))
            .GroupBy(s => new { s.Code, s.Name }) 
            .Select(g => new SpecialtyDto
            {
                Name = g.Key.Name,
                Code = g.Key.Code,
                GroupCount = g.Sum(s => s.GroupCount) 
            })
            .OrderByDescending(s => s.GroupCount)
            .Take(5)
            .ToList();
    }

    /// <summary>
    /// Получает университеты по типу собственности.
    /// </summary>
    /// <param name="ownership">Тип собственности университета.</param>
    /// <returns>Список университетов с указанным типом собственности в виде <see cref="UniversityDto"/>.</returns>
    public List<UniversityDto> GetUniversitiesByOwnership(string ownership)
    {
        return _context.Universities
            .Where(u => u.InstitutionOwnership.Equals(ownership, StringComparison.OrdinalIgnoreCase))
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
    /// Получает сводку по университетам по типу собственности.
    /// </summary>
    /// <returns>Словарь с типами собственности и количеством факультетов, департаментов и специальностей.</returns>
    public List<OwnershipSummaryDto> GetSummaryByOwnership()
    {
        return _context.Universities
            .GroupBy(u => new { u.InstitutionOwnership, u.BuildingOwnership })
            .Select(g => new OwnershipSummaryDto
            {
                OwnershipType = $"{g.Key.InstitutionOwnership} - {g.Key.BuildingOwnership}",
                FacultyCount = g.SelectMany(u => u.Faculties).Count(),
                DepartmentCount = g.SelectMany(u => u.Faculties.SelectMany(f => f.Departments)).Count(),
                SpecialtyCount = g.SelectMany(u => u.Faculties.SelectMany(f => f.Departments.SelectMany(d => d.Specialties))).Count()
            })
            .ToList();
    }
}
