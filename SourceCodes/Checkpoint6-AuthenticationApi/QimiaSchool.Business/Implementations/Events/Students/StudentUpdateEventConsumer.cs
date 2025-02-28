using MassTransit;
using Microsoft.Extensions.Logging;

namespace QimiaSchool.Business.Implementations.Events.Students
{
    internal class StudentUpdateEventConsumer : IConsumer<StudentUpdateEvent>
    {
        private readonly ILogger<StudentUpdateEventConsumer> _logger;

        public StudentUpdateEventConsumer(ILogger<StudentUpdateEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<StudentUpdateEvent> context)
        {
            _logger.LogInformation("Student updated: {@Student}", context.Message);

            return Task.CompletedTask;
        }
    }
}