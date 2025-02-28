using QimiaSchool.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Events.Enrollments;
internal class EnrollmentCreatedEvent
{
    public int Id { get; init; }
    public int StudentId { get; init; }
    public int CourseId { get; init; }

    public Grade Grade { get; init; }
}
