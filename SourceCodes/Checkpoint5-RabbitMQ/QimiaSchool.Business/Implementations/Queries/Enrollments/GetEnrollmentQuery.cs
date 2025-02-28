using MediatR;
using QimiaSchool.Business.Implementations.Queries.Enrollments.Dtos;

namespace QimiaSchool.Business.Implementations.Queries.Enrollments;
public class GetEnrollmentQuery : IRequest<EnrollmentDto>
{
    public int Id { get; }

    public GetEnrollmentQuery(int id)
    {
        Id = id;
    }
}
