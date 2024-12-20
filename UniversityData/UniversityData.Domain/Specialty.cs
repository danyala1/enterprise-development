namespace UniversityData.Domain
{
    public class Specialty
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public int GroupCount { get; set; }
    }
}