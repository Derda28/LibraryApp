using MassTransit;
using Microsoft.Extensions.Logging;

namespace QimiaSchool.Business.Implementations.Events.Courses
{
    internal class CourseGetByIdEventConsumer : IConsumer<CourseGetByIdEvent>
    {
        private readonly ILogger<CourseGetByIdEventConsumer> _logger;

        public CourseGetByIdEventConsumer(ILogger<CourseGetByIdEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<CourseGetByIdEvent> context)
        {
            _logger.LogInformation("Course retrieved: {@Course}", context.Message);

            return Task.CompletedTask;
        }
    }
}