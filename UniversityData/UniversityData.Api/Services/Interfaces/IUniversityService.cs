using UniversityData.Api.Dto;
using UniversityData.Domain;

namespace UniversityData.Api.Services.Interfaces;

/// <summary>
/// Интерфейс для управления университетами.
/// </summary>
public interface IUniversityService
{
    /// <summary>
    /// Получает все университеты.
    /// </summary>
    /// <returns>Список всех университетов в виде <see cref="UniversityDto"/>.</returns>
    List<UniversityDto> GetAll();

    /// <summary>
    /// Получает университет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор университета.</param>
    /// <returns>Университет с указанным идентификатором или <c>null</c>, если не найден.</returns>
    UniversityDto? GetById(int id);

    /// <summary>
    /// Создает новый университет.
    /// </summary>
    /// <param name="university">Данные нового университета.</param>
    void Create(University university);

    /// <summary>
    /// Обновляет существующий университет.
    /// </summary>
    /// <param name="id">Идентификатор университета для обновления.</param>
    /// <param name="university">Обновленные данные университета.</param>
    void Update(int id, University university);

    /// <summary>
    /// Удаляет университет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор университета для удаления.</param>
    void Delete(int id);

    /// <summary>
    /// Получает топ 5 специальностей по количеству групп.
    /// </summary>
    /// <returns>Список топ 5 специальностей в виде <see cref="SpecialtyDto"/>.</returns>
    List<SpecialtyDto> GetTop5SpecialtiesByGroups();

}