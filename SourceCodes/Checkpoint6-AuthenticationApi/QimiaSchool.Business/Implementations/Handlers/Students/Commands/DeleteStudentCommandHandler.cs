using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Commands.Students;
using QimiaSchool.Business.Implementations.Events.Students;
using QimiaSchool.DataAccess.Entities;
using QimiaSchool.DataAccess.MessageBroker.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Handlers.Students.Commands;
public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, int>
{
    private readonly IStudentManager _studentManager;
    private readonly IEventBus _eventBus;

    public DeleteStudentCommandHandler(IStudentManager studentManager, IEventBus eventBus)
    {
        _studentManager = studentManager;
        _eventBus = eventBus;
    }

    public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {

        await _studentManager.DeleteStudentAsync(request.Id, cancellationToken);

        var studentDeleteEvent = new StudentDeleteEvent
        {
            ID = request.Id
        };
        await _eventBus.PublishAsync(studentDeleteEvent);

        return request.Id;
    }
}
