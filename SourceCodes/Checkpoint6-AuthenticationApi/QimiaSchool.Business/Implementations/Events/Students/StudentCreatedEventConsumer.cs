using MassTransit;
using Microsoft.Extensions.Logging;

namespace QimiaSchool.Business.Implementations.Events.Students;
public class StudentCreatedEventConsumer : IConsumer<StudentCreatedEvent>
{
    private readonly ILogger<StudentCreatedEventConsumer> _logger;

    public StudentCreatedEventConsumer(ILogger<StudentCreatedEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<StudentCreatedEvent> context)
    {
        _logger.LogInformation("Student created: {@Student}", context.Message);

        return Task.CompletedTask;
    }
}
