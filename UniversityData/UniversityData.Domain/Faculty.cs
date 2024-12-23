using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

public class Faculty
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Department> Departments { get; set; } = [];
}