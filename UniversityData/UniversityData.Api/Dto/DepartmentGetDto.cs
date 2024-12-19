namespace UniversityData.Api.Dto;
/// <summary>
/// Информация о кафедре
/// </summary>
public class DepartmentGetDto
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название кафедры
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Контактный телефон заведущего кафедрой
    /// </summary>
    public required string SupervisorNumber { get; set; }
    /// <summary>
    /// ID университета
    /// </summary>
    public int UniversityId { get; set; }
}