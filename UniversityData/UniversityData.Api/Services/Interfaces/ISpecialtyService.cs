using UniversityData.Domain;

namespace UniversityData.Api.Services.Interfaces;

/// <summary>
/// Интерфейс для управления специальностями.
/// </summary>
public interface ISpecialtyService
{
    /// <summary>
    /// Получает все специальности.
    /// </summary>
    /// <returns>Список всех специальностей.</returns>
    List<Specialty> GetAll();

    /// <summary>
    /// Получает специальность по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор специальности.</param>
    /// <returns>Специальность с указанным идентификатором или <c>null</c>, если не найдена.</returns>
    Specialty? GetById(int id);

    /// <summary>
    /// Создает новую специальность.
    /// </summary>
    /// <param name="specialty">Данные новой специальности.</param>
    void Create(Specialty specialty);

    /// <summary>
    /// Обновляет существующую специальность.
    /// </summary>
    /// <param name="id">Идентификатор специальности для обновления.</param>
    /// <param name="specialty">Обновленные данные специальности.</param>
    void Update(int id, Specialty specialty);

    /// <summary>
    /// Удаляет специальность по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор специальности для удаления.</param>
    void Delete(int id);
}