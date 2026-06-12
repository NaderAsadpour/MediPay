using MediPay.Auth.Domain.Enums;
using MediPay.Shared.Kernel.Common;
using MediPay.Shared.Kernel.Enums;
using MediPay.Shared.Kernel.Exceptions;

namespace MediPay.Auth.Domain.Entities;

public sealed class Doctor : BaseEntity
{
    public Guid UserId { get; private set; }
    public string MedicalLicenseNumber { get; private set; } = default!;
    public string Specialty { get; private set; } = default!;
    public string? Bio { get; private set; }
    public UserVerificationStatus VerificationStatus { get; private set; }
    public string? RejectionReason { get; private set; }
    public Guid? VerifiedByAdminId { get; private set; }
    public DateTime? VerifiedAt { get; private set; }

    // Navigation
    public User User { get; private set; } = default!;

    private readonly List<DoctorHospital> _hospitals = [];
    public IReadOnlyCollection<DoctorHospital> Hospitals => _hospitals.AsReadOnly();

    private Doctor() { }

    public static Doctor Create(Guid userId, string medicalLicenseNumber, string specialty)
    {
        if (string.IsNullOrWhiteSpace(medicalLicenseNumber))
            throw new DomainException("شماره نظام پزشکی الزامی است.");

        if (string.IsNullOrWhiteSpace(specialty))
            throw new DomainException("تخصص الزامی است.");

        return new Doctor
        {
            UserId = userId,
            MedicalLicenseNumber = medicalLicenseNumber.Trim(),
            Specialty = specialty.Trim(),
            VerificationStatus = UserVerificationStatus.Initial
        };
    }

    public void CompleteProfile(string bio)
    {
        Bio = bio?.Trim();
        VerificationStatus = UserVerificationStatus.ProfileCompleted;
        SetUpdatedAt();
    }

    public void SignContract()
    {
        if (VerificationStatus != UserVerificationStatus.ProfileCompleted)
            throw new DomainException("ابتدا باید پروفایل تکمیل شود.");

        VerificationStatus = UserVerificationStatus.UnderReview;
        //VerificationStatus = UserVerificationStatus.ContractSigned;
        SetUpdatedAt();
    }

    public void SubmitForReview()
    {
        if (VerificationStatus != UserVerificationStatus.UnderReview)
        //if (VerificationStatus != UserVerificationStatus.ContractSigned)
            throw new DomainException("ابتدا باید قرارداد امضا شود.");

        VerificationStatus = UserVerificationStatus.UnderReview;
        SetUpdatedAt();
    }

    public void Verify(Guid adminId)
    {
        if (VerificationStatus != UserVerificationStatus.UnderReview)
            throw new DomainException("پزشک در مرحله بررسی نیست.");

        VerificationStatus = UserVerificationStatus.Verified;
        VerifiedByAdminId = adminId;
        VerifiedAt = DateTime.UtcNow;
        SetUpdatedAt();
    }

    public void RequestRevision(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new DomainException("دلیل درخواست تکمیل اطلاعات الزامی است.");

        VerificationStatus = UserVerificationStatus.NeedsRevision;
        RejectionReason = reason.Trim();
        SetUpdatedAt();
    }

    public void Reject(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new DomainException("دلیل رد الزامی است.");

        VerificationStatus = UserVerificationStatus.Rejected;
        RejectionReason = reason.Trim();
        SetUpdatedAt();
    }
}