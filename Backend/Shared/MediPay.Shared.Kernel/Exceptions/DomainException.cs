namespace MediPay.Shared.Kernel.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message) : base(message) { }
    public DomainException(string message, Exception inner) : base(message, inner) { }
}

public class NotFoundExcception(string entityName, object key) : DomainException($"{entityName} با شناسه ی {key} یافت نشد.") { }

public class BusinessRuleExcception(string message) : DomainException(message) { }

public class UnauthorizedExcception(string message = "دسترسی غیرمجاز.") : DomainException(message) { }

public class ValidationExcception : DomainException
{
    public IReadOnlyDictionary<string, string[]> ValidationErrors { get; } = new Dictionary<string, string[]>();
    public ValidationExcception(IDictionary<string, string[]> validationErrors) : base("یک یا چند خطای اعتبارسنجی رخ داده است.")
    {
        _ = new Dictionary<string, string[]>(validationErrors);
    }
}