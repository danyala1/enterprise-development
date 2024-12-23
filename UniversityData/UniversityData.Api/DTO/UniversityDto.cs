namespace UniversityData.Api.Dto;

/// <summary>
/// Представляет данные университета.
/// </summary>
public class UniversityDto
{
    /// <summary>
    /// Регистрационный номер университета.
    /// </summary>
    public int RegistrationNumber { get; set; }

    /// <summary>
    /// Название университета.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Адрес университета.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Тип собственности университета.
    /// </summary>
    public required string InstitutionOwnership { get; set; }

    /// <summary>
    /// Тип собственности здания университета.
    /// </summary>
    public required string BuildingOwnership { get; set; }

    /// <summary>
    /// Ректора университета.
    /// </summary>
    public RectorDto? Rector { get; set; }

    /// <summary>
    /// Список факультетов, принадлежащих университету.
    /// </summary>
    public List<FacultyDto> Faculties { get; set; } = new List<FacultyDto>();
}

