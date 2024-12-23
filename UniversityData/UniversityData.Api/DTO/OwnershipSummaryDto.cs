namespace UniversityData.Api.Dto
{
    /// <summary>
    /// Представляет сводку по университетам по типу собственности.
    /// </summary>
    public class OwnershipSummaryDto
    {
        /// <summary>
        /// Тип собственности университета.
        /// </summary>
        public required string OwnershipType { get; set; }

        /// <summary>
        /// Количество факультетов.
        /// </summary>
        public int FacultyCount { get; set; }

        /// <summary>
        /// Количество департаментов.
        /// </summary>
        public int DepartmentCount { get; set; }

        /// <summary>
        /// Количество специальностей.
        /// </summary>
        public int SpecialtyCount { get; set; }
    }
}