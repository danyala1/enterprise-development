namespace UniversityData.Domain
{
    public class Specialty
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public int GroupCount { get; set; }
    }
}