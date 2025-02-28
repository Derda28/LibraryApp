

namespace QimiaSchool.DataAccess.Entities;
public class Course
{
    public int ID { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Credits { get; set; }

    public ICollection<Enrollment>? Enrollments { get; set; }
}
