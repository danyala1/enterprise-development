namespace UniversityData.Api.Dto;

/// <summary>
/// Представляет данные университета.
/// </summary>
public class UniversityDto
{
    /// <summary>
    /// Получает или задает регистрационный номер университета.
    /// </summary>
    public int RegistrationNumber { get; set; }

    /// <summary>
    /// Получает или задает название университета.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Получает или задает адрес университета.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Получает или задает тип собственности университета.
    /// </summary>
    public required string InstitutionOwnership { get; set; }

    /// <summary>
    /// Получает или задает тип собственности здания университета.
    /// </summary>
    public required string BuildingOwnership { get; set; }

    /// <summary>
    /// Получает или задает ректора университета.
    /// </summary>
    public RectorDto? Rector { get; set; }

    /// <summary>
    /// Получает или задает список факультетов, принадлежащих университету.
    /// </summary>
    public List<FacultyDto> Faculties { get; set; } = new List<FacultyDto>();
}

