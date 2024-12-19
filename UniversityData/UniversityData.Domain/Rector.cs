using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityData.Domain;
/// <summary>
/// Информация о ректор
/// </summary>
[Table("rector")]
public class Rector
{
    /// <summary>
    /// ID
    /// </summary>
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Имя ректора
    /// </summary>
    [Column("name")]
    public required string Name { get; set; }
    /// <summary>
    /// Фамилия ректора
    /// </summary>
    [Column("surname")]
    public required string Surname { get; set; }
    /// <summary>
    /// Отчество ректора
    /// </summary>
    [Column("patronymic")]
    public required string Patronymic { get; set; }
    /// <summary>
    /// Степень ректора
    /// </summary>
    [Column("degree")]
    public required string Degree { get; set; }
    /// <summary>
    /// Звание ректора
    /// </summary>
    [Column("title")]
    public required string Title { get; set; }
    /// <summary>
    /// Должность ректора
    /// </summary>
    [Column("position")]
    public required string Position { get; set; }
}