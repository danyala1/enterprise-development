﻿using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityData.Domain;
/// <summary>
/// Специальность
/// </summary>
[Table("specialty")]
public class Specialty
{
    /// <summary>
    /// ID
    /// </summary>
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Название специальности
    /// </summary>
    [Column("name")]
    public required string Name { get; set; }
    /// <summary>
    /// Код-шифр специальности 
    /// </summary>
    [Column("code")]
    public required string Code { get; set; }
    /// <summary>
    /// Записи в таблице связи
    /// </summary>
    public List<SpecialtyTableNode>? SpecialtyTableNodes { get; set; }

    public int CountGroups { get; set; }

}