using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

/// <summary>
/// Представляет университет.
/// </summary>
public class University
{
    /// <summary>
    /// Регистрационный номер университета.
    /// Это уникальный идентификатор для каждого университета.
    /// </summary>
    [Key]
    public int RegistrationNumber { get; set; }

    /// <summary>
    /// Название университета.
    /// Это обязательное поле.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Адрес университета.
    /// Это обязательное поле.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Идентификатор ректора университета.
    /// Может быть <c>null</c>, если ректор не назначен.
    /// </summary>
    public int? RectorId { get; set; }

    /// <summary>
    /// Тип собственности университета.
    /// Это обязательное поле.
    /// </summary>
    public required string InstitutionOwnership { get; set; }

    /// <summary>
    /// Тип собственности здания университета.
    /// Это обязательное поле.
    /// </summary>
    public required string BuildingOwnership { get; set; }

    /// <summary>
    /// Список факультетов, связанных с университетом.
    /// </summary>
    public List<Faculty> Faculties { get; set; } = [];
}
