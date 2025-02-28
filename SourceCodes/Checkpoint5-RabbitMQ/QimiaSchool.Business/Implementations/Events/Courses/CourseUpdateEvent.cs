namespace QimiaSchool.Business.Implementations.Events.Courses
{
    public class CourseUpdateEvent
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
    }
}