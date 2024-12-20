using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

public class Specialty
{
    [Key]
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public int GroupCount { get; set; }
}