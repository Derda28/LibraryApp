using AutoMapper;
using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Events.Enrollments;
using QimiaSchool.Business.Implementations.Queries.Enrollments;
using QimiaSchool.Business.Implementations.Queries.Enrollments.Dtos;
using QimiaSchool.DataAccess.Entities;
using QimiaSchool.DataAccess.MessageBroker.Abstractions;

namespace QimiaSchool.Business.Implementations.Handlers.Enrollments.Queries;
public class GetEnrollmentQueryHandler : IRequestHandler<GetEnrollmentQuery, EnrollmentDto>
{
    private readonly IEnrollmentManager _enrollmentManager;
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;

    public GetEnrollmentQueryHandler(
        IEnrollmentManager enrollmentManager,
        IMapper mapper,
        IEventBus eventBus)
    {
        _enrollmentManager = enrollmentManager;
        _mapper = mapper;
        _eventBus = eventBus;
    }

    public async Task<EnrollmentDto> Handle(GetEnrollmentQuery request, CancellationToken cancellationToken)
    {
        var enrollment = await _enrollmentManager.GetEnrollmentByIdAsync(request.Id, cancellationToken);

        var enrollmentGetByIdEvent = new EnrollmentGetByIdEvent
        {
            EnrollmentId = enrollment.ID,
            // Set other properties of the event as needed
        };
        await _eventBus.PublishAsync(enrollmentGetByIdEvent);

        return _mapper.Map<EnrollmentDto>(enrollment);
    }
}
