namespace MediPay.Shared.Kernel.Enums;

public enum Gender
{
    Male = 1,
    Female = 2,
    Other = 3
}

public enum UserType
{
    Patient = 1,
    Doctor = 2,
    Hospital = 4,
    Company = 3
}

public enum UserRole
{
    Admin = 1,
    Acountant = 2
}

public enum UserVerificationStatus
{
    Initial = 1,
    ProfileCompleted = 2,
    UnderReview = 3,
    Verified = 4,
    NeedsRevision = 5,
    Rejected = 6
}

public enum NotificationType
{
    SMS = 1,
    Notification = 2,
    PushNotification = 3,
    Email = 4
}