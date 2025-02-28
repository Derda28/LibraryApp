using MassTransit;
using Microsoft.Extensions.Logging;

namespace QimiaSchool.Business.Implementations.Events.Students
{
    public class StudentGetByIdEventConsumer : IConsumer<StudentGetByIdEvent>
    {
        private readonly ILogger<StudentGetByIdEventConsumer> _logger;

        public StudentGetByIdEventConsumer(ILogger<StudentGetByIdEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<StudentGetByIdEvent> context)
        {
            _logger.LogInformation("Student GetById event received: {@StudentGetByIdEvent}", context.Message);

            // Handle the event logic here

            return Task.CompletedTask;
        }
    }
}
