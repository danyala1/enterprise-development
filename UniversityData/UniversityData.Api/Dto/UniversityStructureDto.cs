namespace UniversityData.Api.Dto;
    /// <summary>
    /// Представляет структуру университета, включая факультеты, кафедры и специальности.
    /// </summary>
    public class UniversityStructureDto
    {
        /// <summary>
        /// Список кафедр университета.
        /// </summary>
        public IEnumerable<DepartmentGetDto>? Departments { get; set; }

        /// <summary>
        /// Список факультетов университета.
        /// </summary>
        public IEnumerable<FacultyGetDto>? Faculties { get; set; }

        /// <summary>
        /// Список специальностей университета.
        /// </summary>
        public IEnumerable<SpecialtyTableNodeGetDto>? Specialties { get; set; }
    }