namespace UniversityData.Domain;
/// <summary>
/// Информация о ректор
/// </summary>
public class Rector
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя ректора
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Фамилия ректора
    /// </summary>
    public required string Surname { get; set; }
    /// <summary>
    /// Отчество ректора
    /// </summary>
    public required string Patronymic { get; set; }
    /// <summary>
    /// Степень ректора
    /// </summary>
    public required string Degree { get; set; }
    /// <summary>
    /// Звание ректора
    /// </summary>
    public required string Title { get; set; }
    /// <summary>
    /// Должность ректора
    /// </summary>
    public required string Position { get; set; }
    /// <summary>
    /// Ссылка на обратную связь
    /// </summary>
    public University? University { get; set; }
}