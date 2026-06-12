namespace MediPay.Shared.Contracts.Events;

public record CreditRequestSubmittedEvent
{
    public Guid CreditRequestId { get; init; }
    public Guid PatientUserId { get; init; }
    public decimal Amount { get; init; }
    public DateTime SubmittedAt { get; init; }
}

public record CreditRequestApprovedEvent
{
    public Guid CreditRequestId { get; init; }
    public Guid PatientUserId { get; init; }
    public decimal ApprovedAmount { get; init; }
    public int InstallmentsCount { get; init; }
    public DateTime ApprovedAt { get; init; }
}

public record CreditRequestRejectedEvent
{
    public Guid CreditRequestId { get; init; }
    public Guid PatientUserId { get; init; }
    public string Reason { get; init; } = default!;
    public DateTime RejectedAt { get; init; }
}

public record CreditDefaultedEvent
{
    public Guid CreditRequestId { get; init; }
    public Guid PatientUserId { get; init; }
    public DateTime DefaultedAt { get; init; }
}

public record CreditSettledEvent
{
    public Guid CreditRequestId { get; init; }
    public Guid PatientUserId { get; init; }
    public DateTime SettledAt { get; init; }
}