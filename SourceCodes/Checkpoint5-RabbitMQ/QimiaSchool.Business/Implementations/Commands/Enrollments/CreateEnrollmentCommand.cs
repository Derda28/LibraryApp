using MediatR;
using QimiaSchool.Business.Implementations.Commands.Enrollments.Dtos;

namespace QimiaSchool.Business.Implementations.Commands.Enrollments;

public class CreateEnrollmentCommand : IRequest<int>
{
    public CreateEnrollmentDto Enrollment { get; set; }

    public CreateEnrollmentCommand(
        CreateEnrollmentDto enrollment)
    {
        Enrollment = enrollment;
    }
}

