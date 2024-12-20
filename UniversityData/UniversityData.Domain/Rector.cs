namespace UniversityData.Domain
{
    public class Rector
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Degree { get; set; }
        public required string Title { get; set; }
        public required string Position { get; set; }
    }
}