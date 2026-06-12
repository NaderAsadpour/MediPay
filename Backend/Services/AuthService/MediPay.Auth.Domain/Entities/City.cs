using MediPay.Shared.Kernel.Common;

namespace MediPay.Auth.Domain.Entities;

public sealed class City : BaseEntity
{
    public string Name { get; private set; } = default!;
    public Guid ProvinceId { get; private set; }

    // Navigation
    public Province Province { get; private set; } = default!;

    private City() { }

    public static City Create(string name, Guid provinceId)
    {
        return new City
        {
            Name = name.Trim(),
            ProvinceId = provinceId
        };
    }
}