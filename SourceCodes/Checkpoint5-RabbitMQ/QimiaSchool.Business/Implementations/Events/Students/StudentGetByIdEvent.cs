using MassTransit;
using Microsoft.Extensions.Logging;

namespace QimiaSchool.Business.Implementations.Events.Students
{
    public class StudentGetByIdEvent
    {
        public int StudentId { get; set; }
    }
}