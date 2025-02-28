using QimiaSchool.DataAccess.Entities;

namespace QimiaSchool.Business.Implementations.Events.Enrollments
{
    public class EnrollmentUpdateEvent
    {
        public int ID { get; set; }
        public Grade Grade { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
    }
}