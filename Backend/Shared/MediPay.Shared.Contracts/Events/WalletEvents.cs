namespace MediPay.Shared.Contracts.Events;

// ولت ایجاد شد
public record WalletCreatedEvent
{
    public Guid WalletId { get; init; }
    public Guid UserId { get; init; }
    public DateTime CreatedAt { get; init; }
}

// ولت شارژ شد (واریز مستقیم)
public record WalletChargedEvent
{
    public Guid WalletId { get; init; }
    public Guid UserId { get; init; }
    public decimal Amount { get; init; }
    public string PaymentReference { get; init; } = default!;
    public DateTime ChargedAt { get; init; }
}

// از ولت برداشت شد
public record WalletWithdrawnEvent
{
    public Guid WalletId { get; init; }
    public Guid UserId { get; init; }
    public decimal Amount { get; init; }
    public string PaymentReference { get; init; } = default!;
    public DateTime WithdrawnAt { get; init; }
}

// پول از ولت بیمار به ولت پزشک منتقل شد (بابت وام)
public record WalletTransferredEvent
{
    public Guid FromWalletId { get; init; }
    public Guid ToWalletId { get; init; }
    public Guid FromUserId { get; init; }
    public Guid ToUserId { get; init; }
    public decimal Amount { get; init; }
    public Guid LoanId { get; init; }
    public DateTime TransferredAt { get; init; }
}

// موجودی قفل شد (بابت وام)
public record WalletBalanceLockedEvent
{
    public Guid WalletId { get; init; }
    public Guid UserId { get; init; }
    public decimal LockedAmount { get; init; }
    public Guid LoanId { get; init; }
    public DateTime LockedAt { get; init; }
}

// قفل موجودی آزاد شد (وام تسویه شد)
public record WalletBalanceUnlockedEvent
{
    public Guid WalletId { get; init; }
    public Guid UserId { get; init; }
    public decimal UnlockedAmount { get; init; }
    public Guid LoanId { get; init; }
    public DateTime UnlockedAt { get; init; }
}

// موجودی ناکافی
public record WalletInsufficientBalanceEvent
{
    public Guid WalletId { get; init; }
    public Guid UserId { get; init; }
    public decimal RequestedAmount { get; init; }
    public decimal AvailableBalance { get; init; }
    public DateTime OccurredAt { get; init; }
}