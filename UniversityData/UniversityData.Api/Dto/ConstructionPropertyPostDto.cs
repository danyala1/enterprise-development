namespace UniversityData.Api.Dto;
/// <summary>
/// Собственность зданий университета
/// </summary>
public class ConstructionPropertyPostDto
{
    /// <summary>
    /// Название собственности зданий университета
    /// </summary>
    public required string NameConstructionProperty { get; set; }
}