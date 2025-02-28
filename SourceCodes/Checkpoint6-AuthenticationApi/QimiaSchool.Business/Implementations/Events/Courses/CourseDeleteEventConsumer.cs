using MassTransit;
using Microsoft.Extensions.Logging;

namespace QimiaSchool.Business.Implementations.Events.Courses
{
    internal class CourseDeleteEventConsumer : IConsumer<CourseDeleteEvent>
    {
        private readonly ILogger<CourseDeleteEventConsumer> _logger;

        public CourseDeleteEventConsumer(ILogger<CourseDeleteEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<CourseDeleteEvent> context)
        {
            _logger.LogInformation("Course deleted: {@Course}", context.Message);

            return Task.CompletedTask;
        }
    }
}