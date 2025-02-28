using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaSchool.Business.Implementations.Commands.Courses.Dtos;
public class UpdateCourseDto
{
    public string Title { get; set; } = string.Empty;
    public int Credits { get; set; }
}
