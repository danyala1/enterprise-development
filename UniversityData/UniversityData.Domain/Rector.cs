using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

/// <summary>
/// Представляет ректора университета.
/// </summary>
public class Rector
{
    /// <summary>
    /// Уникальный идентификатор ректора.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Полное имя ректора.
    /// Это обязательное поле.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Ученую степень ректора.
    /// Это обязательное поле.
    /// </summary>
    public required string Degree { get; set; }

    /// <summary>
    /// Звание ректора.
    /// Это обязательное поле.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Должность ректора.
    /// Это обязательное поле.
    /// </summary>
    public required string Position { get; set; }

    /// <summary>
    /// Список университетов, связанных с ректором.
    /// </summary>
    public List<University> Universities { get; set; } = new();
}
