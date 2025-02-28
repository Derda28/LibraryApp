using System;

namespace QimiaSchool.Business.Implementations.Events.Students
{
    public class StudentUpdateEvent
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set;}

    }
}