using MediPay.Shared.Kernel.Common;
using MediPay.Shared.Kernel.Enums;

namespace MediPay.Auth.Domain.Events;

public sealed class UserRegisteredDomainEvent(
    Guid userId,
    string fullName,
    string phoneNumber,
    UserType userType) : DomainEvent
{
    public Guid UserId { get; } = userId;
    public string FullName { get; } = fullName;
    public string PhoneNumber { get; } = phoneNumber;
    public UserType UserType { get; } = userType;
}

public sealed class PasswordChangedDomainEvent(Guid userId) : DomainEvent
{
    public Guid UserId { get; } = userId;
}

public sealed class PhoneVerifiedDomainEvent(Guid userId) : DomainEvent
{
    public Guid UserId { get; } = userId;
}

public sealed class UserDeactivatedDomainEvent(Guid userId) : DomainEvent
{
    public Guid UserId { get; } = userId;
}