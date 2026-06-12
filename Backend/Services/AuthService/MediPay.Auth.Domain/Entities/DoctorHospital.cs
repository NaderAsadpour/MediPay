using MediPay.Auth.Domain.Enums;
using MediPay.Shared.Kernel.Common;
using MediPay.Shared.Kernel.Exceptions;

namespace MediPay.Auth.Domain.Entities;

public sealed class DoctorHospital : BaseEntity
{
    public Guid DoctorId { get; private set; }
    public Guid HospitalId { get; private set; }
    public MembershipStatus Status { get; private set; }
    public MembershipRequestedBy RequestedBy { get; private set; }
    public DateTime RequestedAt { get; private set; }
    public DateTime? RespondedAt { get; private set; }
    public string? RejectionReason { get; private set; }

    // Navigation
    public Doctor Doctor { get; private set; } = default!;
    public User Hospital { get; private set; } = default!;

    private DoctorHospital() { }

    public static DoctorHospital Create(
        Guid doctorId,
        Guid hospitalId,
        MembershipRequestedBy requestedBy)
    {
        return new DoctorHospital
        {
            DoctorId = doctorId,
            HospitalId = hospitalId,
            Status = MembershipStatus.Pending,
            RequestedBy = requestedBy,
            RequestedAt = DateTime.UtcNow
        };
    }

    public void Accept()
    {
        if (Status != MembershipStatus.Pending)
            throw new DomainException("این درخواست قابل تأیید نیست.");

        Status = MembershipStatus.Accepted;
        RespondedAt = DateTime.UtcNow;
        SetUpdatedAt();
    }

    public void Reject(string reason)
    {
        if (Status != MembershipStatus.Pending)
            throw new DomainException("این درخواست قابل رد کردن نیست.");

        Status = MembershipStatus.Rejected;
        RejectionReason = reason.Trim();
        RespondedAt = DateTime.UtcNow;
        SetUpdatedAt();
    }

    public void Cancel()
    {
        if (Status != MembershipStatus.Pending)
            throw new DomainException("فقط درخواست‌های در انتظار قابل لغو هستند.");

        Status = MembershipStatus.Cancelled;
        SetUpdatedAt();
    }
}