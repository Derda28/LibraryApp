using AutoMapper;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Queries.Students.Dtos;
using QimiaSchool.Business.Implementations.Queries.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace QimiaSchool.Business.Implementations.Handlers.Students.Queries;
public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<StudentDto>>
{
    private readonly IStudentManager _studentManager;
    private readonly IMapper _mapper;

    public GetStudentsQueryHandler(
        IStudentManager studentManager,
        IMapper mapper)
    {
        _studentManager = studentManager;
        _mapper = mapper;
    }

    public async Task<List<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentManager.GetStudentsAsync(cancellationToken);

        return _mapper.Map<List<StudentDto>>(students);
    }
}
