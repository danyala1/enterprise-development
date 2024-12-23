using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

/// <summary>
/// Представляет факультет университета.
/// </summary>
public class Faculty
{
    /// <summary>
    /// Получает или задает уникальный идентификатор факультета.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Получает или задает название факультета.
    /// Это обязательное поле.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Получает или задает идентификатор университета, к которому принадлежит факультет.
    /// </summary>
    public int UniversityId { get; set; }

    /// <summary>
    /// Получает или задает список департаментов, связанных с факультетом.
    /// </summary>
    public List<Department> Departments { get; set; } = [];
}