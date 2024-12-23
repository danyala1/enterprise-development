namespace UniversityData.Api.Dto;

/// <summary>
/// Представляет данные ректора.
/// </summary>
public class RectorDto
{
    /// <summary>
    /// Полное имя ректора.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Степень ректора.
    /// </summary>
    public required string Degree { get; set; }

    /// <summary>
    /// Титул ректора.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Должность ректора.
    /// </summary>
    public required string Position { get; set; }

    /// <summary>
    /// Идентификатор университета, к которому принадлежит ректор.
    /// </summary>
    public int UniversityId { get; set; }
}