using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Commands.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Handlers.Courses.Commands;
public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, int>
{
    private readonly ICourseManager _courseManager;

    public DeleteCourseCommandHandler(ICourseManager courseManager)
    {
        _courseManager = courseManager;
    }

    public async Task<int> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        await _courseManager.DeleteCourseAsync(request.Id, cancellationToken);

        return request.Id;
    }
}
