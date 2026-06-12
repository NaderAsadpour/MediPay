namespace MediPay.Shared.Contracts.Events;

public record UserRegisteredEvent
{
    public Guid UserId { get; init; }
    public string PhoneNumber { get; init; } = default!;
    public string NationalCode { get; init; } = default!;
    public DateTime RegisteredAt { get; set; }
}

public record UserDeactivatedEvent
{
    public Guid UserId { get; init; }
    public DateTime DeactivatedAt { get; init; }
}

public record UserPasswordChangedEvent
{
    public Guid UserId { get; init; }
    public DateTime ChangedAt { get; init; }
}

public record UserCompletedInfoEvent
{
    public Guid UserId { get; init; }
    public string NationalCode { get; init; } = default!;
    public DateTime CompletedAt { get; init; }
}

public record UserAddressAddedEvent
{
    public Guid UserId { get; init; }
    public string Province { get; init; } = default!;
    public string City { get; init; } = default!;
    public string FullAddress { get; init; } = default!;
    public DateTime AddedAt { get; init; }
}

public record UserSuspiciousLoginEvent
{
    public Guid UserId { get; init; }
    public string IpAddress { get; init; } = default!;
    public DateTime LoginAt { get; init; }
}

public record DoctorContractSignedEvent
{ 
    public Guid DoctorUserId { get; init; }
    public DateTime SignedAt { get; init; }
}

public record DoctorVerifiedEvent 
{
    public Guid DoctorUserId { get; init; }
    public Guid AdminId { get; init; }
    public DateTime VerifiedAt { get; init; }
}

public record DoctorNeedsRevisionEvent
{
    public Guid DoctorUserId { get; init; }
    public Guid AdminId { get; init; }
    public string Reason { get; init; } = default!;
    public DateTime RequestedAt { get; init; }
}

public record DoctorRejectedEvent 
{
    public Guid DoctorUserId { get; init; }
    public Guid AdminId { get; init; }
    public string Reason { get; init; } = default!;
    public DateTime RejectedAt { get; init; }
}
