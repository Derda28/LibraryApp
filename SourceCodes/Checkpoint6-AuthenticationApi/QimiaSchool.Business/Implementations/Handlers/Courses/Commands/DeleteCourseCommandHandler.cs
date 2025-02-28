using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Commands.Courses;
using QimiaSchool.Business.Implementations.Events.Courses;
using QimiaSchool.DataAccess.MessageBroker.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Handlers.Courses.Commands;
public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, int>
{
    private readonly ICourseManager _courseManager;
    private readonly IEventBus _eventBus;

    public DeleteCourseCommandHandler(ICourseManager courseManager, IEventBus eventBus)
    {
        _courseManager = courseManager;
        _eventBus = eventBus;
    }

    public async Task<int> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        await _courseManager.DeleteCourseAsync(request.Id, cancellationToken);

        var courseDeleteEvent = new CourseDeleteEvent
        {
            ID = request.Id,
        };
        await _eventBus.PublishAsync(courseDeleteEvent);

        return request.Id;
    }
}
