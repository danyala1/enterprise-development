using UniversityData.Domain;

namespace UniversityData.Api.Services.Interfaces;

/// <summary>
/// Интерфейс для управления ректорами.
/// </summary>
public interface IRectorService
{
    /// <summary>
    /// Получает всех ректоров.
    /// </summary>
    /// <returns>Список всех ректоров.</returns>
    List<Rector> GetAll();

    /// <summary>
    /// Получает ректора по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор ректора.</param>
    /// <returns>Ректор с указанным идентификатором или <c>null</c>, если не найден.</returns>
    Rector? GetById(int id);

    /// <summary>
    /// Создает нового ректора.
    /// </summary>
    /// <param name="rector">Данные нового ректора.</param>
    void Create(Rector rector);

    /// <summary>
    /// Обновляет существующего ректора.
    /// </summary>
    /// <param name="id">Идентификатор ректора для обновления.</param>
    /// <param name="rector">Обновленные данные ректора.</param>
    void Update(int id, Rector rector);

    /// <summary>
    /// Удаляет ректора по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор ректора для удаления.</param>
    void Delete(int id);
}
