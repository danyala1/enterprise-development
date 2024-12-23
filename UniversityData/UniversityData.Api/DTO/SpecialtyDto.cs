namespace UniversityData.Api.Dto;

/// <summary>
/// Представляет данные специальности.
/// </summary>
public class SpecialtyDto
{
    /// <summary>
    /// Код специальности.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Название специальности.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Количество групп, связанных с данной специальностью.
    /// </summary>
    public int GroupCount { get; set; }

    /// <summary>
    /// Идентификатор департамента, к которому принадлежит специальность.
    /// </summary>
    public int DepartmentId { get; set; }
}