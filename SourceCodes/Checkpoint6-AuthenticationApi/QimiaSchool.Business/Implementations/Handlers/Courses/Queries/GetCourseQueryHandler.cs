using AutoMapper;
using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Events.Courses;
using QimiaSchool.Business.Implementations.Queries.Courses;
using QimiaSchool.Business.Implementations.Queries.Courses.Dtos;
using QimiaSchool.DataAccess.Entities;
using QimiaSchool.DataAccess.MessageBroker.Abstractions;

namespace QimiaSchool.Business.Implementations.Handlers.Courses.Queries;
public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, CourseDto>
{
    private readonly ICourseManager _courseManager;
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;

    public GetCourseQueryHandler(
        ICourseManager courseManager,
        IMapper mapper,
        IEventBus eventBus)
    {
        _courseManager = courseManager;
        _mapper = mapper;
        _eventBus = eventBus;
    }

    public async Task<CourseDto> Handle(GetCourseQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseManager.GetCourseByIdAsync(request.Id, cancellationToken);

        var courseGetByIdEvent = new CourseGetByIdEvent
        {
            CourseId = course.ID,
            // Set other properties of the event as needed
        };
        await _eventBus.PublishAsync(courseGetByIdEvent);

        return _mapper.Map<CourseDto>(course);
    }
}
