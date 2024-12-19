namespace UniversityData.Api.Dto;
/// <summary>
/// Собственность университета
/// </summary>
public class UniversityPropertyPostDto
{
    /// <summary>
    /// Название собственности университета
    /// </summary>
    public required string NameUniversityProperty { get; set; }
}