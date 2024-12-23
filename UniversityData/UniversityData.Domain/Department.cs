using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

public class Department
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Specialty> Specialties { get; set; } = [];
}