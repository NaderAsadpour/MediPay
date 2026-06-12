namespace MediPay.Shared.Contracts.Events;

// تیکت جدید ثبت شد
public record TicketCreatedEvent
{
    public Guid TicketId { get; init; }
    public Guid UserId { get; init; }
    public string Subject { get; init; } = default!;
    public string Priority { get; init; } = default!;
    public DateTime CreatedAt { get; init; }
}

// ادمین پاسخ داد
public record TicketRepliedEvent
{
    public Guid TicketId { get; init; }
    public Guid UserId { get; init; } 
    public Guid AdminId { get; init; }
    public bool IsAdminReply { get; init; }
    public DateTime RepliedAt { get; init; }
}

// تیکت بسته شد
public record TicketClosedEvent
{
    public Guid TicketId { get; init; }
    public Guid UserId { get; init; }
    public DateTime ClosedAt { get; init; }
}