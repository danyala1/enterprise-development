using UniversityData.Domain;

namespace UniversityData.Api.Services.Interfaces;

/// <summary>
/// Интерфейс для управления департаментами.
/// </summary>
public interface IDepartmentService
{
    /// <summary>
    /// Получает все департаменты.
    /// </summary>
    /// <returns>Список всех департаментов.</returns>
    List<Department> GetAll();

    /// <summary>
    /// Получает департамент по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор департамента.</param>
    /// <returns>Департамент с указанным идентификатором или <c>null</c>, если не найден.</returns>
    Department? GetById(int id);

    /// <summary>
    /// Создает новый департамент.
    /// </summary>
    /// <param name="department">Данные нового департамента.</param>
    void Create(Department department);

    /// <summary>
    /// Обновляет существующий департамент.
    /// </summary>
    /// <param name="id">Идентификатор департамента для обновления.</param>
    /// <param name="department">Обновленные данные департамента.</param>
    void Update(int id, Department department);

    /// <summary>
    /// Удаляет департамент по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор департамента для удаления.</param>
    void Delete(int id);
}
