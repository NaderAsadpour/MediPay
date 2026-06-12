using MediPay.Auth.Domain.Entities;
using MediPay.Shared.Kernel.Common;
using MediPay.Shared.Kernel.Exceptions;

public sealed class Address : BaseEntity
{
    public Guid UserId { get; private set; }
    public Guid CityId { get; private set; }          // ← فقط CityId
    public string Street { get; private set; } = default!;
    public string PostalCode { get; private set; } = default!;
    public string FullAddress { get; private set; } = default!;
    public bool IsDefault { get; private set; } = false;
    public double? Latitude { get; private set; }
    public double? Longitude { get; private set; }

    // Navigation
    public User User { get; private set; } = default!;
    public City City { get; private set; } = default!; // ← از City میخونی Province رو

    private Address() { }

    public static Address Create(
        Guid userId,
        Guid cityId,
        string street,
        string postalCode,
        string fullAddress,
        bool isDefault = false,
        double? latitude = null,
        double? longitude = null)
    {
        if (string.IsNullOrWhiteSpace(postalCode) || postalCode.Length != 10)
            throw new DomainException("کد پستی باید ۱۰ رقم باشد.");

        return new Address
        {
            UserId = userId,
            CityId = cityId,
            Street = street.Trim(),
            PostalCode = postalCode.Trim(),
            FullAddress = fullAddress.Trim(),
            IsDefault = isDefault,
            Latitude = latitude,
            Longitude = longitude
        };
    }

    public void SetAsDefault()
    {
        IsDefault = true;
        SetUpdatedAt();
    }

    public void UnsetDefault()
    {
        IsDefault = false;
        SetUpdatedAt();
    }

    public void Update(
        Guid cityId,
        string street,
        string postalCode,
        string fullAddress)
    {
        CityId = cityId;
        Street = street.Trim();
        PostalCode = postalCode.Trim();
        FullAddress = fullAddress.Trim();
        SetUpdatedAt();
    }
}