namespace UniversityData.Api.Dto;
/// <summary>
/// Специальность
/// </summary>
public class SpecialtyGetDto
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название специальности
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Код-шифр специальности 
    /// </summary>
    public required string Code { get; set; }
}