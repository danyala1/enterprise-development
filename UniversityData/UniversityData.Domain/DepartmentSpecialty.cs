using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

/// <summary>
/// Представляет связь между департаментом и специальностью.
/// Используется для реализации отношения многие-ко-многим.
/// </summary>
public class DepartmentSpecialty
{
    /// <summary>
    /// Уникальный идентификатор связи между департаментом и специальностью.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор департамента.
    /// </summary>
    public int DepartmentId { get; set; }

    /// <summary>
    /// Департамент, связанный с данной специальностью.
    /// </summary>
    public Department? Department { get; set; }

    /// <summary>
    /// Идентификатор специальности.
    /// </summary>
    public int SpecialtyId { get; set; }

    /// <summary>
    /// Специальность, связанная с данным департаментом.
    /// </summary>
    public Specialty? Specialty { get; set; }
}
