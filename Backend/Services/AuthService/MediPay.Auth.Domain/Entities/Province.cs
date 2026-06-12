using MediPay.Shared.Kernel.Common;

namespace MediPay.Auth.Domain.Entities;

public sealed class Province : BaseEntity
{
    public string Name { get; private set; } = default!;
    public string Code { get; private set; } = default!; // کد استان

    private readonly List<City> _cities = [];
    public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();

    private Province() { }

    public static Province Create(string name, string code)
    {
        return new Province
        {
            Name = name.Trim(),
            Code = code.Trim()
        };
    }
}