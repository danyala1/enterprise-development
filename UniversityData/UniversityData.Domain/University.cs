namespace UniversityData.Domain;
/// <summary>
/// Информация об университете
/// </summary>
public class University
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
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
    /// Сведения о ректоре 
    /// </summary>
    public Rector? RectorData { get; set; }
    /// <summary>
    /// Собственность учреждения
    /// </summary>
    public required string UniversityProperty { get; set; }
    /// <summary>
    /// Собственность здания университета
    /// </summary>
    public required string ConstructionProperty { get; set; }
    /// <summary>
    /// Факультеты университета
    /// </summary>
    public List<Faculty> FacultiesData { get; set; } = [];
    /// <summary>
    /// Кафедры университета
    /// </summary>
    public List<Department> DepartmentsData { get; set; } = [];
    /// <summary>
    /// Таблица связи специальность-количество групп
    /// </summary>
    public List<SpecialtyTableNode> SpecialtyTable { get; set; } = [];
}