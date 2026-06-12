namespace MediPay.Shared.Messaging.Constants;

public static class Exchanges
{
    public const string User = "medipay.user";
    public const string Doctor = "medipay.doctor";
    public const string Credit = "medipay.credit";
    public const string Installment = "medipay.installment";
    public const string Ticket = "medipay.ticket";
    public const string Notification = "medipay.notification";
    public const string Wallet = "medipay.wallet";
    public const string Organization = "medipay.organization";
}

public static class Queues
{
    // User
    public const string UserRegistered = "medipay.user.registered";
    public const string UserDeactivated = "medipay.user.deactivated";
    public const string UserPasswordChanged = "medipay.user.password-changed";
    public const string UserProfileCompleted = "medipay.user.profile-completed";

    // Doctor
    public const string DoctorRegistered = "medipay.doctor.registered";
    public const string DoctorProfileCompleted = "medipay.doctor.profile-completed";
    public const string DoctorContractSigned = "medipay.doctor.contract-signed";
    public const string DoctorVerified = "medipay.doctor.verified";
    public const string DoctorNeedsRevision = "medipay.doctor.needs-revision";
    public const string DoctorRejected = "medipay.doctor.rejected";

    // Credit
    public const string CreditSubmitted = "medipay.credit.submitted";
    public const string CreditApproved = "medipay.credit.approved";
    public const string CreditRejected = "medipay.credit.rejected";
    public const string CreditDefaulted = "medipay.credit.defaulted";
    public const string CreditSettled = "medipay.credit.settled";

    // Installment
    public const string InstallmentPlanCreated = "medipay.installment.plan-created";
    public const string InstallmentPaid = "medipay.installment.paid";
    public const string InstallmentOverdue = "medipay.installment.overdue";
    public const string InstallmentPlanCompleted = "medipay.installment.plan-completed";
    public const string DoctorPaymentProcessed = "medipay.installment.doctor-payment";

    // Ticket
    public const string TicketCreated = "medipay.ticket.created";
    public const string TicketReplied = "medipay.ticket.replied";
    public const string TicketClosed = "medipay.ticket.closed";

    // Wallet
    public const string WalletCreated = "medipay.wallet.created";
    public const string WalletCharged = "medipay.wallet.charged";
    public const string WalletWithdrawn = "medipay.wallet.withdrawn";
    public const string WalletTransferred = "medipay.wallet.transferred";
    public const string WalletBalanceLocked = "medipay.wallet.balance-locked";
    public const string WalletBalanceUnlocked = "medipay.wallet.balance-unlocked";
    public const string WalletInsufficientBalance = "medipay.wallet.insufficient-balance";

    // Organization
    public const string HospitalRegistered = "medipay.organization.hospital-registered";
    public const string CompanyRegistered = "medipay.organization.company-registered";
    public const string DoctorHospitalRequested = "medipay.organization.doctor-hospital-requested";
    public const string DoctorHospitalAccepted = "medipay.organization.doctor-hospital-accepted";
    public const string DoctorHospitalRejected = "medipay.organization.doctor-hospital-rejected";
    public const string CompanyEmployeeRequested = "medipay.organization.employee-requested";
    public const string CompanyEmployeeAccepted = "medipay.organization.employee-accepted";
}