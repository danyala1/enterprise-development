using UniversityData.Domain;
using UniversityData.Api.Dto;
using UniversityData.Api.Services.Interfaces;

namespace UniversityData.Api.Services;

/// <summary>
/// Сервис для управления университетами.
/// </summary>
public class UniversityService : IUniversityService
{
    private readonly List<University> _universities = new();

    /// <summary>
    /// Получает все университеты.
    /// </summary>
    /// <returns>Список всех университетов в виде <see cref="UniversityDto"/>.</returns>
    public List<UniversityDto> GetAll()
    {
        return _universities
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
        var university = _universities.FirstOrDefault(u => u.RegistrationNumber == id);
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

    /// <summary>
    /// Создает новый университет.
    /// </summary>
    /// <param name="university">Данные нового университета.</param>
    public void Create(University university)
    {
        _universities.Add(university);
    }

    /// <summary>
    /// Обновляет существующий университет.
    /// </summary>
    /// <param name="id">Идентификатор университета для обновления.</param>
    /// <param name="university">Обновленные данные университета.</param>
    public void Update(int id, University university)
    {
        var existingUniversity = _universities.FirstOrDefault(u => u.RegistrationNumber == id);
        if (existingUniversity != null)
        {
            existingUniversity.Name = university.Name;
            existingUniversity.Address = university.Address;
            existingUniversity.InstitutionOwnership = university.InstitutionOwnership;
            existingUniversity.BuildingOwnership = university.BuildingOwnership;
        }
    }

    /// <summary>
    /// Удаляет университет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор университета для удаления.</param>
    public void Delete(int id)
    {
        var university = _universities.FirstOrDefault(u => u.RegistrationNumber == id);
        if (university != null)
        {
            _universities.Remove(university);
        }
    }

    /// <summary>
    /// Получает топ университетов по количеству департаментов.
    /// </summary>
    /// <returns>Список топ университетов с наибольшим количеством департаментов в виде <see cref="UniversityDto"/>.</returns>
    public List<UniversityDto> GetTopUniversitiesByDepartments()
    {
        return _universities
            .OrderByDescending(u => u.Faculties.SelectMany(f => f.Departments).Count()) // Считаем кафедры по всем факультетам
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
        return _universities
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
    /// Получает университеты по типу собственности.
    /// </summary>
    /// <param name="ownership">Тип собственности университета.</param>
    /// <returns>Список университетов с указанным типом собственности в виде <see cref="UniversityDto"/>.</returns>
    public List<UniversityDto> GetUniversitiesByOwnership(string ownership)
    {
        return _universities
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
    public Dictionary<string, (int faculties, int departments, int specialties)> GetSummaryByOwnership()
    {
        return _universities
            .GroupBy(u => new { u.InstitutionOwnership, u.BuildingOwnership })
            .ToDictionary(
                g => $"{g.Key.InstitutionOwnership} - {g.Key.BuildingOwnership}",
                g => (
                    faculties: g.SelectMany(u => u.Faculties).Count(),
                    departments: g.SelectMany(u => u.Faculties.SelectMany(f => f.Departments)).Count(),
                    specialties: g.SelectMany(u => u.Faculties.SelectMany(f => f.Departments.SelectMany(d => d.Specialties))).Count()
                )
            );
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
