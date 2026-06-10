namespace MediPay.Shared.Kernel.Common;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTime CreateAt { get; protected set; } = DateTime.UtcNow;
    public DateTime? UpdateAt { get; protected set; }
    public bool IsDelete { get; protected set; } = false;

    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void SetUpdatedAt() => UpdateAt = DateTime.UtcNow;

    public void SoftDelete()
    {
        IsDelete = true;
        SetUpdatedAt();
    }
}
