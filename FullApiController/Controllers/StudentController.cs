using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FullApiController.Models.Domain;
using FullApiController.Models.DTO;
using FullApiController.Mapper;

namespace FullApiController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Student> students = new List<Student>();

        [HttpGet("{id:int}")]

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudent([FromRoute] int id)
        {
            var student = students.Where(m => m.StudentId == id).FirstOrDefault();
            if (student != null)
            {
                return Ok(student);
            }
            return BadRequest();

        }
        [HttpPost]
        public IActionResult AddStudent([FromBody] AddStudentDto student)
        {
            students.Add(student.MapToStudent());
            return Ok(student);
        }

        [HttpPut("{id:int}")]
        public IActionResult EditStudent([FromRoute] int id, [FromBody] EditStudentDto student)
        {
            var StudentForEdit = students.Where(m => m.StudentId == id).FirstOrDefault();
            if (StudentForEdit != null)
            {
                StudentForEdit.Address = student.Address;
                StudentForEdit.Birthday = student.Birthday;
                StudentForEdit.BirthPlace = student.BirthPlace;
                return Ok(StudentForEdit);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            return Ok();
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string? lastname, [FromQuery] string? firstname)
        {
            var results = students.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(lastname))
            {
                results = results.Where(s => !string.IsNullOrWhiteSpace(s.LastName) && s.LastName.Contains(lastname, System.StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(firstname))
            {
                results = results.Where(s => !string.IsNullOrWhiteSpace(s.FirstName) && s.FirstName.Contains(firstname, System.StringComparison.OrdinalIgnoreCase));
            }

            return Ok(results.ToList());
        }
    }
}
