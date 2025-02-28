using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Commands.Enrollments;
public class DeleteEnrollmentCommand : IRequest<int>
{
    public int Id { get; set; }
    public DeleteEnrollmentCommand(int id) 
    {
        Id = id;
    }
}
