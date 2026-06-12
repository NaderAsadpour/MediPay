namespace MediPay.Shared.Contracts.Events;

// بیمارستان ثبت‌نام کرد
public record HospitalRegisteredEvent
{
    public Guid HospitalId { get; init; }
    public string HospitalName { get; init; } = default!;
    public string PhoneNumber { get; init; } = default!;
    public DateTime RegisteredAt { get; init; }
}

// شرکت ثبت‌نام کرد
public record CompanyRegisteredEvent
{
    public Guid CompanyId { get; init; }
    public string CompanyName { get; init; } = default!;
    public string PhoneNumber { get; init; } = default!;
    public DateTime RegisteredAt { get; init; }
}

// درخواست عضویت پزشک در بیمارستان
public record DoctorHospitalMembershipRequestedEvent
{
    public Guid DoctorId { get; init; }
    public Guid HospitalId { get; init; }
    public Guid RequestedById { get; init; } // پزشک یا بیمارستان
    public DateTime RequestedAt { get; init; }
}

// عضویت تأیید شد
public record DoctorHospitalMembershipAcceptedEvent
{
    public Guid DoctorId { get; init; }
    public Guid HospitalId { get; init; }
    public DateTime AcceptedAt { get; init; }
}

// عضویت رد شد
public record DoctorHospitalMembershipRejectedEvent
{
    public Guid DoctorId { get; init; }
    public Guid HospitalId { get; init; }
    public string Reason { get; init; } = default!;
    public DateTime RejectedAt { get; init; }
}

// کارمند به شرکت اضافه شد
public record CompanyEmployeeMembershipRequestedEvent
{
    public Guid EmployeeId { get; init; }
    public Guid CompanyId { get; init; }
    public Guid RequestedById { get; init; }
    public DateTime RequestedAt { get; init; }
}

// عضویت کارمند تأیید شد
public record CompanyEmployeeMembershipAcceptedEvent
{
    public Guid EmployeeId { get; init; }
    public Guid CompanyId { get; init; }
    public decimal CreditLimit { get; init; } // سقف اعتبار تعریف شده توسط شرکت
    public DateTime AcceptedAt { get; init; }
}