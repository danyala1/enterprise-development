using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

/// <summary>
/// Представляет специальность в университете.
/// </summary>
public class Specialty
{
    /// <summary>
    /// Уникальный идентификатор специальности.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Код специальности.
    /// Это обязательное поле.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Название специальности.
    /// Это обязательное поле.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Количество групп, связанных с данной специальностью.
    /// </summary>
    public int GroupCount { get; set; }

    /// <summary>
    /// Идентификатор университета, к которому принадлежит специальность.
    /// Может быть <c>null</c>, если специальность не привязана к университету.
    /// </summary>
    public int? UniversityId { get; set; }

    /// <summary>
    /// Идентификатор департамента, к которому принадлежит специальность.
    /// Может быть <c>null</c>, если специальность не привязана к университету.
    /// </summary>
    public int? DepartmentId { get; set; }

    /// <summary>
    /// Список связей между специальностью и департаментами.
    /// Используется для реализации отношения многие-ко-многим.
    /// </summary>
    public List<Department> Department{ get; set; } = [];
}