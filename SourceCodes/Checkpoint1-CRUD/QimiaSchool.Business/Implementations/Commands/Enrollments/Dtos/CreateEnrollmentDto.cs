using QimiaSchool.DataAccess.Entities;

namespace QimiaSchool.Business.Implementations.Commands.Enrollments.Dtos;

public class CreateEnrollmentDto
{
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public Grade Grade { get; set;}

}
