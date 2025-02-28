using MediatR;
using QimiaSchool.Business.Implementations.Queries.Enrollments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Queries.Enrollments;
public class GetEnrollmentsQuery : IRequest<List<EnrollmentDto>>
{
}
