using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Commands.Courses;
public class DeleteCourseCommand : IRequest<int>
{
    public int Id { get; set; }
    public DeleteCourseCommand(int id)
    {
        Id = id;
    }
}
