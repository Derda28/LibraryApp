using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Commands.Enrollments;
using QimiaSchool.Business.Implementations.Commands.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Handlers.Enrollments.Commands;
public class DeleteEnrollmentCommandHandler : IRequestHandler<DeleteEnrollmentCommand, int>
{
    private readonly IEnrollmentManager _enrollmentManager;

    public DeleteEnrollmentCommandHandler(IEnrollmentManager enrollmentManager)
    {
        _enrollmentManager = enrollmentManager;
    }

    public async Task<int> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
    {

        await _enrollmentManager.DeleteEnrollmentAsync(request.Id, cancellationToken);

        return request.Id;
    }

}
