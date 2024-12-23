using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

/// <summary>
/// Представляет департамент университета.
/// </summary>
public class Department
{
    /// <summary>
    /// Идентификатор департамента.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Название департамента.
    /// Это обязательное поле.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Список специальностей, связанных с департаментом.
    /// </summary>
    public List<Specialty> Specialties { get; set; } = [];

    /// <summary>
    /// Список связей между департаментом и специальностями.
    /// Используется для реализации связи многие-ко-многим.
    /// </summary>
    public List<DepartmentSpecialty> DepartmentSpecialties { get; set; } = [];
}
