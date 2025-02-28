using MassTransit;
using Microsoft.Extensions.Logging;

namespace QimiaSchool.Business.Implementations.Events.Enrollments;
internal class EnrollmentCreatedEventConsumer : IConsumer<EnrollmentCreatedEvent>
{
    private readonly ILogger<EnrollmentCreatedEventConsumer> _logger;

    public EnrollmentCreatedEventConsumer(ILogger<EnrollmentCreatedEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<EnrollmentCreatedEvent> context)
    {
        _logger.LogInformation("Enrollment created: {@Enrollment}", context.Message);

        return Task.CompletedTask;
    }
}
