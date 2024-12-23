using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

/// <summary>
/// Представляет департамент университета.
/// </summary>
public class Department
{
    /// <summary>
    /// Получает или задает уникальный идентификатор департамента.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Получает или задает название департамента.
    /// Это обязательное поле.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Получает или задает идентификатор факультета, к которому принадлежит департамент.
    /// </summary>
    public int FacultyId { get; set; }

    /// <summary>
    /// Получает или задает список специальностей, связанных с департаментом.
    /// </summary>
    public List<Specialty> Specialties { get; set; } = [];

    /// <summary>
    /// Получает или задает список связей между департаментом и специальностями.
    /// Используется для реализации отношения многие-ко-многим.
    /// </summary>
    public List<DepartmentSpecialty> DepartmentSpecialties { get; set; } = [];
}
