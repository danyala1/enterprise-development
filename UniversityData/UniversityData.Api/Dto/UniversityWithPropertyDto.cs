namespace UniversityData.Api.Dto;
/// <summary>
/// Представляет информацию о университете с заданной собственностью.
/// </summary>
public class UniversityWithPropertyDto
{
    /// <summary>
    /// Идентификатор университета.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название университета.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Номер университета.
    /// </summary>
    public required string Number { get; set; }

    /// <summary>
    /// Идентификатор ректора университета.
    /// </summary>
    public int RectorId { get; set; }

    /// <summary>
    /// Информация о строительной собственности.
    /// </summary>
    public required string ConstructionProperty { get; set; }

    /// <summary>
    /// Информация о собственности университета.
    /// </summary>
    public required string UniversityProperty { get; set; }

    /// <summary>
    /// Количество групп в университете.
    /// </summary>
    public int CountGroups { get; set; }
}
