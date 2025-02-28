using MediatR;
using QimiaSchool.Business.Implementations.Commands.Courses.Dtos;

namespace QimiaSchool.Business.Implementations.Commands.Courses;

public class CreateCourseCommand : IRequest<int>
{
    public CreateCourseDto Course { get; set; }

    public CreateCourseCommand(
        CreateCourseDto course)
    {
        Course = course;
    }
}

