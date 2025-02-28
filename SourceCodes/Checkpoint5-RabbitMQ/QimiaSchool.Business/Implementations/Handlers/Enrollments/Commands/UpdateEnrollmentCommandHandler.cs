using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Commands.Enrollments;
using QimiaSchool.Business.Implementations.Events.Enrollments;
using QimiaSchool.Business.Implementations.Events.Students;
using QimiaSchool.DataAccess.Entities;
using QimiaSchool.DataAccess.MessageBroker.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Handlers.Enrollments.Commands;
public class UpdateEnrollmentCommandHandler : IRequestHandler<UpdateEnrollmentCommand, int>
{
    private readonly IEnrollmentManager _enrollmentManager;
    private readonly IEventBus _eventBus;

    public UpdateEnrollmentCommandHandler(IEnrollmentManager enrollmentManager, IEventBus eventBus)
    {
        _enrollmentManager = enrollmentManager;
        _eventBus = eventBus;
    }

    public async Task<int> Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var enrollment = new Enrollment
        {
            CourseID = request.UpdateEnrollmentDto.CourseID,
            StudentID = request.UpdateEnrollmentDto.StudentID,
        };

        await _enrollmentManager.UpdateEnrollmentAsync(request.Id, enrollment, cancellationToken);

        var enrollmentUpdateEvent = new EnrollmentUpdateEvent
        {
            ID = enrollment.ID,
            StudentID = enrollment.StudentID,
            CourseID = enrollment.CourseID,
            Grade = enrollment.Grade??Grade.A,
            // Set other properties of the event as needed
        };
        await _eventBus.PublishAsync(enrollmentUpdateEvent);

        return enrollment.ID;
    }
}
