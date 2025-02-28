namespace QimiaSchool.Business.Implementations.Events.Students;

public record StudentCreatedEvent
{
    public int ID { get; init; }
    public string LastName { get; init; } = string.Empty;
    public string FirstMidName { get; init; } = string.Empty;
}
