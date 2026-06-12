namespace MediPay.Auth.Domain.Enums;

public enum OtpPurpose
{
    PhoneVerification = 1,  // تأیید شماره موبایل
    Login = 2,              // ورود با OTP
    ChangePassword = 3,     // تغییر رمز عبور
    ChangePhone = 4         // تغییر شماره موبایل
}

public enum OtpStatus
{
    Active = 1,
    Used = 2,
    Expired = 3
}

public enum MembershipStatus
{
    Pending = 1,    // در انتظار تأیید
    Accepted = 2,   // تأیید شده
    Rejected = 3,   // رد شده
    Cancelled = 4   // لغو شده
}

public enum MembershipRequestedBy
{
    Doctor = 1,
    Hospital = 2,
    Company = 3,
    Employee = 4
}