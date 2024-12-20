namespace UniversityData.Api.Dto;

/// <summary>
/// Представляет данные ректора.
/// </summary>
public class RectorDto
{
    /// <summary>
    /// Получает или задает полное имя ректора.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Получает или задает степень ректора.
    /// </summary>
    public required string Degree { get; set; }

    /// <summary>
    /// Получает или задает титул ректора.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Получает или задает должность ректора.
    /// </summary>
    public required string Position { get; set; }

    /// <summary>
    /// Получает или задает идентификатор университета, к которому принадлежит ректор.
    /// </summary>
    public int UniversityId { get; set; }
}

