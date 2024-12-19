namespace UniversityData.Api.Dto;
/// <summary>
/// Специальность
/// </summary>
public class SpecialtyPostDto
{
    /// <summary>
    /// Название специальности
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Код-шифр специальности 
    /// </summary>
    public required string Code { get; set; }
}