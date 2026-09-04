using System.ComponentModel.DataAnnotations;

namespace FullApiController.Models.DTO
{
    public class AddStudentDto
    {
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Student number must be in the format YYYY-####.")]
        public string StudentNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateOnly Birthday { get; set; }
        public string BirthPlace { get; set; }

    }
}
