namespace UniversityData.Domain;
/// <summary>
/// Специальность
/// </summary>
public class Specialty
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
    /// <summary>
    /// Ссылка на обратную связь
    /// </summary>
    public SpecialtyTableNode? Node { get; set; }

}