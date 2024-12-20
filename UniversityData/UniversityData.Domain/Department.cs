namespace UniversityData.Domain
{
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Specialty> Specialties { get; set; } = new List<Specialty>();
    }
}