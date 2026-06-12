namespace MediPay.Shared.Messaging.Configuration;

public sealed class RabbitMqSettings
{
    public const string SectionName = "RabbitMQ";

    public string Host { get; init; } = "localhost";
    public int Port { get; init; } = 5672;
    public string Username { get; init; } = "guest";
    public string Password { get; init; } = "guest";
    public string VirtualHost { get; init; } = "/";
    public ushort PrefetchCount { get; init; } = 10;
    public bool AutoDelete { get; init; } = false;
    public bool Durable { get; init; } = true;
}