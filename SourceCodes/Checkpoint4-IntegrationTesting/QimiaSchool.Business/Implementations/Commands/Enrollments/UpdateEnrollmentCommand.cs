
using MediatR;
using QimiaSchool.Business.Implementations.Commands.Enrollments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Commands.Enrollments;
public class UpdateEnrollmentCommand : IRequest<int>
{
    public int Id { get; set; }
    public UpdateEnrollmentDto UpdateEnrollmentDto { get; set; }
    public UpdateEnrollmentCommand(int id, UpdateEnrollmentDto updateEnrollmentDto)
    {
        Id = id;
        UpdateEnrollmentDto = updateEnrollmentDto;
    }
}
