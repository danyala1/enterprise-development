﻿namespace UniversityData.Api.Dto;
/// <summary>
/// Информация об университете
/// </summary>
public class UniversityPostDto
{
    /// <summary>
    /// Регистрационный номер
    /// </summary>
    public required string Number { get; set; }
    /// <summary>
    /// Название университета
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Адрес университета
    /// </summary>
    public required string Address { get; set; }
    /// <summary>
    /// ID ректора
    /// </summary>
    public int RectorId { get; set; }
    /// <summary>
    /// ID собственности учреждения
    /// </summary>
    public int UniversityPropertyId { get; set; }
    /// <summary>
    /// ID собственности зданий университета
    /// </summary>
    public int ConstructionPropertyId { get; set; }
}