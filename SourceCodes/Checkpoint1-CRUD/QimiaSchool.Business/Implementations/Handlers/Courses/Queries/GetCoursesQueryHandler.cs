using AutoMapper;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Queries.Enrollments.Dtos;
using QimiaSchool.Business.Implementations.Queries.Enrollments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using QimiaSchool.Business.Implementations.Queries.Courses;
using QimiaSchool.Business.Implementations.Queries.Courses.Dtos;

namespace QimiaSchool.Business.Implementations.Handlers.Courses.Queries;
public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, List<CourseDto>>
{

    private readonly ICourseManager _courseManager;
    private readonly IMapper _mapper;

    public GetCoursesQueryHandler(
        ICourseManager courseManager,
        IMapper mapper)
    {
        _courseManager = courseManager;
        _mapper = mapper;
    }

    public async Task<List<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await _courseManager.GetCoursesAsync(cancellationToken);

        return _mapper.Map<List<CourseDto>>(courses);
    }
}
