namespace UniversityData.Api.Dto;

/// <summary>
/// Представляет данные департамента.
/// </summary>
public class DepartmentDto
{
    /// <summary>
    /// Название департамента.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Идентификатор факультета, к которому принадлежит департамент.
    /// </summary>
    public int FacultyId { get; set; }
}

