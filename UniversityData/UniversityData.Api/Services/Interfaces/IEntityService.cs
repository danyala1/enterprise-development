using System.Collections.Generic;

namespace UniversityData.Api.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для управления сущностями.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public interface IEntityService<T> where T : class
    {
        /// <summary>
        /// Получает все сущности.
        /// </summary>
        /// <returns>Список всех сущностей.</returns>
        List<T> GetAll();

        /// <summary>
        /// Получает сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность с указанным идентификатором или <c>null</c>, если не найдена.</returns>
        T? GetById(int id);

        /// <summary>
        /// Создает новую сущность.
        /// </summary>
        /// <param name="entity">Данные новой сущности.</param>
        void Create(T entity);

        /// <summary>
        /// Обновляет существующую сущность.
        /// </summary>
        /// <param name="id">Идентификатор сущности для обновления.</param>
        /// <param name="entity">Обновленные данные сущности.</param>
        void Update(int id, T entity);

        /// <summary>
        /// Удаляет сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности для удаления.</param>
        void Delete(int id);
    }
}
