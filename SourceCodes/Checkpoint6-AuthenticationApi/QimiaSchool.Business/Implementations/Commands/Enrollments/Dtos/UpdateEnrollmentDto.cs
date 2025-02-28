using QimiaSchool.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Commands.Enrollments.Dtos;
public class UpdateEnrollmentDto
{
    public int CourseID { get; set; }
    public int StudentID { get; set; }
}
