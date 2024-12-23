using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

/// <summary>
/// Представляет специальность в университете.
/// </summary>
public class Specialty
{
    /// <summary>
    /// Получает или задает уникальный идентификатор специальности.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Получает или задает код специальности.
    /// Это обязательное поле.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Получает или задает название специальности.
    /// Это обязательное поле.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Получает или задает количество групп, связанных с данной специальностью.
    /// </summary>
    public int GroupCount { get; set; }

    /// <summary>
    /// Получает или задает идентификатор университета, к которому принадлежит специальность.
    /// Может быть <c>null</c>, если специальность не привязана к университету.
    /// </summary>
    public int? UniversityId { get; set; }

    /// <summary>
    /// Получает или задает список связей между специальностью и департаментами.
    /// Используется для реализации отношения многие-ко-многим.
    /// </summary>
    public List<DepartmentSpecialty> DepartmentSpecialties { get; set; } = [];
}