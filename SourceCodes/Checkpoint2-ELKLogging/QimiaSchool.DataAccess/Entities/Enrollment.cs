﻿

namespace QimiaSchool.DataAccess.Entities;
public class Enrollment
{
    public int ID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public Grade? Grade { get; set; }

    public Course? Course { get; set; }
    public Student? Student { get; set; }
}
