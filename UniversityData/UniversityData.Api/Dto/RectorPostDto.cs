﻿namespace UniversityData.Api.Dto;
/// <summary>
/// Информация о ректоре
/// </summary>
public class RectorPostDto
{
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
}