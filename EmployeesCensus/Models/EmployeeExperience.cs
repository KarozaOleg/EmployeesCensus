using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesCensus.Models
{
    public class EmployeeExperience
    {
        [ForeignKey("Employee")]
        public int EmployeeExperienceId { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        public Employee Employee { get; set; }
    }
}