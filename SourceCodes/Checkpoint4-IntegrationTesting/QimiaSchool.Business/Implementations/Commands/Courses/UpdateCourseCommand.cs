using MediatR;
using QimiaSchool.Business.Implementations.Commands.Courses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Commands.Courses;
public class UpdateCourseCommand : IRequest<int>
{
    public int Id { get; set; }
    public UpdateCourseDto UpdateCourseDto { get; set; }
    public UpdateCourseCommand(int id, UpdateCourseDto updateCourseDto)
    {
        Id = id;
        UpdateCourseDto = updateCourseDto;
    }
}
