namespace MediPay.Shared.Contracts.Events;

// نوتیفیکیشن ارسال شد
public record NotificationSentEvent
{
    public Guid NotificationId { get; init; }
    public Guid UserId { get; init; }
    public int NotificationTypeId { get; init; }
    public string Recipient { get; init; } = default!;
    public DateTime SentAt { get; init; }
}

// نوتیفیکیشن شکست خورد
public record NotificationFailedEvent
{
    public Guid NotificationId { get; init; }
    public Guid UserId { get; init; }
    public int NotificationTypeId { get; init; } 
    public string Recipient { get; init; } = default!;
    public string ErrorMessage { get; init; } = default!;
    public int RetryCount { get; init; }
    public DateTime FailedAt { get; init; }
}