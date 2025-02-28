using MediatR;
using QimiaSchool.Business.Implementations.Queries.Students.Dtos;

namespace QimiaSchool.Business.Implementations.Queries.Students;
public class GetStudentQuery : IRequest<StudentDto>
{
    public int Id { get; }

    public GetStudentQuery(int id)
    {
        Id = id;
    }
}
