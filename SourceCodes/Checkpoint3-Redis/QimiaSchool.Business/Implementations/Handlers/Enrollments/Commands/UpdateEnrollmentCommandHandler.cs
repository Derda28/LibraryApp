using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Commands.Enrollments;
using QimiaSchool.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Handlers.Enrollments.Commands;
public class UpdateEnrollmentCommandHandler : IRequestHandler<UpdateEnrollmentCommand, int>
{
    private readonly IEnrollmentManager _enrollmentManager;

    public UpdateEnrollmentCommandHandler(IEnrollmentManager enrollmentManager)
    {
        _enrollmentManager = enrollmentManager;
    }

    public async Task<int> Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var enrollment = new Enrollment
        {
            CourseID = request.UpdateEnrollmentDto.CourseID,
            StudentID = request.UpdateEnrollmentDto.StudentID,
        };

        await _enrollmentManager.UpdateEnrollmentAsync(request.Id, enrollment, cancellationToken);

        return enrollment.ID;
    }
}
