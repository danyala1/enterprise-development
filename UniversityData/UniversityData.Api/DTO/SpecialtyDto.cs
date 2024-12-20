namespace UniversityData.Api.Dto;

/// <summary>
/// Представляет данные специальности.
/// </summary>
public class SpecialtyDto
{
    /// <summary>
    /// Получает или задает код специальности.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Получает или задает название специальности.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Получает или задает количество групп, связанных с данной специальностью.
    /// </summary>
    public int GroupCount { get; set; }

    /// <summary>
    /// Получает или задает идентификатор департамента, к которому принадлежит специальность.
    /// </summary>
    public int DepartmentId { get; set; }
}

