using MassTransit;
using Microsoft.Extensions.Logging;

namespace QimiaSchool.Business.Implementations.Events.Students
{
    internal class StudentDeleteEventConsumer : IConsumer<StudentDeleteEvent>
    {
        private readonly ILogger<StudentDeleteEventConsumer> _logger;

        public StudentDeleteEventConsumer(ILogger<StudentDeleteEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<StudentDeleteEvent> context)
        {
            _logger.LogInformation("Student deleted: {@Student}", context.Message);

            return Task.CompletedTask;
        }
    }
}