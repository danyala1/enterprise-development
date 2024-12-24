using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

/// <summary>
/// Представляет факультет университета.
/// </summary>
public class Faculty
{
    /// <summary>
    /// Уникальный идентификатор факультета.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Название факультета.
    /// Это обязательное поле.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Идентификатор университета, к которому принадлежит факультет.
    /// </summary>
    public int UniversityId { get; set; }

    /// <summary>
    /// Список департаментов, связанных с факультетом.
    /// </summary>
    public List<Department> Departments { get; set; } = [];
}