using System.ComponentModel.DataAnnotations;

namespace UniversityData.Domain;

public class University
{
    [Key]
    public int RegistrationNumber { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required Rector Rector { get; set; }
    public required string InstitutionOwnership { get; set; } 
    public required string BuildingOwnership { get; set; }
    public List<Faculty> Faculties { get; set; } = [];
}