namespace MediPay.Shared.Messaging.Abstractions;

public interface IEventPublisher
{
    Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default)
        where T : class;
}

public interface IEventConsumer<in T> where T : class
{
    Task ConsumeAsync(T @event, CancellationToken cancellationToken = default);
}