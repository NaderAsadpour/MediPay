using MediPay.Auth.Domain.Events;
using MediPay.Shared.Kernel.Common;
using MediPay.Shared.Kernel.Enums;
using MediPay.Shared.Kernel.ValueObjects;

namespace MediPay.Auth.Domain.Entities;

public sealed class User : BaseEntity
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string NationalCode { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public PhoneNumber PhoneNumber { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public UserType UserType { get; private set; }
    public UserRole? Role { get; private set; }        // فقط Admin و Accountant
    public Gender Gender { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public bool IsActive { get; private set; } = true;
    public bool IsPhoneVerified { get; private set; } = false;
    public string? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpiresAt { get; private set; }
    public DateTime? LastLoginAt { get; private set; }

    // Navigation
    private readonly List<Address> _addresses = [];
    public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

    private User() { }

    // ── Factory Methods ───────────────────────────────────────

    public static User CreatePatient(
        string firstName,
        string lastName,
        string nationalCode,
        PhoneNumber phoneNumber,
        string passwordHash,
        Gender gender,
        DateTime? birthDate = null)
    {
        var user = new User
        {
            FirstName = firstName.Trim(),
            LastName = lastName.Trim(),
            NationalCode = nationalCode.Trim(),
            Email = string.Empty,
            PhoneNumber = phoneNumber,
            PasswordHash = passwordHash,
            UserType = UserType.Patient,
            Gender = gender,
            BirthDate = birthDate
        };

        user.AddDomainEvent(new UserRegisteredDomainEvent(
            user.Id, user.FullName, phoneNumber.Value, UserType.Patient));

        return user;
    }

    public static User CreateDoctor(
        string firstName,
        string lastName,
        string nationalCode,
        PhoneNumber phoneNumber,
        string passwordHash,
        Gender gender)
    {
        var user = new User
        {
            FirstName = firstName.Trim(),
            LastName = lastName.Trim(),
            NationalCode = nationalCode.Trim(),
            Email = string.Empty,
            PhoneNumber = phoneNumber,
            PasswordHash = passwordHash,
            UserType = UserType.Doctor,
            Gender = gender
        };

        user.AddDomainEvent(new UserRegisteredDomainEvent(
            user.Id, user.FullName, phoneNumber.Value, UserType.Doctor));

        return user;
    }

    public static User CreateHospital(
        string name,
        PhoneNumber phoneNumber,
        string passwordHash)
    {
        var user = new User
        {
            FirstName = name.Trim(),
            LastName = string.Empty,
            NationalCode = string.Empty,
            Email = string.Empty,
            PhoneNumber = phoneNumber,
            PasswordHash = passwordHash,
            UserType = UserType.Hospital,
            Gender = Gender.Other
        };

        user.AddDomainEvent(new UserRegisteredDomainEvent(
            user.Id, name, phoneNumber.Value, UserType.Hospital));

        return user;
    }

    public static User CreateCompany(
        string name,
        PhoneNumber phoneNumber,
        string passwordHash)
    {
        var user = new User
        {
            FirstName = name.Trim(),
            LastName = string.Empty,
            NationalCode = string.Empty,
            Email = string.Empty,
            PhoneNumber = phoneNumber,
            PasswordHash = passwordHash,
            UserType = UserType.Company,
            Gender = Gender.Other
        };

        user.AddDomainEvent(new UserRegisteredDomainEvent(
            user.Id, name, phoneNumber.Value, UserType.Company));

        return user;
    }

    public static User CreateAdmin(
        string firstName,
        string lastName,
        PhoneNumber phoneNumber,
        string passwordHash)
    {
        var user = new User
        {
            FirstName = firstName.Trim(),
            LastName = lastName.Trim(),
            NationalCode = string.Empty,
            Email = string.Empty,
            PhoneNumber = phoneNumber,
            PasswordHash = passwordHash,
            UserType = UserType.Patient,
            Role = UserRole.Admin,
            Gender = Gender.Other
        };

        return user;
    }

    // ── Behaviours ────────────────────────────────────────────

    public string FullName => UserType is UserType.Hospital or UserType.Company
        ? FirstName
        : $"{FirstName} {LastName}".Trim();

    public void VerifyPhone()
    {
        IsPhoneVerified = true;
        SetUpdatedAt();
    }

    public void SetRefreshToken(string token, DateTime expiresAt)
    {
        RefreshToken = token;
        RefreshTokenExpiresAt = expiresAt;
        LastLoginAt = DateTime.UtcNow;
        SetUpdatedAt();
    }

    public bool IsRefreshTokenValid(string token) =>
        RefreshToken == token &&
        RefreshTokenExpiresAt > DateTime.UtcNow;

    public void RevokeRefreshToken()
    {
        RefreshToken = null;
        RefreshTokenExpiresAt = null;
        SetUpdatedAt();
    }

    public void ChangePassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
        RevokeRefreshToken();
        SetUpdatedAt();
        AddDomainEvent(new PasswordChangedDomainEvent(Id));
    }

    public void UpdateProfile(
        string firstName,
        string lastName,
        string email,
        Gender gender,
        DateTime? birthDate)
    {
        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        Email = email.Trim().ToLowerInvariant();
        Gender = gender;
        BirthDate = birthDate;
        SetUpdatedAt();
    }

    public void AddAddress(Address address)
    {
        _addresses.Add(address);
        SetUpdatedAt();
    }

    public void Deactivate()
    {
        IsActive = false;
        RevokeRefreshToken();
        SetUpdatedAt();
    }

    public void Activate()
    {
        IsActive = true;
        SetUpdatedAt();
    }
}