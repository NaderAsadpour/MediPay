namespace MediPay.Shared.Kernel.Common;

public interface IDomainEvent
{
    Guid EventId { get; }
    DateTime OccuredOn { get; }
}

public abstract class DomainEvent : IDomainEvent
{
    public Guid EventId { get; } = Guid.NewGuid();
    public DateTime OccuredOn { get; } = DateTime.UtcNow;
}
