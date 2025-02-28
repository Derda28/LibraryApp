using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Commands.Courses;
using QimiaSchool.Business.Implementations.Commands.Enrollments;
using QimiaSchool.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Handlers.Courses.Commands;
internal class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, int>
{
    private readonly ICourseManager _courseManager;

    public UpdateCourseCommandHandler(ICourseManager courseManager)
    {
        _courseManager = courseManager;
    }

    public async Task<int> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course
        {
            Title = request.UpdateCourseDto.Title,
            Credits = request.UpdateCourseDto.Credits,
        };

        await _courseManager.UpdateCourseAsync(request.Id, course, cancellationToken);

        return course.ID;
    }
}
