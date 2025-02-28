using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Commands.Enrollments;
using QimiaSchool.Business.Implementations.Commands.Students;
using QimiaSchool.Business.Implementations.Events.Enrollments;
using QimiaSchool.Business.Implementations.Events.Students;
using QimiaSchool.DataAccess.MessageBroker.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Handlers.Enrollments.Commands;
public class DeleteEnrollmentCommandHandler : IRequestHandler<DeleteEnrollmentCommand, int>
{
    private readonly IEnrollmentManager _enrollmentManager;
    private readonly IEventBus _eventBus;

    public DeleteEnrollmentCommandHandler(IEnrollmentManager enrollmentManager, IEventBus eventBus)
    {
        _enrollmentManager = enrollmentManager;
        _eventBus = eventBus;
    }

    public async Task<int> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
    {

        await _enrollmentManager.DeleteEnrollmentAsync(request.Id, cancellationToken);

        var enrollmentDeleteEvent = new EnrollmentDeleteEvent
        {
            EnrollmentId = request.Id
        };
        await _eventBus.PublishAsync(enrollmentDeleteEvent);

        return request.Id;
    }

}
