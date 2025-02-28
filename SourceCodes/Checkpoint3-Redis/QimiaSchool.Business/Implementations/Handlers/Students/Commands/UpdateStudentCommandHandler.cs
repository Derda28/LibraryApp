using MediatR;
using QimiaSchool.Business.Abstracts;
using QimiaSchool.Business.Implementations.Commands.Students;
using QimiaSchool.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Handlers.Students.Commands;
public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
{
    private readonly IStudentManager _studentManager;

    public UpdateStudentCommandHandler(IStudentManager studentManager)
    {
        _studentManager = studentManager;
    }

    public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            FirstMidName = request.Student.FirstMidName,
            LastName = request.Student.LastName,
        };

        await _studentManager.UpdateStudentAsync(request.Id, student, cancellationToken);

        return student.ID;
    }
}
