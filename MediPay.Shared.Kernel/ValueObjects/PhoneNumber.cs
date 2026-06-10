using System.Text.RegularExpressions;

namespace MediPay.Shared.Kernel.ValueObjects;

public sealed class PhoneNumber : IEquatable<PhoneNumber>
{
    private static readonly Regex IranianPhoneRegex = new(@"^(\+98|0)?9\d{9}$", RegexOptions.Compiled);

    public string Value { get; }

    private PhoneNumber()
    {
        Value = string.Empty;
    }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("شماره موبایل نمی تواند خالی باشد.");

        var normalized = Value!.Trim().Replace(" ", "");

        if (!IranianPhoneRegex.IsMatch(normalized)) throw new ArgumentException($"شماره موبایل {value} معتبر نیست.");

        value = normalized.StartsWith("+98") ? "0" + normalized[3..] : normalized;
    }

    public bool Equals(PhoneNumber? other) => other != null && other.Value == Value;

    public override bool Equals(object? obj) => Equals(obj as PhoneNumber);

    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value;

    public static bool operator ==(PhoneNumber? left, PhoneNumber? right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }
    public static bool operator !=(PhoneNumber? left, PhoneNumber? right) => !(left == right);
    public static implicit operator string(PhoneNumber phone) => phone.Value;
}
