namespace UniversityData.Api.Dto;

/// <summary>
/// Представляет данные департамента.
/// </summary>
public class DepartmentDto
{
    /// <summary>
    /// Получает или задает название департамента.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Получает или задает идентификатор факультета, к которому принадлежит департамент.
    /// </summary>
    public int FacultyId { get; set; }
}

