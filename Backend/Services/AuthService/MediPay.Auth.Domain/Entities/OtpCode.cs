using MediPay.Auth.Domain.Enums;
using MediPay.Shared.Kernel.Common;
using MediPay.Shared.Kernel.Exceptions;

namespace MediPay.Auth.Domain.Entities;

public sealed class OtpCode : BaseEntity
{
    public Guid UserId { get; private set; }
    public string Code { get; private set; } = default!;
    public OtpPurpose Purpose { get; private set; }
    public OtpStatus Status { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public int FailedAttempts { get; private set; } = 0;
    public const int MaxFailedAttempts = 3;
    public const int OtpLifetimeMinutes = 2;

    // Navigation
    public User User { get; private set; } = default!;

    private OtpCode() { }

    public static OtpCode Create(Guid userId, string code, OtpPurpose purpose)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new DomainException("کد OTP نمی‌تواند خالی باشد.");

        return new OtpCode
        {
            UserId = userId,
            Code = code,
            Purpose = purpose,
            Status = OtpStatus.Active,
            ExpiresAt = DateTime.UtcNow.AddMinutes(OtpLifetimeMinutes)
        };
    }

    public bool IsExpired => DateTime.UtcNow > ExpiresAt;
    public bool IsValid => Status == OtpStatus.Active && !IsExpired;

    public void Verify(string inputCode)
    {
        if (Status == OtpStatus.Used)
            throw new DomainException("این کد قبلاً استفاده شده است.");

        if (Status == OtpStatus.Expired || IsExpired)
            throw new DomainException("کد OTP منقضی شده است.");

        if (FailedAttempts >= MaxFailedAttempts)
            throw new DomainException("تعداد تلاش‌های ناموفق بیش از حد مجاز است.");

        if (Code != inputCode)
        {
            FailedAttempts++;
            SetUpdatedAt();

            if (FailedAttempts >= MaxFailedAttempts)
            {
                Status = OtpStatus.Expired;
                throw new DomainException("کد اشتباه است. OTP به دلیل تلاش‌های ناموفق منقضی شد.");
            }

            throw new DomainException($"کد اشتباه است. {MaxFailedAttempts - FailedAttempts} تلاش باقی مانده.");
        }

        Status = OtpStatus.Used;
        SetUpdatedAt();
    }

    public void Expire()
    {
        Status = OtpStatus.Expired;
        SetUpdatedAt();
    }
}