using AutoMapper;
using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Events.Students;
using QimiaSchool.Business.Implementations.Queries.Students;
using QimiaSchool.Business.Implementations.Queries.Students.Dtos;
using QimiaSchool.DataAccess.MessageBroker.Abstractions;

namespace QimiaSchool.Business.Implementations.Handlers.Students.Queries;
public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDto>
{
    private readonly IStudentManager _studentManager;
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;

    public GetStudentQueryHandler(
        IStudentManager studentManager,
        IMapper mapper,
        IEventBus eventBus)
    {
        _studentManager = studentManager;
        _mapper = mapper;
        _eventBus = eventBus;
    }

    public async Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentManager.GetStudentByIdAsync(request.Id, cancellationToken);

        var studentGetByIdEvent = new StudentGetByIdEvent
        {
            StudentId = student.ID,
            // Set other properties of the event as needed
        };
        await _eventBus.PublishAsync(studentGetByIdEvent);

        return _mapper.Map<StudentDto>(student);
    }
}
