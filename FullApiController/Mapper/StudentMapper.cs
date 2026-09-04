using FullApiController.Models.Domain;
using FullApiController.Models.DTO;

namespace FullApiController.Mapper
{
    public static class StudentMapper
    {
        public static AddStudentDto MapToAddStudentDTO(this Student student)
        {
            return new AddStudentDto
            {
                StudentNumber = student.StudentNumber,
                LastName = student.LastName,
                FirstName = student.FirstName,
                Gender = student.Gender,
                Address = student.Address,
                Birthday = student.Birthday,
                BirthPlace = student.BirthPlace
            };
        }

        public static Student MapToStudent(this AddStudentDto addStudentDto)
        {
            return new Student
            {
                LastName = addStudentDto.LastName,
                FirstName = addStudentDto.FirstName,
                Gender = addStudentDto.Gender,
                Address = addStudentDto.Address,
                Birthday = addStudentDto.Birthday,
                BirthPlace = addStudentDto.BirthPlace
            };
        }
    }
}
