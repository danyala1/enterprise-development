using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

/// <summary>
/// Представляет департамент университета.
/// </summary>
public class Department
{
    /// <summary>
    /// Уникальный идентификатор департамента.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Название департамента.
    /// Это обязательное поле.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Идентификатор факультета, к которому принадлежит департамент.
    /// </summary>
    public int FacultyId { get; set; }

    /// <summary>
    /// Список специальностей, связанных с департаментом.
    /// </summary>
    public List<Specialty> Specialties { get; set; } = [];

}
