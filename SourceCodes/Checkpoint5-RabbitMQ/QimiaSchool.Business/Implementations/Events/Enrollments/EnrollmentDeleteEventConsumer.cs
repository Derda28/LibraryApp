using MassTransit;
using Microsoft.Extensions.Logging;

namespace QimiaSchool.Business.Implementations.Events.Enrollments
{
    internal class EnrollmentDeleteEventConsumer : IConsumer<EnrollmentDeleteEvent>
    {
        private readonly ILogger<EnrollmentDeleteEventConsumer> _logger;

        public EnrollmentDeleteEventConsumer(ILogger<EnrollmentDeleteEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<EnrollmentDeleteEvent> context)
        {
            _logger.LogInformation("Enrollment deleted: {@Enrollment}", context.Message);

            return Task.CompletedTask;
        }
    }
}