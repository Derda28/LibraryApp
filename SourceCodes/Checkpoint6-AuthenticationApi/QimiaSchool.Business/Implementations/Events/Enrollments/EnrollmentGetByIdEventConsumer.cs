using MassTransit;
using Microsoft.Extensions.Logging;

namespace QimiaSchool.Business.Implementations.Events.Enrollments
{
    internal class EnrollmentGetByIdEventConsumer : IConsumer<EnrollmentGetByIdEvent>
    {
        private readonly ILogger<EnrollmentGetByIdEventConsumer> _logger;

        public EnrollmentGetByIdEventConsumer(ILogger<EnrollmentGetByIdEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<EnrollmentGetByIdEvent> context)
        {
            _logger.LogInformation("Enrollment retrieved: {@Enrollment}", context.Message);

            return Task.CompletedTask;
        }
    }
}