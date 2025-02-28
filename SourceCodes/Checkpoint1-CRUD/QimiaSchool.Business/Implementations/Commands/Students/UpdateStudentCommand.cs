using MediatR;
using QimiaSchool.Business.Implementations.Commands.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Commands.Students;
public class UpdateStudentCommand : IRequest<int>
{
    public int Id { get; set; }
    public UpdateStudentDto Student { get; set; }

    public UpdateStudentCommand(int id, UpdateStudentDto student)
    {
        Id = id;
        Student = student;
    }
}
