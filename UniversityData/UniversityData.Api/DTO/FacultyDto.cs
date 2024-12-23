namespace UniversityData.Api.Dto;

/// <summary>
/// Представляет данные факультета.
/// </summary>
public class FacultyDto
{
    /// <summary>
    /// Название факультета.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Идентификатор университета, к которому принадлежит факультет.
    /// </summary>
    public int UniversityId { get; set; }
}