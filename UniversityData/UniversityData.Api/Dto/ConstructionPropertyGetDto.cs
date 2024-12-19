namespace UniversityData.Api.Dto;
/// <summary>
/// Собственность зданий университета
/// </summary>
public class ConstructionPropertyGetDto
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название собственности зданий университета
    /// </summary>
    public required string NameConstructionProperty { get; set; }
}