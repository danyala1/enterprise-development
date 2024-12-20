using UniversityData.Domain;

namespace UniversityData.Api.Services.Interfaces;

/// <summary>
/// Интерфейс для управления факультетами.
/// </summary>
public interface IFacultyService
{
    /// <summary>
    /// Получает все факультеты.
    /// </summary>
    /// <returns>Список всех факультетов.</returns>
    List<Faculty> GetAll();

    /// <summary>
    /// Получает факультет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор факультета.</param>
    /// <returns>Факультет с указанным идентификатором или <c>null</c>, если не найден.</returns>
    Faculty? GetById(int id);

    /// <summary>
    /// Создает новый факультет.
    /// </summary>
    /// <param name="faculty">Данные нового факультета.</param>
    void Create(Faculty faculty);

    /// <summary>
    /// Обновляет существующий факультет.
    /// </summary>
    /// <param name="id">Идентификатор факультета для обновления.</param>
    /// <param name="faculty">Обновленные данные факультета.</param>
    void Update(int id, Faculty faculty);

    /// <summary>
    /// Удаляет факультет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор факультета для удаления.</param>
    void Delete(int id);
}
