using MediatR;
using QimiaSchool.Business.Implementations.Queries.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Queries.Students;
public class GetStudentsQuery : IRequest<List<StudentDto>>
{
}
