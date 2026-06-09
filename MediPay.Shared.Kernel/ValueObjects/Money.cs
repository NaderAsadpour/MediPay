using System.Security;

namespace MediPay.Shared.Kernel.ValueObjects;

public sealed class Money : IEquatable<Money>
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    private Money()
    {
        Currency = string.Empty;
    }

    public Money(decimal amount, string currency = "IRR")
    {
        if (amount < 0) throw new ArgumentOutOfRangeException("مبلغ نمی تواند منفی باشد.");
        if (string.IsNullOrEmpty(currency)) throw new ArgumentNullException("واحد پول نمی تواند خالی باشد.");

        Amount = amount;
        Currency = currency.ToUpperInvariant();
    }

    public static Money Zero(string currency = "IRR") => new Money(0, currency);

    public Money Add(Money other)
    {
        EnsureSameCurrency(other);
        return new Money(Amount + other.Amount, Currency);
    }

    public Money Subtrack(Money other)
    {
        EnsureSameCurrency(other);
        return new Money(Amount - other.Amount, Currency);
    }

    public Money Multiply(decimal facctor) => new(Amount * facctor, Currency);

    public bool IsGreaterThan(Money other)
    {
        EnsureSameCurrency(other);
        return Amount > other.Amount;
    }

    private void EnsureSameCurrency(Money other)
    {
        if (Currency != other.Currency) throw new InvalidOperationException($"نمیتوان {Currency} و {other.Currency} را با هم محاسبه کرد.");
    }

    public bool Equals(Money? other) => other is not null && Amount == other.Amount && Currency == other.Currency;

    //Overrides
    public override bool Equals(object? obj) => obj is Money mponey && Equals(mponey);
    public override int GetHashCode() => HashCode.Combine(Amount, Currency);
    public override string ToString() => $"{Amount:NO} {Currency}";

    //Operator Overloading
    public static Money operator +(Money left, Money right)
    {
        left.EnsureSameCurrency(right);
        return new Money(left.Amount + right.Amount, left.Currency);
    }

    public static Money operator -(Money left, Money right)
    {
        left.EnsureSameCurrency(right);
        return new Money(left.Amount - right.Amount, left.Currency);
    }

    public static Money operator *(Money left, decimal facctor) => new(left.Amount * facctor, left.Currency);

    public static Money operator /(Money left, decimal devisor)
    {
        if (devisor == 0) throw new DivideByZeroException("تقسیم بر صفر مجاز نیست.");
        return new Money(left.Amount / devisor, left.Currency);
    }

    public static bool operator >(Money left, Money right)
    {
        left.EnsureSameCurrency(right);
        return left.Amount > right.Amount;
    }

    public static bool operator <(Money left, Money right)
    {
        left.EnsureSameCurrency(right);
        return left.Amount < right.Amount;
    }

    public static bool operator >=(Money left, Money right)
    {
        left.EnsureSameCurrency(right);
        return left.Amount >= right.Amount;
    }

    public static bool operator <=(Money left, Money right)
    {
        left.EnsureSameCurrency(right);
        return left.Amount <= right.Amount;
    }

    public static bool operator ==(Money? left, Money? right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    public static bool operator !=(Money? left, Money? right) => !(left == right);
}
