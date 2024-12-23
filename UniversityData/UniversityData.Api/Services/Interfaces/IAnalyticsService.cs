using UniversityData.Api.Dto;

namespace UniversityData.Api.Services.Interfaces;

/// <summary>
/// Интерфейс для аналитических запросов.
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    /// Получает топ университетов по количеству департаментов.
    /// </summary>
    /// <returns>Список топ университетов в виде <see cref="UniversityDto"/>.</returns>
    List<UniversityDto> GetTopUniversitiesByDepartments();

    /// <summary>
    /// Получает топ 5 специальностей по количеству групп.
    /// </summary>
    /// <returns>Список топ 5 специальностей в виде <see cref="SpecialtyDto"/>.</returns>
    List<SpecialtyDto> GetTop5SpecialtiesByGroups();

    /// <summary>
    /// Получает университеты по типу собственности.
    /// </summary>
    /// <param name="ownership">Тип собственности университета.</param>
    /// <returns>Список университетов с указанным типом собственности в виде <see cref="UniversityDto"/>.</returns>
    List<UniversityDto> GetUniversitiesByOwnership(string ownership);

    /// <summary>
    /// Получает сводку по университетам по типу собственности.
    /// </summary>
    /// <returns>Словарь с типами собственности и количеством факультетов, департаментов и специальностей.</returns>
    List<OwnershipSummaryDto> GetSummaryByOwnership();
}
