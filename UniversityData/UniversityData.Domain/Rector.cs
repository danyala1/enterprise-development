using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

public class Rector
{
    [Key]
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Degree { get; set; }
    public required string Title { get; set; }
    public required string Position { get; set; }
    public List<University> University { get; set; } = [];
}