using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Commands.Courses;
using QimiaSchool.Business.Implementations.Commands.Enrollments;
using QimiaSchool.Business.Implementations.Events.Courses;
using QimiaSchool.Business.Implementations.Events.Students;
using QimiaSchool.DataAccess.Entities;
using QimiaSchool.DataAccess.MessageBroker.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Handlers.Courses.Commands;
internal class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, int>
{
    private readonly ICourseManager _courseManager;
    private readonly IEventBus _eventBus;

    public UpdateCourseCommandHandler(ICourseManager courseManager, IEventBus eventBus)
    {
        _courseManager = courseManager;
        _eventBus = eventBus;
    }

    public async Task<int> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course
        {
            Title = request.UpdateCourseDto.Title,
            Credits = request.UpdateCourseDto.Credits,
        };

        await _courseManager.UpdateCourseAsync(request.Id, course, cancellationToken);

        var courseUpdateEvent = new CourseUpdateEvent
        {
            ID = course.ID,
            Title = course.Title,
            Credits = course.Credits,
            // Set other properties of the event as needed
        };
        await _eventBus.PublishAsync(courseUpdateEvent);

        return course.ID;
    }
}
