namespace UniversityData.Api.Dto;

/// <summary>
/// Представляет данные факультета.
/// </summary>
public class FacultyDto
{
    /// <summary>
    /// Получает или задает название факультета.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Получает или задает идентификатор университета, к которому принадлежит факультет.
    /// </summary>
    public int UniversityId { get; set; }
}

