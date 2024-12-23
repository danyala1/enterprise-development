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
    /// Шифр специальности.
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
    /// Список связей между специальностью и департаментами.
    /// Используется для реализации связи многие-ко-многим.
    /// </summary>
    public List<DepartmentSpecialty> DepartmentSpecialties { get; set; } = new();
}
